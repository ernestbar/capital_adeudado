<%@ Control Language="VB" ClassName="asignaCobradorAbm" %>

<script runat="server">
    Public Property id_contrato() As Integer
        Get
            Return Integer.Parse(lbl_id_contrato.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_contrato.Text = value
        End Set
    End Property
    
    Public Sub CargarInsertar()
        ddl_cobrador.DataBind()
    End Sub
    
    Protected Sub ddl_cobrador_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        ddl_cobrador.Items.Insert(0, New ListItem("Sin asignar", "0"))
        If (ddl_cobrador.Items.Count > 0) Then
            Dim contrato_asigObj As New asignacion_cobrador(id_contrato.ToString())
            If contrato_asigObj.id_usuario_cobrador <> 0 Then
                ddl_cobrador.SelectedValue = contrato_asigObj.id_usuario_cobrador.ToString()
            Else
                ddl_cobrador.SelectedValue = "0"
            End If
        End If
    End Sub
    
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        'Dim contratoObj As New contrato_venta(id_contrato)
        'Dim contrato_p4n As New contrato_paquete4n(id_contrato.ToString())
        'Dim paquete4n_nuevo As New paquete4n(Int32.Parse(ddl_nuevo_paquete.SelectedValue))
        'contrato_p4n.num_cenizas_inhumadas
        Return correcto
    End Function
    
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim asig_contObj As New asignacion_cobrador(id_contrato, Int32.Parse(ddl_cobrador.SelectedValue))
            If asig_contObj.Asignar(Profile.id_usuario) Then
                Msg1.Text = "La asignación se guardó correctamente"
                Return True
            Else
                Msg1.Text = "La asignación NO se guardó correctamente"
                Return False
            End If
        Else
            Msg1.Text = "La asignación NO se guardó correctamente"
            Return False
        End If
    End Function

    
</script>


<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_dosificacion" runat="server" DisplayMode="List" ValidationGroup="dosificacion" />
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_cobrador_enun" runat="server" Text="Cobrador:"></asp:Label>
        </td>
            <td class="formTdDato">
                <asp:DropDownList ID="ddl_cobrador" runat="server" AutoPostBack="false" DataSourceID="ods_cobrador_lista"
                    DataTextField="nombre_completo" DataValueField="id_usuario" OnDataBound="ddl_cobrador_DataBound">
                </asp:DropDownList>
                <%--[id_localizacion],[nombre]--%>
                <asp:ObjectDataSource ID="ods_cobrador_lista" runat="server" TypeName="terrasur.cobrador"
                    SelectMethod="ListaNoEliminado"></asp:ObjectDataSource>
     </td>
    </tr>
</table>