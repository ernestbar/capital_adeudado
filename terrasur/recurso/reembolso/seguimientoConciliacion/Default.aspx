<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Seguimiento de Conciliaciones" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagPrefix="uc1" TagName="recursoMaster" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoConciliacion", "view") Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub gv_seguimiento_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_seguimiento.DataBound
        gv_seguimiento.Columns(0).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoConciliacion", "realizar")
        gv_seguimiento.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoConciliacion", "rechazar")
    End Sub

    Protected Sub gv_seguimiento_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_seguimiento.RowCommand
        Select Case e.CommandName
            Case "realizar"
                Dim Id_contrato As Integer = Integer.Parse(e.CommandArgument.ToString)
                If traspaso.contrato_conciliacion.VerificarActualizar(Id_contrato) Then
                    Dim contratoConciliacionObj As New traspaso.contrato_conciliacion(Id_contrato, 2)
                    If contratoConciliacionObj.Actualizar() Then
                        gv_seguimiento.DataBind()
                        Msg1.Text = "La conciliación se realizó correctamente"
                    Else
                        Msg1.Text = "La conciliación NO se realizó correctamente"
                    End If
                Else
                    Msg1.Text = "Solo se pueden realizar conciliaciones pendientes"
                End If
            Case "rechazar"
                Dim Id_contrato As Integer = Integer.Parse(e.CommandArgument.ToString)
                If traspaso.contrato_conciliacion.VerificarActualizar(Id_contrato) Then
                    Dim contratoConciliacionObj As New traspaso.contrato_conciliacion(Id_contrato, 3)
                    If contratoConciliacionObj.Actualizar() Then
                        gv_seguimiento.DataBind()
                        Msg1.Text = "La conciliación se rechazó correctamente"
                    Else
                        Msg1.Text = "La conciliación NO se rechazó correctamente"
                    End If
                Else
                    Msg1.Text = "Solo se pueden rechazar conciliaciones pendientes"
                End If
        End Select
    End Sub

    Private Function VerificarActualizar(Id_contrato As Boolean) As Boolean
        If traspaso.contrato_conciliacion.VerificarActualizar(Id_contrato) Then
            Return True
        Else
            Return False
        End If
    End Function

</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" runat="Server">
    <uc1:recursoMaster id="RecursoMaster1" runat="server" recurso="seguimientoConciliacion" mostrarlink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" runat="Server">
    <table class="priTable">
        <tr>
            <td class="priTdTitle">Seguimiento de Conciliaciones</td>
        </tr>
        <tr>
            <td class="priTdContenido">
                <table class="tableContenido" align="center">
                    <tr>
                        <td class="tdMsg">
                            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdGrid">
                            <asp:WizardGridView AllowPaging="True" PageSize="20" ID="gv_seguimiento" runat="server" AutoGenerateColumns="False" DataSourceID="ods_seguimiento_conciliacion_lista" DataKeyNames="id_contrato" EnableModelValidation="True" WizardCustomPager="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="Realizar">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btn_realizar" ImageUrl="~/images/verificar.gif" runat="server" SkinID="btnRealizar" CommandName="realizar" CommandArgument='<%# Eval("id_contrato") %>' OnClientClick="return confirm('¿Esta seguro de REALIZAR la conciliación?');" /></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rechazar">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btn_rechazar" ImageUrl="~/images/gv/delete.gif" runat="server" SkinID="btnRechazar" CommandName="rechazar" CommandArgument='<%# Eval("id_contrato") %>' OnClientClick="return confirm('¿Esta seguro de RECHAZAR la conciliación?');" /></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Número" DataField="num_contrato" />
                                    <asp:BoundField HeaderText="Fecha" DataField="fecha" />
                                    <asp:BoundField HeaderText="Estado" DataField="estado" />
                                </Columns>
                            </asp:WizardGridView>
                            <asp:ObjectDataSource ID="ods_seguimiento_conciliacion_lista" runat="server" TypeName="terrasur.traspaso.contrato_conciliacion" SelectMethod="Lista"></asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
