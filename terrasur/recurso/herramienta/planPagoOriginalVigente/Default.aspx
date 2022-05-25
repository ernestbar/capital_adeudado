<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Planes de pago Originales y Vigentes" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "planPagoOriginalVigente", "exportar") Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_mostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        cargarReporte()
    End Sub

    Public Sub cargarReporte()
        Dim codigo_moneda As String
        Dim mObj As New moneda(Integer.Parse(rbl_moneda.SelectedValue))
        If mObj.codigo = "$us" Then
            codigo_moneda = "DOLARES"
        Else
            codigo_moneda = "BOLIVIANOS"
        End If
        
        Dim num_contrato As String = txt_contratos.Text.Trim
        If num_contrato <> "" Then
            num_contrato = "," & num_contrato.TrimStart(",").TrimEnd(",") & ","
        End If
        
        Dim sb As StringBuilder = contratoReporte.ReportePlanPagosOriginalesVigentes(cp_fecha.SelectedDate, Boolean.Parse(rbl_tipo.SelectedValue), num_contrato, Integer.Parse(rbl_moneda.SelectedValue))
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "text/plain"
        If Boolean.Parse(rbl_tipo.SelectedValue) = True Then
            Response.AddHeader("Content-Disposition", "attachment;filename=PlanesOriginales_" & codigo_moneda & "_" & cp_fecha.SelectedDate.ToString("ddMMyyyy") & ".txt")
        Else
            Response.AddHeader("Content-Disposition", "attachment;filename=PlanesVigentes_" & codigo_moneda & "_" & cp_fecha.SelectedDate.ToString("ddMMyyyy") & ".txt")
        End If
        Response.Charset = "UTF-8"
        Response.ContentEncoding = Encoding.Default
        Response.Write(sb.ToString().TrimEnd(";").Replace(";", vbNewLine))
        Response.End()
    End Sub

    Protected Sub rbl_moneda_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_moneda.DataBound
        If rbl_moneda.Items.Count > 0 Then
            rbl_moneda.SelectedIndex = 0
        End If
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
     <uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteHerramienta" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
    <tr>
        <td class="priTdTitle">Planes de pago Originales y Vigentes</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido">
                <tr>
                    <td class="tdFiltro">
                        <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="formTdEnun"><asp:Label ID="lbl_fecha" runat="server" Text="Planes de pago al:"></asp:Label></td>
                                <td class="formTdDato">
                                    <ew:CalendarPopup ID="cp_fecha" runat="server" AutoPostBack="false" >
                                    </ew:CalendarPopup>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Contratos:</td>
                                <td class="formTdDato">
                                    <asp:TextBox ID="txt_contratos" runat="server" Width="300"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Moneda:</td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_moneda" runat="server" DataSourceID="ods_lista_moneda" DataValueField="id_moneda" DataTextField="nombre_completo" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                    <%--[id_moneda],[codigo],[nombre],[nombre_completo]--%>
                                    <asp:ObjectDataSource ID="ods_lista_moneda" runat="server" TypeName="terrasur.moneda" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun"><asp:Label ID="lbl_tipo_enun" runat="server" Text="Tipo de plan:"></asp:Label></td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_tipo" runat="server">
                                        <asp:ListItem Text="Todos los planes de pago originales" Value="true" Selected="True" />
                                        <asp:ListItem Text="Todos los planes de pago vigentes" Value="false" />
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formEntTdButton" colspan="2">
                                   <asp:Button ID="btn_mostrar" runat="server" SkinID="btnAccion" Text="Exportar datos a un archivo de texto"/>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

