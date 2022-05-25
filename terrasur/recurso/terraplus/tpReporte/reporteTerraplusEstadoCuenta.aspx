<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Resumen de pagos TerraPlus" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>
<%@ Register src="~/recurso/terraplus/tpContrato/userControl/tpDatosTerraPlus.ascx" tagname="tpDatosTerraPlus" tagprefix="uc2" %>
<%@ Register src="~/recurso/terraplus/tpContrato/userControl/tpContratoBusqueda.ascx" tagname="tpContratoBusqueda" tagprefix="uc3" %>

<script runat="server">
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs)
        If Request.QueryString("t") IsNot Nothing AndAlso Session("id_contrato") IsNot Nothing Then
            Session.Remove("id_contrato")
        End If
        If Session("id_contrato") IsNot Nothing Then
            general.CambiarMasterPage(Me, False)
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler tpContratoBusqueda1.Eleccion, AddressOf busqueda_realizada
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpReporte", "reporteTerraplusEstadoCuenta") Then
                Page.Visible = True
                If Session("id_contrato") IsNot Nothing Then
                    If contrato_estado_especial.BloquearContrato(Int32.Parse(Session("id_contrato")), Profile.entorno.codigo_modulo) = True Then
                        Page.Visible = False
                    Else
                        CargarReportes(Int32.Parse(Session("id_contrato")))
                    End If
                    Session.Remove("id_contrato")
                    btn_volver.Visible = False
                Else
                    btn_volver.Visible = True
                End If
            Else
                If Session("id_contrato") IsNot Nothing Then
                    Page.Visible = False
                Else
                    Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
                End If
            End If
            If Page.MasterPageFile.Contains("simple.master") Then
                Reporte1.Formato_Web = False
            End If
        End If
    End Sub
    
    
    Protected Sub busqueda_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        'If VerificarPermiso(Profile.id_usuario, Profile.entorno.id_rol, tpContratoBusqueda1.id_resultado) Then
        CargarReportes(tpContratoBusqueda1.id_resultado)
        'Else
        '   Msg1.Text = "Usted no tiene autorización para ver este estado de cuenta"
        'End If
    End Sub

    Sub CargarReportes(ByVal Contrato_id As Integer)
        'Dim c As New contrato(Contrato_id)
        'Id_contrato.Text = Contrato_id
        Dim rptEc As New rpt_tpEstadoCuenta()
        rptEc.DatosEstadoCuenta(Contrato_id, Profile.nombre_persona, terrasur.terraplus.tp_contrato.CodigoMoneda(Contrato_id))
        rptEc.DataSource = terrasur.terraplus.tp_terraplusReporte.ReporteEstadoCuenta(Contrato_id)
        Reporte1.WebView.Report = rptEc
        MultiView1.ActiveViewIndex = 1
    End Sub
    
    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        tpContratoBusqueda1.Reset()
        MultiView1.ActiveViewIndex = 0
    End Sub

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="tpReporte" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <%--<asp:Label runat="server" id="Id_contrato" Visible="False"  />--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table class="priTable">
        <tr><td class="priTdTitle">Resumen de pagos TerraPlus</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr><td class="tdBusqueda"><uc3:tpContratoBusqueda ID="tpContratoBusqueda1" runat="server" buscar_contrato="false" />
                                </td></tr>
                            <tr><td class="tdMsg"><asp:Msg ID="Msg1" runat="server"></asp:Msg></td></tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table align="center">
                            <tr><td class="tdMsg"><asp:Msg ID="Msg2" runat="server"></asp:Msg></td></tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_cambio" runat="server" GroupingText="Resumen de pagos TerraPlus">
                                        <table class="tableContenido" align="center">
                                            <tr>
                                                <td align="left"><asp:Label ID="lbl_preferencial" runat="server" SkinID="lbl_CajaIngresoPermitido"></asp:Label></td>
                                                <td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_volver" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" /></td>
                                            </tr>
                                            <tr><td colspan="2" class="tdEncabezado"><uc1:reporte ID="Reporte1" runat="server" /></td></tr>
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

