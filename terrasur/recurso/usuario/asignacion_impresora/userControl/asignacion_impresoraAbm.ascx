<%@ Control Language="VB" ClassName="asignacion_impresoraAbm" %>

<script runat="server">
    Private Property id_usuario() As Integer
        Get
            Return Integer.Parse(lbl_id_usuario.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_usuario.Text = value
        End Set
    End Property
        
    Public Sub Cargar(ByVal Id_user As Integer)
        id_usuario = Id_user
        If id_usuario > 0 Then
            lbl_usuario.Text = usuario.ObtenerNombreCompletoPorId(id_usuario)
            lbl_usuario.Visible = True
            ddl_roles.Visible = False
            ddl_usuarios.Visible = False
            rfv_usarios.Enabled = False
        Else
            lbl_usuario.Text = ""
            lbl_usuario.Visible = False
            ddl_roles.Visible = True
            ddl_usuarios.Visible = True
            rfv_usarios.Enabled = True
            
            ddl_roles.DataBind()
            ddl_usuarios.DataBind()
        End If
        gv_impresora.DataBind()
    End Sub
    
    Public Function Verificar() As Boolean
        Dim correcto As Boolean = True
        'If id_usuario = 0 AndAlso ddl_usuarios.Items.Count = 0 Then
        '    Msg1.Text = "Debe selecciomar un usuario"
        '    correcto = False
        'End If
        Return correcto
    End Function
    
    Protected Sub gv_impresora_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_impresora.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If id_usuario > 0 Then
                CType(e.Row.Cells(0).FindControl("cb_impresora"), CheckBox).Checked = impresora_usuario.Verificar(Integer.Parse(DataBinder.Eval(e.Row.DataItem, "id_impresora")), id_usuario)
            End If
        End If
    End Sub
    
    Public Function InsertarEliminar() As Boolean
        If Verificar() Then
            Dim correcto As Boolean = True
            Dim id_user As Integer
            If id_usuario > 0 Then
                id_user = id_usuario
            Else
                id_user = Integer.Parse(ddl_usuarios.SelectedValue)
            End If
            For Each fila As GridViewRow In gv_impresora.Rows
                Dim cb_impresora As CheckBox = CType(fila.Cells(0).FindControl("cb_impresora"), CheckBox)
                Dim id_impresora As Integer = Integer.Parse(gv_impresora.DataKeys(fila.RowIndex).Value.ToString)
                If impresora_usuario.InsertarEliminar(cb_impresora.Checked, id_impresora, id_user) = False Then
                    correcto = False
                End If
            Next
            Return correcto
        Else
            Return False
        End If
    End Function

    Protected Sub ddl_usuarios_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        For i As Integer = ddl_usuarios.Items.Count - 1 To 0 Step -1
            If impresora_usuario.ListaImpresoraPorUsuario(Integer.Parse(ddl_usuarios.Items(i).Value), True, True, True, False).Rows.Count > 0 Then
                ddl_usuarios.Items.RemoveAt(i)
            End If
        Next
    End Sub
</script>

<asp:Label ID="lbl_id_usuario" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_impresora" runat="server" DisplayMode="List" ValidationGroup="impresora" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos de las asignaciónes"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_usuario_enun" runat="server" Text="Usuario:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:Label ID="lbl_usuario" runat="server" Text="0" Visible="true"></asp:Label>
            <asp:DropDownList ID="ddl_roles" runat="server" AutoPostBack="true" DataSourceID="ods_rol_lista" DataValueField="id_rol" DataTextField="nombre" >
            </asp:DropDownList>
            <asp:DropDownList ID="ddl_usuarios" runat="server" AutoPostBack="false" DataSourceID="ods_usuario_lista" DataTextField="nombre_completo" DataValueField="id_usuario" OnDataBound="ddl_usuarios_DataBound">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfv_usarios" runat="server" ControlToValidate="ddl_usuarios" Display="Dynamic" SetFocusOnError="true" ValidationGroup="impresora" Text="*" ErrorMessage="Debe seleccionar un usuario"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_direccion_enun" runat="server" Text="Impresoras:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:GridView ID="gv_impresora" runat="server" AutoGenerateColumns="false" DataSourceID="ods_impresora_lista" DataKeyNames="id_impresora">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="cb_impresora" runat="server" Text='<%# Eval("nombre") %>' ToolTip='<%# Eval("direccion_red") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CheckBoxField HeaderText="Factura" Text="Factura" DataField="factura"/>
                    <asp:CheckBoxField HeaderText="Recibo" Text="Recibo" DataField="recibo"/>
                    <asp:CheckBoxField HeaderText="Comprobante" Text="Comprobante" DataField="comprobante"/>
                </Columns>
            </asp:GridView>
            <%--[id_impresora],[id_usuario],[codigo],[nombre],[valor]--%>
            <asp:ObjectDataSource ID="ods_impresora_lista" runat="server" TypeName="terrasur.impresora"
                SelectMethod="Lista">
                <SelectParameters >
                    <asp:Parameter Name="factura" DefaultValue="true" Type="Boolean" />
                    <asp:Parameter Name="recibo" DefaultValue="true" Type="Boolean" />
                    <asp:Parameter Name="comprobante" DefaultValue="true" Type="Boolean" />
                    <asp:Parameter Name="solo_activos" DefaultValue="true" Type="Boolean" />
                </SelectParameters>    
            </asp:ObjectDataSource>
        </td>
    </tr>
</table>
<asp:ObjectDataSource ID="ods_rol_lista" runat="server" TypeName="terrasur.rol"
    SelectMethod="Lista">
</asp:ObjectDataSource>
<%--[id_usuario],[nombres],[paterno],[materno],[ci],[email],[imagen],[nombre_usuario],[password],[activo],[eliminable],[roles]--%>
<asp:ObjectDataSource ID="ods_usuario_lista" runat="server" TypeName="terrasur.usuario" SelectMethod="Lista">
    <SelectParameters>
        <asp:ControlParameter Name="id_rol" ControlID="ddl_roles"  PropertyName="SelectedValue"  Type="Int32"/>
        <asp:Parameter Name="eliminado" DefaultValue="false" Type="Boolean" />
        <asp:Parameter Name="busqueda" DefaultValue="false" Type="Boolean" />
        <asp:Parameter Name="ci" DefaultValue="" Type="String" />
        <asp:Parameter Name="paterno" DefaultValue="" Type="String" />
        <asp:Parameter Name="materno" DefaultValue="" Type="String" />
        <asp:Parameter Name="nombres" DefaultValue="" Type="String" />
        <asp:Parameter Name="nombre_usuario" DefaultValue="" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
