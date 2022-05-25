<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Edición de datos del usuario" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/usuario/usuarioTodos/userControl/usuarioDatos.ascx" TagName="usuarioDatos" TagPrefix="uc2" %>

<script runat="server">

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs)
        'general.CambiarMasterPage(Me, True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            txt_password.Focus()
        End If
    End Sub

    Protected Sub btn_ingresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ingresar.Click
        Dim usr As New usuario(Profile.id_usuario)
        If usr.password = txt_password.Text.Trim Then
            UsuarioDatos1.CargarActualizar(0, Profile.id_usuario)
            MultiView1.ActiveViewIndex = 1
        Else
            Msg1.Text = "Contraseña incorrecta"
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If UsuarioDatos1.VerificarActualizar Then
            Dim usr_aux As String = usuario.ObtenerNombreUsuarioPorId(Profile.id_usuario)
            If UsuarioDatos1.Actualizar Then
                If usuario.ObtenerNombreUsuarioPorId(Profile.id_usuario) <> usr_aux Then
                    CargarPerfilUsuario(Profile.id_usuario, True)
                    FormsAuthentication.SignOut()
                    'FormsAuthentication.RedirectToLoginPage()
                    Response.Redirect("~/Default.aspx")
                Else
                    CargarPerfilUsuario(Profile.id_usuario, False)
                End If
            End If
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar1.Click, btn_cancelar2.Click
        Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
    End Sub

    Public Sub CargarPerfilUsuario(ByVal Id_usuario As Integer, ByVal Actualizar_menu As Boolean)
        Dim usr As New usuario(Id_usuario)
        Dim pc As ProfileCommon = Profile.GetProfile(usr.nombre_usuario)
        pc.id_usuario = usr.id_usuario
        pc.nombre_usuario = usr.nombre_usuario
        pc.nombre_persona = usr.paterno & " " & usr.materno & " " & usr.nombres
        pc.imagen = usuario.ImagenDireccion(usr.imagen)
        If Actualizar_menu Then
            Dim tabla_roles As Data.DataTable = rol.ListaPorUsuario(Id_usuario)
            For Each fila As Data.DataRow In tabla_roles.Rows
                Dim codigo_modulo As String = fila("modulo_codigo").ToString.Trim
                If codigo_modulo <> "" Then
                    Try
                        pc.SetPropertyValue("menu_modulos." & codigo_modulo, general.MenuStringEliminados(Id_usuario, Integer.Parse(fila("id_rol").ToString)))
                    Catch ex As Exception
                    End Try
                End If
            Next
        End If
        pc.Save()
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <%--<uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="r9" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="priTable">
        <tr><td class="priTdTitle">Actualización de datos personales</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <asp:Panel ID="panel_ingresar" runat="server" DefaultButton="btn_ingresar">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                    <asp:ValidationSummary ID="vs_usuario" runat="server" DisplayMode="List" ValidationGroup="ingreso" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formEntTdForm">
                                    <table class="formTable" align="center">
                                        <tr>
                                            <td class="formTdEnun">
                                                <asp:Label ID="lbl_password" runat="server" Text="Introduzca su contraseña:"></asp:Label>
                                            </td>
                                            <td class="formTdDato">
                                                <asp:RequiredFieldValidator ID="rfv_password" runat="server" ControlToValidate="txt_password" Display="Dynamic" SetFocusOnError="true" ValidationGroup="ingreso" Text="*" ErrorMessage="Debe introducir la contraseña"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="rev_password" runat="server" ControlToValidate="txt_password" Display="Dynamic" SetFocusOnError="true" ValidationGroup="ingreso" ValidationExpression="<%$ AppSettings:usuario_ExpReg_password %>" Text="*" ErrorMessage="La contraseña contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                                                <asp:TextBox ID="txt_password" runat="server" TextMode="Password" MaxLength="25"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formEntTdButton" colspan="2">
                                                <asp:ButtonAction ID="btn_ingresar" runat="server" Text="Ingresar a actualizar datos" TextoEnviando="Ingresando" CausesValidation="true" ValidationGroup="ingreso" />
                                                <asp:Button ID="btn_cancelar1" runat="server" Text="Cancelar/Volver" CausesValidation="false" SkinID="btnAccion" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <asp:Panel ID="panel_cambiar" runat="server" DefaultButton="btn_actualizar">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_cambio_enun" runat="server" Text="Datos personales"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm"><uc2:usuarioDatos ID="UsuarioDatos1" runat="server" /></td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="Guardar cambios" TextoEnviando="Guardando cambios" CausesValidation="true" ValidationGroup="usuario" />
                                    <%--<asp:Button ID="btn_actualizar" runat="server" Text="Guardar cambios" CausesValidation="true" ValidationGroup="usuario" SkinID="btnAccion" />--%>
                                    <asp:Button ID="btn_cancelar2" runat="server" Text="Cancelar/Volver" CausesValidation="false" SkinID="btnAccion" />
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>

