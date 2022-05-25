<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Clientes" %>
<%@ Register Src="~/recurso/clienteZona/cliente/userControl/clienteCriterio.ascx" TagName="clienteCriterio" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/clienteZona/cliente/userControl/clienteAbm.ascx" TagName="clienteAbm" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc3" %>

<script runat="server">
    Protected Property busqueda() As Boolean
        Get
            Return Boolean.Parse(lbl_busqueda.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_busqueda.Text = value
            panel_criterio.Visible = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cliente", "view") Then
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cliente", "insert")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    Protected Sub ods_cliente_lista_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ods_cliente_lista.Selecting
        e.InputParameters("Ci") = ClienteCriterio1.ci
        e.InputParameters("Paterno") = ClienteCriterio1.paterno
        e.InputParameters("Materno") = ClienteCriterio1.materno
        e.InputParameters("Nombres") = ClienteCriterio1.nombres
        e.InputParameters("Num_contrato") = ClienteCriterio1.num_contrato
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_cliente_abm.Text = "Nuevo cliente"
        ClienteAbm1.CargarInsertar()
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_busqueda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_busqueda.Click
        busqueda = True
        ClienteCriterio1.Reset()
    End Sub
    Protected Sub btn_criterio_buscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_criterio_buscar.Click
        If ClienteCriterio1.TieneCriterio Then
            gv_cliente.DataBind()
        Else
            msg_criterio.Text = "Debe introducir un criterio de busqueda"
        End If
    End Sub
    Protected Sub btn_criterio_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_criterio_cancelar.Click
        busqueda = False
    End Sub
    
    
    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If ClienteAbm1.VerificarInsertar Then
            If ClienteAbm1.Insertar Then
                gv_cliente.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If ClienteAbm1.VerificarActualizar Then
            If ClienteAbm1.Actualizar Then
                gv_cliente.DataBind()
            End If
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        busqueda = False
        MultiView1.ActiveViewIndex = 0
    End Sub
    
    Protected Sub gv_cliente_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_cliente.DataBound
        gv_cliente.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cliente", "update")
        gv_cliente.Columns(2).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cliente", "delete")
        gv_cliente.Columns(3).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "kardex", "view")
    End Sub

    Protected Sub gv_cliente_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_cliente.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'general.OnMouseOver(sender, e)
            If Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_contratos")) + Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_servicios")) + Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_audit")) > 0 Then
                CType(e.Row.Cells(2).Controls(0), ImageButton).Visible = False
            End If
        End If
    End Sub
    
    Protected Sub gv_cliente_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_cliente.RowCommand
        Select Case e.CommandName
            Case "ver"
                Session("id_cliente") = Integer.Parse(gv_cliente.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                WinPopUp1.Show()
            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_cliente_abm.Text = "Edición de datos de un cliente"
                ClienteAbm1.CargarActualizar(Integer.Parse(gv_cliente.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
            Case "eliminar"
                Dim clienteObj As New cliente(Integer.Parse(e.CommandArgument.ToString))
                If clienteObj.num_contratos + clienteObj.num_servicios + clienteObj.num_audit = 0 Then
                    If clienteObj.Eliminar(Profile.id_usuario) Then
                        gv_cliente.DataBind()
                        Msg1.Text = "El usuario se eliminó correctamente"
                    Else
                        Msg1.Text = "El usuario NO se eliminó correctamente"
                    End If
                Else
                    Msg1.Text = "El usuario NO se eliminó correctamente"
                End If
            Case "kardex"
                Session("id_cliente") = Integer.Parse(gv_cliente.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                WinPopUp2.Show()
        End Select
    End Sub
    
    
    Protected Function tipo_cliente(ByVal tipo As String) As String
        If Boolean.Parse(tipo) = True Then
            Return "Transitorio"
        Else
            Return "Permanente"
        End If
    End Function
    Protected Function cedula(ByVal ci As String, ByVal codigo_lugar As String) As String
        If ci = "" Then
            Return ""
        Else
            Return ci & " " & codigo_lugar
        End If
    End Function
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc3:recursoMaster ID="RecursoMaster1" runat="server" recurso="cliente" MostrarLink="true"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:Label ID="lbl_busqueda" runat="server" Text="False" Visible="false"></asp:Label>
    <asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/clienteZona/cliente/clienteDetalle.aspx"
        Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="400"
        Win_Left="100" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True"
        Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="100" Win_Width="800">[WinPopUp1]</asp:WinPopUp>
    <asp:WinPopUp id="WinPopUp2" runat="server" NavigateUrl="~/recurso/clienteZona/kardex/Default.aspx">
    </asp:WinPopUp>
    <table class="priTable">
        <tr><td class="priTdTitle">Clientes</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdDropDown">
                                    <table class="tableDDL">
                                        <tr>
                                            <td class="tdDDLEnun"><asp:Label ID="lbl_tipo_cliente_enun" runat="server" Text="Tipo de cliente:"></asp:Label></td>
                                            <td>
                                                <asp:RadioButtonList ID="rbl_tipo_cliente" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
                                                    <asp:ListItem Text="Todos" Value="-1" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Permanente" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Transitorio" Value="1"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdButton">
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo cliente" />
                                    <asp:Button ID="btn_busqueda" runat="server" Text="Busqueda de clientes" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdBusqueda">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="panel_criterio" runat="server" GroupingText="Criterio de búsqueda" DefaultButton="btn_criterio_buscar" Visible="false">
                                                    <table>
                                                        <tr><td class="tdMsg"><asp:Msg ID="msg_criterio" runat="server"></asp:Msg></td></tr>
                                                        <tr><td class="formHorEntTdForm"><uc1:clienteCriterio ID="ClienteCriterio1" runat="server" /></td></tr>
                                                        <tr>
                                                            <td class="formHorEntTdButton">
                                                                <asp:Button ID="btn_criterio_buscar" runat="server" Text="Buscar" CausesValidation="true" SkinID="btnAccion" ValidationGroup="criterio" />
                                                                <asp:Button ID="btn_criterio_cancelar" runat="server" Text="Cancelar" CausesValidation="false" SkinID="btnAccion" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg"><asp:Msg ID="Msg1" runat="server"></asp:Msg></td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                    <asp:WizardGridView AllowPaging="true" PageSize="20" ID="gv_cliente" runat="server" AutoGenerateColumns="false" DataSourceID="ods_cliente_lista" DataKeyNames="id_cliente">
                                        <Columns>
                                            <%--<asp:TemplateField><ItemTemplate><asp:HyperLink ID="hl_ver" runat="server" SkinID="hlVer" NavigateUrl='<%# String.Format("~/recurso/clienteZona/cliente/clienteDetalle.aspx?id={0}",Eval("id_cliente")) %>'></asp:HyperLink></ItemTemplate></asp:TemplateField>--%>
                                            <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_cliente") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar al cliente?');" /></ItemTemplate></asp:TemplateField>
                                            <asp:ButtonField CommandName="kardex" Text="kardex" ControlStyle-CssClass="gvButton" />
                                            <asp:BoundField HeaderText="Ap.Paterno" DataField="paterno" />
                                            <asp:BoundField HeaderText="Ap.Materno" DataField="materno" />
                                            <asp:BoundField HeaderText="Nombres" DataField="nombres" />
                                            <asp:TemplateField HeaderText="C.I." ItemStyle-CssClass="gvCell1"><ItemTemplate><asp:Label ID="lbl_ci" runat="server" Text='<%# cedula(Eval("ci").ToString(),Eval("codigo_lugarcedula").ToString()) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tipo de cliente"><ItemTemplate><asp:Label ID="lbl_tipo" runat="server" Text='<%# tipo_cliente(Eval("transitorio").ToString()) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                        </Columns>
                                    </asp:WizardGridView>
                                    <%--[id_cliente],[id_lugarcedula],[id_lugarcobro],[id_usuario],[ci],[nit],
                                        [nombres],[paterno],[materno],[fecha_nacimiento],[celular],[fax],[email],[casilla],
                                        [domicilio_direccion],[domicilio_fono],[domicilio_id_zona],
                                        [oficina_direccion],[oficina_fono],[oficina_id_zona],[transitorio],
                                        [codigo_lugarcedula],[nombre_lugarcobro],[nombre_zona_domicilio],[nombre_zona_oficina]
                                        [num_contratos],[num_servicios],[num_audit]--%>
                                    <asp:ObjectDataSource ID="ods_cliente_lista" runat="server" TypeName="terrasur.cliente" SelectMethod="Lista">
                                        <SelectParameters>
                                            <asp:ControlParameter Name="Tipo_cliente" Type="Int32" ControlID="rbl_tipo_cliente" PropertyName="SelectedValue" DefaultValue="-1" />
                                            <asp:ControlParameter Name="Busqueda" Type="Boolean" ControlID="lbl_busqueda" PropertyName="Text" DefaultValue="False" />
                                            <asp:Parameter Name="Ci" Type="String" />
                                            <asp:Parameter Name="Paterno" Type="String" />
                                            <asp:Parameter Name="Materno" Type="String" />
                                            <asp:Parameter Name="Nombres" Type="String" />
                                            <asp:Parameter Name="Num_contrato" Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View id="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_cliente_abm" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm"><uc2:clienteAbm ID="ClienteAbm1" runat="server" /></td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="cliente" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="cliente" />
                                    <asp:Button ID="btn_cancelar" runat="server" Text="<%$ Resources:form, btn_cancelar %>" CausesValidation="false" SkinID="btnAccion" />
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>


