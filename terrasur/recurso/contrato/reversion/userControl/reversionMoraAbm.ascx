<%@ Control Language="VB" ClassName="reversionMoraAbm" %>

<script runat="server">
    Public Property grid_contrato() As GridView
        Get
            Return gv_contrato
        End Get
        Set(ByVal value As GridView)
            gv_contrato = value
        End Set
    End Property
        
    Public Sub CargarInsertar()
        ddl_motivo.Items.Clear()
        ddl_motivo.DataBind()
    End Sub
   
    Protected Sub ddl_motivo_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_motivo.DataBound
        ddl_motivo.Items.Insert(0, New ListItem(New motivo_reversion("mora").nombre, New motivo_reversion("mora").id_motivoreversion))
    End Sub
   
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        'Dim contrato_p4n As New contrato_paquete4n(id_contrato.ToString())
        'Dim paquete4n_nuevo As New paquete4n(Int32.Parse(ddl_nuevo_paquete.SelectedValue))
        'contrato_p4n.num_cenizas_inhumadas
        Return correcto
    End Function
    
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim correcto As Boolean = False
            For Each row As GridViewRow In gv_contrato.Rows
                Dim c As New contrato(Integer.Parse(gv_contrato.DataKeys(row.RowIndex).Value.ToString()))
                Dim r As New reversion(c.id_contrato, Integer.Parse(ddl_motivo.SelectedValue), Integer.Parse(row.Cells(8).Text), Integer.Parse(row.Cells(9).Text), c.capital_pagado, c.saldo_capital)
                'La reversión
                If r.Insertar(Profile.id_usuario) Then
                    correcto = True
                Else
                    correcto = False
                End If
            Next
            If correcto = True Then
                Msg1.Text = "La reversión se guardó correctamente"
                Return True
            End If
        Else
            Msg1.Text = "La reversión NO se guardó correctamente"
            Return False
        End If
    End Function

</script>

<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<table >
    <tr>
        <td>
            <table class="formTable" align="left" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="formTdMsg" colspan="2">
                        <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                        <asp:ValidationSummary ID="vs_reversion_mora" runat="server" DisplayMode="List" ValidationGroup="reversion_mora" />
                    </td>
                </tr>
                <tr>
                    <td class="formTdEnun">
                        <asp:Label ID="lbl__enun" runat="server" Text="Motivo de la reversión:"></asp:Label>
                        <%--[id_motivodesactivacion],[nombre]--%>
                        <%--<asp:ObjectDataSource ID="ods_motivo_lista" runat="server" TypeName="terrasur.motivo_reversion"
                SelectMethod="ListaNoSistema"></asp:ObjectDataSource>--%>
                    </td>
                    <td align="left" class="formTdDato">
                        <asp:DropDownList ID="ddl_motivo" runat="server" AutoPostBack="true" DataTextField="nombre"
                            DataValueField="id_motivoreversion">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="formTdEnun">
                        <asp:Label ID="lbl_contratos_enun" runat="server" Text="Contratos a revertir:"></asp:Label>
                    </td>
                    <td class="formTdDato">
                    </td>
                </tr>
                
            </table>
        </td>
        <td align="right">
            <asp:Image ID="img_impresora" runat="server" ImageUrl="~/images/impresora.jpg" Height="32"
                Width="32" />
            <a href="#" onclick="window.print();">Imprimir</a>
        </td>
    </tr>
    <tr>
        <td class="tdGrid" colspan="2">
            <asp:GridView ID="gv_contrato" runat="server" AutoGenerateColumns="false" DataKeyNames="id_contrato"
                Visible="false">
                <Columns>
                    <asp:BoundField HeaderText="Negocio" DataField="negocio_nombre" />
                    <asp:BoundField HeaderText="No. contrato" DataField="num_contrato" ItemStyle-CssClass="gvCell1" />
                    <asp:BoundField HeaderText="Cliente" DataField="cliente_nombre" />
                    <asp:BoundField HeaderText="Lote" DataField="lote_codigo" />
                    <asp:BoundField HeaderText="Capital Total" DataField="capital_total" ItemStyle-CssClass="gvCell1" />
                    <asp:BoundField HeaderText="Capital Pagado" DataField="capital_pagado" ItemStyle-CssClass="gvCell1" />
                    <asp:BoundField HeaderText="Capital Adeudado" DataField="capital_adeudado" ItemStyle-CssClass="gvCell1" />
                    <asp:BoundField HeaderText="Fecha Prox. Pago" DataField="fecha_prox_pago" HtmlEncode="false"
                        DataFormatString="{0:d}" ItemStyle-CssClass="gvCell1" />
                    <asp:BoundField HeaderText="No. días de mora" DataField="dias_mora" ItemStyle-CssClass="gvCell1" />
                    <asp:BoundField HeaderText="No. cuotas en mora" DataField="cuotas_mora" ItemStyle-CssClass="gvCell1" />
                    <asp:BoundField HeaderText="Promotor" DataField="promotor" />
                </Columns>
            </asp:GridView>
            <%-- --%>
            <%--<asp:ObjectDataSource ID="ods_contratos_lista" runat="server" TypeName="terrasur.reversion"
                SelectMethod="ContratosMoraTmp">
                <SelectParameters>
                    <asp:ControlParameter Name="Id_negocio" Type="Int32" ControlID="ddl_negocio" PropertyName="SelectedValue" />
                    <asp:ControlParameter Name="Desde" Type="Int32" ControlID="txt_desde" PropertyName="Text" />
                    <asp:ControlParameter Name="Hasta" Type="Int32" ControlID="txt_hasta" PropertyName="Text" />
                </SelectParameters>
            </asp:ObjectDataSource>--%>
        </td>
    </tr>
</table>


