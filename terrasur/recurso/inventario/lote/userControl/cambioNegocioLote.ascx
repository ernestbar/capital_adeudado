<%@ Control Language="VB" ClassName="cambioNegocioLote" %>

<script runat="server">
    Public Property id_lote() As Integer
        Get
            Return Integer.Parse(lbl_id_lote.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_lote.Text = value
        End Set
    End Property
    Public Property id_manzano() As Integer
        Get
            Return Integer.Parse(lbl_id_manzano.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_manzano.Text = value 
        End Set
    End Property
    Public Property id_urbanizacion() As Integer
        Get
            Return Integer.Parse(lbl_id_urbanizacion.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_urbanizacion.Text = value
        End Set
    End Property
    Public Property id_localizacion() As Integer
        Get
            Return Integer.Parse(lbl_id_localizacion.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_localizacion.Text = value
        End Set
    End Property
    Public ReadOnly Property id_ultimo_pago() As Integer
        Get
            Return Integer.Parse(lbl_id_ultimo_pago.Text)
        End Get
    End Property
    Public Function CargarActualizar() As Boolean
        Dim loteObj As New lote(id_lote)
        Dim negocio_lote As New negocio_lote(loteObj.id_negociolote)
        Dim negocio As New negocio(negocio_lote.id_negocio)
        If negocio.origen = True Then
            Dim el As New estado_lote(loteObj.id_estadolote)
            Dim e As New estado(el.id_estado)
            If e.codigo <> "pre" Then
                id_manzano = loteObj.id_manzano
                lbl_manzano.Text = loteObj.codigo_manzano
                lbl_localizacion.Text = loteObj.nombre_localizacion
                lbl_urbanizacion.Text = loteObj.nombre_urbanizacion
                lbl_lote.Text = loteObj.codigo
                lbl_negocio_actual.Text = loteObj.nombre_negocio
                If e.codigo = "ven" Then
                    Dim c As New contrato(loteObj.id_contrato_asignado)
                    If c.id_ultimo_pago > 0 Then
                        Dim p As New pago(c.id_ultimo_pago)
                        lbl_saldo.Text = p.saldo
                    Else
                        lbl_saldo.Text = c.precio_final
                    End If
                    lbl_id_contrato.Text = loteObj.id_contrato_asignado
                    lbl_id_ultimo_pago.Text = c.id_ultimo_pago
                    lbl_saldo.Visible = True
                    lbl_contrato.Text = "Contrato No.: " & c.numero.ToString()
                    lbl_contrato.Visible = True
                    gv_transferencia.Visible = True
                    lbl_pago_enun.Visible = True
                    ddl_negocio.DataBind()
                    CargarDatosTransferencia()
                Else
                    lbl_id_contrato.Text = "0"
                    lbl_id_ultimo_pago.Text = "0"
                    lbl_saldo.Text = "0"
                    lbl_saldo.Visible = False
                    lbl_contrato.Text = "Contrato No.: 0"
                    lbl_contrato.Visible = False
                    gv_transferencia.Visible = False
                    lbl_pago_enun.Visible = False
                    ddl_negocio.DataBind()
                End If
                Return True
            Else
                Msg1.Text = "No puede realizarce un traspaso ya que el lote esta preasignado."
                Return False
            End If
        Else
            Msg1.Text = "No puede realizarce un traspaso ya que el lote pertenece a un negocio destino."
            Return False
        End If
    End Function
    Public Function Actualizar() As Boolean
        Dim loteObj As New lote(id_lote)
        Dim el As New estado_lote(loteObj.id_estadolote)
        Dim e As New estado(el.id_estado)
        If e.codigo = "ven" Then
            If ddl_negocio.SelectedValue > 0 Then
                If contrato.Transferir(Int32.Parse(lbl_id_contrato.Text), ddl_negocio.SelectedValue, id_ultimo_pago, Profile.id_usuario) Then
                    Msg1.Text = "El lote y contrato se transfirieron correctamente"
                Else
                    Msg1.Text = "El lote y contrato NO se transfirieron correctamente"
                End If
            Else
                Msg1.Text = "No existe otro negocio origen para traspasar."
            End If
        Else
            If e.codigo <> "pre" Then
                Dim nl As New negocio_lote(ddl_negocio.SelectedValue, id_lote)
                If nl.Insertar(Profile.id_usuario) Then
                    Msg1.Text = "El nuevo negocio del lote se guardó correctamente"
                    Return True
                Else
                    Msg1.Text = "El nuevo negocio del lote NO se guardó correctamente"
                    Return False
                End If
            End If
        End If
    End Function

    Protected Sub CargarDatosTransferencia()
        gv_transferencia.DataSource = contrato.TablaTransferencia(Int32.Parse(lbl_id_contrato.Text), Int32.Parse(lbl_id_ultimo_pago.Text))
        gv_transferencia.DataBind()
    End Sub

</script>
<asp:Label ID="lbl_id_ultimo_pago" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_lote" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_manzano" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_localizacion" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_urbanizacion" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_lote" runat="server" DisplayMode="List" ValidationGroup="lote" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos del lote"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_localizacion_enun" runat="server" Text="Localización:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:Label ID="lbl_localizacion" runat="server" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_urbanizacion_enun" runat="server" Text="Sector:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:Label ID="lbl_urbanizacion" runat="server" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_manzano_enun" runat="server" Text="Manzano:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:Label ID="lbl_manzano" runat="server" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_lote_enun" runat="server" Text="Lote:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_lote" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_negocio_actual_enun" runat="server" Text="Negocio Actual:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_negocio_actual" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_negocios_enum" runat="server" Text="Cambiar negocio a:"></asp:Label>
        </td>
        <td class="formTdDato">
        <asp:DropDownList ID="ddl_negocio" runat="server" DataTextField="nombre" DataValueField="id_negocio" DataSourceID="ods_lista_negocio"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top" rowspan="2"><asp:Label ID="lbl_pago_enun" runat="server" SkinID="lblEnun" Text="Saldo a transferir:"></asp:Label></td>
        <td align="left">
            <asp:Label ID="lbl_saldo" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:Label ID="lbl_contrato" runat="server" Text=""></asp:Label>
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
<asp:ObjectDataSource ID="ods_lista_negocio" runat="server" TypeName="terrasur.negocio" SelectMethod="ListaTraspaso">
    <SelectParameters>
        <asp:ControlParameter Name="id_lote" Type="Int32"  ControlID="lbl_id_lote" PropertyName="Text" />
    </SelectParameters>
</asp:ObjectDataSource>