<%@ Control Language="C#" ClassName="contratoCambioSaldo" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>

<script runat="server">
    public int id_contrato {
        get {
            return int.Parse(lbl_id_contrato.Text);
        }
        set {
            lbl_id_contrato.Text = value.ToString();
        }
    }

    public void CargarActualizar()
    {
        txt_superficie.Text = "0";
        txt_saldo.Text = "0";
    }

    public bool Actualizar()
    {
        if (ActualizarSaldo(int.Parse(lbl_id_contrato.Text), decimal.Parse(txt_superficie.Text), decimal.Parse(txt_saldo.Text), Profile.id_usuario))
        {
            Msg1.Text = "Los datos del contrato se actualizaron correctamente";
            return true;
        }
        else
        {
            Msg1.Text = "Los datos del contrato NO se actualizaron correctamente";
        }
        return false;
    }

    private bool ActualizarSaldo(int id_contrato, decimal superficie, decimal saldo, int id_usuario)
    {
        try
        {
            Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
            DbCommand cmd = db1.GetStoredProcCommand("contrato_CambiarSaldo");
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
            db1.AddInParameter(cmd, "superficie_m2", DbType.Decimal, superficie);
            db1.AddInParameter(cmd, "saldo", DbType.Decimal, saldo);
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, id_usuario);
            db1.ExecuteNonQuery(cmd);
            return true;
        }
        catch
        {
            return false;
        }
    }
</script>

<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<table class="contratoFormTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="contratoFormTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_cambio" runat="server" DisplayMode="List" ValidationGroup="cambio" />
        </td>
    </tr>
    <tr>
        <td>
            <table align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="contratoFormTdHorEnun">Nueva Superficie<br />(m2)</td>
                    <td class="contratoFormTdHorEnun">Monto a<br />incrementar</td>
                </tr>
                <tr>
                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_superficie" runat="server" SkinID="txtSingleLine100" MaxLength="15" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_superficie" runat="server" ControlToValidate="txt_superficie" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cambio" Text="*" ErrorMessage="Debe introducir la superficie"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cv_superficie" runat="server" ControlToValidate="txt_superficie" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cambio" Operator="DataTypeCheck" Type="Double" Text="*" ErrorMessage="Debe introducir un número válido (usar , para decimales)"></asp:CompareValidator>
                    </td>

                    <td class="contratoFormTdHorDato">
                        <asp:TextBox ID="txt_saldo" runat="server" SkinID="txtSingleLine100" MaxLength="15" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_saldo" runat="server" ControlToValidate="txt_saldo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cambio" Text="*" ErrorMessage="Debe introducir el saldo a incrementar"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cv_saldo" runat="server" ControlToValidate="txt_saldo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cambio" Operator="DataTypeCheck" Type="Double" Text="*" ErrorMessage="Debe introducir un número válido (usar , para decimales)"></asp:CompareValidator>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
