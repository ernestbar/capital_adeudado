<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Cambio de Saldo de un contrato" %>

<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoBusqueda.ascx" TagName="contratoBusqueda" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos" TagPrefix="uc3" %>
<%@ Register Src="~/recurso/contrato/cambioSaldo/userControl/contratoCambioSaldo.ascx" TagPrefix="uc1" TagName="contratoCambioSaldo" %>

<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler ContratoBusqueda1.Eleccion, AddressOf busqueda_realizada
        If Not Page.IsPostBack Then
            If (Profile.entorno.id_rol <> 1) Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
            contratoCambioSaldo.CargarActualizar()
        End If
    End Sub

    Protected Sub busqueda_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        panel_cambio.GroupingText = "Cambio de Saldo de contrato"
        ContratoDatos1.id_contrato = ContratoBusqueda1.id_resultado
        Id_contrato.Text = ContratoDatos1.id_contrato
        btn_confirmar.Enabled = True
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        ContratoBusqueda1.Reset()
        MultiView1.ActiveViewIndex = 0
    End Sub


    Protected Sub btn_confirmar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_confirmar.Click
        contratoCambioSaldo.id_contrato = Integer.Parse(Id_contrato.Text)
        If contratoCambioSaldo.Actualizar() Then
            contratoCambioSaldo.CargarActualizar()
            busqueda_realizada(Me, New EventArgs())
        End If
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reprogramacion" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" runat="Server">
    <asp:Label runat="server" ID="Id_contrato" Visible="false" Text="0" />
    <table class="priTable">
        <tr>
            <td class="priTdTitle">Cambio de Saldo de contratos</td>
        </tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdBusqueda">
                                    <uc2:contratoBusqueda ID="ContratoBusqueda1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg></td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_cambio" runat="server" DefaultButton="btn_confirmar">
                                        <table class="tableContenido" align="center">
                                            <tr>
                                                <td class="tdButtonNuevaBusqueda">
                                                    <asp:Button ID="btn_volver" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" /></td>
                                            </tr>
                                            <tr>
                                                <td class="tdEncabezado">
                                                    <uc3:contratoDatos ID="ContratoDatos1" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="panel_view_plan_pago_nuevo" runat="server" GroupingText="Nuevo datos">
                                                        <uc1:contratoCambioSaldo runat="server" ID="contratoCambioSaldo" />
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:ButtonAction ID="btn_confirmar" runat="server" Text="Confirmar" TextoEnviando="Guardando" CausesValidation="true" ValidationGroup="contrato" />
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

