<%@ Control Language="VB" ClassName="contratoLoteFiltro" %>

<script runat="server">
    Public ReadOnly Property id_localizacion() As Integer
        Get
            Return Integer.Parse(ddl_localizacion.SelectedValue)
        End Get
    End Property
    Public ReadOnly Property id_urbanizacion() As Integer
        Get
            Return Integer.Parse(ddl_urbanizacion.SelectedValue)
        End Get
    End Property
    Public ReadOnly Property id_manzano() As Integer
        Get
            Return Integer.Parse(ddl_manzano.SelectedValue)
        End Get
    End Property
    Public ReadOnly Property id_lote() As Integer
        Get
            Return Integer.Parse(ddl_lote.SelectedValue)
        End Get
    End Property
    
    Public ReadOnly Property id_estado_contrato() As Integer
        Get
            Return Integer.Parse(ddl_estado.SelectedValue)
        End Get
    End Property
    Public ReadOnly Property id_promotor() As Integer
        Get
            Return Integer.Parse(ddl_promotor.SelectedValue)
        End Get
    End Property
    Public ReadOnly Property id_lugarcobro() As Integer
        Get
            Return Integer.Parse(ddl_lugarcobro.SelectedValue)
        End Get
    End Property
    Public ReadOnly Property por_cobrador() As Integer
        Get
            Return Integer.Parse(rbl_cobranza.SelectedValue)
        End Get
    End Property

    Public ReadOnly Property fecha_registro_inicio_existe() As Boolean
        Get
            Return cp_fecha_registro_inicio.SelectedValue.HasValue
        End Get
    End Property
    Public ReadOnly Property fecha_registro_inicio() As DateTime
        Get
            If cp_fecha_registro_inicio.SelectedValue.HasValue Then
                Return cp_fecha_registro_inicio.SelectedDate
            Else
                Return DateTime.Parse("12/12/9999")
            End If
        End Get
    End Property
    Public ReadOnly Property fecha_registro_fin_existe() As Boolean
        Get
            Return cp_fecha_registro_fin.SelectedValue.HasValue
        End Get
    End Property
    Public ReadOnly Property fecha_registro_fin() As DateTime
        Get
            If cp_fecha_registro_fin.SelectedValue.HasValue Then
                Return cp_fecha_registro_fin.SelectedDate
            Else
                Return DateTime.Parse("12/12/9999")
            End If
        End Get
    End Property

    Public ReadOnly Property fecha_proximo_inicio_existe() As Boolean
        Get
            Return cp_fecha_proximo_inicio.SelectedValue.HasValue
        End Get
    End Property
    Public ReadOnly Property fecha_proximo_inicio() As DateTime
        Get
            If cp_fecha_proximo_inicio.SelectedValue.HasValue Then
                Return cp_fecha_proximo_inicio.SelectedDate
            Else
                Return DateTime.Parse("12/12/9999")
            End If
        End Get
    End Property
    Public ReadOnly Property fecha_proximo_fin_existe() As Boolean
        Get
            Return cp_fecha_proximo_fin.SelectedValue.HasValue
        End Get
    End Property
    Public ReadOnly Property fecha_proximo_fin() As DateTime
        Get
            If cp_fecha_proximo_fin.SelectedValue.HasValue Then
                Return cp_fecha_proximo_fin.SelectedDate
            Else
                Return DateTime.Parse("12/12/9999")
            End If
        End Get
    End Property
    
    Public Function Verificar() As Boolean
        Dim correcto As Boolean = True
        If cp_fecha_registro_inicio.SelectedValue.HasValue AndAlso cp_fecha_registro_fin.SelectedValue.HasValue Then
            If cp_fecha_registro_inicio.SelectedDate > cp_fecha_registro_fin.SelectedDate Then
                Msg1.Text = "El intervalo de fechas de registro es incorrecto"
                correcto = False
            End If
        End If
        If cp_fecha_proximo_inicio.SelectedValue.HasValue AndAlso cp_fecha_proximo_fin.SelectedValue.HasValue Then
            If cp_fecha_proximo_inicio.SelectedDate > cp_fecha_proximo_fin.SelectedDate Then
                Msg1.Text = "El intervalo de fechas de próximo pago es incorrecto"
                correcto = False
            End If
        End If
        Return correcto
    End Function
    Public Sub Reset()
        ddl_localizacion.DataBind()
        ddl_urbanizacion.DataBind()
        ddl_manzano.DataBind()
        ddl_lote.DataBind()
        ddl_promotor.DataBind()
        ddl_lugarcobro.DataBind()
    End Sub
        

    Protected Sub ddl_loc_urb_man_lot_prom_lugar_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_localizacion.DataBound, ddl_urbanizacion.DataBound, ddl_manzano.DataBound, ddl_lote.DataBound, ddl_promotor.DataBound, ddl_lugarcobro.DataBound
        CType(sender, DropDownList).Items.Insert(0, New ListItem("Todos", "0"))
    End Sub
    'Protected Sub ddl_localizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_localizacion.DataBound
    'End Sub
    'Protected Sub ddl_urbanizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_urbanizacion.DataBound
    'End Sub
    'Protected Sub ddl_manzano_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_manzano.DataBound
    'End Sub
    'Protected Sub ddl_lote_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_lote.DataBound
    'End Sub
</script>
<table class="formHorTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formHorTdMsg" colspan="5">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <%--<asp:ValidationSummary ID="vs_contrato" runat="server" DisplayMode="List" ValidationGroup="contrato" />--%>
        </td>
    </tr>
    <tr>
        <td></td>
        <td class="formHorTdEnun">Localización</td>
        <td class="formHorTdEnun">Sector</td>
        <td class="formHorTdEnun">Manzano</td>
        <td class="formHorTdEnun">Lote</td>
    </tr>
    <tr>
        <td class="formHorTdEnun1">Lote:</td>
        <td class="formHorTdDato">
            <asp:DropDownList ID="ddl_localizacion" runat="server" AutoPostBack="true" DataTextField="nombre" DataValueField="id_localizacion" DataSourceID="ods_lista_localizacion"></asp:DropDownList>
        </td>
        <td class="formHorTdDato">
            <asp:DropDownList ID="ddl_urbanizacion" runat="server" AutoPostBack="true" DataTextField="nombre" DataValueField="id_urbanizacion" DataSourceID="ods_lista_urbanizacion"></asp:DropDownList>
        </td>
        <td class="formHorTdDato">
            <asp:DropDownList ID="ddl_manzano" runat="server" AutoPostBack="true" DataTextField="codigo" DataValueField="id_manzano" DataSourceID="ods_lista_manzano"></asp:DropDownList>
        </td>
        <td class="formHorTdDato">
            <asp:DropDownList ID="ddl_lote" runat="server" DataTextField="codigo" DataValueField="id_lote" DataSourceID="ods_lista_lote"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Estado del contrato:</td>
        <td class="formTdDato" colspan="4">
            <asp:DropDownList ID="ddl_estado" runat="server">
                <asp:ListItem Text="Todos" Value="-2" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Preasignado" Value="0"></asp:ListItem>
                <asp:ListItem Text="Vigente" Value="1"></asp:ListItem>
                <asp:ListItem Text="Revertido" Value="2"></asp:ListItem>
                <asp:ListItem Text="Liquidado" Value="3"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Promotor:</td>
        <td class="formTdDato" colspan="4">
            <asp:DropDownList ID="ddl_promotor" runat="server" DataTextField="nombre_completo" DataValueField="id_usuario" DataSourceID="ods_lista_promotor"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Lugar de cobro:</td>
        <td class="formTdDato" colspan="4">
            <asp:DropDownList ID="ddl_lugarcobro" runat="server" DataTextField="nombre" DataValueField="id_lugarcobro" DataSourceID="ods_lista_lugar_cobro"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Cobranza:</td>
        <td class="formTdDato" colspan="4">
            <asp:RadioButtonList ID="rbl_cobranza" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Ambos" Value="-1" Selected="true"></asp:ListItem>
                <asp:ListItem Text="Por cobrador" Value="1"></asp:ListItem>
                <asp:ListItem Text="Sin conbrador" Value="0"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Fecha de registro:</td>
        <td class="formTdDato" colspan="4">
            <table>
                <tr>
                    <td>
                        <%--<asp:RangeValidator ID="rv_fecha_registro_inicio" runat="server" ControlToValidate="cp_fecha_registro_inicio" Display="Dynamic" Type="Date" MinimumValue="01/01/1900" MaximumValue="01/01/2999" Text="*" ErrorMessage="Fecha incorrecta"></asp:RangeValidator>--%>
                        <%--<asp:CompareValidator ID="cv_fecha_registro_inicio" runat="server" ControlToValidate="cp_fecha_registro_inicio" Display="Dynamic" Type="Date" Operator="DataTypeCheck" Text="*" ErrorMessage="Fecha incorrecta"></asp:CompareValidator>--%>
                        <ew:CalendarPopup ID="cp_fecha_registro_inicio" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
                    </td>
                    <td>-</td>
                    <td>
                        <%--<asp:RangeValidator ID="rv_fecha_registro_fin" runat="server" ControlToValidate="cp_fecha_registro_fin" Display="Dynamic" Type="Date" MinimumValue="01/01/1900" MaximumValue="01/01/2999" Text="*" ErrorMessage="Fecha incorrecta"></asp:RangeValidator>--%>
                        <ew:CalendarPopup ID="cp_fecha_registro_fin" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Fecha de próximo pago:</td>
        <td class="formTdDato" colspan="4">
            <table>
                <tr>
                    <td>
                        <%--<asp:RangeValidator ID="rv_fecha_proximo_inicio" runat="server" ControlToValidate="cp_fecha_proximo_inicio" Display="Dynamic" Type="Date" MinimumValue="01/01/1900" MaximumValue="01/01/2999" Text="*" ErrorMessage="Fecha incorrecta"></asp:RangeValidator>--%>
                        <ew:CalendarPopup ID="cp_fecha_proximo_inicio" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
                    </td>
                    <td>-</td>
                    <td>
                        <%--<asp:RangeValidator ID="rv_fecha_proximo_fin" runat="server" ControlToValidate="cp_fecha_proximo_fin" Display="Dynamic" Type="Date" MinimumValue="01/01/1900" MaximumValue="01/01/2999" Text="*" ErrorMessage="Fecha incorrecta"></asp:RangeValidator>--%>
                        <ew:CalendarPopup ID="cp_fecha_proximo_fin" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<%--[id_localizacion],[codigo],[nombre],[imagen],[num_urbanizacion],[num_lote],[num_urbanizacion_activa]--%>
<asp:ObjectDataSource ID="ods_lista_localizacion" runat="server" TypeName="terrasur.localizacion" SelectMethod="Lista">
</asp:ObjectDataSource>
<%--[id_urbanizacion],[codigo],[nombre_corto],[nombre],[mantenimiento_sus],[costo_m2_sus],[precio_m2_sus],[imagen],[activo]--%>
<asp:ObjectDataSource ID="ods_lista_urbanizacion" runat="server" TypeName="terrasur.urbanizacion" SelectMethod="Lista">
    <SelectParameters>
        <asp:ControlParameter Name="Id_localizacion" Type="Int32" ControlID="ddl_localizacion" PropertyName="SelectedValue" />
    </SelectParameters>
</asp:ObjectDataSource>
<%--[id_manzano],[codigo],[num_lote]--%>
<asp:ObjectDataSource ID="ods_lista_manzano" runat="server" TypeName="terrasur.manzano" SelectMethod="Lista">
    <SelectParameters>
        <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="ddl_urbanizacion" PropertyName="SelectedValue" />
    </SelectParameters>
</asp:ObjectDataSource>
<%--[id_lote],[id_usuario],[fecha_registro],[codigo],[superficie_m2],[costo_m2_sus],[precio_m2_sus],[anterior_propietario],[num_partida]--%>
<asp:ObjectDataSource ID="ods_lista_lote" runat="server" TypeName="terrasur.lote" SelectMethod="Lista">
    <SelectParameters>
        <asp:ControlParameter Name="Id_manzano" Type="Int32" ControlID="ddl_manzano" PropertyName="SelectedValue" />
    </SelectParameters>
</asp:ObjectDataSource>
<%--[id_usuario],[paterno],[materno],[nombres],[nombre_completo],[ci],[nombre_usuario]--%>
<asp:ObjectDataSource ID="ods_lista_promotor" runat="server" TypeName="terrasur.promotor" SelectMethod="ListaActivoYAnteriores">
</asp:ObjectDataSource>
<%--[id_lugarcobro],[id_usuario],[codigo],[nombre],[cobrador],[num_clientes]--%>
<asp:ObjectDataSource ID="ods_lista_lugar_cobro" runat="server" TypeName="terrasur.lugar_cobro" SelectMethod="Lista">
</asp:ObjectDataSource>
