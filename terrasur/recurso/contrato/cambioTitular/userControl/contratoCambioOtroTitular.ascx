<%@ Control Language="VB" ClassName="contratoCambioOtroTitular" %>
<%@ Register Src="~/recurso/contrato/cambioTitular/userControl/contratoCambioFormOtroTitular.ascx" TagName="contratoCambioFormOtroTitular" TagPrefix="uc1" %>

<script runat="server">
    Public Property id_contrato() As Integer
        Get
            Return Integer.Parse(lbl_id_contrato.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_contrato.Text = value
            gv_clientes.DataBind()
            btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cambioTitular", "otro_titular")
            MultiView1.ActiveViewIndex = 0
        End Set
    End Property

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        OtroTitular1.Reset(id_contrato)
        btn_insertar.Enabled = True
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If OtroTitular1.Verificar Then
            Dim nuevo_id_titular As Integer = 0
            If OtroTitular1.id_cliente > 0 Then
                nuevo_id_titular = OtroTitular1.id_cliente
            Else
                Dim clienteObj As New cliente(OtroTitular1.id_lugarcedula, 0, OtroTitular1.ci, OtroTitular1.nit, OtroTitular1.nombres, OtroTitular1.paterno, OtroTitular1.materno, DateTime.Now, OtroTitular1.celular, "", OtroTitular1.email, "", "", "", 0, "", "", 0, False)
                If clienteObj.Insertar(Profile.id_usuario) Then
                    nuevo_id_titular = clienteObj.id_cliente
                Else
                    Msg1.Text = "El titular adicional NO se agregó correctamente"
                End If
            End If
            If nuevo_id_titular > 0 Then
                Dim nuevoTitularObj As New cliente_contrato(nuevo_id_titular, id_contrato, False)
                If nuevoTitularObj.Insertar(Profile.id_usuario) Then
                    Msg1.Text = "El titular adicional se agregó correctamente"
                    gv_clientes.DataBind()
                    OtroTitular1.Reset(id_contrato)
                    btn_insertar.Enabled = False
                Else
                    Msg1.Text = "El titular adicional NO se agregó correctamente"
                End If
            End If
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub gv_clientes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_clientes.DataBound
        gv_clientes.Columns(0).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cambioTitular", "otro_titular")
    End Sub

    Protected Sub gv_clientes_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_clientes.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            CType(e.Row.Cells(0).Controls(0), LinkButton).OnClientClick = "return confirm('¿Esta seguro que desea retirar al titular adicional del contrato?');"
        End If
    End Sub

    Protected Sub gv_clientes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_clientes.RowCommand
        If e.CommandName = "retirar" Then
            Dim titularObj As New cliente_contrato(Integer.Parse(gv_clientes.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString), id_contrato)
            If titularObj.Eliminar(Profile.id_usuario) Then
                Msg1.Text = "El titular adicional se retiró correctamente"
                gv_clientes.DataBind()
            Else
                Msg1.Text = "El titular adicional NO se retiró correctamente"
            End If
        End If
    End Sub
</script>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<table align="center">
    <tr>
        <td>
            <asp:Panel ID="panel_primer" runat="server" GroupingText="Otros titulares del contrato">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                    <asp:GridView ID="gv_clientes" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_cliente" DataKeyNames="id_cliente">
                                        <Columns>
                                            <asp:ButtonField Text="Retirar" CommandName="retirar" ControlStyle-CssClass="gvButton" />
                                            <asp:BoundField HeaderText="C.I." DataField="ci" />
                                            <asp:BoundField HeaderText="Nombre completo" DataField="nombre_completo" />
                                            <asp:BoundField HeaderText="NIT" DataField="nit" />
                                            <asp:BoundField HeaderText="Teléfono" DataField="celular" />
                                            <asp:BoundField HeaderText="Email" DataField="email" />
                                        </Columns>
                                        <EmptyDataTemplate>No existen clientes adicionales</EmptyDataTemplate>
                                    </asp:GridView>
                                    <%--[id_cliente],[ci],[nombre_completo],[nit],[celular],[email]--%>
                                    <asp:ObjectDataSource ID="ods_lista_cliente" runat="server" TypeName="terrasur.cliente_contrato" SelectMethod="ListaClientesAdicionales">
                                        <SelectParameters>
                                            <asp:ControlParameter Name="Id_contrato" Type="Int32" ControlID="lbl_id_contrato" PropertyName="Text" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdButtonRealizarAccion1">
                                    <asp:Button ID="btn_nuevo" runat="server" Text="Añadir titular" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg2" runat="server"></asp:Msg>
                                    <asp:ValidationSummary ID="vs_contrato" runat="server" DisplayMode="List" ValidationGroup="contrato" />
                                </td>
                            </tr>
                            <tr><td><uc1:contratoCambioFormOtroTitular id="OtroTitular1" runat="server"></uc1:contratoCambioFormOtroTitular></td></tr>
                            <tr>
                                <td class="tdButtonRealizarAccion1">
                                    <asp:Button ID="btn_insertar" runat="server" Text="Agregar titular" CausesValidation="true" ValidationGroup="cliente" />
                                    <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </asp:Panel>
        </td>
    </tr>
</table>