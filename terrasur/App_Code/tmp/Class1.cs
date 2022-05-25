using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
	public Class1()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static DataTable abc(int n)
    {
        DataTable tabla = new DataTable();
        tabla.Columns.Add(new DataColumn("clase"));
        tabla.Columns.Add(new DataColumn("nombre"));
        tabla.Columns.Add(new DataColumn("paterno"));
        tabla.Columns.Add(new DataColumn("nit"));
        tabla.Columns.Add(new DataColumn("num"));
        for (int j = 0; j < n; j++)
        {
            DataRow fila = tabla.NewRow();
            fila["clase"] = (j % 10) + 1;
            fila["nombre"] = "nombre " + (j + 1);
            fila["paterno"] = "paterno " + (j + 1);
            fila["nit"] = "nit " + (j + 1);
            fila["num"] = j + 1;
            tabla.Rows.Add(fila);
        }
        return tabla;
    }

}
