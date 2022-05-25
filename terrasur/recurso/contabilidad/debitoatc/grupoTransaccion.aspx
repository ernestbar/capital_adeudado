<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Debito automático" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register src="~/recurso/contabilidad/debitoatc/userControl/grupoTransaccionAbm.ascx" tagname="grupoTransaccionAbm" tagprefix="uc2" %>
<%@ Register src="~/recurso/contabilidad/debitoatc/userControl/tarjetaArchivoRespuesta.ascx" tagname="tarjetaArchivoRespuesta" tagprefix="uc3" %>

<script runat="server">
    Protected Property id_grupotransaccion() As Integer
        Get
            Return Integer.Parse(lbl_id_grupotransaccion.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_grupotransaccion.Text = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "grupoTransaccion", "view") Then
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "grupoTransaccion", "insert")
                btn_tarjeta_credito.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tarjetaCredito", "view")
                btn_reporte.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "grupoTransaccion", "reporteDebitosAceptados")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        panel_abm.DefaultButton = "btn_insertar"
        lbl_grupo_abm.Text = "Generación de debitos a realizar"
        grupoTransaccionAbm1.CargarInsertar()
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insertar.Click
        If grupoTransaccionAbm1.Insertar Then
            gv_grupo.DataBind()
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        If grupoTransaccionAbm1.Actualizar Then
            gv_grupo.DataBind()
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub gv_grupo_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_grupo.DataBound
        gv_grupo.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "grupoTransaccion", "update")
        gv_grupo.Columns(2).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "grupoTransaccion", "delete")
        gv_grupo.Columns(3).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "grupoTransaccion", "generar_txt")
        gv_grupo.Columns(4).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "grupoTransaccion", "cargar_txt")
    End Sub

    Protected Sub gv_grupo_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_grupo.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            general.OnMouseOver(sender, e)
            '[id_grupotransaccion],[estado],[numero],[fecha_debito],[periodo_debito],[usuario],[num_debitos],
            '[num_debitos_efectivos], [monto_debitos], [monto_debitos_efectivos], [enviado], [num_archivos_respuesta]
            If Boolean.Parse(DataBinder.Eval(e.Row.DataItem, "enviado")) = True Then
                CType(e.Row.Cells(1).Controls(0), ImageButton).Visible = False
                CType(e.Row.Cells(2).Controls(0), ImageButton).Visible = False
            Else
                e.Row.Cells(4).Enabled = False
            End If
            'e.Row.Cells(4).Enabled = False
        End If
    End Sub

    Protected Sub gv_grupo_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_grupo.RowCommand
        Select Case e.CommandName
            Case "ver"
                Session("id_grupotransaccion") = Integer.Parse(gv_grupo.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                WinPopUp1.Show()
            Case "editar"
                Dim gtObj As New grupo_transaccion(Integer.Parse(gv_grupo.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                If gtObj.enviado = False Then
                    panel_abm.DefaultButton = "btn_actualizar"
                    lbl_grupo_abm.Text = "Edición de debitos a realizar"
                    grupoTransaccionAbm1.CargarActualizar(Integer.Parse(gv_grupo.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                    btn_insertar.Visible = False
                    btn_actualizar.Visible = True
                    MultiView1.ActiveViewIndex = 1
                Else
                    Msg1.Text = "El grupo de debitos no se puede editar porque el archivo TXT ya fue generado"
                End If
            Case "eliminar"
                Dim gtObj As New grupo_transaccion(Integer.Parse(e.CommandArgument.ToString))
                If gtObj.enviado = False Then
                    If gtObj.Eliminar(Profile.id_usuario) Then
                        gv_grupo.DataBind()
                        Msg1.Text = "La tarjeta de crédito se eliminó correctamente"
                    Else
                        Msg1.Text = "La tarjeta de crédito NO se eliminó correctamente"
                    End If
                Else
                    Msg1.Text = "El grupo de debitos no se puede eliminar porque el archivo TXT ya fue generado"
                End If
            Case "generar_txt"
                id_grupotransaccion = Integer.Parse(gv_grupo.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                Dim gtObj As New grupo_transaccion(id_grupotransaccion)
                lbl_numero_grupo.Text = gtObj.numero
                lbl_periodo.Text = gtObj.periodo_deuda_mes + "/20" + gtObj.periodo_deuda_anio
                lbl_fecha_debito.Text = gtObj.fecha_debito.ToString("d")
                lbl_transaccion.Text = gtObj.num_transacciones
                MultiView1.ActiveViewIndex = 2
            Case "respuesta_txt"
                tarjetaArchivoRespuesta1.Cargar(Integer.Parse(gv_grupo.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                MultiView1.ActiveViewIndex = 3
        End Select
    End Sub

    Protected Function DatosParcialTotal(ByVal Parcial As String, ByVal Total As String, ByVal EsDecimal As String) As String
        If EsDecimal = False Then
            Return Parcial & " de " & Total
        Else
            Return Decimal.Parse(Parcial).ToString("F2") & " de " & Decimal.Parse(Total).ToString("F2")
        End If
    End Function

    Protected Sub btn_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/contabilidad/debitoatc/debitosAceptados.aspx")
        'WinPopUp3.Show()
    End Sub

    
    
    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        gv_grupo.DataBind()
        MultiView1.ActiveViewIndex = 0
    End Sub
    Protected Sub btn_generar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gtObj As New grupo_transaccion(id_grupotransaccion)
        grupo_transaccion.RegistrarEnviado(id_grupotransaccion, Profile.id_usuario)
        gv_grupo.DataBind()
        Dim sb As StringBuilder = tarjeta_credito_transaccion.ListaTransacciones(id_grupotransaccion)
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "text/plain"
        Response.AddHeader("Content-Disposition", "attachment;filename=Debitos_" & gtObj.numero & "_" & gtObj.fecha_debito.ToString("ddMMyyyy") & ".txt")
        Response.Charset = "UTF-8"
        Response.ContentEncoding = Encoding.Default
        Response.Write(sb.ToString().TrimEnd(";").Replace(";", vbNewLine))
        Response.End()
    End Sub

    Protected Sub btn_tarjeta_credito_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/recurso/contabilidad/debitoatc/tarjetaCredito.aspx")
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="grupoTransaccion"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:Label ID="lbl_id_grupotransaccion" runat="server" Text="0" Visible="false"></asp:Label>
    <asp:WinPopUp id="WinPopUp1" runat="server" NavigateUrl="~/recurso/contabilidad/debitoatc/grupoTransaccionDetalle.aspx" ></asp:WinPopUp>
    <%--<asp:WinPopUp id="WinPopUp3" runat="server" NavigateUrl="~/recurso/contabilidad/debitoatc/debitosAceptados.aspx" ></asp:WinPopUp>--%>
    <table class="priTable">
        <tr><td class="priTdTitle">Debito automático</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdButton">
                                    <%--<table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="left"></td>
                                            <td align="right"><asp:Button ID="btn_tarjeta_credito" runat="server" Text="Tarjetas de crédito" OnClick="btn_tarjeta_credito_Click" /></td>
                                        </tr>
                                        <tr>
                                            <td align="left"><asp:Button ID="btn_nuevo" runat="server" Text="Nuevo grupo de debitos" /></td>
                                            <td align="right"><asp:Button ID="btn_reporte" runat="server" Text="Reporte de debitos aceptados" OnClick="btn_reporte_Click" /></td>
                                        </tr>
                                    </table>--%>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="left"><asp:Button ID="btn_nuevo" runat="server" Text="Nuevo grupo de debitos" /></td>
                                            <td align="right"><asp:Button ID="btn_tarjeta_credito" runat="server" Text="Tarjetas de crédito" OnClick="btn_tarjeta_credito_Click" /></td>
                                            <td align="right"><asp:Button ID="btn_reporte" runat="server" Text="Reporte de debitos aceptados" OnClick="btn_reporte_Click" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg"><asp:Msg ID="Msg1" runat="server"></asp:Msg></td>
                            </tr>
                            <tr>
                                <td class="tdGrid">
                                    <asp:GridView ID="gv_grupo" runat="server" AutoGenerateColumns="false" DataSourceID="ods_grupo_lista" DataKeyNames="id_grupotransaccion">
                                        <Columns>
                                            <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                            <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                            <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_grupotransaccion") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar el grupo de debitos?');" /></ItemTemplate></asp:TemplateField>
                                            <asp:ButtonField CommandName="generar_txt" Text="Gen.Txt" ControlStyle-CssClass="gvButton" />
                                            <asp:ButtonField CommandName="respuesta_txt" Text="Arch.Resp" ControlStyle-CssClass="gvButton" />

                                            <asp:BoundField HeaderText="Grupo" DataField="numero" />
                                            <asp:BoundField HeaderText="F.Debito" DataField="fecha_debito" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate" />
                                            <asp:BoundField HeaderText="Periodo" DataField="periodo_debito" />
                                            <asp:BoundField HeaderText="Estado" DataField="estado" />
                                            <asp:BoundField HeaderText="Usuario" DataField="usuario" />

                                            <asp:TemplateField HeaderText="Nº trans." ItemStyle-CssClass="gvCell1"><ItemTemplate><asp:Label ID="lbl_num_debitos" runat="server" Text='<%# DatosParcialTotal(Eval("num_debitos_efectivos").ToString(),Eval("num_debitos").ToString(),"False") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                            <asp:TemplateField HeaderText="Monto ($us)" ItemStyle-CssClass="gvCell1"><ItemTemplate><asp:Label ID="lbl_monto_debitos_sus" runat="server" Text='<%# DatosParcialTotal(Eval("monto_debitos_efectivos_sus").ToString(),Eval("monto_debitos_sus").ToString(),"True") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                            <asp:TemplateField HeaderText="Monto (Bs)" ItemStyle-CssClass="gvCell1"><ItemTemplate><asp:Label ID="lbl_monto_debitos_bs" runat="server" Text='<%# DatosParcialTotal(Eval("monto_debitos_efectivos_bs").ToString(),Eval("monto_debitos_bs").ToString(),"True") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <%--[id_grupotransaccion],[estado],[numero],[fecha_debito],[periodo_debito],[usuario],[num_debitos],
                                        [num_debitos_efectivos],[monto_debitos],[monto_debitos_efectivos],[enviado],[num_archivos_respuesta]--%>
                                    <asp:ObjectDataSource ID="ods_grupo_lista" runat="server" TypeName="terrasur.grupo_transaccion" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View id="View2" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_grupo_abm" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm"><uc2:grupoTransaccionAbm ID="grupoTransaccionAbm1" runat="server" /></td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="grupo" />
                                    <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="grupo" />
                                    <asp:Button ID="btn_cancelar" runat="server" Text="<%$ Resources:form, btn_cancelar %>" CausesValidation="false" SkinID="btnAccion" />
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                        <table class="viewTable" align="center">
                            <tr><td colspan="2" align="right"><asp:Button ID="btn_volver" runat="server" Text="Volver" SkinID="btnVolver" OnClick="btn_volver_Click" /></td></tr>
                            <tr><td colspan="2" class="viewTdTitle">Generación de archivo TXT de debitos</td></tr>
                            <tr>
                                <td class="viewTdEnun">Grupo de transacciones:</td>
                                <td class="viewTdDato"><asp:Label ID="lbl_numero_grupo" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="viewTdEnun">Periodo:</td>
                                <td class="viewTdDato"><asp:Label ID="lbl_periodo" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="viewTdEnun">Fecha del debito:</td>
                                <td class="viewTdDato"><asp:Label ID="lbl_fecha_debito" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="viewTdEnun">Nº transacciones:</td>
                                <td class="viewTdDato"><asp:Label ID="lbl_transaccion" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btn_generar" runat="server" Text="Generar archivo TXT de debitos" OnClick="btn_generar_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View4" runat="server">
                        <table class="viewTable" align="center">
                            <tr><td align="right"><asp:Button ID="btn_archivo_volver" runat="server" Text="Volver" SkinID="btnVolver" OnClick="btn_volver_Click" /></td></tr>
                            <tr><td><uc3:tarjetaArchivoRespuesta ID="tarjetaArchivoRespuesta1" runat="server" /></td></tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>