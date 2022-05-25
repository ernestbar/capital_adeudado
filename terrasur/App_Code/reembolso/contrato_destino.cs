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
/// Descripción breve de contrato_destino
/// </summary>
namespace terrasur
{
    namespace traspaso
    {
        public class contrato_destino
        {
            //Base de datos
            private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

            #region Propiedades
            //Propiedades privadas
            private int _id_contratodestino = 0;
            private int _id_reembolso = 0;
            private int _id_contrato = 0;
            private int _id_moneda_contrato = 0;
            private string _num_contrato = "";
            private string _negocio = "";
            private string _producto = "";
            private string _cliente = "";
            private decimal _monto_sus = 0;
            private decimal _monto_bs = 0;
            private decimal _tipo_cambio = 0;

            //Propiedades públicas
            public int id_contratodestino { get { return _id_contratodestino; } set { _id_contratodestino = value; } }
            public int id_reembolso { get { return _id_reembolso; } set { _id_reembolso = value; } }
            public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
            public int id_moneda_contrato { get { return _id_moneda_contrato; } set { _id_moneda_contrato = value; } }
            public string num_contrato { get { return _num_contrato; } set { _num_contrato = value; } }
            public string negocio { get { return _negocio; } set { _negocio = value; } }
            public string producto { get { return _producto; } set { _producto = value; } }
            public string cliente { get { return _cliente; } set { _cliente = value; } }
            public decimal monto_sus { get { return _monto_sus; } set { _monto_sus = value; } }
            public decimal monto_bs { get { return _monto_bs; } set { _monto_bs = value; } }
            public decimal tipo_cambio { get { return _tipo_cambio; } set { _tipo_cambio = value; } }
            #endregion

            #region Constructores
            public contrato_destino(int Id_contratodestino)
            {
                _id_contratodestino = Id_contratodestino;
            }

            public contrato_destino(int Id_reembolso, int Id_contrato, int Id_moneda_contrato,
                string Num_contrato, string Negocio, string Producto, string Cliente, 
                decimal Monto_sus, decimal Monto_bs, decimal Tipo_cambio)
            {
                _id_reembolso = Id_reembolso;
                _id_contrato = Id_contrato;
                _id_moneda_contrato = Id_moneda_contrato;
                _num_contrato = Num_contrato;
                _negocio = Negocio;
                _producto = Producto;
                _cliente = Cliente;
                _monto_sus = Monto_sus;
                _monto_bs = Monto_bs;
                _tipo_cambio = Tipo_cambio;
            }
            #endregion

            #region Métodos que NO requieren constructor
            public static DataTable Lista(int Id_reembolso, string Codigo_moneda)
            {
                //[id_contratodestino],[num_contrato],[id_moneda],[codigo_moneda],[negocio],[producto],[cliente],[monto_sus],[monto_bs],[tipo_cambio]
                DbCommand cmd = db1.GetStoredProcCommand("re_contrato_destino_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, Id_reembolso);
                DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];

                decimal Monto_total = 0;
                foreach (DataRow fila in tabla.Rows)
                {
                    if (Codigo_moneda == "$us") { Monto_total += (decimal)fila["monto_sus"]; }
                    else { Monto_total += (decimal)fila["monto_bs"]; }
                }

                DataRow fila_total = tabla.NewRow();
                fila_total["num_contrato"] = "Total";
                if (Codigo_moneda == "$us") { fila_total["monto_sus"] = Monto_total; }
                else { fila_total["monto_bs"] = Monto_total; }
                tabla.Rows.Add(fila_total);

                return tabla;
            }

            public static DataTable Lista_para_reporte(int Id_reembolso, string Codigo_moneda)
            {
                //[id_contratodestino],[num_contrato],[id_moneda],[codigo_moneda],[negocio],[producto],[cliente],[monto_sus],[monto_bs],[tipo_cambio]
                DbCommand cmd = db1.GetStoredProcCommand("re_contrato_destino_Lista");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, Id_reembolso);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }

            public static bool Verificar(bool Insertar, int Id_reembolso, int Id_contratodestino, int Id_contrato, string Num_contrato)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_contrato_destino_Verificar");
                    db1.AddInParameter(cmd, "insertar", DbType.Boolean, Insertar);
                    db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, Id_reembolso);
                    db1.AddInParameter(cmd, "id_contratodestino", DbType.Int32, Id_contratodestino);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                    db1.AddInParameter(cmd, "num_contrato", DbType.String, Num_contrato);

                    if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
                    else { return false; }
                }
                catch { return true; }
            }

            #endregion

            #region Métodos que requieren constructor
            public bool Insertar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_contrato_destino_Insertar");
                    db1.AddInParameter(cmd, "id_reembolso", DbType.Int32, _id_reembolso);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, _id_contrato);
                    db1.AddInParameter(cmd, "id_moneda_contrato", DbType.Int32, _id_moneda_contrato);
                    db1.AddInParameter(cmd, "num_contrato", DbType.String, _num_contrato);
                    db1.AddInParameter(cmd, "negocio", DbType.String, _negocio);
                    db1.AddInParameter(cmd, "producto", DbType.String, _producto);
                    db1.AddInParameter(cmd, "cliente", DbType.String, _cliente);
                    db1.AddInParameter(cmd, "monto_sus", DbType.Decimal, _monto_sus);
                    db1.AddInParameter(cmd, "monto_bs", DbType.Decimal, _monto_bs);
                    db1.AddInParameter(cmd, "tipo_cambio", DbType.Decimal, _tipo_cambio);
                    
                    db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Audit_id_usuario);
                    db1.AddInParameter(cmd, "audit_ip", DbType.String, Audit_ip);
                    db1.AddInParameter(cmd, "audit_host", DbType.String, Audit_host);
                    
                    _id_contratodestino = (int)db1.ExecuteScalar(cmd);
                    return true;
                }
                catch { return false; }
            }

            public bool Eliminar(int Audit_id_usuario, string Audit_ip, string Audit_host)
            {
                try
                {
                    DbCommand cmd = db1.GetStoredProcCommand("re_contrato_destino_Eliminar");
                    db1.AddInParameter(cmd, "id_contratodestino", DbType.Int32, _id_contratodestino);

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

        public class tmpContratoDestino
        {
            //Base de datos
            private static Database db1_terrasur = DatabaseFactory.CreateDatabase("terrasurConn");
            private static Database db1_renacer = DatabaseFactory.CreateDatabase("renacerConn");

            #region Propiedades
            //Propiedades privadas
            private int _id_contrato = 0;
            private string _num_contrato = "";
            private int _id_moneda = 0;
            private string _codigo_moneda = "";
            private string _negocio = "";
            private string _producto = "";
            private string _cliente = "";
            private decimal _monto_sus = 0;
            private decimal _monto_bs = 0;
            private decimal _tipo_cambio = 0;

            //Propiedades públicas
            public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
            public string num_contrato { get { return _num_contrato; } set { _num_contrato = value; } }
            public int id_moneda { get { return _id_moneda; } set { _id_moneda = value; } }
            public string codigo_moneda { get { return _codigo_moneda; } set { _codigo_moneda = value; } }
            public string negocio { get { return _negocio; } set { _negocio = value; } }
            public string producto { get { return _producto; } set { _producto = value; } }
            public string cliente { get { return _cliente; } set { _cliente = value; } }
            public decimal monto_sus { get { return _monto_sus; } set { _monto_sus = value; } }
            public decimal monto_bs { get { return _monto_bs; } set { _monto_bs = value; } }
            public decimal tipo_cambio { get { return _tipo_cambio; } set { _tipo_cambio = value; } }
            #endregion

            #region Constructores
            public tmpContratoDestino(int Id_contrato, string Num_contrato, int Id_moneda, string Codigo_moneda, 
                string Negocio, string Producto, string Cliente, decimal Monto_sus, decimal Monto_bs, decimal Tipo_cambio)
            {
                _id_contrato = Id_contrato;
                _num_contrato = Num_contrato;
                _id_moneda = Id_moneda;
                _codigo_moneda = Codigo_moneda;
                _negocio = Negocio;
                _producto = Producto;
                _cliente = Cliente;
                _monto_sus = Monto_sus;
                _monto_bs = Monto_bs;
                _tipo_cambio = Tipo_cambio;
            }
            #endregion

            #region Métodos que NO requieren constructor
            public static string Lista_a_Cadena(List<tmpContratoDestino> lista)
            {
                StringBuilder str = new StringBuilder();
                foreach (tmpContratoDestino ctto in lista)
                {
                    str.Append(
                      ctto.id_contrato.ToString() + "·"
                    + ctto.num_contrato + "·"
                    + ctto.id_moneda.ToString() + "·"
                    + ctto.codigo_moneda + "·"
                    + ctto.negocio + "·"
                    + ctto.producto + "·"
                    + ctto.cliente + "·"
                    + ctto.monto_sus.ToString() + "·"
                    + ctto.monto_bs.ToString() + "·"
                    + ctto.tipo_cambio.ToString() + "|");
                }
                return str.ToString().TrimEnd('|');
            }

            public static List<tmpContratoDestino> Cadena_a_Lista(string strCtto)
            {
                List<tmpContratoDestino> lista = new List<tmpContratoDestino>();
                if (!string.IsNullOrEmpty(strCtto))
                {
                    string[] datos_row = strCtto.Split('|');
                    for (int j = 0; j < datos_row.Length; j++)
                    {
                        string[] datos_col = datos_row[j].Split('·');
                        lista.Add(new tmpContratoDestino(
                            int.Parse(datos_col[0]),
                            datos_col[1],
                            int.Parse(datos_col[2]),
                            datos_col[3],
                            datos_col[4],
                            datos_col[5],
                            datos_col[6],
                            decimal.Parse(datos_col[7]),
                            decimal.Parse(datos_col[8]),
                            decimal.Parse(datos_col[9])));
                    }
                }
                return lista;
            }

            public static DataTable Cadena_a_tabla(string strCtto, string Codigo_moneda)
            {
                //[id_contrato],[num_contrato],[id_moneda],[codigo_moneda],[negocio],[producto],[cliente],[monto_sus],[monto_bs],[tipo_cambio]
                List<tmpContratoDestino> lista = Cadena_a_Lista(strCtto);
                DataTable tabla = new DataTable();
                tabla.Columns.Add("id_contrato", typeof(int));
                tabla.Columns.Add("num_contrato", typeof(string));
                tabla.Columns.Add("id_moneda", typeof(int));

                tabla.Columns.Add("codigo_moneda", typeof(string));
                tabla.Columns.Add("negocio", typeof(string));
                tabla.Columns.Add("producto", typeof(string));
                tabla.Columns.Add("cliente", typeof(string));

                tabla.Columns.Add("monto_sus", typeof(decimal));
                tabla.Columns.Add("monto_bs", typeof(decimal));
                tabla.Columns.Add("tipo_cambio", typeof(decimal));

                if (lista.Count > 0)
                {
                    decimal Monto_total = 0;
                    foreach (tmpContratoDestino c in lista)
                    {
                        DataRow fila = tabla.NewRow();
                        fila["id_contrato"] = c.id_contrato;
                        fila["num_contrato"] = c.num_contrato;
                        fila["id_moneda"] = c.id_moneda;

                        fila["codigo_moneda"] = c.codigo_moneda;
                        fila["negocio"] = c.negocio;
                        fila["producto"] = c.producto;
                        fila["cliente"] = c.cliente;

                        if (c.monto_sus > 0) { fila["monto_sus"] = c.monto_sus; }
                        if (c.monto_bs > 0) { fila["monto_bs"] = c.monto_bs; }
                        if (c.tipo_cambio > 0) { fila["tipo_cambio"] = c.tipo_cambio; }
                        tabla.Rows.Add(fila);

                        if (Codigo_moneda == "$us") { Monto_total += c.monto_sus; }
                        else { Monto_total += c.monto_bs; }
                    }

                    DataRow fila_total = tabla.NewRow();
                    fila_total["num_contrato"] = "Total";
                    if (Codigo_moneda == "$us") { fila_total["monto_sus"] = Monto_total; }
                    else { fila_total["monto_bs"] = Monto_total; }
                    tabla.Rows.Add(fila_total);
                }
                return tabla;
            }


            public static string Agregar(string strCtto, string Codigo_moneda_traspaso, DateTime Fecha,
                int Id_contrato, string Num_contrato, int Origen, decimal Monto)
            {
                List<tmpContratoDestino> lista = Cadena_a_Lista(strCtto);
                tmpContratoDestino cttoObj;
                if (Origen == 1) { cttoObj = Terrasur_DatosContrato(Id_contrato, Num_contrato); }
                else { cttoObj = Renacer_DatosContrato(Id_contrato, Num_contrato); cttoObj.id_contrato = 0; }
                
                if (Codigo_moneda_traspaso == "$us")
                {
                    cttoObj.monto_sus = Monto;
                    if (cttoObj.codigo_moneda == "Bs")
                    {
                        sintesis.s_tipo_cambio tcObj = new sintesis.s_tipo_cambio(sintesis.s_tipo_cambio.IdVigente(Fecha));
                        cttoObj.tipo_cambio = tcObj.compra;
                        cttoObj.monto_bs = cttoObj.monto_sus * cttoObj.tipo_cambio;
                    }
                }
                else if (Codigo_moneda_traspaso == "Bs")
                {
                    cttoObj.monto_bs = Monto;
                    if (cttoObj.codigo_moneda == "$us")
                    {
                        sintesis.s_tipo_cambio tcObj = new sintesis.s_tipo_cambio(sintesis.s_tipo_cambio.IdVigente(Fecha));
                        cttoObj.tipo_cambio = tcObj.venta;
                        cttoObj.monto_sus = Math.Round((cttoObj.monto_bs / cttoObj.tipo_cambio), 2);
                    }
                }


                lista.Add(cttoObj);
                return Lista_a_Cadena(lista);
            }

            public static string Retirar(string strCtto, int Id_contrato, string Num_contrato)
            {
                List<tmpContratoDestino> lista = Cadena_a_Lista(strCtto);

                int index = -1;
                for (int j = 0; j < lista.Count; j++)
                {
                    if (lista[j].id_contrato == Id_contrato && lista[j].num_contrato == Num_contrato)
                    {
                        index = j;
                    }
                }
                if (index >= 0) { lista.RemoveAt(index); }

                return Lista_a_Cadena(lista);
            }

            public static bool Verificar(string strCtto, int Id_contrato, string Num_contrato)
            {
                List<tmpContratoDestino> lista = Cadena_a_Lista(strCtto);

                int index = -1;
                for (int j = 0; j < lista.Count; j++)
                {
                    if (lista[j].id_contrato == Id_contrato && lista[j].num_contrato == Num_contrato)
                    {
                        index = j;
                        break;
                    }
                }

                if (index >= 0) { return true; } 
                else { return false; }
            }

            public static decimal MontoTotal(string strCtto, string Codigo_moneda_traspaso)
            {
                decimal Monto = 0;
                List<tmpContratoDestino> lista = Cadena_a_Lista(strCtto);
                foreach (tmpContratoDestino c in lista)
                {
                    if (Codigo_moneda_traspaso == "$us") { Monto += c.monto_sus; }
                    else { Monto += c.monto_bs; }
                }
                return Monto;
            }


            public static tmpContratoDestino Terrasur_DatosContrato(int Id_contrato, string Num_contrato)
            {
                //[id_contrato],[num_contrato],[id_moneda],[codigo_moneda],[negocio],[producto],[cliente]
                DbCommand cmd = db1_terrasur.GetStoredProcCommand("re_contrato_destino_DatosContrato");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1_terrasur.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1_terrasur.AddInParameter(cmd, "num_contrato", DbType.String, Num_contrato);
                DataTable tabla = db1_terrasur.ExecuteDataSet(cmd).Tables[0];

                tmpContratoDestino cttoObj = new tmpContratoDestino(
                    (int)tabla.Rows[0]["id_contrato"]
                    , tabla.Rows[0]["num_contrato"].ToString()
                    , (int)tabla.Rows[0]["id_moneda"]
                    , tabla.Rows[0]["codigo_moneda"].ToString()
                    , tabla.Rows[0]["negocio"].ToString()
                    , tabla.Rows[0]["producto"].ToString()
                    , tabla.Rows[0]["cliente"].ToString()
                    , 0, 0, 0);
                return cttoObj;
            }

            public static tmpContratoDestino Renacer_DatosContrato(int Id_contrato, string Num_contrato)
            {
                //[id_contrato],[num_contrato],[id_moneda],[codigo_moneda],[negocio],[producto],[cliente]
                DbCommand cmd = db1_renacer.GetStoredProcCommand("re_contrato_destino_DatosContrato");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1_renacer.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                db1_renacer.AddInParameter(cmd, "num_contrato", DbType.String, Num_contrato);
                DataTable tabla = db1_renacer.ExecuteDataSet(cmd).Tables[0];

                tmpContratoDestino cttoObj = new tmpContratoDestino(
                    (int)tabla.Rows[0]["id_contrato"]
                    , tabla.Rows[0]["num_contrato"].ToString()
                    , (int)tabla.Rows[0]["id_moneda"]
                    , tabla.Rows[0]["codigo_moneda"].ToString()
                    , tabla.Rows[0]["negocio"].ToString()
                    , tabla.Rows[0]["producto"].ToString()
                    , tabla.Rows[0]["cliente"].ToString()
                    , 0, 0, 0);
                return cttoObj;
            }

            public static void Terrasur_BusquedaContrato(string Num_contrato, DateTime Fecha,
                ref int Id_contrato, ref int Codigo_estado, ref string Estado, ref string Codigo_moneda, ref decimal Saldo)
            {
                //[id_contrato],[codigo_estado],[estado],[codigo_moneda],[saldo]
                DbCommand cmd = db1_terrasur.GetStoredProcCommand("re_contrato_destino_BusquedaContrato");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1_terrasur.AddInParameter(cmd, "num_contrato", DbType.String, Num_contrato);
                db1_terrasur.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
                DataTable tabla = db1_terrasur.ExecuteDataSet(cmd).Tables[0];

                Id_contrato = (int)tabla.Rows[0]["id_contrato"];
                Codigo_estado = (int)tabla.Rows[0]["codigo_estado"];
                Estado = (string)tabla.Rows[0]["estado"];
                Codigo_moneda = (string)tabla.Rows[0]["codigo_moneda"];
                Saldo = (decimal)tabla.Rows[0]["saldo"];
            }

            public static void Renacer_BusquedaContrato(string Num_contrato, DateTime Fecha,
                ref int Id_contrato, ref int Codigo_estado, ref string Estado, ref string Codigo_moneda, ref decimal Saldo)
            {
                //[id_contrato],[codigo_estado],[estado],[codigo_moneda],[saldo]
                DbCommand cmd = db1_renacer.GetStoredProcCommand("re_contrato_destino_BusquedaContrato");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1_renacer.AddInParameter(cmd, "num_contrato", DbType.String, Num_contrato);
                db1_renacer.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
                DataTable tabla = db1_renacer.ExecuteDataSet(cmd).Tables[0];

                Id_contrato = (int)tabla.Rows[0]["id_contrato"];
                Codigo_estado = (int)tabla.Rows[0]["codigo_estado"];
                Estado = (string)tabla.Rows[0]["estado"];
                Codigo_moneda = (string)tabla.Rows[0]["codigo_moneda"];
                Saldo = (decimal)tabla.Rows[0]["saldo"];
            }
            #endregion
        }

    }
}