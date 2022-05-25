<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Generación de datos BNB" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register src="~/recurso/herramienta/datosBNB/userControl/datosPreliminaresBNB.ascx" tagname="datosPreliminaresBNB" tagprefix="uc2" %>

<script runat="server">
    public bool permiso_datos_preliminares { get { return bool.Parse(lbl_permiso_datos_preliminares.Text); } set { lbl_permiso_datos_preliminares.Text = value.ToString(); } }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            permiso_datos_preliminares = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "datosBNB", "datos_preliminares");

            if (permiso_datos_preliminares)
            {
                HabilitarPaneles();
            }
            else { Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx"); }
        }
    }

    protected void HabilitarPaneles()
    {
        panel_datos_preliminares.Visible = permiso_datos_preliminares;
        if (permiso_datos_preliminares) { datosPreliminaresBNB1.Cargar(); }
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
     <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="datosBNB" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:Label ID="lbl_permiso_datos_preliminares" runat="server" Text="false" Visible="false"></asp:Label>

<table class="priTable">
    <tr>
        <td class="priTdTitle">Generación de datos BNB</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table align="center"><%--width="100%"--%>
                <tr>
                    <td align="left"><%--width="50%"--%>
                        <asp:Panel ID="panel_datos_preliminares" runat="server" GroupingText="Datos de contratos BBR para evaluación preliminar">
                            <uc2:datosPreliminaresBNB ID="datosPreliminaresBNB1" runat="server" />
                        </asp:Panel>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

