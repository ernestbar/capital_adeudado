using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.EnterpriseLibrary.Data;

/// <summary>
/// Summary description for reversion
/// </summary>
/// 
namespace terrasur
{
    public class reversion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_reversion = 0;
        private int _id_usuario = 0;
        private int _id_contrato = 0;
        private int _id_motivoreversion = 0;
        private DateTime _fecha = DateTime.Now;
        private int _dias_mora = 0;
        private int _cuotas_mora = 0;
        private decimal _capital_pagado = 0;
        private decimal _capital_adeuda = 0;
        private bool _anulado;
        private DateTime _anulado_fecha = DateTime.Now;
        private int _anulado_id_usuario = 0;

        private string _motivo_reversion = "";
        private string _usuario_reversion = "";

        //Propiedades públicas
        public int id_reversion { get { return _id_reversion; } set { _id_reversion = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public int id_contrato { get { return _id_contrato; } set { _id_contrato = value; } }
        public int id_motivoreversion { get { return _id_motivoreversion; } set { _id_motivoreversion = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public int dias_mora { get { return _dias_mora; } set { _dias_mora = value; } }
        public int cuotas_mora { get { return _cuotas_mora; } set { _cuotas_mora = value; } }
        public decimal capital_pagado { get { return _capital_pagado; } set { _capital_pagado = value; } }
        public decimal capital_adeuda { get { return _capital_adeuda; } set { _capital_adeuda = value; } }
        public bool anulado { get { return _anulado; } set { _anulado = value; } }
        public DateTime anulado_fecha { get { return _anulado_fecha; } set { _anulado_fecha = value; } }
        public int anulado_id_usuario { get { return _anulado_id_usuario; } set { _anulado_id_usuario = value; } }

        public string motivo_reversion { get { return _motivo_reversion; } set { _motivo_reversion = value; } }
        public string usuario_reversion { get { return _usuario_reversion; } set { _usuario_reversion = value; } }

        #endregion


        #region Constructores
        public reversion(int Id_reversion)
        {
            _id_reversion  = Id_reversion;
            RecuperarDatos();
        }
        public reversion(int Id_contrato, int Id_motivoreversion, int Dias_mora,
            int Cuotas_mora, decimal Capital_pagado, decimal Capital_adeuda)
        {
            _id_contrato = Id_contrato;
            _id_motivoreversion = Id_motivoreversion;
            _dias_mora = Dias_mora;
            _cuotas_mora = Cuotas_mora;
            _capital_pagado = Capital_pagado;
            _capital_adeuda = Capital_adeuda;
        }

        #endregion

        
        #region Métodos que NO requieren constructor
        public static DataTable ListaContratosMora(int Id_negocio, int Desde, int Hasta)
        {
            DbCommand cmd = db1.GetStoredProcCommand("reversion_ListaContratosMora");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_negocio", DbType.Int32, Id_negocio);
            db1.AddInParameter(cmd, "desde", DbType.Int32, Desde);
            db1.AddInParameter(cmd, "hasta", DbType.Int32, Hasta);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        public static int ReversionNoAnulada(int Id_contrato)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("reversion_ReversionNoAnulada");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);
                return (int)db1.ExecuteScalar(cmd);
            }
            catch { return 0; }
        }
        public static DataTable ContratosMoraTmp()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_contrato", typeof(Int32)));
            dt.Columns.Add(new DataColumn("negocio_nombre", typeof(string)));
            dt.Columns.Add(new DataColumn("num_contrato", typeof(string)));
            dt.Columns.Add(new DataColumn("cliente_nombre", typeof(string)));
            dt.Columns.Add(new DataColumn("lote_codigo", typeof(string)));
            dt.Columns.Add(new DataColumn("capital_total", typeof(Decimal)));
            dt.Columns.Add(new DataColumn("capital_pagado", typeof(Decimal)));
            dt.Columns.Add(new DataColumn("capital_adeudado", typeof(Decimal)));
            dt.Columns.Add(new DataColumn("fecha_prox_pago", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("dias_mora", typeof(Int32)));
            dt.Columns.Add(new DataColumn("cuotas_mora", typeof(Int32)));
            dt.Columns.Add(new DataColumn("promotor", typeof(string)));
            return dt;
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("reversion_RecuperarDatos");
                db1.AddInParameter(cmd, "id_reversion", DbType.Int32, _id_reversion);

                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_contrato", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "id_motivoreversion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 200);
                db1.AddOutParameter(cmd, "dias_mora", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "cuotas_mora", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "capital_pagado", DbType.Double, 14);
                db1.AddOutParameter(cmd, "capital_adeuda", DbType.Double, 14);
                db1.AddOutParameter(cmd, "anulado", DbType.Boolean, 200);
                db1.AddOutParameter(cmd, "anulado_fecha", DbType.DateTime, 32);
                db1.AddOutParameter(cmd, "anulado_id_usuario", DbType.Int32, 32);

                db1.AddOutParameter(cmd, "motivo_reversion", DbType.String, 100);
                db1.AddOutParameter(cmd, "usuario_reversion", DbType.String, 50);

                db1.ExecuteNonQuery(cmd);

                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _id_contrato = (int)db1.GetParameterValue(cmd, "id_contrato");
                _id_motivoreversion = (int)db1.GetParameterValue(cmd, "id_motivoreversion");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _dias_mora = (int)db1.GetParameterValue(cmd, "dias_mora");
                _cuotas_mora = (int)db1.GetParameterValue(cmd, "cuotas_mora");
                _capital_pagado = (decimal)(double)db1.GetParameterValue(cmd, "capital_pagado");
                _capital_adeuda = (decimal)(double)db1.GetParameterValue(cmd, "capital_adeuda");
                _anulado = (bool)db1.GetParameterValue(cmd, "anulado");
                _anulado_fecha = (DateTime)db1.GetParameterValue(cmd, "anulado_fecha");
                _anulado_id_usuario = (int)db1.GetParameterValue(cmd, "anulado_id_usuario");

                _motivo_reversion = (string)db1.GetParameterValue(cmd, "motivo_reversion");
                _usuario_reversion = (string)db1.GetParameterValue(cmd, "usuario_reversion");
            }
            catch { }
        }

        public bool Insertar(int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("reversion_Insertar");
                db1.AddInParameter(cmd, "id_usuario_r", DbType.Int32, context_id_usuario);
                db1.AddInParameter(cmd, "id_contrato_r", DbType.Int32, _id_contrato);
                db1.AddInParameter(cmd, "id_motivoreversion_r", DbType.Int32, _id_motivoreversion);
                db1.AddInParameter(cmd, "dias_mora_r", DbType.Int32, _dias_mora);
                db1.AddInParameter(cmd, "cuotas_mora_r", DbType.Int32, _cuotas_mora);
                db1.AddInParameter(cmd, "capital_pagado_r", DbType.Double, _capital_pagado);
                db1.AddInParameter(cmd, "capital_adeuda_r", DbType.Double, _capital_adeuda);
                _id_reversion  = (int)db1.ExecuteScalar(cmd);
                if (_id_reversion > 0)
                {
                    contrato ob_con = new contrato(_id_contrato);
                    contrato_venta ob_cv = new contrato_venta(_id_contrato);
                    lote lot = new lote(ob_cv.id_lote);
                    negocio_contrato neg = new negocio_contrato(ob_con.id_negociocontrato);
                    tipo_cambio tc = new tipo_cambio(DateTime.Now);
                    string nombre_urbanizacion = "";
                    nombre_urbanizacion = lot.nombre_urbanizacion.Trim().Replace("\"", "").Replace("(", " ").Replace(")", " ").Replace(".", " ").Replace("/", "").Replace("-", " ") + " " + lot.codigo_manzano.Trim() + " " + lot.codigo.Trim();
                    decimal capital_adeuda_bs = 0;
                    if (neg.id_negocio == 3)
                    {
                        if (ob_con.id_moneda == 1)
                        {
                            capital_adeuda_bs =Math.Round(_capital_adeuda * tc.compra,2);
                        }
                        else 
                        {
                            capital_adeuda_bs = _capital_adeuda;
                        }
                        string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                        //ServiceReference1.SintesisService obj2 = new ServiceReference1.SintesisService();
                        //string resultado2 = obj2.insertarMovimientosOdoo(3, true, ob_con.numero.ToString(), "", _id_reversion.ToString(), 0, true, "REVERSIONES", 0, true, 0, true, 0, true, 0,
                        //    true, 0, true, float.Parse(capital_adeuda_bs.ToString("F2")), true, 0, true, 0, true, lot.id_urbanizacion.ToString(), "", "", true, true, nombre_urbanizacion, "",
                        //    false, true, context_id_usuario, true, ip, DateTime.Now.ToShortDateString(), 0, true, 0, true, 0, true);
                        ////////////////INVENTARIOS////////////////
                        decimal costo_lote = lot.superficie_m2 * lot.costo_m2_sus;
                        decimal porcentaje =ob_cv.capital_pagado / ob_con.precio_final;
                        decimal costo_pagado = costo_lote * porcentaje;
                        decimal saldo_costo = costo_lote - costo_pagado;

                        decimal costo_lote_bs = 0;
                        decimal costo_pagado_bs = 0;
                        decimal saldo_costo_bs = 0;

                        if (ob_con.id_moneda == 1)
                        {
                            costo_lote_bs = Math.Round(costo_lote * tc.compra, 2);
                            costo_pagado_bs = Math.Round(costo_pagado * tc.compra, 2);
                            saldo_costo_bs = Math.Round(saldo_costo * tc.compra, 2);
                        }
                        else
                        {
                            costo_lote_bs = costo_lote;
                            costo_pagado_bs = costo_pagado;
                            saldo_costo_bs = saldo_costo;
                        }



                        //ServiceReference1.SintesisService obj = new ServiceReference1.SintesisService();
                        //string resultado = obj.insertarMovimientosOdoo(3, true, ob_con.numero.ToString(), "", _id_reversion.ToString(), 0, true, "INVENTARIO REVERSIONES", 0, true, 0, true, 0, true, 0,
                        //    true, 0, true, 0, true, 0, true, 0, true, lot.id_urbanizacion.ToString(), "", "", true, true, nombre_urbanizacion, "",
                        //    false, true, context_id_usuario, true, ip, DateTime.Now.ToShortDateString(), float.Parse(costo_lote_bs.ToString("F2")), true, float.Parse(costo_pagado_bs.ToString("F2")), true, float.Parse(saldo_costo_bs.ToString("F2")), true);
                    }
                }
                
                return true;
            }
            catch { return false; }
        }

        public bool Deshacer(int Id_reversion, int context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("reversion_Deshacer");
                db1.AddInParameter(cmd, "id_reversion_d", DbType.Int32, Id_reversion);
                db1.AddInParameter(cmd, "anulado_id_usuario_d", DbType.Int32, context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                reversion rev = new reversion(Id_reversion);
                contrato ob_con = new contrato(rev.id_contrato);
                contrato_venta ob_cv = new contrato_venta(rev.id_contrato);
                lote lot = new lote(ob_cv.id_lote);
                negocio_contrato neg = new negocio_contrato(ob_con.id_negociocontrato);
                tipo_cambio tc = new tipo_cambio(DateTime.Now);
                decimal capital_adeuda_bs = 0;
                if (neg.id_negocio == 3)
                {
                    string nombre_urbanizacion = "";
                    nombre_urbanizacion = lot.nombre_urbanizacion.Trim().Replace("\"", "").Replace("(", " ").Replace(")", " ").Replace(".", " ").Replace("/", "").Replace("-", " ") + " " + lot.codigo_manzano.Trim() + " " + lot.codigo.Trim();
                    if (ob_con.id_moneda == 1)
                    {
                        capital_adeuda_bs = Math.Round(_capital_adeuda * tc.compra,2);
                    }
                    else
                    {
                        capital_adeuda_bs = _capital_adeuda;
                    }
                    string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                    //ServiceReference1.SintesisService obj2 = new ServiceReference1.SintesisService();
                    //string resultado2 = obj2.insertarMovimientosOdoo(3, true, ob_con.numero.ToString(), "", Id_reversion.ToString(), 0, true, "REVERSIONES",
                    //    0, true, 0, true, 0, true, 0, true, 0, true, float.Parse(capital_adeuda_bs.ToString("F2")), true, 0, true, 0, true, lot.id_urbanizacion.ToString(),
                    //    "", "", true, true, nombre_urbanizacion, "", true, true, context_id_usuario,
                    //    true, ip, DateTime.Now.ToShortDateString(), 0, true, 0, true, 0, true);

                    ////////////////INVENTARIOS////////////////
                    decimal costo_lote = lot.superficie_m2 * lot.costo_m2_sus;
                    decimal porcentaje = ob_cv.capital_pagado / ob_con.precio_final;
                    decimal costo_pagado = costo_lote * porcentaje;
                    decimal saldo_costo = costo_lote - costo_pagado;

                    decimal costo_lote_bs = 0;
                    decimal costo_pagado_bs = 0;
                    decimal saldo_costo_bs = 0;

                    if (ob_con.id_moneda == 1)
                    {
                        costo_lote_bs = Math.Round(costo_lote * tc.compra, 2);
                        costo_pagado_bs = Math.Round(costo_pagado * tc.compra, 2);
                        saldo_costo_bs = Math.Round(saldo_costo * tc.compra, 2);
                    }
                    else
                    {
                        costo_lote_bs = costo_lote;
                        costo_pagado_bs = costo_pagado;
                        saldo_costo_bs = saldo_costo;
                    }

                    //ServiceReference1.SintesisService obj = new ServiceReference1.SintesisService();
                    //string resultado = obj.insertarMovimientosOdoo(3, true, ob_con.numero.ToString(), "", Id_reversion.ToString(), 0, true, "INVENTARIO REVERSIONES",
                    //    0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, lot.id_urbanizacion.ToString(),
                    //    "", "", true, true, nombre_urbanizacion, "", true, true, context_id_usuario,
                    //    true, ip, DateTime.Now.ToShortDateString(), float.Parse(costo_lote_bs.ToString("F2")), true, float.Parse(costo_pagado_bs.ToString("F2")), true, float.Parse(saldo_costo_bs.ToString("F2")), true);
                }

                return true;
            }
            catch { return false; }
        }
        #endregion


 

    }
}