<%@ Control Language="VB" ClassName="usuarioDatos" %>
<%@ Register Src="~/recurso/usuario/usuarioTodos/userControl/usuarioForm.ascx" TagName="usuarioForm" TagPrefix="uc1" %>

<script runat="server">
    Public Sub CargarActualizar(ByVal Id_rol As Integer, ByVal Id_usuario As Integer)
        uf0.Enabled_nombres = Boolean.Parse(ConfigurationManager.AppSettings("usuario_cambiar_nombres"))
        uf0.Enabled_paterno = Boolean.Parse(ConfigurationManager.AppSettings("usuario_cambiar_paterno"))
        uf0.Enabled_materno = Boolean.Parse(ConfigurationManager.AppSettings("usuario_cambiar_materno"))
        uf0.Enabled_ci = Boolean.Parse(ConfigurationManager.AppSettings("usuario_cambiar_ci"))
        uf0.Enabled_email = Boolean.Parse(ConfigurationManager.AppSettings("usuario_cambiar_email"))
        uf0.Visible_imagen_file = Boolean.Parse(ConfigurationManager.AppSettings("usuario_cambiar_imagen"))
        uf0.Enabled_nombre_usuario = Boolean.Parse(ConfigurationManager.AppSettings("usuario_cambiar_nombre_usuario"))
        uf0.Visible_password = Boolean.Parse(ConfigurationManager.AppSettings("usuario_cambiar_password"))
        uf0.RequiredField_password = False
        uf0.Visible_activo = False
        uf0.Visible_desbloquear = False
        uf0.Visible_permiso = False
        
        uf0.RecuperarDatos(0, Id_usuario)

        Dim current_id_rol As Integer = Profile.entorno.id_rol
        If current_id_rol = 10 Or current_id_rol = 11 Then
            uf0.Enabled_materno = False
            uf0.Enabled_imagen_file = False
            uf0.Enabled_nombre_usuario = False
        End If

    End Sub
    Public Function VerificarActualizar() As Boolean
        Return uf0.Verificar(uf0.id_usuario)
    End Function
    Public Function Actualizar() As Boolean
        Dim usr_aux As String = usuario.ObtenerNombreUsuarioPorId(uf0.id_usuario)
        Dim current_user As New usuario(uf0.id_usuario, uf0.nombres, uf0.paterno, uf0.materno, uf0.ci, uf0.email, uf0.nombre_usuario, uf0.password, uf0.activo)
        If current_user.Actualizar(Profile.id_usuario) Then
            'Guardamos la imagen del usuario
            If uf0.imagen.HasFile Then
                Try
                    uf0.imagen.SaveAs(Server.MapPath(ConfigurationManager.AppSettings("usuario_dir_imagen") & current_user.id_usuario & System.IO.Path.GetExtension(uf0.imagen.FileName)))
                    current_user.imagen = current_user.id_usuario & System.IO.Path.GetExtension(uf0.imagen.FileName)
                    current_user.ImagenActualizar(Profile.id_usuario)
                Catch ex As Exception
                End Try
            End If
            Msg1.Text = "Sus datos se guardaron correctamente"
            Return True
        Else
            Msg1.Text = "Sus datos NO se guardaron correctamente"
            Return False
        End If
    End Function
</script>
<asp:Msg ID="Msg1" runat="server"></asp:Msg>
<uc1:usuarioForm id="uf0" runat="server">
</uc1:usuarioForm>
