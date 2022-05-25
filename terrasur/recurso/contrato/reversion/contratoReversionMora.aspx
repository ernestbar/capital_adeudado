<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reversión por mora" %>
<%@ Register Src="~/recurso/contrato/reversion/userControl/reversionMoraAbm.ascx" TagName="reversionMoraAbm" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reversion", "mora_ver") Then
                panel_contratos_mora.Visible = False
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
        
    Protected Sub ddl_negocio_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_negocio.DataBound
        ddl_negocio.Items.Insert(0, New ListItem("Todos", "0"))
        ddl_negocio.SelectedValue = "0"
    End Sub
    
    
    Protected Sub ddl_mora_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_mora.SelectedIndexChanged
        If ddl_mora.SelectedValue = "1" Then
            txt_desde.Visible = True
            txt_hasta.Visible = False
            lbl_guion.Visible = False
            txt_hasta.Text = "0"
            txt_desde.Text = ""
        End If
        If ddl_mora.SelectedValue = "2" Then
            txt_desde.Visible = False
            txt_hasta.Visible = True
            lbl_guion.Visible = False
            txt_hasta.Text = ""
            txt_desde.Text = "0"
        End If
        If ddl_mora.SelectedValue = "3" Then
            txt_desde.Visible = True
            txt_hasta.Visible = True
            lbl_guion.Visible = True
            txt_hasta.Text = ""
            txt_desde.Text = ""
        End If
    End Sub
    
    
    Protected Sub btn_mostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        gv_contratos.DataBind()
        If gv_contratos.Rows.Count > 0 Then
            gv_contratos.Visible = True
            btn_revertir.Visible = True
            panel_contratos_mora.Visible = True
        Else
            gv_contratos.Visible = False
            btn_revertir.Visible = False
            panel_contratos_mora.Visible = False
        End If
    End Sub
    


    Protected Sub btn_revertir_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim seleccion As Boolean = False
        Dim dt As New Data.DataTable
        dt = reversion.ContratosMoraTmp()
        For Each row As GridViewRow In gv_contratos.Rows
            Dim chk As CheckBox = CType(row.FindControl("ckb_contrato"), CheckBox)
            If chk.Checked = True Then
                seleccion = True
                dt.Rows.Add(gv_contratos.DataKeys(row.RowIndex).Value.ToString(), HttpUtility.HtmlDecode(row.Cells(1).Text), row.Cells(2).Text, HttpUtility.HtmlDecode(row.Cells(3).Text.ToString()), HttpUtility.HtmlDecode(row.Cells(4).Text.ToString()), HttpUtility.HtmlDecode(row.Cells(5).Text.ToString()), HttpUtility.HtmlDecode(row.Cells(6).Text), HttpUtility.HtmlDecode(row.Cells(7).Text), HttpUtility.HtmlDecode(row.Cells(8).Text), HttpUtility.HtmlDecode(row.Cells(9).Text), HttpUtility.HtmlDecode(row.Cells(10).Text), HttpUtility.HtmlDecode(row.Cells(11).Text))
            End If
        Next
        If seleccion = True Then
            panel_abm.DefaultButton = "btn_insertar"
            'lbl_manzano_abm.Text = "Reversión por mora"
            ReversionMoraAbm1.grid_contrato.Visible = True
            ReversionMoraAbm1.grid_contrato.DataSource = dt
            ReversionMoraAbm1.grid_contrato.DataBind()
            ReversionMoraAbm1.CargarInsertar()
            btn_insertar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reversion", "mora_ejecutar")
            btn_actualizar.Visible = False
            MultiView1.ActiveViewIndex = 1
        Else
            Msg1.Text = "Seleccione por lo menos un contrato para revertir"
        End If
    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        MultiView1.ActiveViewIndex = 0
    End Sub
    
    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If ReversionMoraAbm1.VerificarInsertar Then
            If ReversionMoraAbm1.Insertar Then
                gv_contratos.DataBind()
                MultiView1.ActiveViewIndex = 0
            End If
        Else
            Msg1.Text = "La reversión NO se guardó correctamente"
        End If
    End Sub
    
    Protected Sub ods_contratos_lista_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ods_contratos_lista.Selecting
        e.InputParameters("Desde") = txt_desde.Text
        e.InputParameters("Hasta") = txt_hasta.Text
    End Sub
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reversion" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<%--<asp:ScriptManager runat="server" ID="ScriptManager1">
</asp:ScriptManager>--%>
<table class="priTable">
        <tr><td class="priTdTitle">Reversión por mora</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="formTdMsg" colspan="2">
                                    <asp:Msg ID="Msg2" runat="server"></asp:Msg>
                                    <asp:ValidationSummary ID="vs_reversion_mora" runat="server" DisplayMode="List" ValidationGroup="reversion_mora" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdFiltro">
                                    <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="formTdEnun"><asp:Label ID="lbl_negocio_enun" runat="server" Text="Negocio:"></asp:Label></td>
                                            <td class="formTdDato">
                                                <asp:DropDownList ID="ddl_negocio" runat="server" AutoPostBack="False" DataSourceID="ods_negocio_lista" DataTextField="nombre" DataValueField="id_negocio"></asp:DropDownList>
                                                <%--[id_localizacion],[nombre]--%>
                                                <asp:ObjectDataSource ID="ods_negocio_lista" runat="server" TypeName="terrasur.negocio" SelectMethod="Lista_por_origen">
                                                    <SelectParameters>
                                                        <asp:Parameter Name="origen" Type="Boolean" DefaultValue="True" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTdEnun"><asp:Label ID="lbl_mora_enun" runat="server" Text="No. días de mora:"></asp:Label></td>
                                            <td class="formTdDato">
                                                <%--<asp:UpdatePanel runat="server" ID="UpdatePanel">
                                                     <ContentTemplate>--%>
                                                <asp:DropDownList ID="ddl_mora" runat="server" AutoPostBack="true">
                                                    <asp:ListItem Value="1">Mayor a</asp:ListItem>
                                                    <asp:ListItem Value="2">Menor a</asp:ListItem>
                                                    <asp:ListItem Selected="True"  Value="3">Entre</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:TextBox ID="txt_desde" runat="server" SkinID="txtSingleLine50"></asp:TextBox><asp:Label ID="lbl_guion" runat="server" Text="-" ></asp:Label><asp:RequiredFieldValidator ID="rfv_desde" runat="server" ControlToValidate="txt_desde"
                                                    Display="Dynamic" SetFocusOnError="true" ValidationGroup="reversion_mora" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="rav_desde" runat="server" Type="Integer" MinimumValue="0"
                                                    MaximumValue="99999" ControlToValidate="txt_desde" Display="Dynamic" ValidationGroup="reversion_mora"
                                                    SetFocusOnError="true" Text="*" ErrorMessage="El valor inicial del número de días de mora contiene caracteres inválidos"></asp:RangeValidator>
                                                <asp:TextBox ID="txt_hasta" runat="server" SkinID="txtSingleLine50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfv_hasta" runat="server" ControlToValidate="txt_hasta"
                                                    Display="Dynamic" SetFocusOnError="true" ValidationGroup="reversion_mora" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="eav_hasta" runat="server" Type="Integer" MinimumValue="0"
                                                    MaximumValue="99999" ControlToValidate="txt_hasta" Display="Dynamic" ValidationGroup="reversion_mora"
                                                    SetFocusOnError="true" Text="*" ErrorMessage="El valor final del número de días de mora contiene caracteres inválidos"></asp:RangeValidator>
                                                     <%--</ContentTemplate>
                                                </asp:UpdatePanel>--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:Button ID="btn_mostrar" runat="server" SkinID="btnAccion"  Text="Mostrar contratos" CausesValidation="true" ValidationGroup="reversion_mora" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdGrid" >
                                <asp:Panel ID="panel_contratos_mora"  runat="server"  ScrollBars="Vertical" Height="350" Width="100%" Visible="false" >
                                    <asp:GridView ID="gv_contratos" runat="server" AutoGenerateColumns="false" DataSourceID="ods_contratos_lista" DataKeyNames="id_contrato" Visible="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ckb_contrato" runat="server"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Negocio" DataField="negocio_nombre" />
                                            <asp:BoundField HeaderText="No. contrato" DataField="num_contrato" ItemStyle-CssClass="gvCell1"/> 
                                            <asp:BoundField HeaderText="Cliente" DataField="cliente_nombre" />
                                            <asp:BoundField HeaderText="Lote" DataField="lote_codigo" />
                                            <asp:BoundField HeaderText="Capital Total" DataField="capital_total" ItemStyle-CssClass="gvCell1"/> 
                                            <asp:BoundField HeaderText="Capital Pagado" DataField="capital_pagado" ItemStyle-CssClass="gvCell1"/> 
                                            <asp:BoundField HeaderText="Capital Adeudado" DataField="capital_adeudado" ItemStyle-CssClass="gvCell1"/>
                                            <asp:BoundField HeaderText="Fecha Prox. Pago" DataField="fecha_prox_pago"  HtmlEncode="false" DataFormatString="{0:d}" ItemStyle-CssClass="gvCell1"/>
                                            <asp:BoundField HeaderText="No. días de mora" DataField="dias_mora" ItemStyle-CssClass="gvCell1"/> 
                                            <asp:BoundField HeaderText="No. cuotas en mora" DataField="cuotas_mora" ItemStyle-CssClass="gvCell1"/>
                                            <asp:BoundField HeaderText="Promotor" DataField="promotor" /> 
                                        </Columns>
                                    </asp:GridView>
                                    <%-- --%>
                                    <asp:ObjectDataSource ID="ods_contratos_lista" runat="server" TypeName="terrasur.reversion" SelectMethod="ListaContratosMora">
                                        <SelectParameters>
                                           <asp:ControlParameter Name="Id_negocio" Type="Int32" ControlID="ddl_negocio" PropertyName="SelectedValue" />
                                           <asp:Parameter Name="Desde" Type="int32" />
                                           <asp:Parameter Name="Hasta" Type="int32" />
                                           <%--<asp:ControlParameter Name="Desde" Type="Int32" ControlID="txt_desde" PropertyName="Text" />
                                           <asp:ControlParameter Name="Hasta" Type="Int32" ControlID="txt_hasta" PropertyName="Text" />--%>
                                       </SelectParameters>
                                    </asp:ObjectDataSource>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:Button ID="btn_revertir" runat="server" Text="Revertir contrato(s)"  Visible="false" OnClick="btn_revertir_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View id="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_manzano_abm" runat="server"></asp:Label></td></tr>
                            <tr>
                                <td class="tdButton" colspan="2">
                                    <asp:Button ID="btn_volver" runat="server" Text="Revertir otros contratos" />
                                </td>
                            </tr>
                            <tr><td class="formEntTdForm">
                                <uc1:reversionMoraAbm ID="ReversionMoraAbm1" runat="server" />

                           </td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="Confirmar reversión" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="manzano" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="manzano" />
                                    <asp:Button ID="btn_cancelar" runat="server" Text="<%$ Resources:form, btn_cancelar %>" CausesValidation="false" SkinID="btnAccion" Visible="false"  />
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

