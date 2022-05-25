<%@ Control Language="VB" ClassName="localizacionAbm" %>
<%@ Register Src="~/recurso/inventario/localizacion/userControl/localizacionForm.ascx" TagName="localizacionForm" TagPrefix="uc1" %>

<script runat="server">
    Public Property id_localizacion() As Integer
        Get
            Return Integer.Parse(lf0.id_localizacion)
        End Get
        Set(ByVal value As Integer)
            lf0.id_localizacion = value
        End Set
    End Property
    Public Sub CargarInsertar()
        lf0.Reset()
    End Sub
    Public Function VerificarInsertar() As Boolean
        Return lf0.Verificar(0, True)
    End Function
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim localizacionObj As New localizacion(lf0.codigo, lf0.nombre)
            If localizacionObj.Insertar() Then
                If lf0.imagen.HasFile Then
                    Try
                        lf0.imagen.SaveAs(Server.MapPath(ConfigurationManager.AppSettings("localizacion_dir_imagen") & localizacionObj.id_localizacion & System.IO.Path.GetExtension(lf0.imagen.FileName)))
                        localizacionObj.imagen = localizacionObj.id_localizacion & System.IO.Path.GetExtension(lf0.imagen.FileName)
                        localizacionObj.ImagenActualizar(localizacionObj.id_localizacion)
                    Catch ex As Exception
                    End Try
                End If
                Msg1.Text = "La localización se guardó correctamente"
                CargarInsertar()
                Return True
            Else
                Msg1.Text = "La localización NO se guardó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Sub CargarActualizar(ByVal Id_localizacion As Integer)
        lf0.RecuperarDatos(Id_localizacion)
    End Sub
    
    Public Function VerificarActualizar() As Boolean
        Return lf0.Verificar(lf0.id_localizacion, False)
    End Function
    
    Public Function Actualizar() As Boolean
        If VerificarActualizar() Then
            Dim localizacionObj As New localizacion(lf0.codigo, lf0.nombre)
            localizacionObj.id_localizacion = lf0.id_localizacion
            If localizacionObj.Actualizar() Then
                If lf0.imagen.HasFile Then
                    Try
                        lf0.imagen.SaveAs(Server.MapPath(ConfigurationManager.AppSettings("localizacion_dir_imagen") & localizacionObj.id_localizacion & System.IO.Path.GetExtension(lf0.imagen.FileName)))
                        localizacionObj.imagen = localizacionObj.id_localizacion & System.IO.Path.GetExtension(lf0.imagen.FileName)
                        localizacionObj.ImagenActualizar(localizacionObj.id_localizacion)
                    Catch ex As Exception
                    End Try
                End If
                Msg1.Text = "Los datos de la localización se actualizaron correctamente"
                Return True
            Else
                Msg1.Text = "Los datos de la localización NO se actualizaron correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function
</script>
<asp:Msg ID="Msg1" runat="server"></asp:Msg>
<uc1:localizacionForm ID="lf0" runat="server" />


