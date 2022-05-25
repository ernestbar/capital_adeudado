<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Reporte de cartera vigente por rangos de retraso" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>
<%@ Import Namespace="System.Data" %>
<script runat="server">
    public const int id_usuario_mtejerina = 7;
    public const int id_usuario_majuregui = 366;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContabilidad", "reporteCarteraRangos") == true)
            {
                if (Session["codigo_rol"] != null)
                {
                    //Se redirecciona al reporte especial para promotores
                    panel_opciones.Visible = false;
                    Response.Redirect("~/recurso/contabilidad/reporteContabilidad/reporteCarteraRangosPromotor.aspx");

                    //Si es que se necesita una adaptación especial se ejecuta lo siguiente:
                    /*
                    if (Profile.id_usuario == id_usuario_mtejerina ||
                        Profile.id_usuario == id_usuario_majuregui)
                    {
                        panel_opciones.Visible = true;
                        switch (Profile.id_usuario)
                        {
                            case id_usuario_mtejerina: panel_opciones.GroupingText = "Opciones de acceso de Martín Tejerina"; break;
                            case id_usuario_majuregui: panel_opciones.GroupingText = "Opciones de acceso de Mauricio Jauregui"; break;
                        }

                        //Se habilita el grupo de Martín Tejerina
                        if (Profile.id_usuario == id_usuario_mtejerina) { btn_mtejerina.Visible = true; }
                        else { btn_mtejerina.Visible = false; }

                        //Se habilita el grupo de Marketing
                        if (Profile.id_usuario == id_usuario_mtejerina 
                            || Profile.id_usuario == id_usuario_majuregui)
                        {
                            btn_marketing.Visible = true;
                        }
                        else { btn_marketing.Visible = false; }

                        //Se habilita el grupo de Inactivos
                        if (Profile.id_usuario == id_usuario_mtejerina) { btn_inactivos.Visible = true; }
                        else { btn_inactivos.Visible = false; }
                        
                        //Se habilita el grupo de Ventas institucionales
                        if (Profile.id_usuario == id_usuario_mtejerina) { btn_ventasins.Visible = true; }
                        else { btn_ventasins.Visible = false; }
                      
                    }
                    else
                    {
                        panel_opciones.Visible = false;
                        Session.Add("id_usuario", Profile.id_usuario);
                        Response.Redirect("~/recurso/contabilidad/reporteContabilidad/reporteCarteraRangosPromotor.aspx");
                    }
                    */
                }
                else { Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx"); }

            }
            else { Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx"); }
        }
    }

    protected void btn_mtejerina_Click(object sender, EventArgs e)
    {
        switch (Profile.id_usuario)
        {
            case id_usuario_mtejerina:
                Session.Add("codigo_rol", "director");
                Session.Add("id_usuario", id_usuario_mtejerina);
                Response.Redirect("~/recurso/contabilidad/reporteContabilidad/reporteCarteraRangosPromotor.aspx");
                break;
        }
    }

    protected void btn_marketing_Click(object sender, EventArgs e)
    {
        //director Marketing: 8
        switch (Profile.id_usuario)
        {
            case id_usuario_mtejerina: case id_usuario_majuregui:
                Session.Add("codigo_rol", "director");
                Session.Add("id_usuario", 8);
                Response.Redirect("~/recurso/contabilidad/reporteContabilidad/reporteCarteraRangosPromotor.aspx");
                break;
        }
    }

    protected void btn_inactivos_Click(object sender, EventArgs e)
    {
        //director Inactivos: 9
        switch (Profile.id_usuario)
        {
            case id_usuario_mtejerina:
                Session.Add("codigo_rol", "director");
                Session.Add("id_usuario", 9);
                Response.Redirect("~/recurso/contabilidad/reporteContabilidad/reporteCarteraRangosPromotor.aspx");
                break;
        }
    }

    protected void btn_ventasins_Click(object sender, EventArgs e)
    {
        //director Ventas Ins: 472
        switch (Profile.id_usuario)
        {
            case id_usuario_mtejerina:
                Session.Add("codigo_rol", "director");
                Session.Add("id_usuario", 472);
                Response.Redirect("~/recurso/contabilidad/reporteContabilidad/reporteCarteraRangosPromotor.aspx");
                break;
        }
    }

    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx");
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteContabilidad" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table align="center">
    <tr>
        <td align="right">
            <asp:Button ID="btn_volver" runat="server" SkinID="btnVolver" Text="Volver" OnClick="btn_volver_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_opciones" runat="server" Visible="false">
                <table>
                    <tr><td align="left"><asp:Button ID="btn_mtejerina" runat="server" Text="Grupo de MARTÍN TEJERINA" OnClick="btn_mtejerina_Click" /></td></tr>
                    <tr><td align="left"><asp:Button ID="btn_marketing" runat="server" Text="Grupo de MARKETING" OnClick="btn_marketing_Click" /></td></tr>
                    <tr><td align="left"><asp:Button ID="btn_inactivos" runat="server" Text="Grupo de INACTIVOS" OnClick="btn_inactivos_Click" /></td></tr>
                    <tr><td align="left"><asp:Button ID="btn_ventasins" runat="server" Text="Grupo de VENTAS INSTITUCIONALES" OnClick="btn_ventasins_Click" /></td></tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>

</asp:Content>
