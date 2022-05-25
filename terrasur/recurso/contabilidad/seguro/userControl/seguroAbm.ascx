<%@ Control Language="VB" ClassName="seguroAbm" %>

<script runat="server">
    Protected Property id_contrato() As Integer
        Get
            Return Integer.Parse(lbl_id_contrato.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_contrato.Text = value
        End Set
    End Property
    
    Public Sub Cargar(ByVal _Id_contrato As Integer)
        id_contrato = _Id_contrato

        'If contrato.EsContratoVenta(id_contrato) = True Then
        Dim c As New contrato_venta(id_contrato)
        lbl_num_contrato.Text = c.numero
        lbl_lote_servicio.Text = c.localizacion_nombre + " / " + c.urbanizacion_nombre + " / " + c.manzano_codigo + " / " + c.lote_codigo
        Dim cli As New cliente(c.id_titular)
        lbl_cliente.Text = cli.paterno + " " + cli.materno + " " + cli.nombres + " (CI: " + cli.ci + " " + cli.codigo_lugarcedula + ")"
        Dim seg As New seguro_provida(id_contrato)
        txt_num_seguro.Text = seg.numero
        'Else
        '    Dim c As New contrato_servicio_funerario(id_contrato)
        '    lbl_num_contrato.Text = c.numero
        '    lbl_lote_servicio.Text = "Servicios funerarios"
        '    Dim cli As New cliente(c.id_titular)
        '    lbl_cliente.Text = cli.paterno + " " + cli.materno + " " + cli.nombres + " (CI: " + cli.ci + " " + cli.codigo_lugarcedula + ")"
        '    Dim seg As New seguro_provida(id_contrato)
        '    txt_num_seguro.Text = seg.numero
        'End If
        
        Dim permiso_asignar_update As Boolean = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguro", "asignar_update")
        If txt_num_seguro.Text = "0" Then
            txt_num_seguro.Text = ""
        End If
        txt_num_seguro.Focus()
        rbl_registrar.SelectedValue = "registrar"
        rbl_registrar.Enabled = permiso_asignar_update
    End Sub
    
    Public Function Verificar() As Boolean
        Dim correcto As Boolean = True
        If seguro_provida.VerificarUtilizado(id_contrato, Integer.Parse(txt_num_seguro.Text.Trim)) = True Then
            Msg1.Text = "El número de seguro " & txt_num_seguro.Text.Trim & " ya fue utilizado en el contrato " & seguro_provida.Num_contrato_por_seguro(0, Integer.Parse(txt_num_seguro.Text.Trim), False)
            
            correcto = False
        End If
        Return correcto
    End Function
    
    Public Function Asignar() As Boolean
        If Verificar() = True Then
            If New seguro_provida(id_contrato, Profile.id_usuario, Integer.Parse(txt_num_seguro.Text.Trim)).Asignar(rbl_registrar.SelectedValue.Equals("registrar")) = True Then
                Msg1.Text = "La asignación se realizó correctamente"
                Return True
            Else
                Msg1.Text = "La asignación NO se realizó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function
</script>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_seguro" runat="server" DisplayMode="List" ValidationGroup="seguro" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Asignación de número de seguro a contrato"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Nro. contrato:</td>
        <td class="formTdDato"><asp:Label ID="lbl_num_contrato" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">Lote / Servicio:</td>
        <td class="formTdDato"><asp:Label ID="lbl_lote_servicio" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">Cliente:</td>
        <td class="formTdDato"><asp:Label ID="lbl_cliente" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">Nro. seguro:</td>
        <td class="formTdDato">
            <table cellspacing="0">
                <tr>
                    <td>
                        <asp:TextBox ID="txt_num_seguro" runat="server" SkinID="txtSingleLine50" MaxLength="5"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_num_seguro" runat="server" ControlToValidate="txt_num_seguro" Display="Dynamic" Text="*" ErrorMessage="Debe digitar el número de seguro" ValidationGroup="seguro"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rv_num_seguro" runat="server" ControlToValidate="txt_num_seguro" Type="Integer" MinimumValue="0" MaximumValue="99999" Display="Dynamic" Text="*" ErrorMessage="Debe digitar un número entero válido" ValidationGroup="seguro"></asp:RangeValidator>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rbl_registrar" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Nuevo seguro" Value="registrar" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Correción del seguro" Value="corregir"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
