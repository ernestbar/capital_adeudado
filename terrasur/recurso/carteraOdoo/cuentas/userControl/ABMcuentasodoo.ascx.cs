using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using terrasur;
public partial class recurso_carteraOdoo_cuentas_userControl_ABMcuentasodoo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAddDebito_Click(object sender, EventArgs e)
    {
        cuentaContable obj = new cuentaContable(0, int.Parse(ddlOperacion.SelectedValue), txtDebito.Text, txtNombreCuenta.Text, txtDescripcion.Text, true, false, true, Profile.id_usuario, decimal.Parse(txtPorcentaje.Text.Replace(".", ",")) /100);
        obj.Insertar();
        odsCuentasDebito.DataBind();
        lbCuentasDebito.DataBind();
    }

    protected void ddlOperacion_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnDelDebito_Click(object sender, EventArgs e)
    {
        if (lbCuentasDebito.SelectedIndex !=-1)
        {
            cuentaContable obj = new cuentaContable(int.Parse(lbCuentasDebito.SelectedValue), int.Parse(ddlOperacion.SelectedValue), txtDebito.Text, txtNombreCuenta.Text, txtDescripcion.Text, true, false, false, Profile.id_usuario, decimal.Parse(txtPorcentaje.Text.Replace(".",","))/100);
            obj.Eliminar();
            odsCuentasDebito.DataBind();
            lbCuentasDebito.DataBind();
        }
        
    }

    protected void btnAddCredito_Click(object sender, EventArgs e)
    {
        cuentaContable obj = new cuentaContable(0, int.Parse(ddlOperacion.SelectedValue), txtCredito.Text, txtNombreCuenta.Text, txtDescripcion.Text, false, true, true, Profile.id_usuario, decimal.Parse(txtPorcentaje.Text.Replace(".", ",")) /100);
        obj.Insertar();
        odsCuentasCredito.DataBind();
        lbCuentasCredito.DataBind();
    }

    protected void btnDelCredito_Click(object sender, EventArgs e)
    {
        if (lbCuentasCredito.SelectedIndex !=-1)
        {
            cuentaContable obj = new cuentaContable(int.Parse(lbCuentasCredito.SelectedValue), int.Parse(ddlOperacion.SelectedValue), txtDebito.Text, txtNombreCuenta.Text, txtDescripcion.Text, true, false, false, Profile.id_usuario, decimal.Parse(txtPorcentaje.Text.Replace(".", ",")) /100);
            obj.Eliminar();
            odsCuentasCredito.DataBind();
            lbCuentasCredito.DataBind();
        }
    }

    protected void txtPorcentaje_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btnProbar_Click(object sender, EventArgs e)
    {
        string decSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
        decimal sum_credito = 0;
        decimal sum_debito = 0;
        foreach (ListItem item in lbCuentasDebito.Items)
        {
            string[] cuenta = item.Text.Split('|');
            sum_debito = sum_debito + (decimal.Parse(txtMonto.Text.Replace(".", decSep)) * decimal.Parse(cuenta[2].Replace(".",decSep))/100);

        }

        lblSumaDebito.Text = sum_debito.ToString();
        foreach (ListItem item2 in lbCuentasCredito.Items)
        {
            string[] cuenta2 = item2.Text.Split('|');
            sum_credito = sum_credito + (decimal.Parse(txtMonto.Text.Replace(".", decSep)) * decimal.Parse(cuenta2[2].Replace(".", decSep))/100);

        }
        lblSumaCredito.Text = sum_credito.ToString();
        if (sum_credito != sum_debito)
            lblMsgComprobacion.Text = "Las cuentas no cuadran, agregue la cuenta que fatla o una cuenta de diferencia.";
        else
            lblMsgComprobacion.Text = "";


    }
}