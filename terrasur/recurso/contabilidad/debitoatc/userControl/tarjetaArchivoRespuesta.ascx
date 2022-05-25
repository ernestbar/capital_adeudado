<%@ Control Language="VB" ClassName="tarjetaArchivoRespuesta" %>

<script runat="server">
    Protected ReadOnly Property dirArchivo() As String
        Get
            Return "~/upload/archivoDebito/"
        End Get
    End Property
    
    Protected Property id_grupotransaccion() As Integer
        Get
            Return Integer.Parse(lbl_id_grupotransaccion.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_grupotransaccion.Text = value
        End Set
    End Property
    
    Protected Property id_archivorespuestadebito_aceptados() As Integer
        Get
            Return Integer.Parse(lbl_id_archivorespuestadebito_aceptados.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_archivorespuestadebito_aceptados.Text = value
        End Set
    End Property
    
    Protected Property id_archivorespuestadebito_denegados() As Integer
        Get
            Return Integer.Parse(lbl_id_archivorespuestadebito_denegados.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_archivorespuestadebito_denegados.Text = value
        End Set
    End Property
    
    Public Sub Cargar(ByVal _Id_grupotransaccion As Integer)
        id_grupotransaccion = _Id_grupotransaccion

        Dim aceObj As New archivo_respuesta_debito(id_grupotransaccion, "aceptados")
        Dim fileAceptados As String = System.IO.Path.Combine(Server.MapPath(dirArchivo), aceObj.fileName)
        If aceObj.id_archivorespuestadebito > 0 AndAlso System.IO.File.Exists(fileAceptados) = True Then
            btn_aceptados_ver.Enabled = True
        Else
            btn_aceptados_ver.Enabled = False
        End If
        
        Dim denObj As New archivo_respuesta_debito(id_grupotransaccion, "denegados")
        Dim fileDenegados As String = System.IO.Path.Combine(Server.MapPath(dirArchivo), denObj.fileName)
        If denObj.id_archivorespuestadebito > 0 AndAlso System.IO.File.Exists(fileDenegados) = True Then
            btn_denegados_ver.Enabled = True
        Else
            btn_denegados_ver.Enabled = False
        End If
    End Sub
    
    
    
    Protected Sub btn_aceptados_ver_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim aceObj As New archivo_respuesta_debito(id_grupotransaccion, "aceptados")
        Dim file As String = System.IO.Path.Combine(Server.MapPath(dirArchivo), aceObj.fileName)
        Response.Clear()
        Response.ContentType = "application/octet-stream"
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + aceObj.nombre)
        Response.TransmitFile(file)
        Response.End()
    End Sub

    Protected Sub btn_aceptados_cargar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If System.IO.Path.GetExtension(fu_aceptados.FileName).ToLower() = ".txt" Then
            Dim nombre_archivo As String = fu_aceptados.FileName.TrimEnd(".txt".ToCharArray).TrimEnd(".TXT".ToCharArray) + "_" + DateTime.Now.ToString("ddMMyyyy") + ".txt"
            Dim aObj As New archivo_respuesta_debito(id_grupotransaccion, nombre_archivo, "aceptados")
            If aObj.Guardar(Profile.id_usuario) = True Then
                Try
                    fu_aceptados.SaveAs(Server.MapPath(dirArchivo & aObj.fileName))
                    If aObj.ObtenerDatosArchivo(System.IO.Path.Combine(Server.MapPath(dirArchivo), aObj.fileName)) = True Then
                        Msg1.Text = "El archivo se guardó correctamente"
                        btn_aceptados_ver.Enabled = True
                    Else
                        Msg1.Text = "El archivo no tiene el formato correcto"
                        aObj.Eliminar(Profile.id_usuario)
                    End If
                Catch ex As Exception
                    Msg1.Text = "El archivo NO se guardó correctamente"
                    aObj.Eliminar(Profile.id_usuario)
                End Try
            Else
                Msg1.Text = "El registro del archivo no se guardó correctamente"
            End If
        Else
            Msg1.Text = "El archivo debe tener el formato TXT"
        End If
    End Sub
    
    
    
    Protected Sub btn_denegados_ver_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim denObj As New archivo_respuesta_debito(id_grupotransaccion, "denegados")
        Dim file As String = System.IO.Path.Combine(Server.MapPath(dirArchivo), denObj.fileName)
        Response.Clear()
        Response.ContentType = "application/octet-stream"
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + denObj.nombre)
        Response.TransmitFile(file)
        Response.End()
    End Sub

    Protected Sub btn_denegados_cargar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If System.IO.Path.GetExtension(fu_denegados.FileName).ToLower() = ".txt" Then
            Dim nombre_archivo As String = fu_denegados.FileName.TrimEnd(".txt".ToCharArray).TrimEnd(".TXT".ToCharArray) + "_" + DateTime.Now.ToString("ddMMyyyy") + ".txt"
            Dim aObj As New archivo_respuesta_debito(id_grupotransaccion, nombre_archivo, "denegados")
            If aObj.Guardar(Profile.id_usuario) = True Then
                Try
                    fu_denegados.SaveAs(Server.MapPath(dirArchivo & aObj.fileName))
                    If aObj.ObtenerDatosArchivo(System.IO.Path.Combine(Server.MapPath(dirArchivo), aObj.fileName)) = True Then
                        Msg1.Text = "El archivo se guardó correctamente"
                        btn_denegados_ver.Enabled = True
                    Else
                        Msg1.Text = "El archivo no tiene el formato correcto"
                        aObj.Eliminar(Profile.id_usuario)
                    End If
                Catch ex As Exception
                    Msg1.Text = "El archivo NO se guardó correctamente"
                    aObj.Eliminar(Profile.id_usuario)
                End Try
            Else
                Msg1.Text = "El registro del archivo no se guardó correctamente"
            End If
        Else
            Msg1.Text = "El archivo debe tener el formato TXT"
        End If
    End Sub
</script>
<asp:Label ID="lbl_id_grupotransaccion" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_archivorespuestadebito_aceptados" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_archivorespuestadebito_denegados" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_aceptados" runat="server" DisplayMode="List" ValidationGroup="aceptados" />
            <asp:ValidationSummary ID="vs_denegados" runat="server" DisplayMode="List" ValidationGroup="denegados" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">Archivos de respuesta:</td>
    </tr>
    <tr>
        <td class="formTdEnun">Archivo de debitos ACEPTADOS:</td>
        <td class="formTdDato">
            <asp:Button ID="btn_aceptados_ver" runat="server" Text="Descargar" OnClick="btn_aceptados_ver_Click" />
        </td>
    </tr>
    <tr>
        <td class="formTdEnun"></td>
        <td class="formTdDato">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:FileUpload ID="fu_aceptados" runat="server" SkinID="fuFileUpload200" />
                        <asp:Button ID="btn_aceptados_cargar" runat="server" Text="Cargar archivo TXT" CausesValidation="true" ValidationGroup="aceptados" OnClick="btn_aceptados_cargar_Click" />
                    </td>
                    <td><asp:RequiredFieldValidator ID="rfv_aceptados" runat="server" ControlToValidate="fu_aceptados" Display="Dynamic" ValidationGroup="aceptados" Text="*" ErrorMessage="Debe seleccionar el archivo de debitos ACEPTADOS"></asp:RequiredFieldValidator></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr><td colspan="2">&nbsp;</td></tr>
    <tr>
        <td class="formTdEnun">Archivo de debitos DENEGADOS:</td>
        <td class="formTdDato">
            <asp:Button ID="btn_denegados_ver" runat="server" Text="Descargar" OnClick="btn_denegados_ver_Click" />
        </td>
    </tr>
    <tr>
        <td class="formTdEnun"></td>
        <td class="formTdDato">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:FileUpload ID="fu_denegados" runat="server" SkinID="fuFileUpload200" />
                        <asp:RequiredFieldValidator ID="rfv_denegados" runat="server" ControlToValidate="fu_denegados" Display="Dynamic" ValidationGroup="denegados" Text="*" ErrorMessage="Debe seleccionar el archivo de debitos DENEGADOS"></asp:RequiredFieldValidator>
                    </td>
                    <td><asp:Button ID="btn_denegados_cargar" runat="server" Text="Cargar archivo TXT" CausesValidation="true" ValidationGroup="denegados" OnClick="btn_denegados_cargar_Click" /></td>
                </tr>
            </table>
        </td>
    </tr>
</table>

