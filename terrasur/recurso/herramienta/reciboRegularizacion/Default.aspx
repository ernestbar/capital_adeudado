<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Recibos de regularización de pagos" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/herramienta/reciboRegularizacion/userControl/reciboRegularizacionAbm.ascx" TagName="reciboRegularizacionAbm" TagPrefix="uc3" %>

<script runat="server">
    Protected Property id_recibo() As Integer
        Get
            Return Integer.Parse(lbl_id_recibo.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_recibo.Text = value
        End Set
    End Property
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reciboRegularizacion", "view") Then
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reciboRegularizacion", "insert")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    Protected Sub rbl_impresoras_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_impresoras.DataBound
        If rbl_impresoras.Items.FindByValue(Profile.seleccion_impresora.recibo) IsNot Nothing Then
            Try
                rbl_impresoras.SelectedValue = Profile.seleccion_impresora.recibo
            Catch ex As Exception
            End Try
        ElseIf rbl_impresoras.Items.Count > 0 Then
            rbl_impresoras.SelectedIndex = 0
        End If
    End Sub

    Protected Sub gv_recibo_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        gv_recibo.Columns(0).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reciboRegularizacion", "view_print")
        gv_recibo.Columns(1).Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reciboRegularizacion", "update")
    End Sub

    Protected Sub gv_recibo_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        Select Case e.CommandName
            Case "ver"
                id_recibo = Integer.Parse(gv_recibo.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
                rbl_impresoras.DataBind()

                lbl_imprimiendo.Text = ""
                btn_imprimir.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reciboRegularizacion", "print")
                
                Dim tabla As New Data.DataTable
                tabla.Columns.Add("id_reciboregularizacion", GetType(Integer))
                Dim fila As Data.DataRow = tabla.NewRow
                fila("id_reciboregularizacion") = id_recibo
                tabla.Rows.Add(fila)
                
                If ConfigurationManager.AppSettings("impresoras_red") = "si" Then
                    Dim cajaRecRegularizacion As New cajaTransaccionRegularizacion
                    cajaRecRegularizacion.DataSource = tabla
                    cajaRecRegularizacion.Run()
                    wv_documento.Report = cajaRecRegularizacion
                Else
                    Dim recibo_reg_maestro As New cajaReciboRegularizacionMaestro
                    recibo_reg_maestro.DataSource = tabla
                    recibo_reg_maestro.Run()
                    wv_documento.Report = recibo_reg_maestro
                End If
                
                MultiView1.ActiveViewIndex = 2

            Case "editar"
                panel_abm.DefaultButton = "btn_actualizar"
                lbl_recibo_abm.Text = "Edición de datos de un recibo"
                ReciboRegularizacionAbm1.CargarActualizar(Integer.Parse(gv_recibo.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString))
                btn_insertar.Visible = False
                btn_actualizar.Visible = True
                MultiView1.ActiveViewIndex = 1
        End Select
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        panel_abm.DefaultButton = "btn_insertar"
        lbl_recibo_abm.Text = "Nuevo recibo"
        ReciboRegularizacionAbm1.CargarInsertar()
        btn_insertar.Visible = True
        btn_actualizar.Visible = False
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_insertar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If ReciboRegularizacionAbm1.Insertar Then
            gv_recibo.DataBind()
        End If
    End Sub

    Protected Sub btn_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If ReciboRegularizacionAbm1.Actualizar Then
            gv_recibo.DataBind()
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub btn_imprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim tabla As New Data.DataTable
            tabla.Columns.Add("id_reciboregularizacion", GetType(Integer))
            Dim fila As Data.DataRow = tabla.NewRow
            fila("id_reciboregularizacion") = id_recibo
            tabla.Rows.Add(fila)

            If ConfigurationManager.AppSettings("impresoras_red") = "si" Then
                Dim _PrinterDir As String = rbl_impresoras.SelectedValue
                Dim _PrinterName As String = ""
                Dim _NumBandeja As Integer = 0
                If _PrinterDir.Contains("|") = True Then
                    _PrinterName = _PrinterDir.Split("|")(0)
                    _NumBandeja = Integer.Parse(_PrinterDir.Split("|")(1))
                Else
                    _PrinterName = _PrinterDir
                    _NumBandeja = 0
                End If

                If tabla.Rows.Count > 0 Then
                    Dim cajaRecRegularizacion As New cajaTransaccionRegularizacion
                    cajaRecRegularizacion.DataSource = tabla
                    cajaRecRegularizacion.Run()
                    Try
                        cajaRecRegularizacion.Document.Printer.PrinterName = _PrinterName
                        cajaRecRegularizacion.Document.Printer.PrinterSettings.Copies = 1
                        cajaRecRegularizacion.Document.Printer.DefaultPageSettings.PaperSource = cajaRecRegularizacion.Document.Printer.PrinterSettings.PaperSources(_NumBandeja)
                        Dim PaperSizeLetter As New System.Drawing.Printing.PaperSize("TransaccionCarta", 850, 1100)
                        cajaRecRegularizacion.Document.Printer.DefaultPageSettings.PaperSize = PaperSizeLetter
                        cajaRecRegularizacion.Document.Print(False, False, False)
                        lbl_imprimiendo.Text = "Imprimiendo"
                        transaccion_impresion.Registrar(0, "", 0, 0, 0, id_recibo, Profile.id_usuario, rbl_impresoras.SelectedItem.Text, rbl_impresoras.SelectedItem.Value)
                    Catch ex As Exception
                        lbl_imprimiendo.Text = "No se esta imprimiendo"
                    End Try
                    
                    lbl_sin_impresion.Visible = False
                Else
                    lbl_sin_impresion.Visible = True
                End If
            Else
                Dim recibo_reg_maestro As New cajaReciboRegularizacionMaestro
                recibo_reg_maestro.DataSource = tabla
                recibo_reg_maestro.Run()

                If general.Impersonate_Context(ConfigurationManager.AppSettings("impersonate_user"), "", ConfigurationManager.AppSettings("impersonate_password")) Then
                    Try
                        recibo_reg_maestro.Document.Printer.PrinterName = rbl_impresoras.SelectedValue
                        recibo_reg_maestro.Document.Printer.PrinterSettings.Copies = 1
                        recibo_reg_maestro.Document.Print(False, False, False)
                        lbl_imprimiendo.Text = "Imprimiendo"
                    Catch ex As Exception
                        lbl_imprimiendo.Text = "No se esta imprimiendo"
                    Finally
                        general.Impersonate_Undo()
                    End Try
                Else
                    lbl_imprimiendo.Text = "No se esta imprimiendo"
                End If
            End If
        Catch ex As Exception
            lbl_aux.Text = ex.Message
        End Try
 
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
     <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="reciboRegularizacion" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:Label ID="lbl_id_recibo" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label id="lbl_aux" runat="server"></asp:Label>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<table class="priTable">
    <tr>
        <td class="priTdTitle">Recibos de regularización de pagos</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido">
                <tr>
                    <td>
                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                            <asp:View ID="View1" runat="server">
                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left">
                                            <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo recibo" OnClick="btn_nuevo_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gv_recibo" runat="server" AutoGenerateColumns="false" DataKeyNames="id_reciboregularizacion" DataSourceID="ods_lista_recibo" OnDataBound="gv_recibo_DataBound" OnRowCommand="gv_recibo_RowCommand">
                                                <Columns>
                                                    <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />
                                                    <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                                                    <asp:BoundField HeaderText="Nºcontrato" DataField="num_contrato" ItemStyle-CssClass="gvCell1" />
                                                    <asp:BoundField HeaderText="Moneda" DataField="codigo_moneda" />
                                                    <asp:BoundField HeaderText="Fecha" DataField="fecha" HtmlEncode="false" DataFormatString="{0:d}" />
                                                    <asp:BoundField HeaderText="Monto" DataField="monto_sus" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                                    <asp:BoundField HeaderText="Lote" DataField="lote" />
                                                    <asp:BoundField HeaderText="Cliente" DataField="cliente" />
                                                </Columns>
                                            </asp:GridView>
                                            <%--[id_reciboregularizacion],[num_contrato],[lote],[fecha],[monto_sus],[concepto],[cliente]--%>
                                            <asp:ObjectDataSource ID="ods_lista_recibo" runat="server" TypeName="terrasur.recibo_regularizacion" SelectMethod="Lista">
                                                <SelectParameters>
                                                    <asp:Parameter Name="Num_contrato" Type="string" DefaultValue="" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:Panel ID="panel_abm" runat="server">
                                                <table class="formEntTable">
                                                    <tr><td class="formEntTdTitle"><asp:Label ID="lbl_recibo_abm" runat="server"></asp:Label></td></tr>
                                                    <tr>
                                                        <td class="formEntTdForm">
                                                            <uc3:reciboRegularizacionAbm ID="ReciboRegularizacionAbm1" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formEntTdButton">
                                                            <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="recibo" OnClick="btn_insertar_Click" />
                                                            <asp:ButtonAction ID="btn_actualizar" runat="server" Text="<%$ Resources:form, btn_actualizar %>" TextoEnviando="<%$ Resources:form, btn_actualizar_click %>" CausesValidation="true" ValidationGroup="recibo" OnClick="btn_actualizar_Click" />
                                                            <asp:Button ID="btn_cancelar" runat="server" Text="<%$ Resources:form, btn_cancelar %>" CausesValidation="false" SkinID="btnAccion" OnClick="btn_cancelar_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View3" runat="server">
                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:Panel runat="server" ID="panel_impresoras" GroupingText="Impresoras Habilitadas">
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                            <%--<Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="rbl_impresoras" EventName="DataBound" />
                                                            </Triggers>--%>
                                                            <ContentTemplate>

                                                            <table width="100%">
                                                                <tr>
                                                                    <td><asp:RadioButtonList id="rbl_impresoras" runat="server" DataSourceID="ods_lista_impresoras" RepeatColumns="3" RepeatDirection="Horizontal" DataValueField="direccion_red" DataTextField="nombre"></asp:RadioButtonList></td>
                                                                    <td><asp:Button ID="btn_imprimir" runat="server" Text="Imprimir" SkinID="cajaImprimirButton" CausesValidation="false" OnClick="btn_imprimir_Click" /></td>
                                                                    <td><asp:Button ID="btn_volver" runat="server" Text="Volver a la lista" SkinID="btnVolver" CausesValidation="false" OnClick="btn_volver_Click" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td><asp:Label ID="lbl_imprimiendo" runat="server" SkinID="lbl_CajaIngresoPermitido"></asp:Label></td>
                                                                    <td></td>
                                                                </tr>
                                                            </table>

                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                            <asp:ObjectDataSource ID="ods_lista_impresoras" runat="server" TypeName="terrasur.impresora_usuario" SelectMethod="ListaImpresoraPorUsuario">
                                                                <SelectParameters>
                                                                    <asp:ProfileParameter Name="Id_usuario" Type="Int32" PropertyName="id_usuario" />
                                                                    <asp:Parameter Name="Factura" Type="Boolean" DefaultValue="False" />
                                                                    <asp:Parameter Name="Recibo" Type="Boolean" DefaultValue="True" />
                                                                    <asp:Parameter Name="Comprobante" Type="Boolean" DefaultValue="False" />
                                                                    <asp:Parameter Name="Solo_activos" Type="Boolean" DefaultValue="true" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_sin_impresion" runat="server" Visible="false" Text="La impresión NO se envió correctamente, COMUNÍQUESE CON EL ADMINISTRADOR" Font-Size="Medium" Font-Bold="true" ForeColor="Red" Font-Names="Arial"></asp:Label>
                                                        <ActiveReportsWeb:WebViewer ID="wv_documento" runat="server" Height="400" Width="600" ViewerType="HtmlViewer">
                                                        </ActiveReportsWeb:WebViewer>
                                                        <%--<ActiveReportsWeb:WebViewer ID="wv_documento" runat="server" Height="400" Width="600" ViewerType="AcrobatReader">
                                                        </ActiveReportsWeb:WebViewer>--%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

