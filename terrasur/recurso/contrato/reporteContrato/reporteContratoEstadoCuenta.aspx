	<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Estado de cuenta" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoBusqueda.ascx" TagName="contratoBusqueda" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Environment" %>
<%@ Import Namespace="System.Net" %>

<%@ Register src="~/recurso/contrato/reporteContrato/userControl/contratoOtrosDatos.ascx" tagname="contratoOtrosDatos" tagprefix="uc3" %>

<%@ Register src="~/recurso/contrato/reporteContrato/userControl/contratoDatosReembolso.ascx" tagname="contratoDatosReembolso" tagprefix="uc4" %>

<%@ Register src="~/recurso/contrato/reporteContrato/userControl/contratoEmisionTipoUso.ascx" tagname="contratoEmisionTipoUso" tagprefix="uc5" %>
<%@ Register src="~/recurso/userControl/contratoDatos.ascx" tagname="contratoDatos" tagprefix="uc6" %>
<%@ Register src="~/recurso/contrato/reporteContrato/userControl/contratoEmisionListaSimple.ascx" tagname="contratoEmisionListaSimple" tagprefix="uc7" %>
<%@ Register src="~/recurso/contrato/reporteContrato/userControl/contratoEmisionRegistro.ascx" tagname="contratoEmisionRegistro" tagprefix="uc8" %>


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
        AddHandler ContratoBusqueda1.Eleccion, AddressOf busqueda_realizada
        AddHandler contratoEmisionRegistro1.Continuar, AddressOf emisionRegistrada_Continuar

        If Not Page.IsPostBack Then
            recurso_intercambio()
            If Request.QueryString("t") IsNot Nothing Then
                If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "imprimirContratoEstadoCuenta") Then
                    btn_imprimir.Visible = True
                Else
                    btn_imprimir.Visible = False
                End If
            Else
                btn_imprimir.Visible = False
            End If
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "reporteContratoEstadoCuenta") Then
                Page.Visible = True
                If Session("id_contrato") IsNot Nothing Then
                    'CargarReportes(Int32.Parse(Session("id_contrato")))

                    '334 (S. MAYTA) ; 332 (C.Navarro) ; 610 (B.Huanca) ; 7 (M.Tejerina); 353 (N. Burgos); 340 Jcusicanqui 307 512; 702 (smamani)
                    If Profile.id_usuario = 334 Or Profile.id_usuario = 687 Or Profile.id_usuario = 353 Or Profile.id_usuario = 7 Or Profile.id_usuario = 332 Or Profile.id_usuario = 340 Or Profile.id_usuario = 645 Or Profile.id_usuario = 336 Or Profile.id_usuario = 656 Or Profile.id_usuario = 307 Or Profile.id_usuario = 512 Or Profile.id_usuario = 702 Then
                        CargarReportes(Int32.Parse(Session("id_contrato")))
                    Else
                        If contrato_estado_especial.BloquearContrato(Int32.Parse(Session("id_contrato")), Profile.entorno.codigo_modulo) = True Then
                            Page.Visible = False
                        Else
                            CargarReportes(Int32.Parse(Session("id_contrato")))
                        End If
                    End If

                    Session.Remove("id_contrato")
                    btn_volver.Visible = False
                Else
                    btn_volver.Visible = True
                End If
                'If Session("id_contrato") IsNot Nothing Then
                '    If contrato_estado_especial.BloquearContrato(Int32.Parse(Session("id_contrato")), Profile.entorno.codigo_modulo) = True Then
                '        Page.Visible = False
                '    Else
                '        CargarReportes(Int32.Parse(Session("id_contrato")))
                '    End If
                '    Session.Remove("id_contrato")
                '    btn_volver.Visible = False
                'Else
                '    btn_volver.Visible = True
                'End If
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
    Protected Sub recurso_intercambio()
        Dim ver As Boolean = modulo_recurso.Verificar(Profile.entorno.id_modulo, New recurso("intercambio").id_recurso)
        'panel_intercambio.Visible = ver
        If ver Then
            btn_intercambio.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "intercambio", "view")
        End If
    End Sub

    Protected Sub busqueda_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        'If VerificarPermiso(8, 11, ContratoBusqueda1.id_resultado) Then
        If VerificarPermiso(Profile.id_usuario, Profile.entorno.id_rol, ContratoBusqueda1.id_resultado) Then

            If contratoEmisionTipoUso1.interno = True Then
                Dim regEm As New terrasur.emDoc.emision("ec", ContratoBusqueda1.id_resultado, Profile.id_usuario, 0, "", "")
                regEm.Registrar()
                contratoEmisionTipoUso1.GuardarEleccion()

                CargarReportes(ContratoBusqueda1.id_resultado)
            Else
                MultiView1.ActiveViewIndex = 1
                'contratoDatos1.id_contrato = ContratoBusqueda1.id_resultado
                contratoEmisionRegistro1.Cargar(ContratoBusqueda1.id_resultado, "ec")
                contratoEmisionListaSimple1.Cargar(ContratoBusqueda1.id_resultado, "ec")

            End If
        Else
            Msg1.Text = "Usted no tiene autorizaci?n para ver este estado de cuenta"
        End If
    End Sub

    Protected Sub emisionRegistrada_Continuar(ByVal sender As Object, ByVal e As System.EventArgs)
        contratoEmisionTipoUso1.GuardarEleccion()
        CargarReportes(ContratoBusqueda1.id_resultado)
    End Sub

    Sub CargarReportes(ByVal Contrato_id As Integer)
        Dim c As New contrato(Contrato_id)
        Session("estadoCuenta") = "SI"
        panel_cambio.GroupingText = "Estado de cuenta"
        Dim ec As New rpt_ContratoEstadoCuenta()
        ec.DatosEstadoCuenta(Contrato_id, Profile.nombre_persona)
        ec.DataSource = contratoReporte.ReporteEstadoCuenta(Contrato_id)
        Id_contrato.Text = Contrato_id
        Reporte1.WebView.Report = ec
        MultiView1.ActiveViewIndex = 2
        If negocio_contrato.CodigoNegocioPorContrato(Contrato_id) = "nafibo" Then
            Msg1.Text = "CONTRATO NAFIBO"
        End If

        If Profile.entorno.codigo_modulo = "marketing" Or Profile.id_usuario = 331 Then
            lbl_preferencial.Visible = True
            If c.preferencial = True Then
                lbl_preferencial.Text = "CONTRATO PREFERENCIAL (NO REVERTIR)"
            Else
                lbl_preferencial.Text = "Contrato normal"
            End If
        Else
            lbl_preferencial.Visible = False
        End If

        lbl_msg_ctto_7323.Visible = Contrato_id.Equals(6658)

        'If Profile.id_usuario = 353 Or Profile.id_usuario = 348 Then
        '    lbl_negocio.Visible = False
        'Else
        '    lbl_negocio.Visible = True
        '    lbl_negocio.Text = "Contrato: " & c.numero & " (Negocio: " & c.negocio_nombre & ")"
        'End If
        lbl_terraplus.Text = terrasur.terraplus.tp_contrato.ListaContratosTerraplusPorContratoLote_cadena(Contrato_id).Replace(" ; ", "<br/>")
        contratoOtrosDatos1.CargarDatos(Contrato_id)
        contratoDatosReembolso1.id_contrato = Contrato_id
        lbl_negocio.Text = contratoOtrosDatos1.datos_otros
        lbl_observacion.Text = contratoOtrosDatos1.datos_obs
        gv_llamada.DataSource = callcenter.ListaLLamadasContrato(ContratoBusqueda1.id_resultado)

        gv_llamada.DataBind()

        Dim host As String = HttpContext.Current.Request.UserHostAddress

        Dim objcon As New contrato(ContratoBusqueda1.id_resultado)
        Dim path As String = Server.MapPath("~/logs/")
        Dim texto As String = ""
        If Session("imprimir") = "SI" Then
            texto = "Imprime estado de cuenta del contrato:|" + objcon.numero + "|Usuario:|" + Profile.UserName + "|Fecha y hora:|" + DateTime.Now + "|Equipo|:" + host
        Else
            texto = "Consulta estado de cuenta del contrato:|" + objcon.numero + "|Usuario:|" + Profile.UserName + "|Fecha y hora:|" + DateTime.Now + "|Equipo|:" + host
        End If

        Dim strFile As String = path + "EstdosLog_" & DateTime.Now.Day & DateTime.Now.Month & DateTime.Now.Year & ".txt"
        Dim sw As StreamWriter
        Try
            If (Not File.Exists(strFile)) Then
                sw = File.CreateText(strFile)
                'sw.WriteLine(texto)
            Else
                sw = File.AppendText(strFile)
            End If
            sw.WriteLine(texto)
            sw.Close()
        Catch ex As IOException
            'msgBox("Error writing to log file.")
        End Try
    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click, btn_volver2.Click
        ContratoBusqueda1.Reset()
        contratoEmisionTipoUso1.Reset()
        Session("estadoCuenta") = ""
        MultiView1.ActiveViewIndex = 0
        If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "imprimirContratoEstadoCuenta") Then
            btn_imprimir.Visible = True
        Else
            btn_imprimir.Visible = False
        End If
    End Sub

    Protected Function VerificarPermiso(ByVal _id_usuario As Integer, ByVal _id_rol As Integer, ByVal _id_contrato As Integer) As Boolean
        Try
            Dim db1 As Database = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings("conn"))
            Dim cmd As DbCommand = db1.GetStoredProcCommand("contrato_ReporteEstadoCuenta_VerificarPermiso")
            cmd.CommandTimeout = Integer.Parse(ConfigurationManager.AppSettings("CommandTimeout"))
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, _id_usuario)
            db1.AddInParameter(cmd, "id_rol", DbType.Int32, _id_rol)
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato)
            Return Integer.Parse(db1.ExecuteScalar(cmd).ToString).Equals(0).Equals(False)
        Catch ex As Exception
            Return True
        End Try
    End Function

    Protected Sub lbtnEstadoDesfasado_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/modulo/desfase/Default.aspx")
    End Sub

    Protected Sub btn_imprimir_Click(ByVal sender As Object, ByVal e As EventArgs)
        Session("imprimir") = "SI"
        CargarReportes(ContratoBusqueda1.id_resultado)
        btn_imprimir.Visible = False
    End Sub
    Protected Sub btn_intercambio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_intercambio.Click
        Response.Redirect("~/recurso/contrato/intercambio/Default.aspx")
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteContrato" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:Label runat="server" id="Id_contrato" Visible="False"  />
<table class="priTable">
        <tr><td class="priTdTitle">Estado de cuenta</td></tr>
   
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr><td><uc5:contratoEmisionTipoUso ID="contratoEmisionTipoUso1" runat="server" /></td></tr>
                            <tr><td class="tdBusqueda"><uc2:contratoBusqueda ID="ContratoBusqueda1" runat="server" /></td></tr>
                            <tr><td class="tdMsg"><asp:Msg ID="Msg1" runat="server"></asp:Msg></td></tr>
                            
                            <asp:LinkButton ID="lbtnEstadoDesfasado" runat="server" OnClick="lbtnEstadoDesfasado_Click">Ver desfase</asp:LinkButton><br />
                            <asp:Button ID="btn_intercambio" runat="server" Text="Ver Intercambios" SkinID="btnWebPart"/>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table align="center" >
                            <tr><td align="right"><asp:Button ID="btn_volver2" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" /></td></tr>
                            <%--<tr><td><uc6:contratoDatos ID="contratoDatos1" runat="server" /></td></tr>--%>
                            <tr><td><uc7:contratoEmisionListaSimple ID="contratoEmisionListaSimple1" runat="server" /></td></tr>
                            <tr><td><uc8:contratoEmisionRegistro ID="contratoEmisionRegistro1" runat="server" /></td></tr>
                        </table>
                        
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                        <table align="center">
                            <tr><td class="tdMsg"><asp:Msg ID="Msg2" runat="server"></asp:Msg></td></tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_cambio" runat="server">
                                        <table class="tableContenido" align="center">
											<tr><td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_volver" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" /></td></tr>
											<tr><td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_imprimir" runat="server" Text="Imprimir" OnClick="btn_imprimir_Click" SkinID="btnVolver" /></td></tr>
                                            <tr><td align="left"><asp:Label ID="lbl_preferencial" runat="server" SkinID="lbl_CajaIngresoPermitido"></asp:Label></td>
                                            <tr><td colspan="2" align="left" style="width:800px;"><asp:Label ID="lbl_negocio" runat="server" SkinID="lblEnun"></asp:Label></td></tr>
                                            <tr><td colspan="2" align="left" style="width:800px;"><asp:Label ID="lbl_terraplus" runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label></td></tr>
                                            <tr><td colspan="2" align="center" style="width:800px;"><asp:Label ID="lbl_msg_ctto_7323" runat="server" Visible="false" ForeColor="Red" Font-Bold="true" Font-Size="X-Large" Text="El lote del contrato 7323 fue vendido al Sr. Walter Manuel Loza Flores con el ctto. 6833"></asp:Label></td></tr>
                                            <tr><td colspan="2" align="left" style="width:800px;"><uc4:contratoDatosReembolso ID="contratoDatosReembolso1" runat="server" /></td></tr>
                                            <tr><td colspan="2" class="tdEncabezado"><uc1:reporte ID="Reporte1" runat="server" /></td></tr>
                                            <tr><td colspan="2" align="left" style="width:800px;"><asp:Label ID="lbl_observacion" runat="server" SkinID="lblEnun"></asp:Label></td></tr>
                                            <tr><td colspan="2"><uc3:contratoOtrosDatos ID="contratoOtrosDatos1" runat="server" /></td></tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                     <asp:WizardGridView AllowPaging="true" PageSize="20" ID="gv_llamada" runat="server" AutoGenerateColumns="false" DataKeyNames="id_llamada" >
                                        <Columns>
                                          
                                            <asp:BoundField HeaderText="Fecha Llamada" DataField="fecha_llamada" />
                                            <asp:BoundField HeaderText="Cliente" DataField="nombre_cliente" />
                                            <asp:BoundField HeaderText="Respuetas" DataField="respuesta_cliente" />
                                            <asp:BoundField HeaderText="Usuario" DataField="nombre_call_center" />
                                          
                                        </Columns>
                                    </asp:WizardGridView>
                                  
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>

</asp:Content>

