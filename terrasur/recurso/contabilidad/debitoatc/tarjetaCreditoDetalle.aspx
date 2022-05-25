<%@ Page Language="VB" MasterPageFile="~/modulo/simple.master" Title="Datos de la tarjeta de crédito" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc3" %>
<%@ Register src="~/recurso/contabilidad/debitoatc/userControl/tarjetaCreditoView.ascx" tagname="tarjetaCreditoView" tagprefix="uc1" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Session("id_tarjetacredito") IsNot Nothing Then
                Dim tcObj As New tarjeta_credito(Integer.Parse(Session("id_tarjetacredito").ToString))
                Page.Title = "Datos de la tarjeta de crédito - " & tcObj.numero & " (" & tcObj.titular & ")"
                tarjetaCreditoView1.id_tarjetacredito = tcObj.id_tarjetacredito
                lbl_id_tarjetacredito.Text = tcObj.id_tarjetacredito
                gv_contrato.DataBind()
                gv_transaccion.DataBind()
                Session.Remove("id_tarjetacredito")
            Else
                Page.Visible = False
            End If
        End If
    End Sub
    Protected Function Importe_monto_string(ByVal importe As String) As String
        Dim importe1 As Decimal = Decimal.Parse(importe) / 100
        Return importe1.ToString("F2")
    End Function
    Protected Function Importe_moneda_string(ByVal moneda As String) As String
        If moneda = "840" Then
            Return "$us"
        ElseIf moneda = "068" Then
            Return "Bs"
        Else
            Return ""
        End If
    End Function
    
    
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc3:recursoMaster ID="RecursoMaster1" runat="server" recurso="tarjeta_credito" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:Label ID="lbl_id_tarjetacredito" runat="server" Text="0" Visible="false"></asp:Label>
    <table class="viewEntTable">
        <tr>
            <td class="viewEntTd">
                <table class="viewTable" align="center">
                    <tr><td class="viewTdTitle">Datos de la tarjeta de crédito</td></tr>
                    <tr>
                        <td>
                            <uc1:tarjetaCreditoView ID="tarjetaCreditoView1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="panel_contratos" runat="server" GroupingText="Contratos asignados a la tarjeta de crédito">
                                <asp:GridView ID="gv_contrato" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_contratos" DataKeyNames="id_contrato">
                                    <Columns>
                                        <asp:BoundField HeaderText="Nº contrato" DataField="num_contrato" ItemStyle-CssClass="gvCell1"/>
                                        <asp:BoundField HeaderText="Moneda" DataField="codigo_moneda"/>
                                        <asp:BoundField HeaderText="Periodicidad" DataField="periodicidad_nombre" ItemStyle-CssClass="gvCell1" />
                                        <asp:BoundField HeaderText="F. debito (día)" DataField="fecha_debito" HtmlEncode="false" DataFormatString="{0:dd}" ItemStyle-CssClass="gvCell1" />
                                        <asp:BoundField HeaderText="Monto ($us)" DataField="monto_sus" ItemStyle-CssClass="gvCell1" />
                                        <asp:BoundField HeaderText="Monto (Bs)" DataField="monto_bs" ItemStyle-CssClass="gvCell1" />
                                        <asp:TemplateField HeaderText="Nº debitos" ItemStyle-CssClass="gvCell1"><ItemTemplate><asp:Literal ID="l_debitos" runat="server" Text='<%# String.Format("{0} de {1}",Eval("num_debitos_efectivos"),Eval("num_debitos")) %>'></asp:Literal></ItemTemplate></asp:TemplateField>
                                        <asp:BoundField HeaderText="Activo" DataField="activo" />
                                    </Columns>
                                </asp:GridView>
                                <%--[id_tarjetacreditocontrato],[id_contrato],[num_contrato],[periodicidad_codigo],[periodicidad_nombre],
                                [fecha_debito],[monto_bs],[monto_sus],[num_debitos],[num_debitos_efectivos],[activo]--%>
                                <asp:ObjectDataSource ID="ods_lista_contratos" runat="server" TypeName="terrasur.tarjeta_credito_contrato" SelectMethod="ListaContratos">
                                    <SelectParameters>
                                        <asp:ControlParameter Name="Id_tarjetacredito" Type="Int32" ControlID="lbl_id_tarjetacredito" PropertyName="Text" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="panel_transacciones" runat="server" GroupingText="Debitos realizados a la tarjeta de crédito">
                                <asp:GridView ID="gv_transaccion" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_transacciones" DataKeyNames="id_transaccion">
                                    <Columns>
                                        <asp:BoundField HeaderText="Nº contrato" DataField="num_contrato" ItemStyle-CssClass="gvCell1" />
                                        <asp:BoundField HeaderText="Periodo cobrado" DataField="periodo_deuda2" ItemStyle-CssClass="gvCell1" />
                                        <asp:BoundField HeaderText="F.Debito" DataField="fecha_debito" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="gvCell1" />
                                        <%--<asp:BoundField HeaderText="Importe" DataField="importe" />--%>
                                        <%--<asp:BoundField HeaderText="Moneda" DataField="codigo_moneda" />--%>
                                        <%--<asp:TemplateField HeaderText="Importe" ItemStyle-CssClass="gvCell1"><ItemTemplate><asp:Label ID="l_importe" runat="server" Text='<%# Importe_monto_string(Eval("importe").ToString()) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                        <asp:TemplateField HeaderText="Moneda" ItemStyle-CssClass="gvCell1"><ItemTemplate><asp:Label ID="l_importe" runat="server" Text='<%# Importe_moneda_string(Eval("codigo_moneda").ToString()) %>'></asp:Label></ItemTemplate></asp:TemplateField>--%>
                                        <%--<asp:BoundField HeaderText="Monto debitado ($us)" DataField="importe_sus" />--%>
                                        <asp:BoundField HeaderText="Monto ($us)" DataField="importe_sus2" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                                        <asp:BoundField HeaderText="Monto (Bs)" DataField="importe_bs2" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />

                                        <asp:BoundField HeaderText="Respuesta / Error" DataField="respuesta2" />
                                    </Columns>
                                </asp:GridView>
                                <%--[id_transaccion],[id_establecimiento],[numero_tarjeta],[importe],[codigo_moneda],[fecha_vencimiento],
                                [nombre_cliente],[codigo_cliente],[periodo_deuda],[id_agrupacion],[respuesta1],[codigo_error]
                                [num_contrato],[fecha_debito],[importe_sus],[respuesta2],[periodo_deuda2]--%>
                                <asp:ObjectDataSource ID="ods_lista_transacciones" runat="server" TypeName="terrasur.tarjeta_credito_transaccion" SelectMethod="ListaTransacciones">
                                    <SelectParameters>
                                        <asp:ControlParameter Name="Id_tarjetacredito" Type="Int32" ControlID="lbl_id_tarjetacredito" PropertyName="Text" />
                                        <asp:Parameter Name="Id_grupotransaccion" Type="Int32" DefaultValue="0" />
                                        <asp:Parameter Name="Tipo_transaccion" Type="String" DefaultValue="todos" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

