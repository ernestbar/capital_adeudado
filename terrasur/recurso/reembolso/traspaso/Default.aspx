<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Traspasos y devoluciones" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register src="~/recurso/reembolso/traspaso/userControl/filtroReembolso.ascx" tagname="filtroReembolso" tagprefix="uc3" %>
<%@ Register src="~/recurso/reembolso/traspaso/userControl/reemAbm.ascx" tagname="reemAbm" tagprefix="uc2" %>

<%@ Register src="~/recurso/reembolso/traspaso/userControl/devolucionCortoView.ascx" tagname="devolucionCortoView" tagprefix="uc4" %>
<%@ Register src="~/recurso/reembolso/traspaso/userControl/pagoDevolucionRegistro.ascx" tagname="pagoDevolucionRegistro" tagprefix="uc5" %>

<script runat="server">
    protected bool primer_ingreso { get { return bool.Parse(lbl_primer_ingreso.Text); } set { lbl_primer_ingreso.Text = value.ToString(); } }

    protected bool traspaso_update { get { return bool.Parse(lbl_traspaso_update.Text); } set { lbl_traspaso_update.Text = value.ToString(); } }
    protected bool traspaso_delete { get { return bool.Parse(lbl_traspaso_delete.Text); } set { lbl_traspaso_delete.Text = value.ToString(); } }

    protected bool devolucion_update { get { return bool.Parse(lbl_devolucion_update.Text); } set { lbl_devolucion_update.Text = value.ToString(); } }
    protected bool devolucion_delete { get { return bool.Parse(lbl_devolucion_delete.Text); } set { lbl_devolucion_delete.Text = value.ToString(); } }
    protected bool devolucion_pagos { get { return bool.Parse(lbl_devolucion_pagos.Text); } set { lbl_devolucion_pagos.Text = value.ToString(); } }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "traspaso", "view"))
            {
                primer_ingreso = true;
                btn_nuevo_traspaso.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "traspaso", "insert");
                btn_nuevo_devolucion.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "devolucion", "insert");
                filtroReembolso1.Reset();

                traspaso_update = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "traspaso", "update");
                traspaso_delete = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "traspaso", "delete");

                devolucion_update = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "devolucion", "update");
                devolucion_delete = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "devolucion", "delete");
                devolucion_pagos = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "devolucion", "pagos");

                btn_reporte.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "traspaso", "reporte");
            }
            else { Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx"); }
        }
        MostrarPendientes();
    }

    protected void btn_obtener_Click(object sender, EventArgs e)
    {
        primer_ingreso = false;
        gv1.DataBind();
    }

    protected void btn_nuevo_traspaso_Click(object sender, EventArgs e)
    {
        panel_abm.DefaultButton = "btn_insertar";
        lbl_abm.Text = "Nuevo traspaso";
        reemAbm1.CargarInsertar(true);
        btn_insertar.Visible = true;
        btn_actualizar.Visible = false;
        MultiView1.ActiveViewIndex = 1;
    }

    protected void btn_nuevo_devolucion_Click(object sender, EventArgs e)
    {
        panel_abm.DefaultButton = "btn_insertar";
        lbl_abm.Text = "Nueva devolución";
        reemAbm1.CargarInsertar(false);
        btn_insertar.Visible = true;
        btn_actualizar.Visible = false;
        MultiView1.ActiveViewIndex = 1;
    }


    protected void btn_insertar_Click(object sender, EventArgs e)
    {
        if (reemAbm1.Insertar())
        {
            //gv1.DataBind();
            reemAbm1.CargarInsertar(reemAbm1.traspaso);
        }
        panel_abm.DefaultButton = "btn_insertar";
    }

    protected void btn_actualizar_Click(object sender, EventArgs e)
    {
        if (reemAbm1.Actualizar())
        {
            //gv1.DataBind();
        }
        panel_abm.DefaultButton = "btn_actualizar";
    }

    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        gv1.DataBind();
        MultiView1.ActiveViewIndex = 0;
    }

    protected void btn_cancelar_pagos_Click(object sender, EventArgs e)
    {
        gv1.DataBind();
        MultiView1.ActiveViewIndex = 0;
    }
    
    protected void ods_reembolso_lista_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        if (primer_ingreso == true) { e.InputParameters["Tipo_reembolso"] = -2; }
        else { e.InputParameters["Tipo_reembolso"] = filtroReembolso1.tipo_reembolso; }
        e.InputParameters["Num_contrato"] = filtroReembolso1.num_contrato;
        e.InputParameters["Origen_contrato"] = filtroReembolso1.origen_contrato;
        e.InputParameters["Fecha_inicio"] = filtroReembolso1.fecha_inicio;
        e.InputParameters["Fecha_fin"] = filtroReembolso1.fecha_fin;
        e.InputParameters["Id_usuario"] = filtroReembolso1.id_usuario;
        e.InputParameters["Cliente"] = filtroReembolso1.cliente;
        e.InputParameters["Id_motivo"] = filtroReembolso1.id_motivo;
        e.InputParameters["Asignacion"] = filtroReembolso1.asignacion;
        e.InputParameters["Saldo"] = filtroReembolso1.saldo;
        e.InputParameters["Id_localizacion"] = filtroReembolso1.id_localizacion;
        e.InputParameters["Id_urbanizacion"] = filtroReembolso1.id_urbanizacion;
        e.InputParameters["Id_estadoconciliacion"] = filtroReembolso1.id_estadoconciliacion; // Req. Conciliaciones
    }
    protected void gv1_DataBound(object sender, EventArgs e)
    {
        
    }

    protected void gv1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //[id_reembolso],[tipo],[num_contrato],[fecha],[moneda],[monto],[pagado],[pendiente_asignacion],[saldo],[pagos],[cliente],[motivo],[usuario]
        //[traspaso]
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //general.OnMouseOver(sender, e);
            bool traspaso = (bool)DataBinder.Eval(e.Row.DataItem, "traspaso");
            decimal pagado = (decimal)DataBinder.Eval(e.Row.DataItem, "pagado");
            decimal saldo = (decimal)DataBinder.Eval(e.Row.DataItem, "saldo");
            
            if (traspaso)
            {
                e.Row.Cells[1].Controls[0].Visible = traspaso_update;
                e.Row.Cells[2].Controls[0].Visible = traspaso_delete;
                e.Row.Cells[3].Controls[0].Visible = false;
            }
            else
            {
                e.Row.Cells[1].Controls[0].Visible = devolucion_update;
                e.Row.Cells[2].Controls[0].Visible = devolucion_delete;
                if (saldo <= 0) { e.Row.Cells[3].Controls[0].Visible = false; }
                else { e.Row.Cells[3].Controls[0].Visible = devolucion_pagos; }
            }
        }
    }

    protected void gv1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "ver":
                Session["id_reembolso"] = int.Parse(gv1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
                WinPopUp1.Show();
                break;
            case "editar":
                panel_abm.DefaultButton = "btn_actualizar";
                terrasur.traspaso.reembolso reObj = new terrasur.traspaso.reembolso(int.Parse(gv1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString()));
                if (reObj.traspaso) { lbl_abm.Text = "Edición de datos de un traspaso"; } else { lbl_abm.Text = "Edición de datos de una devolución"; }
                reemAbm1.CargarActualizar(reObj);
                btn_insertar.Visible = false;
                btn_actualizar.Visible = true;
                MultiView1.ActiveViewIndex = 1;
                break;
            case "eliminar":
                terrasur.traspaso.reembolso rObj = new terrasur.traspaso.reembolso(int.Parse(e.CommandArgument.ToString()));
                if (rObj.Eliminar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
                {
                    gv1.DataBind();
                    if (rObj.traspaso) { Msg1.Text = "El traspaso se eliminó correctamente"; }
                    else { Msg1.Text = "El traspaso se eliminó correctamente"; }
                }
                else
                {
                    if (rObj.traspaso) { Msg1.Text = "El traspaso NO se eliminó correctamente"; }
                    else { Msg1.Text = "El traspaso NO se eliminó correctamente"; }
                }
                break;
            case "pagos":
                int _Id_reembolso = int.Parse(gv1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
                devolucionCortoView1.id_reembolso = _Id_reembolso;
                pagoDevolucionRegistro1.id_reembolso = _Id_reembolso;
                MultiView1.ActiveViewIndex = 2;
                break;
        }

    }

    protected void btn_reporte_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/recurso/reembolso/traspaso/reReporte.aspx");
    }

    protected void MostrarPendientes()
    {
        string str_texto = ""; string str_tooltip = "";
        terrasur.traspaso.reembolso.ListaNoRevertidos(ref str_texto, ref str_tooltip);
        //if (str_texto != "") { lbl_pendientes.Text = "Cttos. NO Revertidos ; " + str_texto; }
        //else { lbl_pendientes.Text = str_texto; }
        lbl_pendientes.Text = str_texto;
        lbl_pendientes.ToolTip = str_tooltip;

        //.Replace(" ; ", "<br/>");
    }
    
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="traspaso" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:Label ID="lbl_primer_ingreso" runat="server" Text="true" Visible="false"></asp:Label>

    <asp:Label ID="lbl_traspaso_update" runat="server" Text="false" Visible="false"></asp:Label>
    <asp:Label ID="lbl_traspaso_delete" runat="server" Text="false" Visible="false"></asp:Label>

    <asp:Label ID="lbl_devolucion_update" runat="server" Text="false" Visible="false"></asp:Label>
    <asp:Label ID="lbl_devolucion_delete" runat="server" Text="false" Visible="false"></asp:Label>
    <asp:Label ID="lbl_devolucion_pagos" runat="server" Text="false" Visible="false"></asp:Label>

    <asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/reembolso/traspaso/reembolsoDatosSimple.aspx" Visible="False" 
        Win_Directories="False" Win_Fullscreen="False" Win_Height="550" Win_Width="900" Win_Left="100" Win_Top="100" 
        Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True" Win_Status="True" 
        Win_Titlebar="True" Win_Toolbar="False">[WinPopUp1]</asp:WinPopUp>
    <asp:ScriptManager ID="ScriptManager1" runat="server"><Scripts><asp:ScriptReference Path="../../../js/scriptjs.js" /></Scripts></asp:ScriptManager>
    <table class="priTable">
        <tr><td class="priTdTitle">Traspasos y devoluciones</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" align="center">
                                        <tr>
                                            <td>
                                                <asp:Panel ID="panel_filtro" runat="server" GroupingText="Filtro de datos">
                                                    <table cellpadding="0" cellspacing="0" align="center">
                                                        <tr><td><uc3:filtroReembolso ID="filtroReembolso1" runat="server" /></td></tr>
                                                        <tr><td><asp:Button ID="btn_obtener" runat="server" Text="Obtener datos" OnClick="btn_obtener_Click" /></td></tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <div style="width:700px; text-align:left;"><asp:Label ID="lbl_pendientes" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></div>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdButton">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="left">
                                                <asp:Button ID="btn_nuevo_traspaso" runat="server" Text="Nuevo traspaso" OnClick="btn_nuevo_traspaso_Click" />
                                                <asp:Button ID="btn_nuevo_devolucion" runat="server" Text="Nueva devolución" OnClick="btn_nuevo_devolucion_Click" />
                                            </td>
                                            <td align="right">
                                                <asp:Button ID="btn_reporte" runat="server" Text="Reporte de traspasos y devoluciones" OnClick="btn_reporte_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid"><%--WizardGridView AllowPaging="true" PageSize="20"--%>
                                    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="false" DataSourceID="ods_reembolso_lista" DataKeyNames="id_reembolso" OnDataBound="gv1_DataBound" OnRowDataBound="gv1_RowDataBound" OnRowCommand="gv1_RowCommand">
                                        <Columns>
                                            <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_reembolso") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar el reembolso?');" /></ItemTemplate></asp:TemplateField>
                                            <asp:ButtonField CommandName="pagos" Text="Pagos" ControlStyle-CssClass="gvButton" />
                                            <asp:BoundField HeaderText="Tipo" DataField="tipo" />
                                            <%--<asp:BoundField HeaderText="Nº ctto." DataField="num_contrato" ItemStyle-CssClass="gvCell1" />--%>
                                            <asp:TemplateField HeaderText="Nº ctto."><ItemTemplate><asp:Label ID="lbl_num_contrato" runat="server" Text='<%# Eval("num_contrato") %>' ToolTip='<%# Eval("producto") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                            <asp:BoundField HeaderText="Fecha" DataField="fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="gvCell1" />
                                            <asp:BoundField HeaderText="" DataField="moneda" />
                                            <asp:BoundField HeaderText="Monto" DataField="monto" HtmlEncode="false" DataFormatString="{0:N2}" ItemStyle-CssClass="gvCell1" />
                                            <asp:BoundField HeaderText="Ejecutado" DataField="pagado" HtmlEncode="false" DataFormatString="{0:N2}" ItemStyle-CssClass="gvCell1" />
                                            <asp:BoundField HeaderText="Saldo" DataField="saldo" HtmlEncode="false" DataFormatString="{0:N2}" ItemStyle-CssClass="gvCell1" />
                                            <%--<asp:BoundField HeaderText="Pend.Asignar" DataField="pendiente_asignacion" HtmlEncode="false" DataFormatString="{0:N2}" ItemStyle-CssClass="gvCell1" />--%>
                                            <asp:BoundField HeaderText="Pagos" DataField="pagos" />
                                            <asp:BoundField HeaderText="Cliente" DataField="cliente" />
                                            <asp:BoundField HeaderText="Cttos.Destino" DataField="destino" />
                                            <asp:BoundField HeaderText="Motivo" DataField="motivo" />
                                            <asp:BoundField HeaderText="Proc. por" DataField="usuario" />
                                        </Columns>
                                    </asp:GridView>
                                    <%--[id_reembolso],[tipo],[num_contrato],[fecha],[moneda],[monto],[pagado],[pendiente_asignacion],[saldo],[pagos],[cliente],[motivo],[usuario], 
                                        [traspaso],[producto],[destino],[num_destino]--%>
                                    <asp:ObjectDataSource ID="ods_reembolso_lista" runat="server" TypeName="terrasur.traspaso.reembolso" SelectMethod="Lista" OnSelecting="ods_reembolso_lista_Selecting">
                                        <SelectParameters>
                                            <asp:Parameter Name="Tipo_reembolso" Type="Int32" />
                                            <asp:Parameter Name="Num_contrato" Type="String" />
                                            <asp:Parameter Name="Origen_contrato" Type="Int32" />
                                            <asp:Parameter Name="Fecha_inicio" Type="DateTime" />
                                            <asp:Parameter Name="Fecha_fin" Type="DateTime" />
                                            <asp:Parameter Name="Id_usuario" Type="Int32" />
                                            <asp:Parameter Name="Cliente" Type="String" />
                                            <asp:Parameter Name="Id_motivo" Type="Int32" />
                                            <asp:Parameter Name="Asignacion" Type="Int32" />
                                            <asp:Parameter Name="Saldo" Type="Int32" />
                                            <asp:Parameter Name="Id_localizacion" Type="Int32" />
                                            <asp:Parameter Name="Id_urbanizacion" Type="Int32" />
                                            <%--Req. Conciliaciones--%>
                                            <asp:Parameter Name="Id_estadoconciliacion" Type="Int32" />
                                            <%--Req. Conciliaciones--%>
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View id="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_abm" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm">
                                <uc2:reemAbm ID="reemAbm1" runat="server" />
                            </td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="reembolso" OnClick="btn_insertar_Click" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="false" OnClick="btn_actualizar_Click" />
                                    <asp:Button ID="btn_cancelar" runat="server" Text="<%$ Resources:form, btn_cancelar %>" CausesValidation="false" SkinID="btnAccion" OnClick="btn_cancelar_Click" />
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
                    </asp:View>
                    <asp:View id="View3" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle">Registro de pagos por devoluciones</td></tr>
                            <tr><td class="formEntTdForm">
                                <table cellpadding="0" cellspacing="0" align="center">
                                    <tr>
                                        <td>
                                            <asp:Panel ID="panel_devolucion_contrato" runat="server" GroupingText="Datos de la devolución">
                                                <uc4:devolucionCortoView ID="devolucionCortoView1" runat="server" />
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="panel_devolucion_pagos" runat="server" GroupingText="Pagos previstos para la devolución">
                                                <uc5:pagoDevolucionRegistro ID="pagoDevolucionRegistro1" runat="server" />
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:Button ID="btn_cancelar_pagos" runat="server" Text="<%$ Resources:form, btn_cancelar %>" CausesValidation="false" SkinID="btnAccion" OnClick="btn_cancelar_pagos_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>

