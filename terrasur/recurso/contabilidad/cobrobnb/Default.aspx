<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Generación de archivos BNB" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register src="~/recurso/contabilidad/cobrobnb/userControl/bnbArchivoAbm.ascx" tagname="bnbArchivoAbm" tagprefix="uc2" %>
<%@ Register src="~/recurso/contabilidad/cobrobnb/userControl/bnbArchivoConciliacionAbm.ascx" tagname="bnbArchivoConciliacionAbm" tagprefix="uc3" %>
<%@ Register src="~/recurso/contabilidad/cobrobnb/userControl/bnbArchivoLibroVentas.ascx" tagname="bnbArchivoLibroVentas" tagprefix="uc4" %>

<script runat="server">
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cobrobnb", "ver_archivos") == false)
            {
                Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx");
            }
        }
    }
    
    protected void rbl_institucion_DataBound(object sender, EventArgs e)
    {
        if (rbl_institucion.Items.Count > 0)
        {
            rbl_institucion.SelectedIndex = 0;
            int id_institucion = int.Parse(rbl_institucion.SelectedValue);
            bnbArchivoAbm1.id_institucion = id_institucion;
            bnbArchivoAbm2.id_institucion = id_institucion;
            bnbArchivoAbm3.id_institucion = id_institucion;
            bnbArchivoConciliacionAbm1.id_institucion = id_institucion;
            bnbArchivoLibroVentas1.id_institucion = id_institucion;
            bnbArchivoAbm1.Reset();
            bnbArchivoAbm2.Reset();
            bnbArchivoAbm3.Reset();
            bnbArchivoConciliacionAbm1.Reset();
        }
    }

    protected void rbl_institucion_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id_institucion = int.Parse(rbl_institucion.SelectedValue);
        bnbArchivoAbm1.id_institucion = id_institucion;
        bnbArchivoAbm2.id_institucion = id_institucion;
        bnbArchivoAbm3.id_institucion = id_institucion;
        bnbArchivoConciliacionAbm1.id_institucion = id_institucion;
        bnbArchivoLibroVentas1.id_institucion = id_institucion;
        bnbArchivoAbm1.Reset();
        bnbArchivoAbm2.Reset();
        bnbArchivoAbm3.Reset();
        bnbArchivoConciliacionAbm1.Reset();
    }

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="cobrobnb" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:Label runat="server" id="Id_contrato" Visible="false"  Text="0"/>
<table class="priTable">
        <tr><td class="priTdTitle">Generación de archivos BNB</td></tr>
        <tr>
            <td class="priTdContenido">
                <table align="center" width="100%">
                    <tr>
                        <td>
                            <table align="center">
                                <tr>
                                    <td><asp:Label ID="lbl_institucion_enun" runat="server" Text="Institución" SkinID="lblEnun"></asp:Label></td>
                                    <td>
                                        <asp:RadioButtonList ID="rbl_institucion" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" AutoPostBack="true" DataSourceID="ods_lista_institucion" DataTextField="codigo" DataValueField="id_institucion" OnDataBound="rbl_institucion_DataBound" OnSelectedIndexChanged="rbl_institucion_SelectedIndexChanged">
                                        </asp:RadioButtonList>
                                        <%--[id_institucion],[codigo],[bnb_codigo],[bnb_inicial]--%>
                                        <asp:ObjectDataSource ID="ods_lista_institucion" runat="server" TypeName="terrasur.bnb_institucion" SelectMethod="Lista">
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table align="center" width="100%">
                                <tr>
                                    <td valign="top" width="50%"><uc2:bnbArchivoAbm ID="bnbArchivoAbm1" runat="server" codigo_tipo_archivo="A" /></td>
                                    <td valign="top" width="50%"><uc2:bnbArchivoAbm ID="bnbArchivoAbm2" runat="server" codigo_tipo_archivo="B" /></td>
                                </tr>
                                <tr>
                                    <td valign="top" width="50%"><uc2:bnbArchivoAbm ID="bnbArchivoAbm3" runat="server" codigo_tipo_archivo="C" /></td>
                                    <td valign="top" width="50%"><uc3:bnbArchivoConciliacionAbm ID="bnbArchivoConciliacionAbm1" runat="server" codigo_tipo_archivo="D" /></td>
                                </tr>
                                <tr>
                                    <td valign="top" width="50%"></td>
                                    <td valign="top" width="50%"><uc4:bnbArchivoLibroVentas ID="bnbArchivoLibroVentas1" runat="server" codigo_tipo_archivo="E" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

