<%@ Page Language="C#" AutoEventWireup="true" CodeFile="odoo_cartera_detalles.aspx.cs" Inherits="modulo_consultas_odoo_cartera_detalles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>DETALLES DEL MOVIMIENTO CONTABLE</h3>
        <br />

        <table class="formTable">
            <tr>
                <td class="formTdEnun">
                    &nbsp;</td>
                <td class="formTdEnun">
                    Bs.</td>
                <td class="formTdEnun">
                    $us.</td>
            </tr>
            <tr>
                <td class="formTdEnun">
                    CONTRATO:</td>
                <td class="formTdDato">
                    <asp:Label ID="lblContrato" runat="server"></asp:Label>
                </td>
                <td class="formTdDato">
                    &nbsp;</td>
            </tr>
              <tr>
                <td class="formTdEnun">
                    URBANIZACION:</td>
                <td class="formTdDato">
                    <asp:Label ID="lblUrb" runat="server"></asp:Label>
                </td>
                <td class="formTdDato">
                    &nbsp;</td>
            </tr>
              <tr>
                <td class="formTdEnun">
                    MANZANO:</td>
                <td class="formTdDato">
                    <asp:Label ID="lblMzno" runat="server"></asp:Label>
                </td>
                <td class="formTdDato">
                    &nbsp;</td>
            </tr>
              <tr>
                <td class="formTdEnun">
                    LOTE:</td>
                <td class="formTdDato">
                    <asp:Label ID="lblLote" runat="server"></asp:Label>
                </td>
                <td class="formTdDato">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="formTdEnun">
                    MONEDA DEL CONTRATO:</td>
                <td class="formTdDato">
                    <asp:Label ID="lblMoneda" runat="server"></asp:Label>
                </td>
                <td class="formTdDato">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="formTdEnun">
                    MONTO PAGO:</td>
                <td class="formTdDato">
                    <asp:Label ID="lblMonto_bs" runat="server"></asp:Label>
                </td>
                <td class="formTdDato">
                    <asp:Label ID="lblMonto_sus" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formTdEnun">
                    INTERES:</td>
                <td class="formTdDato">
                    <asp:Label ID="lblInteres_bs" runat="server"></asp:Label>
                </td>
                <td class="formTdDato">
                    <asp:Label ID="lblInteres_sus" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formTdEnun">
                    CAPITAL:</td>
                <td class="formTdDato">
                    <asp:Label ID="lblCapital_bs" runat="server"></asp:Label>
                </td>
                <td class="formTdDato">
                    <asp:Label ID="lblCapital_sus" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formTdEnun">
                    TIPO PAGO:</td>
                <td class="formTdDato">
                    <asp:Label ID="lblTipoPago" runat="server"></asp:Label>
                </td>
                <td class="formTdDato">
                   &nbsp;
                </td>
            </tr>
            <tr>
                <td class="formTdEnun">
                    NRO. FACTURA:</td>
                <td class="formTdDato">
                    <asp:Label ID="lblFactura" runat="server"></asp:Label>
                </td>
                <td class="formTdDato">
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="formTdEnun">
                    NRO. RECIBO:</td>
                <td class="formTdDato">
                    <asp:Label ID="lblRecibo" runat="server"></asp:Label>
                </td>
                <td class="formTdDato">
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="formTdEnun">
                    NRO. DPR:</td>
                <td class="formTdDato">
                    <asp:Label ID="lblDpr" runat="server"></asp:Label>
                </td>
                <td class="formTdDato">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="formTdEnun">
                    FECHA PAGO:</td>
                <td class="formTdDato">
                    <asp:Label ID="lblFecha" runat="server"></asp:Label>
                </td>
                <td class="formTdDato">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="formTdEnun">
                    SUCURSAL:</td>
                <td class="formTdDato">
                    <asp:Label ID="lblSucursal" runat="server"></asp:Label>
                </td>
                <td class="formTdDato">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="formTdEnun">
                    TIPO DE CAMBIO:</td>
                <td class="formTdDato">
                    <asp:Label ID="lblTc" runat="server"></asp:Label>
                </td>
                <td class="formTdDato">
                    &nbsp;</td>
            </tr>
        </table>

    </div>
    </form>
</body>
</html>
