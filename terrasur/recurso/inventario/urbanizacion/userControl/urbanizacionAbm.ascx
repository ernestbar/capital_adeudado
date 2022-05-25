<%@ Control Language="VB" ClassName="urbanizacionAbm" %>
<%@ Register Src="~/recurso/inventario/urbanizacion/userControl/urbanizacionForm.ascx" TagName="urbanizacionForm" TagPrefix="uc1" %>

<script runat="server">
    Public Property id_urbanizacion() As Integer
        Get
            Return Integer.Parse(uf0.id_urbanizacion)
        End Get
        Set(ByVal value As Integer)
            uf0.id_urbanizacion = value
        End Set
    End Property
    Public Property id_localizacion() As Integer
        Get
            Return Integer.Parse(uf0.id_localizacion)
        End Get
        Set(ByVal value As Integer)
            uf0.id_localizacion = value
        End Set
    End Property
    Public Sub CargarInsertar()
        uf0.Reset()
    End Sub
    Public Function VerificarInsertar() As Boolean
        Return uf0.Verificar(0, True)
    End Function
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim urbanizacionObj As New urbanizacion(uf0.id_localizacion, uf0.codigo, uf0.nombre_corto, uf0.nombre, uf0.mantenimiento, uf0.costo, uf0.precio, uf0.activo)
            If urbanizacionObj.Insertar() Then
                If uf0.imagen.HasFile Then
                    Try
                        uf0.imagen.SaveAs(Server.MapPath(ConfigurationManager.AppSettings("urbanizacion_dir_imagen") & urbanizacionObj.id_urbanizacion & System.IO.Path.GetExtension(uf0.imagen.FileName)))
                        urbanizacionObj.imagen = urbanizacionObj.id_urbanizacion & System.IO.Path.GetExtension(uf0.imagen.FileName)
                        urbanizacionObj.ImagenActualizar(urbanizacionObj.id_urbanizacion)
                    Catch ex As Exception
                    End Try
                End If
                Msg1.Text = "El sector se guardó correctamente"
                CargarInsertar()
                Return True
            Else
                Msg1.Text = "El sector NO se guardó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Sub CargarActualizar(ByVal Id_urbanizacion As Integer)
        'lf0.Visible_imagen_img = True
        uf0.RecuperarDatos(Id_urbanizacion)
    End Sub
    
    Public Function VerificarActualizar() As Boolean
        Return uf0.Verificar(uf0.id_urbanizacion, False)
    End Function
    
    Public Function Actualizar() As Boolean
        If VerificarActualizar() Then
            Dim urbanizacionObj As New urbanizacion(uf0.id_localizacion, uf0.codigo, uf0.nombre_corto, uf0.nombre, uf0.mantenimiento, uf0.costo, uf0.precio, uf0.activo)
            urbanizacionObj.id_urbanizacion = uf0.id_urbanizacion
            If urbanizacionObj.Actualizar() Then
                If uf0.imagen.HasFile Then
                    Try
                        uf0.imagen.SaveAs(Server.MapPath(ConfigurationManager.AppSettings("urbanizacion_dir_imagen") & urbanizacionObj.id_urbanizacion & System.IO.Path.GetExtension(uf0.imagen.FileName)))
                        urbanizacionObj.imagen = urbanizacionObj.id_urbanizacion & System.IO.Path.GetExtension(uf0.imagen.FileName)
                        urbanizacionObj.ImagenActualizar(urbanizacionObj.id_urbanizacion)
                    Catch ex As Exception
                    End Try
                End If
                If uf0.costo_todos = True Then
                    Try
                        urbanizacionObj.lotesActualizarCosto(urbanizacionObj.id_urbanizacion, uf0.costo)
                    Catch ex As Exception
                    End Try
                End If
                If uf0.precio_todos = True Then
                    Try
                        urbanizacionObj.lotesActualizarPrecio(urbanizacionObj.id_urbanizacion, uf0.precio)
                    Catch ex As Exception
                    End Try
                End If
                Msg1.Text = "Los datos del sector se actualizaron correctamente"
                Return True
            Else
                Msg1.Text = "Los datos del sector NO se actualizaron correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function
</script>

<asp:Msg ID="Msg1" runat="server"></asp:Msg>
<uc1:urbanizacionForm ID="uf0" runat="server" />
