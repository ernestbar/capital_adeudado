<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte de debitos aceptados" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<script runat="server">
    Protected ReadOnly Property tipo_fecha() As Integer
        Get
            If cp_inicio.SelectedValue.HasValue = False AndAlso cp_fin.SelectedValue.HasValue = False Then
                Return 0
            ElseIf cp_inicio.SelectedValue.HasValue = True AndAlso cp_fin.SelectedValue.HasValue = False Then
                Return 1
            ElseIf cp_inicio.SelectedValue.HasValue = False AndAlso cp_fin.SelectedValue.HasValue = True Then
                Return 2
            ElseIf cp_inicio.SelectedValue.HasValue = True AndAlso cp_fin.SelectedValue.HasValue = True Then
                Return 3
            End If
        End Get
    End Property

    Protected ReadOnly Property fecha_inicio() As DateTime
        Get
            If cp_inicio.SelectedValue.HasValue = True Then
                Return cp_inicio.SelectedDate
            Else
                Return DateTime.Now
            End If
        End Get
    End Property

    Protected ReadOnly Property fecha_fin() As DateTime
        Get
            If cp_fin.SelectedValue.HasValue = True Then
                Return cp_fin.SelectedDate
            Else
                Return DateTime.Now
            End If
        End Get
    End Property
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "grupoTransaccion", "reporteDebitosAceptados") = True Then
                btn_volver.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "grupoTransaccion", "view")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_mostrar_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar_reporte.Click
        Dim repObj As New rpt_debitos_aceptados()
        repObj.DataSource = tarjeta_credito_transaccion.ListaAceptados(Integer.Parse(ddl_grupo_transaccion.SelectedValue), tipo_fecha, fecha_inicio, fecha_fin)
        repObj.CargarDatos(ddl_grupo_transaccion.SelectedItem.Text, tipo_fecha, fecha_inicio, fecha_fin)
        Reporte1.WebView.Report = repObj
    End Sub

    Protected Sub ddl_grupo_transaccion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_grupo_transaccion.DataBound
        ddl_grupo_transaccion.Items.Insert(0, New ListItem("Todos", "0"))
    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        Response.Redirect("~/recurso/contabilidad/debitoatc/grupoTransaccion.aspx")
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="grupoTransaccion" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:Label ID="lbl_id_grupotransaccion" runat="server" Text="0" Visible="false"></asp:Label>
    <table class="viewEntTable">
        <tr>
            <td class="viewEntTd">
                <table class="viewTable" align="center">
                    <tr><td class="priTdTitle">Reporte de debitos aceptados</td></tr>
                    <tr><td align="right"><asp:Button ID="btn_volver" runat="server" Text="Volver a debito automático" SkinID="btnVolver"/></td></tr>
                    <tr>
                        <td class="formEntTdForm">
                            <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="formTdEnun">Grupo de transacciones:</td>
                                    <td class="formTdDato">
                                        <asp:DropDownList ID="ddl_grupo_transaccion" runat="server" DataSourceID="ods_lista_grupo_transaccion" DataTextField="numero" DataValueField="id_grupotransaccion">
                                        </asp:DropDownList>
                                        <%--[id_grupotransaccion],[numero]--%>
                                        <asp:ObjectDataSource ID="ods_lista_grupo_transaccion" runat="server" TypeName="terrasur.grupo_transaccion" SelectMethod="ListaSimple">
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formTdEnun">Fecha de debito:</td>
                                    <td class="formTdDato">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td><ew:CalendarPopup ID="cp_inicio" runat="server" Nullable="true"></ew:CalendarPopup></td>
                                                <td>-</td>
                                                <td><ew:CalendarPopup ID="cp_fin" runat="server" Nullable="true"></ew:CalendarPopup></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="formEntTdButton">
                            <asp:Button ID="btn_mostrar_reporte" runat="server" SkinID="btnAccion" Text="Mostrar reporte" CausesValidation="true"/>
                        </td>
                    </tr>
                    <tr><td><uc2:reporte ID="Reporte1" runat="server" /></td></tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

