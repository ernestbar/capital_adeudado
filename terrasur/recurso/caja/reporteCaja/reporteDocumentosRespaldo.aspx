<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte de documentos de Caja (Respaldo)" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteCaja", "reporteDocumentosRespaldo") Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_mostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        If VerificarFechas() Then
            Dim Nit_razon_social As String = ""
            Dim Id_sucursal As Integer = 0
            If rbl_tipo_documento.SelectedValue = "factura" Then
                Nit_razon_social = rbl_razon_sucursal.SelectedValue.Split(",")(0)
                Id_sucursal = Integer.Parse(rbl_razon_sucursal.SelectedValue.Split(",")(1))
            Else
                Id_sucursal = Integer.Parse(ddl_sucursal.SelectedValue)
            End If
            
            Dim tabla As Data.DataTable = transaccionReporte.ReporteRespaldo(cp_fecha_inicio.SelectedDate, cp_fecha_final.SelectedDate, _
                Integer.Parse(rbl_trans_vigentes.SelectedValue), Integer.Parse(rbl_con_factura.SelectedValue), _
                Integer.Parse(ddl_negocio.SelectedValue), Integer.Parse(ddl_usuario.SelectedValue), _
                Nit_razon_social, Id_sucursal)
        
            Dim tabla_docs As Data.DataTable = Tabla_documentos(rbl_tipo_documento.SelectedValue, tabla)
            If tabla_docs.Rows.Count > 0 Then
                If rbl_tipo_documento.SelectedValue = "factura" Then
                    Dim reporte As New cajaTransaccionFactura
                    reporte.DataSource = tabla_docs
                    Reporte1.WebView.Report = reporte
                ElseIf rbl_tipo_documento.SelectedValue = "recibo" Then
                    Dim reporte As New cajaTransaccionRecibo
                    reporte.DataSource = tabla_docs
                    Reporte1.WebView.Report = reporte
                ElseIf rbl_tipo_documento.SelectedValue = "comprobante" Then
                    Dim reporte As New cajaTransaccionComprobante
                    reporte.DataSource = tabla_docs
                    Reporte1.WebView.Report = reporte
                End If
            Else
                Msg1.Text = "Sin datos, los criterios de búsqueda no dieron resultados"
            End If
        End If
    End Sub

    Protected Function Tabla_documentos(ByVal tipo_documento As String, ByVal tabla As Data.DataTable) As Data.DataTable
        Dim nombre_id As String = ""
        If tipo_documento = "factura" Then
            nombre_id = "id_factura"
        ElseIf tipo_documento = "recibo" Then
            nombre_id = "id_recibo"
        ElseIf tipo_documento = "comprobante" Then
            nombre_id = "id_comprobantedpr"
        End If
        For i As Integer = tabla.Rows.Count - 1 To 0 Step -1
            If Integer.Parse(tabla.Rows(i)(nombre_id)) = 0 Then
                tabla.Rows.RemoveAt(i)
            End If
        Next
        Return tabla
    End Function
    
    
    Protected Function VerificarFechas() As Boolean
        Dim num_dias As Integer = 0
        Dim inicio As DateTime = cp_fecha_inicio.SelectedDate.Date
        Dim fin As DateTime = cp_fecha_final.SelectedDate.Date
        While inicio <= fin
            num_dias = num_dias + 1
            inicio = inicio.AddDays(1)
        End While
       
        Dim num_dias_limite As Integer = 31
        
        Dim correcto As Boolean = True
        If num_dias > 0 Then
            If num_dias > num_dias_limite Then
                Msg1.Text = "El rango de fechas contempla " & num_dias.ToString & " días, seleccione un rango de " & num_dias_limite.ToString & " días como máximo, por razones de performance"
                correcto = False
            End If
        Else
            Msg1.Text = "Rango incorrecto"
            correcto = False
        End If
        
        Return correcto
    End Function
    
    Protected Sub ddl_negocio_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        ddl_negocio.Items.Insert(0, New ListItem("Todos", "0"))
    End Sub

    Protected Sub ddl_usuario_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        ddl_usuario.Items.Insert(0, New ListItem("Todos", "0"))
    End Sub
   

    Protected Sub rbl_tipo_documento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_tipo_documento.SelectedIndexChanged
        If rbl_tipo_documento.SelectedValue = "factura" Then
            lbl_razon_sucursal_enun.Text = "Facturas emitidas en:"
            rbl_razon_sucursal.Visible = True
            ddl_sucursal.Visible = False
        Else
            lbl_razon_sucursal_enun.Text = "Sucursal:"
            rbl_razon_sucursal.Visible = False
            ddl_sucursal.Visible = True
        End If
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteCaja" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
    <tr>
        <td class="priTdTitle">Reporte de documentos de Caja (Respaldo)</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido">
                <tr>
                    <td class="formEntTdForm">
                        <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="formTdEnun">Fecha:</td>
                                <td class="formTdDato">
                                    <ew:CalendarPopup ID="cp_fecha_inicio" runat="server"></ew:CalendarPopup>
                                    -
                                    <ew:CalendarPopup ID="cp_fecha_final" runat="server"></ew:CalendarPopup>
                                </td>
                            </tr>
                            <tr><td colspan="2"><hr /> </td></tr>
                            <tr>
                                <td class="formTdEnun">Tipo de documento:</td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_tipo_documento" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                                        <asp:ListItem Text="Factura" Value="factura" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Recibo" Value="recibo"></asp:ListItem>
                                        <asp:ListItem Text="Comprobante DPR" Value="comprobante"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun"><asp:Label ID="lbl_razon_sucursal_enun" runat="server" Text="Facturas emitidas en:"></asp:Label></td>
                                <td class="formTdDato">
                                    <asp:DropDownList ID="rbl_razon_sucursal" runat="server">
                                        <asp:ListItem Text="BBR S.A. - Oficina Central" Value="153900023,1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="BBR S.A. - Miraflores" Value="153900023,2"></asp:ListItem>
                                        <asp:ListItem Text="Terrasur Ltda. - Oficina Central" Value="1017305028,1"></asp:ListItem>
                                        <asp:ListItem Text="Terrasur Ltda. - Miraflores" Value="1017305028,2"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddl_sucursal" runat="server" Visible="false">
                                        <asp:ListItem Text="Oficina Central" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Miraflores" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr><td colspan="2"><hr /> </td></tr>
                            <tr>
                                <td class="formTdEnun">Transacciones:</td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_trans_vigentes" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                                        <asp:ListItem Text="Todas" Value="-1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Vigentes" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Anuladas" Value="0"></asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RadioButtonList ID="rbl_con_factura" runat="server" Visible="false" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                                        <asp:ListItem Text="Todas" Value="-1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Con factura" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Sin factura" Value="0"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <%--<tr>
                                <td class="formTdEnun"></td>
                                <td class="formTdDato">
                                </td>
                            </tr>--%>
                            <tr>
                                <td class="formTdEnun">Negocio:</td>
                                <td class="formTdDato">
                                    <asp:DropDownList ID="ddl_negocio" runat="server" DataSourceID="ods_negocio_lista" DataTextField="nombre" DataValueField="id_negocio" OnDataBound="ddl_negocio_DataBound">
                                    </asp:DropDownList>
                                    <%--[id_negocio],[nombre]--%>
                                    <asp:ObjectDataSource ID="ods_negocio_lista" runat="server" TypeName="terrasur.negocio" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Usuario:</td>
                                <td class="formTdDato">
                                    <asp:DropDownList ID="ddl_usuario" runat="server" DataSourceID="ods_lista_usuario" DataValueField="id_usuario" DataTextField="nombre" OnDataBound="ddl_usuario_DataBound">
                                    </asp:DropDownList>
                                    <%--[id_usuario],[nombre]--%>
                                    <asp:ObjectDataSource ID="ods_lista_usuario" runat="server" TypeName="terrasur.transaccionReporte" SelectMethod="ListaUsuariosTransaccion">
                                        <SelectParameters>
                                            <asp:Parameter Name="Con_inactivos" Type="Boolean" DefaultValue="False" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formEntTdButton" colspan="2">
                                   <asp:ButtonAction ID="btn_mostrar" runat="server"  SkinID="btnAccion" Text="Mostrar reporte"/>
                                </td>
                            </tr>

                            <%--<tr><td colspan="2"><hr /> </td></tr>
                            <tr>
                                <td class="formTdEnun">NIT:</td>
                                <td class="formTdDato">
                                    <asp:DropDownList ID="ddl_razon_social" runat="server">
                                        <asp:ListItem Text="Todos" Value=""></asp:ListItem>
                                        <asp:ListItem Text="BBR S.A." Value="153900023"></asp:ListItem>
                                        <asp:ListItem Text="TERRASUR LTDA" Value="1017305028"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Sucursal:</td>
                                <td class="formTdDato">
                                    <asp:DropDownList ID="ddl_sucursal" runat="server" DataSourceID="ods_lista_sucursal" DataValueField="id_sucursal" DataTextField="nombre" OnDataBound="ddl_sucursal_DataBound">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ods_lista_sucursal" runat="server" TypeName="terrasur.sucursal" SelectMethod="ListaParaDDL">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            --%>
                         </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                    </td>
                </tr>
                <tr>
                    <td class="tdGrid">
                        <uc1:reporte ID="Reporte1" runat="server" Formato_Excel="false" Formato_Word="false" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

