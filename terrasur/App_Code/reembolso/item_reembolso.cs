using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Data.Common;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;

using System.Text;
/// <summary>
/// Descripción breve de item_reembolso
/// </summary>
namespace terrasur
{
    namespace traspaso
    {
        public class item_reembolso
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_item = 0;
            private int _id_reembolso = 0;
            private decimal _preliminar = 0;
            private decimal _monto = 0;

            //Propiedades públicas
            public int id_item { get { return _id_item; } set { _id_item = value; } }
            public int id_reembolso { get { return _id_reembolso; } set { _id_reembolso = value; } }
            public decimal preliminar { get { return _preliminar; } set { _preliminar = value; } }
            public decimal monto { get { return _monto; } set { _monto = value; } }
            #endregion

            #region Constructores
            public item_reembolso(int Id_item, int Id_reembolso)
            {
                _id_item = Id_item;
                _id_reembolso = Id_reembolso;
            }
            public item_reembolso(int Id_item, int Id_reembolso, decimal Monto)
            {
                _id_item = Id_item;
                _id_reembolso = Id_reembolso;
                _monto = Monto;
            }
            public item_reembolso(int Id_item, int Id_reembolso, decimal Preliminar, decimal Monto)
            {
                _id_item = Id_item;
                _id_reembolso = Id_reembolso;
                _preliminar = Preliminar;
                _monto = Monto;
            }
            #endregion

            #region Métodos que NO requieren constructor
            public static DataTable Lista(int Id_reembolso)
            {
                //[id_item],[incremento],[incremento_string],[codigo],[nombre],[preliminar],[monto]
                DbCommand cmd = db1.GetStoredProcCommand("re_item_reembolso_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, Id_reembolso);
                DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];

                decimal Monto_total = 0;
                foreach(DataRow fila in tabla.Rows)
                {
                    if ((bool)fila["incremento"]) { Monto_total += (decimal)fila["monto"]; }
                    else { Monto_total -= (decimal)fila["monto"]; }
                }
                DataRow fila_total = tabla.NewRow();
                fila_total["id_item"] = 1000;
                fila_total["incremento"] = false;
                fila_total["incremento_string"] = "";
                fila_total["nombre"] = "Total";
                fila_total["preliminar"] = 0;
                fila_total["monto"] = Monto_total;
                tabla.Rows.Add(fila_total);

                return tabla;
            }

            public static DataTable Lista_para_reporte(int Id_reembolso, string Codigo_moneda)
            {
                //[grupo],[item],[monto],[monto_calculo],[moneda]
                DataTable tabla_origen = Lista(Id_reembolso);

                DataTable tabla = new DataTable();
                tabla.Columns.Add("grupo", typeof(string));
                tabla.Columns.Add("item", typeof(string));
                tabla.Columns.Add("monto", typeof(decimal));
                tabla.Columns.Add("monto_calculo", typeof(decimal));
                tabla.Columns.Add("moneda", typeof(string));

                foreach (DataRow fila_origen in tabla_origen.Rows)
                {
                    if (((int)fila_origen["id_item"]) != 1000)
                    {
                        DataRow fila = tabla.NewRow();

                        if (((bool)fila_origen["incremento"]) == true)
                        { fila["grupo"] = "A reconocerse:"; }
                        else { fila["grupo"] = "A descontar:"; }

                        fila["item"] = fila_origen["nombre"].ToString();
                        fila["monto"] = (decimal)fila_origen["monto"];

                        if (((bool)fila_origen["incremento"]) == true)
                        { fila["monto_calculo"] = (decimal)fila_origen["monto"]; }
                        else { fila["monto_calculo"] = ((decimal)fila_origen["monto"]) * (-1); }
                        
                        fila["moneda"] = Codigo_moneda;

                        tabla.Rows.Add(fila);
                    }
                }

                return tabla;
            }

            public static bool Verificar(int Id_reembolso, int Id_item)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_item_reembolso_Verificar");
                    db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, Id_reembolso);
                    db1.AddInParameter(cmd, "id_item", DbType.Int32, Id_item);

                    if ((int)db1.ExecuteScalar(cmd) == 0) { return false; }
                    else { return true; }
                }
                catch { return true; }
            }

            public static decimal MontoItem(int Id_reembolso, int Id_item)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_item_reembolso_MontoItem");
                    db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, Id_reembolso);
                    db1.AddInParameter(cmd, "id_item", DbType.Int32, Id_item);
                    return (decimal)db1.ExecuteScalar(cmd);
                }
                catch { return 0; }
            }

            #endregion

            #region Métodos que requieren constructor
            public bool Insertar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_item_reembolso_Insertar");
                    db1.AddInParameter(cmd, "id_item", DbType.Int32, _id_item);
                    db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, _id_reembolso);
                    db1.AddInParameter(cmd, "preliminar", DbType.Decimal, _preliminar);
                    db1.AddInParameter(cmd, "monto", DbType.Decimal, _monto);

                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }

            public bool Actualizar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_item_reembolso_Actualizar");
                    db1.AddInParameter(cmd, "id_item", DbType.Int32, _id_item);
                    db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, _id_reembolso);
                    db1.AddInParameter(cmd, "monto", DbType.Decimal, _monto);

                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }

            public bool Eliminar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_item_reembolso_Eliminar");
                    db1.AddInParameter(cmd, "id_item", DbType.Int32, _id_item);
                    db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, _id_reembolso);

                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);
                    db1.ExecuteNonQuery(cmd);
                    return true;
                }
                catch { return false; }
            }

            #endregion
        }

        public class tmpItemReembolso
        {
            #region Propiedades
            //Propiedades privadas
            private int _id_item = 0;
            private bool _incremento = false;
            private string _incremento_string = "";
            private string _nombre = "";
            private decimal _preliminar = 0;
            private decimal _monto = 0;

            //Propiedades públicas
            public int id_item { get { return _id_item; } set { _id_item = value; } }
            public bool incremento { get { return _incremento; } set { _incremento = value; } }
            public string incremento_string { get { return _incremento_string; } set { _incremento_string = value; } }
            public string nombre { get { return _nombre; } set { _nombre = value; } }
            public decimal preliminar { get { return _preliminar; } set { _preliminar = value; } }
            public decimal monto { get { return _monto; } set { _monto = value; } }
            #endregion

            #region Constructores
            public tmpItemReembolso(int Id_item, decimal Preliminar, decimal Monto)
            {
                _id_item = Id_item;

                item iObj = new item(Id_item);
                _incremento = iObj.incremento;
                if (iObj.incremento) { _incremento_string = "+"; } else { _incremento_string = "-"; }
                _nombre = iObj.nombre;

                _preliminar = Preliminar;
                _monto = Monto;
            }

            public tmpItemReembolso(int Id_item, bool Incremento, string Incremento_string, string Nombre, decimal Preliminar, decimal Monto)
            {
                _id_item = Id_item;
                _incremento = Incremento;
                _incremento_string = Incremento_string;
                _nombre = Nombre;
                _preliminar = Preliminar;
                _monto = Monto;
            }
            #endregion


            #region Métodos que NO requieren constructor
            public static string Lista_a_Cadena(List<tmpItemReembolso> lista)
            {
                StringBuilder str = new StringBuilder();
                foreach (tmpItemReembolso item in lista)
                {
                    str.Append(item.id_item.ToString() + "·"
                    + item.incremento.ToString() + "·"
                    + item.incremento_string + "·"
                    + item.nombre + "·"
                    + item.preliminar.ToString() + "·"
                    + item.monto.ToString() + "|");
                }
                return str.ToString().TrimEnd('|');
            }
            
            public static List<tmpItemReembolso> Cadena_a_Lista(string strItem)
            {
                List<tmpItemReembolso> lista = new List<tmpItemReembolso>();
                if (!string.IsNullOrEmpty(strItem))
                {
                    string[] datos_row = strItem.Split('|');
                    for (int j = 0; j < datos_row.Length; j++)
                    {
                        string[] datos_col = datos_row[j].Split('·');
                        lista.Add(new tmpItemReembolso(
                            int.Parse(datos_col[0]), 
                            bool.Parse(datos_col[1]), 
                            datos_col[2], 
                            datos_col[3], 
                            decimal.Parse(datos_col[4]), 
                            decimal.Parse(datos_col[5])));
                    }
                }
                return lista;
            }

            public static DataTable Cadena_a_tabla(string strItem)
            {
                //[id_item],[incremento],[incremento_string],[nombre],[preliminar],[monto]
                List<tmpItemReembolso> lista = Cadena_a_Lista(strItem);
                DataTable tabla = new DataTable();
                tabla.Columns.Add("id_item", typeof(int));
                tabla.Columns.Add("incremento", typeof(bool));
                tabla.Columns.Add("incremento_string", typeof(string));
                tabla.Columns.Add("nombre", typeof(string));
                tabla.Columns.Add("preliminar", typeof(decimal));
                tabla.Columns.Add("monto", typeof(decimal));

                if (lista.Count > 0)
                {
                    decimal Monto_total = 0;
                    foreach (tmpItemReembolso i in lista)
                    {
                        DataRow fila = tabla.NewRow();
                        fila["id_item"] = i.id_item;
                        fila["incremento"] = i.incremento;
                        fila["incremento_string"] = i.incremento_string;
                        fila["nombre"] = i.nombre;
                        fila["preliminar"] = i.preliminar;
                        fila["monto"] = i.monto;
                        tabla.Rows.Add(fila);

                        if (i.incremento) { Monto_total += i.monto; }
                        else { Monto_total -= i.monto; }
                    }

                    DataRow fila_total = tabla.NewRow();
                    fila_total["id_item"] = 1000;
                    fila_total["incremento"] = false;
                    fila_total["incremento_string"] = "";
                    fila_total["nombre"] = "Total";
                    fila_total["preliminar"] = 0;
                    fila_total["monto"] = Monto_total;
                    tabla.Rows.Add(fila_total);
                }
                tabla.DefaultView.Sort = "incremento desc,id_item";
                return tabla.DefaultView.ToTable();
            }


            public static string ListaPreliminar(bool Traspaso, int Id_contrato, DateTime Fecha)
            {
                //[id_item],[preliminar]
                DataTable tabla = terrasur.traspaso.item.ListaPredeterminada(Traspaso, Id_contrato, Fecha);
                string strItem = "";
                foreach (DataRow fila in tabla.Rows) { strItem = Agregar(strItem, (int)fila["id_item"], (decimal)fila["preliminar"]); }
                return strItem;
            }

            public static string Agregar(string strItem, int Id_item, int Id_contrato, DateTime Fecha, decimal Monto)
            {
                List<tmpItemReembolso> lista = Cadena_a_Lista(strItem);
                decimal Preliminar= terrasur.traspaso.item.MontoPredeterminadoPorContrato(Id_item, Id_contrato, Fecha);
                lista.Add(new tmpItemReembolso(Id_item, Preliminar, Monto));
                return Lista_a_Cadena(lista);
            }

            private static string Agregar(string strItem, int Id_item, decimal Preliminar)
            {
                List<tmpItemReembolso> lista = Cadena_a_Lista(strItem);
                lista.Add(new tmpItemReembolso(Id_item, Preliminar, Preliminar));
                return Lista_a_Cadena(lista);
            }

            public static string Retirar(string strItem, int Id_item)
            {
                List<tmpItemReembolso> lista = Cadena_a_Lista(strItem);
                if (lista.FindIndex(delegate(tmpItemReembolso i) { return i.id_item == Id_item; }) >= 0)
                {
                    lista.Remove(lista.Find(delegate(tmpItemReembolso i) { return i.id_item == Id_item; }));
                }
                return Lista_a_Cadena(lista);
            }

            public static bool Verificar(string strItem, int Id_item)
            {
                List<tmpItemReembolso> lista = Cadena_a_Lista(strItem);
                if (lista.FindIndex(delegate(tmpItemReembolso i) { return i.id_item == Id_item; }) >= 0)
                {
                    return true;
                }
                else { return false; }
            }

            public static decimal MontoTotal(string strItem)
            {
                decimal Monto_total = 0;
                List<tmpItemReembolso> lista = Cadena_a_Lista(strItem);
                foreach (tmpItemReembolso i in lista)
                {
                    if (i.incremento) { Monto_total += i.monto; }
                    else { Monto_total -= i.monto; }
                }
                return Monto_total;
            }

            public static string ActualizarMontos(string strItem, string strMontos)
            {
                List<tmpItemReembolso> lista = Cadena_a_Lista(strItem);
                string[] lista_item_monto = strMontos.Split('|');
                for (int j = 0; j < lista_item_monto.Length; j++)
                {
                    int Id_item = int.Parse((lista_item_monto[j].Split(';'))[0]);
                    decimal Monto = decimal.Parse((lista_item_monto[j].Split(';'))[1]);

                    if (lista.FindIndex(delegate(tmpItemReembolso i) { return i.id_item == Id_item; }) >= 0)
                    {
                        lista.Find(delegate(tmpItemReembolso i) { return i.id_item == Id_item; }).monto = Monto;
                    }
                }
                return Lista_a_Cadena(lista);
            }

            #endregion
        }
    }
}