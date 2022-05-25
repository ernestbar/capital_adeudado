<%@ Control Language="C#" ClassName="loteViewDato" %>

<script runat="server">
    public int id_lote
    {
        get { return int.Parse(lbl_id_lote.Text); }
        
        set
        {
            lote loteObj = new lote(value);
            lbl_localizacion.Text = loteObj.nombre_localizacion + " (" + loteObj.codigo_localizacion + ")";
            lbl_urbanizacion.Text = loteObj.nombre_urbanizacion + " (" + loteObj.codigo_urbanizacion + ")";
            lbl_manzano.Text = loteObj.codigo_manzano;
            lbl_lote.Text = loteObj.codigo;
            lbl_fecha.Text = loteObj.fecha_registro.ToString("d");
            lbl_superficie.Text = loteObj.superficie_m2.ToString("F2");
            lbl_costo.Text = loteObj.costo_m2_sus.ToString("F2");
            lbl_precio.Text = loteObj.precio_m2_sus.ToString("F2");
            lbl_propietario.Text = loteObj.anterior_propietario;
            lbl_partida.Text = loteObj.num_partida;
            if (loteObj.con_muro == true && loteObj.con_construccion == true) lbl_construccion.Text = "Muro y construccion de casa";
            else if (loteObj.con_muro == true && loteObj.con_construccion == false) lbl_construccion.Text = "Muro";
            else if (loteObj.con_muro == false && loteObj.con_construccion == true) lbl_construccion.Text = "Construccion de casa";
            else lbl_construccion.Text = "Ninguna";
            lbl_negocio_actual.Text = loteObj.nombre_negocio;
            lbl_estado_actual.Text = loteObj.nombre_estado;
            lbl_id_lote.Text = value.ToString();

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

    //protected void gv_inmueble_DataBound(object sender, EventArgs e)
    //{
    //    lbl_inmueble_enun.Visible = gv_inmueble.Rows.Count.Equals(0).Equals(false);
    //    gv_inmueble.Columns[0].Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "inmueble", "view");
    //}

    //protected void gv_inmueble_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "ver")
    //    {
    //        Session["id_inmueble"] = int.Parse(gv_inmueble.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
    //        WinPopUp1.Show();
    //    }
    //}

    protected void gv_intercambio_DataBound(object sender, EventArgs e)
    {
        lbl_intercambio_enun.Visible = gv_intercambio.Rows.Count.Equals(0).Equals(false);
    }
</script>
<asp:Label ID="lbl_id_lote" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_permitir_DatosDetalle" runat="server" Text="False" Visible="false"></asp:Label>
<asp:Label ID="lbl_permitir_EstadoCuenta" runat="server" Text="False" Visible="false"></asp:Label>
<asp:Label ID="lbl_permitir_PlanPagoOriginal" runat="server" Text="False" Visible="false"></asp:Label>
<asp:Label ID="lbl_permitir_PlanPagoVigente" runat="server" Text="False" Visible="false"></asp:Label>
<asp:Label ID="lbl_permitir_PlanPagoRestante" runat="server" Text="False" Visible="false"></asp:Label>

<%--<asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/inventario/inmueble/inmuebleDetalle.aspx">[WinPopUp1]</asp:WinPopUp>--%>

<table class="viewTable" align="center" cellpadding="0" cellspacing="0">
     <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_localizacion_enun" runat="server" Text="Localización:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_localizacion" runat="server"></asp:Label></td>
    </tr>
     <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_urbanizacion_enun" runat="server" Text="Sector:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_urbanizacion" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_manzano_enun" runat="server" Text="Manzano:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_manzano" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_lote_enun" runat="server" Text="Lote:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_lote" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_fecha_enun" runat="server" Text="Fecha de registro:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_fecha" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_superficie_enun" runat="server" Text="Superficie (m2):"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_superficie" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_costo_enun" runat="server" Text="Costo ($us/m2):"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_costo" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_precio_enun" runat="server" Text="Precio ($us/m2):"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_precio" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_propietario_enun" runat="server" Text="Anterior Propietario:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_propietario" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_partida_enun" runat="server" Text="No. de partida:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_partida" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_construccion_enun" runat="server" Text="Construcciones:"></asp:Label></td>
        <td class="formTdDato"><asp:Label ID="lbl_construccion" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_negocio_actual_enun" runat="server" Text="Negocio Actual:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_negocio_actual" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_negocios_enun" runat="server" Text="Negocios anteriores:"></asp:Label></td>
        <td class="formTdDato">
            <asp:GridView ID="gv_negocios" runat="server" AutoGenerateColumns="False" DataSourceID="ods_negocios_lista"
                DataKeyNames="id_negociolote">
                <Columns>
                    <asp:BoundField HeaderText="Negocio" DataField="negocio_nombre" />
                    <asp:BoundField HeaderText="Fecha" DataField="fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField HeaderText="Usuario" DataField="usuario_nombre" />
                </Columns>
            </asp:GridView>
            <%--[id_manzano],[codigo],[num_lote]--%>
            <asp:ObjectDataSource ID="ods_negocios_lista" runat="server" TypeName="terrasur.negocio_lote"
                SelectMethod="ListaPorLote">
                <SelectParameters>
                    <asp:ControlParameter Name="Id_lote" Type="Int32" ControlID="lbl_id_lote" PropertyName="Text" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
     <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_estado_actual_enun" runat="server" Text="Estado Actual:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_estado_actual" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_estados_anteriores" runat="server" Text="Estados anteriores:"></asp:Label></td>
        <td class="formTdDato">
            <asp:GridView ID="gv_estados" runat="server" AutoGenerateColumns="False" DataSourceID="ods_estados_lista"
                DataKeyNames="id_estadolote" OnRowDataBound="gv_estados_RowDataBound">
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
            <asp:ObjectDataSource ID="ods_estados_lista" runat="server" TypeName="terrasur.estado_lote"
                SelectMethod="ListaPorLote">
                <SelectParameters>
                    <asp:ControlParameter Name="Id_lote" Type="Int32" ControlID="lbl_id_lote" PropertyName="Text" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    <%--<tr>
        <td class="formTdEnun"><asp:Label ID="lbl_inmueble_enun" runat="server" Text="Inmueble(s):"></asp:Label></td>
        <td class="formTdDato">
            <asp:GridView ID="gv_inmueble" runat="server" AutoGenerateColumns="false" DataSourceID="ods_inmuebles_lista" DataKeyNames="id_inmueble" OnDataBound="gv_inmueble_DataBound" OnRowCommand="gv_inmueble_RowCommand">
                <Columns>
                    <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                    <asp:BoundField HeaderText="Tipo de inmueble" DataField="tipo_inmueble" />
                    <asp:BoundField HeaderText="Inmueble" DataField="codigo" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ods_inmuebles_lista" runat="server" TypeName="terrasur.inmueble" SelectMethod="ListaPorLote">
                <SelectParameters>
                    <asp:ControlParameter Name="Id_lote" Type="Int32" ControlID="lbl_id_lote" PropertyName="Text" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>--%>
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