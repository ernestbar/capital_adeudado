<%@ Control Language="C#" ClassName="legalLoteViewDato" %>

<script runat="server">
    public int id_lote
    {
        get { return int.Parse(lbl_id_lote.Text); }
        
        set
        {
            lbl_id_lote.Text = value.ToString();

            lote loteObj = new lote(value);
            lbl_localizacion.Text = loteObj.nombre_localizacion + " (" + loteObj.codigo_localizacion + ")";
            lbl_urbanizacion.Text = loteObj.nombre_urbanizacion + " (" + loteObj.codigo_urbanizacion + ")";
            lbl_manzano.Text = loteObj.codigo_manzano;
            lbl_lote.Text = loteObj.codigo;
            lbl_fecha.Text = loteObj.fecha_registro.ToString("d");
            lbl_superficie.Text = loteObj.superficie_m2.ToString("F2");
            lbl_costo.Text = loteObj.costo_m2_sus.ToString("F2");
            lbl_precio.Text = loteObj.precio_m2_sus.ToString("F2");
            if (loteObj.con_muro == true && loteObj.con_construccion == true) lbl_construccion.Text = "Muro y construccion de casa";
            else if (loteObj.con_muro == true && loteObj.con_construccion == false) lbl_construccion.Text = "Muro";
            else if (loteObj.con_muro == false && loteObj.con_construccion == true) lbl_construccion.Text = "Construccion de casa";
            else lbl_construccion.Text = "Ninguna";
            lbl_negocio_actual.Text = loteObj.nombre_negocio;
            lbl_estado_actual.Text = loteObj.nombre_estado;

            legal_negocio_lote nlObj = new legal_negocio_lote(legal_negocio_lote.Id_negociolote_actual(value));
            lbl_legal_negocio_actual.Text = nlObj.nombre_negocio + " - " + nlObj.nombre_estado + " (" + nlObj.fecha.ToString("d") +")";

            gv_folio_anteriores.DataBind();
            
            lbl_permitir_DatosDetalle.Text = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "reporteContratoDatosDetalle").ToString();
            lbl_permitir_EstadoCuenta.Text = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "reporteContratoEstadoCuenta").ToString();
            lbl_permitir_PlanPagoOriginal.Text = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "reporteContratoPlanPagoOriginal").ToString();
            lbl_permitir_PlanPagoVigente.Text = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "reporteContratoPlanPagoVigente").ToString();
            lbl_permitir_PlanPagoRestante.Text = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "reporteContratoPlanPagoRestante").ToString();
        }
    }

    protected void gv_estados_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Int32.Parse(DataBinder.Eval(e.Row.DataItem, "id_contrato").ToString()) > 0 && Int32.Parse(DataBinder.Eval(e.Row.DataItem, "id_reversion").ToString()) == 0)
            {
                ((HyperLink)e.Row.FindControl("hl_DatosDetalle")).Visible = bool.Parse(lbl_permitir_DatosDetalle.Text);
                ((HyperLink)e.Row.FindControl("hl_EstadoCuenta")).Visible = bool.Parse(lbl_permitir_EstadoCuenta.Text);
                ((HyperLink)e.Row.FindControl("hl_PlanPagoOriginal")).Visible = bool.Parse(lbl_permitir_PlanPagoOriginal.Text);
                ((HyperLink)e.Row.FindControl("hl_PlanPagoVigente")).Visible = bool.Parse(lbl_permitir_PlanPagoVigente.Text);
                ((HyperLink)e.Row.FindControl("hl_PlanPagoRestante")).Visible = bool.Parse(lbl_permitir_PlanPagoRestante.Text);
            }
            else
            {
                ((HyperLink)e.Row.FindControl("hl_reportes")).Visible = false;
                ((Panel)e.Row.FindControl("panel_reportes")).Visible = false;
            }
        }
    }

    protected void gv_intercambio_DataBound(object sender, EventArgs e)
    {
        lbl_intercambio_enun.Visible = gv_intercambio.Rows.Count.Equals(0).Equals(false);
    }

    protected void gv_folio_anteriores_DataBound(object sender, EventArgs e)
    {
        if (gv_folio_anteriores.Rows.Count < 2)
        {
            lbl_folio_anteriores.Visible = false;
            gv_folio_anteriores.Visible = false;
        }
        else
        {
            lbl_folio_anteriores.Visible = true;
            gv_folio_anteriores.Visible = true;
        }
    }
</script>
<asp:Label ID="lbl_id_lote" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_permitir_DatosDetalle" runat="server" Text="False" Visible="false"></asp:Label>
<asp:Label ID="lbl_permitir_EstadoCuenta" runat="server" Text="False" Visible="false"></asp:Label>
<asp:Label ID="lbl_permitir_PlanPagoOriginal" runat="server" Text="False" Visible="false"></asp:Label>
<asp:Label ID="lbl_permitir_PlanPagoVigente" runat="server" Text="False" Visible="false"></asp:Label>
<asp:Label ID="lbl_permitir_PlanPagoRestante" runat="server" Text="False" Visible="false"></asp:Label>

<%--<asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/inventario/inmueble/inmuebleDetalle.aspx">[WinPopUp1]</asp:WinPopUp>--%>

<asp:Panel ID="panel_lote" runat="server" GroupingText="Datos del Lote">
    <table class="viewTable" align="center" cellpadding="0" cellspacing="0">
         <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_localizacion_enun" runat="server" Text="Localización:"></asp:Label></td>
            <td class="formTdDato"><asp:Label ID="lbl_localizacion" runat="server"></asp:Label></td>
        </tr>
         <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_urbanizacion_enun" runat="server" Text="Sector:"></asp:Label></td>
            <td class="formTdDato"><asp:Label ID="lbl_urbanizacion" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_manzano_enun" runat="server" Text="Manzano:"></asp:Label></td>
            <td class="formTdDato"><asp:Label ID="lbl_manzano" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_lote_enun" runat="server" Text="Lote:"></asp:Label></td>
            <td class="formTdDato"><asp:Label ID="lbl_lote" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_fecha_enun" runat="server" Text="Fecha de registro:"></asp:Label></td>
            <td class="formTdDato"><asp:Label ID="lbl_fecha" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_superficie_enun" runat="server" Text="Superficie (m2):"></asp:Label></td>
            <td class="formTdDato"><asp:Label ID="lbl_superficie" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_costo_enun" runat="server" Text="Costo ($us/m2):"></asp:Label></td>
            <td class="formTdDato"><asp:Label ID="lbl_costo" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_precio_enun" runat="server" Text="Precio ($us/m2):"></asp:Label></td>
            <td class="formTdDato"><asp:Label ID="lbl_precio" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_construccion_enun" runat="server" Text="Construcciones:"></asp:Label></td>
            <td class="formTdDato"><asp:Label ID="lbl_construccion" runat="server"></asp:Label></td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="panel_legal_negocio" runat="server" GroupingText="Datos del Negocio (para el dpto. Legal)" >
    <table class="viewTable" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_legal_negocio_actual_enun" runat="server" Text="Negocio Actual:"></asp:Label></td>
            <td class="formTdDato"><asp:Label ID="lbl_legal_negocio_actual" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_legal_negocios_enun" runat="server" Text="Negocios anteriores:"></asp:Label></td>
            <td class="formTdDato">
                <asp:GridView ID="gv_legal_negocio" runat="server" AutoGenerateColumns="False" DataSourceID="ods_legal_negocios_lista" DataKeyNames="id_negociolote">
                    <Columns>
                        <asp:BoundField HeaderText="Negocio" DataField="negocio" />
                        <asp:BoundField HeaderText="Estado" DataField="estado" />
                        <asp:BoundField HeaderText="Fecha" DataField="fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="Usuario" DataField="audit_usuario" />
                        <asp:BoundField HeaderText="Fecha Registro" DataField="audit_fecha" />
                    </Columns>
                </asp:GridView>
                <%--[id_negociolote],[fecha],[negocio],[estado],[audit_usuario],[audit_fecha]--%>
                <asp:ObjectDataSource ID="ods_legal_negocios_lista" runat="server" TypeName="terrasur.legal_negocio_lote" SelectMethod="Lista">
                    <SelectParameters>
                        <asp:ControlParameter Name="Id_lote" Type="Int32" ControlID="lbl_id_lote" PropertyName="Text" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="panel_folio" runat="server" GroupingText="Datos del Folio real (para el dpto. Legal)">
    <table class="viewTable" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_legal_folio_enun" runat="server" Text="Folio real actual:"></asp:Label></td>
            <td class="formTdDato">
                <asp:GridView ID="gv_folio" runat="server" AutoGenerateColumns="False" DataSourceID="ods_legal_folio_lista" DataKeyNames="id_folio">
                    <Columns>
                        <asp:BoundField HeaderText="Nro. folio" DataField="numero" />
                        <asp:BoundField HeaderText="Entregado" DataField="entregado" />
                        <asp:BoundField HeaderText="F.Entregado" DataField="entregado_fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="Usuario" DataField="audit_usuario" />
                        <asp:BoundField HeaderText="Fecha Registro" DataField="audit_fecha" />
                    </Columns>
                </asp:GridView>
                <%--[id_folio],[numero],[entregado],[entregado_fecha],[audit_usuario],[audit_fecha]--%>
                <asp:ObjectDataSource ID="ods_legal_folio_lista" runat="server" TypeName="terrasur.legal_folio" SelectMethod="Lista">
                    <SelectParameters>
                        <asp:ControlParameter Name="Id_lote" Type="Int32" ControlID="lbl_id_lote" PropertyName="Text" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="formTdEnun"></td>
            <td class="formTdDato">
                <asp:Label ID="lbl_folio_anteriores" runat="server" Text="Historial de modificaciones al folio:" SkinID="lblEnun"></asp:Label>
                <asp:GridView ID="gv_folio_anteriores" runat="server" AutoGenerateColumns="False" DataSourceID="ods_legal_folio_ListaAnteriores" DataKeyNames="id_folio" OnDataBound="gv_folio_anteriores_DataBound">
                    <Columns>
                        <asp:BoundField HeaderText="Acción" DataField="accion" />
                        <asp:BoundField HeaderText="Nro. folio" DataField="numero" />
                        <asp:BoundField HeaderText="Entregado" DataField="entregado" />
                        <asp:BoundField HeaderText="F.Entregado" DataField="entregado_fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="Usuario" DataField="audit_usuario" />
                        <asp:BoundField HeaderText="Fecha Registro" DataField="audit_fecha" />
                    </Columns>
                </asp:GridView>
                <%--[id_folio],[accion],[numero],[entregado],[entregado_fecha],[audit_usuario],[audit_fecha]--%>
                <asp:ObjectDataSource ID="ods_legal_folio_ListaAnteriores" runat="server" TypeName="terrasur.legal_folio" SelectMethod="ListaAnteriores">
                    <SelectParameters>
                        <asp:ControlParameter Name="Id_lote" Type="Int32" ControlID="lbl_id_lote" PropertyName="Text" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_observacion_enun" runat="server" Text="Observaciones:"></asp:Label></td>
            <td class="formTdDato">
                <asp:GridView ID="gv_observacion" runat="server" AutoGenerateColumns="false" ShowHeader="false" DataSourceID="ods_legal_observacion_lista" DataKeyNames="id_observacion">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" width="500">
                                    <tr><td><asp:Label ID="lbl_usuario_fecha" runat="server" Text='<%# String.Format("{0} ({1})",Eval("audit_fecha"),Eval("audit_usuario")) %>' Font-Bold="true"></asp:Label></td></tr>
                                    <tr><td><asp:Label ID="lbl_obs" runat="server" Text='<%# Eval("observacion") %>'></asp:Label></td></tr>
                                    <tr><td><hr /></td></tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <%--[id_observacion],[observacion],[audit_usuario],[audit_fecha]--%>
                <asp:ObjectDataSource ID="ods_legal_observacion_lista" runat="server" TypeName="terrasur.legal_folio_observacion" SelectMethod="Lista">
                    <SelectParameters>
                        <asp:ControlParameter Name="Id_lote" Type="Int32" ControlID="lbl_id_lote" PropertyName="Text" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="panel_estado" runat="server" GroupingText="Estados del lote">
    <table class="viewTable" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_estado_actual_enun" runat="server" Text="Estado Actual:"></asp:Label></td>
            <td class="formTdDato"><asp:Label ID="lbl_estado_actual" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_estados_anteriores" runat="server" Text="Estados anteriores:"></asp:Label></td>
            <td class="formTdDato">
                <asp:GridView ID="gv_estados" runat="server" AutoGenerateColumns="False" DataSourceID="ods_estados_lista" DataKeyNames="id_estadolote" OnRowDataBound="gv_estados_RowDataBound">
                    <Columns>
                        <asp:BoundField HeaderText="Estado" DataField="nombre_estado" />
                        <asp:BoundField DataField="motivo_bloqueo" />
                        <asp:BoundField HeaderText="Fecha" DataField="fecha" />
                        <asp:BoundField HeaderText="Usuario" DataField="nombre_usuario" />
                        <asp:BoundField HeaderText="Observación" DataField="observacion" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="hl_reportes" runat="server" ImageUrl="~/images/gv/view.gif"></asp:HyperLink>
                                <asp:Panel ID="panel_reportes" runat="server" GroupingText='<%# String.Format("Reportes del contrato Nº {0}",Eval("numero_contrato")) %>' BackColor="white">
                                    <table cellpadding="0" cellspacing="0">
                                        <tr><td><asp:HyperLink ID="hl_DatosDetalle" runat="server" Text="Datos detallados del contrato" Target="_blank" NavigateUrl='<%# String.Format("~/recurso/inventario/lote/loteDetalleReporte.aspx?reporte={0}&contrato={1}", "DatosDetalle", Eval("id_contrato")) %>'></asp:HyperLink></td></tr>
                                        <tr><td><asp:HyperLink ID="hl_EstadoCuenta" runat="server" Text="Estado de cuenta" Target="_blank" NavigateUrl='<%# String.Format("~/recurso/inventario/lote/loteDetalleReporte.aspx?reporte={0}&contrato={1}", "EstadoCuenta", Eval("id_contrato")) %>'></asp:HyperLink></td></tr>
                                        <tr><td><asp:HyperLink ID="hl_PlanPagoOriginal" runat="server" Text="Plan de pagos Original" Target="_blank" NavigateUrl='<%# String.Format("~/recurso/inventario/lote/loteDetalleReporte.aspx?reporte={0}&contrato={1}", "PlanPagoOriginal", Eval("id_contrato")) %>'></asp:HyperLink></td></tr>
                                        <tr><td><asp:HyperLink ID="hl_PlanPagoVigente" runat="server" Text="Plan de pagos Vigente" Target="_blank" NavigateUrl='<%# String.Format("~/recurso/inventario/lote/loteDetalleReporte.aspx?reporte={0}&contrato={1}", "PlanPagoVigente", Eval("id_contrato")) %>'></asp:HyperLink></td></tr>
                                        <tr><td><asp:HyperLink ID="hl_PlanPagoRestante" runat="server" Text="Plan de pagos Restante" Target="_blank" NavigateUrl='<%# String.Format("~/recurso/inventario/lote/loteDetalleReporte.aspx?reporte={0}&contrato={1}", "PlanPagoRestante", Eval("id_contrato")) %>'></asp:HyperLink></td></tr>
                                    </table>
                                </asp:Panel>
                                <ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server" TargetControlID="hl_reportes" PopupControlID="panel_reportes" Position="Left">
                                </ajaxToolkit:PopupControlExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Contrato" DataField="numero_contrato" />
                        <asp:BoundField HeaderText="C. Revertido" DataField="numero_contrato_revertido" />
                    </Columns>
                </asp:GridView>
                <%--[id_manzano],[codigo],[num_lote]--%>
                <asp:ObjectDataSource ID="ods_estados_lista" runat="server" TypeName="terrasur.estado_lote" SelectMethod="ListaPorLote">
                    <SelectParameters>
                        <asp:ControlParameter Name="Id_lote" Type="Int32" ControlID="lbl_id_lote" PropertyName="Text" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_intercambio_enun" runat="server" Text="Intercambio(s):"></asp:Label></td>
            <td class="formTdDato">
                <asp:GridView ID="gv_intercambio" runat="server" AutoGenerateColumns="false" DataSourceID="ods_intercambios_lista" OnDataBound="gv_intercambio_DataBound">
                    <Columns>
                        <asp:BoundField HeaderText="Fecha" DataField="fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate"/>
                        <asp:BoundField HeaderText="Usuario" DataField="nombre_usuario" />
                        <asp:BoundField HeaderText="Nº contrato" DataField="num_contrato" />
                        <asp:TemplateField HeaderText="Empresa">
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0">
                                    <tr><td align="left"><asp:Label ID="lbl_empresa" runat="server" Text='<%# Eval("empresa") %>' SkinID="lblEnun"></asp:Label></td></tr>
                                    <tr><td align="left"><asp:Label ID="lbl_descripcion" runat="server" Text='<%# Eval("descripcion") %>' SkinID="lblDato"></asp:Label></td></tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <%--[fecha],[nombre_usuario],[empresa],[descripcion],[num_contrato]--%>
                <asp:ObjectDataSource ID="ods_intercambios_lista" runat="server" TypeName="terrasur.intercambio" SelectMethod="ListaPorLote">
                    <SelectParameters>
                        <asp:ControlParameter Name="Id_lote" Type="Int32" ControlID="lbl_id_lote" PropertyName="Text" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="panel_finanzas_negocio" runat="server" GroupingText="Negocio (para el dpto. Financiero - Sistema de Cartera)">
    <table class="viewTable" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_negocio_actual_enun" runat="server" Text="Negocio Actual:"></asp:Label></td>
            <td class="formTdDato"><asp:Label ID="lbl_negocio_actual" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="formTdEnun"><asp:Label ID="lbl_negocios_enun" runat="server" Text="Negocios anteriores:"></asp:Label></td>
            <td class="formTdDato">
                <asp:GridView ID="gv_negocios" runat="server" AutoGenerateColumns="False" DataSourceID="ods_negocios_lista" DataKeyNames="id_negociolote">
                    <Columns>
                        <asp:BoundField HeaderText="Negocio" DataField="negocio_nombre" />
                        <asp:BoundField HeaderText="Fecha" DataField="fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="Usuario" DataField="usuario_nombre" />
                    </Columns>
                </asp:GridView>
                <%--[id_manzano],[codigo],[num_lote]--%>
                <asp:ObjectDataSource ID="ods_negocios_lista" runat="server" TypeName="terrasur.negocio_lote" SelectMethod="ListaPorLote">
                    <SelectParameters>
                        <asp:ControlParameter Name="Id_lote" Type="Int32" ControlID="lbl_id_lote" PropertyName="Text" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Panel>
