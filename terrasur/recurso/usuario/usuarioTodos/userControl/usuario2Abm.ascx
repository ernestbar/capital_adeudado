<%@ Control Language="VB" ClassName="usuario2Abm" %>
<%@ Register Src="~/recurso/usuario/usuarioTodos/userControl/usuarioForm.ascx" TagName="usuarioForm" TagPrefix="uc1" %>

<script runat="server">
    Public Property id_usuario() As Integer
        Get
            Return Integer.Parse(lbl_id_usuario.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_usuario.Text = value
        End Set
    End Property
    
    Public Sub CargarInsertar(ByVal Id_rol As Integer)
        Me.id_usuario = 0
        uf0.RequiredField_password = True
        uf0.Reset(Id_rol)
    End Sub
    Public Function VerificarInsertar() As Boolean
        'uf0.nombre_usuario = uf0.paterno.Replace(" ", "") & general.StringRandom(5)
        'uf0.password = general.StringRandom(10)
        Return uf0.Verificar(0)
    End Function
    Public Function Insertar() As Boolean
        Dim nuevo_usuario As New usuario(uf0.nombres, uf0.paterno, uf0.materno, uf0.ci, uf0.email, uf0.nombre_usuario, uf0.password, uf0.activo)
        If nuevo_usuario.Insertar(Profile.id_usuario) Then
            uf0.id_usuario = nuevo_usuario.id_usuario
            Me.id_usuario = uf0.id_usuario
            'Guardamos la imagen del usuario
            If uf0.imagen.HasFile Then
                Try
                    uf0.imagen.SaveAs(Server.MapPath(ConfigurationManager.AppSettings("usuario_dir_imagen") & nuevo_usuario.id_usuario & System.IO.Path.GetExtension(uf0.imagen.FileName)))
                    nuevo_usuario.imagen = nuevo_usuario.id_usuario & System.IO.Path.GetExtension(uf0.imagen.FileName)
                    nuevo_usuario.ImagenActualizar(Profile.id_usuario)
                Catch ex As Exception
                End Try
            End If
            'Guardamos el rol del usuario
            If usuario_rol.InsertarEliminar(True, nuevo_usuario.id_usuario, uf0.id_rol) Then
                'Guardamos los permisos del rol del usuario
                If uf0.permisos <> "" Then
                    Dim permiso As String() = uf0.permisos.Split(";")
                    For i As Integer = 0 To permiso.Length - 1
                        If Boolean.Parse(permiso(i).Split(",")(1)) = True Then
                            usuario_rol_permiso.InsertarEliminar(True, nuevo_usuario.id_usuario, uf0.id_rol, Integer.Parse(permiso(i).Split(",")(0)))
                        End If
                    Next
                End If
            End If
            CargarPerfilUsuario(nuevo_usuario.id_usuario, uf0.id_rol)
            Msg1.Text = "Los datos del usuario se guardaron correctamente"
            Return True
        Else
            Msg1.Text = "Los datos del usuario NO se guardaron correctamente"
            Return False
        End If
    End Function
    
    Public Sub CargarActualizar(ByVal Id_rol As Integer, ByVal Id_usuario As Integer)
        uf0.RequiredField_password = False
        uf0.RecuperarDatos(Id_rol, Id_usuario)
        Me.id_usuario = Id_usuario
    End Sub
    Public Function VerificarActualizar() As Boolean
        Return uf0.Verificar(uf0.id_usuario)
    End Function
    Public Function Actualizar() As Boolean
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
            'De ser necesario guardamos los permisos
            If uf0.Visible_permiso = True AndAlso uf0.id_rol > 0 Then
                Dim permiso As String() = uf0.permisos.Split(";")
                For i As Integer = 0 To permiso.Length - 1
                    usuario_rol_permiso.InsertarEliminar(Boolean.Parse(permiso(i).Split(",")(1)), uf0.id_usuario, uf0.id_rol, Integer.Parse(permiso(i).Split(",")(0)))
                Next
            End If
            CargarPerfilUsuario(uf0.id_usuario, uf0.id_rol)
            Msg1.Text = "Los datos del usuario se actualizaron correctamente"
            Return True
        Else
            Msg1.Text = "Los datos del usuario NO se actualizaron correctamente"
            Return False
        End If
    End Function
    
    Public Sub CargarPerfilUsuario(ByVal Id_usuario As Integer, ByVal Id_rol As Integer)
        Dim usr As New usuario(Id_usuario)
        Dim pc As ProfileCommon = Profile.GetProfile(usr.nombre_usuario)
        pc.id_usuario = usr.id_usuario
        pc.nombre_usuario = usr.nombre_usuario
        pc.nombre_persona = usr.paterno & " " & usr.materno & " " & usr.nombres
        pc.imagen = usuario.ImagenDireccion(usr.imagen)
        Dim codigo_modulo As String = New modulo(New rol(Id_rol).id_modulo).codigo
        If codigo_modulo <> "" Then
            Try
                pc.SetPropertyValue("menu_modulos." & codigo_modulo, general.MenuStringEliminados(Id_usuario, Id_rol))
            Catch ex As Exception
            End Try
        End If
        pc.Save()
    End Sub
</script>
<asp:Msg ID="Msg1" runat="server"></asp:Msg>
<asp:Label ID="lbl_id_usuario" runat="server" Text="0" Visible="false"></asp:Label>
<uc1:usuarioForm id="uf0" runat="server" Visible_imagen_file="false" Visible_imagen_img="false"></uc1:usuarioForm>
<%--<uc1:usuarioForm id="UsuarioForm1" runat="server" Visible_imagen_file="false" Visible_imagen_img="false" Visible_nombre_usuario="false" Visible_password="false" Visible_permiso="false"></uc1:usuarioForm>--%>
