<%@ Control Language="C#" ClassName="contratoDatosReembolso" %>

<script runat="server">
    public int id_contrato
    {
        set
        {
            //Req. Conciliaciones
            if (terrasur.traspaso.reembolso.VerificarReembolsoContrato(value))
            {
                terrasur.traspaso.reembolso rObj = new terrasur.traspaso.reembolso(terrasur.traspaso.reembolso.Idreembolso_PorContrato(value));

                if (rObj.id_motivo == 2) // Traspaso por conciliación
                {
                    terrasur.traspaso.contrato_conciliacion ccObj = new terrasur.traspaso.contrato_conciliacion(value);
                    string firma = "";
                    if (ccObj.id_estadoconciliacion == 1)
                    {
                        firma = "y se encuentra pendiente de firma";
                    }
                    lbl_reembolso.Text = string.Format("El contrato tiene un traspaso por conciliación al contrato {0} realizado en fecha {1} {2}", rObj.num_contrato + "M", rObj.fecha.ToString("d"), firma);
                }
                else
                {
                    string tipo = "un traspaso realizado";
                    if (rObj.traspaso == false)
                    {
                        tipo = "una devolución realizada";
                    }
                    lbl_reembolso.Text = string.Format("El contrato {0} tiene {1} en fecha {2}", rObj.num_contrato, tipo, rObj.fecha.ToString("d"));
                }
            }
            else { lbl_reembolso.Text = ""; }
            //Req. Conciliaciones
        }
    }
</script>
<table width="100%" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Label ID="lbl_reembolso" runat="server" SkinID="lbl_CajaIngresoMensaje"></asp:Label>
        </td>
    </tr>
</table>
            