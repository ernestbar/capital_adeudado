<%@ Control Language="VB" ClassName="contratoTransferencia" %>

<script runat="server">
    Public Property id_contrato() As Integer
        Get
            Return Integer.Parse(lbl_id_contrato.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_contrato.Text = value
            CargarDatos()
        End Set
    End Property
    Public ReadOnly Property id_negocio() As Integer
        Get
            If ddl_negocio.Items.Count > 0 Then
                Return Integer.Parse(ddl_negocio.SelectedValue)
            Else
                Return 0
            End If
        End Get
    End Property
    Public ReadOnly Property id_pago() As Integer
        Get
            If rbl_pago.Items.Count > 0 Then
                Return Integer.Parse(rbl_pago.SelectedValue)
            Else
                Return 0
            End If
        End Get
    End Property
    
    Protected Sub CargarDatos()
        lbl_negocio.Text = New negocio_contrato(contrato.NegocioContrato(id_contrato)).negocio_nombre
        ddl_negocio.DataBind()
        rbl_pago.DataBind()
    End Sub
    Public Function Verificar() As Boolean
        If ddl_negocio.Items.Count > 0 Then
            Return True
        Else
            Msg1.Text = "Debe elegir el negocio al cual se va a transferir el contrato"
            Return False
        End If
    End Function

    Protected Sub rbl_pago_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_pago.DataBound
        If rbl_pago.Items.Count > 0 Then
            rbl_pago.SelectedIndex = 0
        End If
        CargarDatosTransferencia()
    End Sub
    Protected Sub rbl_pago_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_pago.SelectedIndexChanged
        CargarDatosTransferencia()
    End Sub

    Protected Sub CargarDatosTransferencia()
        gv_transferencia.DataSource = contrato.TablaTransferencia(id_contrato, id_pago)
        gv_transferencia.DataBind()
    End Sub
    
</script>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<table align="center">
    <tr>
        <td colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td align="left"><asp:Label ID="lbl_negocio_enun" runat="server" SkinID="lblEnun" Text="Negocio actual:"></asp:Label></td>
        <td align="left"><asp:Label ID="lbl_negocio" runat="server" SkinID="lblDato"></asp:Label></td>
    </tr>
    <tr>
        <td align="left"><asp:Label ID="lbl_nuevo_negocio_enun" runat="server" SkinID="lblEnun" Text="Transferir al negocio:"></asp:Label></td>
        <td align="left">
            <asp:DropDownList ID="ddl_negocio" runat="server" DataTextField="nombre" DataValueField="id_negocio" DataSourceID="ods_lista_negocio"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfv_negocio" runat="server" ControlToValidate="ddl_negocio" Display="Dynamic" ValidationGroup="contrato" Text="*" ErrorMessage="Debe elegir el negocio al cual se va a transferir el contrato"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top" rowspan="2"><asp:Label ID="lbl_pago_enun" runat="server" SkinID="lblEnun" Text="Saldo a transferir:"></asp:Label></td>
        <td align="left">
            <asp:RadioButtonList ID="rbl_pago" runat="server" AutoPostBack="true" DataValueField="id_pago" DataTextField="texto" DataSourceID="ods_lista_pago_transferencia">
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:GridView ID="gv_transferencia" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField ShowHeader="false" DataField="tipo" ItemStyle-Font-Bold="true" />
                    <asp:BoundField HeaderText="Capital" DataField="capital" ItemStyle-CssClass="gvCell1" />
                    <asp:BoundField HeaderText="Costo" DataField="costo" ItemStyle-CssClass="gvCell1" />
                    <asp:BoundField HeaderText="Amortización" DataField="amortizacion" ItemStyle-CssClass="gvCell1" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
<%--[id_pago],[fecha],[monto_pago],[amortizacion],[saldo],[codigo_tipo_pago],[nombre_tipo_pago],[texto]--%>
<asp:ObjectDataSource ID="ods_lista_pago_transferencia" runat="server" TypeName="terrasur.pago" SelectMethod="ListaTransferencia">
    <SelectParameters>
        <asp:ControlParameter Name="Id_contrato" Type="Int32" ControlID="lbl_id_contrato" PropertyName="Text" />
    </SelectParameters>
</asp:ObjectDataSource>
<%--[id_negocio],[codigo],[nombre],[origen]--%>
<asp:ObjectDataSource ID="ods_lista_negocio" runat="server" TypeName="terrasur.negocio" SelectMethod="ListaTransferencia">
    <SelectParameters>
        <asp:ControlParameter Name="Id_contrato" Type="Int32" ControlID="lbl_id_contrato" PropertyName="Text" />
    </SelectParameters>
</asp:ObjectDataSource>