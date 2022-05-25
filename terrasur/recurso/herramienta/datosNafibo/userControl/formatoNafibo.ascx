<%@ Control Language="VB" ClassName="formatoNafibo" %>
<%@ Import Namespace="System.Data" %>

<script runat="server">
    Public Sub Reset()
        txt_contratos.Text = ""
        cp_fecha.SelectedDate = DateTime.Now.Date
        txt_contratos.Focus()
    End Sub

    Protected Sub btn_generar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim codigo_moneda As String
        Dim mObj As New moneda(Integer.Parse(rbl_moneda.SelectedValue))
        If mObj.codigo = "$us" Then
            codigo_moneda = "sus"
        Else
            codigo_moneda = "bs"
        End If

        Dim tabla As DataTable = nafibo_formato.FormatoNafibo(txt_contratos.Text.Trim, cp_fecha.SelectedDate, Integer.Parse(rbl_moneda.SelectedValue))
        ExportarExcel(tabla, "FormatoNafibo_" + codigo_moneda + "_" + cp_fecha.SelectedDate.ToString("d").Replace("/", "_"), rbl_formato.SelectedValue.Equals("excel"))
    End Sub
    
    Protected Sub ExportarExcel(ByVal tabla As Data.DataTable, ByVal nombre As String, ByVal excel As Boolean)
        If excel = True Then
            Response.Clear()
            For Each columna As DataColumn In tabla.Columns
                Response.Write(columna.ColumnName + ";")
            Next
            Response.Write(Environment.NewLine)
            For Each fila As DataRow In tabla.Rows
                For i As Integer = 0 To tabla.Columns.Count - 1
                    Response.Write(fila(i).ToString().Replace(";", String.Empty) + ";")
                Next
                Response.Write(Environment.NewLine)
            Next
            Response.ContentType = "text/csv"
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + nombre + ".csv")
            Response.End()
        Else
            Response.Clear()
            
            For fi As Integer = 0 To tabla.Rows.Count - 1
                For co As Integer = 0 To tabla.Columns.Count - 1
                    If tabla.Columns(co).DataType Is System.Type.GetType("System.Decimal") Then
                        Response.Write((Convert.ToDecimal(tabla.Rows(fi)(co))).ToString("F2").Replace(",", "."))
                    Else
                        Response.Write(tabla.Rows(fi)(co).ToString())
                    End If
                    If co + 1 < tabla.Columns.Count Then
                        Response.Write(",")
                    End If
                Next
                If fi + 1 < tabla.Rows.Count Then
                    Response.Write(Environment.NewLine)
                End If
            Next
            Response.ContentType = "text/plain"
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + nombre + ".txt")
            Response.End()
        End If
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
            <asp:ValidationSummary ID="vs_formato" runat="server" DisplayMode="List" ValidationGroup="formato" />
        </td>
    </tr>
    <%--<tr><td class="formTdTitle" colspan="2"><asp:Label ID="lbl_title" runat="server" Text="Datos del recibo"></asp:Label></td></tr>--%>
    <tr>
        <td class="formTdEnun">Fecha de evaluación:</td>
        <td class="formTdDato">
            <ew:CalendarPopup ID="cp_fecha" runat="server">
            </ew:CalendarPopup>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Contratos:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_contratos" runat="server" Width="300"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_contratos" runat="server" ControlToValidate="txt_contratos" Display="Dynamic" ValidationGroup="formato" Text="*" ErrorMessage="Debe introducir los números de contrato"></asp:RequiredFieldValidator>
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
        <td class="formTdEnun">Formato de los datos:</td>
        <td class="formTdDato">
            <asp:RadioButtonList ID="rbl_formato" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                <asp:ListItem Text="Excel (.csv)" Value="excel" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Texto (.txt)" Value="txt"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="btn_generar" runat="server" Text="Obtener datos" CausesValidation="true" ValidationGroup="formato" OnClick="btn_generar_Click" />
        </td>
    </tr>
</table>