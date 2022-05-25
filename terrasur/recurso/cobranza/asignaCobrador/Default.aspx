<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Asignación de cobrador" %>
<%@ Register Src="~/recurso/cobranza/asignaCobrador/userControl/asignaCobradorAbm.ascx" TagName="asignaCobradorAbm"
    TagPrefix="uc4" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoBusqueda.ascx" TagName="contratoBusqueda" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos" TagPrefix="uc3" %>

<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler ContratoBusqueda1.Eleccion, AddressOf busqueda_realizada
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "asignaCobrador", "asignar") Then

            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    
    Protected Sub busqueda_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim estado As Integer = contrato.Estado(ContratoBusqueda1.id_resultado, DateTime.Now)
        Dim c As New contrato(ContratoBusqueda1.id_resultado)
        'Se verifica que el estado no sea ni Revertido ni Liquidado
        'Inexistente(-1), Preasignado(0), Vigente(1), Revertido(2), Liquidado(3)
        If c.estado_id <> 2 And c.estado_id <> 3 Then 'And c.estado_id <> 0 Then
            If (c.venta_lote = True) Then
                panel_cambio.GroupingText = "Asignación de cobrador"
                ContratoDatos1.id_contrato = ContratoBusqueda1.id_resultado
                Id_contrato.Text = ContratoDatos1.id_contrato
                AsignaCobradorAbm1.id_contrato = ContratoDatos1.id_contrato
                AsignaCobradorAbm1.CargarInsertar()
                MultiView1.ActiveViewIndex = 1
            Else
                Msg1.Text = "El contrato elegido no es un contrato de venta de lote"
            End If
        End If
    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        ContratoBusqueda1.Reset()
        MultiView1.ActiveViewIndex = 0
    End Sub

   
    Protected Sub btn_asignar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_asignar.Click
        If AsignaCobradorAbm1.VerificarInsertar Then
            If AsignaCobradorAbm1.Insertar Then
                AsignaCobradorAbm1.CargarInsertar()
                MultiView1.ActiveViewIndex = 1
            End If
        Else
            Msg1.Text = "La asignación NO se guardó correctamente"
        End If
    End Sub
    


    
    
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="asignaCobrador" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:Label runat="server" id="Id_contrato" Visible="false"  Text="0"/>
<table class="priTable">
        <tr><td class="priTdTitle">Asignación de cobrador</td></tr>
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
                                            <tr><td class="tdEncabezado"><uc4:asignaCobradorAbm ID="AsignaCobradorAbm1" runat="server" /></td></tr>
                                            <tr>
                                                <td class="formEntTdButton">
                                                    <asp:ButtonAction ID="btn_asignar" runat="server" Text="Asignar"  TextoEnviando="Asignando" CausesValidation="true"
                                                        ValidationGroup="asignaCobrador" />
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

