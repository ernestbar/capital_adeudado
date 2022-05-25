<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Registro de Negocios y Folios (dpto. Legal)" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register src="~/recurso/legal/negocioFolio/userControl/legalNegocioAbm.ascx" tagname="legalNegocioAbm" tagprefix="uc5" %>
<%@ Register src="~/recurso/legal/negocioFolio/userControl/legalFolioAbm.ascx" tagname="legalFolioAbm" tagprefix="uc6" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler legalNegocioAbm1.NegocioLoteElegido, AddressOf ActualizarUnNegocio
        AddHandler legalNegocioAbm1.NegocioTodosElegido, AddressOf ActualizarVariosNegocios
        AddHandler legalNegocioAbm1.CancelarElegido, AddressOf CancelarRegistro
        
        
        AddHandler legalFolioAbm1.FolioLoteElegido, AddressOf ActualizarUnFolio
        AddHandler legalFolioAbm1.FolioTodosElegido, AddressOf ActualizarVariosFolios
        AddHandler legalFolioAbm1.CancelarElegido, AddressOf CancelarRegistro

        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "negocioFolio", "view") Then
                btn_nuevo_negocio.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "negocioFolio", "insert_varios_negocios")
                btn_nuevo_folio.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "negocioFolio", "insert_varios_folios")

                legalFolioAbm1.Visible = False
                legalNegocioAbm1.Visible = False
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    
    Protected Sub ddl_localizacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_localizacion.SelectedIndexChanged
        ddl_urbanizacion.DataBind()
        'ddl_manzano.DataBind()
    End Sub

    Protected Sub ddl_urbanizacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_urbanizacion.SelectedIndexChanged
        ddl_manzano.DataBind()
    End Sub

    Protected Sub ddl_manzano_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_manzano.DataBound
        'ddl_manzano.Items.Insert(0, New ListItem("Todos", "0"))
        ddl_manzano.Items.Add(New ListItem("Todos", "0"))
    End Sub

    Protected Sub btn_nuevo_negocio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo_negocio.Click
        If legalNegocioAbm1.Visible = False Then
            legalNegocioAbm1.Visible = True
            legalNegocioAbm1.id_lote = 0
        Else
            If legalNegocioAbm1.id_lote > 0 Then
                legalNegocioAbm1.id_lote = 0
            Else
                legalNegocioAbm1.Visible = False
            End If
        End If
        legalFolioAbm1.Visible = False
    End Sub

    Protected Sub btn_nuevo_folio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo_folio.Click
        If legalFolioAbm1.Visible = False Then
            legalFolioAbm1.Visible = True
            legalFolioAbm1.id_lote = 0
        Else
            If legalFolioAbm1.id_lote > 0 Then
                legalFolioAbm1.id_lote = 0
            Else
                legalFolioAbm1.Visible = False
            End If
        End If
        legalNegocioAbm1.Visible = False
    End Sub


    Protected Sub gv_lote_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_lote.DataBound
        gv_lote.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "negocioFolio", "detalle")
        gv_lote.Columns(2).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "negocioFolio", "update_negocio")
        gv_lote.Columns(3).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "negocioFolio", "update_folio")

        btn_nuevo_negocio.Enabled = gv_lote.Rows.Count.Equals(0).Equals(False)
        btn_nuevo_folio.Enabled = gv_lote.Rows.Count.Equals(0).Equals(False)
    End Sub

    Protected Sub gv_lote_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_lote.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            general.OnMouseOver(sender, e)
        End If
    End Sub


    Protected Sub gv_lote_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_lote.RowCommand
        Select Case e.CommandName
            Case "ver"
                Session("id_lote") = Integer.Parse(gv_lote.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                WinPopUp1.Show()
            Case "actualizar_negocio"
                legalNegocioAbm1.Visible = True
                legalNegocioAbm1.id_lote = Integer.Parse(gv_lote.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                legalFolioAbm1.Visible = False
            Case "actualizar_folio"
                legalFolioAbm1.Visible = True
                legalFolioAbm1.id_lote = Integer.Parse(gv_lote.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                legalNegocioAbm1.Visible = False
        End Select
    End Sub

    Protected Function ObservacionReducida(ByVal Observacion As String, ByVal num_caracteres As Integer) As String
        If Observacion.Trim <> "" And Observacion.Length > num_caracteres Then
            Return Observacion.Substring(0, num_caracteres) + "..."
        ElseIf Observacion.Trim <> "" And Observacion.Length <= num_caracteres Then
            Return Observacion
        Else
            Return ""
        End If
    End Function

    Protected Sub cb_todos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        For Each fila As GridViewRow In gv_lote.Rows
            If fila.RowType = DataControlRowType.DataRow Then
                If fila.FindControl("cb_lote") IsNot Nothing Then
                    CType(fila.FindControl("cb_lote"), CheckBox).Checked = CType(sender, CheckBox).Checked
                End If
            End If
        Next
    End Sub
    
    
    Protected Sub ActualizarUnNegocio(ByVal sender As Object, ByVal e As System.EventArgs)
        If New legal_negocio_lote(legalNegocioAbm1.id_negocio, legalNegocioAbm1.id_lote, legalNegocioAbm1.id_estadotramite, legalNegocioAbm1.fecha).Insertar(Profile.id_usuario) = True Then
            gv_lote.DataBind()
            Msg1.Text = "El negocio del lote se actualizó correctamente"
        Else
            Msg1.Text = "El negocio del lote NO se actualizó correctamente"
        End If
    End Sub
    Protected Sub ActualizarVariosNegocios(ByVal sender As Object, ByVal e As System.EventArgs)
        If ExistenLotesMarcados() = True Then
            Dim num_marcados As Integer = 0, num_marcados_correctos As Integer = 0
            For Each fila As GridViewRow In gv_lote.Rows
                If fila.RowType = DataControlRowType.DataRow _
                AndAlso fila.FindControl("cb_lote") IsNot Nothing _
                AndAlso CType(fila.FindControl("cb_lote"), CheckBox).Checked = True Then
                    num_marcados += 1
                    Dim fila_id_lote As Integer = Integer.Parse(CType(fila.FindControl("lbl_id_lote"), Label).Text)
                    If New legal_negocio_lote(legalNegocioAbm1.id_negocio, fila_id_lote, legalNegocioAbm1.id_estadotramite, legalNegocioAbm1.fecha).Insertar(Profile.id_usuario) = True Then
                        num_marcados_correctos += 1
                    End If
                End If
            Next
            Msg1.Text = "Se registraron correctamente " & num_marcados_correctos & " negocio(s) de " & num_marcados & " lote(s) seleccionado(s)"
            If num_marcados_correctos > 0 Then
                gv_lote.DataBind()
            End If
        Else
            Msg1.Text = "Debe seleccionar los lotes que desea actualizar"
        End If
    End Sub
    
    
    Protected Sub ActualizarUnFolio(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim fObj As New legal_folio(legalFolioAbm1.id_lote, legalFolioAbm1.num_folio, legalFolioAbm1.entregado, legalFolioAbm1.entregado_fecha)
        If fObj.Insertar(Profile.id_usuario) = True Then
            Dim oObj As New legal_folio_observacion(fObj.id_folio, legalFolioAbm1.observacion)
            oObj.Insertar(Profile.id_usuario)
            gv_lote.DataBind()
            Msg1.Text = "El Folio del lote se asignó correctamente"
        Else
            Msg1.Text = "El Folio del lote NO se asignó correctamente"
        End If
    End Sub
    Protected Sub ActualizarVariosFolios(ByVal sender As Object, ByVal e As System.EventArgs)
        If ExistenLotesMarcados() = True Then
            Dim num_marcados As Integer = 0, num_marcados_correctos As Integer = 0
            For Each fila As GridViewRow In gv_lote.Rows
                If fila.RowType = DataControlRowType.DataRow _
                AndAlso fila.FindControl("cb_lote") IsNot Nothing _
                AndAlso CType(fila.FindControl("cb_lote"), CheckBox).Checked = True Then
                    num_marcados += 1
                    Dim fila_id_lote As Integer = Integer.Parse(CType(fila.FindControl("lbl_id_lote"), Label).Text)
                    Dim fObj As New legal_folio(fila_id_lote, legalFolioAbm1.num_folio, legalFolioAbm1.entregado, legalFolioAbm1.entregado_fecha)
                    If fObj.Insertar(Profile.id_usuario) = True Then
                        Dim oObj As New legal_folio_observacion(fObj.id_folio, legalFolioAbm1.observacion)
                        oObj.Insertar(Profile.id_usuario)

                        num_marcados_correctos += 1
                    End If
                End If
            Next
            Msg1.Text = "Se registraron correctamente " & num_marcados_correctos & " folio(s) de " & num_marcados & " lote(s) seleccionado(s)"
            If num_marcados_correctos > 0 Then
                gv_lote.DataBind()
            End If
        Else
            Msg1.Text = "Debe seleccionar los lotes que desea actualizar"
        End If
    End Sub
    
    
    Protected Function ExistenLotesMarcados() As Boolean
        Dim existen As Boolean = False
        For Each fila As GridViewRow In gv_lote.Rows
            If fila.RowType = DataControlRowType.DataRow AndAlso fila.FindControl("cb_lote") IsNot Nothing Then
                If CType(fila.FindControl("cb_lote"), CheckBox).Checked = True Then
                    existen = True
                    Exit For
                End If
            End If
        Next
        Return existen
    End Function

    
    Protected Sub CancelarRegistro(ByVal sender As Object, ByVal e As System.EventArgs)
        If legalNegocioAbm1.Visible = True Then
            legalNegocioAbm1.Visible = False
        End If
        If legalFolioAbm1.Visible = True Then
            legalFolioAbm1.Visible = False
        End If
    End Sub

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="negocioFolio" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/legal/negocioFolio/legalLoteDetalle.aspx" Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="400" Win_Left="100" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True" Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="100" Win_Width="800">[WinPopUp1]</asp:WinPopUp>

    <table class="priTable">
        <tr><td class="priTdTitle">Registro de Negocios y Folios (dpto. Legal)</td></tr>
        <tr>
            <td class="priTdContenido">
                <table class="tableContenido" align="center">
                    <tr>
                        <td class="tdDropDown">
                            <table class="tableDDL">
                                <tr>
                                    <td class="tdDDLEnun"><asp:Label ID="lbl_localizacion_enun" runat="server" Text="Localización:"></asp:Label></td>
                                    <td class="tdDDLEspacio">
                                        <asp:DropDownList ID="ddl_localizacion" runat="server" AutoPostBack="true" DataSourceID="ods_localizacion_lista" DataTextField="nombre" DataValueField="id_localizacion"></asp:DropDownList>
                                        <%--[id_localizacion],[nombre]--%>
                                        <asp:ObjectDataSource ID="ods_localizacion_lista" runat="server" TypeName="terrasur.localizacion" SelectMethod="Lista"></asp:ObjectDataSource>
                                    </td>
                                    <td class="tdDDLEnun"><asp:Label ID="lbl_urbanizacion_enun" runat="server" Text="Sector:"></asp:Label></td>
                                    <td class="tdDDLEspacio">
                                        <asp:DropDownList ID="ddl_urbanizacion" runat="server" AutoPostBack="true" DataSourceID="ods_urb_lista" DataTextField="nombre_completo" DataValueField="id_urbanizacion"></asp:DropDownList>
                                        <%--[id_urbanizacion],[nombre_completo]--%>
                                        <asp:ObjectDataSource ID="ods_urb_lista" runat="server" TypeName="terrasur.urbanizacion" SelectMethod="Lista_para_ddl">
                                            <SelectParameters>
                                                <asp:ControlParameter Name="Id_localizacion" Type="Int32" ControlID="ddl_localizacion" PropertyName="SelectedValue" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                   <td class="tdDDLEnun"><asp:Label ID="lbl_manzano_enun" runat="server" Text="Manzano:"></asp:Label></td>
                                   <td class="tdDDLEspacio">
                                        <asp:DropDownList ID="ddl_manzano" runat="server" AutoPostBack="true" DataSourceID="ods_manzano_lista" DataTextField="codigo" DataValueField="id_manzano"></asp:DropDownList>
                                        <%--[id_manzano],[codigo]--%>
                                        <asp:ObjectDataSource ID="ods_manzano_lista" runat="server" TypeName="terrasur.manzano" SelectMethod="Lista">
                                            <SelectParameters>
                                                <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="ddl_urbanizacion" PropertyName="SelectedValue" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdButton">
                            <asp:Button ID="btn_nuevo_negocio" runat="server" Text="Registro de Negocios" />
                            <asp:Button ID="btn_nuevo_folio" runat="server" Text="Registro de Folios" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table cellpadding="0" cellspacing="0">
                                <tr><td><uc5:legalNegocioAbm ID="legalNegocioAbm1" runat="server" /></td></tr>
                                <tr><td><uc6:legalFolioAbm ID="legalFolioAbm1" runat="server" /></td></tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdMsg">
                            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                            <asp:ValidationSummary ID="vs_lote" runat="server" DisplayMode="List" ValidationGroup="lote" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdGrid" >
                            <asp:Panel ID="panel_lote" runat="server" ScrollBars="Vertical" Height="400">
                                <asp:GridView ID="gv_lote" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lote_lista" DataKeyNames="id_lote">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate><asp:CheckBox ID="cb_todos" runat="server" AutoPostBack="true" OnCheckedChanged="cb_todos_CheckedChanged" /></HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cb_lote" runat="server" />
                                                <asp:Label ID="lbl_id_lote" runat="server" Text='<%# Eval("id_lote") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                        <asp:ButtonField CommandName="actualizar_negocio" Text="Negocio" ControlStyle-CssClass="gvButton" />
                                        <asp:ButtonField CommandName="actualizar_folio" Text="Folio" ControlStyle-CssClass="gvButton" />
                                        <asp:BoundField HeaderText="Mzno." DataField="manzano" />
                                        <asp:BoundField HeaderText="Lote" DataField="lote" />
                                        <asp:BoundField HeaderText="Sup.(m2)" DataField="superficie" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1"/>
                                        <asp:BoundField HeaderText="Estado" DataField="estado" />

                                        <asp:BoundField HeaderText="Neg.Nombre" DataField="legal_negocio" />
                                        <asp:BoundField HeaderText="Neg.Fecha" DataField="legal_negocio_fecha" HtmlEncode="false" DataFormatString="{0:d}" ItemStyle-CssClass="gvCell1"/>
                                        <asp:BoundField HeaderText="Neg.Estado" DataField="legal_negocio_estado" />
                                        
                                        <asp:BoundField HeaderText="Folio Número" DataField="folio_numero" />
                                        <asp:BoundField HeaderText="Fol.Entregado" DataField="folio_entregado" />
                                        <asp:BoundField HeaderText="Fol.Entr.Fecha" DataField="folio_entregado_fecha" HtmlEncode="false" DataFormatString="{0:d}" ItemStyle-CssClass="gvCell1"/>
                                        
                                        <asp:TemplateField HeaderText="Observación"><ItemTemplate><asp:Label ID="lbl_observacion" runat="server" Text='<%# ObservacionReducida(Eval("observacion").ToString(),15) %>' ToolTip='<%# Eval("observacion") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            <%--[id_lote],[manzano],[lote],[superficie],[estado]
                            [legal_negocio],[legal_negocio_fecha],[legal_negocio_estado]
                            [folio_numero],[folio_entregado],[folio_entregado_fecha],[observacion]--%>
                            <asp:ObjectDataSource ID="ods_lote_lista" runat="server" TypeName="terrasur.legal_negocio_lote" SelectMethod="ListaLotes">
                                <SelectParameters>
                                   <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="ddl_urbanizacion" PropertyName="SelectedValue" />
                                   <asp:ControlParameter Name="Id_manzano" Type="Int32" ControlID="ddl_manzano" PropertyName="SelectedValue" />
                               </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

