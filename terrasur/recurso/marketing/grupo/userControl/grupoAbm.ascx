<%@ Control Language="VB" ClassName="grupoAbm" %>

<script runat="server">
    Private Property id_grupoventa() As Integer
        Get
            Return Integer.Parse(lbl_id_grupoventa.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_grupoventa.Text = value
        End Set
    End Property
    Private Property ids_promotores() As String
        Get
            Return lbl_ids_promotores.Text
        End Get
        Set(ByVal value As String)
            lbl_ids_promotores.Text = value
        End Set
    End Property
    
    Public Sub CargarInsertar()
        id_grupoventa = 0
        ids_promotores = ""

        txt_nombre.Text = ""
        ddl_director.DataBind()
        cb_activo.Checked = True
        cb_planilla.Checked = False
        gv_grupo.DataBind()
        gv_sin_grupo.DataBind()
    End Sub
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        If grupo_venta.VerificarNombre(True, 0, txt_nombre.Text.Trim) = True Then
            Msg1.Text = "El nombre del grupo de venta pertenece a otro grupo registrado"
            correcto = False
        End If
        If director.NumeroGrupos(Integer.Parse(ddl_director.SelectedValue), 0) > 0 Then
            Msg1.Text = "El director de ventas tiene asignado otro grupo"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim grupoObj As New grupo_venta(Integer.Parse(ddl_director.SelectedValue), txt_nombre.Text.Trim, cb_activo.Checked, cb_planilla.Checked)
            If grupoObj.Insertar Then
                Msg1.Text = "El grupo de ventas se guardó correctamente"
                If ids_promotores <> "" Then
                    Dim ids As String() = ids_promotores.TrimEnd(",").Split(",")
                    Dim num_promotores As Integer = 0
                    For i As Integer = 0 To ids.Length - 1
                        Dim prup_promObj As New grupo_promotor(grupoObj.id_grupoventa, Integer.Parse(ids(i)))
                        If prup_promObj.Insertar Then
                            num_promotores += 1
                        End If
                    Next
                    If num_promotores = 1 Then
                        Msg1.Text = num_promotores & " promotor se asignó al grupo"
                    ElseIf num_promotores > 1 Then
                        Msg1.Text = num_promotores & " promotores se asignaron al grupo"
                    End If
                    If num_promotores < ids.Length Then
                        Msg1.Text = (ids.Length - num_promotores) & " promotores NO se asignaron correctamente"
                    End If
                End If
                CargarInsertar()
                Return True
            Else
                Msg1.Text = "El grupo de ventas NO se guardó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function
    
    Public Sub CargarActualizar(ByVal _Id_grupoventa As Integer)
        Dim grupoObj As New grupo_venta(_Id_grupoventa)
        id_grupoventa = grupoObj.id_grupoventa
        ids_promotores = ""
        
        txt_nombre.Text = grupoObj.nombre
        ddl_director.DataBind()
        ddl_director.SelectedValue = grupoObj.id_director
        cb_activo.Checked = grupoObj.activo
        cb_planilla.Checked = grupoObj.en_planilla
        gv_grupo.DataBind()
        gv_sin_grupo.DataBind()
    End Sub
    Public Function VerificarActualizar() As Boolean
        Dim correcto As Boolean = True
        If grupo_venta.VerificarNombre(False, id_grupoventa, txt_nombre.Text.Trim) = True Then
            Msg1.Text = "El nombre del grupo de venta pertenece a otro grupo registrado"
            correcto = False
        End If
        If director.NumeroGrupos(Integer.Parse(ddl_director.SelectedValue), id_grupoventa) > 0 Then
            Msg1.Text = "El director de ventas tiene asignado otro grupo"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Actualizar() As Boolean
        If VerificarActualizar() Then
            Dim grupoObj As New grupo_venta(id_grupoventa, Integer.Parse(ddl_director.SelectedValue), txt_nombre.Text.Trim, cb_activo.Checked, cb_planilla.Checked)
            If grupoObj.Actualizar Then
                Msg1.Text = "El grupo de ventas se actualizó correctamente"
                CargarActualizar(id_grupoventa)
                Return True
            Else
                Msg1.Text = "El grupo de ventas NO se actualizó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Protected Sub gv_grupo_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_grupo.RowCommand
        If e.CommandName = "retirar" Then
            If id_grupoventa > 0 Then
                Dim id_grupopromotor As Integer = Integer.Parse(gv_grupo.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Values("id_grupopromotor").ToString)
                Dim prup_promObj As New grupo_promotor(id_grupopromotor)
                If prup_promObj.Eliminar Then
                    Msg1.Text = "El promotor se retiró del grupo"
                    gv_grupo.DataBind()
                    gv_sin_grupo.DataBind()
                Else
                    Msg1.Text = "El promotor NO se retiró correctamente del grupo"
                End If
            Else
                Dim id_promotor As String = gv_grupo.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Values("id_usuario").ToString
                Dim ids As String = "," & ids_promotores
                ids_promotores = ids.Replace("," & id_promotor & ",", ",").TrimStart(",")
                gv_grupo.DataBind()
                gv_sin_grupo.DataBind()
            End If
        End If
    End Sub
    
    Protected Sub gv_sin_grupo_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_sin_grupo.RowCommand
        If e.CommandName = "asignar" Then
            If id_grupoventa > 0 Then
                Dim id_promotor As Integer = Integer.Parse(gv_sin_grupo.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                Dim prup_promObj As New grupo_promotor(id_grupoventa, id_promotor)
                If prup_promObj.Insertar Then
                    Msg1.Text = "El promotor se asignó al grupo"
                    gv_grupo.DataBind()
                    gv_sin_grupo.DataBind()
                Else
                    Msg1.Text = "El promotor NO se asignó correctamente al grupo"
                End If
            Else
                ids_promotores &= gv_sin_grupo.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString & ","
                gv_grupo.DataBind()
                gv_sin_grupo.DataBind()
            End If
        End If
    End Sub

    Protected Sub gv_grupo_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_grupo.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            general.OnMouseOver(sender, e)
        End If
    End Sub
    Protected Sub gv_sin_grupo_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_sin_grupo.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            general.OnMouseOver(sender, e)
        End If
    End Sub
</script>
<asp:Label ID="lbl_id_grupoventa" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_ids_promotores" runat="server" Text="" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_grupo" runat="server" DisplayMode="List" ValidationGroup="grupoventa" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos del grupo de venta"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_nombre_enun" runat="server" Text="Nombre del grupo:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_nombre" runat="server" SkinID="txtSingleLine200" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="grupoventa" Text="*" ErrorMessage="Debe introducir el nombre del grupo"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="grupoventa" Text="*" ErrorMessage="El nombre del grupo contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:grupoventa_ExpReg_nombre %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_director_enun" runat="server" Text="Director de ventas:"></asp:Label></td>
        <td class="formTdDato">
            <asp:DropDownList ID="ddl_director" runat="server" DataSourceID="ods_lista_director" DataTextField="nombre_completo" DataValueField="id_usuario">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfv_director" runat="server" ControlToValidate="ddl_director" Display="Dynamic" ValidationGroup="grupoventa" Text="*" ErrorMessage="No existen directores (sin grupo) disponibles"></asp:RequiredFieldValidator>
            <%--[id_usuario],[nombre_completo],[ci],[nombre_usuario]--%>
            <asp:ObjectDataSource ID="ods_lista_director" runat="server" TypeName="terrasur.director" SelectMethod="Lista">
                <SelectParameters>
                    <asp:ControlParameter Name="Id_grupoventa" Type="Int32" ControlID="lbl_id_grupoventa" PropertyName="Text" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Activo:</td>
        <td class="formTdDato"><asp:CheckBox ID="cb_activo" runat="server" Text="Grupo de venta activo" /></td>
    </tr>
    <tr>
        <td class="formTdEnun">En planilla:</td>
        <td class="formTdDato"><asp:CheckBox ID="cb_planilla" runat="server" Text="Grupo de venta en planilla" /></td>
    </tr>
    <tr>
        <td class="formTdEnun">Promotores del grupo:</td>
        <td class="formTdDato">
            <asp:Panel ID="panel_grupo" runat="server" GroupingText="Promotores del grupo" Height="175px" ScrollBars="Vertical">
                <asp:GridView ID="gv_grupo" runat="server" AllowSorting="true" AutoGenerateColumns="false" DataSourceID="ods_grupo" DataKeyNames="id_grupopromotor,id_usuario">
                    <Columns>
                        <asp:ButtonField Text="Retirar del grupo" CommandName="retirar" ControlStyle-CssClass="gvButton" />
                        <asp:BoundField HeaderText="Promotor" DataField="nombre_completo" SortExpression="nombre_completo" />
                        <asp:CheckBoxField HeaderText="Activo" DataField="activo" Text="Activo" SortExpression="activo" />
                    </Columns>
                    <EmptyDataTemplate>El grupo no tiene promotores</EmptyDataTemplate>
                </asp:GridView>
            </asp:Panel>
            <%--[id_grupopromotor],[id_usuario],[nombre_completo],[ci],[nombre_usuario]--%>
            <asp:ObjectDataSource ID="ods_grupo" runat="server" TypeName="terrasur.grupo_promotor" SelectMethod="ListaPromotorPorGrupo">
                <SelectParameters>
                    <asp:ControlParameter Name="Id_grupoventa" Type="Int32" ControlID="lbl_id_grupoventa" PropertyName="Text" />
                    <asp:ControlParameter Name="Ids_promotores" Type="String" ControlID="lbl_ids_promotores" PropertyName="Text" DefaultValue=""/>
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            Promotores sin grupo:
        </td>
        <td class="formTdDato">
            <asp:Panel ID="panel_sin_grupo" runat="server" GroupingText="Promotores sin grupo" Height="175px" ScrollBars="Vertical">
                <asp:GridView ID="gv_sin_grupo" runat="server" AllowSorting="true" AutoGenerateColumns="false" DataSourceID="ods_sin_grupo" DataKeyNames="id_usuario">
                    <Columns>
                        <asp:ButtonField Text="Asignar al grupo" CommandName="asignar" ControlStyle-CssClass="gvButton" />
                        <asp:BoundField HeaderText="Promotor" DataField="nombre_completo" SortExpression="nombre_completo" />
                    </Columns>
                    <EmptyDataTemplate>No existen promotores sin grupo</EmptyDataTemplate>
                </asp:GridView>
            </asp:Panel>
            <%--[id_usuario],[nombre_completo],[ci],[nombre_usuario]--%>
            <asp:ObjectDataSource ID="ods_sin_grupo" runat="server" TypeName="terrasur.grupo_promotor" SelectMethod="ListaPromotorSinGrupo">
                <SelectParameters>
                    <asp:ControlParameter Name="Id_grupoventa" Type="Int32" ControlID="lbl_id_grupoventa" PropertyName="Text" />
                    <asp:ControlParameter Name="Ids_promotores" Type="String" ControlID="lbl_ids_promotores" PropertyName="Text" DefaultValue="" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
</table>