<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Function VerificarUrlModulo() As String
        If Request.QueryString("ReturnUrl").Contains("/modulo/adm") Then
            Return "adm"
        ElseIf Request.QueryString("ReturnUrl").Contains("/modulo/caja") Then
            Return "caja"
        ElseIf Request.QueryString("ReturnUrl").Contains("/modulo/cobranzas") Then
            Return "cobranzas"
        ElseIf Request.QueryString("ReturnUrl").Contains("/modulo/consultas") Then
            Return "consultas"
        ElseIf Request.QueryString("ReturnUrl").Contains("/modulo/finanzas") Then
            Return "finanzas"
        ElseIf Request.QueryString("ReturnUrl").Contains("/modulo/gerencia") Then
            Return "gerencia"
        ElseIf Request.QueryString("ReturnUrl").Contains("/modulo/marketing") Then
            Return "marketing"
        Else
            Return ""
        End If
    End Function
    
    Protected Sub Login1_LoggedIn(ByVal sender As Object, ByVal e As System.EventArgs) Handles Login1.LoggedIn
        Dim codigo_modulo As String = VerificarUrlModulo()
        If codigo_modulo <> "" Then
            CargarPerfilUsuario(Login1.UserName.Trim, codigo_modulo)
        Else
            Response.Redirect("~/Default.aspx")
        End If
    End Sub
    
    Public Sub CargarPerfilUsuario(ByVal Nombre_usuario As String, ByVal Codigo_modulo As String)
        Dim pc As ProfileCommon = Profile.GetProfile(Nombre_usuario)
        
        Dim Id_usuario As Integer = usuario.ObtenerIdPorNombreUsuario(Nombre_usuario)
        Dim Id_rol As Integer = modulo.Obtener_Rol_del_usuario_por_modulo(Id_usuario, Codigo_modulo)
        
        Dim m As New modulo(codigo_modulo)
        pc.entorno.id_modulo = m.id_modulo
        pc.entorno.codigo_modulo = m.codigo
        pc.entorno.nombre_modulo = m.nombre
        pc.entorno.id_rol = Id_rol

        If pc.nombre_usuario.Trim() = "" Then
            Dim usr As New usuario(usuario.ObtenerIdPorNombreUsuario(Nombre_usuario))
            pc.id_usuario = usr.id_usuario
            pc.nombre_usuario = usr.nombre_usuario
            pc.nombre_persona = usr.paterno & " " & usr.materno & " " & usr.nombres
            pc.imagen = usuario.ImagenDireccion(usr.imagen)
            
            Dim tabla_roles As Data.DataTable = rol.ListaPorUsuario(Id_usuario)
            For Each fila As Data.DataRow In tabla_roles.Rows
                Dim codigo_modulo_rol As String = fila("modulo_codigo").ToString.Trim
                If codigo_modulo_rol <> "" Then
                    Try
                        pc.SetPropertyValue("menu_modulos." & codigo_modulo_rol, general.MenuStringEliminados(Id_usuario, Integer.Parse(fila("id_rol").ToString)))
                    Catch ex As Exception
                    End Try
                End If
            Next
        End If
        pc.Save()
    End Sub

    Protected Sub Login1_LoggingIn(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs) Handles Login1.LoggingIn
        Dim codigo_modulo As String = VerificarUrlModulo()
        If codigo_modulo <> "" Then
            If modulo.Obtener_Rol_del_usuario_por_modulo(usuario.ObtenerIdPorNombreUsuario(Login1.UserName.Trim), codigo_modulo) = 0 Then
                e.Cancel = True
            End If
        Else
            e.Cancel = True
            Response.Redirect("~/Default.aspx")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            lbl_sistema.Text = "Sistema de manejo de cartera"
            hl_modulo.Text = "Sistema de manejo de cartera"
            CType(Login1.FindControl("UserName"), TextBox).Focus()
        End If
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ingreso al sistema</title>
    <link rel="shortcut icon" href="favicon.ico"/>
</head>
<body class="masterBody">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl" runat="server"></asp:Label>
        <table border="0" class="masterTable" cellpadding="0" cellspacing="0">
            <tr>
                <td class="masterTdEncab">
                    <table border="0" class="masterTableEncab" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="masterTdSisModRec">
                                <table border="0" class="masterTableSisModRec" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td rowspan="2" class="masterTdSis">
                                            <asp:Label ID="lbl_sistema" runat="server"></asp:Label>
                                        </td>
                                        <td class="masterTdMod">
                                            &nbsp;&nbsp;
                                            <asp:HyperLink ID="hl_modulo" runat="server" SkinID="hlMasterModulo" NavigateUrl="~/Default.aspx"></asp:HyperLink>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="masterTdRec">Ingreso al sistema</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="masterTdContenido">
                    <table class="priTable">
                        <tr><td class="priTdTitle">Ingreso al sistema</td></tr>
                        <tr>
                            <td class="priTdContenido">
                                <br /><br /><br /><br />
                                <table align="center"><tr><td>
                                    <asp:Login ID="Login1" runat="server" DisplayRememberMe="False" TitleText="Iniciar sesión" UserNameLabelText="Nombre de usuario:" PasswordLabelText="Contraseña:" LoginButtonText="Inicio de sesión" FailureText="El intento de conexión no fue correcto. Inténtelo de nuevo." PasswordRequiredErrorMessage="La contraseña es obligatoria." UserNameRequiredErrorMessage="El nombre de usuario es obligatorio.">
                                    </asp:Login>
                                </td></tr></table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
