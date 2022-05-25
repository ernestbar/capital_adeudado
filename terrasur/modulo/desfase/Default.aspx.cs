using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


public partial class modulo_desfase_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ContratoBusqueda1.Eleccion += busqueda_realizada;
    }
    protected void busqueda_realizada(object sender, System.EventArgs e)
    {
        // If VerificarPermiso(8, 11, ContratoBusqueda1.id_resultado) Then
        int Id_contrato = ContratoBusqueda1.id_resultado;
        if (Id_contrato > 0)
        {
            PanelEstao.Visible = true;
            lblIdContrato.Text = Id_contrato.ToString();
            ods_estado_contrato.DataBind();
            gv_estado.DataBind();
        }
        else
        {
            lblIdContrato.Text = "0";
            PanelEstao.Visible = false;
        }
      

    }


    protected void gv_estado_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)

        {
            string fin = e.Row.Cells[0].Text;
            string fin2 = e.Row.Cells[1].Text;
            string encoded = e.Row.Cells[2].Text;
            
            decimal monto = decimal.Parse(encoded);
            if (monto == 0)
            {
               // e.Row.BackColor = Color.Red;
                e.Row.ForeColor = Color.Red;
            }
            if (fin == "999")
            {
                e.Row.Cells[0].Text = "";
                e.Row.Cells[1].Text = "TOTAL";
                e.Row.Cells[1].Font.Bold = true;
                e.Row.Cells[2].Font.Bold = true;
                e.Row.Cells[3].Font.Bold = true;
                e.Row.Cells[4].Font.Bold = true;
                e.Row.Cells[5].Font.Bold = true;
				 e.Row.Cells[6].Font.Bold = true;
				  e.Row.Cells[7].Font.Bold = true;
            }
            
        }
    }

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        HttpResponse response = Response;
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        System.Web.UI.Page pageToRender = new System.Web.UI.Page();
        HtmlForm form = new HtmlForm();
        form.Controls.Add(gv_estado);
        pageToRender.Controls.Add(form);
        response.Clear();
        response.Buffer = true;
        response.ContentType = "application/vnd.ms-excel";
        response.AddHeader("Content-Disposition", "attachment;filename=EstadoDesfasado.xls");
        response.Charset = "UTF-8";
        response.ContentEncoding = Encoding.Default;
        pageToRender.RenderControl(htw);
        response.Write(sw.ToString());
        response.End();
    }

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/recurso/contrato/reporteContrato/reporteContratoEstadoCuenta.aspx?t=");
    }
}

