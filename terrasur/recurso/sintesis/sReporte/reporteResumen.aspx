<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Resumen de intercambio de información con Síntesis" %>
<%@ Import Namespace="System.Data" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<%@ Register src="~/recurso/sintesis/sReporte/userControl/criterioReporteSintesis.ascx" tagname="criterioReporteSintesis" tagprefix="uc3" %>
<%@ Register src="~/recurso/sintesis/sReporte/userControl/tipoReporteSintesis.ascx" tagname="tipoReporteSintesis" tagprefix="uc4" %>

<script runat="server">
    protected bool primer_ingreso { get { return bool.Parse(lbl_primer_ingreso.Text); } set { lbl_primer_ingreso.Text = value.ToString(); } }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sReporte", "reporteResumen") == true)
            {
                criterioReporteSintesis1.Cargar(true);
                tipoReporteSintesis1.Cargar(false);
                primer_ingreso = true;
            }
            else { Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx"); }
        }
    }

    protected void btn_obtener_datos_Click(object sender, EventArgs e)
    {
        primer_ingreso = false;
        gv_resumen.DataBind();
    }

    protected void ods_reporte_resumen_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        if (primer_ingreso == true) { e.InputParameters["Id_eeff"] = -1; }
        else { e.InputParameters["Id_eeff"] = criterioReporteSintesis1.id_eeff; }
        e.InputParameters["Id_sucursal_eeff"] = criterioReporteSintesis1.id_sucursal_eeff;
        e.InputParameters["Codigo_usuario"] = criterioReporteSintesis1.usuario;
        e.InputParameters["Fecha_inicio"] = criterioReporteSintesis1.fecha_inicio;
        e.InputParameters["Fecha_fin"] = criterioReporteSintesis1.fecha_fin;
        e.InputParameters["Num_contrato"] = criterioReporteSintesis1.num_contrato;
        e.InputParameters["Id_pagopendiente"] = criterioReporteSintesis1.id_pagopendiente;
        e.InputParameters["Tipo_reporte"] = tipoReporteSintesis1.tipo_reporte_elegidos;
    }

    public string string_corto(string texto)
    {
        if (texto.Length <= 40) { return texto; }
        else { return texto.Substring(0, 40) + "..."; }
    }

    protected void gv_resumen_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ver")
        {
            int index = int.Parse(e.CommandArgument.ToString());
            string tipo_codigo = gv_resumen.DataKeys[index].Values["tipo_codigo"].ToString();
            string num_contrato = gv_resumen.DataKeys[index].Values["num_contrato"].ToString();
            DateTime fecha = (DateTime)gv_resumen.DataKeys[index].Values["fecha"];

            Session["tipo_reporte"] = tipo_codigo;
            Session["fecha"] = fecha;

            Session["id_eeff"] = criterioReporteSintesis1.id_eeff;
            Session["id_sucursal_eeff"] = criterioReporteSintesis1.id_sucursal_eeff;
            //fecha_inicio
            //fecha_fin
            Session["id_pagopendiente"] = criterioReporteSintesis1.id_pagopendiente;

            Session["string_eeff"] = criterioReporteSintesis1.string_eeff;
            Session["string_sucursal_eeff"] = criterioReporteSintesis1.string_sucursal_eeff;
            Session["string_usuario"] = criterioReporteSintesis1.usuario;
            Session["string_fechas"] = criterioReporteSintesis1.string_fechas;
            Session["num_contrato"] = "";//num_contrato;
            Session["string_id_pagopendiente"] = criterioReporteSintesis1.string_id_pagopendiente;

            WinPopUp1.Show();
        }
    }


    protected void gv_resumen_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            general.OnMouseOver(ref sender, ref e);
        }
    }

    protected void btn_reporte_Click(object sender, EventArgs e)
    {
        Session["tipo_reporte"] = "resumen";
        Session["fecha"] = criterioReporteSintesis1.fecha_inicio;

        Session["id_eeff"] = criterioReporteSintesis1.id_eeff;
        Session["id_sucursal_eeff"] = criterioReporteSintesis1.id_sucursal_eeff;
        Session["id_pagopendiente"] = criterioReporteSintesis1.id_pagopendiente;

        Session["string_eeff"] = criterioReporteSintesis1.string_eeff;
        Session["string_sucursal_eeff"] = criterioReporteSintesis1.string_sucursal_eeff;
        Session["string_usuario"] = criterioReporteSintesis1.usuario;
        Session["string_fechas"] = criterioReporteSintesis1.string_fechas;
        Session["num_contrato"] = criterioReporteSintesis1.num_contrato;
        Session["string_id_pagopendiente"] = criterioReporteSintesis1.string_id_pagopendiente;

        Session["tipo_solicitud"] = tipoReporteSintesis1.tipo_reporte_elegidos;
        Session["string_tipo_solicitud"] = tipoReporteSintesis1.string_tipo_reporte_elegidos;
        Session["fecha_inicio"] = criterioReporteSintesis1.fecha_inicio;
        Session["fecha_fin"] = criterioReporteSintesis1.fecha_fin;

        WinPopUp1.Show();
    }

    protected void gv_resumen_DataBound(object sender, EventArgs e)
    {
        lbl_num_solicitudes.Text = gv_resumen.Rows.Count.ToString();
    }
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="sReporte" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:Label ID="lbl_primer_ingreso" runat="server" Text="true" Visible="false"></asp:Label>

<asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/sintesis/sReporte/reporteDetalle.aspx"
    Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="500"
    Win_Left="100" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True"
    Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="100" Win_Width="900"></asp:WinPopUp>


<table class="priTable">
    <tr>
        <td class="priTdTitle">Resumen de intercambio de información con Síntesis</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido">
                <tr>
                    <td class="tdFiltro">
                        <table cellpadding="0" cellspacing="0" align="center">
                            <tr><td><uc3:criterioReporteSintesis ID="criterioReporteSintesis1" runat="server" /></td></tr>
                            <tr><td><uc4:tipoReporteSintesis ID="tipoReporteSintesis1" runat="server" /></td></tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="100%" align="center"><asp:Button ID="btn_obtener_datos" runat="server" Text="Obtener datos" OnClick="btn_obtener_datos_Click" /></td>
                                            <td align="right"><asp:Button ID="btn_reporte" runat="server" Text="Mostrar reporte" OnClick="btn_reporte_Click" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lbl_num_solicitudes_enun" runat="server" Text="Nro. de solicitudes: " SkinID="lblEnun"></asp:Label>
                        <asp:Label ID="lbl_num_solicitudes" runat="server" Text="0" SkinID="lblEnun"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tdGrid">
                        <asp:Panel ID="panel_resumen" runat="server" GroupingText="Intercambio de información" ScrollBars="Vertical" Height="500">
                            <asp:GridView ID="gv_resumen" runat="server" AutoGenerateColumns="false" DataSourceID="ods_reporte_resumen" DataKeyNames="tipo_codigo,num_contrato,fecha" OnRowCommand="gv_resumen_RowCommand" OnRowDataBound="gv_resumen_RowDataBound" OnDataBound="gv_resumen_DataBound">
                                <Columns>
                                    <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                    <asp:BoundField HeaderText="Fecha" DataField="fecha" />
                                    <asp:BoundField HeaderText="Tipo de solicitud" DataField="tipo_nombre" />
                                    <asp:BoundField HeaderText="EEFF" DataField="codigo_eeff" />
                                    <asp:BoundField HeaderText="Sucursal" DataField="codigo_sucursal" />
                                    <asp:BoundField HeaderText="Usuario" DataField="codigo_usuario" />
                                    <asp:BoundField HeaderText="Solicitud" DataField="solicitud" />
                                    <asp:BoundField HeaderText="Nº contrato" DataField="num_contrato" ItemStyle-CssClass="gvCell1" />
                                    <asp:BoundField HeaderText="Nº.Resp." DataField="num_respuesta" />
                                    <asp:TemplateField HeaderText="Respuesta"><ItemTemplate><asp:Label ID="lbl_respuesta" runat="server" Text='<%# string_corto(Eval("respuesta").ToString()) %>' ToolTip='<%# Eval("respuesta") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                    <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                        <%--[fecha],[id],[tipo_codigo],[tipo_nombre],[codigo_eeff],[codigo_sucursal],[codigo_usuario]
                        [num_contrato],[solicitud],[num_respuesta],[respuesta]--%>
                        <asp:ObjectDataSource ID="ods_reporte_resumen" runat="server" TypeName="terrasur.sintesis.s_reporte" SelectMethod="reporte_resumen" OnSelecting="ods_reporte_resumen_Selecting">
                            <SelectParameters>
                                <asp:Parameter Name="Id_eeff" Type="Int32" />
                                <asp:Parameter Name="Id_sucursal_eeff" Type="Int32" />
                                <asp:Parameter Name="Codigo_usuario" Type="String" />
                                <asp:Parameter Name="Fecha_inicio" Type="DateTime" />
                                <asp:Parameter Name="Fecha_fin" Type="DateTime" />
                                <asp:Parameter Name="Num_contrato" Type="String" />
                                <asp:Parameter Name="Id_pagopendiente" Type="Int32" />
                                <asp:Parameter Name="Tipo_reporte" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>
