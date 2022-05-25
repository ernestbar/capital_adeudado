<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Asignación de número de seguro" %>
<%@ Register src="~/recurso/contabilidad/seguro/userControl/seguroAbm.ascx" tagname="seguroAbm" tagprefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/contratoBusqueda.ascx" TagName="contratoBusqueda" TagPrefix="uc3" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler ContratoBusqueda1.Eleccion, AddressOf busqueda_realizada
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguro", "view") Then
                'btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguro", "insert")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    Protected Sub busqueda_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        lbl_id_contrato.Text = ContratoBusqueda1.id_resultado
        gv_seguro.DataBind()
    End Sub

    
    
    Protected Sub gv_seguro_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_seguro.DataBound
        gv_seguro.Columns(0).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguro", "asignar")
    End Sub

    Protected Sub gv_seguro_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_seguro.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'general.OnMouseOver(sender, e)
            'CType(e.Row.Cells(2).Controls(0), ImageButton).Visible = Integer.Parse(DataBinder.Eval(e.Row.DataItem, "num_lote").ToString).Equals(0)
        End If
    End Sub

    Protected Sub gv_seguro_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_seguro.RowCommand
        Select Case e.CommandName
            Case "asignar"
                seguroAbm1.Cargar(Integer.Parse(gv_seguro.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                MultiView1.ActiveViewIndex = 1
        End Select
    End Sub
   
    Protected Sub btn_asignar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_asignar.Click
        If seguroAbm1.Asignar Then
            gv_seguro.DataBind()
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub btn_buscar_seguro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscar_seguro.Click
        If txt_num_seguro.Text.Trim <> "" Then
            Dim n As Integer
            If Integer.TryParse(txt_num_seguro.Text.Trim, n) = True Then
                Dim id_contr As Integer = Integer.Parse(seguro_provida.Num_contrato_por_seguro(0, n, True))
                If id_contr > 0 Then
                    lbl_id_contrato.Text = id_contr
                    gv_seguro.DataBind()
                Else
                    Msg1.Text = "El número de seguro " & n.ToString & " no esta asignado a ningún contrato"
                End If
            Else
                Msg1.Text = "El número del formulario de seguro no es válido"
            End If
        Else
            Msg1.Text = "Debe introducir el número del formulario de seguro"
        End If
        txt_num_seguro.Focus()
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="seguro" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
    <asp:Label ID="lbl_id_cliente" runat="server" Text="0" Visible="false"></asp:Label>
    
    <table class="priTable">
        <tr><td class="priTdTitle">Asignación de seguros a contratos</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdButton">
                                    <table cellpadding="0" cellspacing="0" align="center">
                                        <tr><td><uc3:contratoBusqueda ID="ContratoBusqueda1" runat="server" buscar_contrato="true" /></td></tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="panel_numero_seguro" runat="server" GroupingText="Búsqueda de contrato por número de seguro" DefaultButton="btn_buscar_seguro" HorizontalAlign="Center">
                                                    <asp:Label ID="lbl_num_seguro_enun" runat="server" Text="Nº form. seguro:" SkinID="lblEnun"></asp:Label>
                                                    <asp:TextBox ID="txt_num_seguro" runat="server" SkinID="txtSingleLine100" MaxLength="5"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="rfv_num_seguro" runat="server" ControlToValidate="txt_num_seguro" Display="Dynamic" Text="*" ErrorMessage="Debe digitar el número de seguro" ValidationGroup="buscar_seguro"></asp:RequiredFieldValidator>--%>
                                                    <asp:RangeValidator ID="rv_num_seguro" runat="server" ControlToValidate="txt_num_seguro" Type="Integer" MinimumValue="0" MaximumValue="99999" Display="Dynamic" Text="*" ErrorMessage="Debe digitar un número entero válido" ValidationGroup="buscar_seguro"></asp:RangeValidator>
                                                    <asp:ButtonAction ID="btn_buscar_seguro" runat="server" Text="Buscar" TextoEnviando="Buscando" CausesValidation="true" ValidationGroup="buscar_seguro"/>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                    <asp:GridView ID="gv_seguro" runat="server" AutoGenerateColumns="false" DataSourceID="ods_seguro_lista" DataKeyNames="id_contrato">
                                        <Columns>
                                            <asp:ButtonField CommandName="asignar" Text="Asignar seguro" ControlStyle-CssClass="gvButton" />
                                            <asp:BoundField HeaderText="Nº contrato" DataField="num_contrato" ItemStyle-CssClass="gvCell1"/>
                                            <asp:BoundField HeaderText="Estado" DataField="estado"/>
                                            <asp:BoundField HeaderText="Nº seguro" DataField="num_seguro" ItemStyle-CssClass="gvCell1"/>
                                            <asp:BoundField HeaderText="F.Registro" DataField="fecha_registro" HtmlEncode="false" DataFormatString="{0:d}" />
                                            <asp:BoundField HeaderText="Usuario" DataField="usuario"/>
                                            <asp:BoundField HeaderText="% seg." DataField="porcentaje_seguro" ItemStyle-CssClass="gvCell1"/>
                                            <asp:BoundField HeaderText="Cliente" DataField="cliente"/>
                                            <asp:BoundField HeaderText="Tipo de contrato" DataField="tipo_contrato"/>
                                            <asp:BoundField HeaderText="Lote" DataField="lote"/>
                                        </Columns>
                                    </asp:GridView>
                                    <%-- [id_contrato],[num_contrato],[estado],[num_seguro],[fecha_registro],[usuario],[porcentaje_seguro],[cliente],[tipo_contrato],[lote]--%>
                                    <asp:ObjectDataSource ID="ods_seguro_lista" runat="server" TypeName="terrasur.seguro_provida" SelectMethod="Lista">
                                        <SelectParameters>
                                           <asp:ControlParameter Name="Id_contrato" Type="Int32" ControlID="lbl_id_contrato" PropertyName="Text" />
                                           <asp:ControlParameter Name="Id_cliente" Type="Int32" ControlID="lbl_id_cliente" PropertyName="Text" />
                                       </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View id="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server" DefaultButton="btn_asignar">
                            <table class="formEntTable">
                                <tr><td class="formEntTdTitle">Asignación de seguro</td></tr>
                                <tr><td class="formEntTdForm"><uc1:seguroAbm ID="seguroAbm1" runat="server"/></td></tr>
                                <tr>
                                    <td class="formEntTdButton">
                                        <asp:ButtonAction ID="btn_asignar" runat="server" Text="Asignar" TextoEnviando="Asignando" CausesValidation="true" ValidationGroup="seguro" />
                                        <asp:Button ID="btn_cancelar" runat="server" Text="<%$ Resources:form, btn_cancelar %>" SkinID="btnAccion" />
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

