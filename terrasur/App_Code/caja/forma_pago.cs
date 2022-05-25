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
/// Summary description for forma_pago
/// </summary>
namespace terrasur
{
    public class forma_pago
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
            
        #region Propiedades
        //Propiedades privadas
        private int _id_transaccion = 0;
        private bool _dpr = false;
        private decimal _dpr_sus = 0;
        private int _dpr_id_dpr = 0;
        private decimal _efectivo_sus = 0;
        private decimal _efectivo_bs = 0;
        private decimal _deposito_sus = 0;
        private decimal _deposito_bs = 0;
        private string _tarjeta_numero = "";
        private decimal _tarjeta_sus = 0;
        private decimal _tarjeta_bs = 0;
        private int _cheque_id_banco = 0;
        private string _cheque_numero = "";
        private decimal _cheque_sus = 0;
        private decimal _cheque_bs = 0;

        //Propiedades públicas
        public int id_transaccion { get { return _id_transaccion; } set { _id_transaccion = value; } }
        public bool dpr { get { return _dpr; } set { _dpr = value; } }
        public decimal dpr_sus { get { return _dpr_sus; } set { _dpr_sus = value; } }
        public int dpr_id_dpr { get { return _dpr_id_dpr; } set { _dpr_id_dpr = value; } }
        public decimal efectivo_sus { get { return _efectivo_sus; } set { _efectivo_sus = value; } }
        public decimal efectivo_bs { get { return _efectivo_bs; } set { _efectivo_bs = value; } }
        public decimal deposito_sus { get { return _deposito_sus; } set { _deposito_sus = value; } }
        public decimal deposito_bs { get { return _deposito_bs; } set { _deposito_bs = value; } }
        public string tarjeta_numero { get { return _tarjeta_numero; } set { _tarjeta_numero = value; } }
        public decimal tarjeta_sus { get { return _tarjeta_sus; } set { _tarjeta_sus = value; } }
        public decimal tarjeta_bs { get { return _tarjeta_bs; } set { _tarjeta_bs = value; } }
        public int cheque_id_banco { get { return _cheque_id_banco; } set { _cheque_id_banco = value; } }
        public string cheque_numero { get { return _cheque_numero; } set { _cheque_numero = value; } }
        public decimal cheque_sus { get { return _cheque_sus; } set { _cheque_sus = value; } }
        public decimal cheque_bs { get { return _cheque_bs; } set { _cheque_bs = value; } }
        #endregion

        #region Constructores
        public forma_pago(){}
        public forma_pago(int Id_transaccion)
        {
            _id_transaccion = Id_transaccion;
            RecuperarDatos();
        }
        public forma_pago(int Id_transaccion, tmpFormaPago tfp)
        {
            _id_transaccion = Id_transaccion;
            _dpr = tfp.dpr;
            _dpr_sus = tfp.dpr_sus;
            _dpr_id_dpr = tfp.dpr_id_dpr;
            _efectivo_sus = tfp.efectivo_sus;
            _efectivo_bs = tfp.efectivo_bs;
            _deposito_sus = tfp.deposito_sus;
            _deposito_bs = tfp.deposito_bs;
            _tarjeta_numero = tfp.tarjeta_numero;
            _tarjeta_sus = tfp.tarjeta_sus;
            _tarjeta_bs = tfp.tarjeta_bs;
            _cheque_id_banco = tfp.cheque_id_banco;
            _cheque_numero = tfp.cheque_numero;
            _cheque_sus = tfp.cheque_sus;
            _cheque_bs = tfp.cheque_bs;
        }
        #endregion

        #region Métodos que NO requieren constructor
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("forma_pago_RecuperarDatos");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, _id_transaccion);
                db1.AddOutParameter(cmd, "dpr", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "dpr_sus", DbType.Double, 32);
                db1.AddOutParameter(cmd, "dpr_id_dpr", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "efectivo_sus", DbType.Double, 14);
                db1.AddOutParameter(cmd, "efectivo_bs", DbType.Double, 14);
                db1.AddOutParameter(cmd, "deposito_sus", DbType.Double, 14);
                db1.AddOutParameter(cmd, "deposito_bs", DbType.Double, 14);
                db1.AddOutParameter(cmd, "tarjeta_numero", DbType.String, 50);
                db1.AddOutParameter(cmd, "tarjeta_sus", DbType.Double, 14);
                db1.AddOutParameter(cmd, "tarjeta_bs", DbType.Double, 14);
                db1.AddOutParameter(cmd, "cheque_id_banco", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "cheque_numero", DbType.String, 50);
                db1.AddOutParameter(cmd, "cheque_sus", DbType.Double, 14);
                db1.AddOutParameter(cmd, "cheque_bs", DbType.Double, 14);
                db1.ExecuteNonQuery(cmd);

                _dpr = (bool)db1.GetParameterValue(cmd, "dpr");
                _dpr_sus = (decimal)(double)db1.GetParameterValue(cmd, "dpr_sus");
                _dpr_id_dpr = (int)db1.GetParameterValue(cmd, "dpr_id_dpr");
                _efectivo_sus = (decimal)(double)db1.GetParameterValue(cmd, "efectivo_sus");
                _efectivo_bs = (decimal)(double)db1.GetParameterValue(cmd, "efectivo_bs");
                _deposito_sus = (decimal)(double)db1.GetParameterValue(cmd, "deposito_sus");
                _deposito_bs = (decimal)(double)db1.GetParameterValue(cmd, "deposito_bs");
                _tarjeta_numero = (string)db1.GetParameterValue(cmd, "tarjeta_numero");
                _tarjeta_sus = (decimal)(double)db1.GetParameterValue(cmd, "tarjeta_sus");
                _tarjeta_bs = (decimal)(double)db1.GetParameterValue(cmd, "tarjeta_bs");
                _cheque_id_banco = (int)db1.GetParameterValue(cmd, "cheque_id_banco");
                _cheque_numero = (string)db1.GetParameterValue(cmd, "cheque_numero");
                _cheque_sus = (decimal)(double)db1.GetParameterValue(cmd, "cheque_sus");
                _cheque_bs = (decimal)(double)db1.GetParameterValue(cmd, "cheque_bs");
            }
            catch { }
        }

        public bool Insertar()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("forma_pago_Insertar");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, _id_transaccion);
                db1.AddInParameter(cmd, "dpr", DbType.Boolean, _dpr);
                db1.AddInParameter(cmd, "dpr_sus", DbType.Decimal, _dpr_sus);
                db1.AddInParameter(cmd, "dpr_id_dpr", DbType.Int32, _dpr_id_dpr);
                db1.AddInParameter(cmd, "efectivo_sus", DbType.Decimal, _efectivo_sus);
                db1.AddInParameter(cmd, "efectivo_bs", DbType.Decimal, _efectivo_bs);
                db1.AddInParameter(cmd, "deposito_sus", DbType.Decimal, _deposito_sus);
                db1.AddInParameter(cmd, "deposito_bs", DbType.Decimal, _deposito_bs);
                db1.AddInParameter(cmd, "tarjeta_numero", DbType.String, _tarjeta_numero);
                db1.AddInParameter(cmd, "tarjeta_sus", DbType.Decimal, _tarjeta_sus);
                db1.AddInParameter(cmd, "tarjeta_bs", DbType.Decimal, _tarjeta_bs);
                db1.AddInParameter(cmd, "cheque_id_banco", DbType.Int32, _cheque_id_banco);
                db1.AddInParameter(cmd, "cheque_numero", DbType.String, _cheque_numero);
                db1.AddInParameter(cmd, "cheque_sus", DbType.Decimal, _cheque_sus);
                db1.AddInParameter(cmd, "cheque_bs", DbType.Decimal, _cheque_bs);
                db1.ExecuteNonQuery(cmd);
                //return true;
                return VerificarDocumentos(_id_transaccion);
            }
            catch { return false; }
        }
        protected bool VerificarDocumentos(int Id_transaccion)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("forma_pago_transaccion_VerificarDocumentos");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, Id_transaccion);
                if ((int)db1.ExecuteScalar(cmd) > 0) { return true; }
                else { return false; }
            }
            catch { return false; }
        }
 
        #endregion

    }

    public class tmpFormaPago
    {
        #region Propiedades
        //Propiedades privadas
        private decimal _monto = 0;
        /*private decimal _tc_compra = 0;*/

        private bool _dpr = false;
        private decimal _dpr_sus = 0;
        private int _dpr_id_dpr = 0;

        private decimal _efectivo_sus = 0;
        private decimal _efectivo_bs = 0;

        private int _cheque_id_banco = 0;
        private string _cheque_numero = "";
        private decimal _cheque_sus = 0;
        private decimal _cheque_bs = 0;

        private string _tarjeta_numero = "";
        private decimal _tarjeta_sus = 0;
        private decimal _tarjeta_bs = 0;

        private decimal _deposito_sus = 0;
        private decimal _deposito_bs = 0;

        //Propiedades públicas
        public decimal monto { get { return _monto; } set { _monto = value; } }
        /*public decimal tc_compra { get { return _tc_compra; } set { _tc_compra = value; } }*/

        public bool dpr { get { return _dpr; } set { _dpr = value; } }
        public decimal dpr_sus { get { return _dpr_sus; } set { _dpr_sus = value; } }
        public int dpr_id_dpr { get { return _dpr_id_dpr; } set { _dpr_id_dpr = value; } }

        public decimal efectivo_sus { get { return _efectivo_sus; } set { _efectivo_sus = value; } }
        public decimal efectivo_bs { get { return _efectivo_bs; } set { _efectivo_bs = value; } }

        public int cheque_id_banco { get { return _cheque_id_banco; } set { _cheque_id_banco = value; } }
        public string cheque_numero { get { return _cheque_numero; } set { _cheque_numero = value.Trim(); } }
        public decimal cheque_sus { get { return _cheque_sus; } set { _cheque_sus = value; } }
        public decimal cheque_bs { get { return _cheque_bs; } set { _cheque_bs = value; } }

        public string tarjeta_numero { get { return _tarjeta_numero; } set { _tarjeta_numero = value.Trim(); } }
        public decimal tarjeta_sus { get { return _tarjeta_sus; } set { _tarjeta_sus = value; } }
        public decimal tarjeta_bs { get { return _tarjeta_bs; } set { _tarjeta_bs = value; } }

        public decimal deposito_sus { get { return _deposito_sus; } set { _deposito_sus = value; } }
        public decimal deposito_bs { get { return _deposito_bs; } set { _deposito_bs = value; } }
        #endregion

        #region Constructores
        public tmpFormaPago(decimal Monto) { _monto = Monto;  }
        #endregion

        #region Métodos que NO requieren constructor
        public static tmpFormaPago TmpFormaPagoReplica(tmpFormaPago tfp_principal)
        {
            tmpFormaPago tfp = new tmpFormaPago(tfp_principal.monto);

            tfp.dpr = tfp_principal.dpr;
            tfp.dpr_sus = tfp_principal.dpr_sus;
            tfp.dpr_id_dpr = tfp_principal.dpr_id_dpr;

            tfp.efectivo_sus = tfp_principal.efectivo_sus;
            tfp.efectivo_bs = tfp_principal.efectivo_bs;

            tfp.cheque_id_banco = tfp_principal.cheque_id_banco;
            tfp.cheque_numero = tfp_principal.cheque_numero;
            tfp.cheque_sus = tfp_principal.cheque_sus;
            tfp.cheque_bs = tfp_principal.cheque_bs;

            tfp.tarjeta_numero = tfp_principal.tarjeta_numero;
            tfp.tarjeta_sus = tfp_principal.tarjeta_sus;
            tfp.tarjeta_bs = tfp_principal.tarjeta_bs;

            tfp.deposito_sus = tfp_principal.deposito_sus;
            tfp.deposito_bs = tfp_principal.deposito_bs;
            return tfp;
        }
        
        public static forma_pago FormaPagoTransaccion(int Id_transaccion, ref tmpFormaPago tfp_principal, decimal MontoParcial)
        {
            forma_pago fp = new forma_pago();
            fp.id_transaccion = Id_transaccion;
            if (MontoParcial > 0)
            {
                if (tfp_principal.dpr_sus > 0)
                {
                    fp.dpr = true;
                    fp.dpr_id_dpr = tfp_principal.dpr_id_dpr;

                    //decimal monto_en_dpr = MontoParcial;
                    decimal monto_cobrar_dpr = 0;
                    if (tfp_principal.dpr_sus >= MontoParcial) { monto_cobrar_dpr = MontoParcial; }
                    else { monto_cobrar_dpr = tfp_principal.dpr_sus; }

                    tfp_principal.dpr_sus = tfp_principal.dpr_sus - monto_cobrar_dpr;
                    fp.dpr_sus = monto_cobrar_dpr;

                }
                else if ((tfp_principal.efectivo_sus + tfp_principal.cheque_sus + tfp_principal.tarjeta_sus + tfp_principal.deposito_sus) > 0)
                {
                    fp.dpr = false;
                    decimal monto_cobrar_sus = MontoParcial;

                    //Se cobra En Efectivo
                    if (tfp_principal.efectivo_sus > 0 && monto_cobrar_sus > 0)
                    {
                        decimal monto_en_efectivo_sus = 0;
                        if (tfp_principal.efectivo_sus >= monto_cobrar_sus) { monto_en_efectivo_sus = monto_cobrar_sus; }
                        else { monto_en_efectivo_sus = tfp_principal.efectivo_sus; }

                        tfp_principal.efectivo_sus = tfp_principal.efectivo_sus - monto_en_efectivo_sus;
                        fp.efectivo_sus = monto_en_efectivo_sus;
                        monto_cobrar_sus = monto_cobrar_sus - monto_en_efectivo_sus;
                    }

                    //Se cobra con una tarjeta
                    if (tfp_principal.tarjeta_sus > 0 && monto_cobrar_sus > 0)
                    {
                        decimal monto_en_tarjeta_sus = 0;
                        if (tfp_principal.tarjeta_sus >= monto_cobrar_sus) { monto_en_tarjeta_sus = monto_cobrar_sus; }
                        else { monto_en_tarjeta_sus = tfp_principal.tarjeta_sus; }

                        tfp_principal.tarjeta_sus = tfp_principal.tarjeta_sus - monto_en_tarjeta_sus;
                        fp.tarjeta_sus = monto_en_tarjeta_sus;
                        monto_cobrar_sus = monto_cobrar_sus - monto_en_tarjeta_sus;

                        fp.tarjeta_numero = tfp_principal.tarjeta_numero;
                    }

                    //Se cobra con un depósito
                    if (tfp_principal.deposito_sus > 0 && monto_cobrar_sus > 0)
                    {
                        decimal monto_en_deposito_sus = 0;
                        if (tfp_principal.deposito_sus >= monto_cobrar_sus) { monto_en_deposito_sus = monto_cobrar_sus; }
                        else { monto_en_deposito_sus = tfp_principal.deposito_sus; }

                        tfp_principal.deposito_sus = tfp_principal.deposito_sus - monto_en_deposito_sus;
                        fp.deposito_sus = monto_en_deposito_sus;
                        monto_cobrar_sus = monto_cobrar_sus - monto_en_deposito_sus;
                    }

                    //Se cobra con un cheque
                    if (tfp_principal.cheque_sus > 0 && monto_cobrar_sus > 0)
                    {
                        decimal monto_en_cheque_sus = 0;
                        if (tfp_principal.cheque_sus >= monto_cobrar_sus) { monto_en_cheque_sus = monto_cobrar_sus; }
                        else { monto_en_cheque_sus = tfp_principal.cheque_sus; }

                        tfp_principal.cheque_sus = tfp_principal.cheque_sus - monto_en_cheque_sus;
                        fp.cheque_sus = monto_en_cheque_sus;
                        monto_cobrar_sus = monto_cobrar_sus - monto_en_cheque_sus;

                        fp.cheque_id_banco = tfp_principal.cheque_id_banco;
                        fp.cheque_numero = tfp_principal.cheque_numero;
                    }

                }
                else if ((tfp_principal.efectivo_bs + tfp_principal.cheque_bs + tfp_principal.tarjeta_bs + tfp_principal.deposito_bs) > 0)
                {
                    fp.dpr = false;
                    decimal monto_cobrar_bs = MontoParcial;

                    //Se cobra En Efectivo
                    if (tfp_principal.efectivo_bs > 0 && monto_cobrar_bs > 0)
                    {
                        decimal monto_en_efectivo_bs = 0;
                        if (tfp_principal.efectivo_bs >= monto_cobrar_bs) { monto_en_efectivo_bs = monto_cobrar_bs; }
                        else { monto_en_efectivo_bs = tfp_principal.efectivo_bs; }

                        tfp_principal.efectivo_bs = tfp_principal.efectivo_bs - monto_en_efectivo_bs;
                        fp.efectivo_bs = monto_en_efectivo_bs;
                        monto_cobrar_bs = monto_cobrar_bs - monto_en_efectivo_bs;
                    }

                    //Se cobra con una tarjeta
                    if (tfp_principal.tarjeta_bs > 0 && monto_cobrar_bs > 0)
                    {
                        decimal monto_en_tarjeta_bs = 0;
                        if (tfp_principal.tarjeta_bs >= monto_cobrar_bs) { monto_en_tarjeta_bs = monto_cobrar_bs; }
                        else { monto_en_tarjeta_bs = tfp_principal.tarjeta_bs; }

                        tfp_principal.tarjeta_bs = tfp_principal.tarjeta_bs - monto_en_tarjeta_bs;
                        fp.tarjeta_bs = monto_en_tarjeta_bs;
                        monto_cobrar_bs = monto_cobrar_bs - monto_en_tarjeta_bs;

                        fp.tarjeta_numero = tfp_principal.tarjeta_numero;
                    }

                    //Se cobra con un depósito
                    if (tfp_principal.deposito_bs > 0 && monto_cobrar_bs > 0)
                    {
                        decimal monto_en_deposito_bs = 0;
                        if (tfp_principal.deposito_bs >= monto_cobrar_bs) { monto_en_deposito_bs = monto_cobrar_bs; }
                        else { monto_en_deposito_bs = tfp_principal.deposito_bs; }

                        tfp_principal.deposito_bs = tfp_principal.deposito_bs - monto_en_deposito_bs;
                        fp.deposito_bs = monto_en_deposito_bs;
                        monto_cobrar_bs = monto_cobrar_bs - monto_en_deposito_bs;
                    }

                    //Se cobra con un cheque
                    if (tfp_principal.cheque_bs > 0 && monto_cobrar_bs > 0)
                    {
                        decimal monto_en_cheque_bs = 0;
                        if (tfp_principal.cheque_bs >= monto_cobrar_bs) { monto_en_cheque_bs = monto_cobrar_bs; }
                        else { monto_en_cheque_bs = tfp_principal.cheque_bs; }

                        tfp_principal.cheque_bs = tfp_principal.cheque_bs - monto_en_cheque_bs;
                        fp.cheque_bs = monto_en_cheque_bs;
                        monto_cobrar_bs = monto_cobrar_bs - monto_en_cheque_bs;

                        fp.cheque_id_banco = tfp_principal.cheque_id_banco;
                        fp.cheque_numero = tfp_principal.cheque_numero;
                    }
                }
            }
            return fp;
        }
        #endregion

        #region Métodos que requieren constructor
        /*public string Forma
        {
            get
            {
                if (_dpr == true) return "dpr";
                else if (_efectivo_sus > 0 || _efectivo_bs > 0) return "efectivo";
                else if (_cheque_sus > 0 || _cheque_bs > 0) return "cheque";
                else if (_tarjeta_sus > 0 || _tarjeta_bs > 0) return "tarjeta";
                else if (_deposito_sus > 0 || _deposito_bs > 0) return "deposito";
                else return "";
            }
        }*/

        /*public bool Verificar()
        {
            switch (Forma)
            {
                case "dpr":
                    if (dpr_id_dpr > 0) return _dpr_sus.Equals(_monto);
                    else return false;
                case "efectivo":
                    if ((_efectivo_sus + _efectivo_bs) == _monto) return true;
                    else return false;
                case "cheque":
                    if (_cheque_id_banco == 0 || _cheque_numero == "") return false;
                    else
                    {
                        if ((_cheque_sus + _cheque_bs) == _monto) return true;
                        else return false;
                    }
                case "tarjeta":
                    if (_tarjeta_numero == "") return false;
                    else
                    {
                        if ((_tarjeta_sus + _tarjeta_bs) == _monto) return true;
                        else return false;
                    }
                case "deposito":
                    if ((_deposito_sus + _deposito_bs) == _monto) return true;
                    else return false;
                default: return false;
            }
        }*/


        /*
        public forma_pago FormaPagoTransaccion(int Id_transaccion, decimal MontoParcial)
        {
            MontoParcial = Math.Round(MontoParcial, 2);
            forma_pago fp = new forma_pago();

            decimal Proporcion = 0;
            if (MontoParcial == _monto) Proporcion = 1;
            else if (MontoParcial < _monto && _monto > 0 && MontoParcial > 0) { Proporcion = MontoParcial / _monto; }
            
            if (Proporcion > 0)
            {
                fp.id_transaccion = Id_transaccion;
                if (this._dpr == true)
                {
                    fp.dpr = true;
                    fp.dpr_sus = this._monto * Proporcion;
                }
                else
                {
                    fp.dpr = false;

                    //Para el efectivo:
                    if (this._efectivo_sus > 0) { fp.efectivo_sus = Math.Round((this._efectivo_sus * Proporcion), 2); }
                    if (this._efectivo_bs > 0) { fp.efectivo_bs = Math.Round((this._efectivo_bs * Proporcion), 2); }

                    //Para el cheque:
                    fp.cheque_id_banco = this._cheque_id_banco;
                    fp.cheque_numero = this._cheque_numero;
                    if (this._cheque_sus > 0) { fp.cheque_sus = Math.Round((this._cheque_sus * Proporcion), 2); }
                    if (this._cheque_bs > 0) { fp.cheque_bs = Math.Round((this._cheque_bs * Proporcion), 2); }

                    //Para la tarjeta:
                    fp.tarjeta_numero = this._tarjeta_numero;
                    if (this._tarjeta_sus > 0) { fp.tarjeta_sus = Math.Round((this._tarjeta_sus * Proporcion), 2); }
                    if (this._tarjeta_bs > 0) { fp.tarjeta_bs = Math.Round((this._tarjeta_bs * Proporcion), 2); }

                    //Para el depósito
                    if (this._deposito_sus > 0) { fp.deposito_sus = Math.Round((this._deposito_sus * Proporcion), 2); }
                    if (this._deposito_bs > 0) { fp.deposito_bs = Math.Round((this._deposito_bs * Proporcion), 2); }

                    //Se realiza el tratamiento para corregir redondeos
                    if ((fp.efectivo_sus + fp.cheque_sus + fp.tarjeta_sus + fp.deposito_sus) > 0)
                    {
                        decimal diferencia_sus = MontoParcial - (fp.efectivo_sus + fp.cheque_sus + fp.tarjeta_sus + fp.deposito_sus);
                        if (diferencia_sus != 0)
                        {
                            if (fp.cheque_sus > 0 && fp.cheque_sus >= Math.Abs(diferencia_sus)) { fp.cheque_sus = fp.cheque_sus + diferencia_sus; }
                            else if (fp.deposito_sus > 0 && fp.deposito_sus >= Math.Abs(diferencia_sus)) { fp.deposito_sus = fp.deposito_sus + diferencia_sus; }
                            else if (fp.tarjeta_sus > 0 && fp.tarjeta_sus >= Math.Abs(diferencia_sus)) { fp.tarjeta_sus = fp.tarjeta_sus + diferencia_sus; }
                            else if (fp.efectivo_sus > 0 && fp.efectivo_sus >= Math.Abs(diferencia_sus)) { fp.efectivo_sus = fp.efectivo_sus + fp.efectivo_sus; }
                        }
                    }
                    else if ((fp.efectivo_bs + fp.cheque_bs + fp.tarjeta_bs + fp.deposito_bs) > 0)
                    {
                        decimal diferencia_bs = MontoParcial - (fp.efectivo_bs + fp.cheque_bs + fp.tarjeta_bs + fp.deposito_bs);
                        if (diferencia_bs != 0)
                        {
                            if (fp.cheque_bs > 0) { fp.cheque_bs = fp.cheque_bs + diferencia_bs; }
                            else if (fp.deposito_bs > 0) { fp.deposito_bs = fp.deposito_bs + diferencia_bs; }
                            else if (fp.tarjeta_bs > 0) { fp.tarjeta_bs = fp.tarjeta_bs + diferencia_bs; }
                            else if (fp.efectivo_bs > 0) { fp.efectivo_bs = fp.efectivo_bs + fp.efectivo_bs; }
                        }
                    }
                }
            }
            return fp;
        }
        */
        #endregion
    }
}