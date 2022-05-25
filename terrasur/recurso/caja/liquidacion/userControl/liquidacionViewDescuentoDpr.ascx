<%@ Control Language="VB" ClassName="liquidacionViewDescuentoDpr" %>

<script runat="server">
    Protected Property codigo_moneda() As String
        Get
            Return lbl_codigo_moneda.Text
        End Get
        Set(ByVal value As String)
            lbl_codigo_moneda.Text = value
            
            gv_dprs.Columns(2).HeaderText = "Monto (" & value & ")"
            gv_dprs.Columns(3).HeaderText = "Amortiz. (" & value & ")"
        End Set
    End Property

    Public WriteOnly Property id_contrato() As Integer
        Set(ByVal value As Integer)
            lbl_id_contrato.Text = value.ToString()
            lbl_total.Text = "0"
            
            codigo_moneda = contrato.CodigoMoneda(Integer.Parse(lbl_id_contrato.Text))
            
            gv_dprs.DataBind()
        End Set
    End Property
   
    Protected Sub gv_dprs_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_dprs.DataBound
        If gv_dprs.Rows.Count > 0 Then
            Dim precio_total As Decimal = 0
            For Each row As GridViewRow In gv_dprs.Rows
                precio_total += Decimal.Parse(row.Cells(3).Text)
            Next
            lbl_total.Visible = True
            lbl_total.Text = precio_total.ToString("F2") & " (" & codigo_moneda & ")"
        Else
            lbl_total.Visible = False
        End If
    End Sub
</script>

<asp:Label ID="lbl_id_contrato" runat="server" Visible="false"></asp:Label>
<asp:Label ID="lbl_codigo_moneda" runat="server" Text="$us" Visible="false"></asp:Label>
<table class="liquidacionViewTable" align="center" cellspacing="0">
    <tr>
        <td class="tdGrid">
            <asp:GridView ID="gv_dprs" runat="server" AutoGenerateColumns="false"
                DataSourceID="ods_lista_dpr" DataKeyNames="id_dpr">
                <Columns>
                    <asp:BoundField DataField="dpr_nombre" HeaderText="DPR" />
                    <asp:BoundField DataField="dpr_numero" HeaderText="No. de DPR" />
                    <asp:BoundField DataField="monto" HeaderText="Monto ($us)" ItemStyle-CssClass="gvCell1" />
                    <asp:BoundField DataField="amortizacion" HeaderText="Amortiz. ($us)" ItemStyle-CssClass="gvCell1" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr >
        <td align="right"><asp:Label ID="lbl_total" runat="server"></asp:Label></td>
    </tr>
</table>
<asp:ObjectDataSource ID="ods_lista_dpr" runat="server" TypeName="terrasur.liquidacion" SelectMethod="ListaDescuentoDpr">
    <SelectParameters>
        <asp:ControlParameter Name="id_contrato" Type="Int32" ControlID="lbl_id_contrato" PropertyName="Text" />
    </SelectParameters>
</asp:ObjectDataSource>