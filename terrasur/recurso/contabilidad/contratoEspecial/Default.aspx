<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Estados especiales de contratos" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/contrato/contratoEstadoEspecial/userControl/estadoEspecialAbm.ascx" TagName="estadoEspecialAbm" TagPrefix="uc2" %>

<%@ Register src="userControl/contratoEspecialAbm.ascx" tagname="contratoEspecialAbm" tagprefix="uc3" %>

<script runat="server">
    Protected Property permiso_insert() As Boolean
        Get
            Return Boolean.Parse(lbl_permiso_insert.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_permiso_insert.Text = value
        End Set
    End Property
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "contratoEspecial", "view") Then
                permiso_insert = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "contratoEspecial", "insert")
                panel_abm.Visible = permiso_insert
                gv_contrato.Columns(1).Visible = permiso_insert
                contratoEspecialAbm1.Reset("", True)
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

  
    
    Protected Sub gv_contrato_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_contrato.DataBound
        gv_contrato.Columns(1).Visible = permiso_insert
    End Sub
    Protected Sub gv_contrato_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_contrato.RowCommand
        If e.CommandName = "cambiar" Then
            Dim ceObj As New contrato_especial(Integer.Parse(e.CommandArgument.ToString), "")
            contratoEspecialAbm1.Reset(ceObj.num_contrato, ceObj.especial.Equals(False))
        End If
    End Sub
    
    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If contratoEspecialAbm1.Insertar() Then
            gv_contrato.DataBind()
        End If
    End Sub

    Protected Function StringCambiarEspecial(ByVal especial As String) As String
        If especial = "1" Then
            Return "No es especial"
        Else
            Return "Es especial"
        End If
    End Function

    Protected Sub gv_contrato_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_contrato.RowDataBound
        general.OnMouseOver(sender, e)
    End Sub
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="contratoEspecial" MostrarLink="true"/>
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:Label ID="lbl_permiso_insert" runat="server" Text="False" Visible="false"></asp:Label>
<table class="priTable">
    <tr><td class="priTdTitle">Cartera especial</td></tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido" align="center">
                <tr>
                    <td class="tdDropDown">
                        <table width="100%">
                            <tr>
                                <td align="left">
                                    <table class="tableDDL" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="tdDDLEnun">Cartera:</td>
                                            <td class="tdDDLEspacio">
                                                <asp:RadioButtonList ID="rbl_especial" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                                                    <asp:ListItem Text="Especial" Value="1" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Normal" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Todos" Value="-1"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td valign="top">
                                    <asp:Panel ID="panel_abm" runat="server" GroupingText="Asignar/Retirar contrato de cartera especial" DefaultButton="btn_insertar">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td><uc3:contratoEspecialAbm ID="contratoEspecialAbm1" runat="server" /></td>
                                                <td valign="bottom"><asp:Button ID="btn_insertar" runat="server" Text="Asignar/Retirar" CausesValidation="true" ValidationGroup="contrato"/></td>
                                            </tr>
                                        </table>
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
                        <asp:GridView ID="gv_contrato" runat="server" AutoGenerateColumns="False" DataSourceID="ods_lista_contratos" DataKeyNames="id_contrato">
                            <Columns>
                                <asp:BoundField HeaderText="Cartera" DataField="especial_string" />
                                <asp:TemplateField><ItemTemplate><asp:LinkButton ID="lb_cambiar" runat="server" Text='<%# StringCambiarEspecial(Eval("especial").ToString()) %>' CommandName="cambiar" CommandArgument='<%# Eval("id_contrato") %>'></asp:LinkButton></ItemTemplate></asp:TemplateField>
                                <asp:BoundField HeaderText="Nº contrato" DataField="num_contrato" ItemStyle-CssClass="gvCell1" />
                                <asp:BoundField HeaderText="Estado" DataField="estado" />
                                <asp:BoundField HeaderText="Lote" DataField="lote" />
                                <asp:BoundField HeaderText="Titular" DataField="titular" />
                                <asp:TemplateField HeaderText="Observación" ><ItemTemplate><asp:Label ID="lbl_observacion" runat="server" Text='<%# Eval("observacion_breve") %>' ToolTip='<%# Eval("observacion") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                <asp:BoundField HeaderText="F.Ult.Pago" DataField="fecha_ultimo_pago" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate"/>
                                <asp:BoundField HeaderText="F.Interés" DataField="interes_fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate"/>
                                <asp:BoundField HeaderText="Nº dias mora" DataField="num_dias_mora" ItemStyle-CssClass="gvCell1" />
                                <asp:BoundField HeaderText="Saldo($us)" DataField="saldo" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                            </Columns>
                        </asp:GridView>
                        <%--[id_contrato],[especial],[especial_string],[num_contrato],[estado],[lote],[titular],
                        [observacion],[observacion_breve],[fecha_ultimo_pago],[interes_fecha],[num_dias_mora],[saldo]--%>
                        <asp:ObjectDataSource ID="ods_lista_contratos" runat="server" TypeName="terrasur.contrato_especial" SelectMethod="Lista">
                            <SelectParameters>
                                <asp:ControlParameter Name="Especial" Type="Int32" ControlID="rbl_especial" PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>

        </td>
    </tr>
    </table>
</asp:Content>

