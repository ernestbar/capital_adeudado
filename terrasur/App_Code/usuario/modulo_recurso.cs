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
/// Summary description for modulo_recurso
/// </summary>
public class modulo_recurso
{
    //Base de datos
    private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

    #region Propiedades
    //Propiedades privadas

    //Propiedades públicas
    #endregion

    #region Constructores
    public modulo_recurso()
    {
    }
    #endregion

    #region Métodos que NO requieren constructor
    public static bool Verificar(int Id_modulo, int Id_recurso)
    {
        try
        {
            DbCommand cmd = db1.GetStoredProcCommand("modulo_recurso_Verificar");
            db1.AddInParameter(cmd, "id_modulo", DbType.Int32, Id_modulo);
            db1.AddInParameter(cmd, "id_recurso", DbType.Int32, Id_recurso);
            if ((int)db1.ExecuteScalar(cmd) != 0) { return true; }
            else { return false; }
        }
        catch { return true; }
    }
    #endregion

    #region Métodos que requieren constructor
    #endregion

}
