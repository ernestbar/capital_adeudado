<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Cambio de beneficiario de facturas" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoBusqueda.ascx" TagName="contratoBusqueda" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos" TagPrefix="uc3" %>
<%@ Register Src="~/recurso/contrato/cambioBeneficiario/userControl/beneficiarioAbm.ascx" TagName="beneficiarioAbm" TagPrefix="uc4" %>

<script runat="server">
    Protected Property id_contrato() As Integer
        Get
            Return Integer.Parse(lbl_id_contrato.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_contrato.Text = value
        End Set
    End Property
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler ContratoBusqueda1.Eleccion, AddressOf busqueda_realizada
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cambioBeneficiario", "view") Then
                panel_nuevo_beneficiario.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cambioBeneficiario", "insert")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    
    Protected Sub busqueda_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        id_contrato = ContratoBusqueda1.id_resultado
        ContratoDatos1.id_contrato = id_contrato
        MultiView1.ActiveViewIndex = 1
        gv_beneficiario.DataBind()
        If panel_nuevo_beneficiario.Visible Then
            BeneficiarioAbm1.CargarInsertar(id_contrato)
        End If
    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        ContratoBusqueda1.Reset()
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        If BeneficiarioAbm1.VerificarInsertar Then
            If BeneficiarioAbm1.Insertar Then
                gv_beneficiario.DataBind()
                BeneficiarioAbm1.CargarInsertar(id_contrato)
            End If
        End If
    End Sub

    Protected Sub gv_beneficiario_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_beneficiario.DataBound
        If gv_beneficiario.Rows.Count > 0 Then
            gv_beneficiario.Rows(gv_beneficiario.Rows.Count - 1).CssClass = "gvRowSelected"
        End If
    End Sub

    Protected Sub gv_beneficiario_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_beneficiario.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            general.OnMouseOver(sender, e)
        End If
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="cambioBeneficiario" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
    <table class="priTable">
        <tr><td class="priTdTitle">Cambio de beneficiario de facturas</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr><td class="tdBusqueda"><uc2:contratoBusqueda ID="ContratoBusqueda1" runat="server" /></td></tr>
                            <tr><td class="tdMsg"><asp:Msg ID="Msg1" runat="server"></asp:Msg></td></tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_cambio" runat="server">
                                        <table class="tableContenido" align="center">
                                            <tr><td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_volver" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" /></td></tr>
                                            <tr><td class="tdEncabezado"><uc3:contratoDatos ID="ContratoDatos1" runat="server" /></td></tr>
                                            <tr>
                                                <td class="tdEncabezado">
                                                    <table align="center">
                                                        <tr>
                                                            <td valign="top">
                                                                <asp:Panel ID="panel_anteriores_beneficiarios" runat="server" GroupingText="Anteriores beneficiarios de facturas">
                                                                    <asp:GridView ID="gv_beneficiario" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_beneficiario" DataKeyNames="id_beneficiariofactura">
                                                                        <Columns>
                                                                            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                                                                            <asp:BoundField HeaderText="NIT" DataField="nit" />
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                    <asp:ObjectDataSource ID="ods_lista_beneficiario" runat="server" TypeName="terrasur.beneficiario_factura" SelectMethod="ListaPorContrato">
                                                                        <SelectParameters>
                                                                            <asp:ControlParameter Name="Id_contrato" Type="Int32" ControlID="lbl_id_contrato" PropertyName="Text" />
                                                                        </SelectParameters>
                                                                    </asp:ObjectDataSource>
                                                                </asp:Panel>
                                                            </td>
                                                            <td valign="top">
                                                                <asp:Panel ID="panel_nuevo_beneficiario" runat="server" GroupingText="Nuevo beneficiario de facturas" DefaultButton="btn_nuevo">
                                                                    <table>
                                                                        <tr><td><uc4:beneficiarioAbm ID="BeneficiarioAbm1" runat="server" /></td></tr>
                                                                        <tr><td align="center"><asp:ButtonAction ID="btn_nuevo" runat="server" Text="Registrar" TextoEnviando="Registrando" CausesValidation="true" ValidationGroup="beneficiario"/></td></tr>
                                                                    </table>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                               </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>

