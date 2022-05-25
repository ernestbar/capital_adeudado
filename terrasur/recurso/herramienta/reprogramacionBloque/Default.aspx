<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reprogramaciones en bloque" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reprogramacionBloque", "view") Then
                btn_reprogramar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reprogramacionBloque", "reprogramar")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    Protected Sub btn_ver_reprogramacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ver_reprogramacion.Click
        Dim num_total As Integer = 0
        Dim num_reprog As Integer = 0
        gv_reprogramacion.DataSource = plan_pago.reprog_bloque_tabla_reprogramacion(txt_cadena_datos.Text, num_total, num_reprog)
        gv_reprogramacion.DataBind()
        panel_reprogramacion.Visible = True
        lbl_num_reprog.Text = "Nº de reprogramaciones: " & num_reprog & " de " & num_total
        panel_reporte.Visible = False
    End Sub

    Protected Sub btn_reprogramar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_reprogramar.Click
        Dim num_total As Integer = 0
        Dim num_reprog As Integer = 0
        Dim tabla As Data.DataTable = plan_pago.reprog_bloque_reprogramar(txt_cadena_datos.Text, Profile.id_usuario, num_total, num_reprog)

        panel_reporte.Visible = True
        Dim reporte As New rpt_reprogramacionBloque
        reporte.CargarDatos(DateTime.Now, num_total, num_reprog, Profile.nombre_usuario)
        reporte.DataSource = tabla
        Reporte1.WebView.Report = reporte
    End Sub

    Protected Sub gv_reprogramacion_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_reprogramacion.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Boolean.Parse(DataBinder.Eval(e.Row.DataItem, "reprogramar").ToString) = False Then
                e.Row.CssClass = "gvRowSelected"
            End If
        End If
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
     <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reprogramacionBloque" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
    <tr>
        <td class="priTdTitle">Reprogramaciones en bloque</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido">
                <tr>
                    <td class="tdFiltro">
                        <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center">
                                    <table cellpadding="0" cellspacing="0" align="center">
                                        <tr><td align="left"><asp:Label ID="lbl_formato" runat="server" SkinID="lblEnun" Text="Formato de los datos: Nºcontrato1:Nºcuotas1:Interés1:Fecha de inicio de plan1;Nºcontrato2..."></asp:Label></td></tr>
                                        <tr><td><asp:TextBox ID="txt_cadena_datos" runat="server" TextMode="MultiLine" Width="600" Height="50"></asp:TextBox></td></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:Button ID="btn_ver_reprogramacion" runat="server" Text="Ver reprogramaciones" />
                                    <asp:Button ID="btn_reprogramar" runat="server" Text="Reprogramar" OnClientClick="return confirm('¿Esta seguro que desea realizar las reprogramaciones?');" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table align="center">
                                        <tr>
                                            <td align="left">
                                                <asp:Panel ID="panel_reprogramacion" runat="server" GroupingText="Tabla de reprogramaciones" ScrollBars="Vertical" Height="200" Visible="false">
                                                    <asp:Label ID="lbl_num_reprog" runat="server" SkinID="lblEnun"></asp:Label>
                                                    <%--[num_contrato],[estado],[saldo],[reprogramar],
                                                    [id_contrato],[id_pago],[num_cuotas],[seguro],[mantenimiento_sus],
                                                    [interes_corriente],[interes_penal],[cuota_base],[fecha_inicio_plan],[fecha_proximo],
                                                    [o_num_cuotas],[o_interes_corriente],[o_fecha_inicio_plan],[o_cuota_base]--%>
                                                    <asp:GridView ID="gv_reprogramacion" runat="server" AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Nºcontrato" DataField="num_contrato" ItemStyle-CssClass="gvCell1" />
                                                            <asp:BoundField HeaderText="Moneda" DataField="codigo_moneda" />
                                                            <asp:BoundField HeaderText="Estado" DataField="estado" />
                                                            <asp:BoundField HeaderText="Saldo" DataField="saldo" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />

                                                            <asp:BoundField HeaderText="A.Nºcuotas" DataField="o_num_cuotas" ItemStyle-CssClass="gvCell1" />
                                                            <asp:BoundField HeaderText="A.Interés" DataField="o_interes_corriente" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                                            <asp:BoundField HeaderText="A.F.Ini.Plan" DataField="o_fecha_inicio_plan" HtmlEncode="false" DataFormatString="{0:d}" />
                                                            <asp:BoundField HeaderText="A.C.Base" DataField="o_cuota_base" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />

                                                            <asp:BoundField HeaderText="N.Nºcuotas" DataField="num_cuotas" ItemStyle-CssClass="gvCell1" />
                                                            <asp:BoundField HeaderText="N.Interés" DataField="interes_corriente" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                                            <asp:BoundField HeaderText="N.F.Ini.Plan" DataField="fecha_inicio_plan" HtmlEncode="false" DataFormatString="{0:d}" />
                                                            <asp:BoundField HeaderText="N.C.Base" DataField="cuota_base" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr><td><asp:Panel ID="panel_reporte" runat="server" Visible="false"><uc2:reporte ID="Reporte1" runat="server" /></asp:Panel></td></tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

