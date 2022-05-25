<%@ Control Language="VB" ClassName="contratoViewTitular" %>

<script runat="server">
    Public WriteOnly Property id_cliente() As Integer
        Set(ByVal value As Integer)
            Dim clienteObj As New cliente(value)
            Cargar(clienteObj.ci, clienteObj.id_lugarcedula, clienteObj.paterno, clienteObj.materno, clienteObj.nombres, _
            clienteObj.nit, clienteObj.fecha_nacimiento, clienteObj.celular, clienteObj.fax, clienteObj.email, clienteObj.casilla, _
            clienteObj.domicilio_direccion, clienteObj.domicilio_fono, clienteObj.domicilio_id_zona, clienteObj.oficina_direccion, _
            clienteObj.oficina_fono, clienteObj.oficina_id_zona, clienteObj.id_lugarcobro)
        End Set
    End Property

    Public Sub Cargar(ByVal ci As String, ByVal id_lugarcedula As Integer, _
    ByVal paterno As String, ByVal materno As String, ByVal nombres As String, ByVal nit As String, _
    ByVal fecha_nacimiento As DateTime, ByVal celular As String, ByVal fax As String, ByVal email As String, ByVal casilla As String, _
    ByVal domicilio_direccion As String, ByVal domicilio_fono As String, ByVal domicilio_id_zona As Integer, _
    ByVal oficina_direccion As String, ByVal oficina_fono As String, ByVal oficina_id_zona As Integer, _
    ByVal id_lugarcobro As Integer)
        lbl_ci.Text = ci & " " & New lugar_cedula(id_lugarcedula).codigo
        lbl_paterno.Text = paterno
        lbl_materno.Text = materno
        lbl_nombres.Text = nombres
        lbl_nit.Text = nit
        If fecha_nacimiento.Date = DateTime.Now.Date Then
            lbl_fecha.Text = ""
        Else
            lbl_fecha.Text = fecha_nacimiento.ToString("d")
        End If
        lbl_celular.Text = celular
        lbl_fax.Text = fax
        lbl_email.Text = email
        lbl_casilla.Text = casilla
        lbl_domicilio_direccion.Text = domicilio_direccion
        lbl_domicilio_fono.Text = domicilio_fono
        lbl_domicilio_zona.Text = (New zona(domicilio_id_zona)).nombre
        lbl_oficina_direccion.Text = oficina_direccion
        lbl_oficina_fono.Text = oficina_fono
        lbl_oficina_zona.Text = (New zona(oficina_id_zona)).nombre
        lbl_lugar_cobro.Text = (New lugar_cobro(id_lugarcobro)).nombre
        'If id_lugarcobro = 0 Then
        '    lbl_lugar_cobro.Text = New lugar_cobro("terrasur").nombre
        'Else
        '    lbl_lugar_cobro.Text = (New lugar_cobro(id_lugarcobro)).nombre
        'End If
    End Sub
</script>
<table class="contratoViewTable" align="left" cellpadding="0" cellspacing="0">
    <tr>
        <td rowspan="2" class="contratoFormTdLeft"></td>
        <td>
            <table class="contratoViewTable" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="contratoViewTdHorEnun">C.I.</td>
                    <td class="contratoViewTdHorEnun">Ap.Paterno</td>
                    <td class="contratoViewTdHorEnun">Ap.Materno</td>
                    <td class="contratoViewTdHorEnun">Nombre</td>
                    <td class="contratoViewTdHorEnun">NIT</td>
                </tr>
                <tr>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_ci" runat="server"></asp:Label></td>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_paterno" runat="server"></asp:Label></td>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_materno" runat="server"></asp:Label></td>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_nombres" runat="server"></asp:Label></td>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_nit" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="contratoViewTdHorEnun">F.Nacimiento</td>
                    <td class="contratoViewTdHorEnun">Celular</td>
                    <td class="contratoViewTdHorEnun">Fax</td>
                    <td class="contratoViewTdHorEnun">Email</td>
                    <td class="contratoViewTdHorEnun">Casilla</td>
                </tr>
                <tr>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_fecha" runat="server"></asp:Label></td>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_celular" runat="server"></asp:Label></td>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_fax" runat="server"></asp:Label></td>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_email" runat="server"></asp:Label></td>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_casilla" runat="server"></asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table class="contratoViewTable" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td></td>
                    <td class="contratoViewTdHorEnun">Dirección</td>
                    <td class="contratoViewTdHorEnun">Teléfono</td>
                    <td class="contratoViewTdHorEnun">Zona</td>
                </tr>
                <tr>
                    <td class="contratoViewTdEnun">Domicilio:</td>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_domicilio_direccion" runat="server"></asp:Label></td>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_domicilio_fono" runat="server"></asp:Label></td>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_domicilio_zona" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="contratoViewTdEnun">Oficina:</td>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_oficina_direccion" runat="server"></asp:Label></td>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_oficina_fono" runat="server"></asp:Label></td>
                    <td class="contratoViewTdHorDato"><asp:Label ID="lbl_oficina_zona" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="contratoViewTdEnun">Lugar de cobro:</td>
                                <td class="contratoViewTdDato"><asp:Label ID="lbl_lugar_cobro" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
