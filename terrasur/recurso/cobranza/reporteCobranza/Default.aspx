<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reportes de cobranzas" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            btn_pago_depositado.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteCobranza", "pago_depositado")
            btn_asignacion_recibo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteCobranza", "asignacion_recibo")
            btn_control_diario.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteCobranza", "control_diario")
            btn_clientes_zona.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteCobranza", "clientes_zona")
            btn_contratos_a_cobrar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteCobranza", "contratos_a_cobrar")
            btn_recibos_cobrador.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteCobranza", "recibos_cobrador")
            btn_contratos_asignados.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteCobranza", "contratos_asignados")
        End If
    End Sub
    
    Protected Sub btn_pago_depositado_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/cobranza/reporteCobranza/reportePorCobrador.aspx")
    End Sub

    Protected Sub btn_asignacion_recibo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/cobranza/reporteCobranza/reporteAsignacion.aspx")
    End Sub

    Protected Sub btn_clientes_zona_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/cobranza/reporteCobranza/reporteClienteZona.aspx")
    End Sub

    Protected Sub btn_contratos_a_cobrar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/cobranza/reportecobranza/reporteContratosCobradorCobrar.aspx")
    End Sub

    Protected Sub btn_contratos_asignados_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/cobranza/reporteCobranza/reporteAsignacionCobrador.aspx")
    End Sub

    Protected Sub btn_control_diario_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/cobranza/reporteCobranza/reporteControlDiario.aspx")
    End Sub

    Protected Sub btn_recibos_cobrador_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/cobranza/reportecobranza/reporteReciboCobrador.aspx")
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteCobranza" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
        <tr><td class="priTdTitle">Reportes de cobranzas</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdButtonVolver">
                                </td>
                            </tr>
                            <tr>
                                <td class="tdDropDown">
                                    <table class="tableDDL">
                                        <tr>
                                            <td class="tdDDLEnun"></td>
                                            <td><%--[Aquí viene el DropDownList]--%></td>
                                            <td class="tdDDLEspacio"></td><%--Es para insertar un espacio entre opciones (si es necesario)--%>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_pago_depositado" runat="server" Text="Pagos depositados por cobrador"
                                        OnClick="btn_pago_depositado_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_asignacion_recibo" runat="server" Text="Asignación de recibos oficiales a cobradores"
                                        OnClick="btn_asignacion_recibo_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_control_diario" runat="server" Text="Control diario de recibos oficiales por cobrador"
                                        OnClick="btn_control_diario_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_clientes_zona" runat="server" Text="Reporte de clientes por zonas"
                                        OnClick="btn_clientes_zona_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_contratos_a_cobrar" runat="server" Text="Reporte de contratos a cobrar por cobrador"
                                        OnClick="btn_contratos_a_cobrar_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_recibos_cobrador" runat="server" Text="Reporte de recibos por cobrador"
                                        OnClick="btn_recibos_cobrador_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_contratos_asignados" runat="server" Text="Reporte de contratos asignados por cobrador"
                                        OnClick="btn_contratos_asignados_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdBusqueda">
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>

