<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte de recibos de cobrador" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteCobranza", "reporteReciboCobrador") Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
      
    Public Sub cargarReporte()
        If (txt_desde.Text <> "") And (txt_hasta.Text <> "") Then
            Dim reporte As New rpt_recibo_cobrador()
            reporte.Encabezado(Int32.Parse(txt_desde.Text.Trim()), Int32.Parse(txt_hasta.Text.Trim()), Int32.Parse(rbl_estado.SelectedValue))
            reporte.DataSource = cobranzaReporte.ReporteReciboCobrador(Int32.Parse(txt_desde.Text.Trim()), Int32.Parse(txt_hasta.Text.Trim()), Int32.Parse(rbl_estado.SelectedValue))
            Reporte1.WebView.Report = reporte
        End If
    End Sub
        
    
    Protected Sub btn_mostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        cargarReporte()
    End Sub

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteCobranza" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:ScriptManager runat="server">
    </asp:ScriptManager>
<table class="priTable">
    <tr>
        <td class="priTdTitle">Reporte de recibos de cobrador</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido">
                <tr>
                    <td class="tdButtonVolver">
                      <asp:ValidationSummary ID="vs_recibo" runat="server" DisplayMode="List" ValidationGroup="recibo" />
                    </td>
                </tr>
                <tr>
                    <td class="tdFiltro">
                        <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="formTdEnun">
                                    <asp:Label ID="lbl_recibos" runat="server" Text="No. de recibos:"></asp:Label></td>
                                <td class="formTdDato">
                                    <asp:TextBox ID="txt_desde" runat="server" SkinID="txtSingleLine50" ></asp:TextBox>-
                                    <asp:RequiredFieldValidator ID="rfv_desde" runat="server" ControlToValidate="txt_desde" Display="Dynamic" SetFocusOnError="true" ValidationGroup="recibo" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="rav_desde" runat="server" Type="Integer"  MinimumValue="0" MaximumValue="99999999" ControlToValidate="txt_desde"  Display="Dynamic" ValidationGroup="recibo" SetFocusOnError="true" Text="*" ErrorMessage="El valor inicial del número de recibo contiene caracteres inválidos"></asp:RangeValidator>
                                    <asp:TextBox ID="txt_hasta" runat="server" SkinID="txtSingleLine50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_hasta" runat="server" ControlToValidate="txt_hasta" Display="Dynamic" SetFocusOnError="true" ValidationGroup="recibo" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="eav_hasta" runat="server" Type="Integer"  MinimumValue="0" MaximumValue="99999999" ControlToValidate="txt_hasta"  Display="Dynamic" ValidationGroup="recibo" SetFocusOnError="true" Text="*" ErrorMessage="El valor final del número de recibo contiene caracteres inválidos"></asp:RangeValidator>   
                                </td>
                            </tr>
                           <tr>
                                <td class="formTdEnun">
                                    <asp:Label ID="lbl_estado_enun" runat="server" Text="Estado:"></asp:Label></td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_estado" runat="server" AutoPostBack="false" RepeatDirection="Horizontal" CausesValidation="true"  ValidationGroup="recibo">
                                        <asp:ListItem Value="0" Selected="True" >Todos</asp:ListItem>
                                        <asp:ListItem Value="1">Activos</asp:ListItem>
                                        <asp:ListItem Value="2">Desactivados</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formEntTdButton" colspan="2">
                                   <asp:Button ID="btn_mostrar" runat="server" SkinID="btnAccion" Text="Mostrar reporte" CausesValidation="true" ValidationGroup="recibo"/>
                                </td>
                            </tr>
                         </table>
                    </td>
                </tr>
                <tr>
                    <td class="tdGrid">
                    <uc1:reporte ID="Reporte1" runat="server" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

