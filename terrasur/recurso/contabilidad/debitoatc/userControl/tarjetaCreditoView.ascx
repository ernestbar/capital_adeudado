<%@ Control Language="VB" ClassName="tarjetaCreditoView" %>

<script runat="server">
    Public WriteOnly Property id_tarjetacredito() As Integer
        Set(ByVal value As Integer)
            Dim tcObj As New tarjeta_credito(value)
            lbl_num_tarjeta.Text = tcObj.numero
            lbl_fecha_vencicmiento.Text = tcObj.vencimiento_mes & "/" & tcObj.vencimiento_anio
            lbl_tipo_tarjeta.Text = tcObj.tipo_tarjeta_nombre
            lbl_banco.Text = tcObj.banco_nombre
            lbl_titular_nombre.Text = tcObj.titular
            lbl_titular_ci.Text = tcObj.ci & " " & tcObj.lugar_cedula_codigo
            If tcObj.activo = True Then
                lbl_activo.Text = "Activa"
            Else
                lbl_activo.Text = "Inactiva"
            End If

            lbl_registro.Text = tcObj.registro_usuario & " (" & tcObj.registro_fecha & ")"
            lbl_actualizacion.Text = tcObj.actualizacion_usuario & " (" & tcObj.actualizacion_fecha & ")"
        End Set
    End Property
    Public WriteOnly Property MostrarDatosRegistro() As Boolean
        Set(ByVal value As Boolean)
            panel_registro.Visible = value
        End Set
    End Property
        
</script>
<table align="center">
    <tr>
        <td>
            <asp:Panel ID="panel_datos" runat="server" GroupingText="Datos de la tarjeta de crédito">
                <table class="viewTable" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="viewTdEnun">Nº tarjeta:</td>
                        <td class="viewTdDato"><asp:Label ID="lbl_num_tarjeta" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun">Fecha de vencimiento:</td>
                        <td class="viewTdDato"><asp:Label ID="lbl_fecha_vencicmiento" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun">Tipo de tarjeta:</td>
                        <td class="viewTdDato"><asp:Label ID="lbl_tipo_tarjeta" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun">Banco:</td>
                        <td class="viewTdDato"><asp:Label ID="lbl_banco" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun">Titular:</td>
                        <td class="viewTdDato"><asp:Label ID="lbl_titular_nombre" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun">Titular (CI):</td>
                        <td class="viewTdDato"><asp:Label ID="lbl_titular_ci" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun">Tarjeta activa:</td>
                        <td class="viewTdDato"><asp:Label ID="lbl_activo" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_registro" runat="server" GroupingText="Registro de la tarjeta de crédito">
                <table class="viewTable" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="viewTdEnun">Registro de la tarjeta:</td>
                        <td class="viewTdDato"><asp:Label ID="lbl_registro" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun">Última actualización:</td>
                        <td class="viewTdDato"><asp:Label ID="lbl_actualizacion" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
