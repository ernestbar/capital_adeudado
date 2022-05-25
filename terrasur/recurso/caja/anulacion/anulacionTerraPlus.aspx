<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Anulación de venta de servicios" %>
<%@ Register src="../../terraplus/tpContrato/userControl/cajaTerraPlusAnulacionesMaster.ascx" tagname="cajaTerraPlusAnulacionesMaster" tagprefix="uc1" %>
<%@ Register src="../../terraplus/tpContrato/userControl/tpDatosTerraPlus.ascx" tagname="tpDatosTerraPlus" tagprefix="uc2" %>
<%--<%@ Register Src="~/recurso/caja/userControl/cajaAnulacionesMaster.ascx" TagName="cajaAnulacionesMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/contratoDatos.ascx" TagName="contratoDatos" TagPrefix="uc2" %>--%>

<script runat="server">
    Protected Property id_contrato_terraplus() As Integer
        Get
            Return Integer.Parse(lbl_id_contrato_terraplus.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_contrato_terraplus.Text = value
        End Set
    End Property
    
    Protected Property codigo_moneda() As String
        Get
            Return lbl_codigo_moneda.Text
        End Get
        Set(ByVal value As String)
            lbl_codigo_moneda.Text = value
            
            'gv_servicios.Columns(6).HeaderText = "P. unit. (" & value & ")"
            'gv_servicios.Columns(7).HeaderText = "P. total (" & value & ")"
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Session("id_contrato") IsNot Nothing Then
                id_contrato_terraplus = Integer.Parse(Session("id_contrato").ToString)
                Session.Remove("id_contrato")

                tpDatosTerraPlus1.id_contrato = id_contrato_terraplus
                codigo_moneda = terrasur.terraplus.tp_contrato.CodigoMoneda(id_contrato_terraplus)
                CargarDatos()
            Else
                Response.Redirect("~/recurso/caja/terraplusAnulacion.aspx")
            End If
        End If
    End Sub
    
    Protected Sub btn_volver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        Session("id_contrato") = id_contrato_terraplus
        Response.Redirect("~/recurso/caja/terraplusAnulacion.aspx")
    End Sub

    Protected Sub CargarDatos()
        If id_contrato_terraplus > 0 Then
            gv_servicios.DataBind()
        End If
    End Sub

    Protected Sub gv_servicios_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim num_filas As Integer = gv_servicios.Rows.Count
        If num_filas > 0 Then
            Dim permitir_anular As Boolean = terrasur.terraplus.tp_pago.PermitirAnularUltimoPago(id_contrato_terraplus, Profile.id_usuario, Profile.entorno.id_rol)
            For i As Integer = 0 To num_filas - 1
                If i < num_filas - 1 Then
                    CType(gv_servicios.Rows(i).Cells(0).Controls(0), LinkButton).Enabled = False
                Else
                    CType(gv_servicios.Rows(i).Cells(0).Controls(0), LinkButton).Enabled = permitir_anular
                    If permitir_anular Then
                        CType(gv_servicios.Rows(i).Cells(0).Controls(0), LinkButton).OnClientClick = "return confirm('¿Esta seguro que desea anular este pago TerraPlus?');"
                    End If
                End If
            Next
        End If
    End Sub

    Protected Sub gv_servicios_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        If (e.CommandName = "anular") Then
            Dim id_serviciovendido As Integer = Integer.Parse(gv_servicios.DataKeys(Integer.Parse(e.CommandArgument.ToString)).Value.ToString)
            
            If terrasur.terraplus.tp_pago.Anular_ServicioVendido_y_PagosTerraPlus(id_serviciovendido, Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host) Then
                Msg1.Text = "La anulación del pago TerraPlus se realizó correctamente"
                tpDatosTerraPlus1.id_contrato = id_contrato_terraplus
                gv_servicios.DataBind()
            Else
                Msg1.Text = "La anulación del pago TerraPlus NO se realizó correctamente"
            End If
            'Msg1.Text = "id_serviciovendido=" & id_serviciovendido.ToString
        End If
    End Sub
    
    'Protected Sub gv_servicios_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_servicios.RowDataBound
    '    If (e.Row.RowType = DataControlRowType.DataRow) Then
    '        If servicio_vendido.Anulable(Integer.Parse(DataBinder.Eval(e.Row.DataItem, "id_serviciovendido").ToString), Profile.id_usuario, Profile.entorno.id_rol) Then
    '            CType(e.Row.Cells(0).Controls(0), LinkButton).OnClientClick = "return confirm('¿Esta seguro que desea anular la venta de este servicio?');"
    '            CType(e.Row.Cells(0).Controls(0), LinkButton).Enabled = True
    '        Else
    '            CType(e.Row.Cells(0).Controls(0), LinkButton).Enabled = False
    '        End If
    '    End If
    'End Sub



</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:cajaTerraPlusAnulacionesMaster ID="cajaTerraPlusAnulacionesMaster1" runat="server" tipo_anulacion="pagoTerraPlus" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"><Scripts><asp:ScriptReference Path="../../../js/scriptjs.js" /></Scripts></asp:ScriptManager>
    <asp:Label ID="lbl_id_contrato_terraplus" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lbl_codigo_moneda" runat="server" Text="$us" Visible="false"></asp:Label>

    <table class="priTable">
        <tr><td class="priTdTitle">Anulación de venta de servicios</td></tr>
        <tr>
            <td class="priTdContenido">
                <table class="tableContenido" align="center">
                    <tr><td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_volver" runat="server" Text="Cancelar / Volver" SkinID="btnVolver"/></td></tr>
                    <tr><td class="tdEncabezado"><uc2:tpDatosTerraPlus ID="tpDatosTerraPlus1" runat="server" /></td></tr>
                    <tr><td class="tdMsg"><asp:Msg ID="Msg1" runat="server"></asp:Msg></td></tr>
                    <tr>
                        <td class="tdGrid">
                            <table align="center">
                                <tr>
                                    <td>
                                        <asp:Panel ID="panel_anulacion" runat="server" GroupingText="Pagos TerraPlus">
                                            <asp:GridView ID="gv_servicios" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_servicios"
                                                DataKeyNames="id_serviciovendido" OnDataBound="gv_servicios_DataBound" OnRowCommand="gv_servicios_RowCommand">
                                                <Columns>
                                                    <asp:ButtonField Text="Anular" CommandName="anular" ControlStyle-CssClass="gvButton" ButtonType="Link" />
                                                    <asp:BoundField HeaderText="Fecha de pago" DataField="fecha" HtmlEncode="false" DataFormatString="{0:d}" />
                                                    <asp:BoundField HeaderText="Mes(es) pagado(s)" DataField="literal_meses" />
                                                    <asp:BoundField HeaderText="Nº meses" DataField="num_meses" ItemStyle-CssClass="gvCell1" />
                                                    <asp:BoundField HeaderText="Monto" DataField="precio_total" ItemStyle-CssClass="gvCell1" />
                                                    <asp:BoundField HeaderText="" DataField="codigo_moneda" />
                                                    <asp:BoundField HeaderText="Nº Fact." DataField="num_factura" ItemStyle-CssClass="gvCell1"/>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%--[id_serviciovendido],[fecha],[literal_meses],[num_meses]
        [precio_total],[codigo_moneda],[num_factura],[num_recibo],[num_comprobante]--%>
<asp:ObjectDataSource ID="ods_lista_servicios" runat="server" TypeName="terrasur.terraplus.tp_pago" SelectMethod="ListaDePagoServicio">
    <SelectParameters>
        <asp:ControlParameter Name="Id_contrato" Type="String" ControlID="lbl_id_contrato_terraplus" PropertyName="Text" />
    </SelectParameters>
</asp:ObjectDataSource>
</asp:Content>

