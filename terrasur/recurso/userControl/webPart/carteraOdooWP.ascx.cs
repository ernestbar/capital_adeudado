using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using terrasur;


public partial class recurso_userControl_webPart_carteraOdooWP : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cuentas", "insert") == true)
        {
            btn_contrato_insert.Visible = true;
        }
        else
        {
            btn_contrato_insert.Visible = false;
        }
        if (Profile.entorno.id_rol == 1)
        {
            lbtnOdooMigracion.Visible = true;
        }
        else
        {   
            lbtnOdooMigracion.Visible = false; 
        }

    }

    protected void btn_contrato_insert_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/recurso/carteraOdoo/cuentas/Default.aspx");
    }

    protected void btn_contrato_lista_Click(object sender, EventArgs e)
    {

    }

    protected void r_reporte_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
    protected void lb_reporte_Click(object sender, EventArgs e)
    { }
    protected void lbtnOdooMigracion_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/modulo/consultas/odoo_migracion.aspx");
    }
}

