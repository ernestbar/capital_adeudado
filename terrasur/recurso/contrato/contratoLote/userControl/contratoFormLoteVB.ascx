<%@ Control Language="VB" ClassName="contratoFormLoteVB" %>

<script runat="server">

    'Public Event ElegirLote As EventHandler
    'protected sub elegir() as virtual
    '{
    '}

    'Protected Overridable Sub OnClick(ByVal e As EventArgs)
    '    RaiseEvent ElegirLote(Me, e)
    'End Sub
    'public event EventHandler AceptarClicked;
    'protected virtual void OnClick(object sender)
    '{
    '    if (this.AceptarClicked != null) this.AceptarClicked(sender, new EventArgs());
    '}
    'protected void btn_ver_Click(object sender, EventArgs e) { OnClick(sender); }
    
    
    
    Public ReadOnly Property id_lote() As Integer
        Get
            If ddl_lote.Items.Count > 0 Then
                Return Integer.Parse(ddl_lote.SelectedValue)
            Else
                Return 0
            End If
        End Get
    End Property
    
    Public Sub Reset()
        ddl_localizacion.DataBind()
    End Sub
    
    Public Function Verificar() As Boolean
        If id_lote > 0 Then
            Dim loteObj As New lote(id_lote)
            Dim estadoLoteObj As New estado_lote(loteObj.id_estadolote)
            If estadoLoteObj.codigo_estado = "dis" Then
                Return True
            Else
                Msg1.Text = "El lote elegido ya no esta disponible"
                ddl_lote.DataBind()
                Return False
            End If
        Else
            Msg1.Text = "Debe elegir un lote"
            Return False
        End If
    End Function
    
    Protected Sub ddl_localizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_localizacion.DataBound
        CargarDatosLocalizacion()
        ddl_urbanizacion.DataBind()
        ddl_manzano.DataBind()
        ddl_lote.DataBind()
    End Sub
    Protected Sub ddl_localizacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_localizacion.SelectedIndexChanged
        CargarDatosLocalizacion()
    End Sub

    Protected Sub ddl_urbanizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_urbanizacion.DataBound
        CargarDatosUrbanizacion()
        ddl_manzano.DataBind()
        ddl_lote.DataBind()
    End Sub
    Protected Sub ddl_urbanizacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_urbanizacion.SelectedIndexChanged
        CargarDatosUrbanizacion()
    End Sub

    Protected Sub ddl_manzano_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_manzano.DataBound
        ddl_lote.DataBind()
    End Sub

    Protected Sub ddl_lote_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_lote.DataBound
        CargarDatosLote()
    End Sub
    Protected Sub ddl_lote_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_lote.SelectedIndexChanged
        CargarDatosLote()
    End Sub
    
    Private Sub CargarDatosLocalizacion()
        If ddl_localizacion.Items.Count > 0 Then
            Dim loc As New localizacion(Integer.Parse(ddl_localizacion.SelectedValue))
            If localizacion.ImagenDireccion(loc.imagen) <> ConfigurationManager.AppSettings("localizacion_dir_imagen_vacio") Then
                hl_localizacion.NavigateUrl = localizacion.ImagenDireccion(loc.imagen)
                hl_localizacion.Visible = True
            Else
                hl_localizacion.Visible = False
            End If
        Else
            hl_localizacion.Visible = False
        End If
    End Sub
    Private Sub CargarDatosUrbanizacion()
        If ddl_urbanizacion.Items.Count > 0 Then
            Dim urb As New urbanizacion(Integer.Parse(ddl_urbanizacion.SelectedValue))
            If urbanizacion.ImagenDireccion(urb.imagen) <> ConfigurationManager.AppSettings("urbanizacion_dir_imagen_vacio") Then
                hl_urbanizacion.NavigateUrl = urbanizacion.ImagenDireccion(urb.imagen)
                hl_urbanizacion.Visible = True
            Else
                hl_urbanizacion.Visible = False
            End If
        Else
            hl_urbanizacion.Visible = False
        End If
    End Sub
    Private Sub CargarDatosLote()
        If ddl_lote.Items.Count > 0 Then
            Dim loteObj As New lote(Integer.Parse(ddl_lote.SelectedValue))
            lbl_superficie.Text = loteObj.superficie_m2
            lbl_precio_m2.Text = loteObj.precio_m2_sus
            lbl_precio_total.Text = loteObj.superficie_m2 * loteObj.precio_m2_sus
        Else
            lbl_superficie.Text = 0
            lbl_precio_m2.Text = 0
            lbl_precio_total.Text = 0
        End If
    End Sub
</script>
<table class="contratoFormTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="contratoFormTdMsg" colspan="4">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td class="contratoFormTdHorEnun">Localizacion</td>
        <td class="contratoFormTdHorEnun">Sector</td>
        <td class="contratoFormTdHorEnun">Manzano</td>
        <td class="contratoFormTdHorEnun">Lote</td>
    </tr>
    <tr>
        <td class="contratoFormTdHorDato">
            <asp:DropDownList ID="ddl_localizacion" runat="server" AutoPostBack="true" DataTextField="nombre" DataValueField="id_localizacion" DataSourceID="ods_lista_localizacion"></asp:DropDownList>
            <asp:HyperLink ID="hl_localizacion" runat="server" Target="_blank" Text="Ver"></asp:HyperLink>
        </td>
        <td class="contratoFormTdHorDato">
            <asp:DropDownList ID="ddl_urbanizacion" runat="server" AutoPostBack="true" DataTextField="nombre" DataValueField="id_urbanizacion" DataSourceID="ods_lista_urbanizacion"></asp:DropDownList>
            <asp:HyperLink ID="hl_urbanizacion" runat="server" Target="_blank" Text="Ver"></asp:HyperLink>
        </td>
        <td class="contratoFormTdHorDato">
            <asp:DropDownList ID="ddl_manzano" runat="server" AutoPostBack="true" DataTextField="codigo" DataValueField="id_manzano" DataSourceID="ods_lista_manzano"></asp:DropDownList>
        </td>
        <td class="contratoFormTdHorDato">
            <asp:DropDownList ID="ddl_lote" runat="server" AutoPostBack="true" DataTextField="codigo" DataValueField="id_lote" DataSourceID="ods_lista_lote"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfl_lote" runat="server" ControlToValidate="ddl_lote" Display="Dynamic" ValidationGroup="contrato" Text="*" ErrorMessage="Debe elegir un lote"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="contratoFormTdEnun">Superficie (m2):</td>
                    <%--<td class="contratoFormTdDato"><asp:TextBox ID="txt_superficie" runat="server" SkinID="txtSingleLine50" Enabled="false"></asp:TextBox></td>--%>
                    <td class="contratoFormTdDato"><asp:Label ID="lbl_superficie" runat="server"></asp:Label></td>
                    <td class="contratoFormTdEspacio"></td>
                    <td class="contratoFormTdEnun">Precio ($us/m2):</td>
                    <%--<td class="contratoFormTdDato"><asp:TextBox ID="txt_precio_m2" runat="server" SkinID="txtSingleLine50" Enabled="false"></asp:TextBox></td>--%>
                    <td class="contratoFormTdDato"><asp:Label ID="lbl_precio_m2" runat="server"></asp:Label></td>
                    <td class="contratoFormTdEspacio"></td>
                    <td class="contratoFormTdEnun">Precio total ($us):</td>
                    <%--<td class="contratoFormTdDato"><asp:TextBox ID="txt_precio_total" runat="server" SkinID="txtSingleLine50" Enabled="false"></asp:TextBox></td>--%>
                    <td class="contratoFormTdDato"><asp:Label ID="lbl_precio_total" runat="server"></asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<%--[id_localizacion],[codigo],[nombre],[imagen]--%>
<asp:ObjectDataSource ID="ods_lista_localizacion" runat="server" TypeName="terrasur.localizacion" SelectMethod="ListaConUrbanizacion">
    <SelectParameters>
        <asp:Parameter Name="Id_localizacion" Type="Int32" DefaultValue="0" />
    </SelectParameters>
</asp:ObjectDataSource>
<%--[id_urbanizacion],[id_localizacion],[codigo],[nombre_corto],[nombre]
[mantenimiento_sus],[costo_m2_sus],[precio_m2_sus],[imagen],[activo]--%>
<asp:ObjectDataSource ID="ods_lista_urbanizacion" runat="server" TypeName="terrasur.urbanizacion" SelectMethod="ListaPorActivo">
    <SelectParameters>
        <asp:ControlParameter Name="Id_localizacion" Type="Int32" ControlID="ddl_localizacion" PropertyName="SelectedValue" />
        <asp:Parameter Name="Activo" Type="Boolean" DefaultValue="True" />
    </SelectParameters>
</asp:ObjectDataSource>
<%--[id_manzano],[codigo],[num_lote]--%>
<asp:ObjectDataSource ID="ods_lista_manzano" runat="server" TypeName="terrasur.manzano" SelectMethod="Lista">
    <SelectParameters>
        <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="ddl_urbanizacion" PropertyName="SelectedValue" />
    </SelectParameters>
</asp:ObjectDataSource>
<%--[id_lote],[codigo]--%>
<asp:ObjectDataSource ID="ods_lista_lote" runat="server" TypeName="terrasur.lote" SelectMethod="ListaDisponible">
    <SelectParameters>
        <asp:ControlParameter Name="Id_manzano" Type="Int32" ControlID="ddl_manzano" PropertyName="SelectedValue" />
    </SelectParameters>
</asp:ObjectDataSource>