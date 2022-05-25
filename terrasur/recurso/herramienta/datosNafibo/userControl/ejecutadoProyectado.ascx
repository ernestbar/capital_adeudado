<%@ Control Language="VB" ClassName="ejecutadoProyectado" %>
<%@ Import Namespace="System.Data" %>
<script runat="server">
    Public Sub Reset()
        rbl_tipo_reporte.SelectedValue = "ejecutado"
        btn_ejecutado.Visible = True
        btn_proyectado.Visible = False

        MostrarBotonGuardarAjuste()
        
        If ddl_anio.Items.Count = 0 Then
            ddl_anio.DataBind()
        End If
        ddl_anio.SelectedValue = DateTime.Now.Year
        ddl_mes.DataBind()
        ddl_mes.SelectedValue = DateTime.Now.Month
        
        rbl_capitainteres.SelectedValue = "True"
        rbl_formato.SelectedValue = "True"
        cb_ajuste.Checked = True
    End Sub
    
    Protected Sub rbl_tipo_reporte_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_tipo_reporte.SelectedIndexChanged
        MostrarBotonGuardarAjuste()
        If rbl_tipo_reporte.SelectedValue = "ejecutado" Then
            btn_ejecutado.Visible = True
            btn_proyectado.Visible = False
        Else
            btn_ejecutado.Visible = False
            btn_proyectado.Visible = True
        End If
    End Sub
    Protected Sub MostrarBotonGuardarAjuste()
        If rbl_tipo_reporte.SelectedValue = "ejecutado" Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "datosNafibo", "guardar_ajuste_ejecutado") Then
                'Dim fecha_elegida As DateTime = DateTime.Parse("01/" & ddl_mes.SelectedValue.ToString & "/" & ddl_anio.SelectedValue)
                'fecha_elegida = fecha_elegida.AddMonths(1).AddSeconds(-1)
                'Dim fecha_actual As DateTime = DateTime.Now
                'If fecha_elegida.AddDays(-3) < fecha_actual And fecha_actual < fecha_elegida.AddDays(2) Then
                '    btn_guardar_ajuste.Visible = True
                'Else
                '    btn_guardar_ajuste.Visible = False
                'End If
                btn_guardar_ajuste.Visible = True
            Else
                btn_guardar_ajuste.Visible = False
            End If
        Else
            btn_guardar_ajuste.Visible = False
        End If
    End Sub
    
    Protected Sub btn_ejecutado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ejecutado.Click
        Dim codigo_moneda As String
        Dim mObj As New moneda(Integer.Parse(rbl_moneda.SelectedValue))
        If mObj.codigo = "$us" Then
            codigo_moneda = "sus"
        Else
            codigo_moneda = "bs"
        End If
        Dim Fecha_inicio As DateTime, Fecha_fin As DateTime
        ObtenerFechasInicioFinMes(ddl_mes.SelectedValue, ddl_anio.SelectedValue, Fecha_inicio, Fecha_fin)
        Dim tabla As DataTable = nafibo_ejecutado.TablaEjecutado(Fecha_inicio, Fecha_fin, cb_ajuste.Checked, Boolean.Parse(rbl_capitainteres.SelectedValue), Boolean.Parse(rbl_formato.SelectedValue), Integer.Parse(rbl_moneda.SelectedValue))
        ExportarDatos(tabla, rbl_tipo_reporte.SelectedItem.Text, Fecha_inicio, cb_ajuste.Checked, Boolean.Parse(rbl_capitainteres.SelectedValue), Boolean.Parse(rbl_formato.SelectedValue), codigo_moneda)
    End Sub

    Protected Sub btn_proyectado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_proyectado.Click
        Dim codigo_moneda As String
        Dim mObj As New moneda(Integer.Parse(rbl_moneda.SelectedValue))
        If mObj.codigo = "$us" Then
            codigo_moneda = "sus"
        Else
            codigo_moneda = "bs"
        End If
        Dim Fecha_inicio As DateTime, Fecha_fin As DateTime
        ObtenerFechasInicioFinMes(ddl_mes.SelectedValue, ddl_anio.SelectedValue, Fecha_inicio, Fecha_fin)
        Dim Fecha_emision_proyectado As DateTime = Fecha_inicio.AddDays(-1)
        Dim tabla As DataTable = nafibo_proyectado.TablaProyectado(Fecha_emision_proyectado, cb_ajuste.Checked, Boolean.Parse(rbl_capitainteres.SelectedValue), Boolean.Parse(rbl_formato.SelectedValue), Integer.Parse(rbl_moneda.SelectedValue))
        ExportarDatos(tabla, rbl_tipo_reporte.SelectedItem.Text, Fecha_inicio, cb_ajuste.Checked, Boolean.Parse(rbl_capitainteres.SelectedValue), Boolean.Parse(rbl_formato.SelectedValue), codigo_moneda)
    End Sub

    Protected Sub btn_guardar_ajuste_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar_ajuste.Click
        Dim Fecha_inicio As DateTime, Fecha_fin As DateTime
        ObtenerFechasInicioFinMes(ddl_mes.SelectedValue, ddl_anio.SelectedValue, Fecha_inicio, Fecha_fin)

        If nafibo_ejecutado.GuardarAjustesNumCuotas(Fecha_inicio, Fecha_fin) = True Then
            Msg1.Text = "Los ajustes se guardaron correctamente"
        Else
            Msg1.Text = "Los ajustes NO se guardaron correctamente"
        End If
    End Sub
    

    
    Protected Sub ObtenerFechasInicioFinMes(ByVal Mes As String, ByVal Anio As String, ByRef Fecha_inicio As DateTime, ByRef Fecha_fin As DateTime)
        If Mes.Length < 2 Then
            Mes = "0" & Mes
        End If
        Fecha_inicio = DateTime.Parse("01/" + Mes + "/" + Anio)
        Fecha_fin = Fecha_inicio.AddMonths(1).AddDays(-1)
    End Sub
    
    Protected Sub ExportarDatos(ByVal tabla As DataTable, ByVal TipoReporte As String, ByVal Fecha As DateTime, ByVal Ajuste As Boolean, ByVal CapitalInteres As Boolean, ByVal Excel As Boolean, ByVal Codigo_moneda As String)
        Dim Nombre_archivo As String = "TERRASUR_" & TipoReporte & "_" & Codigo_moneda & "_" & nafibo_ejecutado.StringMes(Fecha.Month) & "_" & Fecha.Year.ToString
        If Excel = True Then
            If CapitalInteres = False Then
                Nombre_archivo = Nombre_archivo & "_MontoPagado"
            Else
                Nombre_archivo = Nombre_archivo & "_CapitalInteres"
            End If
            Nombre_archivo = "Formato_Excel_" & Nombre_archivo & ".csv"
        Else
            If CapitalInteres = False Then
                Nombre_archivo = Nombre_archivo & "_MontoPagado"
            End If
            Nombre_archivo = Nombre_archivo & ".txt"
        End If

        Response.Clear()
        If Excel = True Then
            For Each columna As DataColumn In tabla.Columns
                Response.Write(columna.ColumnName & ";")
            Next
            Response.Write(Environment.NewLine)
        End If
        For Each fila As DataRow In tabla.Rows
            For i As Integer = 0 To tabla.Columns.Count - 1
                If Excel = True Then
                    Response.Write(fila(i).ToString().Replace(";", String.Empty) + ";")
                Else
                    Response.Write(fila(i).ToString())
                    If i < tabla.Columns.Count - 1 Then
                        Response.Write(",")
                    End If
                End If
            Next
            Response.Write(Environment.NewLine)
        Next
        If Excel = True Then
            Response.ContentType = "text/csv"
        Else
            Response.ContentType = "text/plain"
        End If
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Nombre_archivo)
        Response.End()
    End Sub
 
    Protected Sub rbl_moneda_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_moneda.DataBound
        If rbl_moneda.Items.Count > 0 Then
            rbl_moneda.SelectedIndex = 0
        End If
    End Sub

</script>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <%--<tr><td class="formTdTitle" colspan="2"><asp:Label ID="lbl_title" runat="server" Text="Datos del recibo"></asp:Label></td></tr>--%>
    <tr>
        <td class="formTdEnun">Tipo de reporte:</td>
        <td class="formTdDato">
            <asp:RadioButtonList ID="rbl_tipo_reporte" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0" AutoPostBack="true">
                <asp:ListItem Text="Ejecutado" Value="ejecutado" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Proyectado" Value="proyectado"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Periodo:</td>
        <td class="formTdDato">
            <table cellpadding="0" cellspacing="0" align="left">
                <tr>
                    <td>
                        <asp:DropDownList ID="ddl_anio" runat="server" AutoPostBack="true" DataSourceID="ods_lista_anio" DataTextField="nombre" DataValueField="codigo"></asp:DropDownList>
                        <asp:ObjectDataSource ID="ods_lista_anio" runat="server" TypeName="terrasur.nafibo_ejecutado" SelectMethod="ListaAnio">
                        </asp:ObjectDataSource>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_mes" runat="server" AutoPostBack="true" DataSourceID="ods_lista_mes" DataTextField="nombre" DataValueField="codigo"></asp:DropDownList>
                        <asp:ObjectDataSource ID="ods_lista_mes" runat="server" TypeName="terrasur.nafibo_ejecutado" SelectMethod="ListaMes">
                            <SelectParameters>
                                <asp:ControlParameter Name="codigo_anio" Type="Int32" ControlID="ddl_anio" DefaultValue="SelectedValue" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                    <td>
                        <asp:Button ID="btn_guardar_ajuste" runat="server" Text="Guardar ajuste Nros. cuota" OnClientClick="return confirm('¿Esta Seguro que desea guardar los ajustes de números de cuota?');" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Moneda de los contratos:</td>
        <td class="formTdDato">
            <asp:RadioButtonList ID="rbl_moneda" runat="server" DataSourceID="ods_lista_moneda" DataValueField="id_moneda" DataTextField="nombre_completo" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
            </asp:RadioButtonList>
            <%--[id_moneda],[codigo],[nombre],[nombre_completo]--%>
            <asp:ObjectDataSource ID="ods_lista_moneda" runat="server" TypeName="terrasur.moneda" SelectMethod="Lista">
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Datos:</td>
        <td class="formTdDato">
            <asp:RadioButtonList ID="rbl_capitainteres" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                <asp:ListItem Text="Capital - Interés" Value="True" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Monto pagado" Value="False"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Formato:</td>
        <td class="formTdDato">
            <asp:RadioButtonList ID="rbl_formato" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                <asp:ListItem Text="Excel (.csv)" Value="True" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Texto (.txt)" Value="False"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Ajuste:</td>
        <td class="formTdDato">
            <asp:CheckBox ID="cb_ajuste" runat="server" Text="Realizar ajuste de Nros. de Cuota Nafibo" Checked="true" />
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="btn_ejecutado" runat="server" Text="Generar archivo Ejecutado" />
            <asp:Button ID="btn_proyectado" runat="server" Text="Generar archivo Proyectado" />
        </td>
    </tr>
</table>