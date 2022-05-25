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
/// Summary description for tipo_cambio
/// </summary>
public class tipo_cambio
{
    //Base de datos
    private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

    #region Propiedades
    //Propiedades privadas
    private int _id_tipocambio = 0;
    private int _id_usuario = 0;
    private DateTime _fecha = DateTime.Now;
    private decimal _compra = 0;
    private decimal _venta = 0;
    private DateTime _registro_fecha = DateTime.Now;

    private string _nombre_usuario = "";

    //Propiedades públicas
    public int id_tipocambio { get { return _id_tipocambio; } set { _id_tipocambio = value; } }
    public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
    public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
    public decimal compra { get { return _compra; } set { _compra = value; } }
    public decimal venta { get { return _venta; } set { _venta = value; } }
    public DateTime registro_fecha { get { return _registro_fecha; } set { _registro_fecha = value; } }

    public string nombre_usuario { get { return _nombre_usuario; } }
    #endregion

    #region Constructores
    public tipo_cambio(int Id_tipocambio)
    {
        _id_tipocambio = Id_tipocambio;
        RecuperarDatos();
    }
    public tipo_cambio(DateTime Fecha)
    {
        _fecha = Fecha;
        RecuperarDatos();
    }
    public tipo_cambio(DateTime Fecha, decimal Compra, decimal Venta)
    {
        _fecha = Fecha.Date;
        _compra = Compra;
        _venta = Venta;
        RecuperarDatos();
    }
    #endregion

    #region Métodos que NO requieren constructor
    public static bool Verificar(DateTime Fecha)
    {
        try
        {
            DbCommand cmd = db1.GetStoredProcCommand("tipo_cambio_Verificar");
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            db1.ExecuteNonQuery(cmd);
            if ((int)db1.ExecuteScalar(cmd) != 0) return true;
            else return false;
        }
        catch { return true; }
    }

    public static int Anterior(DateTime Fecha)
    {
        try
        {
            DbCommand cmd = db1.GetStoredProcCommand("tipo_cambio_Anterior");
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
            return (int)db1.ExecuteScalar(cmd);
        }
        catch { return 0; }
    }

    public static int Actual()
    {
        try
        {
            DbCommand cmd = db1.GetStoredProcCommand("tipo_cambio_Actual");
            return (int)db1.ExecuteScalar(cmd);
        }
        catch { return 0; }
    }

    public static DataTable Lista(bool Fecha_inicio_existe, DateTime Fecha_inicio, 
        bool Fecha_fin_existe, DateTime Fecha_fin)
    {
        //[id_tipocambio],[fecha],[compra],[venta],[nombre_usuario],[registro_fecha]
        DbCommand cmd = db1.GetStoredProcCommand("tipo_cambio_Lista");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        db1.AddInParameter(cmd, "fecha_inicio_existe", DbType.Boolean, Fecha_inicio_existe);
        db1.AddInParameter(cmd, "fecha_inicio", DbType.DateTime, Fecha_inicio);
        db1.AddInParameter(cmd, "fecha_fin_existe", DbType.Boolean, Fecha_fin_existe);
        db1.AddInParameter(cmd, "fecha_fin", DbType.DateTime, Fecha_fin);
        return db1.ExecuteDataSet(cmd).Tables[0];

    }
    #endregion

    #region Métodos que requieren constructor
    private void RecuperarDatos()
    {
        try
        {
            DbCommand cmd = db1.GetStoredProcCommand("tipo_cambio_RecuperarDatos");
            db1.AddInParameter(cmd, "id_tipocambio0", DbType.Int32, _id_tipocambio);
            db1.AddInParameter(cmd, "fecha0", DbType.DateTime, _fecha);

            db1.AddOutParameter(cmd, "id_tipocambio", DbType.Int32, 32);
            db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
            db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 200);
            db1.AddOutParameter(cmd, "compra", DbType.Double, 14);
            db1.AddOutParameter(cmd, "venta", DbType.Double, 14);
            db1.AddOutParameter(cmd, "registro_fecha", DbType.DateTime, 200);

            db1.AddOutParameter(cmd, "nombre_usuario", DbType.String, 50);

            db1.ExecuteNonQuery(cmd);

            _id_tipocambio = (int)db1.GetParameterValue(cmd, "id_tipocambio");
            _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
            _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
            _compra = (decimal)(double)db1.GetParameterValue(cmd, "compra");
            _venta = (decimal)(double)db1.GetParameterValue(cmd, "venta");
            _registro_fecha = (DateTime)db1.GetParameterValue(cmd, "registro_fecha");

            _nombre_usuario = (string)db1.GetParameterValue(cmd, "nombre_usuario");
        }
        catch { }
    }

    public bool Guardar(int context_id_usuario)
    {
        try
        {
            DbCommand cmd = db1.GetStoredProcCommand("tipo_cambio_Guardar");
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, context_id_usuario);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, _fecha);
            db1.AddInParameter(cmd, "compra", DbType.Decimal, _compra);
            db1.AddInParameter(cmd, "venta", DbType.Decimal, _venta);
            _id_tipocambio = (int)db1.ExecuteScalar(cmd);
            return true;
        }
        catch { return false; }
    }
    #endregion
}
