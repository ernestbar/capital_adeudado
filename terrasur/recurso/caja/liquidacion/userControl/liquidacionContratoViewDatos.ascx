<%@ Control Language="VB" ClassName="liquidacionContratoViewDatos" %>

<script runat="server">
    Public WriteOnly Property id_contrato() As Integer
        Set(ByVal value As Integer)
            lbl_id_contrato.Text = value.ToString()
            Dim cv As New contrato_venta(value)
            Dim l As New lote(cv.id_lote)
            'lbl_superficie.Text = l.superficie_m2.ToString()
            lbl_superficie.Text = cv.superficie_m2.ToString("F2")
            lbl_urbanizacion.Text = l.nombre_urbanizacion
            lbl_manzanolote.Text = l.codigo_manzano & "/" & l.codigo
            Dim cl As New cliente(cv.id_titular)
            lbl_no_contrato.Text = cv.numero.ToString()
            lbl_titular.Text = cl.paterno & " " & cl.materno & " " & cl.nombres
            gv_clientes.DataBind()
        End Set
    End Property
</script>

<asp:Label ID="lbl_id_contrato" runat="server" Visible="false"></asp:Label>
<table class="liquidacionViewTable" align="center" width="100%" cellspacing="0">
    <tr>
        <td width="50%" valign="top">
            <table>
                <tr>
                    <td class="liquidacionViewTdHorEnun">No. contrato:</td>
                    <td class="liquidacionViewTdDato"><asp:Label ID="lbl_no_contrato" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="liquidacionViewTdHorEnun">Sector:</td>
                    <td class="liquidacionViewTdDato"><asp:Label ID="lbl_urbanizacion" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="liquidacionViewTdHorEnun">Manzano/Lote:</td>
                    <td class="liquidacionViewTdDato"><asp:Label ID="lbl_manzanolote" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2"></td> 
                </tr>
            </table>
        </td>
        <td width="50%" valign="top">
            <table>
                <tr>
                    <td class="liquidacionViewTdHorEnun">Superficie:</td>
                    <td class="liquidacionViewTdDato"><asp:Label ID="lbl_superficie" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="liquidacionViewTdHorEnun">Primer Titular:</td>
                    <td class="liquidacionViewTdDato"><asp:Label ID="lbl_titular" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="liquidacionViewTdHorEnun">Otros Titulares:</td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td class="tdGrid">
                        <asp:GridView ID="gv_clientes" HorizontalAlign="Left" ShowHeader="false" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_clientes" DataKeyNames="id_cliente">
                            <Columns>
                                <asp:BoundField DataField="nombre_completo" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<asp:ObjectDataSource ID="ods_lista_clientes" runat="server" TypeName="terrasur.cliente_contrato" SelectMethod="ListaClientesAdicionales">
    <SelectParameters>
        <asp:ControlParameter Name="id_contrato" Type="Int32" ControlID="lbl_id_contrato" PropertyName="Text" />
    </SelectParameters>
</asp:ObjectDataSource>