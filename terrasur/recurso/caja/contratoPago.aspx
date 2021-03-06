<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Caja - Pagos" %>
<%--<%@ Register Assembly="MakeNoise" Namespace="MakeNoise" TagPrefix="cc1" %>--%>

<%@ Register Src="~/recurso/caja/userControl/cajaMaster.ascx" TagName="cajaMaster" TagPrefix="uc0" %>
<%--<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>--%>
<%@ Register Src="~/recurso/userControl/contratoBusqueda.ascx" TagName="contratoBusqueda" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/caja/pagoInicial/userControl/ingresoPagoInicial.ascx" TagName="ingresoPagoInicial" TagPrefix="uc3" %>
<%@ Register Src="~/recurso/caja/pagoCapital/userControl/ingresoPagoCapital.ascx" TagName="ingresoPagoCapital" TagPrefix="uc4" %>
<%@ Register Src="~/recurso/caja/pagoAdelantado/userControl/ingresoPagoAdelantado.ascx" TagName="ingresoPagoAdelantado" TagPrefix="uc5" %>
<%@ Register Src="~/recurso/caja/pagoMora/userControl/ingresoPagoMora.ascx" TagName="ingresoPagoMora" TagPrefix="uc6" %>
<%@ Register Src="~/recurso/caja/pagoNormal/userControl/ingresoPagoNormal.ascx" TagName="ingresoPagoNormal" TagPrefix="uc7" %>
<%@ Register Src="~/recurso/caja/pagoSegunPlan/userControl/ingresoPagoSegunPlan.ascx" TagName="ingresoPagoSegunPlan" TagPrefix="uc8" %>
<%@ Register Src="~/recurso/caja/pagoOtroServicio/userControl/ingresoPagoServiciosCliente.ascx" TagName="ingresoPagoServiciosCliente" TagPrefix="uc9" %>
<%@ Register Src="~/recurso/caja/liquidacion/userControl/ingresoLiquidacion.ascx" TagName="ingresoLiquidacion" TagPrefix="uc10" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler ContratoBusqueda1.Eleccion, AddressOf busqueda_realizada
        If Not Page.IsPostBack Then
            If Session("id_contrato") IsNot Nothing Then
                ContratoDatos1.id_contrato = Integer.Parse(Session("id_contrato").ToString)
                MultiView1.ActiveViewIndex = 1
                CargarPagos()
                Session.Remove("id_contrato")
            Else
                If parametro_facturacion.ActivoActual = 0 Or tipo_cambio.Actual = 0 Or _
                contrato.PermitirPagosContrato(Profile.id_usuario, Profile.entorno.id_rol) = False Then
                    Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
                End If
            End If
        End If
    End Sub

    Protected Sub busqueda_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        'If negocio_contrato.CodigoNegocioPorContrato(ContratoBusqueda1.id_resultado) = "bbr" Then
        Dim permitir_cobrar As Boolean = True
        Dim num_sucursal As Integer = Integer.Parse(ConfigurationManager.AppSettings("num_sucursal"))

        'ALERTAS PARA EL NO PAGO DE PROMOCION DE FIN A?O
        Dim sec As New contrato_venta(ContratoBusqueda1.id_resultado)
        Dim urbanizacion As String
        urbanizacion = sec.urbanizacion_nombre_corto.Trim()
        If urbanizacion = "J.LIPARI" Or urbanizacion = "J.LIPARI1" Or urbanizacion = "TERRAZAS DE LIPARI" Or urbanizacion = "Cerro Negro" Or urbanizacion = "Media Luna" Or urbanizacion = "URB. PRADERA DE SAYTU" Then
            Msg1.Text ="LA URBANIZACION: " & urbanizacion & " NO PARTICIPA DE LA PROMOCION DE FIN DE A?O!"
        End If

        If urbanizacion = "URB. EUROPA" Then
            Msg1.Text = "LA URBANIZACION: " & urbanizacion & " DEBE PAGAR IMPUESTO DE LA GESTION 2019 POR OTROS SERVICIOS"
        End If
		If urbanizacion = "V.ESMER/02(u)" Then
            Msg1.Text = "LA URBANIZACION: " & urbanizacion & " DEBE PAGAR IMPUESTO DE LA GESTION 2019 - 2020 POR OTROS SERVICIOS"
        End If
        If urbanizacion = "LAS PALMERAS" Then
            Msg1.Text = "LA URBANIZACION: " & urbanizacion & " DEBE PAGAR IMPUESTOS ANUALES POR OTROS SERVICIOS, SEG?N LISTADO NOTA No. 03/2022 AREA LEGAL - DIVISION Y PARTICI?N"
        End If
        'Se realiza verificaciones para las sucursales
        If num_sucursal > 0 Then
            Dim codigo_negocio As String = negocio_contrato.CodigoNegocioPorContrato(ContratoBusqueda1.id_resultado)

            If codigo_negocio = "nafibo" Then
                'Se verifica si es un contrato NAFIBO
                Dim p_sucursal_permitir_pago_nafibo As New parametro("sucursal_permitir_pago_nafibo")
                If p_sucursal_permitir_pago_nafibo.valor = 0 Then
                    permitir_cobrar = False
                    Msg1.Text = "Contrato NAFIBO, solo se paga en la OFICINA CENTRAL"
                End If
            ElseIf codigo_negocio = "pr_casas" Or codigo_negocio = "pr_amanecer" Or codigo_negocio = "ed_suiza1" Or codigo_negocio = "pr_edificios" Or codigo_negocio = "mercado" Then
                'Se verifica si es un contrato de CASAS
                Dim p_sucursal_permitir_pago_casas As New parametro("sucursal_permitir_pago_casas")
                If p_sucursal_permitir_pago_casas.valor = 0 Then
                    permitir_cobrar = False
                    Msg1.Text = "Contrato de Inmueble, solo se paga en la OFICINA CENTRAL"
                End If
            End If
        End If

        'Se verifica que el contrato no tenga un reemboldo
        If terrasur.traspaso.reembolso.VerificarReembolsoContrato(ContratoBusqueda1.id_resultado) Then
            permitir_cobrar = False
            Msg1.Text = "NO puede realizar pagos sobre este contrato, debido a que se realiz? un Traspaso/Devoluci?n sobre el mismo"
        End If

        'Si esta se continua con el pago
        If permitir_cobrar = True Then
            ContratoDatos1.id_contrato = ContratoBusqueda1.id_resultado
            MultiView1.ActiveViewIndex = 1
            CargarPagos()
        End If

        'Else
        '    Msg1.Text = "Temporalmente no esta disponible el cobro de contratos TERRASUR, CEA y NAFIBO"
        'End If
    End Sub

    Protected Sub CargarPagos()
        Dim ica As Decimal = contrato.InteresAcumulado(ContratoDatos1.id_contrato)

        If ica > 0 Then
            lbl_mensaje_ica.Visible = True
            lbl_mensaje_ica.Text = "El cliente de este contrato adeuda $us " & ica.ToString("F2") & " por concepto de Inter?s Corriente Acumulado"
        Else
            lbl_mensaje_ica.Visible = False
        End If
        IngresoPagoInicial1.id_contrato = ContratoDatos1.id_contrato
        IngresoPagoCapital1.id_contrato = ContratoDatos1.id_contrato
        IngresoPagoAdelantado1.id_contrato = ContratoDatos1.id_contrato
        'IngresoPagoMora1.id_contrato = ContratoDatos1.id_contrato
        IngresoPagoNormal1.id_contrato = ContratoDatos1.id_contrato
        IngresoPagoSegunPlan1.id_contrato = ContratoDatos1.id_contrato
        IngresoPagoServiciosCliente1.id_contrato = ContratoDatos1.id_contrato
        If contrato.EsContratoVenta(ContratoDatos1.id_contrato) AndAlso _
        liquidacion.LiquidacionPermitir(ContratoDatos1.id_contrato, Profile.id_usuario, Profile.entorno.id_rol) Then
            panel_liquidacion.Visible = True
            IngresoLiquidacion1.id_contrato = ContratoDatos1.id_contrato
        Else
            panel_liquidacion.Visible = False
        End If
        If negocio_contrato.CodigoNegocioPorContrato(ContratoDatos1.id_contrato) = "nafibo" Then
            Msg1.Text = "CONTRATO NAFIBO"
            'PlayPageSound1.SoundFile = VirtualPathUtility.ToAbsolute("~/sounds/alert/nafibo.wav")
            Dim par_fuera_hora_sabado_hora As String = "fuera_hora_sabado_hora"
            Dim par_fuera_hora_lun_vie_hora As String = "fuera_hora_lun_vie_hora"
            If Integer.Parse(ConfigurationManager.AppSettings("num_sucursal")) > 0 Then
                par_fuera_hora_sabado_hora = "sucursal_fuera_hora_sabado_hora"
                par_fuera_hora_lun_vie_hora = "sucursal_fuera_hora_lun_vie_hora"
            End If

            If DateTime.Now.DayOfWeek = DayOfWeek.Saturday Then
                If DateTime.Now > parametro.ConvertDecimalToDateTime(DateTime.Now, New parametro(par_fuera_hora_sabado_hora).valor) Then
                    Msg2.Text = "EL PAGO SER? REALIZADO FUERA DE HORA"
                End If
            Else
                If DateTime.Now > parametro.ConvertDecimalToDateTime(DateTime.Now, New parametro(par_fuera_hora_lun_vie_hora).valor) Then
                    Msg2.Text = "EL PAGO SER? REALIZADO FUERA DE HORA"
                End If
            End If

            Dim coObj As New contrato(ContratoDatos1.id_contrato)
            If ",6966,6967,7053,7377,7531,7920,7987,8656,8828,10118,".Contains("," & coObj.numero & ",") = True Then
                Msg3.Text = "El dep?sito en caja del BNB de este contrato (" & coObj.numero & ") NO PUEDE SER INFERIOR a la CUOTA MENSUAL ESTABLECIDA, comunicarse con ERLAND ESPINOZA o FELIX NINA para realizar el dep?sito en caja del BNB"
            End If
        End If
        If contrato_estado_especial.VerificarActivo(ContratoDatos1.id_contrato, 0, "", "correspondencia") Then
            lbl_correspondencia.Visible = True
            Dim dt As System.Data.DataTable
            Dim dr As System.Data.DataRow
            dt = contrato_estado_especial.RecuperarMensaje(ContratoDatos1.id_contrato, 2)
            For Each dr In dt.Rows
                Msg3.Text = dr("observacion").ToString()
            Next
            'Msg3.Text = "Solo cobrar una cuota mensualmente por instrucci?n de Armando Balcazar"
            'PlayPageSound1.SoundFile = VirtualPathUtility.ToAbsolute("~/sounds/alert/carta.wav")
        Else
            lbl_correspondencia.Visible = False
        End If
        If contrato_estado_especial.VerificarActivo(ContratoDatos1.id_contrato, 0, "", "no_promocion") Then
            Msg4.Text = "ANUNCIO:NO PARTICIPA DE LA PROMOCION"
        End If
        Mensaje_impuestos_la_suizaII(ContratoDatos1.id_contrato)

        'Dim Num_dprs As Integer = 0
        'Dim Monto_dprs As Decimal = 0
        'contrato.NumDprsPromocion(ContratoDatos1.id_contrato, Num_dprs, Monto_dprs)
        'lbl_dprs.Text = "Se realizaron " & Num_dprs & " pago(s) con DPR (de Promoci?n) por un monto de $us " & Monto_dprs.ToString("F2") & " desde el 06/11/2012"

        'If Integer.Parse(ConfigurationManager.AppSettings("num_sucursal")) = 0 Then
        Dim permiso_promocion As Hashtable = promocion.PermisoPorContrato(ContratoDatos1.id_contrato)
        '[permitir],[periodo_correcto],[es_terreno],[es_nafibo],[num_pagos_promo_mes],[al_dia]
        If permiso_promocion("periodo_correcto").ToString = "1" Then
            If permiso_promocion("permitir").ToString = "1" Then
                lbl_promocion_si.Text = "El cliente puede acceder a la promoci?n"
                lbl_promocion_no.Text = ""

                If permiso_promocion("al_dia").ToString = "0" Then
                    lbl_promocion_no.Text = "El contrato no est? al d?a"
                End If
            Else
                lbl_promocion_si.Text = ""
                lbl_promocion_no.Text = "El cliente NO puede acceder a la promoci?n"

                If permiso_promocion("es_terreno").ToString = "1" Then
                    If permiso_promocion("es_nafibo").ToString = "1" Then
                        lbl_promocion_no.Text &= ": " & "El contrato Nafibo no puede acceder a la promoci?n"
                    Else
                        If Integer.Parse(permiso_promocion("num_pagos_promo_mes").ToString()) > 0 Then
                            lbl_promocion_no.Text &= ": " & "El cliente ya accedi? a la promoci?n"
                        Else
                            If permiso_promocion("al_dia").ToString = "0" Then
                                lbl_promocion_no.Text &= ": " & "El contrato no est? al d?a"
                            End If
                        End If
                    End If
                End If
            End If
        Else
            lbl_promocion_si.Text = ""
            lbl_promocion_no.Text = ""
        End If
        'Else
        '    lbl_promocion_si.Text = ""
        '    lbl_promocion_no.Text = "El cliente NO puede acceder a la promoci?n en las sucursales"
        'End If


    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        ContratoBusqueda1.Reset()
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub Mensaje_impuestos_la_suizaII(ByVal Id_contrato As Integer)
        If DateTime.Now.Date >= DateTime.Parse("01/01/2015") And DateTime.Now.Date <= DateTime.Parse("28/02/2015") Then
            Dim db1 As Microsoft.Practices.EnterpriseLibrary.Data.Database = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings("conn"))
            Dim cmd As System.Data.Common.DbCommand = db1.GetStoredProcCommand("contrato_VerificacionImpuestoLaSuizaII")
            db1.AddInParameter(cmd, "id_contrato", System.Data.DbType.Int32, Id_contrato)
            db1.AddOutParameter(cmd, "es_suizaII", System.Data.DbType.Int32, 32)
            db1.AddOutParameter(cmd, "pago_impuestos", System.Data.DbType.Int32, 32)
            db1.ExecuteNonQuery(cmd)
            Dim es_suizaII As Integer = Integer.Parse(db1.GetParameterValue(cmd, "es_suizaII").ToString())
            Dim pago_impuestos As Integer = Integer.Parse(db1.GetParameterValue(cmd, "pago_impuestos").ToString())
            If es_suizaII > 0 Then
                If pago_impuestos = 0 Then
                    Msg4.Text = "El contrato es de la Suiza II, debe pagar IMPUESTOS de la gesti?n 2013"
                End If
            End If
        End If
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc0:cajaMaster ID="CajaMaster1" runat="server" tipo_pago="" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="priTable">
        <tr>
            <td class="priTdTitle">
                Caja - Pagos
            </td>
        </tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr><td class="tdBusqueda"><uc1:contratoBusqueda ID="ContratoBusqueda1" runat="server" /></td></tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                    <asp:Msg ID="Msg2" runat="server"></asp:Msg>
                                    <asp:Msg ID="Msg3" runat="server"></asp:Msg>
                                    
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <table class="tableContenido" align="center">
                                        <tr><td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_volver" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" /></td></tr>
                                        <tr><td class="tdEncabezado"><uc2:contratoDatos ID="ContratoDatos1" runat="server" /></td></tr>
                                        <tr><td align="center"><asp:Label ID="lbl_correspondencia" runat="server" Visible="false" Text="Solo cobrar una cuota mensualmente por instrucci?n de Armando Balcazar" SkinID="lbl_CajaIngresoPermitido"></asp:Label></td></tr>
                                        <tr><td align="center"><asp:Label ID="lbl_mensaje_ica" runat="server" SkinID="lbl_CajaIngresoMensaje" Visible="false"></asp:Label></td></tr>
                                        <%--<tr><td align="center"><asp:Label ID="lbl_dprs" runat="server" SkinID="lbl_CajaIngresoPermitido"></asp:Label></td></tr>--%>
                                        <tr><td align="center"><asp:Label ID="lbl_promocion_si" runat="server" SkinID="lbl_CajaIngresoPermitido"></asp:Label></td></tr>
                                        <tr><td align="center"><asp:Label ID="lbl_promocion_no" runat="server" SkinID="lbl_CajaIngresoMensaje"></asp:Label></td></tr>
                                        <tr>
                                            <td class="tdGrid">
                                                <table align="center" width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="panel_pago" runat="server" GroupingText="PAGOS">
                                                                <table align="center" width="100%">
                                                                    <tr><td align="center"><asp:Msg ID="Msg4" runat="server"></asp:Msg></td></tr>
                                                                    <%--<tr><td><uc6:ingresoPagoMora ID="IngresoPagoMora1" runat="server" /></td></tr>--%>
                                                                    <tr><td><uc3:ingresoPagoInicial ID="IngresoPagoInicial1" runat="server" /></td></tr>
                                                                    <tr><td><uc7:ingresoPagoNormal ID="IngresoPagoNormal1" runat="server" /></td></tr>
                                                                    <tr><td><uc8:ingresoPagoSegunPlan ID="IngresoPagoSegunPlan1" runat="server" /></td></tr>
                                                                    <%--<tr><td><uc5:ingresoPagoAdelantado ID="IngresoPagoAdelantado1" runat="server" /></td></tr>
                                                                    <tr><td><uc4:ingresoPagoCapital ID="IngresoPagoCapital1" runat="server" /></td></tr>--%>
                                                                    <tr><td><table width="100%"><tr>
                                                                        <td><uc5:ingresoPagoAdelantado ID="IngresoPagoAdelantado1" runat="server" /></td>
                                                                        <td><uc4:ingresoPagoCapital ID="IngresoPagoCapital1" runat="server" /></td>
                                                                    </tr></table></td></tr>
                                                                    <tr><td><uc9:ingresoPagoServiciosCliente ID="IngresoPagoServiciosCliente1" runat="server" /></td></tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="panel_liquidacion" runat="server" GroupingText="LIQUIDACI?N DEL CONTRATO">
                                                                <table align="center" width="100%">
                                                                    <tr><td><uc10:ingresoLiquidacion ID="IngresoLiquidacion1" runat="server" />
                                                                    </td></tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <%--<cc1:PlayPageSound ID="PlayPageSound1" runat="server" />--%>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>
