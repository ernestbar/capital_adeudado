<%@ Control Language="VB" ClassName="estadoEspecialAbm" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>

<script runat="server">
    Public Property id_estadoespecial() As Integer
        Get
            Return Integer.Parse(lbl_id_estadoespecial.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_estadoespecial.Text = value
            txt_numero.Text = ""
            txt_observacion.Text = ""
        End Set
    End Property
    
    Protected Function VerificarInsertar() As Boolean
        Dim id_contrato As Integer = contrato.IdPorNumero(txt_numero.Text.Trim)
        If id_contrato > 0 Then
            If contrato_estado_especial.Verificar(id_contrato, id_estadoespecial, "", "") = False Then
                Return True
            Else
                Msg1.Text = "El contrato ya tiene el estado elegido"
                Return False
            End If
        Else
            Msg1.Text = "Contrato inexistente"
            Return False
        End If
    End Function
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim id_contrato As Integer = contrato.IdPorNumero(txt_numero.Text.Trim)
            If contrato_estado_especial.Insertar(id_contrato, id_estadoespecial, Profile.id_usuario) Then
                If txt_observacion.Text.Trim <> "" Then
                    InsertarComentario(id_contrato, id_estadoespecial, txt_observacion.Text.Trim)
                End If
                Msg1.Text = "El estado se asignó correctamente"
                txt_numero.Text = ""
                txt_observacion.Text = ""
                Return True
            Else
                Msg1.Text = "El estado NO se asignó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function
    
    Protected Sub InsertarComentario(ByVal _id_contrato As Integer, ByVal _id_estadoespecial As Integer, ByVal _observacion As String)
        Dim db1 As Database = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings("conn"))
        Dim cmd As DbCommand = db1.GetStoredProcCommand("contrato_estado_especial_ActualizarObservacion")
        db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato)
        db1.AddInParameter(cmd, "id_estadoespecial", DbType.Int32, _id_estadoespecial)
        db1.AddInParameter(cmd, "observacion", DbType.String, _observacion)
        db1.ExecuteNonQuery(cmd)
    End Sub
    
</script>
<asp:Label ID="lbl_id_estadoespecial" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="5">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Contrato:</td>
        <td class="formTdDato"><asp:TextBox ID="txt_numero" runat="server" MaxLength="7"></asp:TextBox></td>
        <td><asp:RequiredFieldValidator ID="rfv_numero" runat="server" ControlToValidate="txt_numero" Display="Dynamic" SetFocusOnError="True" ValidationGroup="contrato" Text="*"></asp:RequiredFieldValidator></td>
        <%--<td><asp:RegularExpressionValidator ID="rev_numero" runat="server" ControlToValidate="txt_numero" Display="Dynamic" SetFocusOnError="True" ValidationGroup="contrato" ValidationExpression="<%$ AppSettings:contrato_ExpReg_numero %>" Text="*"></asp:RegularExpressionValidator></td>--%>
        <td class="formTdDato"><asp:TextBox ID="txt_observacion" runat="server"></asp:TextBox></td>
   </tr>
</table>



