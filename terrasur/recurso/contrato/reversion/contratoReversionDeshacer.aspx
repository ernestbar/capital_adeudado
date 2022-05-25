<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Deshacer reversión" %>
<%@ Register Src="~/recurso/contrato/reversion/userControl/reversionDeshacerAbm.ascx" TagName="reversionDeshacerAbm" TagPrefix="uc4" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoBusqueda.ascx" TagName="contratoBusqueda" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos" TagPrefix="uc3" %>

<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler ContratoBusqueda1.Eleccion, AddressOf busqueda_realizada
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reversion", "deshacer") Then
                btn_deshacer.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reversion", "deshacer")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    
    Protected Sub busqueda_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim permitir_reactivación As Boolean = False
        
        'Se verifica que el estado sea Revertido
        'Inexistente(-1), Preasignado(0), Vigente(1), Revertido(2), Liquidado(3)
        Dim c As New contrato(ContratoBusqueda1.id_resultado)
        If c.estado_id = 2 Then
            Dim r As New reversion(reversion.ReversionNoAnulada(c.id_contrato))
            Dim m_r As New motivo_reversion(r.id_motivoreversion)

            'Verificar el tipo de contrato
            If c.venta_lote = True Then
                'verificar que el estado del lote sea disponible
                Dim c_v As New contrato_venta(c.id_contrato)
                Dim l As New lote(c_v.id_lote)
                Dim es As New estado(New estado_lote(l.id_estadolote).id_estado)
                If es.codigo = "dis" Then
                    'Verificar el negocio del lote
                    Dim n_c As New negocio_contrato(c.id_negociocontrato)
                    Dim n_l As New negocio_lote(l.id_negociolote)
                    If n_c.id_negocio = n_l.id_negocio Then
                        permitir_reactivación = True
                    Else
                        Msg1.Text = "El negocio del lote ha cambiado."
                    End If
                Else
                    Msg1.Text = "El lote del contrato no se encuentra disponible."
                End If
            End If
        Else
            Msg1.Text = "El estado actual del contrato es: " & c.estado_nombre
        End If
        
        'Se verifica que el contrato no tenga un reemboldo
        If terrasur.traspaso.reembolso.VerificarReembolsoContrato(ContratoBusqueda1.id_resultado) = True Then
            Msg1.Text = "NO puede reactivar este contrato, debido a que se realizó un Traspaso/Devolución sobre el mismo"
            permitir_reactivación = False
        End If
        
        If permitir_reactivación = True Then
            panel_cambio.GroupingText = "Deshacer reversión"
            ContratoDatos1.id_contrato = ContratoBusqueda1.id_resultado
            Id_contrato.Text = ContratoDatos1.id_contrato
            ReversionDeshacerAbm1.id_contrato = ContratoDatos1.id_contrato
            ReversionDeshacerAbm1.CargarInsertar()
            MultiView1.ActiveViewIndex = 1
        End If
        
    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        ContratoBusqueda1.Reset()
        MultiView1.ActiveViewIndex = 0
    End Sub

   
    Protected Sub btn_asignar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_deshacer.Click
        If ReversionDeshacerAbm1.VerificarDeshacer Then
            If ReversionDeshacerAbm1.Deshacer Then
                'ReversionDeshacerAbm1.CargarInsertar()
                ContratoBusqueda1.Reset()
                MultiView1.ActiveViewIndex = 0
            End If
        Else
            Msg1.Text = "La reversión se deshizo correctamente"
        End If
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reversion" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
      <asp:Label runat="server" id="Id_contrato" Visible="false"  Text="0"/>
<table class="priTable">
        <tr><td class="priTdTitle">Deshacer reversión</td></tr>
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
                                            <tr><td class="tdEncabezado"> 
                                                <uc4:reversionDeshacerAbm ID="ReversionDeshacerAbm1" runat="server" />
                                            </td></tr>
                                            <tr>
                                                <td class="formEntTdButton">
                                                    <asp:ButtonAction ID="btn_deshacer" runat="server" Text="Deshacer la reversión del contrato"  TextoEnviando="Deshaciendo" CausesValidation="true"
                                                        ValidationGroup="reversion" />
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

