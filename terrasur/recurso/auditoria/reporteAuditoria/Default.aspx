<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reportes de auditoría" %>

<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/auditoria/reporteAuditoria/userControl/reporteAuditoriaFiltro.ascx" TagName="reporteAuditoriaFiltro" TagPrefix="uc3" %>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteAuditoria", "ver") Then
                raf1.Reporte = ""
                btn_mostrar_reporte.Enabled = False
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub ddl_reporte_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_reporte_auditoria.DataBound, ddl_reporte_parametro.DataBound
        Dim ddl_reporte As DropDownList = CType(sender, DropDownList)
        ddl_reporte.Items.Insert(0, New ListItem("", ""))
        If Session("codigo_reporte") IsNot Nothing Then
            If ddl_reporte.Items.FindByValue(Session("codigo_reporte").ToString) IsNot Nothing Then
                ddl_reporte.SelectedValue = Session("codigo_reporte").ToString
                raf1.Reporte = ddl_reporte.SelectedValue
                btn_mostrar_reporte.Enabled = ddl_reporte.SelectedValue.Equals("").Equals(False)
                Session.Remove("codigo_reporte")
            End If
        End If
    End Sub
    Protected Sub ddl_reporte_auditoria_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_reporte_auditoria.SelectedIndexChanged
        If ddl_reporte_auditoria.SelectedValue <> "" Then
            ddl_reporte_parametro.SelectedValue = ""
        End If
        raf1.Reporte = ddl_reporte_auditoria.SelectedValue
        btn_mostrar_reporte.Enabled = ddl_reporte_auditoria.SelectedValue.Equals("").Equals(False)
    End Sub
    Protected Sub ddl_reporte_parametro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_reporte_parametro.SelectedIndexChanged
        If ddl_reporte_parametro.SelectedValue <> "" Then
            ddl_reporte_auditoria.SelectedValue = ""
        End If
        raf1.Reporte = ddl_reporte_parametro.SelectedValue
        btn_mostrar_reporte.Enabled = ddl_reporte_parametro.SelectedValue.Equals("").Equals(False)
    End Sub
    
    Protected Sub btn_mostrar_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar_reporte.Click
        Page.Title = "Reportes de auditoría" & " - " & raf1.ReporteNombre
        Reporte1.NombreReporte = raf1.Reporte
        Select Case raf1.Reporte
            Case "audit_reporte_asignacion_promotor"
                Dim reporte As New rpt_audit_reporte_asignacion_promotor
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_contrato_nuevo"
                Dim reporte As New rpt_audit_reporte_contrato_nuevo
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_reversion_anulada"
                Dim reporte As New rpt_audit_reporte_reversion_anulada
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_liquidacion"
                Dim reporte As New rpt_audit_reporte_liquidacion
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_transaccion"
                Dim reporte As New rpt_audit_reporte_transaccion
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_lote"
                Dim reporte As New rpt_audit_reporte_lote
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_cliente"
                Dim reporte As New rpt_audit_reporte_cliente
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_usuario"
                Dim reporte As New rpt_audit_reporte_usuario
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_tipo_cambio"
                Dim reporte As New rpt_audit_reporte_tipo_cambio
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_ciclo_comercial"
                Dim reporte As New rpt_audit_reporte_ciclo_comercial
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_pago_anulado"
                Dim reporte As New rpt_audit_reporte_pago_anulado
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_servicio_vendido_anulado"
                Dim reporte As New rpt_audit_reporte_servicio_vendido_anulado
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_reprogramacion"
                Dim reporte As New rpt_audit_reporte_reprogramacion
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_reprogramacion_anulada"
                Dim reporte As New rpt_audit_reporte_reprogramacion_anulada
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_factura_anulada"
                Dim reporte As New rpt_audit_reporte_factura_anulada
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_recibo_anulado"
                Dim reporte As New rpt_audit_reporte_recibo_anulado
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_comprobante_anulado"
                Dim reporte As New rpt_audit_reporte_comprobante_anulado
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_comision_promotor_eliminado"
                Dim reporte As New rpt_audit_reporte_comision_promotor_eliminado
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_lote_estado"
                Dim reporte As New rpt_audit_reporte_lote_estado
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_lote_negocio"
                Dim reporte As New rpt_audit_reporte_lote_negocio
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_contrato_tipo_cliente"
                Dim reporte As New rpt_audit_reporte_contrato_tipo_cliente
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_contrato_lote"
                Dim reporte As New rpt_audit_reporte_contrato_lote
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_contrato_cliente"
                Dim reporte As New rpt_audit_reporte_contrato_cliente
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_pago_fuera_hora"
                Dim reporte As New rpt_audit_reporte_pago_fuera_hora
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_parametro_general"
                Dim reporte As New rpt_audit_reporte_parametro_general
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_parametro_facturacion"
                Dim reporte As New rpt_audit_reporte_parametro_facturacion
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_parametro_facturacion_negocio"
                Dim reporte As New rpt_audit_reporte_parametro_facturacion_negocio
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_servicio"
                Dim reporte As New rpt_audit_reporte_servicio
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_dpr"
                Dim reporte As New rpt_audit_reporte_dpr
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_banco"
                Dim reporte As New rpt_audit_reporte_banco
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_lugar_cobro"
                Dim reporte As New rpt_audit_reporte_lugar_cobro
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_motivo_reversion"
                Dim reporte As New rpt_audit_reporte_motivo_reversion
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_motivo_desactivacion"
                Dim reporte As New rpt_audit_reporte_motivo_desactivacion
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_recibo_cobrador_transaccion"
                Dim reporte As New rpt_audit_reporte_recibo_cobrador_transaccion
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_recibo_regularizacion"
                Dim reporte As New rpt_audit_reporte_recibo_regularizacion
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_recibo_gastos"
                Dim reporte As New rpt_audit_reporte_recibo_gastos
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte

            Case "audit_reporte_tarjeta_credito"
                Dim reporte As New rpt_audit_reporte_tarjeta_credito
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_tarjeta_credito_contrato"
                Dim reporte As New rpt_audit_reporte_tarjeta_credito_contrato
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_grupo_transaccion"
                Dim reporte As New rpt_audit_reporte_grupo_transaccion
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_tarjeta_credito_transaccion"
                Dim reporte As New rpt_audit_reporte_tarjeta_credito_transaccion
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
                
                
            Case "audit_reporte_intercambio"
                Dim reporte As New rpt_audit_reporte_intercambio
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
                
                
            Case "audit_reporte_re_motivo"
                Dim reporte As New rpt_audit_reporte_re_motivo
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_re_item"
                Dim reporte As New rpt_audit_reporte_re_item
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_re_usuario_reembolso"
                Dim reporte As New rpt_audit_reporte_re_usuario_reembolso
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_re_reembolso"
                Dim reporte As New rpt_audit_reporte_re_reembolso
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_re_item_reembolso"
                Dim reporte As New rpt_audit_reporte_re_item_reembolso
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_re_contrato_destino"
                Dim reporte As New rpt_audit_reporte_re_contrato_destino
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
            Case "audit_reporte_re_pago"
                Dim reporte As New rpt_audit_reporte_re_pago
                reporte.DataSource = auditoriaReporte.Reporte(raf1.Reporte, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                reporte.CargarDatos(raf1.ReporteNombre, raf1.usuario, raf1.tipo_fecha, raf1.fecha_inicio, raf1.fecha_fin, raf1.num_contrato, raf1.entero, raf1.cadena)
                Reporte1.WebView.Report = reporte
        End Select
    End Sub

</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteAuditoria" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <table class="priTable">
        <tr><td class="priTdTitle"><asp:Label ID="lbl_titulo" runat="server" Text="Reportes de auditoría"></asp:Label></td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:Panel ID="panel_filtro" runat="server" DefaultButton="btn_mostrar_reporte">
                    <table class="formEntTable">
                        <tr>
                            <td>
                                <table align="center"><tr><td>
                                <asp:Panel ID="panel_reporte" runat="server" GroupingText="Tipo de reporte">
                                    <table class="formTable">
                                        <tr>
                                            <td class="formTdEnun"><asp:Label ID="lbl_reporte_auditoria" runat="server" Text="Operaciones y transacciones:" SkinID="lblEnun"></asp:Label></td>
                                            <td class="formTdDato">
                                                <asp:DropDownList ID="ddl_reporte_auditoria" runat="server" AutoPostBack="true" DataSourceID="xds_lista_reporte_auditoria" DataValueField="codigo" DataTextField="nombre"></asp:DropDownList>
                                                <asp:XmlDataSource ID="xds_lista_reporte_auditoria" runat="server" DataFile="~/App_Data/reportesAuditoria.xml" XPath="/reportes/reporte[@parametro='false']"></asp:XmlDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTdEnun"><asp:Label ID="lbl_reporte_parametro" runat="server" Text="Parámetros" SkinID="lblEnun"></asp:Label></td>
                                            <td class="formTdDato">
                                                <asp:DropDownList ID="ddl_reporte_parametro" runat="server" AutoPostBack="true" DataSourceID="xds_lista_reporte_parametro" DataValueField="codigo" DataTextField="nombre"></asp:DropDownList>
                                                <asp:XmlDataSource ID="xds_lista_reporte_parametro" runat="server" DataFile="~/App_Data/reportesAuditoria.xml" XPath="/reportes/reporte[@parametro='true']"></asp:XmlDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                </td></tr></table>
                            </td>
                        </tr>
                        <tr><td><uc3:reporteAuditoriaFiltro ID="raf1" runat="server" /></td></tr>
                        <tr>
                            <td class="formEntTdButton">
                                <asp:ButtonAction ID="btn_mostrar_reporte" runat="server" Text="Mostrar reporte" TextoEnviando="Generando reporte" CausesValidation="true"/>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>            
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="panel_report_view" runat="server">
                    <uc2:reporte ID="Reporte1" runat="server" />
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>