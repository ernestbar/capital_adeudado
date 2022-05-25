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
using System.Text;
using System.Collections.Generic;

/// <summary>
/// Summary description for migracionTerrasur
/// </summary>
public class migracionTerrasur
{
    //public migracionTerrasur() { }
    private static Database db1 = DatabaseFactory.CreateDatabase("terrasurConn");
    public static string Formato(string Dato) { return Dato.Trim().Replace("'", " ").Replace("--", ""); }
    private static string _encabezado = "TERRASUR LTDA.|ACT.INMOBILIARIA|C. Belizario Salinas Nº 525 - Sopocachi|Teléfono: 2423090|La Paz - Bolivia";
    public static int Id_primer_usuario()
    {
        DbCommand cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT MIN([id_usuario]) FROM [usuario]),0)");
        return (int)db1.ExecuteScalar(cmd);
    }

    public static string MigrarServicios(int Context_id_usuario)
    {
        migracionResumen m_servicio = new migracionResumen("Servicios", true);
        //Datos a migrar:
        DbCommand cmd = db1.GetSqlStringCommand("SELECT [abrev],[concepto],[preciosus],(CASE WHEN [abrev]='MAN' THEN 2 WHEN [concepto] LIKE '%MANTENIMIENTO%' THEN 3 ELSE 1 END) as 'orden' FROM [sat_otros_serv] ORDER BY [orden]");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_sat_otros_serv = db1.ExecuteDataSet(cmd).Tables[0];
        //Migración de [sat_otros_serv]:
        foreach (DataRow fila in tabla_sat_otros_serv.Rows)
        {
            m_servicio.num_encontrato += 1;

            string abrev = Formato(fila["abrev"].ToString());
            string concepto = Formato(fila["concepto"].ToString());
            decimal preciosus = (decimal)fila["preciosus"];
            cmd = db1.GetSqlStringCommand("SELECT COUNT([id_servicio]) FROM [servicio] WHERE RTRIM(LTRIM([codigo]))=@codigo");
            db1.AddInParameter(cmd, "codigo", DbType.String, abrev);
            if ((int)db1.ExecuteScalar(cmd) == 0)
            {
                try
                {
                    bool activo = true; if (concepto.ToUpper().Contains("MANTENIMIENTO") == true) if (abrev.ToUpper() != "MAN") activo = false;
                    cmd = db1.GetSqlStringCommand("INSERT INTO [servicio]([id_usuario],[codigo],[nombre],[valor_sus],[varios],[facturar],[liquidacion],[activo]) VALUES (@id_usuario,@codigo,@nombre,@valor_sus,@varios,@facturar,@liquidacion,@activo)");
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                    db1.AddInParameter(cmd, "codigo", DbType.String, abrev);
                    db1.AddInParameter(cmd, "nombre", DbType.String, concepto);
                    db1.AddInParameter(cmd, "valor_sus", DbType.Decimal, preciosus);
                    db1.AddInParameter(cmd, "varios", DbType.Boolean, true);
                    db1.AddInParameter(cmd, "facturar", DbType.Boolean, true);
                    db1.AddInParameter(cmd, "liquidacion", DbType.Boolean, true);
                    db1.AddInParameter(cmd, "activo", DbType.Boolean, activo);

                    db1.ExecuteNonQuery(cmd);
                    m_servicio.num_migrado += 1;
                }
                catch (Exception ex)
                {
                    m_servicio.num_error += 1;
                    m_servicio.NewMens("Error", "", "abrev: " + abrev + " ; concepto: " + concepto + " ; Mensaje de error: " + ex.Message);
                }
            }
            else
            {
                m_servicio.num_repetido += 1;
                m_servicio.NewMens("Repetido", "[servicio]", "abrev: " + abrev + " ; concepto: " + concepto);
            }
        }

        //Los resultados:
        return m_servicio.Datos();
    }

    public static string MigrarSectoresDeLaCiudad()
    {
        migracionResumen m_sector = new migracionResumen("Sectores de la ciudad", true);
        //Datos a migrar:
        DbCommand cmd = db1.GetSqlStringCommand("(SELECT DISTINCT [num] FROM [sat_zonas]) UNION (SELECT DISTINCT [numzona_do] as 'num' FROM [sat_cli_dir] WHERE [zona_do] not in (SELECT DISTINCT [zona] FROM [sat_zonas]) AND RTRIM(LTRIM([zona_do]))<>'') UNION (SELECT DISTINCT [numzona_of] as 'num' FROM [sat_cli_dir] WHERE [zona_do] not in (SELECT DISTINCT [zona] FROM [sat_zonas]) AND RTRIM(LTRIM([zona_of]))<>'')");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_sat_zonas = db1.ExecuteDataSet(cmd).Tables[0];
        //Migración de [sat_zonas]:
        foreach (DataRow fila in tabla_sat_zonas.Rows)
        {
            m_sector.num_encontrato += 1;
            string num = Formato((fila["num"]).ToString());
            cmd = db1.GetSqlStringCommand("SELECT COUNT([id_sector]) FROM [sector_zona] WHERE RTRIM(LTRIM([codigo]))=@codigo");
            db1.AddInParameter(cmd, "codigo", DbType.String, num);
            if ((int)db1.ExecuteScalar(cmd) == 0)
            {
                try
                {
                    cmd = db1.GetSqlStringCommand("INSERT INTO [sector_zona]([codigo],[nombre]) VALUES(@codigo,@nombre)");
                    db1.AddInParameter(cmd, "codigo", DbType.String, num);
                    db1.AddInParameter(cmd, "nombre", DbType.String, num);
                    db1.ExecuteNonQuery(cmd);
                    m_sector.num_migrado += 1;
                }
                catch (Exception ex)
                {
                    m_sector.num_error += 1;
                    m_sector.NewMens("Error", "", "num: " + num + " ; Mensaje de error: " + ex.Message);
                }
            }
            else
            {
                m_sector.num_repetido += 1;
                m_sector.NewMens("Repetido", "", "num: " + num);
            }
        }
        return m_sector.Datos();
    }

    public static string MigrarZonas()
    {
        migracionResumen m_zona = new migracionResumen("Zonas", true);
        //Datos a migrar:
        DbCommand cmd = db1.GetSqlStringCommand("SELECT [num],[zona] FROM [sat_zonas] UNION (SELECT DISTINCT [numzona_do] as 'num', [zona_do] as 'zona' FROM [sat_cli_dir] WHERE [zona_do] not in (SELECT DISTINCT [zona] FROM [sat_zonas]) AND RTRIM(LTRIM([zona_do]))<>'') UNION (SELECT DISTINCT [numzona_of] as 'num', [zona_of] as 'zona' FROM [sat_cli_dir] WHERE [zona_do] not in (SELECT DISTINCT [zona] FROM [sat_zonas]) AND RTRIM(LTRIM([zona_of]))<>'')");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_sat_zonas = db1.ExecuteDataSet(cmd).Tables[0];
        //Migración de [sat_zonas]:
        foreach (DataRow fila in tabla_sat_zonas.Rows)
        {
            m_zona.num_encontrato += 1;
            string num = Formato((fila["num"]).ToString());
            string zona = Formato(fila["zona"].ToString());
            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_sector] FROM [sector_zona] WHERE RTRIM(LTRIM([codigo]))=@codigo),0)");
            db1.AddInParameter(cmd, "codigo", DbType.String, num);
            int id_sector = (int)db1.ExecuteScalar(cmd);
            if (id_sector > 0)
            {
                cmd = db1.GetSqlStringCommand("SELECT COUNT([id_zona]) FROM [zona] WHERE RTRIM(LTRIM([nombre]))=@nombre");
                db1.AddInParameter(cmd, "nombre", DbType.String, zona);
                if ((int)db1.ExecuteScalar(cmd) == 0)
                {
                    try
                    {
                        cmd = db1.GetSqlStringCommand("INSERT INTO [zona]([id_sector],[nombre]) VALUES(@id_sector,@nombre)");
                        db1.AddInParameter(cmd, "id_sector", DbType.Int32, id_sector);
                        db1.AddInParameter(cmd, "nombre", DbType.String, zona);
                        db1.ExecuteNonQuery(cmd);
                        m_zona.num_migrado += 1;
                    }
                    catch (Exception ex)
                    {
                        m_zona.num_error += 1;
                        m_zona.NewMens("Error", "", "nombre(zona): " + zona + " ; Mensaje de error: " + ex.Message);
                    }
                }
                else
                {
                    m_zona.num_repetido += 1;
                    m_zona.NewMens("Repetido", "", "nombre(zona): " + zona);
                }
            }
            else
            {
                m_zona.num_error += 1;
                m_zona.NewMens("Error", "", "num(sector no encontrado): " + num);
            }
        }
        return m_zona.Datos();
    }

    public static string MigrarBancos(int Context_id_usuario)
    {
        migracionResumen m_banco = new migracionResumen("Banco", true);

        //Datos a migrar:
        DbCommand cmd = db1.GetSqlStringCommand("SELECT [abrev],[nombre] FROM [sat_bancos]");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);

        DataTable tabla_sat_bancos = db1.ExecuteDataSet(cmd).Tables[0];
        //Migración de [sat_bancos] a [banco]:
        foreach (DataRow fila in tabla_sat_bancos.Rows)
        {
            m_banco.num_encontrato += 1;
            string abrev = Formato(fila["abrev"].ToString());
            string nombre = Formato(fila["nombre"].ToString());
            cmd = db1.GetSqlStringCommand("SELECT COUNT([id_banco]) FROM [banco] WHERE RTRIM(LTRIM([codigo]))=@codigo");
            db1.AddInParameter(cmd, "codigo", DbType.String, abrev);
            if ((int)db1.ExecuteScalar(cmd) == 0)
            {
                try
                {
                    cmd = db1.GetSqlStringCommand("INSERT INTO [banco]([id_usuario],[codigo],[nombre],[activo]) VALUES(@id_usuario,@codigo,@nombre,@activo)");
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                    db1.AddInParameter(cmd, "codigo", DbType.String, abrev);
                    db1.AddInParameter(cmd, "nombre", DbType.String, nombre);
                    db1.AddInParameter(cmd, "activo", DbType.Boolean, true);
                    db1.ExecuteNonQuery(cmd);
                    m_banco.num_migrado += 1;
                }
                catch (Exception ex)
                {
                    m_banco.num_error += 1;
                    m_banco.NewMens("Error", "", "abrev: " + abrev + " ; nombre: " + nombre + " ; Mensaje de error: " + ex.Message);
                }
            }
            else
            {
                m_banco.num_repetido += 1;
                m_banco.NewMens("Repetido", "", "abrev: " + abrev + " ; nombre: " + nombre);
            }
        }
        return m_banco.Datos();
    }

    public static string MigrarDPRs(int Context_id_usuario)
    {
        migracionResumen m_dpr = new migracionResumen("Dpr", true);
        migracionResumen m_bono = new migracionResumen("Bono", true);
        //Datos a migrar:
        DbCommand cmd = db1.GetSqlStringCommand("SELECT (CASE LTRIM(RTRIM([abrev])) WHEN '' THEN 'SIN' ELSE LTRIM(RTRIM([abrev])) END) as 'abrev',[concepto] FROM [sat_dpr_ini]");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_sat_dpr_ini = db1.ExecuteDataSet(cmd).Tables[0];
        //Migración de [sat_dpr_ini] a [dpr]:
        foreach (DataRow fila in tabla_sat_dpr_ini.Rows)
        {
            m_dpr.num_encontrato += 1;
            string abrev = Formato(fila["abrev"].ToString());
            string concepto = Formato(fila["concepto"].ToString());
            cmd = db1.GetSqlStringCommand("SELECT COUNT([id_dpr]) FROM [dpr] WHERE [codigo]=@codigo");
            db1.AddInParameter(cmd, "codigo", DbType.String, abrev);
            if ((int)db1.ExecuteScalar(cmd) == 0)
            {
                try
                {
                    cmd = db1.GetSqlStringCommand("INSERT INTO [dpr]([id_usuario],[codigo],[nombre],[inicial],[liquidable],[activo]) VALUES(@id_usuario,@codigo,@nombre,@inicial,@liquidable,@activo)");
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                    db1.AddInParameter(cmd, "codigo", DbType.String, abrev);
                    db1.AddInParameter(cmd, "nombre", DbType.String, concepto);
                    db1.AddInParameter(cmd, "inicial", DbType.Boolean, true);
                    db1.AddInParameter(cmd, "liquidable", DbType.Boolean, false);
                    db1.AddInParameter(cmd, "activo", DbType.Boolean, true);
                    db1.ExecuteNonQuery(cmd);
                    m_dpr.num_migrado += 1;
                }
                catch (Exception ex)
                {
                    m_dpr.num_error += 1;
                    m_dpr.NewMens("Error", "", "abrev(dpr_ini): " + abrev + " ; concepto: " + concepto + " ; Mensaje de error: " + ex.Message);
                }
            }
            else
            {
                m_dpr.num_repetido += 1;
                m_dpr.NewMens("Error", "", "abrev(dpr_ini): " + abrev + " ; concepto: " + concepto);
            }
        }

        //Datos a migrar:
        cmd = db1.GetSqlStringCommand("SELECT (CASE LTRIM(RTRIM([abrev])) WHEN '' THEN 'SIN' ELSE LTRIM(RTRIM([abrev])) END) as 'abrev',[detalle] FROM [sat_par_bono]");
        DataTable tabla_sat_par_bono = db1.ExecuteDataSet(cmd).Tables[0];
        //Migración de [sat_par_bono] a [dpr]:
        foreach (DataRow fila in tabla_sat_par_bono.Rows)
        {
            m_bono.num_encontrato += 1;
            string abrev = Formato(fila["abrev"].ToString());
            string detalle = Formato(fila["detalle"].ToString());
            cmd = db1.GetSqlStringCommand("SELECT COUNT([id_dpr]) FROM [dpr] WHERE [codigo]=@codigo");
            db1.AddInParameter(cmd, "codigo", DbType.String, abrev);
            if ((int)db1.ExecuteScalar(cmd) == 0)
            {
                try
                {
                    cmd = db1.GetSqlStringCommand("INSERT INTO [dpr]([id_usuario],[codigo],[nombre],[inicial],[liquidable],[activo]) VALUES(@id_usuario,@codigo,@nombre,@inicial,@liquidable,@activo)");
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                    db1.AddInParameter(cmd, "codigo", DbType.String, abrev);
                    db1.AddInParameter(cmd, "nombre", DbType.String, detalle);
                    db1.AddInParameter(cmd, "inicial", DbType.Boolean, false);
                    db1.AddInParameter(cmd, "liquidable", DbType.Boolean, false);
                    db1.AddInParameter(cmd, "activo", DbType.Boolean, true);
                    db1.ExecuteNonQuery(cmd);
                    m_bono.num_migrado += 1;
                }
                catch (Exception ex)
                {
                    m_bono.num_error += 1;
                    m_bono.NewMens("Error", "", "abrev(par_bono): " + abrev + " ; detalle: " + detalle + " ; Mensaje de error: " + ex.Message);
                }
            }
            else
            {
                m_bono.num_repetido += 1;
                m_bono.NewMens("Error", "", "abrev(par_bono): " + abrev + " ; detalle: " + detalle);
            }
        }
        return m_dpr.Datos() + m_bono.Datos();
    }

    public static string MigrarParametroFacturacion(int Context_id_usuario)
    {
        migracionResumen m_fact = new migracionResumen("Parámetros de facturación", true);
        //Datos a migrar:
        DbCommand cmd = db1.GetSqlStringCommand("SELECT [ruc_emp],[fle],[n_auto],[llave_dos],[nfac_sig] FROM [sat_constfac]");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_sat_constfac = db1.ExecuteDataSet(cmd).Tables[0];
        //Migración de [tabla_sat_constfac]:
        foreach (DataRow fila in tabla_sat_constfac.Rows)
        {
            m_fact.num_encontrato += 1;
            string ruc_emp = Formato(fila["ruc_emp"].ToString());
            string fle = Formato(fila["fle"].ToString());
            string n_auto = Formato(fila["n_auto"].ToString());
            string llave_dos = fila["llave_dos"].ToString();
            string nfac_sig = Formato(fila["nfac_sig"].ToString());
            cmd = db1.GetSqlStringCommand("SELECT COUNT([id_parametrofacturacion]) FROM [parametro_facturacion] WHERE [num_autorizacion]=@num_autorizacion");
            db1.AddInParameter(cmd, "num_autorizacion", DbType.Decimal, decimal.Parse(n_auto));
            if ((int)db1.ExecuteScalar(cmd) == 0)
            {
                try
                {
                    cmd = db1.GetSqlStringCommand("INSERT INTO [parametro_facturacion]([id_usuario],[razon_social],[nit],[fecha_limite],[num_autorizacion],[llave_dosificacion],[num_siguiente_factura],[encabezado]) VALUES (@id_usuario,@razon_social,@nit,@fecha_limite,@num_autorizacion,@llave_dosificacion,@num_siguiente_factura,@encabezado)");
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                    db1.AddInParameter(cmd, "razon_social", DbType.String, "");
                    db1.AddInParameter(cmd, "nit", DbType.Decimal, decimal.Parse(ruc_emp));
                    db1.AddInParameter(cmd, "fecha_limite", DbType.DateTime, DateTime.Parse(fle));
                    db1.AddInParameter(cmd, "num_autorizacion", DbType.Decimal, decimal.Parse(n_auto));
                    db1.AddInParameter(cmd, "llave_dosificacion", DbType.String, llave_dos);
                    db1.AddInParameter(cmd, "num_siguiente_factura", DbType.Int32, int.Parse(nfac_sig));
                    db1.AddInParameter(cmd, "encabezado", DbType.String, _encabezado);
                    db1.ExecuteNonQuery(cmd);
                    m_fact.num_migrado += 1;
                }
                catch (Exception ex)
                {
                    m_fact.num_error += 1;
                    m_fact.NewMens("Error", "", "n_auto: " + n_auto + " ; ruc_emp : " + ruc_emp + " ; Mensaje de error: " + ex.Message);
                }
            }
            else
            {
                m_fact.num_repetido += 1;
                m_fact.NewMens("Error", "", "n_auto: " + n_auto + " ; ruc_emp : " + ruc_emp);
            }
        }
        return m_fact.Datos();
    }

    public static string MigrarCliente(int Context_id_usuario)
    {
        migracionResumen m_cli = new migracionResumen("Clientes", true);
        //Datos a migrar:
        DbCommand cmd = db1.GetSqlStringCommand("SELECT [cod_cli],[ci],(CASE WHEN [ext] in ('LP','CB','SC','TJ','PA','BE','CH','PT','OR') THEN [ext] ELSE '' END) as 'ext',RTRIM(LTRIM([ruc])) as 'ruc',RTRIM(LTRIM([nombre])) as 'nombre',RTRIM(LTRIM([paterno])) as 'paterno',RTRIM(LTRIM([materno])) as 'materno' FROM [sat_clientes] WHERE [ci]>0");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_sat_clientes = db1.ExecuteDataSet(cmd).Tables[0];
        //Migración de [sat_clientes]:
        foreach (DataRow fila in tabla_sat_clientes.Rows)
        {
            m_cli.num_encontrato += 1;
            string sat_cod_cli = Formato(fila["cod_cli"].ToString());
            string sat_ci = Formato(fila["ci"].ToString());
            string sat_ext = Formato(fila["ext"].ToString());
            string sat_ruc = Formato(fila["ruc"].ToString());
            string sat_nombre = Formato(fila["nombre"].ToString());
            string sat_paterno = Formato(fila["paterno"].ToString());
            string sat_materno = Formato(fila["materno"].ToString());
            cmd = db1.GetSqlStringCommand("SELECT COUNT([id_cliente]) FROM [cliente] WHERE [ci]=@ci");
            db1.AddInParameter(cmd, "ci", DbType.String, sat_ci);
            if ((int)db1.ExecuteScalar(cmd) == 0)
            {
                string sat_telefono1 = "", sat_telefono2 = "", sat_telefono3 = "", sat_zona_do = "", sat_dir_dom = "";
                string sat_zona_of = "", sat_dir_ofi = "", sat_cobrar_en = "", sat_email = "";
                try
                {
                    cmd = db1.GetSqlStringCommand("SELECT TOP 1 (CASE [telefono1] WHEN 0 THEN '' ELSE CONVERT(nvarchar,[telefono1]) END) as 'telefono1',(CASE [telefono2] WHEN 0 THEN '' ELSE CONVERT(nvarchar,[telefono2]) END) as 'telefono2',(CASE [telefono3] WHEN 0 THEN '' ELSE CONVERT(nvarchar,[telefono3]) END) as 'telefono3',(CASE WHEN [dir_dom]='' THEN '' WHEN [dir_dom]<>'' AND [zona_do]='' THEN 'PENDIENTE' ELSE [zona_do] END) as 'zona_do',[dir_dom],(CASE WHEN [dir_ofi]='' THEN '' WHEN [dir_ofi]<>'' AND [zona_of]='' THEN 'PENDIENTE' ELSE [zona_of] END) as 'zona_of',[dir_ofi],(CASE [cobrar_en] WHEN 'D' THEN 'domicilio' WHEN 'O' THEN 'oficina' ELSE 'terrasur' END) as 'cobrar_en',[email] FROM [sat_cli_dir] WHERE [cod_cli]=@ci");
                    db1.AddInParameter(cmd, "ci", DbType.Decimal, decimal.Parse(sat_ci));
                    DataTable tabla_sat_cli_dir = db1.ExecuteDataSet(cmd).Tables[0];
                    if (tabla_sat_cli_dir.Rows.Count == 1)
                    {
                        sat_telefono1 = Formato(tabla_sat_cli_dir.Rows[0]["telefono1"].ToString());
                        sat_telefono2 = Formato(tabla_sat_cli_dir.Rows[0]["telefono2"].ToString());
                        sat_telefono3 = Formato(tabla_sat_cli_dir.Rows[0]["telefono3"].ToString());
                        sat_zona_do = Formato(tabla_sat_cli_dir.Rows[0]["zona_do"].ToString());
                        sat_dir_dom = Formato(tabla_sat_cli_dir.Rows[0]["dir_dom"].ToString());
                        sat_zona_of = Formato(tabla_sat_cli_dir.Rows[0]["zona_of"].ToString());
                        sat_dir_ofi = Formato(tabla_sat_cli_dir.Rows[0]["dir_ofi"].ToString());
                        sat_cobrar_en = Formato(tabla_sat_cli_dir.Rows[0]["cobrar_en"].ToString());
                        sat_email = Formato(tabla_sat_cli_dir.Rows[0]["email"].ToString());
                    }

                    cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT TOP 1 [id_lugarcedula] FROM [lugar_cedula] WHERE RTRIM(LTRIM([codigo]))=@codigo),0)");
                    db1.AddInParameter(cmd, "codigo", DbType.String, sat_ext);
                    int id_lugarcedula = (int)db1.ExecuteScalar(cmd);
                    cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT TOP 1 [id_lugarcobro] FROM [lugar_cobro] WHERE RTRIM(LTRIM([codigo]))=@codigo),0)");
                    db1.AddInParameter(cmd, "codigo", DbType.String, sat_cobrar_en);
                    int id_lugarcobro = (int)db1.ExecuteScalar(cmd);
                    cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT TOP 1 [id_zona] FROM [zona] WHERE RTRIM(LTRIM([nombre]))=@nombre),0)");
                    db1.AddInParameter(cmd, "nombre", DbType.String, sat_zona_do);
                    int domicilio_id_zona = (int)db1.ExecuteScalar(cmd);
                    cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT TOP 1 [id_zona] FROM [zona] WHERE RTRIM(LTRIM([nombre]))=@nombre),0)");
                    db1.AddInParameter(cmd, "nombre", DbType.String, sat_zona_of);
                    int oficina_id_zona = (int)db1.ExecuteScalar(cmd);
                    //string id_lugarcedula = (string)db1.ExecuteScalar(CommandType.Text, "SELECT ISNULL((SELECT TOP 1 CONVERT(nvarchar,[id_lugarcedula]) FROM [lugar_cedula] WHERE [codigo]='" + sat_ext + "'),'NULL')");
                    //string id_lugarcobro = (string)db1.ExecuteScalar(CommandType.Text, "SELECT ISNULL((SELECT TOP 1 CONVERT(nvarchar,[id_lugarcobro]) FROM [lugar_cobro] WHERE [codigo]='" + sat_cobrar_en + "'),'NULL')");
                    //string domicilio_id_zona = (string)db1.ExecuteScalar(CommandType.Text, "SELECT ISNULL((SELECT TOP 1 CONVERT(nvarchar,[id_zona]) FROM [zona] WHERE [nombre]='" + sat_zona_do + "'),'NULL')");
                    //string oficina_id_zona = (string)db1.ExecuteScalar(CommandType.Text, "SELECT ISNULL((SELECT TOP 1 CONVERT(nvarchar,[id_zona]) FROM [zona] WHERE [nombre]='" + sat_zona_of + "'),'NULL')");

                    cmd = db1.GetSqlStringCommand("INSERT INTO [cliente] ([id_lugarcedula],[id_lugarcobro],[id_usuario],[ci],[nit],[nombres],[paterno],[materno],[fecha_nacimiento],[celular],[fax],[email],[casilla],[domicilio_direccion],[domicilio_fono],[domicilio_id_zona],[oficina_direccion],[oficina_fono],[oficina_id_zona],[transitorio]) VALUES (@id_lugarcedula,@id_lugarcobro,@id_usuario,@ci,@nit,@nombres,@paterno,@materno,@fecha_nacimiento,@celular,@fax,@email,@casilla,@domicilio_direccion,@domicilio_fono,@domicilio_id_zona,@oficina_direccion,@oficina_fono,@oficina_id_zona,@transitorio)");

                    if (id_lugarcedula > 0) db1.AddInParameter(cmd, "id_lugarcedula", DbType.Int32, id_lugarcedula);
                    else db1.AddInParameter(cmd, "id_lugarcedula", DbType.Int32, null);
                    if (id_lugarcobro > 0) db1.AddInParameter(cmd, "id_lugarcobro", DbType.Int32, id_lugarcobro);
                    else db1.AddInParameter(cmd, "id_lugarcobro", DbType.Int32, null);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);

                    db1.AddInParameter(cmd, "ci", DbType.String, sat_ci);
                    db1.AddInParameter(cmd, "nit", DbType.String, sat_ruc);
                    db1.AddInParameter(cmd, "nombres", DbType.String, sat_nombre);
                    db1.AddInParameter(cmd, "paterno", DbType.String, sat_paterno);
                    db1.AddInParameter(cmd, "materno", DbType.String, sat_materno);
                    db1.AddInParameter(cmd, "fecha_nacimiento", DbType.DateTime, null);

                    db1.AddInParameter(cmd, "celular", DbType.String, sat_telefono2);
                    db1.AddInParameter(cmd, "fax", DbType.String, "");
                    db1.AddInParameter(cmd, "email", DbType.String, sat_email);
                    db1.AddInParameter(cmd, "casilla", DbType.String, "");
                    db1.AddInParameter(cmd, "domicilio_direccion", DbType.String, sat_dir_dom);
                    db1.AddInParameter(cmd, "domicilio_fono", DbType.String, sat_telefono1);
                    if (domicilio_id_zona > 0) db1.AddInParameter(cmd, "domicilio_id_zona", DbType.Int32, domicilio_id_zona);
                    else db1.AddInParameter(cmd, "domicilio_id_zona", DbType.Int32, null);

                    db1.AddInParameter(cmd, "oficina_direccion", DbType.String, sat_dir_ofi);
                    db1.AddInParameter(cmd, "oficina_fono", DbType.String, sat_telefono3);
                    if (oficina_id_zona > 0) db1.AddInParameter(cmd, "oficina_id_zona", DbType.Int32, oficina_id_zona);
                    else db1.AddInParameter(cmd, "oficina_id_zona", DbType.Int32, null);

                    db1.AddInParameter(cmd, "transitorio", DbType.Boolean, false);
                    db1.ExecuteNonQuery(cmd);
                    m_cli.num_migrado += 1;
                }
                catch (Exception ex)
                {
                    m_cli.num_error += 1;
                    m_cli.NewMens("Error", "", "ci: " + sat_ci + " " + "cod_cli: " + sat_cod_cli + " ; Mensaje de error: " + ex.Message);
                }
            }
            else
            {
                m_cli.num_repetido += 1;
                m_cli.NewMens("Repetido", "", "ci: " + sat_ci + " " + "cod_cli: " + sat_cod_cli);
            }
        }
        return m_cli.Datos();
    }

    public static string MigrarClienteTransitorio(int Context_id_usuario)
    {
        migracionResumen m_cli = new migracionResumen("Clientes transitorios", true);
        //Datos a migrar:
        DbCommand cmd = db1.GetSqlStringCommand("SELECT DISTINCT ct.[ruc],LTRIM(RTRIM(ct.[nombre])) as 'nombre',LTRIM(RTRIM(ct.[paterno])) as 'paterno' FROM [sat_cli_temp] as [ct] ORDER BY [ruc]");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_sat_clientes_transitorio = db1.ExecuteDataSet(cmd).Tables[0];
        //Migración de [sat_cli_temp]:
        foreach (DataRow fila in tabla_sat_clientes_transitorio.Rows)
        {
            m_cli.num_encontrato += 1;
            string sat_ruc = Formato(fila["ruc"].ToString());
            string sat_nombre = Formato(fila["nombre"].ToString());
            string sat_paterno = Formato(fila["paterno"].ToString());
            cmd = db1.GetSqlStringCommand("SELECT COUNT([id_cliente]) FROM [cliente] WHERE [nit]=@nit AND (([nit]<>'0') OR ([nit]='0' AND ([paterno]=@paterno AND [nombres]=@nombres))) AND [transitorio]=1");
            db1.AddInParameter(cmd, "nit", DbType.String, sat_ruc);
            db1.AddInParameter(cmd, "paterno", DbType.String, sat_paterno);
            db1.AddInParameter(cmd, "nombres", DbType.String, sat_nombre);
            if ((int)db1.ExecuteScalar(cmd) == 0)
            {
                try
                {

                    cmd = db1.GetSqlStringCommand("INSERT INTO [cliente] ([id_lugarcedula],[id_lugarcobro],[id_usuario],[ci],[nit],[nombres],[paterno],[materno],[fecha_nacimiento],[celular],[fax],[email],[casilla],[domicilio_direccion],[domicilio_fono],[domicilio_id_zona],[oficina_direccion],[oficina_fono],[oficina_id_zona],[transitorio]) VALUES (@id_lugarcedula,@id_lugarcobro,@id_usuario,@ci,@nit,@nombres,@paterno,@materno,@fecha_nacimiento,@celular,@fax,@email,@casilla,@domicilio_direccion,@domicilio_fono,@domicilio_id_zona,@oficina_direccion,@oficina_fono,@oficina_id_zona,@transitorio)");
                    db1.AddInParameter(cmd, "id_lugarcedula", DbType.Int32, null);
                    db1.AddInParameter(cmd, "id_lugarcobro", DbType.Int32, null);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);

                    db1.AddInParameter(cmd, "ci", DbType.String, "");
                    db1.AddInParameter(cmd, "nit", DbType.String, sat_ruc);
                    db1.AddInParameter(cmd, "nombres", DbType.String, sat_nombre);
                    db1.AddInParameter(cmd, "paterno", DbType.String, sat_paterno);
                    db1.AddInParameter(cmd, "materno", DbType.String, "");
                    db1.AddInParameter(cmd, "fecha_nacimiento", DbType.DateTime, null);

                    db1.AddInParameter(cmd, "celular", DbType.String, "");
                    db1.AddInParameter(cmd, "fax", DbType.String, "");
                    db1.AddInParameter(cmd, "email", DbType.String, "");
                    db1.AddInParameter(cmd, "casilla", DbType.String, "");
                    db1.AddInParameter(cmd, "domicilio_direccion", DbType.String, "");
                    db1.AddInParameter(cmd, "domicilio_fono", DbType.String, "");
                    db1.AddInParameter(cmd, "domicilio_id_zona", DbType.Int32, null);

                    db1.AddInParameter(cmd, "oficina_direccion", DbType.String, "");
                    db1.AddInParameter(cmd, "oficina_fono", DbType.String, "");
                    db1.AddInParameter(cmd, "oficina_id_zona", DbType.Int32, null);

                    db1.AddInParameter(cmd, "transitorio", DbType.Boolean, true);
                    db1.ExecuteNonQuery(cmd);
                    m_cli.num_migrado += 1;
                }
                catch (Exception ex)
                {
                    m_cli.num_error += 1;
                    m_cli.NewMens("Error", "", "ruc: " + sat_ruc + " ; " + "paterno: " + sat_paterno + " ; " + "nombre: " + sat_nombre + " ; Mensaje de error: " + ex.Message);
                }
            }
            else
            {
                m_cli.num_repetido += 1;
                m_cli.NewMens("Repetido", "", "ruc: " + sat_ruc + " ; " + "paterno: " + sat_paterno + " ; " + "nombre: " + sat_nombre);
            }
        }
        return m_cli.Datos();
    }

    public static string MigrarClienteAdicional(int Context_id_usuario)
    {
        migracionResumen m_cli = new migracionResumen("Clientes adicionales", true);
        //Datos a migrar:
        DbCommand cmd = db1.GetSqlStringCommand("SELECT DISTINCT [adcod_cli],LTRIM(RTRIM([adnombre])) as 'adnombre',LTRIM(RTRIM([adpaterno])) as 'adpaterno', (CASE LTRIM(RTRIM([admaterno])) WHEN '.' THEN '' ELSE LTRIM(RTRIM([admaterno])) END) as 'admaterno' FROM [sat_cli_adi] ORDER BY [adcod_cli]");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_sat_clientes_adicionales = db1.ExecuteDataSet(cmd).Tables[0];
        //Migración de [sat_cli_adi]:
        foreach (DataRow fila in tabla_sat_clientes_adicionales.Rows)
        {
            m_cli.num_encontrato += 1;
            string sat_adcod_cli = Formato(fila["adcod_cli"].ToString());
            string sat_adnombre = Formato(fila["adnombre"].ToString());
            string sat_adpaterno = Formato(fila["adpaterno"].ToString());
            string sat_admaterno = Formato(fila["admaterno"].ToString());
            cmd = db1.GetSqlStringCommand("SELECT COUNT([id_cliente]) FROM [cliente] WHERE [ci]=@ci AND [transitorio]=0");
            db1.AddInParameter(cmd, "ci", DbType.String, sat_adcod_cli);
            if ((int)db1.ExecuteScalar(cmd) == 0)
            {
                try
                {

                    cmd = db1.GetSqlStringCommand("INSERT INTO [cliente] ([id_lugarcedula],[id_lugarcobro],[id_usuario],[ci],[nit],[nombres],[paterno],[materno],[fecha_nacimiento],[celular],[fax],[email],[casilla],[domicilio_direccion],[domicilio_fono],[domicilio_id_zona],[oficina_direccion],[oficina_fono],[oficina_id_zona],[transitorio]) VALUES (@id_lugarcedula,@id_lugarcobro,@id_usuario,@ci,@nit,@nombres,@paterno,@materno,@fecha_nacimiento,@celular,@fax,@email,@casilla,@domicilio_direccion,@domicilio_fono,@domicilio_id_zona,@oficina_direccion,@oficina_fono,@oficina_id_zona,@transitorio)");
                    db1.AddInParameter(cmd, "id_lugarcedula", DbType.Int32, null);
                    db1.AddInParameter(cmd, "id_lugarcobro", DbType.Int32, null);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);

                    db1.AddInParameter(cmd, "ci", DbType.String, sat_adcod_cli);
                    db1.AddInParameter(cmd, "nit", DbType.String, "");
                    db1.AddInParameter(cmd, "nombres", DbType.String, sat_adnombre);
                    db1.AddInParameter(cmd, "paterno", DbType.String, sat_adpaterno);
                    db1.AddInParameter(cmd, "materno", DbType.String, sat_admaterno);
                    db1.AddInParameter(cmd, "fecha_nacimiento", DbType.DateTime, null);

                    db1.AddInParameter(cmd, "celular", DbType.String, "");
                    db1.AddInParameter(cmd, "fax", DbType.String, "");
                    db1.AddInParameter(cmd, "email", DbType.String, "");
                    db1.AddInParameter(cmd, "casilla", DbType.String, "");
                    db1.AddInParameter(cmd, "domicilio_direccion", DbType.String, "");
                    db1.AddInParameter(cmd, "domicilio_fono", DbType.String, "");
                    db1.AddInParameter(cmd, "domicilio_id_zona", DbType.Int32, null);

                    db1.AddInParameter(cmd, "oficina_direccion", DbType.String, "");
                    db1.AddInParameter(cmd, "oficina_fono", DbType.String, "");
                    db1.AddInParameter(cmd, "oficina_id_zona", DbType.Int32, null);

                    db1.AddInParameter(cmd, "transitorio", DbType.Boolean, false);
                    db1.ExecuteNonQuery(cmd);
                    m_cli.num_migrado += 1;
                }
                catch (Exception ex)
                {
                    m_cli.num_error += 1;
                    m_cli.NewMens("Error", "", "adcod_cli: " + sat_adcod_cli + " ; " + "adnombre: " + sat_adnombre + " ; " + "adpaterno: " + sat_adpaterno + " ; " + "admaterno: " + sat_admaterno + " ; Mensaje de error: " + ex.Message);
                }
            }
            else
            {
                m_cli.num_repetido += 1;
                m_cli.NewMens("Repetido", "", "adcod_cli: " + sat_adcod_cli + " ; " + "adnombre: " + sat_adnombre + " ; " + "adpaterno: " + sat_adpaterno + " ; " + "admaterno: " + sat_admaterno);
            }
        }
        return m_cli.Datos();
    }

    public static string MigrarTipoCambio(int Context_id_usuario)
    {
        migracionResumen m_tc = new migracionResumen("Tipo de cambio", true);
        //Datos a migrar:
        DbCommand cmd = db1.GetSqlStringCommand("SELECT DISTINCT [fecha],[tccompra],[tcventa] FROM [sat_tcdolar] WHERE [fecha]>'01/01/1900' ORDER BY [fecha]");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_sat_tc_dolar = db1.ExecuteDataSet(cmd).Tables[0];
        //Migración de [sat_otros_serv]:
        foreach (DataRow fila in tabla_sat_tc_dolar.Rows)
        {
            m_tc.num_encontrato += 1;
            DateTime sat_fecha = (DateTime)fila["fecha"];
            decimal sat_tccompra = (decimal)fila["tccompra"];
            decimal sat_tcventa = (decimal)fila["tcventa"];
            cmd = db1.GetSqlStringCommand("SELECT COUNT([compra]) FROM [tipo_cambio] WHERE [fecha]=@fecha");
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, sat_fecha);
            if ((int)db1.ExecuteScalar(cmd) == 0)
            {
                try
                {
                    cmd = db1.GetSqlStringCommand("INSERT INTO [tipo_cambio]([id_usuario],[fecha],[compra],[venta],[registro_fecha]) VALUES(@id_usuario,@fecha,@compra,@venta,GETDATE())");
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                    db1.AddInParameter(cmd, "fecha", DbType.DateTime, sat_fecha);
                    db1.AddInParameter(cmd, "compra", DbType.Decimal, sat_tccompra);
                    db1.AddInParameter(cmd, "venta", DbType.Decimal, sat_tcventa);
                    db1.ExecuteNonQuery(cmd);
                    m_tc.num_migrado += 1;
                }
                catch (Exception ex)
                {
                    m_tc.num_error += 1;
                    m_tc.NewMens("Error", "", "fecha: " + sat_fecha.ToShortDateString() + " ; tccompra: " + sat_tccompra.ToString() + " ; tcventa: " + sat_tcventa.ToString() + " ; Mensaje de error: " + ex.Message);
                }
            }
            else
            {
                m_tc.num_repetido += 1;
                m_tc.NewMens("Error", "", "fecha: " + sat_fecha.ToShortDateString() + " ; tccompra: " + sat_tccompra.ToString() + " ; tcventa: " + sat_tcventa.ToString());
            }
        }
        return m_tc.Datos();
    }

    public static string MigrarUsuarioRol(int Context_id_usuario)
    {
        migracionResumen m_usuario = new migracionResumen("Usuarios y Roles", true);
        migracionResumen m_grupo = new migracionResumen("Grupos de venta");
        //Datos a migrar:
        DbCommand cmd = db1.GetSqlStringCommand("(SELECT DISTINCT u.[ci],u.[nombre],u.[paterno],u.[materno],(CASE u.[clave] WHEN 0 THEN 1234 ELSE u.[clave] END) as 'clave',u.[id],u.[estado],u.[grupo],u.[adm],u.[caj],u.[pro],(CASE (SELECT COUNT([ci_cob]) FROM [sat_cobrador] WHERE [ci_cob]=u.[ci]) WHEN 0 THEN CONVERT(bit,0) ELSE CONVERT(bit,1) END) as 'cob',(CASE (SELECT COUNT([ci]) FROM [sat_directores] WHERE LTRIM(RTRIM(UPPER([nombre])))=LTRIM(RTRIM(UPPER(u.[nombre]))) AND LTRIM(RTRIM(UPPER([apellido])))=LTRIM(RTRIM(UPPER(u.[paterno])))) WHEN 0 THEN CONVERT(bit,0) ELSE CONVERT(bit,1) END) as 'dir' FROM [sat_usuarios] as u WHERE u.[ci]>0 AND ([adm]=1 OR [pro]=1 OR [caj]=1)) UNION (SELECT d.[ci],d.[nombre],d.[apellido] as 'paterno','' as 'materno',1234 as 'clave', SUBSTRING(LTRIM(RTRIM(d.[nombre])),1,1) + '.' + d.[apellido] as 'id','' as estado, d.[grupo],CONVERT(bit,0) as 'adm',CONVERT(bit,0) as 'caj',CONVERT(bit,0) as 'pro',CONVERT(bit,0) as 'cob',CONVERT(bit,1) as 'dir' FROM [sat_directores] as d WHERE d.[grupo] NOT IN (SELECT u.[grupo] FROM [sat_usuarios] as u WHERE (CASE (SELECT COUNT([ci]) FROM [sat_directores] WHERE LTRIM(RTRIM(UPPER([nombre])))=LTRIM(RTRIM(UPPER(u.[nombre]))) AND LTRIM(RTRIM(UPPER([apellido])))=LTRIM(RTRIM(UPPER(u.[paterno])))) WHEN 0 THEN CONVERT(bit,0) ELSE CONVERT(bit,1) END)=1)) UNION (SELECT (CASE c.[ci_cob] WHEN 9999999 THEN 99999999 ELSE c.[ci_cob] END) as 'ci',c.[nombre],c.[paterno],'' as 'materno','1234' as 'clave', SUBSTRING(LTRIM(RTRIM(c.[nombre])),1,1) + '.' + c.[paterno] as 'id','' as estado, 0 as 'grupo',CONVERT(bit,0) as 'adm',CONVERT(bit,0) as 'caj',CONVERT(bit,0) as 'pro',CONVERT(bit,1) as 'cob',CONVERT(bit,0) as 'dir' FROM [sat_cobrador] as c WHERE c.[ci_cob]>0 AND c.[ci_cob] NOT IN (SELECT u.[ci] FROM [sat_usuarios] as u WHERE (CASE (SELECT COUNT([ci_cob]) FROM [sat_cobrador] WHERE [ci_cob]=u.[ci]) WHEN 0 THEN CONVERT(bit,0) ELSE CONVERT(bit,1) END)=1)) ORDER BY [dir] DESC,[pro] DESC,[cob] DESC");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);

        DataTable tabla_sat_usuario = db1.ExecuteDataSet(cmd).Tables[0];
        //Migración de [sat_bancos] a [banco]:
        foreach (DataRow fila in tabla_sat_usuario.Rows)
        {
            m_usuario.num_encontrato += 1;
            string sat_ci = Formato(fila["ci"].ToString());
            string sat_nombre = Formato(fila["nombre"].ToString());
            string sat_paterno = Formato(fila["paterno"].ToString());
            string sat_materno = Formato(fila["materno"].ToString());
            string sat_clave = Formato(fila["clave"].ToString());
            string sat_id = Formato(fila["id"].ToString());
            string sat_estado = Formato(fila["estado"].ToString());
            string sat_grupo = Formato(fila["grupo"].ToString());
            bool sat_adm = (bool)fila["adm"];
            bool sat_caj = (bool)fila["caj"];
            bool sat_pro = (bool)fila["pro"];
            bool sat_cob = (bool)fila["cob"];
            bool sat_dir = (bool)fila["dir"];
            cmd = db1.GetSqlStringCommand("SELECT COUNT([id_usuario]) FROM [usuario] WHERE [ci]=@ci");
            db1.AddInParameter(cmd, "ci", DbType.String, sat_ci);
            if ((int)db1.ExecuteScalar(cmd) == 0)
            {
                bool activo = true; if (sat_estado == "BA") activo = false;
                terrasur.usuario usrObj = new terrasur.usuario(sat_nombre, sat_paterno, sat_materno, sat_ci, "", sat_ci, sat_clave, activo);
                if (usrObj.Insertar(Context_id_usuario) == true)
                {
                    m_usuario.num_migrado += 1;
                    if (sat_dir == true)
                    {
                        m_grupo.num_encontrato += 1;
                        if (terrasur.usuario_rol.InsertarEliminar(true, usrObj.id_usuario, new terrasur.rol(ConfigurationManager.AppSettings["director_codigo"]).id_rol) == false)
                            m_usuario.NewMens("Error", "rol del director", "ci: " + sat_ci + " ; nombre: " + sat_nombre + " ; paterno: " + sat_paterno + " ; materno: " + sat_materno);
                        try
                        {
                            cmd = db1.GetSqlStringCommand("SELECT COUNT([id_grupoventa]) FROM [grupo_venta] WHERE [nombre]=@nombre");
                            db1.AddInParameter(cmd, "nombre", DbType.String, sat_grupo);
                            if ((int)db1.ExecuteScalar(cmd) == 0)
                            {
                                cmd = db1.GetSqlStringCommand("INSERT INTO [grupo_venta]([id_usuario],[nombre],[activo]) VALUES(@id_usuario,@nombre,@activo)");
                                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, usrObj.id_usuario);
                                db1.AddInParameter(cmd, "nombre", DbType.String, sat_grupo);
                                db1.AddInParameter(cmd, "activo", DbType.Boolean, true);
                                db1.ExecuteNonQuery(cmd);
                                m_grupo.num_migrado += 1;
                            }
                            else
                            {
                                m_grupo.num_repetido += 1;
                                m_grupo.NewMens("Repetido", "", "grupo: " + sat_grupo);
                            }
                        }
                        catch (Exception ex)
                        {
                            m_grupo.num_error += 1;
                            m_grupo.NewMens("Error", "", "grupo: " + sat_grupo + " ; Mensaje de error: " + ex.Message);
                        }
                    }
                    if (sat_pro == true)
                    {
                        if (terrasur.usuario_rol.InsertarEliminar(true, usrObj.id_usuario, new terrasur.rol(ConfigurationManager.AppSettings["promotor_codigo"]).id_rol) == false)
                            m_usuario.NewMens("Error", "rol del promotor", "ci: " + sat_ci + " ; nombre: " + sat_nombre + " ; paterno: " + sat_paterno + " ; materno: " + sat_materno);
                        try
                        {
                            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT TOP 1 [id_grupoventa] FROM [grupo_venta] WHERE [nombre]=@nombre),0)");
                            db1.AddInParameter(cmd, "nombre", DbType.String, sat_grupo);
                            int id_grupoventa = (int)db1.ExecuteScalar(cmd);
                            if (id_grupoventa > 0)
                            {
                                cmd = db1.GetSqlStringCommand("INSERT INTO [grupo_promotor]([id_grupoventa],[id_usuario],[fecha],[activo]) VALUES(@id_grupoventa,@id_usuario,GETDATE(),1)");
                                db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, id_grupoventa);
                                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, usrObj.id_usuario);
                                db1.ExecuteNonQuery(cmd);
                            }
                            else if (sat_grupo != "0")
                                m_usuario.NewMens("Error", "Grupo de ventas inexistente", "grupo: " + sat_grupo);
                        }
                        catch (Exception ex)
                        {
                            m_usuario.NewMens("Error", "Asignación del promotor al grupo", "grupo: " + sat_grupo + " ; Promotor: " + sat_nombre + " " + sat_paterno + " " + sat_materno + " ; Mensaje de error: " + ex.Message);
                        }
                    }
                    if (sat_cob == true)
                    {
                        if (terrasur.usuario_rol.InsertarEliminar(true, usrObj.id_usuario, new terrasur.rol(ConfigurationManager.AppSettings["cobrador_codigo"]).id_rol) == false)
                            m_usuario.NewMens("Error", "rol del cobrador", "ci: " + sat_ci + " ; nombre: " + sat_nombre + " ; paterno: " + sat_paterno + " ; materno: " + sat_materno);
                    }
                    if (sat_caj == true)
                    {
                        if (terrasur.usuario_rol.InsertarEliminar(true, usrObj.id_usuario, new terrasur.rol(ConfigurationManager.AppSettings["cajero_codigo"]).id_rol) == false)
                            m_usuario.NewMens("Error", "rol del cajero", "ci: " + sat_ci + " ; nombre: " + sat_nombre + " ; paterno: " + sat_paterno + " ; materno: " + sat_materno);
                    }
                    if (sat_adm == true)
                    {
                        if (terrasur.usuario_rol.InsertarEliminar(true, usrObj.id_usuario, new terrasur.rol(ConfigurationManager.AppSettings["administrativo_codigo"]).id_rol) == false)
                            m_usuario.NewMens("Error", "rol del administrativo", "ci: " + sat_ci + " ; nombre: " + sat_nombre + " ; paterno: " + sat_paterno + " ; materno: " + sat_materno);
                    }
                }
                else
                {
                    m_usuario.num_error += 1;
                    m_usuario.NewMens("Error", "", "ci: " + sat_ci + " ; nombre: " + sat_nombre + " ; paterno: " + sat_paterno + " ; materno: " + sat_materno);
                }
            }
            else
            {
                m_usuario.num_repetido += 1;
                m_usuario.NewMens("Repetido", "", "ci: " + sat_ci + " ; nombre: " + sat_nombre + " ; paterno: " + sat_paterno + " ; materno: " + sat_materno);
            }
        }
        return m_usuario.Datos() + m_grupo.Datos();
    }

    public static string MigrarCicloComercial(int Context_id_usuario)
    {
        migracionResumen m_ciclo = new migracionResumen("Ciclos comerciales", true);
        //Datos a migrar:
        DbCommand cmd = db1.GetSqlStringCommand("SELECT [cicloini],[ciclofin] FROM [sat_par_ciclocom] ORDER BY [ciclofin] ASC");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_sat_ciclo_comercial = db1.ExecuteDataSet(cmd).Tables[0];
        //Migración de [sat_par_ciclocom] a [ciclo_comercial]:
        foreach (DataRow fila in tabla_sat_ciclo_comercial.Rows)
        {
            m_ciclo.num_encontrato += 1;
            DateTime sat_cicloini = (DateTime)fila["cicloini"];
            DateTime sat_ciclofin = (DateTime)fila["ciclofin"];
            try
            {
                cmd = db1.GetSqlStringCommand("INSERT INTO [ciclo_comercial]([id_usuario],[inicio],[fin]) VALUES(@id_usuario,@inicio,@fin)");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                db1.AddInParameter(cmd, "inicio", DbType.DateTime, sat_cicloini);
                db1.AddInParameter(cmd, "fin", DbType.DateTime, sat_ciclofin);
                db1.ExecuteNonQuery(cmd);
                m_ciclo.num_migrado += 1;
            }
            catch (Exception ex)
            {
                m_ciclo.num_error += 1;
                m_ciclo.NewMens("Error", "", "cicloini: " + sat_cicloini.ToShortDateString() + " ; ciclofin: " + sat_ciclofin.ToShortDateString() + " ; " + ex.Message);
            }
        }
        return m_ciclo.Datos();
    }

    public static string MigrarContrato(int Context_id_usuario)
    {
        migracionResumen m_contrato = new migracionResumen("Contrato ([contrato])", true);
        migracionResumen m_cont_venta = new migracionResumen("Contrato de venta ([contrato_venta])");
        migracionResumen m_estado_lote = new migracionResumen("Estado del lote ([estado_lote])");
        migracionResumen m_neg_con = new migracionResumen("Negocio del contrato ([negocio_contrato])");
        migracionResumen m_asig_prom = new migracionResumen("Agisnación del promotor ([asignacion_promotor])");
        migracionResumen m_ben_fact = new migracionResumen("Beneficiario de la factura ([beneficiario_factura])");
        migracionResumen m_cli_titu = new migracionResumen("Primer titular del contrato ([cliente_contrato])");
        migracionResumen m_cli_adi = new migracionResumen("Titular adicional del contrato ([cliente_contrato])");

        //Datos a migrar:
        //DbCommand cmd = db1.GetSqlStringCommand("SELECT dc.[ncontrato],dc.[fechaing],(CASE dc.[concre] WHEN 'CON' THEN CONVERT(bit,1) ELSE CONVERT(bit,0) END) as 'concre',dc.[valorsitio],dc.[valorsitioorig],(CASE WHEN [valorsitioorig]>[valorsitio] AND [valorsitioorig]>0 THEN ((([valorsitioorig]-[valorsitio])/[valorsitioorig])*100) ELSE 0 END) as 'dctopromo',(CASE WHEN (SELECT COUNT([valorcuota]) FROM [sat_iniciales] WHERE [ncontrato]=dc.[ncontrato])>0 THEN (SELECT TOP 1 [valorcuota] FROM [sat_iniciales] WHERE [ncontrato]=dc.[ncontrato]) WHEN (SELECT COUNT([valorcuota]) FROM [sat_inihist] WHERE [ncontrato]=dc.[ncontrato])>0 THEN (SELECT TOP 1 [valorcuota] FROM [sat_inihist] WHERE [ncontrato]=dc.[ncontrato]) ELSE dc.[inicialh] END) as 'inicialh',(CASE WHEN (SELECT COUNT([ncuotas]) FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] AND [n_repro]=0)>0 THEN (SELECT TOP 1 [ncuotas] FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] AND [n_repro]=0) ELSE dc.[ncuotas] END) as 'ncuotas',(CASE WHEN (SELECT COUNT([intan]) FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] AND [n_repro]=0)>0 THEN (SELECT TOP 1 [intan] FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] AND [n_repro]=0) ELSE dc.[ncuotas] END) as 'intan',(CASE WHEN (SELECT COUNT([cmes]) FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] AND [n_repro]=0)>0 THEN (SELECT TOP 1 [cmes] FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] AND [n_repro]=0) ELSE dc.[ncuotas] END) as 'cmes',(CASE WHEN (SELECT COUNT([fecha]) FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] AND [n_repro]=0)>0 THEN (SELECT TOP 1 [fecha] FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] AND [n_repro]=0) ELSE dc.[ncuotas] END) as 'fecha',ISNULL((SELECT TOP 1 [detalle] FROM [sat_observa] WHERE [ncontrato]=dc.[ncontrato]),'') as 'observa',dc.[cod_pro],dc.[cod_cli],dc.[negocio],dc.[manzano],(CASE dc.[codigolote] WHEN '88888' THEN (SELECT TOP 1 [codigolote] FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] AND [n_repro]=0) ELSE dc.[codigolote] END) as 'codigolote',dc.[sup],dc.[pr_m2],dc.[co_m2],dc.[costolote],ISNULL((SELECT TOP 1 LTRIM(RTRIM([nombre])) + ' ' + LTRIM(RTRIM([paterno])) FROM [sat_clientes] WHERE [cod_cli]=dc.[cod_cli]),'') as 'factura_nombre',ISNULL((SELECT TOP 1 [ruc] FROM [sat_clientes] WHERE [cod_cli]=dc.[cod_cli]),0) as 'factura_nit' FROM [sat_datoscred] as dc WHERE [valorsitio]>0 ORDER BY [ncontrato]");
        //DbCommand cmd = db1.GetSqlStringCommand("SELECT dc.[ncontrato],dc.[fechaing],(CASE dc.[concre] WHEN 'CON' THEN CONVERT(bit,1) ELSE CONVERT(bit,0) END) as 'concre',dc.[valorsitio],dc.[valorsitioorig],(CASE WHEN [valorsitioorig]>[valorsitio] AND [valorsitioorig]>0 THEN ((([valorsitioorig]-[valorsitio])/[valorsitioorig])*100) ELSE 0 END) as 'dctopromo',(CASE WHEN (SELECT COUNT([valorcuota]) FROM [sat_iniciales] WHERE [ncontrato]=dc.[ncontrato])>0 THEN (SELECT TOP 1 [valorcuota] FROM [sat_iniciales] WHERE [ncontrato]=dc.[ncontrato]) WHEN (SELECT COUNT([valorcuota]) FROM [sat_inihist] WHERE [ncontrato]=dc.[ncontrato])>0 THEN (SELECT TOP 1 [valorcuota] FROM [sat_inihist] WHERE [ncontrato]=dc.[ncontrato]) ELSE dc.[inicialh] END) as 'inicialh',(CASE WHEN (SELECT COUNT([ncuotas]) FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] AND [n_repro]=0)>0 THEN (SELECT TOP 1 [ncuotas] FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] AND [n_repro]=0) ELSE dc.[ncuotas] END) as 'ncuotas',(CASE WHEN (SELECT COUNT([intan]) FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] AND [n_repro]=0)>0 THEN (SELECT TOP 1 [intan] FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] AND [n_repro]=0) ELSE dc.[intan] END) as 'intan',(CASE WHEN (SELECT COUNT([cmes]) FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] AND [n_repro]=0)>0 THEN (SELECT TOP 1 [cmes] FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] AND [n_repro]=0) ELSE dc.[cmes] END) as 'cmes',(CASE WHEN (SELECT COUNT([fecha]) FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] AND [n_repro]=0)>0 THEN (SELECT TOP 1 [fecha] FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] AND [n_repro]=0) ELSE dc.[fecha] END) as 'fecha',ISNULL((SELECT TOP 1 [detalle] FROM [sat_observa] WHERE [ncontrato]=dc.[ncontrato]),'') as 'observa',dc.[cod_pro],dc.[cod_cli],dc.[negocio],dc.[manzano],(CASE dc.[codigolote] WHEN '88888' THEN (SELECT TOP 1 [codigolote] FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] AND [negocio]=(CASE dc.[ncontrato] WHEN 6027 THEN 100 ELSE dc.[negocio] END) ORDER BY [n_repro]) ELSE dc.[codigolote] END) as 'codigolote',dc.[sup],dc.[pr_m2],dc.[co_m2],dc.[costolote],ISNULL((SELECT TOP 1 LTRIM(RTRIM([nombre])) + ' ' + LTRIM(RTRIM([paterno])) FROM [sat_clientes] WHERE [cod_cli]=dc.[cod_cli]),'') as 'factura_nombre',ISNULL((SELECT TOP 1 [ruc] FROM [sat_clientes] WHERE [cod_cli]=dc.[cod_cli]),0) as 'factura_nit' FROM [sat_datoscred] as dc WHERE [valorsitio]>0 ORDER BY [ncontrato]");
        DbCommand cmd = db1.GetSqlStringCommand("SELECT dc.[ncontrato],dc.[fechaing],(CASE dc.[concre] WHEN 'CON' THEN CONVERT(bit,1) ELSE CONVERT(bit,0) END) as 'concre',dc.[valorsitio],dc.[valorsitioorig],(CASE WHEN [valorsitioorig]>[valorsitio] AND [valorsitioorig]>0 THEN ((([valorsitioorig]-[valorsitio])/[valorsitioorig])*100) ELSE 0 END) as 'dctopromo',(CASE WHEN (SELECT COUNT([valorcuota]) FROM [sat_iniciales] WHERE [ncontrato]=dc.[ncontrato])>0 THEN (SELECT TOP 1 [valorcuota] FROM [sat_iniciales] WHERE [ncontrato]=dc.[ncontrato]) WHEN (SELECT COUNT([valorcuota]) FROM [sat_inihist] WHERE [ncontrato]=dc.[ncontrato])>0 THEN (SELECT TOP 1 [valorcuota] FROM [sat_inihist] WHERE [ncontrato]=dc.[ncontrato]) ELSE dc.[inicialh] END) as 'inicialh',(CASE WHEN (SELECT COUNT([ncuotas]) FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato])>0 THEN (SELECT TOP 1 [ncuotas] FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] ORDER BY [n_repro]) ELSE dc.[ncuotas] END) as 'ncuotas',(CASE WHEN (SELECT COUNT([intan]) FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato])>0 THEN (SELECT TOP 1 [intan] FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] ORDER BY [n_repro]) ELSE dc.[intan] END) as 'intan',(CASE WHEN (SELECT COUNT([cmes]) FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato])>0 THEN (SELECT TOP 1 [cmes] FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] ORDER BY [n_repro]) ELSE dc.[cmes] END) as 'cmes',(CASE WHEN (SELECT COUNT([fecha]) FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato])>0 THEN (SELECT TOP 1 [fecha] FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] ORDER BY [n_repro]) ELSE dc.[fecha] END) as 'fecha',ISNULL((SELECT TOP 1 [detalle] FROM [sat_observa] WHERE [ncontrato]=dc.[ncontrato]),'') as 'observa',dc.[cod_pro],dc.[cod_cli],dc.[negocio],dc.[manzano],(CASE dc.[codigolote] WHEN '88888' THEN (SELECT TOP 1 [codigolote] FROM [sat_datoshist] WHERE [ncontrato]=dc.[ncontrato] AND [negocio]=(CASE dc.[ncontrato] WHEN 6027 THEN 100 ELSE dc.[negocio] END) ORDER BY [n_repro]) ELSE dc.[codigolote] END) as 'codigolote',dc.[sup],dc.[pr_m2],dc.[co_m2],dc.[costolote],ISNULL((SELECT TOP 1 LTRIM(RTRIM([nombre])) + ' ' + LTRIM(RTRIM([paterno])) FROM [sat_clientes] WHERE [cod_cli]=dc.[cod_cli]),'') as 'factura_nombre',ISNULL((SELECT TOP 1 [ruc] FROM [sat_clientes] WHERE [cod_cli]=dc.[cod_cli]),0) as 'factura_nit' FROM [sat_datoscred] as dc WHERE [valorsitio]>0 ORDER BY [ncontrato]");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_sat_datoscred = db1.ExecuteDataSet(cmd).Tables[0];
        //Parámetros generales necesarios
        cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_moneda] FROM [moneda] WHERE [codigo]='$us'),0)");
        int id_moneda = (int)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [valor] FROM [parametro] WHERE [nombre]='tasa_mora'),0.00000)");
        decimal interes_penal = (decimal)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT [id_estado] FROM [estado] WHERE [codigo]='pre'");
        int id_estado_preasignado = (int)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT TOP 1 [id_grupoventa] FROM [grupo_venta] WHERE [nombre]='10'),0)");
        int id_grupoventa_vendedores_inactivos = (int)db1.ExecuteScalar(cmd);

        //Migración de [sat_datoscred] y [sat_observa] a [contrato]:
        foreach (DataRow fila in tabla_sat_datoscred.Rows)
        {
            m_contrato.num_encontrato += 1;
            int id_contrato = 0;

            string ncontrato = Formato(fila["ncontrato"].ToString());
            DateTime fechaing = (DateTime)fila["fechaing"];
            bool concre = (bool)fila["concre"];
            decimal valorsitio = (decimal)fila["valorsitio"];
            decimal valorsitioorig = (decimal)fila["valorsitioorig"];
            decimal dctopromo = (decimal)fila["dctopromo"];
            decimal inicialh = (decimal)fila["inicialh"];
            string ncuotas = Formato(fila["ncuotas"].ToString());
            decimal intan = (decimal)fila["intan"];
            decimal cmes = (decimal)fila["cmes"];
            DateTime fecha = (DateTime)fila["fecha"];
            if (fecha < DateTime.Parse("01/01/1995")) fecha = fechaing;
            string observa = Formato(fila["observa"].ToString());
            string cod_pro = Formato(fila["cod_pro"].ToString());
            string cod_cli = Formato(fila["cod_cli"].ToString());
            string negocio = Formato(fila["negocio"].ToString());
            string manzano = Formato(fila["manzano"].ToString());
            string codigolote = Formato(fila["codigolote"].ToString());
            decimal sup = (decimal)fila["sup"];
            decimal pr_m2 = (decimal)fila["pr_m2"];
            decimal co_m2 = (decimal)fila["co_m2"];
            decimal costolote = (decimal)fila["costolote"];
            string factura_nombre = Formato(fila["factura_nombre"].ToString());
            string factura_nit = Formato(fila["factura_nit"].ToString());


            cmd = db1.GetSqlStringCommand("SELECT COUNT([id_contrato]) FROM [contrato] WHERE [numero]=@numero");
            db1.AddInParameter(cmd, "numero", DbType.String, ncontrato);
            if ((int)db1.ExecuteScalar(cmd) == 0)
            {
                try
                {
                    //Se registra en [contrato]
                    cmd = db1.GetSqlStringCommand("INSERT INTO [contrato]([id_moneda],[id_usuario],[numero],[fecha],[contado],[preferencial],[precio],[descuento_porcentaje],[descuento_efectivo],[precio_final],[cuota_inicial],[num_cuotas],[seguro],[mantenimiento_sus],[interes_corriente],[interes_penal],[cuota_base],[fecha_inicio_plan],[observacion]) VALUES(@id_moneda,@id_usuario,@numero,@fecha,@contado,@preferencial,@precio,@descuento_porcentaje,@descuento_efectivo,@precio_final,@cuota_inicial,@num_cuotas,@seguro,@mantenimiento_sus,@interes_corriente,@interes_penal,@cuota_base,@fecha_inicio_plan,@observacion)");
                    db1.AddInParameter(cmd, "id_moneda", DbType.Int32, id_moneda);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                    db1.AddInParameter(cmd, "numero", DbType.String, ncontrato);
                    db1.AddInParameter(cmd, "fecha", DbType.DateTime, fechaing);
                    db1.AddInParameter(cmd, "contado", DbType.Boolean, concre);
                    db1.AddInParameter(cmd, "preferencial", DbType.Boolean, false);

                    db1.AddInParameter(cmd, "precio", DbType.Decimal, valorsitioorig);
                    db1.AddInParameter(cmd, "descuento_porcentaje", DbType.Decimal, dctopromo);
                    db1.AddInParameter(cmd, "descuento_efectivo", DbType.Decimal, 0);
                    db1.AddInParameter(cmd, "precio_final", DbType.Decimal, valorsitio);

                    db1.AddInParameter(cmd, "cuota_inicial", DbType.Decimal, inicialh);
                    db1.AddInParameter(cmd, "num_cuotas", DbType.Int32, int.Parse(ncuotas));
                    db1.AddInParameter(cmd, "seguro", DbType.Decimal, 0);
                    db1.AddInParameter(cmd, "mantenimiento_sus", DbType.Decimal, 0);
                    db1.AddInParameter(cmd, "interes_corriente", DbType.Decimal, intan);

                    db1.AddInParameter(cmd, "interes_penal", DbType.Decimal, interes_penal);
                    db1.AddInParameter(cmd, "cuota_base", DbType.Decimal, cmes);
                    db1.AddInParameter(cmd, "fecha_inicio_plan", DbType.DateTime, fecha);
                    db1.AddInParameter(cmd, "observacion", DbType.String, observa);
                    db1.ExecuteNonQuery(cmd);

                    m_contrato.num_migrado += 1;
                    //Se obtiene [id_contrato]
                    cmd = db1.GetSqlStringCommand("SELECT IDENT_CURRENT('contrato')");
                    id_contrato = int.Parse(db1.ExecuteScalar(cmd).ToString());
                }
                catch (Exception ex)
                {
                    m_contrato.num_error += 1;
                    m_contrato.NewMens("Error", "insert", "ncontrato: " + ncontrato + " ; Mensaje de error: " + ex.Message);
                }
            }
            else
            {
                m_contrato.num_repetido += 1;
                m_contrato.NewMens("Repetido", "", "ncontrato: " + ncontrato);
            }




            if (id_contrato > 0)
            {
                //Se obtienen los datos necesarios
                //Se obtiene [id_lote]

                cmd = db1.GetSqlStringCommand("SELECT [dbo].[migracion_IdLote](@negocio,@manzano,@codigolote)");
                db1.AddInParameter(cmd, "negocio", DbType.String, negocio);
                db1.AddInParameter(cmd, "manzano", DbType.String, manzano);
                db1.AddInParameter(cmd, "codigolote", DbType.String, codigolote);
                int id_lote = (int)db1.ExecuteScalar(cmd);
                //Se obtiene el precio y el costo del lote (según inventario)
                decimal costo_m2_sus = 0;
                decimal precio_m2_sus = 0;
                cmd = db1.GetSqlStringCommand("SELECT [costo_m2_sus],[precio_m2_sus] FROM [lote] WHERE [id_lote]=@id_lote");
                db1.AddInParameter(cmd, "id_lote", DbType.Int32, id_lote);
                DataTable tabla_precio_costo_lote = db1.ExecuteDataSet(cmd).Tables[0];
                if (tabla_precio_costo_lote.Rows.Count > 0)
                {
                    costo_m2_sus = (decimal)tabla_precio_costo_lote.Rows[0]["costo_m2_sus"];
                    precio_m2_sus = (decimal)tabla_precio_costo_lote.Rows[0]["precio_m2_sus"];
                }

                //Se obtiene [id_negociolote] y [id_negocio]
                cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT TOP 1 [id_negociolote] FROM [negocio_lote] WHERE [id_lote]=@id_lote ORDER BY [fecha] DESC),0)");
                db1.AddInParameter(cmd, "id_lote", DbType.Int32, id_lote);
                int id_negociolote = (int)db1.ExecuteScalar(cmd);
                cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_negocio] FROM [negocio_lote] WHERE [id_negociolote]=@id_negociolote),0)");
                db1.AddInParameter(cmd, "id_negociolote", DbType.Int32, id_negociolote);
                int id_negocio = (int)db1.ExecuteScalar(cmd);


                ////Se realiza la asignación del promotor al contrato
                //bool desde_excel = false; string excel_promotor_ci = ""; decimal excel_comision_total = 0;
                //cmd = db1.GetSqlStringCommand("SELECT [promotor_ci],[comision_total] FROM [marketing_comision] WHERE [ncontrato]=@ncontrato");
                //db1.AddInParameter(cmd, "ncontrato", DbType.String, ncontrato);
                //DataTable tabla_promotor_excel = db1.ExecuteDataSet(cmd).Tables[0];
                //if (tabla_promotor_excel.Rows.Count > 0)
                //{
                //    desde_excel = true;
                //    excel_promotor_ci = tabla_promotor_excel.Rows[0]["promotor_ci"].ToString();
                //    excel_comision_total = (decimal)tabla_promotor_excel.Rows[0]["comision_total"];
                //}

                //try
                //{
                //    cmd = db1.GetStoredProcCommand("migracion_PromotorAsignacion");
                //    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                //    //db1.AddInParameter(cmd, "ncontrato", DbType.String, ncontrato);
                //    if (desde_excel == true) db1.AddInParameter(cmd, "cod_pro", DbType.String, excel_promotor_ci);
                //    else db1.AddInParameter(cmd, "cod_pro", DbType.String, cod_pro);
                //    db1.AddInParameter(cmd, "fecha", DbType.DateTime, fechaing);
                //    db1.AddInParameter(cmd, "precio_final", DbType.Decimal, valorsitio);

                //    db1.AddInParameter(cmd, "desde_excel", DbType.Boolean, desde_excel);
                //    db1.AddInParameter(cmd, "comision_total", DbType.Decimal, excel_comision_total);

                //    db1.AddInParameter(cmd, "id_grupoventa_inactivos", DbType.Int32, id_grupoventa_vendedores_inactivos);
                //    db1.AddInParameter(cmd, "context_id_usuario", DbType.Int32, Context_id_usuario);

                //    if ((int)db1.ExecuteScalar(cmd) == 1)
                //    {
                //        m_asig_prom.num_encontrato += 1;
                //        m_asig_prom.num_migrado += 1;
                //    }
                //}
                //catch (Exception ex)
                //{
                //    m_asig_prom.num_encontrato += 1;
                //    m_asig_prom.num_error += 1;
                //    m_asig_prom.NewMens("Error", "insert", "ncontrato: " + ncontrato + " ; cod_pro: " + cod_pro + " ; id_contrato: " + id_contrato  + " ; Menssaje de error: " + ex.Message);
                //}

                //Se obtiene [id_promotor] (Promotor al cual se asigna el contrato)
                cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT TOP 1 [id_usuario] FROM [usuario] WHERE [ci]=@ci),0)");
                db1.AddInParameter(cmd, "ci", DbType.String, cod_pro);
                int id_promotor = (int)db1.ExecuteScalar(cmd);
                cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT TOP 1 [id_grupopromotor] FROM [grupo_promotor] WHERE [id_usuario]=@id_usuario ORDER BY [fecha] DESC),0)");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, id_promotor);
                int id_grupopromotor = (int)db1.ExecuteScalar(cmd);
                if (id_promotor > 0 && id_grupopromotor == 0)
                {
                    try
                    {
                        cmd = db1.GetSqlStringCommand("INSERT INTO [grupo_promotor]([id_grupoventa],[id_usuario],[fecha],[activo]) VALUES(@id_grupoventa,@id_usuario,@fecha,@activo)");
                        db1.AddInParameter(cmd, "id_grupoventa", DbType.Int32, id_grupoventa_vendedores_inactivos);
                        db1.AddInParameter(cmd, "id_usuario", DbType.Int32, id_promotor);
                        db1.AddInParameter(cmd, "fecha", DbType.DateTime, fechaing);
                        db1.AddInParameter(cmd, "activo", DbType.Boolean, true);
                        db1.ExecuteNonQuery(cmd);
                        cmd = db1.GetSqlStringCommand("SELECT IDENT_CURRENT('grupo_promotor')");
                        id_grupopromotor = int.Parse(db1.ExecuteScalar(cmd).ToString());
                    }
                    catch { }
                }



                //Se obtiene [id_cliente] (Primer Titular)
                cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT TOP 1 [id_cliente] FROM [cliente] WHERE [ci]=@ci),0)");
                db1.AddInParameter(cmd, "ci", DbType.String, cod_cli);
                int id_cliente_titular = (int)db1.ExecuteScalar(cmd);

                //Se registra en [contrato_venta]
                m_cont_venta.num_encontrato += 1;
                if (id_lote > 0)
                {
                    try
                    {
                        cmd = db1.GetSqlStringCommand("INSERT INTO [contrato_venta]([id_contrato],[id_lote],[superficie_m2],[precio_m2_sus],[costo_m2_sus]) VALUES (@id_contrato,@id_lote,@superficie_m2,@precio_m2_sus,@costo_m2_sus)");
                        db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                        db1.AddInParameter(cmd, "id_lote", DbType.Int32, id_lote);
                        db1.AddInParameter(cmd, "superficie_m2", DbType.Decimal, sup);
                        db1.AddInParameter(cmd, "precio_m2_sus", DbType.Decimal, pr_m2);
                        db1.AddInParameter(cmd, "costo_m2_sus", DbType.Decimal, costo_m2_sus); //co_m2);
                        db1.ExecuteNonQuery(cmd);
                        m_cont_venta.num_migrado += 1;
                    }
                    catch (Exception ex)
                    {
                        m_cont_venta.num_error += 1;
                        m_cont_venta.NewMens("Error", "insert", "ncontrato: " + ncontrato + " ; negocio: " + negocio + " ; manzano: " + manzano + " ; codigolote: " + codigolote + " ; id_contrato: " + id_contrato + " ; id_lote: " + id_lote + " ; Mensaje de error: " + ex.Message);
                        //break;
                    }
                }
                else
                {
                    m_cont_venta.num_error += 1;
                    m_cont_venta.NewMens("Error", "[lote] inexistente", "ncontrato: " + ncontrato + " ; negocio: " + negocio + " ; manzano: " + manzano + " ; codigolote: " + codigolote + " ; id_contrato: " + id_contrato + " ; id_lote: " + id_lote);
                }

                //Se registra en [estado_lote]
                m_estado_lote.num_encontrato += 1;
                if (id_lote > 0)
                {
                    try
                    {
                        cmd = db1.GetSqlStringCommand("INSERT INTO [estado_lote]([id_estado],[id_lote],[id_contrato],[id_reversion],[id_usuario],[fecha],[observacion]) VALUES (@id_estado,@id_lote,@id_contrato,NULL,@id_usuario,@fecha,'')");
                        db1.AddInParameter(cmd, "id_estado", DbType.Int32, id_estado_preasignado);
                        db1.AddInParameter(cmd, "id_lote", DbType.Int32, id_lote);
                        db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                        db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                        db1.AddInParameter(cmd, "fecha", DbType.DateTime, fechaing);
                        db1.ExecuteNonQuery(cmd);
                        m_estado_lote.num_migrado += 1;
                    }
                    catch (Exception ex)
                    {
                        m_estado_lote.num_error += 1;
                        m_estado_lote.NewMens("Error", "insert", "ncontrato: " + ncontrato + " ; negocio: " + negocio + " ; manzano: " + manzano + " ; codigolote: " + codigolote + " ; id_contrato: " + id_contrato + " ; id_lote: " + id_lote + " ; Mensaje de error: " + ex.Message);
                        //break;
                    }
                }
                else
                {
                    m_estado_lote.num_error += 1;
                    m_estado_lote.NewMens("Error", "[lote] inexistente", "ncontrato: " + ncontrato + " ; negocio: " + negocio + " ; manzano: " + manzano + " ; codigolote: " + codigolote + " ; id_contrato: " + id_contrato + " ; id_lote: " + id_lote);
                }


                //Se registra en [negocio_contrato]
                m_neg_con.num_encontrato += 1;
                if (id_negociolote > 0)
                {
                    try
                    {
                        cmd = db1.GetSqlStringCommand("INSERT INTO [negocio_contrato]([id_negocio],[id_contrato],[id_usuario],[id_negociolote],[id_pago],[id_reversion],[fecha],[saldo_capital],[saldo_costo],[anulado]) VALUES(@id_negocio,@id_contrato,@id_usuario,@id_negociolote,NULL,NULL,@fecha,@saldo_capital,@saldo_costo,0)");
                        db1.AddInParameter(cmd, "id_negocio", DbType.Int32, id_negocio);
                        db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                        db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                        db1.AddInParameter(cmd, "id_negociolote", DbType.Int32, id_negociolote);
                        db1.AddInParameter(cmd, "fecha", DbType.DateTime, fechaing);
                        db1.AddInParameter(cmd, "saldo_capital", DbType.Decimal, valorsitio);
                        //if (costolote > 0) db1.AddInParameter(cmd, "saldo_costo", DbType.Decimal, costolote);
                        //else db1.AddInParameter(cmd, "saldo_costo", DbType.Decimal, sup * co_m2);
                        if ((sup * costo_m2_sus) > 0) db1.AddInParameter(cmd, "saldo_costo", DbType.Decimal, sup * costo_m2_sus);
                        else db1.AddInParameter(cmd, "saldo_costo", DbType.Decimal, costolote);
                        db1.ExecuteNonQuery(cmd);
                        m_neg_con.num_migrado += 1;
                    }
                    catch (Exception ex)
                    {
                        m_neg_con.num_error += 1;
                        m_neg_con.NewMens("Error", "insert", "ncontrato: " + ncontrato + " ; id_contrato: " + id_contrato + " ; id_lote: " + id_lote + " ; id_negociolote: " + id_negociolote + " ; Mensaje de error: " + ex.Message);
                        //break;
                    }
                }
                else
                {
                    m_neg_con.num_error += 1;
                    m_neg_con.NewMens("Error", "[negocio_lote] inexistente", "ncontrato: " + ncontrato + " ; id_contrato: " + id_contrato + " ; id_lote: " + id_lote + " ; id_negociolote: " + id_negociolote);
                }

                //Se registra en [asignacion_promotor]
                m_asig_prom.num_encontrato += 1;
                if (id_grupopromotor > 0)
                {
                    try
                    {
                        cmd = db1.GetSqlStringCommand("INSERT INTO [asignacion_promotor]([id_grupopromotor],[id_contrato],[id_usuario],[porcentaje],[comision_total],[fecha],[activo]) VALUES(@id_grupopromotor,@id_contrato,@id_usuario,@porcentaje,@comision_total,@fecha,1)");
                        db1.AddInParameter(cmd, "id_grupopromotor", DbType.Int32, id_grupopromotor);
                        db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                        db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                        db1.AddInParameter(cmd, "porcentaje", DbType.Decimal, 0);
                        db1.AddInParameter(cmd, "comision_total", DbType.Decimal, 0);
                        db1.AddInParameter(cmd, "fecha", DbType.DateTime, fechaing);
                        db1.ExecuteNonQuery(cmd);
                        m_asig_prom.num_migrado += 1;
                    }
                    catch (Exception ex)
                    {
                        m_asig_prom.num_error += 1;
                        m_asig_prom.NewMens("Error", "insert", "ncontrato: " + ncontrato + " ; cod_pro: " + cod_pro + " ; id_contrato: " + id_contrato + " ; id_grupopromotor: " + id_grupopromotor + " ; id_promotor: " + id_promotor + " ; Menssaje de error: " + ex.Message);
                        //break;
                    }
                }
                else
                {
                    m_asig_prom.num_error += 1;
                    m_asig_prom.NewMens("Error", "[grupo_promotor] inexistente", "ncontrato: " + ncontrato + " ; cod_pro: " + cod_pro + " ; id_contrato: " + id_contrato + " ; id_grupopromotor: " + id_grupopromotor + " ; id_promotor: " + id_promotor);
                }


                //Se registra en [beneficiario_factura]
                m_ben_fact.num_encontrato += 1;
                try
                {
                    cmd = db1.GetSqlStringCommand("INSERT INTO [beneficiario_factura]([id_contrato],[nombre],[nit]) VALUES (@id_contrato,@nombre,@nit)");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                    db1.AddInParameter(cmd, "nombre", DbType.String, factura_nombre);
                    db1.AddInParameter(cmd, "nit", DbType.String, factura_nit);
                    db1.ExecuteNonQuery(cmd);
                    m_ben_fact.num_migrado += 1;
                }
                catch (Exception ex)
                {
                    m_ben_fact.num_error += 1;
                    m_ben_fact.NewMens("Error", "insert", "ncontrato: " + ncontrato + " ; factura_nombre: " + factura_nombre + " ; factura_nit: " + factura_nit + " ; Menssaje de error: " + ex.Message);
                    //break;
                }

                //Se registra en [cliente_contrato] (Primer titular)
                m_cli_titu.num_encontrato += 1;
                if (id_cliente_titular > 0)
                {
                    try
                    {
                        cmd = db1.GetSqlStringCommand("INSERT INTO [cliente_contrato]([id_cliente],[id_contrato],[primer_titular]) VALUES (@id_cliente,@id_contrato,@primer_titular)");
                        db1.AddInParameter(cmd, "id_cliente", DbType.Int32, id_cliente_titular);
                        db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                        db1.AddInParameter(cmd, "primer_titular", DbType.Boolean, true);
                        db1.ExecuteNonQuery(cmd);
                        m_cli_titu.num_migrado += 1;
                    }
                    catch (Exception ex)
                    {
                        m_cli_titu.num_error += 1;
                        m_cli_titu.NewMens("Error", "insert", "ncontrato: " + ncontrato + " ; cod_cli: " + cod_cli + " ; id_contrato: " + id_contrato + " ; id_cliente_titular: " + id_cliente_titular + " ; Menssaje de error: " + ex.Message);
                        //break;
                    }
                }
                else
                {
                    m_cli_titu.num_error += 1;
                    m_cli_titu.NewMens("Error", "[cliente] inexistente", "ncontrato: " + ncontrato + " ; cod_cli: " + cod_cli + " ; id_contrato: " + id_contrato + " ; id_cliente_titular: " + id_cliente_titular);
                }


                //Se registra en [cliente_cotrato] (Clientes adicionales)
                cmd = db1.GetSqlStringCommand("SELECT DISTINCT [adcod_cli] FROM [sat_cli_adi] WHERE [ncontrato]=@ncontrato");
                db1.AddInParameter(cmd, "ncontrato", DbType.String, ncontrato);
                DataTable tabla_sat_cli_adi = db1.ExecuteDataSet(cmd).Tables[0];
                if (tabla_sat_cli_adi.Rows.Count > 0)
                {
                    foreach (DataRow fila_cli_adi in tabla_sat_cli_adi.Rows)
                    {
                        string adcod_cli = Formato(fila_cli_adi["adcod_cli"].ToString());
                        cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT TOP 1 [id_cliente] FROM [cliente] WHERE [ci]=@ci),0)");
                        db1.AddInParameter(cmd, "ci", DbType.String, adcod_cli);
                        int id_cliente_adicional = (int)db1.ExecuteScalar(cmd);

                        m_cli_adi.num_encontrato += 1;
                        if (id_cliente_adicional > 0)
                        {
                            cmd = db1.GetSqlStringCommand("SELECT COUNT([primer_titular]) FROM [cliente_contrato] WHERE [id_cliente]=@id_cliente AND [id_contrato]=@id_contrato");
                            db1.AddInParameter(cmd, "id_cliente", DbType.Int32, id_cliente_adicional);
                            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                            if ((int)db1.ExecuteScalar(cmd) == 0)
                            {
                                try
                                {
                                    cmd = db1.GetSqlStringCommand("INSERT INTO [cliente_contrato]([id_cliente],[id_contrato],[primer_titular]) VALUES (@id_cliente,@id_contrato,@primer_titular)");
                                    db1.AddInParameter(cmd, "id_cliente", DbType.Int32, id_cliente_adicional);
                                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                                    db1.AddInParameter(cmd, "primer_titular", DbType.Boolean, false);
                                    db1.ExecuteNonQuery(cmd);
                                    m_cli_adi.num_migrado += 1;
                                }
                                catch (Exception ex)
                                {
                                    m_cli_adi.num_error += 1;
                                    m_cli_adi.NewMens("Error", "insert", "ncontrato: " + ncontrato + " ; adcod_cli: " + adcod_cli + " ; id_contrato: " + id_contrato + " ; id_cliente_adicional: " + id_cliente_adicional + " ; Menssaje de error: " + ex.Message);
                                    //break;
                                }
                            }
                            else
                            {
                                m_cli_adi.num_repetido += 1;
                                //m_cli_adi.NewMens("Repetido", "cliente adicional", "ncontrato: " + ncontrato + " ; adcod_cli: " + adcod_cli + " ; id_contrato: " + id_contrato + " ; id_cliente_adicional: " + id_cliente_adicional);
                            }
                        }
                        else
                        {
                            m_cli_adi.num_error += 1;
                            m_cli_adi.NewMens("Error", "[cliente] inexistente", "ncontrato: " + ncontrato + " ; adcod_cli: " + adcod_cli + " ; id_contrato: " + id_contrato + " ; id_cliente_adicional: " + id_cliente_adicional);
                        }
                    }
                }
            }
        }

        return m_contrato.Datos() + m_cont_venta.Datos() + m_estado_lote.Datos() + m_neg_con.Datos() +
            m_asig_prom.Datos() + m_ben_fact.Datos() + m_cli_titu.Datos() + m_cli_adi.Datos();
    }

    public static string MigrarCuotaInicial(int Context_id_usuario)
    {
        migracionResumen m_inicial = new migracionResumen("Cuota inicial", true);
        migracionResumen m_transaccion = new migracionResumen("Transacción");
        migracionResumen m_forma_pago = new migracionResumen("Forma de pago");
        migracionResumen m_recibo = new migracionResumen("Recibo");
        migracionResumen m_pago = new migracionResumen("Pago");
        migracionResumen m_plan_pago = new migracionResumen("Plan de pagos");
        migracionResumen m_estado_lote = new migracionResumen("Estado del lote");

        //Datos a migrar:
        //DbCommand cmd = db1.GetSqlStringCommand("SELECT i.[ncontrato],i.[fechapago],i.[valorcuota] as 'i_valorcuota',i.[saldocapit],ISNULL((SELECT [n_trans] FROM [sat_facturac] WHERE [ncontrato]=i.[ncontrato] AND [tipo]='INI'),0) as 'n_trans',ISNULL((SELECT [valorcuota] FROM [sat_facturac] WHERE [ncontrato]=i.[ncontrato] AND [tipo]='INI'),0) as 'f_valorcuota',ISNULL((SELECT [amortiz] FROM [sat_facturac] WHERE [ncontrato]=i.[ncontrato] AND [tipo]='INI'),0) as 'amortiz',ISNULL((SELECT [tccompra] FROM [sat_facturac] WHERE [ncontrato]=i.[ncontrato] AND [tipo]='INI'),0) as 'tccompra',ISNULL((SELECT [montosus] FROM [sat_facturac] WHERE [ncontrato]=i.[ncontrato] AND [tipo]='INI'),0) as 'montosus',ISNULL((SELECT [montobs] FROM [sat_facturac] WHERE [ncontrato]=i.[ncontrato] AND [tipo]='INI'),0) as 'montobs',ISNULL((SELECT [montodpr] FROM [sat_facturac] WHERE [ncontrato]=i.[ncontrato] AND [tipo]='INI'),0) as 'montodpr',REPLACE(REPLACE(ISNULL((SELECT [tipodpr] FROM [sat_facturac] WHERE [ncontrato]=i.[ncontrato] AND [tipo]='INI'),''),'-',''),'+','') as 'tipodpr',ISNULL((SELECT [nrecibo] FROM [sat_facturac] WHERE [ncontrato]=i.[ncontrato] AND [tipo]='INI'),0) as 'nrecibo',ISNULL((SELECT [ncontrol] FROM [sat_facturac] WHERE [ncontrato]=i.[ncontrato] AND [tipo]='INI'),0) as 'ncontrol' FROM (SELECT *FROM [sat_iniciales] UNION SELECT *FROM [sat_inihist]) as i ORDER BY [ncontrato]");
        DbCommand cmd = db1.GetSqlStringCommand("SELECT i.[ncontrato],i.[fechapago],i.[valorcuota] as 'i_valorcuota',i.[saldocapit],ISNULL((SELECT [n_trans] FROM [sat_facturac] WHERE [ncontrato]=i.[ncontrato] AND [tipo]='INI'),0) as 'n_trans',ISNULL((SELECT [valorcuota] FROM [sat_facturac] WHERE [ncontrato]=i.[ncontrato] AND [tipo]='INI'),0) as 'f_valorcuota',ISNULL((SELECT [amortiz] FROM [sat_facturac] WHERE [ncontrato]=i.[ncontrato] AND [tipo]='INI'),0) as 'amortiz',ISNULL((SELECT [tccompra] FROM [sat_facturac] WHERE [ncontrato]=i.[ncontrato] AND [tipo]='INI'),0) as 'tccompra',ISNULL((SELECT [montosus] FROM [sat_facturac] WHERE [ncontrato]=i.[ncontrato] AND [tipo]='INI'),0) as 'montosus',ISNULL((SELECT [montobs] FROM [sat_facturac] WHERE [ncontrato]=i.[ncontrato] AND [tipo]='INI'),0) as 'montobs',ISNULL((SELECT [montodpr] FROM [sat_facturac] WHERE [ncontrato]=i.[ncontrato] AND [tipo]='INI'),0) as 'montodpr',REPLACE(REPLACE(ISNULL((SELECT [tipodpr] FROM [sat_facturac] WHERE [ncontrato]=i.[ncontrato] AND [tipo]='INI'),''),'-',''),'+','') as 'tipodpr',ISNULL((SELECT [nrecibo] FROM [sat_facturac] WHERE [ncontrato]=i.[ncontrato] AND [tipo]='INI'),0) as 'nrecibo',ISNULL((SELECT [ncontrol] FROM [sat_facturac] WHERE [ncontrato]=i.[ncontrato] AND [tipo]='INI'),0) as 'ncontrol',ISNULL((SELECT [ci] FROM [sat_facturac] WHERE [ncontrato]=i.[ncontrato] AND [tipo]='INI'),0) as 'ci' FROM (SELECT *FROM [sat_iniciales] UNION SELECT *FROM [sat_inihist]) as i ORDER BY [ncontrato]");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_sat_iniciales = db1.ExecuteDataSet(cmd).Tables[0];

        //Parámetros generales necesarios
        cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_moneda] FROM [moneda] WHERE [codigo]='$us'),0)");
        int id_moneda = (int)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT [id_estado] FROM [estado] WHERE [codigo]='ven'");
        int id_estado_vendido = (int)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT [id_tipopago] FROM [tipo_pago] WHERE [codigo]='ini'");
        int id_tipopago_inicial = (int)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_dpr] FROM [dpr] WHERE [codigo]='SIN'),0)");
        int id_dpr_sin = (int)db1.ExecuteScalar(cmd);

        foreach (DataRow fila in tabla_sat_iniciales.Rows)
        {
            m_inicial.num_encontrato += 1;
            string ncontrato = Formato(fila["ncontrato"].ToString());
            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_contrato] FROM [contrato] WHERE [numero]=@numero),0)");
            db1.AddInParameter(cmd, "numero", DbType.String, ncontrato);
            int id_contrato = (int)db1.ExecuteScalar(cmd);
            if (id_contrato > 0)
            {
                cmd = db1.GetSqlStringCommand("SELECT COUNT([id_pago]) FROM [pago] WHERE [id_contrato]=@id_contrato AND [id_tipopago]=@id_tipopago");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                db1.AddInParameter(cmd, "id_tipopago", DbType.Int32, id_tipopago_inicial);
                if ((int)db1.ExecuteScalar(cmd) == 0)
                {
                    DateTime fechapago = (DateTime)fila["fechapago"];
                    decimal i_valorcuota = (decimal)fila["i_valorcuota"];
                    decimal saldocapit = (decimal)fila["saldocapit"];
                    int n_trans = int.Parse(fila["n_trans"].ToString());
                    decimal f_valorcuota = (decimal)fila["f_valorcuota"];
                    decimal amortiz = (decimal)fila["amortiz"];
                    decimal tccompra = (decimal)fila["tccompra"];
                    decimal montosus = (decimal)fila["montosus"];
                    decimal montobs = (decimal)fila["montobs"];
                    decimal montodpr = (decimal)fila["montodpr"];
                    string tipodpr = Formato(fila["tipodpr"].ToString());
                    int nrecibo = int.Parse(fila["nrecibo"].ToString());
                    int ncontrol = int.Parse(fila["ncontrol"].ToString());




                    string ci = fila["ci"].ToString();
                    //Se reculera el id del usuario que hizo la transacción
                    int id_usuario_transaccion = 0;
                    if (ci != "0")
                    {
                        cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_usuario] FROM [usuario] WHERE [ci]=@ci),0)");
                        db1.AddInParameter(cmd, "ci", DbType.String, ci);
                        id_usuario_transaccion = (int)db1.ExecuteScalar(cmd);
                    }
                    if (id_usuario_transaccion == 0) id_usuario_transaccion = Context_id_usuario;




                    //Se recupera el [id_negocio] y [id_negociocontrato] vigentes del [contrato] 
                    int id_negociocontrato = 0, id_negocio = 0;
                    cmd = db1.GetSqlStringCommand("SELECT TOP 1 [id_negociocontrato],[id_negocio] FROM [negocio_contrato] WHERE [id_contrato]=@id_contrato ORDER BY [fecha] DESC,[id_negociocontrato] DESC");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                    DataTable tabla_negocio_contrato = db1.ExecuteDataSet(cmd).Tables[0];
                    if (tabla_negocio_contrato.Rows.Count > 0)
                    {
                        id_negociocontrato = (int)tabla_negocio_contrato.Rows[0]["id_negociocontrato"];
                        id_negocio = (int)tabla_negocio_contrato.Rows[0]["id_negocio"];
                    }

                    //Se obtiene los datos del primer plan de pagos del contrato
                    cmd = db1.GetSqlStringCommand("SELECT [num_cuotas],[interes_corriente],[interes_penal],[cuota_base],[fecha_inicio_plan] FROM [contrato] WHERE [id_contrato]=@id_contrato");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                    DataTable tabla_sat_contrato = db1.ExecuteDataSet(cmd).Tables[0];
                    int c_num_cuotas = (int)tabla_sat_contrato.Rows[0]["num_cuotas"];
                    decimal c_interes_corriente = (decimal)tabla_sat_contrato.Rows[0]["interes_corriente"];
                    decimal c_interes_penal = (decimal)tabla_sat_contrato.Rows[0]["interes_penal"];
                    decimal c_cuota_base = (decimal)tabla_sat_contrato.Rows[0]["cuota_base"];
                    DateTime c_fecha_inicio_plan = (DateTime)tabla_sat_contrato.Rows[0]["fecha_inicio_plan"];

                    //De ser necesario se obtiene el recibo de cobrador
                    int id_recibocobrador = 0;
                    if (ncontrol > 0)
                    {
                        cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT TOP 1 [id_recibocobrador] FROM [recibo_cobrador] WHERE [numero]=@numero),0)");
                        db1.AddInParameter(cmd, "numero", DbType.Int32, ncontrol);
                        id_recibocobrador = (int)db1.ExecuteScalar(cmd);
                    }

                    //Se registra la transacción
                    int id_transaccion = 0;
                    m_transaccion.num_encontrato += 1;
                    try
                    {
                        cmd = db1.GetSqlStringCommand("INSERT INTO [transaccion]([id_moneda],[id_usuario],[id_negocio],[id_negociocontrato],[id_recibocobrador],[fecha],[ntrans],[tipo_cambio],[monto],[comisionable],[anulado]) VALUES (@id_moneda,@id_usuario,@id_negocio,@id_negociocontrato,@id_recibocobrador,@fecha,@ntrans,@tipo_cambio,@monto,@comisionable,@anulado)");
                        db1.AddInParameter(cmd, "id_moneda", DbType.Int32, id_moneda);



                        //db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                        db1.AddInParameter(cmd, "id_usuario", DbType.Int32, id_usuario_transaccion);



                        db1.AddInParameter(cmd, "id_negocio", DbType.Int32, id_negocio);
                        db1.AddInParameter(cmd, "id_negociocontrato", DbType.Int32, id_negociocontrato);
                        if (id_recibocobrador > 0) db1.AddInParameter(cmd, "id_recibocobrador", DbType.Int32, id_recibocobrador);
                        else db1.AddInParameter(cmd, "id_recibocobrador", DbType.Int32, null);
                        db1.AddInParameter(cmd, "fecha", DbType.DateTime, fechapago);
                        db1.AddInParameter(cmd, "ntrans", DbType.Int32, n_trans);
                        db1.AddInParameter(cmd, "tipo_cambio", DbType.Decimal, tccompra);
                        db1.AddInParameter(cmd, "monto", DbType.Decimal, f_valorcuota);
                        if (montodpr > 0) db1.AddInParameter(cmd, "comisionable", DbType.Boolean, false);
                        else db1.AddInParameter(cmd, "comisionable", DbType.Boolean, true);
                        db1.AddInParameter(cmd, "anulado", DbType.Boolean, false);
                        db1.ExecuteNonQuery(cmd);

                        cmd = db1.GetSqlStringCommand("SELECT IDENT_CURRENT('transaccion')");
                        id_transaccion = Int32.Parse(db1.ExecuteScalar(cmd).ToString());

                        m_transaccion.num_migrado += 1;
                    }
                    catch (Exception ex)
                    {
                        m_transaccion.num_error += 1;
                        m_transaccion.NewMens("Error", "[transaccion]", "ncontrato: " + ncontrato + " ; id_contrato: " + id_contrato.ToString() + " ; Mensaje de error: " + ex.Message);
                    }
                    if (id_transaccion > 0)
                    {
                        //De ser necesario se obtiene el dpr_id_dpr
                        int dpr_id_dpr = 0;
                        if (montodpr > 0)
                        {
                            if (tipodpr == "")
                            {
                                cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT MAX([tipobono]) FROM [sat_bonos] WHERE [ncontrato]=@ncontrato AND [n_trans]=@n_trans),'')");
                                db1.AddInParameter(cmd, "ncontrato", DbType.Decimal, decimal.Parse(ncontrato));
                                db1.AddInParameter(cmd, "n_trans", DbType.Decimal, decimal.Parse(n_trans.ToString()));
                                tipodpr = db1.ExecuteScalar(cmd).ToString().Trim();
                            }
                            if (tipodpr != "")
                            {
                                cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_dpr] FROM [dpr] WHERE [codigo]=@codigo),0)");
                                db1.AddInParameter(cmd, "codigo", DbType.String, tipodpr);
                                dpr_id_dpr = (int)db1.ExecuteScalar(cmd);
                            }
                            else dpr_id_dpr = id_dpr_sin;
                        }

                        //Si se empleó un cheque para realizar la transacción se obtienen los datos utilizados
                        int cheque_id_banco = 0; string cheque_numero = ""; decimal cheque_sus = 0; decimal cheque_bs = 0;
                        cmd = db1.GetSqlStringCommand("SELECT [mon_chsu] as 'sus',[mon_chbs] as 'bs',(CASE [mon_chsu] WHEN 0 THEN [num_chbs] ELSE [num_chsu] END) as 'numero',(CASE [mon_chsu] WHEN 0 THEN [bco_chbs] ELSE [bco_chsu] END) as 'banco' FROM [sat_fact_chq] WHERE [ncontrato]=@ncontrato AND [n_trans]=@n_trans AND ([mon_chsu]>0 OR [mon_chbs]>0)");
                        db1.AddInParameter(cmd, "ncontrato", DbType.Decimal, decimal.Parse(ncontrato));
                        db1.AddInParameter(cmd, "n_trans", DbType.Decimal, decimal.Parse(n_trans.ToString()));
                        DataTable tabla_cheque = db1.ExecuteDataSet(cmd).Tables[0];
                        if (tabla_cheque.Rows.Count > 0)
                        {//sus,bs,numero,banco
                            cheque_sus = (decimal)tabla_cheque.Rows[0]["sus"];
                            cheque_bs = (decimal)tabla_cheque.Rows[0]["bs"];
                            cheque_numero = tabla_cheque.Rows[0]["numero"].ToString();
                            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_banco] FROM [banco] WHERE [codigo]=@codigo),0)");
                            db1.AddInParameter(cmd, "codigo", DbType.String, tabla_cheque.Rows[0]["banco"].ToString().Trim());
                            cheque_id_banco = (int)db1.ExecuteScalar(cmd);
                        }

                        //Se registra la forma de pago
                        m_forma_pago.num_encontrato += 1;
                        try
                        {
                            cmd = db1.GetSqlStringCommand("INSERT INTO [forma_pago]([id_transaccion],[dpr],[dpr_sus],[dpr_id_dpr],[efectivo_sus],[efectivo_bs],[deposito_sus],[deposito_bs],[tarjeta_numero],[tarjeta_sus],[tarjeta_bs],[cheque_id_banco],[cheque_numero],[cheque_sus],[cheque_bs]) VALUES(@id_transaccion,@dpr,@dpr_sus,@dpr_id_dpr,@efectivo_sus,@efectivo_bs,0,0,'',0,0,@cheque_id_banco,@cheque_numero,@cheque_sus,@cheque_bs)");
                            db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                            db1.AddInParameter(cmd, "dpr", DbType.Boolean, montodpr.Equals(0).Equals(false));
                            db1.AddInParameter(cmd, "dpr_sus", DbType.Decimal, montodpr);
                            if (dpr_id_dpr > 0) db1.AddInParameter(cmd, "dpr_id_dpr", DbType.Int32, dpr_id_dpr);
                            else db1.AddInParameter(cmd, "dpr_id_dpr", DbType.Int32, null);
                            db1.AddInParameter(cmd, "efectivo_sus", DbType.Decimal, montosus);
                            db1.AddInParameter(cmd, "efectivo_bs", DbType.Decimal, montobs);
                            if (cheque_id_banco > 0) db1.AddInParameter(cmd, "cheque_id_banco", DbType.Int32, cheque_id_banco);
                            else db1.AddInParameter(cmd, "cheque_id_banco", DbType.Int32, null);
                            db1.AddInParameter(cmd, "cheque_numero", DbType.String, cheque_numero);
                            db1.AddInParameter(cmd, "cheque_sus", DbType.Decimal, cheque_sus);
                            db1.AddInParameter(cmd, "cheque_bs", DbType.Decimal, cheque_bs);
                            db1.ExecuteNonQuery(cmd);
                            m_forma_pago.num_migrado += 1;
                        }
                        catch (Exception ex)
                        {
                            m_forma_pago.num_error += 1;
                            m_forma_pago.NewMens("Error", "[forma_pago]", "ncontrato: " + ncontrato + " ; id_contrato: " + id_contrato.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; Mensaje de error: " + ex.Message);
                        }

                        //Se registra el recibo, si es necesario y si existe
                        if (nrecibo > 0)
                        {
                            m_recibo.num_encontrato += 1;
                            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT TOP 1 [paterno] + ' ' + [materno] + ' ' + [nombres] FROM [cliente] as c, [cliente_contrato] as cc WHERE cc.[id_cliente]=c.[id_cliente] AND cc.[id_contrato]=@id_contrato AND primer_titular=1),'')");
                            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                            string nombre_cliente = db1.ExecuteScalar(cmd).ToString();
                            try
                            {
                                cmd = db1.GetSqlStringCommand("INSERT INTO [recibo]([id_transaccion],[num_recibo],[fecha],[nombre_cliente],[concepto],[monto_sus],[tipo_cambio],[encabezado],[anulado],[anulado_fecha],[anulado_id_usuario]) VALUES(@id_transaccion,@num_recibo,@fecha,@nombre_cliente,@concepto,@monto_sus,@tipo_cambio,@encabezado,0,NULL,NULL)");
                                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                                db1.AddInParameter(cmd, "num_recibo", DbType.Int32, nrecibo);
                                db1.AddInParameter(cmd, "fecha", DbType.DateTime, fechapago);
                                db1.AddInParameter(cmd, "nombre_cliente", DbType.String, nombre_cliente);
                                db1.AddInParameter(cmd, "concepto", DbType.String, "PAGO DE LA CUOTA INICIAL");
                                db1.AddInParameter(cmd, "monto_sus", DbType.Decimal, i_valorcuota);
                                db1.AddInParameter(cmd, "tipo_cambio", DbType.Decimal, tccompra);
                                db1.AddInParameter(cmd, "encabezado", DbType.String, _encabezado);
                                db1.ExecuteNonQuery(cmd);
                                m_recibo.num_migrado += 1;
                            }
                            catch (Exception ex)
                            {
                                m_recibo.num_error += 1;
                                m_recibo.NewMens("Error", "[recibo]", "ncontrato: " + ncontrato + " ; id_contrato: " + id_contrato.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; nrecibo: " + nrecibo.ToString() + " ; Mensaje de error: " + ex.Message);
                            }
                        }

                        //Se registra el pago
                        int id_pago = 0;
                        m_pago.num_encontrato += 1;
                        try
                        {
                            cmd = db1.GetSqlStringCommand("INSERT INTO [pago]([id_tipopago],[id_contrato],[id_transaccion],[id_planpago],[fecha],[fecha_proximo],[num_cuotas],[monto_pago],[seguro],[seguro_fecha],[seguro_meses],[mantenimiento_sus],[mantenimiento_fecha],[mantenimiento_meses],[interes],[interes_fecha],[interes_dias],[interes_dias_total],[amortizacion],[saldo],[anulado]) VALUES(@id_tipopago,@id_contrato,@id_transaccion,NULL,@fecha,@fecha_proximo,0,@monto_pago,0,@seguro_fecha,0,0,@mantenimiento_fecha,0,0,@interes_fecha,0,0,@amortizacion,@saldo,0)");
                            db1.AddInParameter(cmd, "id_tipopago", DbType.Int32, id_tipopago_inicial);
                            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                            db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                            db1.AddInParameter(cmd, "fecha", DbType.DateTime, fechapago);
                            db1.AddInParameter(cmd, "fecha_proximo", DbType.DateTime, c_fecha_inicio_plan.AddMonths(1));
                            db1.AddInParameter(cmd, "monto_pago", DbType.Decimal, i_valorcuota);
                            db1.AddInParameter(cmd, "seguro_fecha", DbType.DateTime, c_fecha_inicio_plan);
                            db1.AddInParameter(cmd, "mantenimiento_fecha", DbType.DateTime, c_fecha_inicio_plan);
                            db1.AddInParameter(cmd, "interes_fecha", DbType.DateTime, c_fecha_inicio_plan);
                            db1.AddInParameter(cmd, "amortizacion", DbType.Decimal, i_valorcuota);
                            db1.AddInParameter(cmd, "saldo", DbType.Decimal, saldocapit);
                            db1.ExecuteNonQuery(cmd);

                            cmd = db1.GetSqlStringCommand("SELECT IDENT_CURRENT('pago')");
                            id_pago = Int32.Parse(db1.ExecuteScalar(cmd).ToString());
                            m_pago.num_migrado += 1;
                        }
                        catch (Exception ex)
                        {
                            m_pago.num_error += 1;
                            m_pago.NewMens("Error", "[pago]", "ncontrato: " + ncontrato + " ; id_contrato: " + id_contrato.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; Mensaje de error: " + ex.Message);
                        }

                        if (id_pago > 0)
                        {
                            //Se registra el primer Plan de Pagos
                            m_plan_pago.num_encontrato += 1;
                            try
                            {
                                cmd = db1.GetSqlStringCommand("INSERT INTO [plan_pago]([id_contrato],[id_pago],[id_usuario],[fecha],[vigente],[num_cuotas],[seguro],[mantenimiento_sus],[interes_corriente],[interes_penal],[cuota_base],[fecha_inicio_plan]) VALUES(@id_contrato,@id_pago,@id_usuario,@fecha,1,@num_cuotas,0,0,@interes_corriente,@interes_penal,@cuota_base,@fecha_inicio_plan)");
                                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                                db1.AddInParameter(cmd, "id_pago", DbType.Int32, id_pago);
                                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                                db1.AddInParameter(cmd, "fecha", DbType.DateTime, fechapago);
                                db1.AddInParameter(cmd, "num_cuotas", DbType.Int32, c_num_cuotas);
                                db1.AddInParameter(cmd, "interes_corriente", DbType.Decimal, c_interes_corriente);
                                db1.AddInParameter(cmd, "interes_penal", DbType.Decimal, c_interes_penal);
                                db1.AddInParameter(cmd, "cuota_base", DbType.Decimal, c_cuota_base);
                                db1.AddInParameter(cmd, "fecha_inicio_plan", DbType.DateTime, c_fecha_inicio_plan);
                                db1.ExecuteNonQuery(cmd);
                                m_plan_pago.num_migrado += 1;
                            }
                            catch (Exception ex)
                            {
                                m_plan_pago.num_error += 1;
                                m_plan_pago.NewMens("Error", "[plan_pago]", "ncontrato: " + ncontrato + " ; id_contrato: " + id_contrato.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; id_pago: " + id_pago.ToString() + " ; Mensaje de error: " + ex.Message);
                            }
                        }

                        //Se registra el nuevo estado del lote
                        cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_lote] FROM [contrato_venta] WHERE [id_contrato]=@id_contrato),0)");
                        db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                        int id_lote = (int)db1.ExecuteScalar(cmd);
                        m_estado_lote.num_encontrato += 1;
                        try
                        {
                            cmd = db1.GetSqlStringCommand("INSERT INTO [estado_lote]([id_estado],[id_lote],[id_contrato],[id_reversion],[id_usuario],[fecha],[observacion]) VALUES (@id_estado,@id_lote,@id_contrato,NULL,@id_usuario,@fecha,'')");
                            db1.AddInParameter(cmd, "id_estado", DbType.Int32, id_estado_vendido);
                            db1.AddInParameter(cmd, "id_lote", DbType.Int32, id_lote);
                            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                            db1.AddInParameter(cmd, "fecha", DbType.DateTime, fechapago);
                            db1.ExecuteNonQuery(cmd);
                            m_estado_lote.num_migrado += 1;
                        }
                        catch (Exception ex)
                        {
                            m_estado_lote.num_error += 1;
                            m_estado_lote.NewMens("Error", "[estado_lote]", "ncontrato: " + ncontrato + " ; id_contrato: " + id_contrato.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; id_lote: " + id_lote.ToString() + " ; Mensaje de error: " + ex.Message);
                        }

                        m_inicial.num_migrado += 1;
                    }
                }
                else
                {
                    m_inicial.num_repetido += 1;
                }
            }
            else
            {
                m_inicial.num_error += 1;
                m_inicial.NewMens("Error", "[contrato] inexistente", "ncontrato: " + ncontrato);
            }
        }
        return m_inicial.Datos() + m_transaccion.Datos() + m_forma_pago.Datos() + m_recibo.Datos() +
            m_pago.Datos() + m_plan_pago.Datos() + m_estado_lote.Datos();
    }

    public static string MigrarCuotaNormal_Parcial(int Context_id_usuario, int bloque, int num_bloques)
    {
        migracionResumen m_contrato = new migracionResumen("Contratos con pagos", true);
        migracionResumen m_transaccion = new migracionResumen("Transacciones");
        migracionResumen m_forma_pago = new migracionResumen("Forma de pago");
        migracionResumen m_recibo = new migracionResumen("Recibo");
        migracionResumen m_factura = new migracionResumen("Factura");
        migracionResumen m_comprobante = new migracionResumen("Comprobante DPR");
        migracionResumen m_pago = new migracionResumen("Pago");

        //Parámetros generales necesarios
        DbCommand cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_moneda] FROM [moneda] WHERE [codigo]='$us'),0)");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        int id_moneda = (int)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT [id_tipopago] FROM [tipo_pago] WHERE [codigo]='cuo'");
        int id_tipopago_normal = (int)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_dpr] FROM [dpr] WHERE [codigo]='SIN'),0)");
        int id_dpr_sin = (int)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT TOP 1 [id_parametrofacturacion],[razon_social],[nit],[fecha_limite] FROM [parametro_facturacion] ORDER BY [id_parametrofacturacion]");
        DataTable tabla_par_fact = db1.ExecuteDataSet(cmd).Tables[0];
        int pf_id_parametrofacturacion = 0; string pf_razon_social = ""; decimal pf_nit = 0; DateTime pf_fecha_limite = DateTime.Now;
        if (tabla_par_fact.Rows.Count > 0)
        {
            pf_id_parametrofacturacion = (int)tabla_par_fact.Rows[0]["id_parametrofacturacion"];
            pf_razon_social = tabla_par_fact.Rows[0]["razon_social"].ToString();
            pf_nit = (decimal)tabla_par_fact.Rows[0]["nit"];
            pf_fecha_limite = (DateTime)tabla_par_fact.Rows[0]["fecha_limite"];
        }

        //Contratos
        cmd = db1.GetSqlStringCommand("SELECT c.[id_contrato],c.[numero],ISNULL((SELECT TOP 1 [id_planpago] FROM [plan_pago] WHERE [id_contrato]=c.[id_contrato] ORDER BY [fecha]),0) as 'id_planpago' FROM [contrato] as c ORDER BY c.[id_contrato]");
        DataTable tabla_contrato = db1.ExecuteDataSet(cmd).Tables[0];
        int num_registros = tabla_contrato.Rows.Count; int inicio = 0; int fin = 0;
        inicio = (num_registros / num_bloques) * (bloque - 1);
        fin = inicio + (num_registros / num_bloques);
        //if (inicio > 0) inicio = inicio - 1;
        //if (fin < num_registros) fin = fin + 1;
        if (bloque == num_bloques) fin = num_registros - 1;
        m_contrato.nombre = "Contratos (" + (inicio + 1).ToString() + " - " + (fin + 1).ToString() + " / " + num_registros.ToString() + ")";
        for (int c1 = inicio; c1 <= fin; c1++)
        {
            m_contrato.num_encontrato += 1;
            int c_id_contrato = (int)tabla_contrato.Rows[c1]["id_contrato"];
            string c_numero = tabla_contrato.Rows[c1]["numero"].ToString();
            int c_id_planpago = (int)tabla_contrato.Rows[c1]["id_planpago"];
            //}

            //    foreach (DataRow fila_contrato in tabla_contrato.Rows)
            //    {
            //        m_contrato.num_encontrato += 1;
            //        int c_id_contrato = (int)fila_contrato["id_contrato"];
            //        string c_numero = fila_contrato["numero"].ToString();
            //        int c_id_planpago = (int)fila_contrato["id_planpago"];

            cmd = db1.GetSqlStringCommand("SELECT COUNT(p.[id_pago]) FROM [pago] as p, [tipo_pago] as tp WHERE p.[id_tipopago]=tp.[id_tipopago] AND tp.[codigo]<>'ini' AND p.[id_contrato]=@id_contrato");
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, c_id_contrato);
            if ((int)db1.ExecuteScalar(cmd) == 0)
            {
                //Se recupera el [id_negocio] y [id_negociocontrato] vigentes del [contrato] 
                int id_negociocontrato = 0, id_negocio = 0;
                cmd = db1.GetSqlStringCommand("SELECT [id_negociocontrato],[id_negocio] FROM [negocio_contrato] WHERE [id_contrato]=@id_contrato ORDER BY [fecha] DESC,[id_negociocontrato] DESC");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, c_id_contrato);
                DataTable tabla_negocio_contrato = db1.ExecuteDataSet(cmd).Tables[0];
                if (tabla_negocio_contrato.Rows.Count > 0)
                {
                    id_negociocontrato = (int)tabla_negocio_contrato.Rows[0]["id_negociocontrato"];
                    id_negocio = (int)tabla_negocio_contrato.Rows[0]["id_negocio"];
                }

                //Cuotas a migrar:
                //cmd = db1.GetSqlStringCommand("SELECT f.[n_trans],f.[fecha],(SELECT TOP 1 a.[proxpago] FROM (SELECT [proxpago],[ncontrato],[n_trans2],[numero] FROM [sat_amortiz] UNION SELECT [proxpago],[ncontrato],[n_trans2],[numero] FROM [sat_amohist]) as a WHERE a.[ncontrato]=@ncontrato AND a.[n_trans2]=f.[n_trans] ORDER BY [numero] DESC) as 'proxpago',(SELECT SUM(a.[cuotames]) FROM (SELECT [cuotames],[ncontrato],[n_trans2] FROM [sat_amortiz] UNION SELECT [cuotames],[ncontrato],[n_trans2] FROM [sat_amohist]) as a WHERE a.[ncontrato]=@ncontrato AND a.[n_trans2]=f.[n_trans]) as 'cuotames',(SELECT SUM(a.[interes]) FROM (SELECT [interes],[ncontrato],[n_trans2] FROM [sat_amortiz] UNION SELECT [interes],[ncontrato],[n_trans2] FROM [sat_amohist]) as a WHERE a.[ncontrato]=@ncontrato AND a.[n_trans2]=f.[n_trans]) as 'interes',(SELECT SUM(a.[amortiz]) FROM (SELECT [amortiz],[ncontrato],[n_trans2] FROM [sat_amortiz] UNION SELECT [amortiz],[ncontrato],[n_trans2] FROM [sat_amohist]) as a WHERE a.[ncontrato]=@ncontrato AND a.[n_trans2]=f.[n_trans]) as 'amortiz',(SELECT TOP 1 a.[saldocapit] FROM (SELECT [saldocapit],[ncontrato],[n_trans2],[numero] FROM [sat_amortiz] UNION SELECT [saldocapit],[ncontrato],[n_trans2],[numero] FROM [sat_amohist]) as a WHERE a.[ncontrato]=@ncontrato AND a.[n_trans2]=f.[n_trans] ORDER BY [numero] DESC) as 'saldocapit',f.[intemora],(f.[numhasta]-f.[numdesde]+1) as 'num_cuotas',f.[tccompra],f.[nrecibo],f.[nfactura],f.[ndpr],f.[ncontrol],f.[montosus],f.[montobs],f.[montodpr],f.[montobono],REPLACE(REPLACE(f.[tipodpr],'-',''),'+','') as 'tipodpr',f.[tipobono] FROM [sat_facturac] as f WHERE f.[ncontrato]=@ncontrato AND f.[n_trans] in (SELECT am.[n_trans2] FROM (SELECT [ncontrato],[n_trans2] FROM [sat_amortiz] UNION SELECT [ncontrato],[n_trans2] FROM [sat_amohist]) as am WHERE am.[ncontrato]=@ncontrato) ORDER BY [numdesde]");
                //cmd = db1.GetSqlStringCommand("((SELECT f.[n_trans],f.[fecha],(SELECT MAX([proxpago]) FROM [sat_amortiz] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans]) as 'proxpago',(SELECT SUM([cuotames]) FROM [sat_amortiz] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans]) as 'cuotames',(SELECT SUM([interes]) FROM [sat_amortiz] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans]) as 'interes',(SELECT SUM([amortiz]) FROM [sat_amortiz] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans]) as 'amortiz',(SELECT MIN([saldocapit]) FROM [sat_amortiz] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans]) as 'saldocapit',f.[intemora],(f.[numhasta]-f.[numdesde]+1) as 'num_cuotas',f.[tccompra],f.[nrecibo],f.[nfactura],f.[ndpr],f.[ncontrol],f.[montosus],f.[montobs],f.[montodpr],f.[montobono],REPLACE(REPLACE(f.[tipodpr],'-',''),'+','') as 'tipodpr',f.[tipobono],f.[numdesde] FROM [sat_facturac] as f WHERE f.[ncontrato]=@ncontrato AND (SELECT COUNT([ncontrato]) FROM [sat_amortiz] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans])>0) UNION (SELECT f.[n_trans],f.[fecha],(SELECT MAX([proxpago]) FROM [sat_amohist] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans]) as 'proxpago',(SELECT SUM([cuotames]) FROM [sat_amohist] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans]) as 'cuotames',(SELECT SUM([interes]) FROM [sat_amohist] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans]) as 'interes',(SELECT SUM([amortiz]) FROM [sat_amohist] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans]) as 'amortiz',(SELECT MIN([saldocapit]) FROM [sat_amohist] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans]) as 'saldocapit',f.[intemora],(f.[numhasta]-f.[numdesde]+1) as 'num_cuotas',f.[tccompra],f.[nrecibo],f.[nfactura],f.[ndpr],f.[ncontrol],f.[montosus],f.[montobs],f.[montodpr],f.[montobono],REPLACE(REPLACE(f.[tipodpr],'-',''),'+','') as 'tipodpr',f.[tipobono],f.[numdesde] FROM [sat_facturac] as f WHERE f.[ncontrato]=@ncontrato AND (SELECT COUNT([ncontrato]) FROM [sat_amohist] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans])>0)) ORDER BY [numdesde]");
                //cmd = db1.GetSqlStringCommand("((SELECT f.[n_trans],f.[fecha],(SELECT MAX([proxpago]) FROM [sat_amortiz] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans]) as 'proxpago',(SELECT SUM([cuotames]) FROM [sat_amortiz] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans]) as 'cuotames',(SELECT SUM([interes]) FROM [sat_amortiz] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans]) as 'interes',(SELECT SUM([amortiz]) FROM [sat_amortiz] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans]) as 'amortiz',(SELECT MIN([saldocapit]) FROM [sat_amortiz] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans]) as 'saldocapit',(SELECT MAX([modo]) FROM [sat_amortiz] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans]) as 'modo',f.[intemora],(f.[numhasta]-f.[numdesde]+1) as 'num_cuotas',f.[tccompra],f.[nrecibo],f.[nfactura],f.[ndpr],f.[ncontrol],f.[montosus],f.[montobs],f.[montodpr],f.[montobono],REPLACE(REPLACE(f.[tipodpr],'-',''),'+','') as 'tipodpr',f.[tipobono],f.[numdesde] FROM [sat_facturac] as f WHERE f.[ncontrato]=@ncontrato AND (SELECT COUNT([ncontrato]) FROM [sat_amortiz] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans])>0) UNION (SELECT f.[n_trans],f.[fecha],(SELECT MAX([proxpago]) FROM [sat_amohist] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans]) as 'proxpago',(SELECT SUM([cuotames]) FROM [sat_amohist] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans]) as 'cuotames',(SELECT SUM([interes]) FROM [sat_amohist] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans]) as 'interes',(SELECT SUM([amortiz]) FROM [sat_amohist] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans]) as 'amortiz',(SELECT MIN([saldocapit]) FROM [sat_amohist] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans]) as 'saldocapit',(SELECT MAX([modo]) FROM [sat_amohist] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans]) as 'modo',f.[intemora],(f.[numhasta]-f.[numdesde]+1) as 'num_cuotas',f.[tccompra],f.[nrecibo],f.[nfactura],f.[ndpr],f.[ncontrol],f.[montosus],f.[montobs],f.[montodpr],f.[montobono],REPLACE(REPLACE(f.[tipodpr],'-',''),'+','') as 'tipodpr',f.[tipobono],f.[numdesde] FROM [sat_facturac] as f WHERE f.[ncontrato]=@ncontrato AND (SELECT COUNT([ncontrato]) FROM [sat_amohist] WHERE [ncontrato]=@ncontrato AND [n_trans2]=f.[n_trans])>0)) ORDER BY [numdesde]");
                //cmd = db1.GetSqlStringCommand("((SELECT f.[n_trans],f.[fecha],(SELECT MAX([proxpago]) FROM [sat_amortiz] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'proxpago',(SELECT SUM([cuotames]) FROM [sat_amortiz] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'cuotames',(SELECT SUM([interes]) FROM [sat_amortiz] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'interes',(SELECT SUM([amortiz]) FROM [sat_amortiz] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'amortiz',(SELECT MIN([saldocapit]) FROM [sat_amortiz] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'saldocapit',(SELECT MAX([modo]) FROM [sat_amortiz] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'modo',f.[intemora],(f.[numhasta]-f.[numdesde]+1) as 'num_cuotas',f.[tccompra],f.[nrecibo],f.[nfactura],f.[ndpr],f.[ncontrol],f.[montosus],f.[montobs],f.[montodpr],f.[montobono],REPLACE(REPLACE(f.[tipodpr],'-',''),'+','') as 'tipodpr',f.[tipobono],f.[numdesde] FROM [sat_facturac] as f WHERE f.[ncontrato]=@ncontrato AND (SELECT COUNT([ncontrato]) FROM [sat_amortiz] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans])>0 AND (f.[intecorr]>0 OR f.[amortiz]>0 OR f.[intemora]>0)) UNION (SELECT f.[n_trans],f.[fecha],(SELECT MAX([proxpago]) FROM [sat_amohist] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'proxpago',(SELECT SUM([cuotames]) FROM [sat_amohist] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'cuotames',(SELECT SUM([interes]) FROM [sat_amohist] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'interes',(SELECT SUM([amortiz]) FROM [sat_amohist] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'amortiz',(SELECT MIN([saldocapit]) FROM [sat_amohist] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'saldocapit',(SELECT MAX([modo]) FROM [sat_amohist] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'modo',f.[intemora],(f.[numhasta]-f.[numdesde]+1) as 'num_cuotas',f.[tccompra],f.[nrecibo],f.[nfactura],f.[ndpr],f.[ncontrol],f.[montosus],f.[montobs],f.[montodpr],f.[montobono],REPLACE(REPLACE(f.[tipodpr],'-',''),'+','') as 'tipodpr',f.[tipobono],f.[numdesde] FROM [sat_facturac] as f WHERE f.[ncontrato]=@ncontrato AND (SELECT COUNT([ncontrato]) FROM [sat_amohist] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans])>0 AND (f.[intecorr]>0 OR f.[amortiz]>0 OR f.[intemora]>0))) ORDER BY [numdesde],[fecha]");

                //cmd = db1.GetSqlStringCommand("((SELECT f.[n_trans],f.[fecha],(SELECT MAX([proxpago]) FROM [sat_amortiz] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'proxpago',(SELECT SUM([cuotames]) FROM [sat_amortiz] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'cuotames',(SELECT SUM([interes]) FROM [sat_amortiz] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'interes',(SELECT SUM([amortiz]) FROM [sat_amortiz] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'amortiz',(SELECT MIN([saldocapit]) FROM [sat_amortiz] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'saldocapit',(SELECT MAX([modo]) FROM [sat_amortiz] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'modo',f.[intemora],(f.[numhasta]-f.[numdesde]+1) as 'num_cuotas',f.[tccompra],f.[nrecibo],f.[nfactura],f.[ndpr],f.[ncontrol],f.[montosus],f.[montobs],f.[montodpr],f.[montobono],REPLACE(REPLACE(f.[tipodpr],'-',''),'+','') as 'tipodpr',f.[tipobono],f.[numdesde] FROM [sat_facturac] as f WHERE f.[ncontrato]=@ncontrato AND (SELECT COUNT([ncontrato]) FROM [sat_amortiz] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans])>0 AND (f.[intecorr]>0 OR f.[amortiz]>0 OR f.[intemora]>0)) UNION (SELECT f.[n_trans],f.[fecha],(SELECT MAX([proxpago]) FROM [sat_amohist] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'proxpago',(SELECT SUM([cuotames]) FROM [sat_amohist] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'cuotames',(SELECT SUM([interes]) FROM [sat_amohist] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'interes',(SELECT SUM([amortiz]) FROM [sat_amohist] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'amortiz',(SELECT MIN([saldocapit]) FROM [sat_amohist] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'saldocapit',(SELECT MAX([modo]) FROM [sat_amohist] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'modo',f.[intemora],(f.[numhasta]-f.[numdesde]+1) as 'num_cuotas',f.[tccompra],f.[nrecibo],f.[nfactura],f.[ndpr],f.[ncontrol],f.[montosus],f.[montobs],f.[montodpr],f.[montobono],REPLACE(REPLACE(f.[tipodpr],'-',''),'+','') as 'tipodpr',f.[tipobono],f.[numdesde] FROM [sat_facturac] as f WHERE f.[ncontrato]=@ncontrato AND (SELECT COUNT([ncontrato]) FROM [sat_amohist] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans])>0 AND (f.[intecorr]>0 OR f.[amortiz]>0 OR f.[intemora]>0)) UNION (SELECT a.[n_trans2] as 'n_trans',a.[fechapago] as 'fecha',a.[proxpago],a.[cuotames],a.[interes],a.[amortiz],a.[saldocapit],a.[modo],0 as 'intemora',1 as 'num_cuotas',0 as 'tccompra',a.[recibo] as 'nrecibo',a.[factura] as 'nfactura',0 as 'ndpr',0 as 'ncontrol',a.[cuotames] as 'montosus',0 as 'montobs',0 as 'montodpr',0 as 'montobono','' as 'tipodpr','' as 'tipobono',a.[numero] as 'numdesde' FROM [sat_amortiz] as a WHERE a.[ncontrato]=@ncontrato AND (SELECT COUNT([ncontrato]) FROM [sat_facturac] WHERE [ncontrato]=a.[ncontrato] AND [n_trans]=a.[n_trans2])=0 AND (a.[amortiz]>0 OR a.[interes]>0)) UNION (SELECT a.[n_trans2] as 'n_trans',a.[fechapago] as 'fecha',a.[proxpago],a.[cuotames],a.[interes],a.[amortiz],a.[saldocapit],a.[modo],0 as 'intemora',1 as 'num_cuotas',0 as 'tccompra',a.[recibo] as 'nrecibo',a.[factura] as 'nfactura',0 as 'ndpr',0 as 'ncontrol',a.[cuotames] as 'montosus',0 as 'montobs',0 as 'montodpr',0 as 'montobono','' as 'tipodpr','' as 'tipobono',a.[numero] as 'numdesde' FROM [sat_amohist] as a WHERE a.[ncontrato]=@ncontrato AND (SELECT COUNT([ncontrato]) FROM [sat_facturac] WHERE [ncontrato]=a.[ncontrato] AND [n_trans]=a.[n_trans2])=0 AND (a.[amortiz]>0 OR a.[interes]>0)))ORDER BY [numdesde],[fecha]");
                cmd = db1.GetSqlStringCommand("((SELECT f.[n_trans],f.[fecha],(SELECT MAX([proxpago]) FROM [sat_amortiz] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'proxpago',(SELECT SUM([cuotames]) FROM [sat_amortiz] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'cuotames',(SELECT SUM([interes]) FROM [sat_amortiz] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'interes',(SELECT SUM([amortiz]) FROM [sat_amortiz] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'amortiz',(SELECT MIN([saldocapit]) FROM [sat_amortiz] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'saldocapit',(SELECT MAX([modo]) FROM [sat_amortiz] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'modo',f.[intemora],(f.[numhasta]-f.[numdesde]+1) as 'num_cuotas',f.[tccompra],f.[nrecibo],f.[nfactura],f.[ndpr],f.[ncontrol],f.[montosus],f.[montobs],f.[montodpr],f.[montobono],REPLACE(REPLACE(f.[tipodpr],'-',''),'+','') as 'tipodpr',f.[tipobono],f.[numdesde],f.[ci] FROM [sat_facturac] as f WHERE f.[ncontrato]=@ncontrato AND (SELECT COUNT([ncontrato]) FROM [sat_amortiz] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans])>0 AND (f.[intecorr]>0 OR f.[amortiz]>0 OR f.[intemora]>0)) UNION (SELECT f.[n_trans],f.[fecha],(SELECT MAX([proxpago]) FROM [sat_amohist] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'proxpago',(SELECT SUM([cuotames]) FROM [sat_amohist] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'cuotames',(SELECT SUM([interes]) FROM [sat_amohist] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'interes',(SELECT SUM([amortiz]) FROM [sat_amohist] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'amortiz',(SELECT MIN([saldocapit]) FROM [sat_amohist] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'saldocapit',(SELECT MAX([modo]) FROM [sat_amohist] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans]) as 'modo',f.[intemora],(f.[numhasta]-f.[numdesde]+1) as 'num_cuotas',f.[tccompra],f.[nrecibo],f.[nfactura],f.[ndpr],f.[ncontrol],f.[montosus],f.[montobs],f.[montodpr],f.[montobono],REPLACE(REPLACE(f.[tipodpr],'-',''),'+','') as 'tipodpr',f.[tipobono],f.[numdesde],f.[ci] FROM [sat_facturac] as f WHERE f.[ncontrato]=@ncontrato AND (SELECT COUNT([ncontrato]) FROM [sat_amohist] WHERE [ncontrato]=f.[ncontrato] AND [n_trans2]=f.[n_trans])>0 AND (f.[intecorr]>0 OR f.[amortiz]>0 OR f.[intemora]>0)) UNION (SELECT a.[n_trans2] as 'n_trans',a.[fechapago] as 'fecha',a.[proxpago],a.[cuotames],a.[interes],a.[amortiz],a.[saldocapit],a.[modo],0 as 'intemora',1 as 'num_cuotas',0 as 'tccompra',a.[recibo] as 'nrecibo',a.[factura] as 'nfactura',0 as 'ndpr',0 as 'ncontrol',a.[cuotames] as 'montosus',0 as 'montobs',0 as 'montodpr',0 as 'montobono','' as 'tipodpr','' as 'tipobono',a.[numero] as 'numdesde',0 as 'ci' FROM [sat_amortiz] as a WHERE a.[ncontrato]=@ncontrato AND (SELECT COUNT([ncontrato]) FROM [sat_facturac] WHERE [ncontrato]=a.[ncontrato] AND [n_trans]=a.[n_trans2])=0 AND (a.[amortiz]>0 OR a.[interes]>0)) UNION (SELECT a.[n_trans2] as 'n_trans',a.[fechapago] as 'fecha',a.[proxpago],a.[cuotames],a.[interes],a.[amortiz],a.[saldocapit],a.[modo],0 as 'intemora',1 as 'num_cuotas',0 as 'tccompra',a.[recibo] as 'nrecibo',a.[factura] as 'nfactura',0 as 'ndpr',0 as 'ncontrol',a.[cuotames] as 'montosus',0 as 'montobs',0 as 'montodpr',0 as 'montobono','' as 'tipodpr','' as 'tipobono',a.[numero] as 'numdesde',0 as 'ci' FROM [sat_amohist] as a WHERE a.[ncontrato]=@ncontrato AND (SELECT COUNT([ncontrato]) FROM [sat_facturac] WHERE [ncontrato]=a.[ncontrato] AND [n_trans]=a.[n_trans2])=0 AND (a.[amortiz]>0 OR a.[interes]>0))) ORDER BY [numdesde],[fecha]");

                db1.AddInParameter(cmd, "ncontrato", DbType.Decimal, decimal.Parse(c_numero));
                DataTable tabla_sat_cuotas = db1.ExecuteDataSet(cmd).Tables[0];
                //n_trans,fecha,proxpago,cuotames,interes,amortiz,saldocapit,modo,intemora,num_cuotas,tccompra,
                //nrecibo,nfactura,ndpr,ncontrol,montosus,montobs,montodpr,montobono,tipodpr,tipobono
                //bool contrato_pagos_migrado = false;
                foreach (DataRow fila in tabla_sat_cuotas.Rows)
                {
                    int n_trans = int.Parse(fila["n_trans"].ToString());
                    DateTime fecha = (DateTime)fila["fecha"];
                    DateTime proxpago = (DateTime)fila["proxpago"];
                    decimal cuotames = (decimal)fila["cuotames"];
                    decimal interes = (decimal)fila["interes"];
                    decimal amortiz = (decimal)fila["amortiz"];
                    decimal saldocapit = (decimal)fila["saldocapit"];
                    string modo = Formato(fila["modo"].ToString());
                    decimal intemora = (decimal)fila["intemora"];
                    int num_cuotas = int.Parse(fila["num_cuotas"].ToString());
                    decimal tccompra = (decimal)fila["tccompra"];
                    int nrecibo = int.Parse(fila["nrecibo"].ToString());
                    int nfactura = int.Parse(fila["nfactura"].ToString());
                    int ndpr = int.Parse(fila["ndpr"].ToString());
                    int ncontrol = int.Parse(fila["ncontrol"].ToString());
                    decimal montosus = (decimal)fila["montosus"];
                    decimal montobs = (decimal)fila["montobs"];
                    decimal montodpr = (decimal)fila["montodpr"];
                    decimal montobono = (decimal)fila["montobono"];
                    string tipodpr = Formato(fila["tipodpr"].ToString());
                    string tipobono = Formato(fila["tipobono"].ToString());




                    string ci = fila["ci"].ToString();
                    //Se reculera el id del usuario que hizo la transacción
                    int id_usuario_transaccion = 0;
                    if (ci != "0")
                    {
                        cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_usuario] FROM [usuario] WHERE [ci]=@ci),0)");
                        db1.AddInParameter(cmd, "ci", DbType.String, ci);
                        id_usuario_transaccion = (int)db1.ExecuteScalar(cmd);
                    }
                    if (id_usuario_transaccion == 0) id_usuario_transaccion = Context_id_usuario;




                    //De ser necesario se extrae el monto pagado por concepto de mora
                    if (intemora > 0)
                    {
                        if (montosus == 0 && montobs == 0) montodpr = cuotames;
                        else if (montodpr == 0)
                        {
                            if (montosus > 0 && montobs == 0) montosus = cuotames;
                            else if (montosus == 0 && montobs > 0) montobs = cuotames * tccompra;
                            else
                            {
                                if (montosus == cuotames) montobs = 0;
                                else if (montobs / tccompra == cuotames) montosus = 0;
                                else { montosus = cuotames; montobs = 0; }
                            }
                        }
                        else
                        {
                            if (montosus == cuotames) { montobs = 0; montodpr = 0; }
                            else if (montodpr == cuotames) { montosus = 0; montobs = 0; }
                            else { montosus = cuotames; montobs = 0; montodpr = 0; }
                        }
                    }
                    if (montodpr == 0) montobono = 0;

                    //De ser necesario se obtiene el recibo de cobrador
                    int id_recibocobrador = 0;
                    if (ncontrol > 0)
                    {
                        cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT MIN([id_recibocobrador]) FROM [recibo_cobrador] WHERE [numero]=@numero),0)");
                        db1.AddInParameter(cmd, "numero", DbType.Int32, ncontrol);
                        id_recibocobrador = (int)db1.ExecuteScalar(cmd);
                    }

                    //Se obtiene el nombre y nit del titular del contrato
                    string nombre_cliente = "";
                    string nit_cliente = "";
                    cmd = db1.GetSqlStringCommand("SELECT ([paterno] + ' ' + [materno] + ' ' + [nombres]) as 'nombre', [nit] FROM [cliente] as c, [cliente_contrato] as cc WHERE cc.[id_cliente]=c.[id_cliente] AND cc.[id_contrato]=@id_contrato AND primer_titular=1");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, c_id_contrato);
                    DataTable tabla_cliente_titular = db1.ExecuteDataSet(cmd).Tables[0];
                    if (tabla_cliente_titular.Rows.Count > 0)
                    {
                        nombre_cliente = tabla_cliente_titular.Rows[0]["nombre"].ToString();
                        nit_cliente = tabla_cliente_titular.Rows[0]["nit"].ToString();
                    }

                    //Se obtiene el plan de pagos para el contrato
                    cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT MAX([id_planpago]) FROM [plan_pago] WHERE [id_contrato]=@id_contrato AND [fecha]<=@fecha),0)");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, c_id_contrato);
                    db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                    int id_planpago = (int)db1.ExecuteScalar(cmd);
                    if (id_planpago == 0) id_planpago = c_id_planpago;


                    //Se registra la transacción
                    int id_transaccion = 0;
                    m_transaccion.num_encontrato += 1;
                    try
                    {
                        cmd = db1.GetSqlStringCommand("INSERT INTO [transaccion]([id_moneda],[id_usuario],[id_negocio],[id_negociocontrato],[id_recibocobrador],[fecha],[ntrans],[tipo_cambio],[monto],[comisionable],[anulado]) VALUES (@id_moneda,@id_usuario,@id_negocio,@id_negociocontrato,@id_recibocobrador,@fecha,@ntrans,@tipo_cambio,@monto,@comisionable,@anulado)");
                        db1.AddInParameter(cmd, "id_moneda", DbType.Int32, id_moneda);




                        //db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                        db1.AddInParameter(cmd, "id_usuario", DbType.Int32, id_usuario_transaccion);




                        db1.AddInParameter(cmd, "id_negocio", DbType.Int32, id_negocio);
                        db1.AddInParameter(cmd, "id_negociocontrato", DbType.Int32, id_negociocontrato);
                        if (id_recibocobrador > 0) db1.AddInParameter(cmd, "id_recibocobrador", DbType.Int32, id_recibocobrador);
                        else db1.AddInParameter(cmd, "id_recibocobrador", DbType.Int32, null);
                        db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                        db1.AddInParameter(cmd, "ntrans", DbType.Int32, n_trans);
                        db1.AddInParameter(cmd, "tipo_cambio", DbType.Decimal, tccompra);
                        db1.AddInParameter(cmd, "monto", DbType.Decimal, cuotames);
                        if (montodpr > 0) db1.AddInParameter(cmd, "comisionable", DbType.Boolean, false);
                        else db1.AddInParameter(cmd, "comisionable", DbType.Boolean, true);
                        db1.AddInParameter(cmd, "anulado", DbType.Boolean, false);
                        db1.ExecuteNonQuery(cmd);

                        cmd = db1.GetSqlStringCommand("SELECT IDENT_CURRENT('transaccion')");
                        id_transaccion = Int32.Parse(db1.ExecuteScalar(cmd).ToString());

                        m_transaccion.num_migrado += 1;
                    }
                    catch (Exception ex)
                    {
                        m_transaccion.num_error += 1;
                        m_transaccion.NewMens("Error", "[transaccion]", "Nº contrato: " + c_numero + " ; id_contrato: " + c_id_contrato.ToString() + " ; Mensaje de error: " + ex.Message);
                    }

                    if (id_transaccion > 0)
                    {
                        //De ser necesario se obtiene el dpr_id_dpr
                        int dpr_id_dpr = 0;
                        if (montodpr > 0 || montobono > 0)
                        {
                            if (montobono > 0)
                            {
                                //Si existe, se obtiene el tipo de bono de la tabla [sat_bonos]
                                string bonos_tipobono = "";
                                cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT MAX([tipobono]) FROM [sat_bonos] WHERE [ncontrato]=@ncontrato AND [n_trans]=@n_trans),'')");
                                db1.AddInParameter(cmd, "ncontrato", DbType.Decimal, decimal.Parse(c_numero));
                                db1.AddInParameter(cmd, "n_trans", DbType.Decimal, decimal.Parse(n_trans.ToString()));
                                bonos_tipobono = db1.ExecuteScalar(cmd).ToString().Trim();
                                if (bonos_tipobono != "") bonos_tipobono = tipobono;

                                //Se obtiene el Id del "DPR" o "BONO" utilizado
                                if (bonos_tipobono != "")
                                {
                                    cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_dpr] FROM [dpr] WHERE [codigo]=@codigo),0)");
                                    db1.AddInParameter(cmd, "codigo", DbType.String, bonos_tipobono);
                                    dpr_id_dpr = (int)db1.ExecuteScalar(cmd);
                                }
                                else { dpr_id_dpr = id_dpr_sin; }
                            }
                            else
                            {
                                if (tipodpr != "")
                                {
                                    cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_dpr] FROM [dpr] WHERE [codigo]=@codigo),0)");
                                    db1.AddInParameter(cmd, "codigo", DbType.String, tipodpr);
                                    dpr_id_dpr = (int)db1.ExecuteScalar(cmd);
                                }
                                else dpr_id_dpr = id_dpr_sin;
                            }
                        }

                        //Si se empleó un cheque para realizar la transacción se obtienen los datos utilizados
                        int cheque_id_banco = 0; string cheque_numero = ""; decimal cheque_sus = 0; decimal cheque_bs = 0;
                        cmd = db1.GetSqlStringCommand("SELECT [mon_chsu] as 'sus',[mon_chbs] as 'bs',(CASE [mon_chsu] WHEN 0 THEN [num_chbs] ELSE [num_chsu] END) as 'numero',(CASE [mon_chsu] WHEN 0 THEN [bco_chbs] ELSE [bco_chsu] END) as 'banco' FROM [sat_fact_chq] WHERE [ncontrato]=@ncontrato AND [n_trans]=@n_trans AND ([mon_chsu]>0 OR [mon_chbs]>0)");
                        db1.AddInParameter(cmd, "ncontrato", DbType.Decimal, decimal.Parse(c_numero));
                        db1.AddInParameter(cmd, "n_trans", DbType.Decimal, decimal.Parse(n_trans.ToString()));
                        DataTable tabla_cheque = db1.ExecuteDataSet(cmd).Tables[0];
                        if (tabla_cheque.Rows.Count > 0)
                        {//sus,bs,numero,banco
                            cheque_sus = (decimal)tabla_cheque.Rows[0]["sus"];
                            cheque_bs = (decimal)tabla_cheque.Rows[0]["bs"];
                            cheque_numero = tabla_cheque.Rows[0]["numero"].ToString();
                            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_banco] FROM [banco] WHERE [codigo]=@codigo),0)");
                            db1.AddInParameter(cmd, "codigo", DbType.String, tabla_cheque.Rows[0]["banco"].ToString().Trim());
                            cheque_id_banco = (int)db1.ExecuteScalar(cmd);
                        }



                        //Se registra la forma de pago
                        m_forma_pago.num_encontrato += 1;
                        try
                        {
                            cmd = db1.GetSqlStringCommand("INSERT INTO [forma_pago]([id_transaccion],[dpr],[dpr_sus],[dpr_id_dpr],[efectivo_sus],[efectivo_bs],[deposito_sus],[deposito_bs],[tarjeta_numero],[tarjeta_sus],[tarjeta_bs],[cheque_id_banco],[cheque_numero],[cheque_sus],[cheque_bs]) VALUES(@id_transaccion,@dpr,@dpr_sus,@dpr_id_dpr,@efectivo_sus,@efectivo_bs,0,0,'',0,0,@cheque_id_banco,@cheque_numero,@cheque_sus,@cheque_bs)");
                            db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                            db1.AddInParameter(cmd, "dpr", DbType.Boolean, montodpr.Equals(0).Equals(false));
                            db1.AddInParameter(cmd, "dpr_sus", DbType.Decimal, montodpr);
                            if (dpr_id_dpr > 0) db1.AddInParameter(cmd, "dpr_id_dpr", DbType.Int32, dpr_id_dpr);
                            else db1.AddInParameter(cmd, "dpr_id_dpr", DbType.Int32, null);
                            db1.AddInParameter(cmd, "efectivo_sus", DbType.Decimal, montosus);
                            db1.AddInParameter(cmd, "efectivo_bs", DbType.Decimal, montobs);
                            if (cheque_id_banco > 0) db1.AddInParameter(cmd, "cheque_id_banco", DbType.Int32, cheque_id_banco);
                            else db1.AddInParameter(cmd, "cheque_id_banco", DbType.Int32, null);
                            db1.AddInParameter(cmd, "cheque_numero", DbType.String, cheque_numero);
                            db1.AddInParameter(cmd, "cheque_sus", DbType.Decimal, cheque_sus);
                            db1.AddInParameter(cmd, "cheque_bs", DbType.Decimal, cheque_bs);
                            db1.ExecuteNonQuery(cmd);
                            m_forma_pago.num_migrado += 1;
                        }
                        catch (Exception ex)
                        {
                            m_forma_pago.num_error += 1;
                            m_forma_pago.NewMens("Error", "[forma_pago]", "Nº contrato: " + c_numero + " ; id_contrato: " + c_id_contrato.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; Mensaje de error: " + ex.Message);
                        }

                        //Se registra el recibo, si es necesario y si existe
                        //if (nrecibo > 0)
                        //{
                        //cmd = db1.GetSqlStringCommand("SELECT [fecha],[fechaanu],(CASE [estado] WHEN 'AN' THEN CONVERT(bit,1) ELSE CONVERT(bit,0) END) as 'anulado' FROM [sat_recibos] WHERE [ncontrato]=@ncontrato and [n_trans]=@n_trans and [nrecibo]=@nrecibo");
                        //cmd = db1.GetSqlStringCommand("SELECT [fecha],[fechaanu],(CASE [estado] WHEN 'AN' THEN CONVERT(bit,1) ELSE CONVERT(bit,0) END) as 'anulado' FROM [sat_recibos] WHERE [ncontrato]=@ncontrato and [n_trans]=@n_trans");
                        cmd = db1.GetSqlStringCommand("SELECT [nrecibo],[fecha],[fechaanu],(CASE [estado] WHEN 'AN' THEN CONVERT(bit,1) ELSE CONVERT(bit,0) END) as 'anulado' FROM [sat_recibos] WHERE [ncontrato]=@ncontrato and [n_trans]=@n_trans");
                        db1.AddInParameter(cmd, "ncontrato", DbType.Decimal, decimal.Parse(c_numero));
                        db1.AddInParameter(cmd, "n_trans", DbType.Decimal, decimal.Parse(n_trans.ToString()));
                        //db1.AddInParameter(cmd, "nrecibo", DbType.Decimal, decimal.Parse(nrecibo.ToString()));
                        DataTable tabla_sat_recibos = db1.ExecuteDataSet(cmd).Tables[0];
                        foreach (DataRow fila_recibo in tabla_sat_recibos.Rows)
                        {
                            int r_nrecibo = int.Parse(fila_recibo["nrecibo"].ToString());
                            DateTime r_fecha = (DateTime)fila_recibo["fecha"];
                            DateTime r_fechaanu = (DateTime)fila_recibo["fechaanu"];
                            bool r_anulado = (bool)fila_recibo["anulado"];
                            m_recibo.num_encontrato += 1;
                            try
                            {
                                cmd = db1.GetSqlStringCommand("INSERT INTO [recibo]([id_transaccion],[num_recibo],[fecha],[nombre_cliente],[concepto],[monto_sus],[tipo_cambio],[encabezado],[anulado],[anulado_fecha],[anulado_id_usuario]) VALUES(@id_transaccion,@num_recibo,@fecha,@nombre_cliente,@concepto,@monto_sus,@tipo_cambio,@encabezado,@anulado,@anulado_fecha,@anulado_id_usuario)");
                                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                                db1.AddInParameter(cmd, "num_recibo", DbType.Int32, r_nrecibo);
                                db1.AddInParameter(cmd, "fecha", DbType.DateTime, r_fecha);
                                db1.AddInParameter(cmd, "nombre_cliente", DbType.String, nombre_cliente);
                                db1.AddInParameter(cmd, "concepto", DbType.String, "Pago de cuotas");
                                db1.AddInParameter(cmd, "monto_sus", DbType.Decimal, cuotames);
                                db1.AddInParameter(cmd, "tipo_cambio", DbType.Decimal, tccompra);
                                db1.AddInParameter(cmd, "encabezado", DbType.String, _encabezado);
                                db1.AddInParameter(cmd, "anulado", DbType.Boolean, r_anulado);
                                if (r_anulado == true)
                                {
                                    db1.AddInParameter(cmd, "anulado_fecha", DbType.DateTime, r_fechaanu);
                                    db1.AddInParameter(cmd, "anulado_id_usuario", DbType.Int32, Context_id_usuario);
                                }
                                else
                                {
                                    db1.AddInParameter(cmd, "anulado_fecha", DbType.DateTime, null);
                                    db1.AddInParameter(cmd, "anulado_id_usuario", DbType.Int32, null);
                                }
                                db1.ExecuteNonQuery(cmd);
                                m_recibo.num_migrado += 1;
                            }
                            catch (Exception ex)
                            {
                                m_recibo.num_error += 1;
                                m_recibo.NewMens("Error", "[recibo]", "Nº contrato: " + c_numero + " ; id_contrato: " + c_id_contrato.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; nrecibo: " + nrecibo.ToString() + " ; Mensaje de error: " + ex.Message);
                            }
                        }
                        //}

                        //Se registra la factura, si es necesario y si existe
                        //if (nfactura > 0)
                        //{
                        //cmd = db1.GetSqlStringCommand("SELECT [fecha],[montobs],[tc],[nauto],[ccontrol],[fechaanu],(CASE [estado] WHEN 'AN' THEN CONVERT(bit,1) ELSE CONVERT(bit,0) END) as 'anulado' FROM [sat_facturas] WHERE [ncontrato]=@ncontrato AND [n_trans]=@n_trans AND [nfactura]=@nfactura");
                        //cmd = db1.GetSqlStringCommand("SELECT [fecha],[montobs],[tc],[nauto],[ccontrol],[fechaanu],(CASE [estado] WHEN 'AN' THEN CONVERT(bit,1) ELSE CONVERT(bit,0) END) as 'anulado' FROM [sat_facturas] WHERE [ncontrato]=@ncontrato AND [n_trans]=@n_trans");
                        cmd = db1.GetSqlStringCommand("SELECT [nfactura],[fecha],[montobs],[tc],[nauto],[ccontrol],[fechaanu],(CASE [estado] WHEN 'AN' THEN CONVERT(bit,1) ELSE CONVERT(bit,0) END) as 'anulado' FROM [sat_facturas] WHERE [ncontrato]=@ncontrato AND [n_trans]=@n_trans");
                        db1.AddInParameter(cmd, "ncontrato", DbType.Decimal, decimal.Parse(c_numero));
                        db1.AddInParameter(cmd, "n_trans", DbType.Decimal, decimal.Parse(n_trans.ToString()));
                        //db1.AddInParameter(cmd, "nfactura", DbType.Decimal, decimal.Parse(nfactura.ToString()));
                        DataTable tabla_sat_facturas = db1.ExecuteDataSet(cmd).Tables[0];
                        foreach (DataRow fila_factura in tabla_sat_facturas.Rows)
                        {
                            int f_nfactura = int.Parse(fila_factura["nfactura"].ToString());
                            DateTime f_fecha = (DateTime)fila_factura["fecha"];
                            decimal f_montobs = (decimal)fila_factura["montobs"];
                            decimal f_tc = (decimal)fila_factura["tc"];
                            string f_nauto = Formato(fila_factura["nauto"].ToString()); if (f_nauto == "") f_nauto = "0";
                            string f_ccontrol = fila_factura["ccontrol"].ToString();
                            DateTime f_fechaanu = (DateTime)fila_factura["fechaanu"];
                            bool f_anulado = (bool)fila_factura["anulado"];
                            m_factura.num_encontrato += 1;
                            try
                            {
                                cmd = db1.GetSqlStringCommand("INSERT INTO [factura]([id_parametrofacturacion],[id_transaccion],[razon_social],[nit],[fecha_limite],[num_autorizacion],[llave_dosificacion],[encabezado],[num_factura],[fecha],[cliente_nombre],[cliente_nit],[concepto],[monto_bs],[tipo_cambio],[numero_control],[anulado],[anulado_fecha],[anulado_id_usuario]) VALUES(@id_parametrofacturacion,@id_transaccion,@razon_social,@nit,@fecha_limite,@num_autorizacion,@llave_dosificacion,@encabezado,@num_factura,@fecha,@cliente_nombre,@cliente_nit,@concepto,@monto_bs,@tipo_cambio,@numero_control,@anulado,@anulado_fecha,@anulado_id_usuario)");
                                db1.AddInParameter(cmd, "id_parametrofacturacion", DbType.Int32, pf_id_parametrofacturacion);
                                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                                db1.AddInParameter(cmd, "razon_social", DbType.String, pf_razon_social);
                                db1.AddInParameter(cmd, "nit", DbType.Decimal, pf_nit);
                                db1.AddInParameter(cmd, "fecha_limite", DbType.DateTime, pf_fecha_limite);
                                db1.AddInParameter(cmd, "num_autorizacion", DbType.Decimal, decimal.Parse(f_nauto));
                                db1.AddInParameter(cmd, "llave_dosificacion", DbType.String, "");
                                db1.AddInParameter(cmd, "encabezado", DbType.String, _encabezado);

                                db1.AddInParameter(cmd, "num_factura", DbType.Int32, f_nfactura);
                                db1.AddInParameter(cmd, "fecha", DbType.DateTime, f_fecha);
                                db1.AddInParameter(cmd, "cliente_nombre", DbType.String, nombre_cliente);
                                db1.AddInParameter(cmd, "cliente_nit", DbType.Decimal, decimal.Parse(nit_cliente));
                                db1.AddInParameter(cmd, "concepto", DbType.String, "Pago de cuotas");
                                db1.AddInParameter(cmd, "monto_bs", DbType.Decimal, f_montobs);
                                db1.AddInParameter(cmd, "tipo_cambio", DbType.Decimal, f_tc);
                                db1.AddInParameter(cmd, "numero_control", DbType.String, f_ccontrol);

                                db1.AddInParameter(cmd, "anulado", DbType.Boolean, f_anulado);
                                if (f_anulado == true)
                                {
                                    db1.AddInParameter(cmd, "anulado_fecha", DbType.DateTime, f_fechaanu);
                                    db1.AddInParameter(cmd, "anulado_id_usuario", DbType.Int32, Context_id_usuario);
                                }
                                else
                                {
                                    db1.AddInParameter(cmd, "anulado_fecha", DbType.DateTime, null);
                                    db1.AddInParameter(cmd, "anulado_id_usuario", DbType.Int32, null);
                                }
                                db1.ExecuteNonQuery(cmd);
                                m_factura.num_migrado += 1;
                            }
                            catch (Exception ex)
                            {
                                m_factura.num_error += 1;
                                m_factura.NewMens("Error", "[factura]", "Nº contrato: " + c_numero + " ; id_contrato: " + c_id_contrato.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; nfactura: " + nfactura.ToString() + " ; Mensaje de error: " + ex.Message);
                            }
                        }
                        //}

                        //Se registra el comprobante dpr, si es necesario y si existe
                        if (ndpr > 0 && montodpr > 0)
                        {
                            m_comprobante.num_encontrato += 1;
                            try
                            {
                                cmd = db1.GetSqlStringCommand("INSERT INTO [comprobante_dpr]([id_transaccion],[num_comprobante],[fecha],[nombre_cliente],[concepto],[monto_sus],[tipo_cambio],[encabezado],[anulado],[anulado_fecha],[anulado_id_usuario]) VALUES(@id_transaccion,@num_comprobante,@fecha,@nombre_cliente,@concepto,@monto_sus,@tipo_cambio,@encabezado,0,NULL,NULL)");
                                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                                db1.AddInParameter(cmd, "num_comprobante", DbType.Int32, ndpr);
                                db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                                db1.AddInParameter(cmd, "nombre_cliente", DbType.String, nombre_cliente);
                                db1.AddInParameter(cmd, "concepto", DbType.String, "Pago de cuotas");
                                db1.AddInParameter(cmd, "monto_sus", DbType.Decimal, cuotames);
                                db1.AddInParameter(cmd, "tipo_cambio", DbType.Decimal, tccompra);
                                db1.AddInParameter(cmd, "encabezado", DbType.String, _encabezado);
                                db1.ExecuteNonQuery(cmd);
                                m_comprobante.num_migrado += 1;
                            }
                            catch (Exception ex)
                            {
                                m_comprobante.num_error += 1;
                                m_comprobante.NewMens("Error", "[comprobante_dpr]", "Nº contrato: " + c_numero + " ; id_contrato: " + c_id_contrato.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; ndpr: " + ndpr.ToString() + " ; Mensaje de error: " + ex.Message);
                            }
                        }

                        //Se registra el pago
                        m_pago.num_encontrato += 1;
                        try
                        {
                            DateTime interes_fecha = fecha;
                            if (modo == "2") interes_fecha = proxpago.AddMonths(-1);

                            cmd = db1.GetSqlStringCommand("INSERT INTO [pago]([id_tipopago],[id_contrato],[id_transaccion],[id_planpago],[fecha],[fecha_proximo],[num_cuotas],[monto_pago],[seguro],[seguro_fecha],[seguro_meses],[mantenimiento_sus],[mantenimiento_fecha],[mantenimiento_meses],[interes],[interes_fecha],[interes_dias],[interes_dias_total],[amortizacion],[saldo],[anulado]) VALUES(@id_tipopago,@id_contrato,@id_transaccion,@id_planpago,@fecha,@fecha_proximo,@num_cuotas,@monto_pago,0,@seguro_fecha,0,0,@mantenimiento_fecha,0,@interes,@interes_fecha,0,0,@amortizacion,@saldo,0)");
                            db1.AddInParameter(cmd, "id_tipopago", DbType.Int32, id_tipopago_normal);
                            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, c_id_contrato);
                            db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                            if (id_planpago > 0) db1.AddInParameter(cmd, "id_planpago", DbType.Int32, id_planpago);
                            else db1.AddInParameter(cmd, "id_planpago", DbType.Int32, null);
                            db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                            db1.AddInParameter(cmd, "fecha_proximo", DbType.DateTime, proxpago);
                            db1.AddInParameter(cmd, "num_cuotas", DbType.Int32, num_cuotas);
                            db1.AddInParameter(cmd, "monto_pago", DbType.Decimal, cuotames);
                            db1.AddInParameter(cmd, "seguro_fecha", DbType.DateTime, proxpago.AddMonths(-1));
                            db1.AddInParameter(cmd, "mantenimiento_fecha", DbType.DateTime, proxpago.AddMonths(-1));
                            db1.AddInParameter(cmd, "interes", DbType.Decimal, interes);
                            db1.AddInParameter(cmd, "interes_fecha", DbType.DateTime, interes_fecha);
                            db1.AddInParameter(cmd, "amortizacion", DbType.Decimal, amortiz);
                            db1.AddInParameter(cmd, "saldo", DbType.Decimal, saldocapit);
                            db1.ExecuteNonQuery(cmd);

                            m_pago.num_migrado += 1;
                            //contrato_pagos_migrado = true;
                        }
                        catch (Exception ex)
                        {
                            m_pago.num_error += 1;
                            m_pago.NewMens("Error", "[pago]", "Nº contrato: " + c_numero + " ; id_contrato: " + c_id_contrato.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; Mensaje de error: " + ex.Message);
                        }

                    }
                }
                //if (contrato_pagos_migrado = true) m_contrato.num_migrado += 1;
            }
            else
            {
                m_contrato.num_repetido += 1;
            }
        }
        return m_contrato.Datos() + m_transaccion.Datos() + m_forma_pago.Datos() + m_recibo.Datos() +
            m_factura.Datos() + m_comprobante.Datos() + m_pago.Datos();
    }

    public static string MigrarAjusteProximoPago()
    {
        migracionResumen m_proxpago = new migracionResumen("Ajuste de la fecha de Próximo Pago", true);
        //Datos a migrar:
        DbCommand cmd = db1.GetSqlStringCommand("SELECT c.[id_contrato],c.[id_pago],ISNULL((SELECT MAX([fecha_inicio_plan]) FROM [plan_pago] WHERE [id_contrato]=c.[id_contrato] AND [vigente]=1),c.[fecha_inicio_plan]) as 'fecha_inicio_plan',p.[interes_fecha],p.[fecha_proximo] FROM (SELECT co.[id_contrato],co.[fecha_inicio_plan],(SELECT MAX([id_pago]) FROM [pago] WHERE [id_contrato]=co.[id_contrato]) as 'id_pago' FROM [contrato] as co ) as c, [pago] as p WHERE c.[id_pago]=p.[id_pago] AND p.[saldo]>0");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        //id_contrato,id_pago,fecha_inicio_plan,interes_fecha,fecha_proximo
        DataTable tabla_ult_pago = db1.ExecuteDataSet(cmd).Tables[0];

        //Ajuste de la fecha de próximo pago:
        foreach (DataRow fila in tabla_ult_pago.Rows)
        {
            m_proxpago.num_encontrato += 1;
            int id_contrato = (int)fila["id_contrato"];
            int id_pago = (int)fila["id_pago"];
            DateTime fecha_inicio_plan = (DateTime)fila["fecha_inicio_plan"];
            DateTime interes_fecha = (DateTime)fila["interes_fecha"];
            DateTime fecha_proximo = (DateTime)fila["fecha_proximo"];

            DateTime nueva_fecha_proximo = terrasur.logica.FechaProximoPago(interes_fecha, fecha_inicio_plan);
            if (nueva_fecha_proximo.Date != fecha_proximo.Date)
            {
                try
                {
                    cmd = db1.GetSqlStringCommand("UPDATE [pago] SET [fecha_proximo]=@fecha_proximo WHERE [id_pago]=@id_pago");
                    db1.AddInParameter(cmd, "fecha_proximo", DbType.DateTime, nueva_fecha_proximo);
                    db1.AddInParameter(cmd, "id_pago", DbType.Int32, id_pago);
                    db1.ExecuteNonQuery(cmd);
                    m_proxpago.num_migrado += 1;
                }
                catch (Exception ex)
                {
                    m_proxpago.num_error += 1;
                    m_proxpago.NewMens("Error", "[pago]", "id_contrato: " + id_contrato.ToString() + " ; fecha_inicio_plan: " + fecha_inicio_plan.ToShortDateString() + " ; interes_fecha: " + interes_fecha.ToShortDateString() + " ; fecha_proximo: " + fecha_proximo.ToShortDateString() + " ; Mensaje de error: " + ex.Message);
                }
            }
            else
            {
                m_proxpago.num_repetido += 1;
                //m_proxpago.NewMens("Repetido", "Cambio innecesario", "id_contrato: " + id_contrato.ToString() + " ; fecha_inicio_plan: " + fecha_inicio_plan.ToShortDateString() + " ; interes_fecha: " + interes_fecha.ToShortDateString() + " ; fecha_proximo: " + fecha_proximo.ToShortDateString());
            }
        }

        //Los resultados:
        return m_proxpago.Datos();
    }

    public static string MigrarOtrosServiciosContrato(int Context_id_usuario)
    {
        migracionResumen m_servicio = new migracionResumen("Servicios Vendidos sobre Contratos", true);
        migracionResumen m_transaccion = new migracionResumen("Transacciones");
        migracionResumen m_forma_pago = new migracionResumen("Forma de pago");
        migracionResumen m_recibo = new migracionResumen("Recibo");
        migracionResumen m_factura = new migracionResumen("Factura");
        migracionResumen m_comprobante = new migracionResumen("Comprobante DPR");

        //Parámetros generales necesarios
        DbCommand cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_moneda] FROM [moneda] WHERE [codigo]='$us'),0)");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        int id_moneda = (int)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_dpr] FROM [dpr] WHERE [codigo]='SIN'),0)");
        int id_dpr_sin = (int)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT [id_negocio] FROM [negocio] WHERE [codigo]='terra'");
        int id_negocio_terrasur = (int)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT TOP 1 [id_parametrofacturacion],[razon_social],[nit],[fecha_limite] FROM [parametro_facturacion] ORDER BY [id_parametrofacturacion]");
        DataTable tabla_par_fact = db1.ExecuteDataSet(cmd).Tables[0];
        int pf_id_parametrofacturacion = 0; string pf_razon_social = ""; decimal pf_nit = 0; DateTime pf_fecha_limite = DateTime.Now;
        if (tabla_par_fact.Rows.Count > 0)
        {
            pf_id_parametrofacturacion = (int)tabla_par_fact.Rows[0]["id_parametrofacturacion"];
            pf_razon_social = tabla_par_fact.Rows[0]["razon_social"].ToString();
            pf_nit = (decimal)tabla_par_fact.Rows[0]["nit"];
            pf_fecha_limite = (DateTime)tabla_par_fact.Rows[0]["fecha_limite"];
        }

        //Servicios vendidos
        //ncontrato,n_trans,fecha,tipo2,tccompra,montosus,montobs,montodpr,montobono,ncontrol,nrecibo,nfactura,ndpr,tipodpr,tipobono,unidades,precio_unitario
        //cmd = db1.GetSqlStringCommand("SELECT [ncontrato],[n_trans],[fecha],[tipo2],[tccompra],[montosus],[montobs],[montodpr],[montobono],[ncontrol],[nrecibo],[nfactura],[ndpr],[tipodpr],[tipobono],(SELECT COUNT([numero]) FROM [sat_otroscob] WHERE [ncontrato]=f.[ncontrato] AND [n_trans]=f.[n_trans]) as 'unidades',(SELECT MAX([importe]) FROM [sat_otroscob] WHERE [ncontrato]=f.[ncontrato] AND [n_trans]=f.[n_trans]) as 'precio_unitario' FROM [sat_facturac] as f WHERE (SELECT COUNT([numero]) FROM [sat_otroscob] WHERE [ncontrato]=f.[ncontrato] and [n_trans]=f.[n_trans])>0 AND (f.[tipo]='OTR' OR (f.[tipo]<>'OTR' AND [amortiz]=0 AND [intecorr]=0))");
        cmd = db1.GetSqlStringCommand("SELECT [ncontrato],[n_trans],[fecha],[tipo2],[tccompra],[montosus],[montobs],[montodpr],[montobono],[ncontrol],[nrecibo],[nfactura],[ndpr],[tipodpr],[tipobono],(SELECT COUNT([numero]) FROM [sat_otroscob] WHERE [ncontrato]=f.[ncontrato] AND [n_trans]=f.[n_trans]) as 'unidades',(SELECT MAX([importe]) FROM [sat_otroscob] WHERE [ncontrato]=f.[ncontrato] AND [n_trans]=f.[n_trans]) as 'precio_unitario',[ci] FROM [sat_facturac] as f WHERE (SELECT COUNT([numero]) FROM [sat_otroscob] WHERE [ncontrato]=f.[ncontrato] and [n_trans]=f.[n_trans])>0 AND (f.[tipo]='OTR' OR (f.[tipo]<>'OTR' AND [amortiz]=0 AND [intecorr]=0))");

        DataTable tabla_servicio_vendido = db1.ExecuteDataSet(cmd).Tables[0];
        foreach (DataRow fila_serv in tabla_servicio_vendido.Rows)
        {
            m_servicio.num_encontrato += 1;
            string ncontrato = fila_serv["ncontrato"].ToString();
            int n_trans = int.Parse(fila_serv["n_trans"].ToString());
            DateTime fecha = (DateTime)fila_serv["fecha"];
            string tipo2 = Formato(fila_serv["tipo2"].ToString());
            decimal tccompra = (decimal)fila_serv["tccompra"];
            decimal montosus = (decimal)fila_serv["montosus"];
            decimal montobs = (decimal)fila_serv["montobs"];
            decimal montodpr = (decimal)fila_serv["montodpr"];
            decimal montobono = (decimal)fila_serv["montobono"];
            int ncontrol = int.Parse(fila_serv["ncontrol"].ToString());
            int nrecibo = int.Parse(fila_serv["nrecibo"].ToString());
            int nfactura = int.Parse(fila_serv["nfactura"].ToString());
            int ndpr = int.Parse(fila_serv["ndpr"].ToString());
            string tipodpr = Formato(fila_serv["tipodpr"].ToString());
            string tipobono = Formato(fila_serv["tipobono"].ToString());
            int unidades = (int)fila_serv["unidades"];
            decimal precio_unitario = (decimal)fila_serv["precio_unitario"];



            string ci = fila_serv["ci"].ToString();
            //Se reculera el id del usuario que hizo la transacción
            int id_usuario_transaccion = 0;
            if (ci != "0")
            {
                cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_usuario] FROM [usuario] WHERE [ci]=@ci),0)");
                db1.AddInParameter(cmd, "ci", DbType.String, ci);
                id_usuario_transaccion = (int)db1.ExecuteScalar(cmd);
            }
            if (id_usuario_transaccion == 0) id_usuario_transaccion = Context_id_usuario;




            //Se obtiene el identificador del contrato: [id_contrato]
            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_contrato] FROM [contrato] WHERE [numero]=@numero),0)");
            db1.AddInParameter(cmd, "numero", DbType.String, ncontrato);
            int id_contrato = (int)db1.ExecuteScalar(cmd);

            if (id_contrato > 0)
            {
                //Se obtiene el identificador del servicio
                cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_servicio] FROM [servicio] WHERE [codigo]=@codigo),0)");
                db1.AddInParameter(cmd, "codigo", DbType.String, tipo2);
                int id_servicio = (int)db1.ExecuteScalar(cmd);

                if (id_servicio > 0)
                {
                    //De ser necesario se obtiene el recibo de cobrador
                    int id_recibocobrador = 0;
                    if (ncontrol > 0)
                    {
                        cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT MIN([id_recibocobrador]) FROM [recibo_cobrador] WHERE [numero]=@numero),0)");
                        db1.AddInParameter(cmd, "numero", DbType.Int32, ncontrol);
                        id_recibocobrador = (int)db1.ExecuteScalar(cmd);
                    }

                    //Se obtiene el id, nombre y nit del titular del contrato
                    int id_cliente = 0; string nombre_cliente = ""; string nit_cliente = "";
                    cmd = db1.GetSqlStringCommand("SELECT c.[id_cliente],([paterno] + ' ' + [materno] + ' ' + [nombres]) as 'nombre', [nit] FROM [cliente] as c, [cliente_contrato] as cc WHERE cc.[id_cliente]=c.[id_cliente] AND cc.[id_contrato]=@id_contrato AND primer_titular=1");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                    DataTable tabla_cliente_titular = db1.ExecuteDataSet(cmd).Tables[0];
                    if (tabla_cliente_titular.Rows.Count > 0)
                    {
                        id_cliente = (int)tabla_cliente_titular.Rows[0]["id_cliente"];
                        nombre_cliente = tabla_cliente_titular.Rows[0]["nombre"].ToString();
                        nit_cliente = tabla_cliente_titular.Rows[0]["nit"].ToString();
                    }

                    //Se obtiene el monto del servicio vendido
                    decimal monto = 0;
                    if (montosus > 0) monto = montosus; else if (montodpr > 0) monto = montodpr; else monto = montobs / tccompra;

                    //Se registra la transacción
                    int id_transaccion = 0;
                    m_transaccion.num_encontrato += 1;
                    try
                    {
                        cmd = db1.GetSqlStringCommand("INSERT INTO [transaccion]([id_moneda],[id_usuario],[id_negocio],[id_negociocontrato],[id_recibocobrador],[fecha],[ntrans],[tipo_cambio],[monto],[comisionable],[anulado]) VALUES (@id_moneda,@id_usuario,@id_negocio,@id_negociocontrato,@id_recibocobrador,@fecha,@ntrans,@tipo_cambio,@monto,@comisionable,@anulado)");
                        db1.AddInParameter(cmd, "id_moneda", DbType.Int32, id_moneda);




                        //db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                        db1.AddInParameter(cmd, "id_usuario", DbType.Int32, id_usuario_transaccion);




                        db1.AddInParameter(cmd, "id_negocio", DbType.Int32, id_negocio_terrasur);
                        db1.AddInParameter(cmd, "id_negociocontrato", DbType.Int32, null);
                        if (id_recibocobrador > 0) db1.AddInParameter(cmd, "id_recibocobrador", DbType.Int32, id_recibocobrador);
                        else db1.AddInParameter(cmd, "id_recibocobrador", DbType.Int32, null);
                        db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                        db1.AddInParameter(cmd, "ntrans", DbType.Int32, n_trans);
                        db1.AddInParameter(cmd, "tipo_cambio", DbType.Decimal, tccompra);
                        db1.AddInParameter(cmd, "monto", DbType.Decimal, monto);
                        if (montodpr > 0) db1.AddInParameter(cmd, "comisionable", DbType.Boolean, false);
                        else db1.AddInParameter(cmd, "comisionable", DbType.Boolean, true);
                        db1.AddInParameter(cmd, "anulado", DbType.Boolean, false);
                        db1.ExecuteNonQuery(cmd);

                        cmd = db1.GetSqlStringCommand("SELECT IDENT_CURRENT('transaccion')");
                        id_transaccion = Int32.Parse(db1.ExecuteScalar(cmd).ToString());

                        m_transaccion.num_migrado += 1;
                    }
                    catch (Exception ex)
                    {
                        m_transaccion.num_error += 1;
                        m_transaccion.NewMens("Error", "[transaccion]", "Nº contrato: " + ncontrato + " ; tipo2: " + tipo2.ToString() + " ; id_contrato: " + id_contrato.ToString() + " ; id_servicio: " + id_servicio.ToString() + " ; Mensaje de error: " + ex.Message);
                    }

                    if (id_transaccion > 0)
                    {
                        //De ser necesario se obtiene el dpr_id_dpr
                        int dpr_id_dpr = 0;
                        if (montodpr > 0 || montobono > 0)
                        {
                            if (montobono > 0)
                            {
                                //Si existe, se obtiene el tipo de bono de la tabla [sat_bonos]
                                string bonos_tipobono = "";
                                cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT MAX([tipobono]) FROM [sat_bonos] WHERE [ncontrato]=@ncontrato AND [n_trans]=@n_trans),'')");
                                db1.AddInParameter(cmd, "ncontrato", DbType.Decimal, decimal.Parse(ncontrato));
                                db1.AddInParameter(cmd, "n_trans", DbType.Decimal, decimal.Parse(n_trans.ToString()));
                                bonos_tipobono = db1.ExecuteScalar(cmd).ToString().Trim();
                                if (bonos_tipobono != "") bonos_tipobono = tipobono;

                                //Se obtiene el Id del "DPR" o "BONO" utilizado
                                if (bonos_tipobono != "")
                                {
                                    cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_dpr] FROM [dpr] WHERE [codigo]=@codigo),0)");
                                    db1.AddInParameter(cmd, "codigo", DbType.String, bonos_tipobono);
                                    dpr_id_dpr = (int)db1.ExecuteScalar(cmd);
                                }
                                else { dpr_id_dpr = id_dpr_sin; }
                            }
                            else
                            {
                                if (tipodpr != "")
                                {
                                    cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_dpr] FROM [dpr] WHERE [codigo]=@codigo),0)");
                                    db1.AddInParameter(cmd, "codigo", DbType.String, tipodpr);
                                    dpr_id_dpr = (int)db1.ExecuteScalar(cmd);
                                }
                                else dpr_id_dpr = id_dpr_sin;
                            }
                        }

                        //Si se empleó un cheque para realizar la transacción se obtienen los datos utilizados
                        int cheque_id_banco = 0; string cheque_numero = ""; decimal cheque_sus = 0; decimal cheque_bs = 0;
                        cmd = db1.GetSqlStringCommand("SELECT [mon_chsu] as 'sus',[mon_chbs] as 'bs',(CASE [mon_chsu] WHEN 0 THEN [num_chbs] ELSE [num_chsu] END) as 'numero',(CASE [mon_chsu] WHEN 0 THEN [bco_chbs] ELSE [bco_chsu] END) as 'banco' FROM [sat_fact_chq] WHERE [ncontrato]=@ncontrato AND [n_trans]=@n_trans AND ([mon_chsu]>0 OR [mon_chbs]>0)");
                        db1.AddInParameter(cmd, "ncontrato", DbType.Decimal, decimal.Parse(ncontrato));
                        db1.AddInParameter(cmd, "n_trans", DbType.Decimal, decimal.Parse(n_trans.ToString()));
                        DataTable tabla_cheque = db1.ExecuteDataSet(cmd).Tables[0];
                        if (tabla_cheque.Rows.Count > 0)
                        {//sus,bs,numero,banco
                            cheque_sus = (decimal)tabla_cheque.Rows[0]["sus"];
                            cheque_bs = (decimal)tabla_cheque.Rows[0]["bs"];
                            cheque_numero = tabla_cheque.Rows[0]["numero"].ToString();
                            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_banco] FROM [banco] WHERE [codigo]=@codigo),0)");
                            db1.AddInParameter(cmd, "codigo", DbType.String, tabla_cheque.Rows[0]["banco"].ToString().Trim());
                            cheque_id_banco = (int)db1.ExecuteScalar(cmd);
                        }

                        //Se registra la forma de pago
                        m_forma_pago.num_encontrato += 1;
                        try
                        {
                            cmd = db1.GetSqlStringCommand("INSERT INTO [forma_pago]([id_transaccion],[dpr],[dpr_sus],[dpr_id_dpr],[efectivo_sus],[efectivo_bs],[deposito_sus],[deposito_bs],[tarjeta_numero],[tarjeta_sus],[tarjeta_bs],[cheque_id_banco],[cheque_numero],[cheque_sus],[cheque_bs]) VALUES(@id_transaccion,@dpr,@dpr_sus,@dpr_id_dpr,@efectivo_sus,@efectivo_bs,0,0,'',0,0,@cheque_id_banco,@cheque_numero,@cheque_sus,@cheque_bs)");
                            db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                            db1.AddInParameter(cmd, "dpr", DbType.Boolean, montodpr.Equals(0).Equals(false));
                            db1.AddInParameter(cmd, "dpr_sus", DbType.Decimal, montodpr);
                            if (dpr_id_dpr > 0) db1.AddInParameter(cmd, "dpr_id_dpr", DbType.Int32, dpr_id_dpr);
                            else db1.AddInParameter(cmd, "dpr_id_dpr", DbType.Int32, null);
                            db1.AddInParameter(cmd, "efectivo_sus", DbType.Decimal, montosus);
                            db1.AddInParameter(cmd, "efectivo_bs", DbType.Decimal, montobs);
                            if (cheque_id_banco > 0) db1.AddInParameter(cmd, "cheque_id_banco", DbType.Int32, cheque_id_banco);
                            else db1.AddInParameter(cmd, "cheque_id_banco", DbType.Int32, null);
                            db1.AddInParameter(cmd, "cheque_numero", DbType.String, cheque_numero);
                            db1.AddInParameter(cmd, "cheque_sus", DbType.Decimal, cheque_sus);
                            db1.AddInParameter(cmd, "cheque_bs", DbType.Decimal, cheque_bs);
                            db1.ExecuteNonQuery(cmd);
                            m_forma_pago.num_migrado += 1;
                        }
                        catch (Exception ex)
                        {
                            m_forma_pago.num_error += 1;
                            m_forma_pago.NewMens("Error", "[forma_pago]", "ncontrato: " + ncontrato + " ; tipo2: " + tipo2 + " ; id_contrato: " + id_contrato.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; id_servicio: " + id_servicio.ToString() + " ; Mensaje de error: " + ex.Message);
                        }

                        //Se registra el recibo, si es necesario y si existe
                        //if (nrecibo > 0)
                        //{
                        //cmd = db1.GetSqlStringCommand("SELECT [fecha],[fechaanu],(CASE [estado] WHEN 'AN' THEN CONVERT(bit,1) ELSE CONVERT(bit,0) END) as 'anulado' FROM [sat_recibos] WHERE [ncontrato]=@ncontrato and [n_trans]=@n_trans and [nrecibo]=@nrecibo");
                        cmd = db1.GetSqlStringCommand("SELECT [nrecibo],[fecha],[fechaanu],(CASE [estado] WHEN 'AN' THEN CONVERT(bit,1) ELSE CONVERT(bit,0) END) as 'anulado' FROM [sat_recibos] WHERE [ncontrato]=@ncontrato and [n_trans]=@n_trans");
                        db1.AddInParameter(cmd, "ncontrato", DbType.Decimal, decimal.Parse(ncontrato));
                        db1.AddInParameter(cmd, "n_trans", DbType.Decimal, decimal.Parse(n_trans.ToString()));
                        //db1.AddInParameter(cmd, "nrecibo", DbType.Decimal, decimal.Parse(nrecibo.ToString()));
                        DataTable tabla_sat_recibos = db1.ExecuteDataSet(cmd).Tables[0];
                        foreach (DataRow fila_recibo in tabla_sat_recibos.Rows)
                        {
                            int r_nrecibo = int.Parse(fila_recibo["nrecibo"].ToString());
                            DateTime r_fecha = (DateTime)fila_recibo["fecha"];
                            DateTime r_fechaanu = (DateTime)fila_recibo["fechaanu"];
                            bool r_anulado = (bool)fila_recibo["anulado"];
                            m_recibo.num_encontrato += 1;
                            try
                            {
                                cmd = db1.GetSqlStringCommand("INSERT INTO [recibo]([id_transaccion],[num_recibo],[fecha],[nombre_cliente],[concepto],[monto_sus],[tipo_cambio],[encabezado],[anulado],[anulado_fecha],[anulado_id_usuario]) VALUES(@id_transaccion,@num_recibo,@fecha,@nombre_cliente,@concepto,@monto_sus,@tipo_cambio,@encabezado,@anulado,@anulado_fecha,@anulado_id_usuario)");
                                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                                db1.AddInParameter(cmd, "num_recibo", DbType.Int32, r_nrecibo);
                                db1.AddInParameter(cmd, "fecha", DbType.DateTime, r_fecha);
                                db1.AddInParameter(cmd, "nombre_cliente", DbType.String, nombre_cliente);
                                db1.AddInParameter(cmd, "concepto", DbType.String, "Pago por venta de servicios");
                                db1.AddInParameter(cmd, "monto_sus", DbType.Decimal, monto);
                                db1.AddInParameter(cmd, "tipo_cambio", DbType.Decimal, tccompra);
                                db1.AddInParameter(cmd, "encabezado", DbType.String, _encabezado);
                                db1.AddInParameter(cmd, "anulado", DbType.Boolean, r_anulado);
                                if (r_anulado == true)
                                {
                                    db1.AddInParameter(cmd, "anulado_fecha", DbType.DateTime, r_fechaanu);
                                    db1.AddInParameter(cmd, "anulado_id_usuario", DbType.Int32, Context_id_usuario);
                                }
                                else
                                {
                                    db1.AddInParameter(cmd, "anulado_fecha", DbType.DateTime, null);
                                    db1.AddInParameter(cmd, "anulado_id_usuario", DbType.Int32, null);
                                }
                                db1.ExecuteNonQuery(cmd);
                                m_recibo.num_migrado += 1;
                            }
                            catch (Exception ex)
                            {
                                m_recibo.num_error += 1;
                                m_recibo.NewMens("Error", "[recibo]", "ncontrato: " + ncontrato + " ; n_trans: " + n_trans.ToString() + " ; id_contrato: " + id_contrato.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; nrecibo: " + nrecibo.ToString() + " ; Mensaje de error: " + ex.Message);
                            }
                        }
                        //}

                        //Se registra la factura, si es necesario y si existe
                        //if (nfactura > 0)
                        //{
                        //cmd = db1.GetSqlStringCommand("SELECT [fecha],[montobs],[tc],[nauto],[ccontrol],[fechaanu],(CASE [estado] WHEN 'AN' THEN CONVERT(bit,1) ELSE CONVERT(bit,0) END) as 'anulado' FROM [sat_facturas] WHERE [ncontrato]=@ncontrato AND [n_trans]=@n_trans AND [nfactura]=@nfactura");
                        cmd = db1.GetSqlStringCommand("SELECT [nfactura],[fecha],[montobs],[tc],[nauto],[ccontrol],[fechaanu],(CASE [estado] WHEN 'AN' THEN CONVERT(bit,1) ELSE CONVERT(bit,0) END) as 'anulado' FROM [sat_facturas] WHERE [ncontrato]=@ncontrato AND [n_trans]=@n_trans");
                        db1.AddInParameter(cmd, "ncontrato", DbType.Decimal, decimal.Parse(ncontrato));
                        db1.AddInParameter(cmd, "n_trans", DbType.Decimal, decimal.Parse(n_trans.ToString()));
                        //db1.AddInParameter(cmd, "nfactura", DbType.Decimal, decimal.Parse(nfactura.ToString()));
                        DataTable tabla_sat_facturas = db1.ExecuteDataSet(cmd).Tables[0];
                        foreach (DataRow fila_factura in tabla_sat_facturas.Rows)
                        {
                            int f_nfactura = int.Parse(fila_factura["nfactura"].ToString());
                            DateTime f_fecha = (DateTime)fila_factura["fecha"];
                            decimal f_montobs = (decimal)fila_factura["montobs"];
                            decimal f_tc = (decimal)fila_factura["tc"];
                            string f_nauto = Formato(fila_factura["nauto"].ToString()); if (f_nauto == "") f_nauto = "0";
                            string f_ccontrol = fila_factura["ccontrol"].ToString();
                            DateTime f_fechaanu = (DateTime)fila_factura["fechaanu"];
                            bool f_anulado = (bool)fila_factura["anulado"];
                            m_factura.num_encontrato += 1;
                            try
                            {
                                cmd = db1.GetSqlStringCommand("INSERT INTO [factura]([id_parametrofacturacion],[id_transaccion],[razon_social],[nit],[fecha_limite],[num_autorizacion],[llave_dosificacion],[encabezado],[num_factura],[fecha],[cliente_nombre],[cliente_nit],[concepto],[monto_bs],[tipo_cambio],[numero_control],[anulado],[anulado_fecha],[anulado_id_usuario]) VALUES(@id_parametrofacturacion,@id_transaccion,@razon_social,@nit,@fecha_limite,@num_autorizacion,@llave_dosificacion,@encabezado,@num_factura,@fecha,@cliente_nombre,@cliente_nit,@concepto,@monto_bs,@tipo_cambio,@numero_control,@anulado,@anulado_fecha,@anulado_id_usuario)");
                                db1.AddInParameter(cmd, "id_parametrofacturacion", DbType.Int32, pf_id_parametrofacturacion);
                                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                                db1.AddInParameter(cmd, "razon_social", DbType.String, pf_razon_social);
                                db1.AddInParameter(cmd, "nit", DbType.Decimal, pf_nit);
                                db1.AddInParameter(cmd, "fecha_limite", DbType.DateTime, pf_fecha_limite);
                                db1.AddInParameter(cmd, "num_autorizacion", DbType.Decimal, decimal.Parse(f_nauto));
                                db1.AddInParameter(cmd, "llave_dosificacion", DbType.String, "");
                                db1.AddInParameter(cmd, "encabezado", DbType.String, _encabezado);

                                db1.AddInParameter(cmd, "num_factura", DbType.Int32, f_nfactura);
                                db1.AddInParameter(cmd, "fecha", DbType.DateTime, f_fecha);
                                db1.AddInParameter(cmd, "cliente_nombre", DbType.String, nombre_cliente);
                                db1.AddInParameter(cmd, "cliente_nit", DbType.Decimal, decimal.Parse(nit_cliente));
                                db1.AddInParameter(cmd, "concepto", DbType.String, "Pago por venta de servicios");
                                db1.AddInParameter(cmd, "monto_bs", DbType.Decimal, f_montobs);
                                db1.AddInParameter(cmd, "tipo_cambio", DbType.Decimal, f_tc);
                                db1.AddInParameter(cmd, "numero_control", DbType.String, f_ccontrol);

                                db1.AddInParameter(cmd, "anulado", DbType.Boolean, f_anulado);
                                if (f_anulado == true)
                                {
                                    db1.AddInParameter(cmd, "anulado_fecha", DbType.DateTime, f_fechaanu);
                                    db1.AddInParameter(cmd, "anulado_id_usuario", DbType.Int32, Context_id_usuario);
                                }
                                else
                                {
                                    db1.AddInParameter(cmd, "anulado_fecha", DbType.DateTime, null);
                                    db1.AddInParameter(cmd, "anulado_id_usuario", DbType.Int32, null);
                                }
                                db1.ExecuteNonQuery(cmd);
                                m_factura.num_migrado += 1;
                            }
                            catch (Exception ex)
                            {
                                m_factura.num_error += 1;
                                m_factura.NewMens("Error", "[factura]", "ncontrato: " + ncontrato + " ; id_contrato: " + id_contrato.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; nfactura: " + nfactura.ToString() + " ; Mensaje de error: " + ex.Message);
                            }
                        }
                        //}

                        //Se registra el comprobante dpr, si es necesario y si existe
                        if (ndpr > 0)
                        {
                            m_comprobante.num_encontrato += 1;
                            try
                            {
                                cmd = db1.GetSqlStringCommand("INSERT INTO [comprobante_dpr]([id_transaccion],[num_comprobante],[fecha],[nombre_cliente],[concepto],[monto_sus],[tipo_cambio],[encabezado],[anulado],[anulado_fecha],[anulado_id_usuario]) VALUES(@id_transaccion,@num_comprobante,@fecha,@nombre_cliente,@concepto,@monto_sus,@tipo_cambio,@encabezado,0,NULL,NULL)");
                                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                                db1.AddInParameter(cmd, "num_comprobante", DbType.Int32, ndpr);
                                db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                                db1.AddInParameter(cmd, "nombre_cliente", DbType.String, nombre_cliente);
                                db1.AddInParameter(cmd, "concepto", DbType.String, "Pago por venta de servicios");
                                db1.AddInParameter(cmd, "monto_sus", DbType.Decimal, monto);
                                db1.AddInParameter(cmd, "tipo_cambio", DbType.Decimal, tccompra);
                                db1.AddInParameter(cmd, "encabezado", DbType.String, _encabezado);
                                db1.ExecuteNonQuery(cmd);
                                m_comprobante.num_migrado += 1;
                            }
                            catch (Exception ex)
                            {
                                m_comprobante.num_error += 1;
                                m_comprobante.NewMens("Error", "[comprobante_dpr]", "ncontrato: " + ncontrato + " ; id_contrato: " + id_contrato.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; ndpr: " + ndpr.ToString() + " ; Mensaje de error: " + ex.Message);
                            }
                        }

                        //Se registra el Servicio Vendido
                        try
                        {
                            cmd = db1.GetSqlStringCommand("INSERT INTO [servicio_vendido]([id_servicio],[id_cliente],[id_transaccion],[id_contrato],[id_liquidacion],[fecha],[num_unidades],[precio_unidad],[precio_total],[facturar],[anulado]) VALUES (@id_servicio,@id_cliente,@id_transaccion,@id_contrato,@id_liquidacion,@fecha,@num_unidades,@precio_unidad,@precio_total,@facturar,@anulado)");
                            //@id_servicio,@id_cliente,@id_transaccion,@id_contrato,@id_liquidacion,@fecha,
                            //@num_unidades,@precio_unidad,@precio_total,@facturar,@anulado
                            db1.AddInParameter(cmd, "id_servicio", DbType.Int32, id_servicio);
                            db1.AddInParameter(cmd, "id_cliente", DbType.Int32, id_cliente);
                            db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                            db1.AddInParameter(cmd, "id_liquidacion", DbType.Int32, null);
                            db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);

                            db1.AddInParameter(cmd, "num_unidades", DbType.Int32, unidades);
                            db1.AddInParameter(cmd, "precio_unidad", DbType.Decimal, precio_unitario);
                            db1.AddInParameter(cmd, "precio_total", DbType.Decimal, monto);
                            db1.AddInParameter(cmd, "facturar", DbType.Boolean, nfactura.Equals(0).Equals(false));
                            db1.AddInParameter(cmd, "anulado", DbType.Boolean, false);
                            db1.ExecuteNonQuery(cmd);
                            m_servicio.num_migrado += 1;
                        }
                        catch (Exception ex)
                        {
                            m_servicio.num_error += 1;
                            m_servicio.NewMens("Error", "[servicio_vendido]", "ncontrato: " + ncontrato + " ; id_contrato: " + id_contrato.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; Mensaje de error: " + ex.Message);
                        }
                    }
                }
                else
                {
                    m_servicio.num_error += 1;
                    m_servicio.NewMens("Error (servicio inexistente)", "[servicio_vendido]", "ncontrato: " + ncontrato + " ; n_trans: " + n_trans.ToString() + " ; tipo2: " + tipo2);
                }
            }
            else
            {
                m_servicio.num_error += 1;
                m_servicio.NewMens("Error (contrato inexistente)", "[contrato]", "ncontrato: " + ncontrato + " ; n_trans: " + n_trans.ToString() + " ; tipo2: " + tipo2);
            }
        }

        return m_servicio.Datos() + m_transaccion.Datos() + m_forma_pago.Datos() + m_recibo.Datos() +
            m_factura.Datos() + m_comprobante.Datos();
    }

    public static string MigrarOtrosServiciosCliTemp(int Context_id_usuario)
    {
        migracionResumen m_servicio = new migracionResumen("Servicios Vendidos a clientes transitorios", true);
        migracionResumen m_transaccion = new migracionResumen("Transacciones");
        migracionResumen m_forma_pago = new migracionResumen("Forma de pago");
        migracionResumen m_recibo = new migracionResumen("Recibo");
        migracionResumen m_factura = new migracionResumen("Factura");
        migracionResumen m_comprobante = new migracionResumen("Comprobante DPR");

        //Parámetros generales necesarios
        DbCommand cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_moneda] FROM [moneda] WHERE [codigo]='$us'),0)");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        int id_moneda = (int)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_dpr] FROM [dpr] WHERE [codigo]='SIN'),0)");
        int id_dpr_sin = (int)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT [id_negocio] FROM [negocio] WHERE [codigo]='terra'");
        int id_negocio_terrasur = (int)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT TOP 1 [id_parametrofacturacion],[razon_social],[nit],[fecha_limite] FROM [parametro_facturacion] ORDER BY [id_parametrofacturacion]");
        DataTable tabla_par_fact = db1.ExecuteDataSet(cmd).Tables[0];
        int pf_id_parametrofacturacion = 0; string pf_razon_social = ""; decimal pf_nit = 0; DateTime pf_fecha_limite = DateTime.Now;

        if (tabla_par_fact.Rows.Count > 0)
        {
            pf_id_parametrofacturacion = (int)tabla_par_fact.Rows[0]["id_parametrofacturacion"];
            pf_razon_social = tabla_par_fact.Rows[0]["razon_social"].ToString();
            pf_nit = (decimal)tabla_par_fact.Rows[0]["nit"];
            pf_fecha_limite = (DateTime)tabla_par_fact.Rows[0]["fecha_limite"];
        }

        //Servicios vendidos
        //ncontrato,n_trans,fecha,tipo2,tccompra,montosus,montobs,montodpr,montobono,ncontrol,nrecibo,nfactura,ndpr,tipodpr,tipobono,ruc,nombre,paterno
        //cmd = db1.GetSqlStringCommand("SELECT [ncontrato],[n_trans],[fecha],[tipo2],[tccompra],[montosus],[montobs],[montodpr],[montobono],[ncontrol],[nrecibo],[nfactura],[ndpr],[tipodpr],[tipobono],(SELECT [ruc] FROM [sat_cli_temp] WHERE [n_trans]=f.[n_trans]) as 'ruc',(SELECT [nombre] FROM [sat_cli_temp] WHERE [n_trans]=f.[n_trans]) as 'nombre',(SELECT [paterno] FROM [sat_cli_temp] WHERE [n_trans]=f.[n_trans]) as 'paterno' FROM [sat_facturac] as f WHERE tipo='OTR' AND [n_trans] IN (SELECT [n_trans] FROM [sat_cli_temp])");
        cmd = db1.GetSqlStringCommand("SELECT [ncontrato],[n_trans],[fecha],[tipo2],[tccompra],[montosus],[montobs],[montodpr],[montobono],[ncontrol],[nrecibo],[nfactura],[ndpr],[tipodpr],[tipobono],(SELECT [ruc] FROM [sat_cli_temp] WHERE [n_trans]=f.[n_trans]) as 'ruc',(SELECT [nombre] FROM [sat_cli_temp] WHERE [n_trans]=f.[n_trans]) as 'nombre',(SELECT [paterno] FROM [sat_cli_temp] WHERE [n_trans]=f.[n_trans]) as 'paterno',[ci] FROM [sat_facturac] as f WHERE tipo='OTR' AND [n_trans] IN (SELECT [n_trans] FROM [sat_cli_temp])");

        DataTable tabla_servicio_vendido = db1.ExecuteDataSet(cmd).Tables[0];
        foreach (DataRow fila_serv in tabla_servicio_vendido.Rows)
        {
            m_servicio.num_encontrato += 1;
            string ncontrato = fila_serv["ncontrato"].ToString();
            int n_trans = int.Parse(fila_serv["n_trans"].ToString());
            DateTime fecha = (DateTime)fila_serv["fecha"];
            string tipo2 = Formato(fila_serv["tipo2"].ToString());
            decimal tccompra = (decimal)fila_serv["tccompra"];
            decimal montosus = (decimal)fila_serv["montosus"];
            decimal montobs = (decimal)fila_serv["montobs"];
            decimal montodpr = (decimal)fila_serv["montodpr"];
            decimal montobono = (decimal)fila_serv["montobono"];
            int ncontrol = int.Parse(fila_serv["ncontrol"].ToString());
            int nrecibo = int.Parse(fila_serv["nrecibo"].ToString());
            int nfactura = int.Parse(fila_serv["nfactura"].ToString());
            int ndpr = int.Parse(fila_serv["ndpr"].ToString());
            string tipodpr = Formato(fila_serv["tipodpr"].ToString());
            string tipobono = Formato(fila_serv["tipobono"].ToString());
            decimal ruc = (decimal)fila_serv["ruc"];
            string nombre = Formato(fila_serv["nombre"].ToString());
            string paterno = Formato(fila_serv["paterno"].ToString());




            string ci = fila_serv["ci"].ToString();
            //Se reculera el id del usuario que hizo la transacción
            int id_usuario_transaccion = 0;
            if (ci != "0")
            {
                cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_usuario] FROM [usuario] WHERE [ci]=@ci),0)");
                db1.AddInParameter(cmd, "ci", DbType.String, ci);
                id_usuario_transaccion = (int)db1.ExecuteScalar(cmd);
            }
            if (id_usuario_transaccion == 0) id_usuario_transaccion = Context_id_usuario;




            //Se obtiene el identificador del cliente: [id_cliente]
            int id_cliente = 0;
            if (ruc > 0)
            {
                cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT MIN([id_cliente]) FROM [cliente] WHERE [transitorio]=1 AND [nit]=@nit),0)");
                db1.AddInParameter(cmd, "nit", DbType.String, ruc.ToString());
                id_cliente = (int)db1.ExecuteScalar(cmd);
            }
            else
            {
                cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT MIN([id_cliente]) FROM [cliente] WHERE [transitorio]=1 AND [nombres]=@nombres AND [paterno]=@paterno),0)");
                db1.AddInParameter(cmd, "nombres", DbType.String, nombre);
                db1.AddInParameter(cmd, "paterno", DbType.String, paterno);
                id_cliente = (int)db1.ExecuteScalar(cmd);
            }

            if (id_cliente > 0)
            {
                //Se obtiene el identificador del servicio
                cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_servicio] FROM [servicio] WHERE [codigo]=@codigo),0)");
                db1.AddInParameter(cmd, "codigo", DbType.String, tipo2);
                int id_servicio = (int)db1.ExecuteScalar(cmd);

                if (id_servicio > 0)
                {
                    //De ser necesario se obtiene el recibo de cobrador
                    int id_recibocobrador = 0;
                    if (ncontrol > 0)
                    {
                        cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT MIN([id_recibocobrador]) FROM [recibo_cobrador] WHERE [numero]=@numero),0)");
                        db1.AddInParameter(cmd, "numero", DbType.Int32, ncontrol);
                        id_recibocobrador = (int)db1.ExecuteScalar(cmd);
                    }

                    //Se obtiene el monto del servicio vendido
                    decimal monto = 0;
                    if (montosus > 0) monto = montosus; else if (montodpr > 0) monto = montodpr; else monto = montobs / tccompra;

                    //Se registra la transacción
                    int id_transaccion = 0;
                    m_transaccion.num_encontrato += 1;
                    try
                    {
                        cmd = db1.GetSqlStringCommand("INSERT INTO [transaccion]([id_moneda],[id_usuario],[id_negocio],[id_negociocontrato],[id_recibocobrador],[fecha],[ntrans],[tipo_cambio],[monto],[comisionable],[anulado]) VALUES (@id_moneda,@id_usuario,@id_negocio,@id_negociocontrato,@id_recibocobrador,@fecha,@ntrans,@tipo_cambio,@monto,@comisionable,@anulado)");
                        db1.AddInParameter(cmd, "id_moneda", DbType.Int32, id_moneda);



                        //db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                        db1.AddInParameter(cmd, "id_usuario", DbType.Int32, id_usuario_transaccion);



                        db1.AddInParameter(cmd, "id_negocio", DbType.Int32, id_negocio_terrasur);
                        db1.AddInParameter(cmd, "id_negociocontrato", DbType.Int32, null);
                        if (id_recibocobrador > 0) db1.AddInParameter(cmd, "id_recibocobrador", DbType.Int32, id_recibocobrador);
                        else db1.AddInParameter(cmd, "id_recibocobrador", DbType.Int32, null);
                        db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                        db1.AddInParameter(cmd, "ntrans", DbType.Int32, n_trans);
                        db1.AddInParameter(cmd, "tipo_cambio", DbType.Decimal, tccompra);
                        db1.AddInParameter(cmd, "monto", DbType.Decimal, monto);
                        if (montodpr > 0) db1.AddInParameter(cmd, "comisionable", DbType.Boolean, false);
                        else db1.AddInParameter(cmd, "comisionable", DbType.Boolean, true);
                        db1.AddInParameter(cmd, "anulado", DbType.Boolean, false);
                        db1.ExecuteNonQuery(cmd);

                        cmd = db1.GetSqlStringCommand("SELECT IDENT_CURRENT('transaccion')");
                        id_transaccion = Int32.Parse(db1.ExecuteScalar(cmd).ToString());

                        m_transaccion.num_migrado += 1;
                    }
                    catch (Exception ex)
                    {
                        m_transaccion.num_error += 1;
                        m_transaccion.NewMens("Error", "[transaccion]", "n_trans: " + n_trans.ToString() + " ; tipo2: " + tipo2.ToString() + " ; id_servicio: " + id_servicio.ToString() + " ; Mensaje de error: " + ex.Message);
                    }

                    if (id_transaccion > 0)
                    {
                        //De ser necesario se obtiene el dpr_id_dpr
                        int dpr_id_dpr = 0;
                        if (montodpr > 0 || montobono > 0)
                        {
                            if (montobono > 0)
                            {
                                //Si existe, se obtiene el tipo de bono de la tabla [sat_bonos]
                                string bonos_tipobono = "";
                                cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT MAX([tipobono]) FROM [sat_bonos] WHERE [ncontrato]=@ncontrato AND [n_trans]=@n_trans),'')");
                                db1.AddInParameter(cmd, "ncontrato", DbType.Decimal, decimal.Parse(ncontrato));
                                db1.AddInParameter(cmd, "n_trans", DbType.Decimal, decimal.Parse(n_trans.ToString()));
                                bonos_tipobono = db1.ExecuteScalar(cmd).ToString().Trim();
                                if (bonos_tipobono != "") bonos_tipobono = tipobono;

                                //Se obtiene el Id del "DPR" o "BONO" utilizado
                                if (bonos_tipobono != "")
                                {
                                    cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_dpr] FROM [dpr] WHERE [codigo]=@codigo),0)");
                                    db1.AddInParameter(cmd, "codigo", DbType.String, bonos_tipobono);
                                    dpr_id_dpr = (int)db1.ExecuteScalar(cmd);
                                }
                                else { dpr_id_dpr = id_dpr_sin; }
                            }
                            else
                            {
                                if (tipodpr != "")
                                {
                                    cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_dpr] FROM [dpr] WHERE [codigo]=@codigo),0)");
                                    db1.AddInParameter(cmd, "codigo", DbType.String, tipodpr);
                                    dpr_id_dpr = (int)db1.ExecuteScalar(cmd);
                                }
                                else dpr_id_dpr = id_dpr_sin;
                            }
                        }

                        //Si se empleó un cheque para realizar la transacción se obtienen los datos utilizados
                        int cheque_id_banco = 0; string cheque_numero = ""; decimal cheque_sus = 0; decimal cheque_bs = 0;
                        cmd = db1.GetSqlStringCommand("SELECT [mon_chsu] as 'sus',[mon_chbs] as 'bs',(CASE [mon_chsu] WHEN 0 THEN [num_chbs] ELSE [num_chsu] END) as 'numero',(CASE [mon_chsu] WHEN 0 THEN [bco_chbs] ELSE [bco_chsu] END) as 'banco' FROM [sat_fact_chq] WHERE [ncontrato]=@ncontrato AND [n_trans]=@n_trans AND ([mon_chsu]>0 OR [mon_chbs]>0)");
                        db1.AddInParameter(cmd, "ncontrato", DbType.Decimal, decimal.Parse(ncontrato));
                        db1.AddInParameter(cmd, "n_trans", DbType.Decimal, decimal.Parse(n_trans.ToString()));
                        DataTable tabla_cheque = db1.ExecuteDataSet(cmd).Tables[0];
                        if (tabla_cheque.Rows.Count > 0)
                        {//sus,bs,numero,banco
                            cheque_sus = (decimal)tabla_cheque.Rows[0]["sus"];
                            cheque_bs = (decimal)tabla_cheque.Rows[0]["bs"];
                            cheque_numero = tabla_cheque.Rows[0]["numero"].ToString();
                            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_banco] FROM [banco] WHERE [codigo]=@codigo),0)");
                            db1.AddInParameter(cmd, "codigo", DbType.String, tabla_cheque.Rows[0]["banco"].ToString().Trim());
                            cheque_id_banco = (int)db1.ExecuteScalar(cmd);
                        }

                        //Se registra la forma de pago
                        m_forma_pago.num_encontrato += 1;
                        try
                        {
                            cmd = db1.GetSqlStringCommand("INSERT INTO [forma_pago]([id_transaccion],[dpr],[dpr_sus],[dpr_id_dpr],[efectivo_sus],[efectivo_bs],[deposito_sus],[deposito_bs],[tarjeta_numero],[tarjeta_sus],[tarjeta_bs],[cheque_id_banco],[cheque_numero],[cheque_sus],[cheque_bs]) VALUES(@id_transaccion,@dpr,@dpr_sus,@dpr_id_dpr,@efectivo_sus,@efectivo_bs,0,0,'',0,0,@cheque_id_banco,@cheque_numero,@cheque_sus,@cheque_bs)");
                            db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                            db1.AddInParameter(cmd, "dpr", DbType.Boolean, montodpr.Equals(0).Equals(false));
                            db1.AddInParameter(cmd, "dpr_sus", DbType.Decimal, montodpr);
                            if (dpr_id_dpr > 0) db1.AddInParameter(cmd, "dpr_id_dpr", DbType.Int32, dpr_id_dpr);
                            else db1.AddInParameter(cmd, "dpr_id_dpr", DbType.Int32, null);
                            db1.AddInParameter(cmd, "efectivo_sus", DbType.Decimal, montosus);
                            db1.AddInParameter(cmd, "efectivo_bs", DbType.Decimal, montobs);
                            if (cheque_id_banco > 0) db1.AddInParameter(cmd, "cheque_id_banco", DbType.Int32, cheque_id_banco);
                            else db1.AddInParameter(cmd, "cheque_id_banco", DbType.Int32, null);
                            db1.AddInParameter(cmd, "cheque_numero", DbType.String, cheque_numero);
                            db1.AddInParameter(cmd, "cheque_sus", DbType.Decimal, cheque_sus);
                            db1.AddInParameter(cmd, "cheque_bs", DbType.Decimal, cheque_bs);
                            db1.ExecuteNonQuery(cmd);
                            m_forma_pago.num_migrado += 1;
                        }
                        catch (Exception ex)
                        {
                            m_forma_pago.num_error += 1;
                            m_forma_pago.NewMens("Error", "[forma_pago]", "n_trans: " + n_trans.ToString() + " ; tipo2: " + tipo2 + " ; id_transaccion: " + id_transaccion.ToString() + " ; id_servicio: " + id_servicio.ToString() + " ; Mensaje de error: " + ex.Message);
                        }

                        //Se registra el recibo, si es necesario y si existe
                        //if (nrecibo > 0)
                        //{
                        //cmd = db1.GetSqlStringCommand("SELECT [fecha],[fechaanu],(CASE [estado] WHEN 'AN' THEN CONVERT(bit,1) ELSE CONVERT(bit,0) END) as 'anulado' FROM [sat_recibos] WHERE [ncontrato]=@ncontrato and [n_trans]=@n_trans and [nrecibo]=@nrecibo");
                        cmd = db1.GetSqlStringCommand("SELECT [nrecibo],[fecha],[fechaanu],(CASE [estado] WHEN 'AN' THEN CONVERT(bit,1) ELSE CONVERT(bit,0) END) as 'anulado' FROM [sat_recibos] WHERE [ncontrato]=@ncontrato and [n_trans]=@n_trans");
                        db1.AddInParameter(cmd, "ncontrato", DbType.Decimal, decimal.Parse(ncontrato));
                        db1.AddInParameter(cmd, "n_trans", DbType.Decimal, decimal.Parse(n_trans.ToString()));
                        //db1.AddInParameter(cmd, "nrecibo", DbType.Decimal, decimal.Parse(nrecibo.ToString()));
                        DataTable tabla_sat_recibos = db1.ExecuteDataSet(cmd).Tables[0];
                        foreach (DataRow fila_recibo in tabla_sat_recibos.Rows)
                        {
                            int r_nrecibo = int.Parse(fila_recibo["nrecibo"].ToString());
                            DateTime r_fecha = (DateTime)fila_recibo["fecha"];
                            DateTime r_fechaanu = (DateTime)fila_recibo["fechaanu"];
                            bool r_anulado = (bool)fila_recibo["anulado"];
                            m_recibo.num_encontrato += 1;
                            try
                            {
                                cmd = db1.GetSqlStringCommand("INSERT INTO [recibo]([id_transaccion],[num_recibo],[fecha],[nombre_cliente],[concepto],[monto_sus],[tipo_cambio],[encabezado],[anulado],[anulado_fecha],[anulado_id_usuario]) VALUES(@id_transaccion,@num_recibo,@fecha,@nombre_cliente,@concepto,@monto_sus,@tipo_cambio,@encabezado,@anulado,@anulado_fecha,@anulado_id_usuario)");
                                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                                db1.AddInParameter(cmd, "num_recibo", DbType.Int32, r_nrecibo);
                                db1.AddInParameter(cmd, "fecha", DbType.DateTime, r_fecha);
                                db1.AddInParameter(cmd, "nombre_cliente", DbType.String, nombre + " " + paterno);
                                db1.AddInParameter(cmd, "concepto", DbType.String, "Pago por venta de servicio");
                                db1.AddInParameter(cmd, "monto_sus", DbType.Decimal, monto);
                                db1.AddInParameter(cmd, "tipo_cambio", DbType.Decimal, tccompra);
                                db1.AddInParameter(cmd, "encabezado", DbType.String, _encabezado);
                                db1.AddInParameter(cmd, "anulado", DbType.Boolean, r_anulado);
                                if (r_anulado == true)
                                {
                                    db1.AddInParameter(cmd, "anulado_fecha", DbType.DateTime, r_fechaanu);
                                    db1.AddInParameter(cmd, "anulado_id_usuario", DbType.Int32, Context_id_usuario);
                                }
                                else
                                {
                                    db1.AddInParameter(cmd, "anulado_fecha", DbType.DateTime, null);
                                    db1.AddInParameter(cmd, "anulado_id_usuario", DbType.Int32, null);
                                }
                                db1.ExecuteNonQuery(cmd);
                                m_recibo.num_migrado += 1;
                            }
                            catch (Exception ex)
                            {
                                m_recibo.num_error += 1;
                                m_recibo.NewMens("Error", "[recibo]", "n_trans: " + n_trans.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; nrecibo: " + nrecibo.ToString() + " ; Mensaje de error: " + ex.Message);
                            }
                        }
                        //}

                        //Se registra la factura, si es necesario y si existe
                        //if (nfactura > 0)
                        //{
                        //cmd = db1.GetSqlStringCommand("SELECT [fecha],[montobs],[tc],[nauto],[ccontrol],[fechaanu],(CASE [estado] WHEN 'AN' THEN CONVERT(bit,1) ELSE CONVERT(bit,0) END) as 'anulado' FROM [sat_facturas] WHERE [ncontrato]=@ncontrato AND [n_trans]=@n_trans AND [nfactura]=@nfactura");
                        cmd = db1.GetSqlStringCommand("SELECT [nfactura],[fecha],[montobs],[tc],[nauto],[ccontrol],[fechaanu],(CASE [estado] WHEN 'AN' THEN CONVERT(bit,1) ELSE CONVERT(bit,0) END) as 'anulado' FROM [sat_facturas] WHERE [ncontrato]=@ncontrato AND [n_trans]=@n_trans");
                        db1.AddInParameter(cmd, "ncontrato", DbType.Decimal, decimal.Parse(ncontrato));
                        db1.AddInParameter(cmd, "n_trans", DbType.Decimal, decimal.Parse(n_trans.ToString()));
                        //db1.AddInParameter(cmd, "nfactura", DbType.Decimal, decimal.Parse(nfactura.ToString()));
                        DataTable tabla_sat_facturas = db1.ExecuteDataSet(cmd).Tables[0];
                        foreach (DataRow fila_factura in tabla_sat_facturas.Rows)
                        {
                            int f_nfactura = int.Parse(fila_factura["nfactura"].ToString());
                            DateTime f_fecha = (DateTime)fila_factura["fecha"];
                            decimal f_montobs = (decimal)fila_factura["montobs"];
                            decimal f_tc = (decimal)fila_factura["tc"];
                            string f_nauto = Formato(fila_factura["nauto"].ToString()); if (f_nauto == "") f_nauto = "0";
                            string f_ccontrol = fila_factura["ccontrol"].ToString();
                            DateTime f_fechaanu = (DateTime)fila_factura["fechaanu"];
                            bool f_anulado = (bool)fila_factura["anulado"];
                            m_factura.num_encontrato += 1;
                            try
                            {
                                cmd = db1.GetSqlStringCommand("INSERT INTO [factura]([id_parametrofacturacion],[id_transaccion],[razon_social],[nit],[fecha_limite],[num_autorizacion],[llave_dosificacion],[encabezado],[num_factura],[fecha],[cliente_nombre],[cliente_nit],[concepto],[monto_bs],[tipo_cambio],[numero_control],[anulado],[anulado_fecha],[anulado_id_usuario]) VALUES(@id_parametrofacturacion,@id_transaccion,@razon_social,@nit,@fecha_limite,@num_autorizacion,@llave_dosificacion,@encabezado,@num_factura,@fecha,@cliente_nombre,@cliente_nit,@concepto,@monto_bs,@tipo_cambio,@numero_control,@anulado,@anulado_fecha,@anulado_id_usuario)");
                                db1.AddInParameter(cmd, "id_parametrofacturacion", DbType.Int32, pf_id_parametrofacturacion);
                                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                                db1.AddInParameter(cmd, "razon_social", DbType.String, pf_razon_social);
                                db1.AddInParameter(cmd, "nit", DbType.Decimal, pf_nit);
                                db1.AddInParameter(cmd, "fecha_limite", DbType.DateTime, pf_fecha_limite);
                                db1.AddInParameter(cmd, "num_autorizacion", DbType.Decimal, decimal.Parse(f_nauto));
                                db1.AddInParameter(cmd, "llave_dosificacion", DbType.String, "");
                                db1.AddInParameter(cmd, "encabezado", DbType.String, _encabezado);

                                db1.AddInParameter(cmd, "num_factura", DbType.Int32, f_nfactura);
                                db1.AddInParameter(cmd, "fecha", DbType.DateTime, f_fecha);
                                db1.AddInParameter(cmd, "cliente_nombre", DbType.String, nombre + " " + paterno);
                                db1.AddInParameter(cmd, "cliente_nit", DbType.Decimal, ruc);
                                db1.AddInParameter(cmd, "concepto", DbType.String, "Pago por venta de servicio");
                                db1.AddInParameter(cmd, "monto_bs", DbType.Decimal, f_montobs);
                                db1.AddInParameter(cmd, "tipo_cambio", DbType.Decimal, f_tc);
                                db1.AddInParameter(cmd, "numero_control", DbType.String, f_ccontrol);

                                db1.AddInParameter(cmd, "anulado", DbType.Boolean, f_anulado);
                                if (f_anulado == true)
                                {
                                    db1.AddInParameter(cmd, "anulado_fecha", DbType.DateTime, f_fechaanu);
                                    db1.AddInParameter(cmd, "anulado_id_usuario", DbType.Int32, Context_id_usuario);
                                }
                                else
                                {
                                    db1.AddInParameter(cmd, "anulado_fecha", DbType.DateTime, null);
                                    db1.AddInParameter(cmd, "anulado_id_usuario", DbType.Int32, null);
                                }
                                db1.ExecuteNonQuery(cmd);
                                m_factura.num_migrado += 1;
                            }
                            catch (Exception ex)
                            {
                                m_factura.num_error += 1;
                                m_factura.NewMens("Error", "[factura]", "n_trans: " + n_trans.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; nfactura: " + nfactura.ToString() + " ; Mensaje de error: " + ex.Message);
                            }
                        }
                        //}

                        //Se registra el comprobante dpr, si es necesario y si existe
                        if (ndpr > 0)
                        {
                            m_comprobante.num_encontrato += 1;
                            try
                            {
                                cmd = db1.GetSqlStringCommand("INSERT INTO [comprobante_dpr]([id_transaccion],[num_comprobante],[fecha],[nombre_cliente],[concepto],[monto_sus],[tipo_cambio],[encabezado],[anulado],[anulado_fecha],[anulado_id_usuario]) VALUES(@id_transaccion,@num_comprobante,@fecha,@nombre_cliente,@concepto,@monto_sus,@tipo_cambio,@encabezado,0,NULL,NULL)");
                                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                                db1.AddInParameter(cmd, "num_comprobante", DbType.Int32, ndpr);
                                db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                                db1.AddInParameter(cmd, "nombre_cliente", DbType.String, nombre + " " + paterno);
                                db1.AddInParameter(cmd, "concepto", DbType.String, "Pago por venta de servicio");
                                db1.AddInParameter(cmd, "monto_sus", DbType.Decimal, monto);
                                db1.AddInParameter(cmd, "tipo_cambio", DbType.Decimal, tccompra);
                                db1.AddInParameter(cmd, "encabezado", DbType.String, _encabezado);
                                db1.ExecuteNonQuery(cmd);
                                m_comprobante.num_migrado += 1;
                            }
                            catch (Exception ex)
                            {
                                m_comprobante.num_error += 1;
                                m_comprobante.NewMens("Error", "[comprobante_dpr]", "n_trans: " + n_trans.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; ndpr: " + ndpr.ToString() + " ; Mensaje de error: " + ex.Message);
                            }
                        }

                        //Se registra el Servicio Vendido
                        try
                        {
                            cmd = db1.GetSqlStringCommand("INSERT INTO [servicio_vendido]([id_servicio],[id_cliente],[id_transaccion],[id_contrato],[id_liquidacion],[fecha],[num_unidades],[precio_unidad],[precio_total],[facturar],[anulado]) VALUES (@id_servicio,@id_cliente,@id_transaccion,@id_contrato,@id_liquidacion,@fecha,@num_unidades,@precio_unidad,@precio_total,@facturar,@anulado)");
                            //@id_servicio,@id_cliente,@id_transaccion,@id_contrato,@id_liquidacion,@fecha,
                            //@num_unidades,@precio_unidad,@precio_total,@facturar,@anulado
                            db1.AddInParameter(cmd, "id_servicio", DbType.Int32, id_servicio);
                            db1.AddInParameter(cmd, "id_cliente", DbType.Int32, id_cliente);
                            db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, null);
                            db1.AddInParameter(cmd, "id_liquidacion", DbType.Int32, null);
                            db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);

                            db1.AddInParameter(cmd, "num_unidades", DbType.Int32, 1);
                            db1.AddInParameter(cmd, "precio_unidad", DbType.Decimal, monto);
                            db1.AddInParameter(cmd, "precio_total", DbType.Decimal, monto);
                            db1.AddInParameter(cmd, "facturar", DbType.Boolean, nfactura.Equals(0).Equals(false));
                            db1.AddInParameter(cmd, "anulado", DbType.Boolean, false);
                            db1.ExecuteNonQuery(cmd);
                            m_servicio.num_migrado += 1;
                        }
                        catch (Exception ex)
                        {
                            m_servicio.num_error += 1;
                            m_servicio.NewMens("Error", "[servicio_vendido]", "n_trans: " + n_trans.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; Mensaje de error: " + ex.Message);
                        }
                    }
                }
                else
                {
                    m_servicio.num_error += 1;
                    m_servicio.NewMens("Error (servicio inexistente)", "[servicio_vendido]", "ncontrato: " + ncontrato + " ; n_trans: " + n_trans.ToString() + " ; tipo2: " + tipo2);
                }
            }
            else
            {
                m_servicio.num_error += 1;
                m_servicio.NewMens("Error (cliente inexistente)", "[cliente]", "ruc: " + ruc.ToString() + " ; nombre: " + nombre + " ; paterno: " + paterno + " ; n_trans: " + n_trans.ToString() + " ; tipo2: " + tipo2);
            }
        }

        return m_servicio.Datos() + m_transaccion.Datos() + m_forma_pago.Datos() + m_recibo.Datos() +
            m_factura.Datos() + m_comprobante.Datos();
    }

    public static string MigrarPagoMora(int Context_id_usuario)
    {
        migracionResumen m_intemora = new migracionResumen("Pago de Intereses Penales (Mora)", true);
        migracionResumen m_transaccion = new migracionResumen("Transacciones");
        migracionResumen m_forma_pago = new migracionResumen("Forma de pago");
        migracionResumen m_recibo = new migracionResumen("Recibo");
        migracionResumen m_factura = new migracionResumen("Factura");
        migracionResumen m_comprobante = new migracionResumen("Comprobante DPR");

        //Parámetros generales necesarios
        DbCommand cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_moneda] FROM [moneda] WHERE [codigo]='$us'),0)");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        int id_moneda = (int)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_dpr] FROM [dpr] WHERE [codigo]='SIN'),0)");
        int id_dpr_sin = (int)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT [id_negocio] FROM [negocio] WHERE [codigo]='terra'");
        int id_negocio_terrasur = (int)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT TOP 1 [id_parametrofacturacion],[razon_social],[nit],[fecha_limite] FROM [parametro_facturacion] ORDER BY [id_parametrofacturacion]");
        DataTable tabla_par_fact = db1.ExecuteDataSet(cmd).Tables[0];
        int pf_id_parametrofacturacion = 0; string pf_razon_social = ""; decimal pf_nit = 0; DateTime pf_fecha_limite = DateTime.Now;
        if (tabla_par_fact.Rows.Count > 0)
        {
            pf_id_parametrofacturacion = (int)tabla_par_fact.Rows[0]["id_parametrofacturacion"];
            pf_razon_social = tabla_par_fact.Rows[0]["razon_social"].ToString();
            pf_nit = (decimal)tabla_par_fact.Rows[0]["nit"];
            pf_fecha_limite = (DateTime)tabla_par_fact.Rows[0]["fecha_limite"];
        }

        //Pagos de Intereses Penales 
        //ncontrato,n_trans,fecha,intemora,tccompra,montosus,montobs,montodpr,
        //montobono,ncontrol,nrecibo,nfactura,ndpr,tipodpr,tipobono
        cmd = db1.GetSqlStringCommand("SELECT f.[ncontrato],f.[n_trans],f.[fecha],f.[intemora],f.[tccompra],f.[montosus],f.[montobs],f.[montodpr],f.[montobono],f.[ncontrol],im.[recibo] as 'nrecibo',im.[factura] as 'nfactura',f.[ndpr],f.[tipodpr],f.[tipobono] FROM [sat_facturac] as f, [sat_intemora] as im WHERE f.[intemora]>0 AND f.[ncontrato]=im.[ncontrato] AND f.[n_trans]=im.[n_trans] UNION SELECT f.[ncontrato],f.[n_trans],f.[fecha],f.[intemora],f.[tccompra],f.[montosus],f.[montobs],f.[montodpr],f.[montobono],f.[ncontrol],f.[nrecibo],f.[nfactura],f.[ndpr],f.[tipodpr],f.[tipobono] FROM [sat_facturac] as f WHERE f.[intemora]>0 AND (SELECT COUNT([montosus]) FROM [sat_intemora] WHERE [ncontrato]=f.[ncontrato] AND [n_trans]=f.[n_trans])=0");
        DataTable tabla_intemora = db1.ExecuteDataSet(cmd).Tables[0];
        foreach (DataRow fila_intemora in tabla_intemora.Rows)
        {
            m_intemora.num_encontrato += 1;
            string ncontrato = fila_intemora["ncontrato"].ToString();
            int n_trans = int.Parse(fila_intemora["n_trans"].ToString());
            DateTime fecha = (DateTime)fila_intemora["fecha"];
            decimal intemora = (decimal)fila_intemora["intemora"];
            decimal tccompra = (decimal)fila_intemora["tccompra"];
            decimal montosus = (decimal)fila_intemora["montosus"];
            decimal montobs = (decimal)fila_intemora["montobs"];
            decimal montodpr = (decimal)fila_intemora["montodpr"];
            decimal montobono = (decimal)fila_intemora["montobono"];
            int ncontrol = int.Parse(fila_intemora["ncontrol"].ToString());
            int nrecibo = int.Parse(fila_intemora["nrecibo"].ToString());
            int nfactura = int.Parse(fila_intemora["nfactura"].ToString());
            int ndpr = int.Parse(fila_intemora["ndpr"].ToString());
            string tipodpr = Formato(fila_intemora["tipodpr"].ToString());
            string tipobono = Formato(fila_intemora["tipobono"].ToString());

            //De ser necesario se extrae el monto pagado por concepto de amortización e interés
            if (montodpr == 0)
            {
                if (montosus > 0 && montobs == 0) montosus = intemora;
                else if (montosus == 0 && montobs > 0) montobs = intemora * tccompra;
                else
                {
                    if (Math.Round(montobs / tccompra, 2) == intemora) montosus = 0;
                    else if (montosus == intemora) montobs = 0;
                    else { montosus = intemora; montobs = 0; }
                }
            }
            else if (montosus == 0 && montobs == 0) { montodpr = intemora; }
            else
            {
                if (montodpr == intemora) { montosus = 0; montobs = 0; }
                else if (montosus == intemora) { montobs = 0; montodpr = 0; }
                //else { montosus = intemora; montobs = 0; montodpr = 0; }
                else { montodpr = intemora; montosus = 0; montobs = 0; }
            }
            if (montodpr == 0) montobono = 0;

            //Se obtiene el identificador del contrato: [id_contrato]
            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_contrato] FROM [contrato] WHERE [numero]=@numero),0)");
            db1.AddInParameter(cmd, "numero", DbType.String, ncontrato);
            int id_contrato = (int)db1.ExecuteScalar(cmd);

            if (id_contrato > 0)
            {
                ////Temporalmente se enlaza al pago inicial:
                //cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT MIN([id_pago]) FROM [pago] WHERE [id_contrato]=@id_contrato),0)");
                //db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);

                //Se obtiene el identificador del pago
                cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT p.[id_pago] FROM [pago] as p, [transaccion] as t WHERE p.[id_contrato]=@id_contrato AND p.[id_transaccion]=t.[id_transaccion] AND t.[ntrans]=@ntrans),0)");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                db1.AddInParameter(cmd, "ntrans", DbType.Int32, n_trans);
                int id_pago = (int)db1.ExecuteScalar(cmd);

                if (id_pago > 0)
                {
                    //De ser necesario se obtiene el recibo de cobrador
                    int id_recibocobrador = 0;
                    if (ncontrol > 0)
                    {
                        cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT MIN([id_recibocobrador]) FROM [recibo_cobrador] WHERE [numero]=@numero),0)");
                        db1.AddInParameter(cmd, "numero", DbType.Int32, ncontrol);
                        id_recibocobrador = (int)db1.ExecuteScalar(cmd);
                    }

                    //Se obtiene el id, nombre y nit del titular del contrato
                    int id_cliente = 0; string nombre_cliente = ""; string nit_cliente = "";
                    cmd = db1.GetSqlStringCommand("SELECT c.[id_cliente],([paterno] + ' ' + [materno] + ' ' + [nombres]) as 'nombre', [nit] FROM [cliente] as c, [cliente_contrato] as cc WHERE cc.[id_cliente]=c.[id_cliente] AND cc.[id_contrato]=@id_contrato AND primer_titular=1");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                    DataTable tabla_cliente_titular = db1.ExecuteDataSet(cmd).Tables[0];
                    if (tabla_cliente_titular.Rows.Count > 0)
                    {
                        id_cliente = (int)tabla_cliente_titular.Rows[0]["id_cliente"];
                        nombre_cliente = tabla_cliente_titular.Rows[0]["nombre"].ToString();
                        nit_cliente = tabla_cliente_titular.Rows[0]["nit"].ToString();
                    }

                    //Se registra la transacción
                    int id_transaccion = 0;
                    m_transaccion.num_encontrato += 1;
                    try
                    {
                        cmd = db1.GetSqlStringCommand("INSERT INTO [transaccion]([id_moneda],[id_usuario],[id_negocio],[id_negociocontrato],[id_recibocobrador],[fecha],[ntrans],[tipo_cambio],[monto],[comisionable],[anulado]) VALUES (@id_moneda,@id_usuario,@id_negocio,@id_negociocontrato,@id_recibocobrador,@fecha,@ntrans,@tipo_cambio,@monto,@comisionable,@anulado)");
                        db1.AddInParameter(cmd, "id_moneda", DbType.Int32, id_moneda);
                        db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                        db1.AddInParameter(cmd, "id_negocio", DbType.Int32, id_negocio_terrasur);
                        db1.AddInParameter(cmd, "id_negociocontrato", DbType.Int32, null);
                        if (id_recibocobrador > 0) db1.AddInParameter(cmd, "id_recibocobrador", DbType.Int32, id_recibocobrador);
                        else db1.AddInParameter(cmd, "id_recibocobrador", DbType.Int32, null);
                        db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                        db1.AddInParameter(cmd, "ntrans", DbType.Int32, n_trans);
                        db1.AddInParameter(cmd, "tipo_cambio", DbType.Decimal, tccompra);
                        db1.AddInParameter(cmd, "monto", DbType.Decimal, intemora);
                        if (montodpr > 0) db1.AddInParameter(cmd, "comisionable", DbType.Boolean, false);
                        else db1.AddInParameter(cmd, "comisionable", DbType.Boolean, true);
                        db1.AddInParameter(cmd, "anulado", DbType.Boolean, false);
                        db1.ExecuteNonQuery(cmd);

                        cmd = db1.GetSqlStringCommand("SELECT IDENT_CURRENT('transaccion')");
                        id_transaccion = Int32.Parse(db1.ExecuteScalar(cmd).ToString());

                        m_transaccion.num_migrado += 1;
                    }
                    catch (Exception ex)
                    {
                        m_transaccion.num_error += 1;
                        m_transaccion.NewMens("Error", "[transaccion]", "Nº contrato: " + ncontrato + " ; n_trans: " + n_trans.ToString() + " ; id_contrato: " + id_contrato.ToString() + " ; intemora: " + intemora.ToString() + " ; Mensaje de error: " + ex.Message);
                    }

                    if (id_transaccion > 0)
                    {
                        //De ser necesario se obtiene el dpr_id_dpr
                        int dpr_id_dpr = 0;
                        if (montodpr > 0 || montobono > 0)
                        {
                            if (montobono > 0)
                            {
                                //Si existe, se obtiene el tipo de bono de la tabla [sat_bonos]
                                string bonos_tipobono = "";
                                cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT MAX([tipobono]) FROM [sat_bonos] WHERE [ncontrato]=@ncontrato AND [n_trans]=@n_trans),'')");
                                db1.AddInParameter(cmd, "ncontrato", DbType.Decimal, decimal.Parse(ncontrato));
                                db1.AddInParameter(cmd, "n_trans", DbType.Decimal, decimal.Parse(n_trans.ToString()));
                                bonos_tipobono = db1.ExecuteScalar(cmd).ToString().Trim();
                                if (bonos_tipobono != "") bonos_tipobono = tipobono;

                                //Se obtiene el Id del "DPR" o "BONO" utilizado
                                if (bonos_tipobono != "")
                                {
                                    cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_dpr] FROM [dpr] WHERE [codigo]=@codigo),0)");
                                    db1.AddInParameter(cmd, "codigo", DbType.String, bonos_tipobono);
                                    dpr_id_dpr = (int)db1.ExecuteScalar(cmd);
                                }
                                else { dpr_id_dpr = id_dpr_sin; }
                            }
                            else
                            {
                                if (tipodpr != "")
                                {
                                    cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_dpr] FROM [dpr] WHERE [codigo]=@codigo),0)");
                                    db1.AddInParameter(cmd, "codigo", DbType.String, tipodpr);
                                    dpr_id_dpr = (int)db1.ExecuteScalar(cmd);
                                }
                                else dpr_id_dpr = id_dpr_sin;
                            }
                        }

                        //Si se empleó un cheque para realizar la transacción se obtienen los datos utilizados
                        int cheque_id_banco = 0; string cheque_numero = ""; decimal cheque_sus = 0; decimal cheque_bs = 0;
                        cmd = db1.GetSqlStringCommand("SELECT [mon_chsu] as 'sus',[mon_chbs] as 'bs',(CASE [mon_chsu] WHEN 0 THEN [num_chbs] ELSE [num_chsu] END) as 'numero',(CASE [mon_chsu] WHEN 0 THEN [bco_chbs] ELSE [bco_chsu] END) as 'banco' FROM [sat_fact_chq] WHERE [ncontrato]=@ncontrato AND [n_trans]=@n_trans AND ([mon_chsu]>0 OR [mon_chbs]>0)");
                        db1.AddInParameter(cmd, "ncontrato", DbType.Decimal, decimal.Parse(ncontrato));
                        db1.AddInParameter(cmd, "n_trans", DbType.Decimal, decimal.Parse(n_trans.ToString()));
                        DataTable tabla_cheque = db1.ExecuteDataSet(cmd).Tables[0];
                        if (tabla_cheque.Rows.Count > 0)
                        {//sus,bs,numero,banco
                            cheque_sus = (decimal)tabla_cheque.Rows[0]["sus"];
                            cheque_bs = (decimal)tabla_cheque.Rows[0]["bs"];
                            cheque_numero = tabla_cheque.Rows[0]["numero"].ToString();
                            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_banco] FROM [banco] WHERE [codigo]=@codigo),0)");
                            db1.AddInParameter(cmd, "codigo", DbType.String, tabla_cheque.Rows[0]["banco"].ToString().Trim());
                            cheque_id_banco = (int)db1.ExecuteScalar(cmd);
                        }

                        //Se registra la forma de pago
                        m_forma_pago.num_encontrato += 1;
                        try
                        {
                            cmd = db1.GetSqlStringCommand("INSERT INTO [forma_pago]([id_transaccion],[dpr],[dpr_sus],[dpr_id_dpr],[efectivo_sus],[efectivo_bs],[deposito_sus],[deposito_bs],[tarjeta_numero],[tarjeta_sus],[tarjeta_bs],[cheque_id_banco],[cheque_numero],[cheque_sus],[cheque_bs]) VALUES(@id_transaccion,@dpr,@dpr_sus,@dpr_id_dpr,@efectivo_sus,@efectivo_bs,0,0,'',0,0,@cheque_id_banco,@cheque_numero,@cheque_sus,@cheque_bs)");
                            db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                            db1.AddInParameter(cmd, "dpr", DbType.Boolean, montodpr.Equals(0).Equals(false));
                            db1.AddInParameter(cmd, "dpr_sus", DbType.Decimal, montodpr);
                            if (dpr_id_dpr > 0) db1.AddInParameter(cmd, "dpr_id_dpr", DbType.Int32, dpr_id_dpr);
                            else db1.AddInParameter(cmd, "dpr_id_dpr", DbType.Int32, null);
                            db1.AddInParameter(cmd, "efectivo_sus", DbType.Decimal, montosus);
                            db1.AddInParameter(cmd, "efectivo_bs", DbType.Decimal, montobs);
                            if (cheque_id_banco > 0) db1.AddInParameter(cmd, "cheque_id_banco", DbType.Int32, cheque_id_banco);
                            else db1.AddInParameter(cmd, "cheque_id_banco", DbType.Int32, null);
                            db1.AddInParameter(cmd, "cheque_numero", DbType.String, cheque_numero);
                            db1.AddInParameter(cmd, "cheque_sus", DbType.Decimal, cheque_sus);
                            db1.AddInParameter(cmd, "cheque_bs", DbType.Decimal, cheque_bs);
                            db1.ExecuteNonQuery(cmd);
                            m_forma_pago.num_migrado += 1;
                        }
                        catch (Exception ex)
                        {
                            m_forma_pago.num_error += 1;
                            m_forma_pago.NewMens("Error", "[forma_pago]", "ncontrato: " + ncontrato + " ; n_trans: " + n_trans + " ; id_contrato: " + id_contrato.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; intemora: " + intemora.ToString() + " ; Mensaje de error: " + ex.Message);
                        }

                        //Se registra el recibo, si es necesario y si existe
                        //if (nrecibo > 0)
                        //{
                        //cmd = db1.GetSqlStringCommand("SELECT [fecha],[fechaanu],(CASE [estado] WHEN 'AN' THEN CONVERT(bit,1) ELSE CONVERT(bit,0) END) as 'anulado' FROM [sat_recibos] WHERE [ncontrato]=@ncontrato and [n_trans]=@n_trans and [nrecibo]=@nrecibo");
                        cmd = db1.GetSqlStringCommand("SELECT [nrecibo],[fecha],[fechaanu],(CASE [estado] WHEN 'AN' THEN CONVERT(bit,1) ELSE CONVERT(bit,0) END) as 'anulado' FROM [sat_recibos] WHERE [ncontrato]=@ncontrato and [n_trans]=@n_trans");
                        db1.AddInParameter(cmd, "ncontrato", DbType.Decimal, decimal.Parse(ncontrato));
                        db1.AddInParameter(cmd, "n_trans", DbType.Decimal, decimal.Parse(n_trans.ToString()));
                        //db1.AddInParameter(cmd, "nrecibo", DbType.Decimal, decimal.Parse(nrecibo.ToString()));
                        DataTable tabla_sat_recibos = db1.ExecuteDataSet(cmd).Tables[0];
                        foreach (DataRow fila_recibo in tabla_sat_recibos.Rows)
                        {
                            int r_nrecibo = int.Parse(fila_recibo["nrecibo"].ToString());
                            DateTime r_fecha = (DateTime)fila_recibo["fecha"];
                            DateTime r_fechaanu = (DateTime)fila_recibo["fechaanu"];
                            bool r_anulado = (bool)fila_recibo["anulado"];
                            m_recibo.num_encontrato += 1;
                            try
                            {
                                cmd = db1.GetSqlStringCommand("INSERT INTO [recibo]([id_transaccion],[num_recibo],[fecha],[nombre_cliente],[concepto],[monto_sus],[tipo_cambio],[encabezado],[anulado],[anulado_fecha],[anulado_id_usuario]) VALUES(@id_transaccion,@num_recibo,@fecha,@nombre_cliente,@concepto,@monto_sus,@tipo_cambio,@encabezado,@anulado,@anulado_fecha,@anulado_id_usuario)");
                                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                                db1.AddInParameter(cmd, "num_recibo", DbType.Int32, r_nrecibo);
                                db1.AddInParameter(cmd, "fecha", DbType.DateTime, r_fecha);
                                db1.AddInParameter(cmd, "nombre_cliente", DbType.String, nombre_cliente);
                                db1.AddInParameter(cmd, "concepto", DbType.String, "Pago de interés penal");
                                db1.AddInParameter(cmd, "monto_sus", DbType.Decimal, intemora);
                                db1.AddInParameter(cmd, "tipo_cambio", DbType.Decimal, tccompra);
                                db1.AddInParameter(cmd, "encabezado", DbType.String, _encabezado);
                                db1.AddInParameter(cmd, "anulado", DbType.Boolean, r_anulado);
                                if (r_anulado == true)
                                {
                                    db1.AddInParameter(cmd, "anulado_fecha", DbType.DateTime, r_fechaanu);
                                    db1.AddInParameter(cmd, "anulado_id_usuario", DbType.Int32, Context_id_usuario);
                                }
                                else
                                {
                                    db1.AddInParameter(cmd, "anulado_fecha", DbType.DateTime, null);
                                    db1.AddInParameter(cmd, "anulado_id_usuario", DbType.Int32, null);
                                }
                                db1.ExecuteNonQuery(cmd);
                                m_recibo.num_migrado += 1;
                            }
                            catch (Exception ex)
                            {
                                m_recibo.num_error += 1;
                                m_recibo.NewMens("Error", "[recibo]", "ncontrato: " + ncontrato + " ; n_trans: " + n_trans.ToString() + " ; id_contrato: " + id_contrato.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; nrecibo: " + nrecibo.ToString() + " ; Mensaje de error: " + ex.Message);
                            }
                        }
                        //}

                        //Se registra la factura, si es necesario y si existe
                        //if (nfactura > 0)
                        //{
                        //cmd = db1.GetSqlStringCommand("SELECT [fecha],[montobs],[tc],[nauto],[ccontrol],[fechaanu],(CASE [estado] WHEN 'AN' THEN CONVERT(bit,1) ELSE CONVERT(bit,0) END) as 'anulado' FROM [sat_facturas] WHERE [ncontrato]=@ncontrato AND [n_trans]=@n_trans AND [nfactura]=@nfactura");
                        cmd = db1.GetSqlStringCommand("SELECT [nfactura],[fecha],[montobs],[tc],[nauto],[ccontrol],[fechaanu],(CASE [estado] WHEN 'AN' THEN CONVERT(bit,1) ELSE CONVERT(bit,0) END) as 'anulado' FROM [sat_facturas] WHERE [ncontrato]=@ncontrato AND [n_trans]=@n_trans");
                        db1.AddInParameter(cmd, "ncontrato", DbType.Decimal, decimal.Parse(ncontrato));
                        db1.AddInParameter(cmd, "n_trans", DbType.Decimal, decimal.Parse(n_trans.ToString()));
                        //db1.AddInParameter(cmd, "nfactura", DbType.Decimal, decimal.Parse(nfactura.ToString()));
                        DataTable tabla_sat_facturas = db1.ExecuteDataSet(cmd).Tables[0];
                        foreach (DataRow fila_factura in tabla_sat_facturas.Rows)
                        {
                            int f_nfactura = int.Parse(fila_factura["nfactura"].ToString());
                            DateTime f_fecha = (DateTime)fila_factura["fecha"];
                            decimal f_montobs = (decimal)fila_factura["montobs"];
                            decimal f_tc = (decimal)fila_factura["tc"];
                            string f_nauto = Formato(fila_factura["nauto"].ToString()); if (f_nauto == "") f_nauto = "0";
                            string f_ccontrol = fila_factura["ccontrol"].ToString();
                            DateTime f_fechaanu = (DateTime)fila_factura["fechaanu"];
                            bool f_anulado = (bool)fila_factura["anulado"];
                            m_factura.num_encontrato += 1;
                            try
                            {
                                cmd = db1.GetSqlStringCommand("INSERT INTO [factura]([id_parametrofacturacion],[id_transaccion],[razon_social],[nit],[fecha_limite],[num_autorizacion],[llave_dosificacion],[encabezado],[num_factura],[fecha],[cliente_nombre],[cliente_nit],[concepto],[monto_bs],[tipo_cambio],[numero_control],[anulado],[anulado_fecha],[anulado_id_usuario]) VALUES(@id_parametrofacturacion,@id_transaccion,@razon_social,@nit,@fecha_limite,@num_autorizacion,@llave_dosificacion,@encabezado,@num_factura,@fecha,@cliente_nombre,@cliente_nit,@concepto,@monto_bs,@tipo_cambio,@numero_control,@anulado,@anulado_fecha,@anulado_id_usuario)");
                                db1.AddInParameter(cmd, "id_parametrofacturacion", DbType.Int32, pf_id_parametrofacturacion);
                                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                                db1.AddInParameter(cmd, "razon_social", DbType.String, pf_razon_social);
                                db1.AddInParameter(cmd, "nit", DbType.Decimal, pf_nit);
                                db1.AddInParameter(cmd, "fecha_limite", DbType.DateTime, pf_fecha_limite);
                                db1.AddInParameter(cmd, "num_autorizacion", DbType.Decimal, decimal.Parse(f_nauto));
                                db1.AddInParameter(cmd, "llave_dosificacion", DbType.String, "");
                                db1.AddInParameter(cmd, "encabezado", DbType.String, _encabezado);

                                db1.AddInParameter(cmd, "num_factura", DbType.Int32, f_nfactura);
                                db1.AddInParameter(cmd, "fecha", DbType.DateTime, f_fecha);
                                db1.AddInParameter(cmd, "cliente_nombre", DbType.String, nombre_cliente);
                                db1.AddInParameter(cmd, "cliente_nit", DbType.Decimal, decimal.Parse(nit_cliente));
                                db1.AddInParameter(cmd, "concepto", DbType.String, "Pago de interés penal");
                                db1.AddInParameter(cmd, "monto_bs", DbType.Decimal, f_montobs);
                                db1.AddInParameter(cmd, "tipo_cambio", DbType.Decimal, f_tc);
                                db1.AddInParameter(cmd, "numero_control", DbType.String, f_ccontrol);

                                db1.AddInParameter(cmd, "anulado", DbType.Boolean, f_anulado);
                                if (f_anulado == true)
                                {
                                    db1.AddInParameter(cmd, "anulado_fecha", DbType.DateTime, f_fechaanu);
                                    db1.AddInParameter(cmd, "anulado_id_usuario", DbType.Int32, Context_id_usuario);
                                }
                                else
                                {
                                    db1.AddInParameter(cmd, "anulado_fecha", DbType.DateTime, null);
                                    db1.AddInParameter(cmd, "anulado_id_usuario", DbType.Int32, null);
                                }
                                db1.ExecuteNonQuery(cmd);
                                m_factura.num_migrado += 1;
                            }
                            catch (Exception ex)
                            {
                                m_factura.num_error += 1;
                                m_factura.NewMens("Error", "[factura]", "ncontrato: " + ncontrato + " ; id_contrato: " + id_contrato.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; nfactura: " + nfactura.ToString() + " ; Mensaje de error: " + ex.Message);
                            }
                        }
                        //}

                        //Se registra el comprobante dpr, si es necesario y si existe
                        if (ndpr > 0 && montodpr > 0)
                        {
                            m_comprobante.num_encontrato += 1;
                            try
                            {
                                cmd = db1.GetSqlStringCommand("INSERT INTO [comprobante_dpr]([id_transaccion],[num_comprobante],[fecha],[nombre_cliente],[concepto],[monto_sus],[tipo_cambio],[encabezado],[anulado],[anulado_fecha],[anulado_id_usuario]) VALUES(@id_transaccion,@num_comprobante,@fecha,@nombre_cliente,@concepto,@monto_sus,@tipo_cambio,@encabezado,0,NULL,NULL)");
                                db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                                db1.AddInParameter(cmd, "num_comprobante", DbType.Int32, ndpr);
                                db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                                db1.AddInParameter(cmd, "nombre_cliente", DbType.String, nombre_cliente);
                                db1.AddInParameter(cmd, "concepto", DbType.String, "Pago de interés penal");
                                db1.AddInParameter(cmd, "monto_sus", DbType.Decimal, intemora);
                                db1.AddInParameter(cmd, "tipo_cambio", DbType.Decimal, tccompra);
                                db1.AddInParameter(cmd, "encabezado", DbType.String, _encabezado);
                                db1.ExecuteNonQuery(cmd);
                                m_comprobante.num_migrado += 1;
                            }
                            catch (Exception ex)
                            {
                                m_comprobante.num_error += 1;
                                m_comprobante.NewMens("Error", "[comprobante_dpr]", "ncontrato: " + ncontrato + " ; id_contrato: " + id_contrato.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; ndpr: " + ndpr.ToString() + " ; Mensaje de error: " + ex.Message);
                            }
                        }

                        //Se registra el Pago de interés penal
                        try
                        {
                            cmd = db1.GetSqlStringCommand("INSERT INTO [pago_mora]([id_pago],[id_transaccion],[fecha],[num_dias],[num_cuotas],[monto_pagar],[monto_pagado]) VALUES (@id_pago,@id_transaccion,@fecha,@num_dias,@num_cuotas,@monto_pagar,@monto_pagado)");
                            //@id_pago,@id_transaccion,@fecha,@num_dias,@num_cuotas,@monto_pagar,@monto_pagado
                            db1.AddInParameter(cmd, "id_pago", DbType.Int32, id_pago);
                            db1.AddInParameter(cmd, "id_transaccion", DbType.Int32, id_transaccion);
                            db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                            db1.AddInParameter(cmd, "num_dias", DbType.Int32, 0);
                            db1.AddInParameter(cmd, "num_cuotas", DbType.Int32, 0);
                            db1.AddInParameter(cmd, "monto_pagar", DbType.Decimal, intemora);
                            db1.AddInParameter(cmd, "monto_pagado", DbType.Decimal, intemora);
                            db1.ExecuteNonQuery(cmd);
                            m_intemora.num_migrado += 1;
                        }
                        catch (Exception ex)
                        {
                            m_intemora.num_error += 1;
                            m_intemora.NewMens("Error", "[pago_mora]", "ncontrato: " + ncontrato + " ; n_trans: " + n_trans.ToString() + " ; id_contrato: " + id_contrato.ToString() + " ; id_transaccion: " + id_transaccion.ToString() + " ; Mensaje de error: " + ex.Message);
                        }
                    }
                }
                else
                {
                    m_intemora.num_error += 1;
                    m_intemora.NewMens("Error (pago inexistente)", "[pago]", "ncontrato: " + ncontrato + " ; n_trans: " + n_trans.ToString() + " ; intemora: " + intemora.ToString());
                }
            }
            else
            {
                m_intemora.num_error += 1;
                m_intemora.NewMens("Error (contrato inexistente)", "[contrato]", "ncontrato: " + ncontrato + " ; n_trans: " + n_trans.ToString() + " ; intemora: " + intemora.ToString());
            }
        }
        return m_intemora.Datos() + m_transaccion.Datos() + m_forma_pago.Datos() + m_recibo.Datos() +
            m_factura.Datos() + m_comprobante.Datos();
    }
    /*
    public static string MigrarContratosNafibo(int Context_id_usuario)
    {
        migracionResumen m_nafibo = new migracionResumen("Contratos Nafibo", true);

        //Parámetros generales necesarios
        DbCommand cmd = db1.GetSqlStringCommand("SELECT [id_negocio] FROM [negocio] WHERE [codigo]='terra'");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        int id_negocio_terrasur = (int)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT [id_negocio] FROM [negocio] WHERE [codigo]='nafibo'");
        int id_negocio_nafibo = (int)db1.ExecuteScalar(cmd);

        cmd = db1.GetSqlStringCommand("SELECT [ncontrato] FROM [sat_cli_naf] ORDER BY 1");
        DataTable tabla_sat_cli_naf = db1.ExecuteDataSet(cmd).Tables[0];
        foreach (DataRow fila_naf in tabla_sat_cli_naf.Rows)
        {
            m_nafibo.num_encontrato += 1;

            string ncontrato = fila_naf["ncontrato"].ToString();

            //Se obtiene el identificador del contrato: [id_contrato]
            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_contrato] FROM [contrato] WHERE [numero]=@numero),0)");
            db1.AddInParameter(cmd, "numero", DbType.String, ncontrato);
            int id_contrato = (int)db1.ExecuteScalar(cmd);

            if (id_contrato > 0)
            {
                //Se verifica si el contrato ya fue transferido a Nafibo
                cmd = db1.GetSqlStringCommand("SELECT COUNT([id_negociocontrato]) FROM [negocio_contrato] WHERE [id_negocio]=@id_negocio AND [id_contrato]=@id_contrato");
                db1.AddInParameter(cmd, "id_negocio", DbType.Int32, id_negocio_nafibo);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                if ((int)db1.ExecuteScalar(cmd) == 0)
                {
                    //Se obtiene el identificador del último pago realizado
                    cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT MAX([id_pago]) FROM [pago] WHERE [id_contrato]=@id_contrato),0)");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                    int id_pago = (int)db1.ExecuteScalar(cmd);
                    if (id_pago > 0)
                    {
                        try
                        {
                            cmd = db1.GetStoredProcCommand("contrato_Transferir");
                            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                            db1.AddInParameter(cmd, "id_negocio", DbType.Int32, id_negocio_nafibo);
                            db1.AddInParameter(cmd, "id_pago", DbType.Int32, id_pago);
                            db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Context_id_usuario);
                            db1.ExecuteNonQuery(cmd);
                            m_nafibo.num_migrado += 1;
                        }
                        catch (Exception ex)
                        {
                            m_nafibo.num_error += 1;
                            m_nafibo.NewMens("Error (transferencia incorrecta)", "", "ncontrato: " + ncontrato + " ; id_contrato: " + id_contrato.ToString() + " ; Mensaje de error: " + ex.Message);
                        }
                    }
                    else
                    {
                        m_nafibo.num_error += 1;
                        m_nafibo.NewMens("Error (contrato no existen pagos)", "[pago]", "ncontrato: " + ncontrato + " ; id_contrato: " + id_contrato.ToString());
                    }
                }
                else
                {
                    m_nafibo.num_repetido += 1;
                    //m_nafibo.NewMens("Repetido", "[negocio_contrato]", "ncontrato: " + ncontrato + " ; id_contrato: " + id_contrato.ToString());
                }
            }
            else
            {
                m_nafibo.num_error += 1;
                m_nafibo.NewMens("Error (contrato inexistente)", "[contrato]", "ncontrato: " + ncontrato);
            }
        }

        return m_nafibo.Datos();
    }
*/

    public static string MigrarContratosNafibo(int Context_id_usuario)
    {
        migracionResumen m_nafibo = new migracionResumen("Contratos Nafibo", true);

        //Parámetros generales necesarios
        DbCommand cmd = db1.GetSqlStringCommand("SELECT [id_negocio] FROM [negocio] WHERE [codigo]='nafibo'");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        int id_negocio_nafibo = (int)db1.ExecuteScalar(cmd);

        cmd = db1.GetSqlStringCommand("SELECT [fecha],[ncontrato],[saldo_real] FROM [finanzas_nafibo] ORDER BY [fecha]");
        DataTable tabla_sat_cli_naf = db1.ExecuteDataSet(cmd).Tables[0];
        foreach (DataRow fila_naf in tabla_sat_cli_naf.Rows)
        {
            m_nafibo.num_encontrato += 1;
            DateTime fecha = (DateTime)fila_naf["fecha"];
            string ncontrato = fila_naf["ncontrato"].ToString();
            Decimal saldo_real = (decimal)fila_naf["saldo_real"];
            try
            {
                cmd = db1.GetStoredProcCommand("migracion_TransferirNafibo");
                db1.AddInParameter(cmd, "ncontrato", DbType.String, ncontrato);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                db1.AddInParameter(cmd, "saldo_real", DbType.Decimal, saldo_real);
                db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, Context_id_usuario);
                db1.AddInParameter(cmd, "id_negocio_nafibo", DbType.Int32, id_negocio_nafibo);
                db1.ExecuteNonQuery(cmd);
                m_nafibo.num_migrado += 1;
            }
            catch (Exception ex)
            {
                m_nafibo.num_error += 1;
                m_nafibo.NewMens("Error (transferencia incorrecta)", "", "ncontrato: " + ncontrato + " ; fecha: " + fecha.ToString("d") + " ; saldo_real: " + saldo_real.ToString("F2") + " ; Mensaje de error: " + ex.Message);
            }
        }
        return m_nafibo.Datos();
    }

    public static string MigrarPromotorComisionesRestantes()
    {
        migracionResumen m_comision = new migracionResumen("Comisiones restantes a promotores", true);

        DbCommand cmd = db1.GetSqlStringCommand("SELECT ISNULL([ncontrato],'') as ncontrato,ISNULL([promotor_ci],'') as promotor_ci,ISNULL([comision_total],0) as comision_total,ISNULL([comision_inicial],0) as comision_inicial,ISNULL([num_cuotas_total],0) as num_cuotas_total,ISNULL([num_cuotas_restante],0) as num_cuotas_restante,ISNULL([saldo_restante],0) as saldo_restante FROM [marketing_comision]");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
        foreach (DataRow fila in tabla.Rows)
        {
            m_comision.num_encontrato += 1;
            string ncontrato = fila["ncontrato"].ToString();
            string promotor_ci = fila["promotor_ci"].ToString();
            decimal comision_total = (decimal)fila["comision_total"];
            decimal comision_inicial = (decimal)fila["comision_inicial"];
            int num_cuotas_total = (int)fila["num_cuotas_total"];
            int num_cuotas_restante = (int)fila["num_cuotas_restante"];
            decimal saldo_restante = (decimal)fila["saldo_restante"];

            //Se obtiene los identificadores del contrato y del promotor
            int id_contrato = 0;
            int id_promotor = 0;
            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_contrato] FROM [contrato] WHERE [numero]=@ncontrato),0)");
            db1.AddInParameter(cmd, "ncontrato", DbType.String, ncontrato);
            id_contrato = (int)db1.ExecuteScalar(cmd);
            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_usuario] FROM [usuario] WHERE [ci]=@promotor_ci),0)");
            db1.AddInParameter(cmd, "promotor_ci", DbType.String, promotor_ci);
            id_promotor = (int)db1.ExecuteScalar(cmd);
            if (id_contrato > 0)
            {
                if (id_promotor > 0)
                {
                    try
                    {
                        cmd = db1.GetStoredProcCommand("migracion_PromotorAsignacion");
                        db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                        db1.AddInParameter(cmd, "id_promotor", DbType.Int32, id_promotor);
                        db1.AddInParameter(cmd, "comision_total", DbType.Decimal, comision_total);
                        db1.AddInParameter(cmd, "comision_inicial", DbType.Decimal, comision_inicial);
                        db1.AddInParameter(cmd, "num_cuotas_total", DbType.Int32, num_cuotas_total);
                        db1.AddInParameter(cmd, "num_cuotas_restante", DbType.Int32, num_cuotas_restante);
                        db1.AddInParameter(cmd, "saldo_restante", DbType.Decimal, saldo_restante);
                        if ((int)db1.ExecuteScalar(cmd) > 0) m_comision.num_migrado += 1;
                        else
                        {
                            m_comision.NewMens("Error", "Asignacion del promotor", "Asignación incorrecta, Contrato: " + ncontrato + ", Promotor: " + promotor_ci);
                            m_comision.num_error += 1;
                        }
                    }
                    catch (Exception Ex)
                    {
                        m_comision.NewMens("Error", "", "Asignación incorrecta, Contrato: " + ncontrato + ", Promotor: " + promotor_ci + ", mensaje de error: " + Ex.Message);
                        m_comision.num_error += 1;
                    }
                }
                else
                {
                    m_comision.NewMens("Error", "Promotor", "El promotor con CI " + promotor_ci + " no existe");
                    m_comision.num_error += 1;
                }
            }
            else
            {
                m_comision.NewMens("Error", "Contrato", "El contrato Nº " + ncontrato + " no existe");
                m_comision.num_error += 1;
            }
        }
        return m_comision.Datos();
    }

    public static string MigrarAjusteContratoSinCliente(int Context_id_usuario)
    {
        migracionResumen m_cliente_contrato = new migracionResumen("Creación de un cliente INEXISTENTE para contratos sin titular", true);

        DbCommand cmd = db1.GetSqlStringCommand("SELECT c.[id_contrato] FROM [contrato] as c WHERE (SELECT COUNT([id_cliente]) FROM [cliente_contrato] WHERE [id_contrato]=c.[id_contrato] AND [primer_titular]=1)=0");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_contrato = db1.ExecuteDataSet(cmd).Tables[0];
        if (tabla_contrato.Rows.Count > 0)
        {
            //Creación del cliente "INEXISTENTE"
            int id_cliente = 0;
            try
            {
                cmd = db1.GetSqlStringCommand("INSERT INTO [cliente]([id_lugarcedula],[id_lugarcobro],[id_usuario],[ci],[nit],[nombres],[paterno],[materno],[fecha_nacimiento],[celular],[fax],[email],[casilla],[domicilio_direccion],[domicilio_fono],[domicilio_id_zona],[oficina_direccion],[oficina_fono],[oficina_id_zona],[transitorio]) VALUES(NULL,NULL,@id_usuario,'','0','INEXISTENTE','INEXISTENTE','INEXISTENTE',NULL,'','','','','','',NULL,'','',NULL,1)");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                //Se recupera el [id_cliente]
                cmd = db1.GetSqlStringCommand("SELECT IDENT_CURRENT('cliente')");
                id_cliente = int.Parse(db1.ExecuteScalar(cmd).ToString());
            }
            catch (Exception ex)
            {
                m_cliente_contrato.num_encontrato = tabla_contrato.Rows.Count;
                m_cliente_contrato.num_error += 1;
                m_cliente_contrato.NewMens("Error", "[cliente]", "No se insertó correctamente el cliente INEXISTENTE ; Mensaje de error: " + ex.Message);
            }
            //Se asignan los contrato al cliente
            if (id_cliente > 0)
            {
                foreach (DataRow fila in tabla_contrato.Rows)
                {
                    m_cliente_contrato.num_encontrato += 1;
                    int id_contrato = (int)fila["id_contrato"];
                    try
                    {
                        cmd = db1.GetSqlStringCommand("INSERT INTO [cliente_contrato]([id_cliente],[id_contrato],[primer_titular]) VALUES(@id_cliente,@id_contrato,@primer_titular)");
                        db1.AddInParameter(cmd, "id_cliente", DbType.Int32, id_cliente);
                        db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                        db1.AddInParameter(cmd, "primer_titular", DbType.Boolean, true);
                        db1.ExecuteNonQuery(cmd);
                        m_cliente_contrato.num_migrado += 1;
                    }
                    catch (Exception ex)
                    {
                        m_cliente_contrato.num_error += 1;
                        m_cliente_contrato.NewMens("Error", "[cliente_contrato]", "[id_cliente]:" + id_cliente.ToString() + " ; [id_contrato]:" + id_contrato.ToString() + " ; Mensaje de error: " + ex.Message);
                    }
                }
            }
        }
        return m_cliente_contrato.Datos();
    }

    public static string MigrarFechaEstadoLoteReversion()
    {
        migracionResumen m_estadolote_reversion = new migracionResumen("Ajuste de la fecha de reversión en los estados de lotes", true);

        DbCommand cmd = db1.GetSqlStringCommand("SELECT [id_estado] FROM [estado] where [codigo]='ven'");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        int id_estado_vendido = (int)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT [id_estado] FROM [estado] where [codigo]='dis'");
        int id_estado_disponible = (int)db1.ExecuteScalar(cmd);

        //Datos a migrar:
        cmd = db1.GetSqlStringCommand("SELECT e_l.[id_estadolote],lot.[fecha_ultima_venta] FROM [estado_lote] as e_l,(SELECT cv.[id_lote],(SELECT el.[id_estadolote] FROM [estado_lote] as el WHERE el.[id_estado]=@id_estado_vendido AND el.[id_lote]=cv.[id_lote] AND (SELECT COUNT([id_estadolote]) FROM [estado_lote] WHERE [id_lote]=el.[id_lote] AND [id_contrato]=el.[id_contrato])=2) as 'id_estadolote_vendido',(SELECT el.[fecha] FROM [estado_lote] as el WHERE el.[id_estado]=@id_estado_vendido AND el.[id_lote]=cv.[id_lote] AND (SELECT COUNT([id_estadolote]) FROM [estado_lote] WHERE [id_lote]=el.[id_lote] AND [id_contrato]=el.[id_contrato])=2) as 'fecha_ultima_venta' FROM [contrato] as c,[contrato_venta] as cv WHERE c.[id_contrato]=cv.[id_contrato] AND (SELECT [estado] FROM [dbo].[t_contrato_EstadoActual](c.[id_contrato]))=1 AND (SELECT [id_estado] FROM [dbo].[t_lote_EstadoLote_IdEstado](cv.[id_lote],GETDATE()))=@id_estado_disponible) as lot WHERE e_l.[id_lote]=lot.[id_lote] AND e_l.[id_reversion] is not null AND e_l.[fecha]>lot.[fecha_ultima_venta] ORDER BY lot.[id_lote]");
        db1.AddInParameter(cmd, "id_estado_vendido", DbType.Int32, id_estado_vendido);
        db1.AddInParameter(cmd, "id_estado_disponible", DbType.Int32, id_estado_disponible);
        //id_estadolote,fecha_ultima_venta
        DataTable tabla_estado_lote = db1.ExecuteDataSet(cmd).Tables[0];


        //Ajuste de la fecha de reversión en los estados de lotes:
        foreach (DataRow fila in tabla_estado_lote.Rows)
        {
            m_estadolote_reversion.num_encontrato += 1;
            int id_estadolote = (int)fila["id_estadolote"];
            DateTime fecha_ultima_venta = (DateTime)fila["fecha_ultima_venta"];
            try
            {
                cmd = db1.GetSqlStringCommand("UPDATE [estado_lote] SET [fecha]=@fecha WHERE [id_estadolote]=@id_estadolote");
                db1.AddInParameter(cmd, "id_estadolote", DbType.Int32, id_estadolote);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha_ultima_venta);
                db1.ExecuteNonQuery(cmd);
                m_estadolote_reversion.num_migrado += 1;
            }
            catch (Exception ex)
            {
                m_estadolote_reversion.num_error += 1;
                m_estadolote_reversion.NewMens("Error", "[estado_lote]", "id_estadolote: " + id_estadolote.ToString() + " ; fecha_ultima_venta: " + fecha_ultima_venta.ToShortDateString() + " ; Mensaje de error: " + ex.Message);
            }
        }
        //Los resultados:
        return m_estadolote_reversion.Datos();
    }

    public static string MigrarAsignacionCobrador(int Context_id_usuario)
    {
        migracionResumen m_asignacion = new migracionResumen("Asignaciones de cobradores", true);

        //Parámetros generales necesarios
        DbCommand cmd = db1.GetSqlStringCommand("SELECT DISTINCT c.[id_contrato],(SELECT [id_usuario] FROM [usuario] WHERE [ci]=(SELECT TOP 1 [ci] FROM [cobranzas_asignacion] WHERE [ncontrato]=ca.[ncontrato])) as 'id_usuario' FROM [cobranzas_asignacion] as ca, [contrato] as c WHERE ca.[ncontrato] IS NOT NULL AND ca.[ci] IS NOT NULL AND ca.[ncontrato]=c.[numero] AND (SELECT COUNT([id_usuario]) FROM [usuario] WHERE [ci]=ca.[ci])>0");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_asignacion = db1.ExecuteDataSet(cmd).Tables[0];
        foreach (DataRow fila in tabla_asignacion.Rows)
        {
            m_asignacion.num_encontrato += 1;
            cmd = db1.GetSqlStringCommand("SELECT COUNT([id_asignacioncobrador]) FROM [asignacion_cobrador] WHERE [id_contrato]=@id_contrato AND [id_usuario_cobrador]=@id_usuario_cobrador");
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, (int)fila["id_contrato"]);
            db1.AddInParameter(cmd, "id_usuario_cobrador", DbType.Int32, (int)fila["id_usuario"]);
            if ((int)db1.ExecuteScalar(cmd) == 0)
            {
                try
                {
                    cmd = db1.GetSqlStringCommand("INSERT INTO [asignacion_cobrador] ([id_contrato],[id_usuario_cobrador],[id_usuario],[fecha],[activo]) VALUES(@id_contrato,@id_usuario_cobrador,@id_usuario,@fecha,@activo)");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, (int)fila["id_contrato"]);
                    db1.AddInParameter(cmd, "id_usuario_cobrador", DbType.Int32, (int)fila["id_usuario"]);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                    db1.AddInParameter(cmd, "fecha", DbType.DateTime, DateTime.Now);
                    db1.AddInParameter(cmd, "activo", DbType.Boolean, true);
                    db1.ExecuteNonQuery(cmd);
                    m_asignacion.num_migrado += 1;
                }
                catch (Exception ex)
                {
                    m_asignacion.num_error += 1;
                    m_asignacion.NewMens("Error (asignación incorrecta)", "", "id_contrato: " + fila["id_contrato"].ToString() + " ; id_usuario: " + fila["id_usuario"].ToString() + " ; Mensaje de error: " + ex.Message);
                }
            }
            else { m_asignacion.num_repetido += 1; }
        }
        return m_asignacion.Datos();
    }

    public static string MigrarAjustePlanPagoContratosNafibo()
    {
        migracionResumen m_nafibo = new migracionResumen("Ajuste a Planes de Pago de Contratos Nafibo", true);

        DateTime fecha_auxiliar;
        DbCommand cmd = db1.GetSqlStringCommand("SELECT [ncontrato],[fecha_pago],[cuota_base],[interes_corriente] FROM [finanzas_nafibo_plan_pago]");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_sat_cli_naf = db1.ExecuteDataSet(cmd).Tables[0];
        foreach (DataRow fila_naf in tabla_sat_cli_naf.Rows)
        {
            m_nafibo.num_encontrato += 1;
            string m_ncontrato = fila_naf["ncontrato"].ToString();
            DateTime m_fecha_pago = (DateTime)fila_naf["fecha_pago"];
            decimal m_cuota_base = (decimal)fila_naf["cuota_base"];
            decimal m_interes_corriente = (decimal)fila_naf["interes_corriente"];

            cmd = db1.GetSqlStringCommand("SELECT TOP 1 pp.[id_contrato],pp.[id_planpago],pp.[cuota_base],pp.[interes_corriente],pp.[fecha_inicio_plan] FROM [plan_pago] as pp WHERE pp.[id_contrato]=(SELECT TOP 1 [id_contrato] FROM [contrato] WHERE [numero]=@ncontrato) AND [vigente]=1 ORDER BY [fecha] DESC");
            db1.AddInParameter(cmd, "ncontrato", DbType.String, m_ncontrato);
            DataTable tabla_plan_pago_actual = db1.ExecuteDataSet(cmd).Tables[0];
            if (tabla_plan_pago_actual.Rows.Count > 0)
            {
                int pp_id_contrato = (int)tabla_plan_pago_actual.Rows[0]["id_contrato"];
                int pp_id_planpago = (int)tabla_plan_pago_actual.Rows[0]["id_planpago"];
                decimal pp_cuota_base = (decimal)tabla_plan_pago_actual.Rows[0]["cuota_base"];
                decimal pp_interes_corriente = (decimal)tabla_plan_pago_actual.Rows[0]["interes_corriente"];
                DateTime pp_fecha_inicio_plan = (DateTime)tabla_plan_pago_actual.Rows[0]["fecha_inicio_plan"];

                //De ser necesario se modifica la fecha de inicio de plan del Plan de Pagos Vigente
                fecha_auxiliar = pp_fecha_inicio_plan;
                if (pp_fecha_inicio_plan.Day != m_fecha_pago.Day)
                {
                    if (pp_fecha_inicio_plan.Day < m_fecha_pago.Day)
                        pp_fecha_inicio_plan = pp_fecha_inicio_plan.AddDays(m_fecha_pago.Day - pp_fecha_inicio_plan.Day);
                    else
                        pp_fecha_inicio_plan = pp_fecha_inicio_plan.AddDays((-1) * (pp_fecha_inicio_plan.Day - m_fecha_pago.Day));
                }

                //De ser necesario se modifica el interés corriente del plan de pagos
                if (m_interes_corriente > 0)
                    if (m_interes_corriente != pp_interes_corriente)
                        pp_interes_corriente = m_interes_corriente;

                //Se actualiza el plan de pagos con los datos actualizados
                try
                {
                    cmd = db1.GetSqlStringCommand("UPDATE [plan_pago] SET [cuota_base]=@cuota_base,[fecha_inicio_plan]=@fecha_inicio_plan,[interes_corriente]=@interes_corriente WHERE [id_planpago]=@id_planpago");
                    db1.AddInParameter(cmd, "cuota_base", DbType.Decimal, m_cuota_base);
                    db1.AddInParameter(cmd, "fecha_inicio_plan", DbType.DateTime, pp_fecha_inicio_plan);
                    db1.AddInParameter(cmd, "interes_corriente", DbType.Decimal, pp_interes_corriente);
                    db1.AddInParameter(cmd, "id_planpago", DbType.Decimal, pp_id_planpago);
                    db1.ExecuteNonQuery(cmd);
                    m_nafibo.num_migrado += 1;
                }
                catch (Exception ex)
                {
                    m_nafibo.num_error += 1;
                    m_nafibo.NewMens("Error", "Update [plan_pago]", "ncontrato: " + m_ncontrato + " ; fecha_pago: " + m_fecha_pago.ToString("d") + " ; cuota_base: " + m_cuota_base.ToString("F2") + " ; interes_corriente: " + m_interes_corriente.ToString("F2") + " ; Mensaje de error: " + ex.Message);
                }

                //De ser necesario se modifica la fecha de próximo pago del último pago
                //if (fecha_auxiliar.Day != m_fecha_pago.Day)
                //{
                //Se recuperan los datos del último pago (si existe)
                cmd = db1.GetSqlStringCommand("SELECT TOP 1 [id_pago],[interes_fecha] FROM [pago] WHERE [id_contrato]=@id_contrato AND [anulado]=0 ORDER BY [fecha] DESC");
                db1.AddInParameter(cmd, "id_contrato", DbType.Decimal, pp_id_contrato);
                DataTable tabla_ultimo_pago = db1.ExecuteDataSet(cmd).Tables[0];
                if (tabla_ultimo_pago.Rows.Count > 0)
                {
                    int up_id_pago = (int)tabla_ultimo_pago.Rows[0]["id_pago"];
                    DateTime up_interes_fecha = (DateTime)tabla_ultimo_pago.Rows[0]["interes_fecha"];

                    DateTime nueva_fecha_proximo = terrasur.logica.FechaProximoPago(up_interes_fecha, m_fecha_pago);

                    try
                    {
                        cmd = db1.GetSqlStringCommand("UPDATE [pago] SET [fecha_proximo]=@fecha_proximo WHERE [id_pago]=@id_pago");
                        db1.AddInParameter(cmd, "fecha_proximo", DbType.DateTime, nueva_fecha_proximo);
                        db1.AddInParameter(cmd, "id_pago", DbType.Int32, up_id_pago);
                        db1.ExecuteNonQuery(cmd);
                    }
                    catch (Exception ex)
                    {
                        m_nafibo.NewMens("Error", "Update [pago]", "id_contrato: " + pp_id_contrato.ToString() + " ; fecha_inicio_plan: " + pp_fecha_inicio_plan.ToShortDateString() + " ; interes_fecha: " + up_interes_fecha.ToShortDateString() + " ; fecha_proximo: " + nueva_fecha_proximo.ToShortDateString() + " ; Mensaje de error: " + ex.Message);
                    }
                }
                //}
            }
        }
        return m_nafibo.Datos();
    }

    public static string MigrarReversionesAnuladas(int Context_id_usuario)
    {
        migracionResumen m_reversion = new migracionResumen("Reversiones anuladas", true);
        //Datos a migrar:
        DbCommand cmd = db1.GetSqlStringCommand("SELECT rev.[id_contrato],rev.[ncontrato],rev.[fecha],rev.[pagado],rev.[sd],rev.[diasmora],(CASE WHEN rev.[anulado_fecha]>rev.[fecha] THEN DATEADD(day,-1,rev.[anulado_fecha]) ELSE rev.[fecha] END) as 'anulado_fecha',(SELECT [id_motivoreversion] FROM [motivo_reversion] WHERE [codigo]='fuerza') as 'id_motivoreversion' FROM (SELECT c.[id_contrato],r.[ncontrato],r.[fecha],r.[pagado],r.[sd],r.[diasmora],ISNULL((SELECT TOP 1 [fecha] FROM [pago] WHERE [fecha]>=r.[fecha] AND [id_contrato]=(SELECT [id_contrato] FROM [contrato] WHERE [numero]=CONVERT(nvarchar(50),r.[ncontrato])) ORDER BY [fecha]),r.[fecha]) as 'anulado_fecha' FROM [sat_revertid] as r, [contrato] as c WHERE r.[estado]<>'X' AND CONVERT(nvarchar(50),r.[ncontrato])=c.[numero]) as rev ORDER BY ncontrato");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_sat_revertid = db1.ExecuteDataSet(cmd).Tables[0];
        foreach (DataRow fila in tabla_sat_revertid.Rows)
        {
            m_reversion.num_encontrato += 1;
            int id_contrato = (int)fila["id_contrato"];
            string ncontrato = fila["ncontrato"].ToString();
            DateTime fecha = (DateTime)fila["fecha"];
            decimal pagado = (decimal)fila["pagado"];
            decimal sd = (decimal)fila["sd"];
            int diasmora = int.Parse(fila["diasmora"].ToString());
            DateTime anulado_fecha = (DateTime)fila["anulado_fecha"];
            int id_motivoreversion = (int)fila["id_motivoreversion"];

            cmd = db1.GetSqlStringCommand("SELECT COUNT([id_reversion]) FROM [reversion] WHERE [anulado]=1 AND [id_contrato]=@id_contrato AND [fecha]=@fecha");
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
            db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
            if ((int)db1.ExecuteScalar(cmd) == 0)
            {
                try
                {
                    cmd = db1.GetSqlStringCommand("INSERT INTO [reversion]([id_usuario],[id_contrato],[id_motivoreversion],[fecha],[dias_mora],[cuotas_mora],[capital_pagado],[capital_adeuda],[anulado],[anulado_fecha],[anulado_id_usuario]) VALUES (@id_usuario_r,@id_contrato_r,@id_motivoreversion_r,@fecha,@dias_mora_r,@cuotas_mora_r,@capital_pagado_r,@capital_adeuda_r,@anulado_r,@anulado_fecha_r,@anulado_id_usuario_r) DECLARE @id_reversion_r int SET @id_reversion_r =IDENT_CURRENT('reversion') SELECT @id_reversion_r");
                    db1.AddInParameter(cmd, "id_usuario_r", DbType.Int32, Context_id_usuario);
                    db1.AddInParameter(cmd, "id_contrato_r", DbType.Int32, id_contrato);
                    db1.AddInParameter(cmd, "id_motivoreversion_r", DbType.Int32, id_motivoreversion);
                    db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                    db1.AddInParameter(cmd, "dias_mora_r", DbType.Int32, diasmora);
                    db1.AddInParameter(cmd, "cuotas_mora_r", DbType.Int32, 0);
                    db1.AddInParameter(cmd, "capital_pagado_r", DbType.Decimal, pagado);
                    db1.AddInParameter(cmd, "capital_adeuda_r", DbType.Decimal, sd);
                    db1.AddInParameter(cmd, "anulado_r", DbType.Boolean, true);
                    db1.AddInParameter(cmd, "anulado_fecha_r", DbType.DateTime, anulado_fecha);
                    db1.AddInParameter(cmd, "anulado_id_usuario_r", DbType.Int32, Context_id_usuario);

                    int id_reversion = (int)db1.ExecuteScalar(cmd);
                    m_reversion.num_migrado += 1;


                    //SE INGRESA EL REGISTRO DE NEGOCIO_CONTRATO
                    cmd = db1.GetSqlStringCommand("(SELECT [id_negocio],ISNULL([id_negociolote],0) as 'id_negociolote',(SELECT [id_pago] FROM [dbo].[t_contrato_UltimoPago](@id_contrato,@fecha)) as 'id_ultimo_pago',CONVERT(numeric(10,2),(([saldo_capital] - @capital_pagado) * (-1))) as 'saldo_capital_revertido',CONVERT(numeric(10,2),(([saldo_costo] - ([saldo_costo] * (@capital_pagado / [saldo_capital]))) * (-1))) as 'saldo_costo_revertido' FROM [negocio_contrato] WHERE [id_negociocontrato] = (SELECT [id_negociocontrato] FROM [dbo].[t_contrato_NegocioContrato](@id_contrato)) AND [anulado] = 0)");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                    db1.AddInParameter(cmd, "capital_pagado", DbType.Double, pagado);
                    db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                    DataTable tabla_negocio_contrato = db1.ExecuteDataSet(cmd).Tables[0];
                    int id_negocio = 0;
                    int id_negociolote = 0;
                    int id_ultimo_pago = 0;
                    decimal saldo_capital_revertido = 0;
                    decimal saldo_costo_revertido = 0;
                    if (tabla_negocio_contrato.Rows.Count > 0)
                    {
                        id_negocio = int.Parse(Formato(tabla_negocio_contrato.Rows[0]["id_negocio"].ToString()));
                        id_negociolote = int.Parse(Formato(tabla_negocio_contrato.Rows[0]["id_negociolote"].ToString()));
                        id_ultimo_pago = int.Parse(Formato(tabla_negocio_contrato.Rows[0]["id_ultimo_pago"].ToString()));
                        saldo_capital_revertido = decimal.Parse(Formato(tabla_negocio_contrato.Rows[0]["saldo_capital_revertido"].ToString()));
                        saldo_costo_revertido = decimal.Parse(Formato(tabla_negocio_contrato.Rows[0]["saldo_costo_revertido"].ToString()));
                    }

                    //NEGOCIO_CONTRATO
                    cmd = db1.GetSqlStringCommand("DECLARE @id_negociolote1 int IF @id_negociolote=0 BEGIN SET @id_negociolote1=NULL END ELSE BEGIN	SET @id_negociolote1=@id_negociolote END DECLARE @id_pago1 int IF @id_pago=0 BEGIN 	SET @id_pago1=NULL END ELSE BEGIN SET @id_pago1=@id_pago END INSERT INTO [negocio_contrato] ([id_negocio],[id_contrato],[id_usuario],[id_negociolote],[id_pago],[id_reversion],[fecha],[saldo_capital],[saldo_costo],[anulado])	VALUES (@id_negocio,@id_contrato,@id_usuario,@id_negociolote1,@id_pago1,@id_reversion,@fecha,@saldo_capital,@saldo_costo,1)");
                    db1.AddInParameter(cmd, "id_negocio", DbType.Int32, id_negocio);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                    db1.AddInParameter(cmd, "id_negociolote", DbType.Int32, id_negociolote);
                    db1.AddInParameter(cmd, "id_pago", DbType.Int32, id_ultimo_pago);
                    db1.AddInParameter(cmd, "id_reversion", DbType.Int32, id_reversion);
                    db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                    db1.AddInParameter(cmd, "saldo_capital", DbType.Decimal, (sd * (-1)));
                    db1.AddInParameter(cmd, "saldo_costo", DbType.Decimal, saldo_costo_revertido);
                    db1.ExecuteNonQuery(cmd);

                    //ESTADO_LOTE SI ES CONTRATO VENTA
                    cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_lote] FROM [contrato_venta] WHERE [id_contrato]=@id_contrato),0) as 'id_lote'");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                    int id_lote = (int)db1.ExecuteScalar(cmd);
                    if (id_lote > 0)
                    {
                        cmd = db1.GetSqlStringCommand("SELECT TOP 1 [id_estado] FROM [estado_lote] WHERE [id_lote]=@id_lote ORDER BY [fecha] DESC,[id_estado] DESC");
                        db1.AddInParameter(cmd, "id_lote", DbType.Int32, id_lote);
                        int id_estado_anterior = (int)db1.ExecuteScalar(cmd);
                        cmd = db1.GetSqlStringCommand("SELECT [id_estado] FROM [estado] WHERE UPPER([codigo])='DIS'");
                        int id_estado_disponible = (int)db1.ExecuteScalar(cmd);

                        //Primero se inserta el estado disponible (reversión)
                        cmd = db1.GetSqlStringCommand("INSERT INTO [estado_lote]([id_estado],[id_lote],[id_contrato],[id_reversion],[id_usuario],[fecha],[observacion]) VALUES (@id_estado,@id_lote,@id_contrato,@id_reversion,@id_usuario,@fecha,@observacion)");
                        db1.AddInParameter(cmd, "id_estado", DbType.Int32, id_estado_disponible);
                        db1.AddInParameter(cmd, "id_lote", DbType.Int32, id_lote);
                        db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                        db1.AddInParameter(cmd, "id_reversion", DbType.Int32, id_reversion);
                        db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                        db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                        db1.AddInParameter(cmd, "observacion", DbType.String, "Reversión");
                        db1.ExecuteNonQuery(cmd);

                        //Luego se inserta el estado vendido o preasignado (deshacer reversión)
                        cmd = db1.GetSqlStringCommand("INSERT INTO [estado_lote]([id_estado],[id_lote],[id_contrato],[id_reversion],[id_usuario],[fecha],[observacion]) VALUES (@id_estado,@id_lote,@id_contrato,NULL,@id_usuario,@fecha,@observacion)");
                        db1.AddInParameter(cmd, "id_estado", DbType.Int32, id_estado_anterior);
                        db1.AddInParameter(cmd, "id_lote", DbType.Int32, id_lote);
                        db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                        db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                        db1.AddInParameter(cmd, "fecha", DbType.DateTime, anulado_fecha);
                        db1.AddInParameter(cmd, "observacion", DbType.String, "Reversión deshecha");
                        db1.ExecuteNonQuery(cmd);
                    }


                }
                catch (Exception ex)
                {
                    m_reversion.num_error += 1;
                    m_reversion.msg.Add(new Mens("Error", "", "Num. contrato: " + ncontrato + " ; Mensaje de error: " + ex.Message));
                }
            }
            else
            {
                m_reversion.num_repetido += 1;
                m_reversion.msg.Add(new Mens("Repetido", "[reversion]", "Num. contrato: " + ncontrato));
            }
        }
        return m_reversion.Datos();
    }

    public static string MigrarRolesPermisosUsuarios()
    {
        //Primero se migran los roles de los usuarios
        migracionResumen m_roles = new migracionResumen("Roles de los usuarios", true);
        DbCommand cmd = db1.GetSqlStringCommand("SELECT DISTINCT [usuario_ci],[rol_codigo] FROM [migracion_usuario_rol_permiso] WHERE [recurso_codigo]='' AND [permiso_codigo]=''");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_roles = db1.ExecuteDataSet(cmd).Tables[0];
        int id_usuario = 0; int id_rol = 0;
        foreach (DataRow fila in tabla_roles.Rows)
        {
            m_roles.num_encontrato += 1;

            //Se recupera el id_usuario y el id_rol
            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT TOP 1 [id_usuario] FROM [usuario] WHERE [ci]=@usuario_ci),0)");
            db1.AddInParameter(cmd, "usuario_ci", DbType.String, fila["usuario_ci"].ToString());
            id_usuario = (int)db1.ExecuteScalar(cmd);
            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT TOP 1 [id_rol] FROM [rol] WHERE [codigo]=@rol_codigo),0)");
            db1.AddInParameter(cmd, "rol_codigo", DbType.String, fila["rol_codigo"].ToString());
            id_rol = (int)db1.ExecuteScalar(cmd);

            if (id_usuario > 0 && id_rol > 0)
            {
                //Se verifica si el usuario_rol ya existe
                cmd = db1.GetSqlStringCommand("SELECT COUNT([id_usuario]) FROM [usuario_rol] WHERE [id_usuario]=@id_usuario AND [id_rol]=@id_rol");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, id_rol);
                if ((int)db1.ExecuteScalar(cmd) == 0)
                {
                    //Se realiza la asignación del rol al usuario
                    if (terrasur.usuario_rol.InsertarEliminar(true, id_usuario, id_rol) == true)
                        m_roles.num_migrado += 1;
                    else
                    {
                        m_roles.num_error += 1;
                        m_roles.NewMens("Insert", "", "ci_usuario: " + fila["usuario_ci"].ToString() + " ; rol_codigo: " + fila["rol_codigo"].ToString() + " ; id_usuario:" + id_usuario.ToString() + " ; id_rol:" + id_rol.ToString());
                    }

                    //De ser necesario se eliminan los roles del usuario que utilizan el mísmo módulo
                    cmd = db1.GetSqlStringCommand("SELECT DISTINCT ur.[id_rol] FROM [usuario_rol] as ur WHERE ur.[id_usuario]=@id_usuario AND ur.[id_rol]<>@id_rol AND ur.[id_rol] in (SELECT [id_rol] FROM [rol] WHERE [id_modulo]=(SELECT ISNULL([id_modulo],0) FROM [rol] WHERE [id_rol]=@id_rol)) AND ur.[id_rol] not in (SELECT [id_rol] FROM [rol] WHERE [codigo] in ('promotor','director'))");
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, id_usuario);
                    db1.AddInParameter(cmd, "id_rol", DbType.Int32, id_rol);
                    DataTable tabla_roles_eliminar = db1.ExecuteDataSet(cmd).Tables[0];
                    foreach (DataRow fila_roles_eliminar in tabla_roles_eliminar.Rows)
                    {
                        bool aux = terrasur.usuario_rol.InsertarEliminar(false, id_usuario, Int32.Parse(fila_roles_eliminar["id_rol"].ToString()));
                    }
                }
                else m_roles.num_repetido += 1;
            }
            else
            {
                m_roles.num_error += 1;
                m_roles.NewMens("Insert", "", "ci_usuario: " + fila["usuario_ci"].ToString() + " ; rol_codigo: " + fila["rol_codigo"].ToString() + " ; id_usuario:" + id_usuario.ToString() + " ; id_rol:" + id_rol.ToString());
            }
        }

        migracionResumen m_permiso = new migracionResumen("Permisos de los usuarios", true);
        cmd = db1.GetSqlStringCommand("SELECT DISTINCT [usuario_ci],[rol_codigo],[recurso_codigo],[permiso_codigo] FROM [migracion_usuario_rol_permiso] WHERE [recurso_codigo]<>'' AND [permiso_codigo]<>''");
        DataTable tabla_permisos = db1.ExecuteDataSet(cmd).Tables[0];
        int id_permiso = 0;
        foreach (DataRow fila_permiso in tabla_permisos.Rows)
        {
            m_permiso.num_encontrato += 1;
            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT TOP 1 [id_usuario] FROM [usuario] WHERE [ci]=@usuario_ci),0)");
            db1.AddInParameter(cmd, "usuario_ci", DbType.String, fila_permiso["usuario_ci"].ToString());
            id_usuario = (int)db1.ExecuteScalar(cmd);
            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT TOP 1 [id_rol] FROM [rol] WHERE [codigo]=@rol_codigo),0)");
            db1.AddInParameter(cmd, "rol_codigo", DbType.String, fila_permiso["rol_codigo"].ToString());
            id_rol = (int)db1.ExecuteScalar(cmd);
            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT TOP 1 p.[id_permiso] FROM [permiso] as p,[recurso] as r WHERE p.[id_recurso]=r.[id_recurso] AND r.[codigo]=@recurso_codigo AND p.[codigo]=@permiso_codigo),0)");
            db1.AddInParameter(cmd, "recurso_codigo", DbType.String, fila_permiso["recurso_codigo"].ToString());
            db1.AddInParameter(cmd, "permiso_codigo", DbType.String, fila_permiso["permiso_codigo"].ToString());
            id_permiso = (int)db1.ExecuteScalar(cmd);
            if (id_usuario > 0 && id_rol > 0 && id_permiso > 0)
            {
                cmd = db1.GetSqlStringCommand("SELECT COUNT([id_usuario]) FROM [usuario_rol_permiso] WHERE [id_usuario]=@id_usuario AND [id_rol]=@id_rol AND [id_permiso]=@id_permiso");
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, id_usuario);
                db1.AddInParameter(cmd, "id_rol", DbType.Int32, id_rol);
                db1.AddInParameter(cmd, "id_permiso", DbType.Int32, id_permiso);
                if ((int)db1.ExecuteScalar(cmd) == 0)
                {
                    try
                    {
                        cmd = db1.GetSqlStringCommand("INSERT INTO [usuario_rol_permiso]([id_usuario],[id_rol],[id_permiso]) VALUES(@id_usuario,@id_rol,@id_permiso)");
                        db1.AddInParameter(cmd, "id_usuario", DbType.Int32, id_usuario);
                        db1.AddInParameter(cmd, "id_rol", DbType.Int32, id_rol);
                        db1.AddInParameter(cmd, "id_permiso", DbType.Int32, id_permiso);
                        db1.ExecuteNonQuery(cmd);
                        m_permiso.num_migrado += 1;
                    }
                    catch (Exception ex)
                    {
                        m_permiso.num_error += 1;
                        m_permiso.NewMens("Error (Insert)", "", "id_usuario:" + id_usuario.ToString() + " ; id_rol:" + id_rol.ToString() + " ; id_permiso:" + id_permiso.ToString() + " ; Mensaje de error: " + ex.Message);
                    }
                }
                else { m_permiso.num_repetido += 1; }
            }
            else
            {
                m_permiso.num_error += 1;
                m_permiso.NewMens("Error (datos)", "", "id_usuario:" + id_usuario.ToString() + " ; id_rol:" + id_rol.ToString() + " ; id_permiso:" + id_permiso.ToString());
            }
        }
        return m_roles.Datos() + m_permiso.Datos();
    }




    public static string MigrarLocalizaciones()
    {
        migracionResumen m_localizaciones = new migracionResumen("Localizaciones", true);

        //Datos a migrar:
        DbCommand cmd = db1.GetSqlStringCommand("(SELECT cod_loc,ISNULL(nom_loc,cod_loc) as nom_loc from sat_det_loc) UNION (SELECT d.cod_loc,ISNULL(l.nom_loc,d.cod_loc) as nom_loc FROM sat_det_urb d LEFT JOIN sat_det_loc l ON l.cod_loc = d.cod_loc GROUP BY d.cod_loc,l.nom_loc) ORDER BY 1");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_sat_loc = db1.ExecuteDataSet(cmd).Tables[0];
        //Migración de [sat_det_loc]:
        foreach (DataRow fila in tabla_sat_loc.Rows)
        {
            m_localizaciones.num_encontrato += 1;

            string codigo = Formato((fila["cod_loc"]).ToString());
            string nombre = Formato((fila["nom_loc"]).ToString());
            cmd = db1.GetSqlStringCommand("SELECT COUNT([id_localizacion]) FROM [localizacion] WHERE RTRIM(LTRIM([codigo]))=@codigo");
            db1.AddInParameter(cmd, "codigo", DbType.String, codigo);
            if ((int)db1.ExecuteScalar(cmd) == 0)
            {
                try
                {
                    cmd = db1.GetSqlStringCommand("INSERT INTO [localizacion]([codigo],[nombre],[imagen]) VALUES(@codigo,@nombre,'')");
                    db1.AddInParameter(cmd, "codigo", DbType.String, codigo);
                    db1.AddInParameter(cmd, "nombre", DbType.String, nombre);
                    db1.ExecuteNonQuery(cmd);
                    m_localizaciones.num_migrado += 1;
                }
                catch (Exception ex)
                {
                    m_localizaciones.num_error += 1;
                    m_localizaciones.NewMens("Error", "", "codigo: " + codigo + "; Mensaje de error: " + ex.Message);
                }
            }
            else
            {
                m_localizaciones.num_repetido += 1;
                m_localizaciones.NewMens("Repetido", "[localizacion]", "codigo: " + codigo);
            }
        }

        //Los resultados:
        return m_localizaciones.Datos();
    }

    public static string MigrarUrbanizaciones()
    {
        migracionResumen m_urbanizaciones = new migracionResumen("Sectores", true);
        //Datos a migrar:
        //DbCommand cmd = db1.GetSqlStringCommand("(SELECT cod_loc,cod_urb,urb_corto,CASE ISNULL(urb_largo,'') WHEN ''  THEN urb_corto ELSE urb_largo END as urb_largo,ISNULL(activo,1) as activo from sat_det_urb) UNION (select d.locacion,d.negocio,d.sector,CASE ISNULL(l.urb_largo,'') WHEN ''  THEN d.sector ELSE l.urb_largo END as urb_largo,ISNULL(l.activo,1) as activo from  sat_datoscred d left join sat_det_urb l on CONVERT(numeric(10),l.cod_urb) = d.codigourba group by d.locacion,d.negocio,d.sector,l.urb_largo,l.activo) order by 1,2,3 desc");
        DbCommand cmd = db1.GetSqlStringCommand("(SELECT cod_loc,cod_urb,urb_corto,CASE ISNULL(urb_largo,'') WHEN ''  THEN urb_corto ELSE urb_largo END as 'urb_largo',ISNULL(activo,'True') as 'activo' from sat_det_urb) UNION (select d.locacion as 'cod_loc',d.negocio as 'cod_urb',d.sector as 'urb_corto',d.sector as 'urb_largo','True' as 'activo' from sat_datoscred d where d.negocio not in ((SELECT distinct cod_urb from sat_det_urb) )) order by 1,2,3 desc");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_sat_urb = db1.ExecuteDataSet(cmd).Tables[0];
        //Migración de [sat_det_urb]:
        foreach (DataRow fila in tabla_sat_urb.Rows)
        {
            m_urbanizaciones.num_encontrato += 1;

            string cod_loc = Formato((fila["cod_loc"]).ToString());
            string cod_urb = Formato(fila["cod_urb"].ToString());
            string nombre_corto = Formato(fila["urb_corto"].ToString());
            string nombre = Formato(fila["urb_largo"].ToString());
            bool activo = bool.Parse(Formato(fila["activo"].ToString()));
            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_localizacion] FROM [localizacion] WHERE RTRIM(LTRIM([codigo]))=@codigo),0)");
            db1.AddInParameter(cmd, "codigo", DbType.String, cod_loc);
            int id_localizacion = (int)db1.ExecuteScalar(cmd);
            if (id_localizacion > 0)
            {
                cmd = db1.GetSqlStringCommand("SELECT COUNT([id_urbanizacion]) FROM [urbanizacion] WHERE RTRIM(LTRIM([codigo]))=@codigo");
                db1.AddInParameter(cmd, "codigo", DbType.String, cod_urb);
                if ((int)db1.ExecuteScalar(cmd) == 0)
                {
                    try
                    {
                        decimal precio = 0;
                        decimal costo = 0;
                        //VERFICAR LOS CODIGOS DE URB. QUE NO TIENEN TABLA
                        if (cod_urb != "000" & cod_urb != "020" & cod_urb != "075" & cod_urb != "077" & cod_urb != "080" & cod_urb != "086" & cod_urb != "089")
                        {
                            //PRECIO URBANIZACION
                            string query = "SELECT urb.[pr_m2] FROM (SELECT TOP 1 u.[pr_m2],(SELECT COUNT([codigolote]) FROM [sat_inv_ur" + cod_urb + "] WHERE [pr_m2]=u.[pr_m2]) as 'num'FROM [sat_inv_ur" + cod_urb + "] as u ORDER BY 1 DESC) as urb";
                            cmd = db1.GetSqlStringCommand(query);
                            precio = (decimal)db1.ExecuteScalar(cmd);

                            //COSTO URBANIZACION
                            query = "SELECT urb.[co_m2] FROM (SELECT TOP 1 u.[co_m2],(SELECT COUNT([codigolote]) FROM [sat_inv_ur" + cod_urb + "] WHERE [co_m2]=u.[co_m2]) as 'num' FROM [sat_inv_ur" + cod_urb + "] as u ORDER BY 1 DESC) as urb";
                            cmd = db1.GetSqlStringCommand(query);
                            costo = (decimal)db1.ExecuteScalar(cmd);
                        }

                        cmd = db1.GetSqlStringCommand("INSERT INTO [urbanizacion]([id_localizacion],[codigo],[nombre_corto],[nombre],[mantenimiento_sus],[costo_m2_sus],[precio_m2_sus],[imagen],[activo])	VALUES (@id_localizacion,@codigo,@nombre_corto,@nombre,@mantenimiento_sus,@costo_m2_sus,@precio_m2_sus,@imagen,@activo)");
                        db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, id_localizacion);
                        db1.AddInParameter(cmd, "codigo", DbType.String, cod_urb);
                        db1.AddInParameter(cmd, "nombre_corto", DbType.String, nombre_corto);
                        db1.AddInParameter(cmd, "nombre", DbType.String, nombre);
                        db1.AddInParameter(cmd, "mantenimiento_sus", DbType.Decimal, 0);
                        db1.AddInParameter(cmd, "costo_m2_sus", DbType.Decimal, costo);
                        db1.AddInParameter(cmd, "precio_m2_sus", DbType.Decimal, precio);
                        db1.AddInParameter(cmd, "imagen", DbType.String, "");
                        db1.AddInParameter(cmd, "activo", DbType.Boolean, activo);
                        db1.ExecuteNonQuery(cmd);
                        m_urbanizaciones.num_migrado += 1;
                    }
                    catch (Exception ex)
                    {
                        m_urbanizaciones.num_error += 1;
                        m_urbanizaciones.NewMens("Error", "", "nombre(urbanizacion): " + cod_urb + "; Mensaje de error: " + ex.Message);
                    }
                }
                else
                {
                    m_urbanizaciones.num_repetido += 1;
                    m_urbanizaciones.NewMens("Repetido", "[urbanizacion]", "codigo: " + cod_urb);

                }
            }
            else
            {
                m_urbanizaciones.num_error += 1;
                m_urbanizaciones.NewMens("Error", "", "num(localización no encontrada): " + cod_loc + ";");

            }
        }
        return m_urbanizaciones.Datos();
    }

    public static string MigrarManzanos()
    {
        migracionResumen m_manzanos = new migracionResumen("Manzanos", true);
        //Datos a migrar:
        DbCommand cmd = db1.GetSqlStringCommand("(SELECT DISTINCT cod_urb as cod_urb from sat_det_urb) UNION (select DISTINCT d.negocio as cod_urb from  sat_datoscred d left join sat_det_urb l on CONVERT(numeric(10),l.cod_urb) = d.codigourba) order by 1");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_sat_urb = db1.ExecuteDataSet(cmd).Tables[0];
        //Migración de [manzano]:
        foreach (DataRow fila in tabla_sat_urb.Rows)
        {


            string cod_urb = Formato(fila["cod_urb"].ToString());
            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_urbanizacion] FROM [urbanizacion] WHERE RTRIM(LTRIM([codigo]))=@codigo),0)");
            db1.AddInParameter(cmd, "codigo", DbType.String, cod_urb);
            int id_urbanizacion = (int)db1.ExecuteScalar(cmd);
            if (id_urbanizacion > 0)
            {
                string query = "";
                if (cod_urb != "" & cod_urb != "000" & cod_urb != "020" & cod_urb != "075" & cod_urb != "077" & cod_urb != "080" & cod_urb != "086" & cod_urb != "089")
                {
                    query = "SELECT DISTINCT negocio, CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END manzano from sat_datoscred where negocio='" + cod_urb + "' UNION SELECT DISTINCT negocio,CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END from sat_altaslotes where negocio='" + cod_urb + "' UNION SELECT DISTINCT negocio,CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE  CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END from sat_bajaslotes where negocio='" + cod_urb + "' UNION SELECT DISTINCT negocio,CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE  CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END from sat_preasigna where negocio='" + cod_urb + "' UNION SELECT DISTINCT negocio,CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE  CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END from sat_reserva where negocio='" + cod_urb + "'  UNION SELECT DISTINCT negocio,CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE  CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END from sat_revertid where negocio='" + cod_urb + "' UNION SELECT DISTINCT '" + cod_urb + "', CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE  CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1) END END from sat_inv_ur" + cod_urb + " ORDER BY 1,2";
                }
                else
                {
                    query = "SELECT DISTINCT negocio, CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END manzano from sat_datoscred where negocio='" + cod_urb + "' UNION SELECT DISTINCT negocio,CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END from sat_altaslotes where negocio='" + cod_urb + "' UNION SELECT DISTINCT negocio,CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE  CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END from sat_bajaslotes where negocio='" + cod_urb + "' UNION SELECT DISTINCT negocio,CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE  CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END from sat_preasigna where negocio='" + cod_urb + "' UNION SELECT DISTINCT negocio,CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE  CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END from sat_reserva where negocio='" + cod_urb + "'  UNION SELECT DISTINCT negocio,CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE  CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END from sat_revertid where negocio='" + cod_urb + "' ORDER BY 1,2";
                }
                cmd = db1.GetSqlStringCommand(query);
                DataTable tabla_sat_manzano = db1.ExecuteDataSet(cmd).Tables[0];

                foreach (DataRow fila_mzno in tabla_sat_manzano.Rows)
                {
                    //CONTADOR DE REGISTROS
                    m_manzanos.num_encontrato += 1;

                    string codigo = Formato((fila_mzno["manzano"]).ToString());

                    if (codigo != "")
                    {
                        cmd = db1.GetSqlStringCommand("SELECT COUNT([id_manzano]) FROM [manzano] WHERE RTRIM(LTRIM([codigo]))=@codigo AND [id_urbanizacion] = @id_urbanizacion");
                        db1.AddInParameter(cmd, "codigo", DbType.String, codigo);
                        db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, id_urbanizacion);
                        if ((int)db1.ExecuteScalar(cmd) == 0)
                        {
                            try
                            {

                                cmd = db1.GetSqlStringCommand("	INSERT INTO [manzano]([id_urbanizacion],[codigo]) VALUES (@id_urbanizacion,@codigo)");
                                db1.AddInParameter(cmd, "id_urbanizacion", DbType.String, id_urbanizacion);
                                db1.AddInParameter(cmd, "codigo", DbType.String, codigo);
                                db1.ExecuteNonQuery(cmd);
                                m_manzanos.num_migrado += 1;

                            }
                            catch (Exception ex)
                            {
                                m_manzanos.num_error += 1;
                                m_manzanos.NewMens("Error", "", "nombre(manzano): " + codigo + "; Mensaje de error: " + ex.Message);
                            }
                        }
                        else
                        {
                            m_manzanos.num_repetido += 1;
                            m_manzanos.NewMens("Repetido", "[manzano]", "codigo: " + codigo);
                        }
                    }
                }

            }
            else
            {
                m_manzanos.num_error += 1;
                m_manzanos.NewMens("Error", "", "num(sector no encontrado): " + cod_urb + ";");
            }

        }
        return m_manzanos.Datos();
    }

    public static string MigrarLotes(int Context_id_usuario)
    {
        migracionResumen m_lotes = new migracionResumen("Lotes", true);
        //Datos a migrar:
        DbCommand cmd = db1.GetSqlStringCommand("(SELECT DISTINCT cod_urb as cod_urb from sat_det_urb) UNION (select DISTINCT d.negocio as cod_urb from  sat_datoscred d left join sat_det_urb l on CONVERT(numeric(10),l.cod_urb) = d.codigourba) order by 1");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_sat_urb = db1.ExecuteDataSet(cmd).Tables[0];

        //ESTADOS DE LOTES
        cmd = db1.GetSqlStringCommand("SELECT [id_estado] FROM [estado] WHERE UPPER([codigo]) = 'DIS'");
        int id_estado_dis = (int)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT [id_estado] FROM [estado] WHERE UPPER([codigo]) = 'BLO'");
        int id_estado_blo = (int)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT [id_estado] FROM [estado] WHERE UPPER([codigo]) = 'RES'");
        int id_estado_res = (int)db1.ExecuteScalar(cmd);
        int id_estado = 0;
        //Migración de [manzano]:
        foreach (DataRow fila in tabla_sat_urb.Rows)
        {
            string cod_urb = Formato(fila["cod_urb"].ToString());
            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_urbanizacion] FROM [urbanizacion] WHERE RTRIM(LTRIM([codigo]))=@codigo),0)");
            db1.AddInParameter(cmd, "codigo", DbType.String, cod_urb);
            int id_urbanizacion = (int)db1.ExecuteScalar(cmd);
            if (id_urbanizacion > 0)
            {

                string query = "";
                if (cod_urb != "" & cod_urb != "000" & cod_urb != "020" & cod_urb != "075" & cod_urb != "077" & cod_urb != "080" & cod_urb != "086" & cod_urb != "089")
                {
                    query = "SELECT DISTINCT negocio, CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END manzano from sat_datoscred where negocio='" + cod_urb + "' UNION SELECT DISTINCT negocio,CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END from sat_altaslotes where negocio='" + cod_urb + "' UNION SELECT DISTINCT negocio,CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE  CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END from sat_bajaslotes where negocio='" + cod_urb + "' UNION SELECT DISTINCT negocio,CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE  CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END from sat_preasigna where negocio='" + cod_urb + "' UNION SELECT DISTINCT negocio,CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE  CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END from sat_reserva where negocio='" + cod_urb + "'  UNION SELECT DISTINCT negocio,CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE  CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END from sat_revertid where negocio='" + cod_urb + "' UNION SELECT DISTINCT '" + cod_urb + "', CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE  CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1) END END from sat_inv_ur" + cod_urb + " ORDER BY 1,2";
                }
                else
                {
                    query = "SELECT DISTINCT negocio, CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END manzano from sat_datoscred where negocio='" + cod_urb + "' UNION SELECT DISTINCT negocio,CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END from sat_altaslotes where negocio='" + cod_urb + "' UNION SELECT DISTINCT negocio,CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE  CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END from sat_bajaslotes where negocio='" + cod_urb + "' UNION SELECT DISTINCT negocio,CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE  CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END from sat_preasigna where negocio='" + cod_urb + "' UNION SELECT DISTINCT negocio,CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE  CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END from sat_reserva where negocio='" + cod_urb + "'  UNION SELECT DISTINCT negocio,CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE  CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END from sat_revertid where negocio='" + cod_urb + "' ORDER BY 1,2";
                }
                cmd = db1.GetSqlStringCommand(query);
                DataTable tabla_sat_mzno = db1.ExecuteDataSet(cmd).Tables[0];
                //Migración de [lotes]:
                foreach (DataRow fila_mzno in tabla_sat_mzno.Rows)
                {
                    string manzano = Formato(fila_mzno["manzano"].ToString());
                    if (manzano != "")
                    {
                        cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_manzano] FROM [manzano] WHERE RTRIM(LTRIM([codigo]))=@codigo AND [id_urbanizacion] = @id_urbanizacion),0)");
                        db1.AddInParameter(cmd, "codigo", DbType.String, manzano);
                        db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, id_urbanizacion);
                        int id_manzano = (int)db1.ExecuteScalar(cmd);
                        if (id_manzano > 0)
                        {
                            if (cod_urb != "" & cod_urb != "000" & cod_urb != "020" & cod_urb != "075" & cod_urb != "077" & cod_urb != "080" & cod_urb != "086" & cod_urb != "089")
                            {
                                query = "(SELECT DISTINCT codigolote from sat_datoscred where negocio='" + cod_urb + "' AND (CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END) = '" + manzano + "' AND codigolote <> '88888' UNION SELECT DISTINCT codigolote from sat_altaslotes where negocio='" + cod_urb + "' AND (CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE  CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END) ='" + manzano + "' AND codigolote <> '88888' UNION SELECT DISTINCT codigolote from sat_bajaslotes where negocio='" + cod_urb + "' AND (CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END) ='" + manzano + "' AND codigolote <> '88888' UNION SELECT DISTINCT codigolote from sat_preasigna where negocio='" + cod_urb + "' AND (CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END) ='" + manzano + "' AND codigolote <> '88888' UNION SELECT DISTINCT codigolote from sat_reserva where negocio='" + cod_urb + "' AND (CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE  CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END) ='" + manzano + "' AND codigolote <> '88888' UNION SELECT DISTINCT codigolote from sat_revertid where negocio='" + cod_urb + "' AND (CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END) ='" + manzano + "' AND codigolote <> '88888' UNION SELECT DISTINCT codigolote from sat_inv_ur" + cod_urb + " WHERE CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END = '" + manzano + "' AND codigolote <> '88888') ORDER BY 1";
                            }
                            else
                            {
                                query = "(SELECT DISTINCT codigolote from sat_datoscred where negocio='" + cod_urb + "' AND (CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END) = '" + manzano + "' AND codigolote <> '88888' UNION SELECT DISTINCT codigolote from sat_altaslotes where negocio='" + cod_urb + "' AND (CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE  CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END) ='" + manzano + "' AND codigolote <> '88888' UNION SELECT DISTINCT codigolote from sat_bajaslotes where negocio='" + cod_urb + "' AND (CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END) ='" + manzano + "' AND codigolote <> '88888' UNION SELECT DISTINCT codigolote from sat_preasigna where negocio='" + cod_urb + "' AND (CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END) ='" + manzano + "' AND codigolote <> '88888' UNION SELECT DISTINCT codigolote from sat_reserva where negocio='" + cod_urb + "' AND (CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE  CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END) ='" + manzano + "' AND codigolote <> '88888' UNION SELECT DISTINCT codigolote from sat_revertid where negocio='" + cod_urb + "' AND (CASE manzano WHEN '' THEN (CASE LEN(codigolote) WHEN 1 THEN codigolote ELSE CASE ISNUMERIC(SUBSTRING(codigolote,2,2)) WHEN 0 THEN SUBSTRING(codigolote,1,2) ELSE SUBSTRING(codigolote,1,1)END END) ELSE manzano END) ='" + manzano + "' AND codigolote <> '88888') ORDER BY 1";
                            }
                            cmd = db1.GetSqlStringCommand(query);
                            DataTable tabla_sat_lotes = db1.ExecuteDataSet(cmd).Tables[0];

                            foreach (DataRow fila_lote in tabla_sat_lotes.Rows)
                            {
                                //CONTADOR DE REGISTROS
                                m_lotes.num_encontrato += 1;

                                string codigo = Formato((fila_lote["codigolote"]).ToString());
                                if (cod_urb != "" & cod_urb != "000" & cod_urb != "020" & cod_urb != "075" & cod_urb != "077" & cod_urb != "080" & cod_urb != "086" & cod_urb != "089")
                                {
                                    query = "(SELECT codigolote,sup,co_m2,pr_m2,CASE WHEN estado = 'BL' THEN 'BL' WHEN estado = 'RE' THEN 'RE' ELSE 'DI' END  as 'estado' from sat_inv_ur" + cod_urb + " WHERE  codigolote = '" + codigo + "') ORDER BY 1,2";
                                }
                                else
                                {
                                    query = "(SELECT DISTINCT TOP 1 codigolote,sup,pr_m2,co_m2,'DI' as 'estado' from sat_datoshist where negocio='" + cod_urb + "' AND RTRIM(LTRIM(codigolote)) = '" + codigo + "' ) ORDER BY 1,2";
                                }
                                cmd = db1.GetSqlStringCommand(query);
                                DataTable tabla_sat_lote_datos = db1.ExecuteDataSet(cmd).Tables[0];
                                decimal sup = 0;
                                decimal precio = 0;
                                decimal costo = 0;
                                string estado = "";
                                if (tabla_sat_lote_datos.Rows.Count > 0)
                                {
                                    sup = decimal.Parse(Formato(tabla_sat_lote_datos.Rows[0]["sup"].ToString()));
                                    precio = decimal.Parse(Formato(tabla_sat_lote_datos.Rows[0]["pr_m2"].ToString()));
                                    costo = decimal.Parse(Formato(tabla_sat_lote_datos.Rows[0]["co_m2"].ToString()));
                                    estado = Formato(tabla_sat_lote_datos.Rows[0]["estado"].ToString());
                                }
                                cmd = db1.GetSqlStringCommand("SELECT COUNT([id_lote]) FROM [lote] WHERE RTRIM(LTRIM([codigo]))=@codigo AND [id_manzano] = @id_manzano");
                                db1.AddInParameter(cmd, "codigo", DbType.String, codigo);
                                db1.AddInParameter(cmd, "id_manzano", DbType.String, id_manzano);
                                if ((int)db1.ExecuteScalar(cmd) == 0)
                                {
                                    try
                                    {
                                        //NEGOCIO / TERRASUR
                                        query = "SELECT [id_negocio] FROM [negocio] WHERE UPPER([codigo])='CEA'";
                                        cmd = db1.GetSqlStringCommand(query);
                                        int id_negocio = (int)db1.ExecuteScalar(cmd);
                                        if (id_negocio > 0)
                                        {
                                            cmd = db1.GetSqlStringCommand("INSERT INTO [lote]([id_manzano],[id_usuario],[fecha_registro],[codigo],[superficie_m2],[costo_m2_sus],[precio_m2_sus],[anterior_propietario],[num_partida]) VALUES (@id_manzano,@id_usuario_i,'30/12/1899',@codigo,@superficie_m2,@costo_m2_sus,@precio_m2_sus,@anterior_propietario,@num_partida) DECLARE @id_lote_i int SET @id_lote_i=IDENT_CURRENT('lote')  SELECT @id_lote_i");
                                            db1.AddInParameter(cmd, "id_negocio_i", DbType.Int32, id_negocio);
                                            db1.AddInParameter(cmd, "id_manzano", DbType.Int32, id_manzano);
                                            db1.AddInParameter(cmd, "id_usuario_i", DbType.Int32, Context_id_usuario);
                                            db1.AddInParameter(cmd, "codigo", DbType.String, codigo);
                                            db1.AddInParameter(cmd, "superficie_m2", DbType.Decimal, sup);
                                            db1.AddInParameter(cmd, "costo_m2_sus", DbType.Decimal, costo);
                                            db1.AddInParameter(cmd, "precio_m2_sus", DbType.Decimal, precio);
                                            db1.AddInParameter(cmd, "anterior_propietario", DbType.String, "");
                                            db1.AddInParameter(cmd, "num_partida", DbType.String, "");
                                            int id_lote = (int)db1.ExecuteScalar(cmd);

                                            //NEGOCIO_LOTE
                                            cmd = db1.GetSqlStringCommand("INSERT INTO [negocio_lote]([id_negocio],[id_lote],[id_usuario],[fecha]) VALUES (@id_negocio,@id_lote,@id_usuario,'30/12/1899')");
                                            db1.AddInParameter(cmd, "id_negocio", DbType.Int32, id_negocio);
                                            db1.AddInParameter(cmd, "id_lote", DbType.Int32, id_lote);
                                            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                                            db1.ExecuteNonQuery(cmd);

                                            //ESTADO_LOTE
                                            //cmd = db1.GetSqlStringCommand("SELECT [id_estado] FROM [estado] WHERE UPPER([codigo]) = 'DIS'");
                                            //int id_estado = (int)db1.ExecuteScalar(cmd);

                                            if (estado == "BL") { id_estado = id_estado_blo; }
                                            else if (estado == "RE") { id_estado = id_estado_res; }
                                            else { id_estado = id_estado_dis; }

                                            cmd = db1.GetSqlStringCommand("IF @id_contrato=0 BEGIN	SELECT @id_contrato = NULL END IF @id_reversion=0 BEGIN	SELECT @id_reversion = NULL	END INSERT INTO [estado_lote]([id_estado],[id_lote],[id_contrato],[id_reversion],[id_usuario],[fecha],[observacion]) VALUES (@id_estado,@id_lote,@id_contrato,@id_reversion,@id_usuario,'30/12/1899',@observacion)");
                                            db1.AddInParameter(cmd, "id_estado", DbType.Int32, id_estado);
                                            db1.AddInParameter(cmd, "id_lote", DbType.Int32, id_lote);
                                            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, 0);
                                            db1.AddInParameter(cmd, "id_reversion", DbType.Int32, 0);
                                            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                                            db1.AddInParameter(cmd, "observacion", DbType.String, "");
                                            db1.ExecuteNonQuery(cmd);
                                            m_lotes.num_migrado += 1;
                                        }


                                    }
                                    catch (Exception ex)
                                    {
                                        m_lotes.num_error += 1;
                                        m_lotes.NewMens("Error", "", "nombre(manzano/lote): " + manzano + "/" + codigo + "; Mensaje de error: " + ex.Message);
                                    }
                                }
                                else
                                {
                                    m_lotes.num_repetido += 1;
                                    m_lotes.NewMens("Repetido", "nombre(manzano/lote): ", " " + manzano + "/" + codigo + "");
                                }
                            }
                        }
                        else
                        {
                            m_lotes.num_error += 1;
                            m_lotes.NewMens("Error", "", "num(manzano no encontrado): " + manzano + ";");
                        }
                    }
                }

            }
            else
            {
                m_lotes.num_error += 1;
                m_lotes.NewMens("Error", "", "num(sector no encontrado): " + cod_urb + ";");
            }
        }

        //NEGOCIO / ROLDAN
        cmd = db1.GetSqlStringCommand("select l.[id_lote] from [lote] l ,[manzano] m,[urbanizacion] u WHERE l.[id_manzano] = m.[id_manzano] AND m.[id_urbanizacion] = u.[id_urbanizacion] AND u.[nombre_corto] = 'GARAJE./00(l)'  AND m.[codigo] = '0' AND l.[codigo] = '08'");
        int id_lote_roldan = (int)db1.ExecuteScalar(cmd);
        cmd = db1.GetSqlStringCommand("SELECT [id_negocio] FROM [negocio] WHERE UPPER([codigo])='ROLDAN'");
        int id_negocio_roldan = (int)db1.ExecuteScalar(cmd);

        //NEGOCIO_LOTE
        cmd = db1.GetSqlStringCommand("UPDATE [negocio_lote] SET [id_negocio]= @id_negocio WHERE [id_negociolote]=@id_negociolote");
        db1.AddInParameter(cmd, "id_negociolote", DbType.Int32, id_lote_roldan);
        db1.AddInParameter(cmd, "id_negocio", DbType.Int32, id_negocio_roldan);
        db1.ExecuteNonQuery(cmd);

        return m_lotes.Datos();
    }

    public static string MigrarDosificaciones()
    {
        migracionResumen m_dosifics = new migracionResumen("Dosificaciones", true);
        //Datos a migrar:
        DbCommand cmd = db1.GetSqlStringCommand("select distinct ci_cob,desde,hasta,fecha from sat_cob_dosi order by 2");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_sat_dos = db1.ExecuteDataSet(cmd).Tables[0];
        //Migración de [sat_cob_dosi]:
        foreach (DataRow fila in tabla_sat_dos.Rows)
        {

            m_dosifics.num_encontrato += 1;

            string ci_cob = Formato((fila["ci_cob"]).ToString());
            int desde = int.Parse(Formato(fila["desde"].ToString()));
            int hasta = int.Parse(Formato(fila["hasta"].ToString()));
            DateTime fecha = DateTime.Parse(Formato(fila["fecha"].ToString()));
            if (ci_cob == "9999999") { ci_cob = "99999999"; }
            cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT [id_usuario] FROM [usuario] WHERE RTRIM(LTRIM([ci]))=@ci_cob),0)");
            db1.AddInParameter(cmd, "ci_cob", DbType.String, ci_cob);
            int id_usuario = (int)db1.ExecuteScalar(cmd);
            if (id_usuario > 0)
            {

                //VERIFICAR QUE NO EXISTE LA DOSIFICACION
                string query = "SELECT ISNULL((select distinct top 1 [id_dosificacion] from [dosificacion] where " + desde + " between desde and  hasta),0)";
                cmd = db1.GetSqlStringCommand(query);
                if ((int)db1.ExecuteScalar(cmd) == 0)
                {
                    try
                    {

                        cmd = db1.GetSqlStringCommand("INSERT INTO [dosificacion]([id_usuario],[desde],[hasta],[fecha],[activo]) VALUES (@id_usuario,@desde,@hasta,@fecha,@activo) DECLARE @id_dosificacion int 	SET @id_dosificacion=IDENT_CURRENT('dosificacion') SELECT @id_dosificacion");
                        db1.AddInParameter(cmd, "id_usuario", DbType.Int32, id_usuario);
                        db1.AddInParameter(cmd, "desde", DbType.Int32, desde);
                        db1.AddInParameter(cmd, "hasta", DbType.Int32, hasta);
                        db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                        db1.AddInParameter(cmd, "activo", DbType.Boolean, true);
                        int id_dosificacion = (int)db1.ExecuteScalar(cmd);
                        m_dosifics.num_migrado += 1;


                        //CREAR RECIBOS
                        for (int contador = desde; contador <= hasta; contador++)
                        {
                            cmd = db1.GetSqlStringCommand("INSERT INTO [recibo_cobrador]([id_dosificacion],[numero],[activo]) VALUES (@id_dosificacion,@numero,@activo)");
                            db1.AddInParameter(cmd, "id_dosificacion", DbType.Int32, id_dosificacion);
                            db1.AddInParameter(cmd, "numero", DbType.Int32, contador);
                            db1.AddInParameter(cmd, "activo", DbType.Boolean, true);
                            db1.ExecuteNonQuery(cmd);
                        }
                    }
                    catch (Exception ex)
                    {
                        m_dosifics.num_error += 1;
                        m_dosifics.NewMens("Error", "", "nombre(dosificacion): " + desde + "/" + hasta + " ; Mensaje de error: " + ex.Message);
                    }
                }
                else
                {
                    m_dosifics.num_repetido += 1;
                    m_dosifics.NewMens("Repetido", "[dosificacion]", " " + desde + "/" + hasta + "");
                }
            }
            else
            {
                m_dosifics.num_error += 1;
                m_dosifics.NewMens("Error", "", "num(usuario no encontrada): " + ci_cob + ";");
            }
        }

        return m_dosifics.Datos();
    }

    public static string MigrarReprogramaciones(int Context_id_usuario)
    {
        migracionResumen m_reprog = new migracionResumen("Reprogramaciones", true);
        //Lista de contratos:
        //DbCommand cmd = db1.GetSqlStringCommand("SELECT distinct r.ncontrato,r.n_repro,r.modo from sat_reprog as r where r.[n_repro] = (SELECT  max(n_repro) from sat_reprog WHERE ncontrato = r.ncontrato)order by 1");
        DbCommand cmd = db1.GetSqlStringCommand("SELECT distinct r.ncontrato,r.n_repro,r.modo from sat_reprog as r where r.[n_repro] = (SELECT  max(n_repro) from sat_reprog WHERE ncontrato = r.ncontrato AND modo <> 'P' )order by 1");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_contratos = db1.ExecuteDataSet(cmd).Tables[0];
        //Migración de [sat_reprog]:
        foreach (DataRow fila_contratos in tabla_contratos.Rows)
        {
            int ncontrato = int.Parse(fila_contratos["ncontrato"].ToString());
            int n_repro = int.Parse(fila_contratos["n_repro"].ToString());
            string modo = Formato(fila_contratos["modo"].ToString());
            //SE RECUPERAN LAS REPROGRAMACIONES PARA CADA CONTRATO
            //string query = "(SELECT c.[ncontrato],(SELECT [id_contrato] FROM [contrato] WHERE [numero] = c.[ncontrato]) as 'id_contrato',( SELECT [id_planpago] FROM [dbo].[t_contrato_PlanPago_Vigente]((SELECT [id_contrato] FROM [contrato] WHERE [numero] = c.[ncontrato]))) as 'id_pp_vigente',((ISNULL((SELECT top 1 p.[id_pago] FROM [pago] as p, [tipo_pago] as tp WHERE p.[id_tipopago]=tp.[id_tipopago] AND p.[id_contrato]=(SELECT [id_contrato] FROM [contrato] WHERE [numero] = c.[ncontrato])  AND p.[anulado]=0 AND tp.[codigo]='ini'),0))) as 'id_cuota_inicial',c.[fecha],c.[ncuotas],c.[n_repro] as 'seguro',(CASE WHEN c.[nuevoint] < 1 THEN (c.[nuevoint] * 100) ELSE c.[nuevoint] END) as 'interes_corriente', (SELECT [valor] FROM [parametro] WHERE UPPER([nombre]) = 'TASA_MORA') as 'interes_penal',c.[cuobase]	as 'cuota_mes',0 as 'saldo',(CASE ISNULL((SELECT TOP 1 [fecha] FROM [sat_datoshist]  WHERE [ncontrato] = c.[ncontrato] AND [n_repro] = c.[n_repro]),'') WHEN  '' THEN (SELECT [fecha] FROM [sat_datoscred]  WHERE [ncontrato] = c.[ncontrato]) ELSE (SELECT TOP 1 ISNULL([fecha],'') FROM [sat_datoshist]  WHERE [ncontrato] = c.[ncontrato] AND [n_repro] = c.[n_repro]) END) as 'fecha_inicio_plan',c.[modo],c.[n_trans],c.[n_repro] FROM [sat_reprog] as c WHERE c.[ncontrato] = @ncontrato AND c.[modo] = 'R') UNION (SELECT c.[ncontrato],(SELECT [id_contrato] FROM [contrato] WHERE [numero] = c.[ncontrato]) as 'id_contrato',(SELECT [id_planpago] FROM [dbo].[t_contrato_PlanPago_Vigente]((SELECT [id_contrato] FROM [contrato] WHERE [numero] = c.[ncontrato]))) as 'id_pp_vigente',((ISNULL((SELECT top 1 p.[id_pago] FROM [pago] as p, [tipo_pago] as tp WHERE p.[id_tipopago]=tp.[id_tipopago] AND p.[id_contrato]=(SELECT [id_contrato] FROM [contrato] WHERE [numero] = c.[ncontrato])  AND p.[anulado]=0 AND tp.[codigo]='ini'),0))) as 'id_cuota_inicial',c.[fecha],c.[ncuotas],c.[n_repro] as 'seguro',(select [intan] from sat_datoscred where [ncontrato]=c.[ncontrato])  as 'interes_corriente', (SELECT [valor] FROM [parametro] WHERE UPPER([nombre]) = 'TASA_MORA') as 'interes_penal',c.[cuobase]	as 'cuota_mes',  (SELECT (select s.[saldocapit] from (select top 1 a.[numero],a.[saldocapit] from ((select distinct [numero],[saldocapit] from sat_amortiz where  ncontrato = c.[ncontrato]) UNION (select distinct [numero],[saldocapit] from sat_amohist where  ncontrato = c.[ncontrato])) as a order by 1 desc) as s)) as  'saldo', (SELECT [fecha] FROM [sat_datoscred]  WHERE [ncontrato] = c.[ncontrato]) as 'fecha_inicio_plan', c.[modo],c.[n_trans],c.[n_repro] FROM [sat_reprog] as c WHERE c.[ncontrato] = @ncontrato AND c.[n_repro] = @n_repro AND c.[modo] = 'P') ORDER BY 12";
            string query = "(SELECT c.[ncontrato],(SELECT [id_contrato] FROM [contrato] WHERE [numero] = c.[ncontrato]) as 'id_contrato',( SELECT [id_planpago] FROM [dbo].[t_contrato_PlanPago_Vigente]((SELECT [id_contrato] FROM [contrato] WHERE [numero] = c.[ncontrato]))) as 'id_pp_vigente',((ISNULL((SELECT top 1 p.[id_pago] FROM [pago] as p, [tipo_pago] as tp WHERE p.[id_tipopago]=tp.[id_tipopago] AND p.[id_contrato]=(SELECT [id_contrato] FROM [contrato] WHERE [numero] = c.[ncontrato])  AND p.[anulado]=0 AND tp.[codigo]='ini'),0))) as 'id_cuota_inicial',c.[fecha],c.[ncuotas],c.[n_repro] as 'seguro',(CASE WHEN c.[nuevoint] < 1 THEN (c.[nuevoint] * 100) ELSE c.[nuevoint] END) as 'interes_corriente', (SELECT [valor] FROM [parametro] WHERE UPPER([nombre]) = 'TASA_MORA') as 'interes_penal',c.[cuobase]	as 'cuota_mes',0 as 'saldo',(CASE ISNULL((SELECT TOP 1 [fecha] FROM [sat_datoshist] WHERE [ncontrato] = c.[ncontrato] AND [n_repro] = c.[n_repro]),'') WHEN  '' THEN (SELECT [fecha] FROM [sat_datoscred]  WHERE [ncontrato] = c.[ncontrato]) ELSE (SELECT TOP 1 ISNULL([fecha],'') FROM [sat_datoshist]  WHERE [ncontrato] = c.[ncontrato] AND [n_repro] = c.[n_repro]) END) as 'fecha_inicio_plan',c.[modo],c.[n_trans],c.[n_repro] FROM [sat_reprog] as c WHERE c.[ncontrato] = @ncontrato AND c.[modo] = 'R') ORDER BY 12";
            cmd = db1.GetSqlStringCommand(query);
            db1.AddInParameter(cmd, "ncontrato", DbType.String, ncontrato);
            db1.AddInParameter(cmd, "n_repro", DbType.String, n_repro);
            DataTable tabla_sat_reprog = db1.ExecuteDataSet(cmd).Tables[0];

            foreach (DataRow fila in tabla_sat_reprog.Rows)
            {
                int id_pago = int.Parse(fila["id_cuota_inicial"].ToString());
                int id_contrato = int.Parse(fila["id_contrato"].ToString());
                DateTime fecha = DateTime.Parse(fila["fecha"].ToString());
                int ncuotas = int.Parse(fila["ncuotas"].ToString());
                int seguro = int.Parse(fila["seguro"].ToString());
                decimal interes_corriente = decimal.Parse(fila["interes_corriente"].ToString());
                decimal interes_penal = decimal.Parse(fila["interes_penal"].ToString());
                decimal cuota_mes = decimal.Parse(fila["cuota_mes"].ToString());
                decimal saldo = decimal.Parse(fila["saldo"].ToString());
                DateTime fecha_inicio_plan = DateTime.Parse(fila["fecha_inicio_plan"].ToString());
                string modo_r = Formato(fila["modo"].ToString());
                int n_repro_r = int.Parse(fila["n_repro"].ToString());
                decimal n_trans = decimal.Parse(fila["n_trans"].ToString());
                int id_plan_pago_vigente = int.Parse(fila["id_pp_vigente"].ToString());

                cmd = db1.GetSqlStringCommand("SELECT ISNULL((SELECT count([id_planpago]) FROM [plan_pago] WHERE [id_contrato] = @id_contrato AND [seguro] = @n_repro),0)");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                db1.AddInParameter(cmd, "n_repro", DbType.Int32, n_repro_r);
                int num_reprog = (int)db1.ExecuteScalar(cmd);

                if (num_reprog == 0)
                {
                    bool vigente = false;
                    //SE ACTIVA LA ULTIMA REPROGRAMACION QUE SE INGRESE  Y SE DESACTIVA EL PLAN INICIAL
                    if (n_repro == n_repro_r)
                    {
                        vigente = true;
                        if (id_plan_pago_vigente > 0)
                        {
                            cmd = db1.GetSqlStringCommand("UPDATE [plan_pago] SET [vigente] = 0 WHERE [id_planpago] = @id_planpago");
                            db1.AddInParameter(cmd, "id_planpago", DbType.Int32, id_plan_pago_vigente);
                            db1.ExecuteNonQuery(cmd);
                        }
                        //SE CALCULA LA CUOTA BASE EN CASO DE SER NECESARIO
                        if (modo_r == "P" & saldo > 0 & ncuotas > 0)
                        {
                            cuota_mes = terrasur.simular.Obtener_cuota_base(saldo, ncuotas, 0, 0, interes_corriente);
                        }
                    }

                    //PARA CONTRATOS CON ID_PAGO INICIAL MAYOR A CERO 
                    if (id_pago > 0)
                    {
                        m_reprog.num_encontrato += 1;

                        try
                        {
                            cmd = db1.GetSqlStringCommand("INSERT INTO [plan_pago]([id_contrato],[id_pago],[id_usuario],[fecha],[vigente],[num_cuotas],[seguro],[mantenimiento_sus],[interes_corriente],[interes_penal],[cuota_base],[fecha_inicio_plan]) VALUES(@id_contrato,@id_pago,@id_usuario,@fecha,@vigente,@num_cuotas,@seguro,@mantenimiento_sus,@interes_corriente,@interes_penal, @cuota_base,@fecha_inicio_plan)");
                            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                            db1.AddInParameter(cmd, "id_pago", DbType.Int32, id_pago);
                            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                            db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                            db1.AddInParameter(cmd, "vigente", DbType.Boolean, vigente);
                            db1.AddInParameter(cmd, "num_cuotas", DbType.Int32, ncuotas);
                            db1.AddInParameter(cmd, "seguro", DbType.Decimal, n_repro_r);
                            db1.AddInParameter(cmd, "mantenimiento_sus", DbType.Decimal, n_trans);
                            db1.AddInParameter(cmd, "interes_corriente", DbType.Decimal, interes_corriente);
                            db1.AddInParameter(cmd, "interes_penal", DbType.Decimal, interes_penal);
                            db1.AddInParameter(cmd, "cuota_base", DbType.Decimal, cuota_mes);
                            db1.AddInParameter(cmd, "fecha_inicio_plan", DbType.DateTime, fecha_inicio_plan);
                            db1.ExecuteNonQuery(cmd);
                            m_reprog.num_migrado += 1;
                        }
                        catch (Exception ex)
                        {
                            m_reprog.num_error += 1;
                            m_reprog.msg.Add(new Mens("Error", "", "Contrato: " + ncontrato.ToString() + " ; No. reprog: " + n_repro_r + " ; Mensaje de error: " + ex.Message));
                        }
                    }
                }
                else
                {
                    m_reprog.num_repetido += 1;
                    m_reprog.msg.Add(new Mens("Repetido", "[contrato]", "No.: " + ncontrato.ToString() + "; Reprogramaciones ya migradas"));
                }
            }
        }
        //Se actualiza la columna [seguro] a 0 borrando los n_repro para los nuevos registros 
        //cmd = db1.GetSqlStringCommand("UPDATE [plan_pago] SET [seguro] = 0");
        //db1.ExecuteNonQuery(cmd);

        //Los resultados:
        return m_reprog.Datos();
    }

    public static string MigrarReversiones(int Context_id_usuario)
    {
        migracionResumen m_reversion = new migracionResumen("Reversiones", true);
        //Datos a migrar:
        DbCommand cmd = db1.GetSqlStringCommand("(SELECT (SELECT [id_contrato] FROM [contrato] WHERE [numero] = r.[ncontrato]) as 'id_contrato',r.[ncontrato],CASE r.[razon] WHEN 'CAM' THEN (SELECT [id_motivoreversion] FROM [motivo_reversion] WHERE UPPER(codigo) = 'CAMBIO') ELSE (CASE WHEN r.[diasmora]<=0 THEN (SELECT [id_motivoreversion] FROM [motivo_reversion] WHERE UPPER(codigo) = 'FUERZA') ELSE (SELECT [id_motivoreversion] FROM [motivo_reversion] WHERE UPPER(codigo) = 'MORA') END) END as 'id_motivoreversion',r.[fecha],	r.[diasmora],r.[pagado],r.[sd] FROM [sat_revertid] as r WHERE [estado] = 'X') UNION (SELECT (SELECT [id_contrato] FROM [contrato] WHERE [numero] = d.[ncontrato]) as 'id_contrato',d.[ncontrato],CASE d.[estado] WHEN 'AN' THEN (SELECT [id_motivoreversion] FROM [motivo_reversion] WHERE UPPER(codigo) = 'ANULADO') ELSE ((SELECT [id_motivoreversion] FROM [motivo_reversion] WHERE UPPER(codigo) = 'RG')) END as 'id_motivoreversion',CASE d.[fecharev] WHEN '30/12/1899' THEN DATEADD(day,1,d.[fechaing]) ELSE  d.[fecharev] END as 'fecharev',0 as 'diasmora',0 as 'pagado',CASE WHEN ISNULL((SELECT MIN([saldocapit]) FROM [sat_amohist] WHERE [ncontrato] = d.[ncontrato]),'999999') = '999999' THEN CASE WHEN ISNULL((SELECT MIN([saldocapit]) FROM [sat_inihist] WHERE [ncontrato] = d.[ncontrato]),'999999') = '999999' THEN d.[valorsitio] ELSE (SELECT MIN([saldocapit]) FROM [sat_inihist] WHERE [ncontrato] = d.[ncontrato]) END ELSE (SELECT MIN([saldocapit]) FROM [sat_amohist] WHERE [ncontrato] = d.[ncontrato]) END as 'sd' FROM [sat_datoscred] d WHERE d.[ncontrato] not in ( SELECT DISTINCT [ncontrato] FROM [sat_revertid]) AND d.[estado] in ('RG','AN') AND [ncontrato] <> 1001201020 ) ORDER BY 1");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_sat_revertid = db1.ExecuteDataSet(cmd).Tables[0];
        //Migración de [sat_revertid]:
        foreach (DataRow fila in tabla_sat_revertid.Rows)
        {
            m_reversion.num_encontrato += 1;

            int id_contrato = int.Parse(fila["id_contrato"].ToString());
            int ncontrato = int.Parse(fila["ncontrato"].ToString());
            int id_motivoreversion = int.Parse(fila["id_motivoreversion"].ToString());
            DateTime fecha = DateTime.Parse(fila["fecha"].ToString());
            int diasmora = int.Parse(fila["diasmora"].ToString());
            decimal pagado = decimal.Parse(fila["pagado"].ToString());
            decimal sd = decimal.Parse(fila["sd"].ToString());

            cmd = db1.GetSqlStringCommand("SELECT COUNT([id_reversion]) FROM [reversion] WHERE [id_contrato]=@id_contrato AND [anulado]=0");
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
            if ((int)db1.ExecuteScalar(cmd) == 0)
            {
                try
                {
                    cmd = db1.GetSqlStringCommand("INSERT INTO [reversion]([id_usuario],[id_contrato],[id_motivoreversion],[fecha],[dias_mora],[cuotas_mora],[capital_pagado],[capital_adeuda],[anulado]) VALUES (@id_usuario_r,@id_contrato_r,@id_motivoreversion_r,@fecha,@dias_mora_r,@cuotas_mora_r,@capital_pagado_r,@capital_adeuda_r,0) DECLARE @id_reversion_r int SET @id_reversion_r =IDENT_CURRENT('reversion') SELECT @id_reversion_r");
                    db1.AddInParameter(cmd, "id_usuario_r", DbType.Int32, Context_id_usuario);
                    db1.AddInParameter(cmd, "id_contrato_r", DbType.Int32, id_contrato);
                    db1.AddInParameter(cmd, "id_motivoreversion_r", DbType.Int32, id_motivoreversion);
                    db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                    db1.AddInParameter(cmd, "dias_mora_r", DbType.Int32, diasmora);
                    db1.AddInParameter(cmd, "cuotas_mora_r", DbType.Int32, 0);
                    db1.AddInParameter(cmd, "capital_pagado_r", DbType.Double, pagado);
                    db1.AddInParameter(cmd, "capital_adeuda_r", DbType.Double, sd);
                    int id_reversion = (int)db1.ExecuteScalar(cmd);
                    m_reversion.num_migrado += 1;


                    //SE INGRESA EL REGISTRO DE NEGOCIO_CONTRATO
                    cmd = db1.GetSqlStringCommand("(SELECT [id_negocio],ISNULL([id_negociolote],0) as 'id_negociolote',(SELECT [id_pago] FROM [dbo].[t_contrato_UltimoPago](@id_contrato,@fecha)) as 'id_ultimo_pago',CONVERT(numeric(10,2),(([saldo_capital] - @capital_pagado) * (-1))) as 'saldo_capital_revertido',CONVERT(numeric(10,2),(([saldo_costo] - ([saldo_costo] * (@capital_pagado / [saldo_capital]))) * (-1))) as 'saldo_costo_revertido' FROM [negocio_contrato] WHERE [id_negociocontrato] = (SELECT [id_negociocontrato] FROM [dbo].[t_contrato_NegocioContrato](@id_contrato)) AND [anulado] = 0)");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                    db1.AddInParameter(cmd, "capital_pagado", DbType.Double, pagado);
                    db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                    DataTable tabla_negocio_contrato = db1.ExecuteDataSet(cmd).Tables[0];
                    int id_negocio = 0;
                    int id_negociolote = 0;
                    int id_ultimo_pago = 0;
                    decimal saldo_capital_revertido = 0;
                    decimal saldo_costo_revertido = 0;
                    if (tabla_negocio_contrato.Rows.Count > 0)
                    {
                        id_negocio = int.Parse(Formato(tabla_negocio_contrato.Rows[0]["id_negocio"].ToString()));
                        id_negociolote = int.Parse(Formato(tabla_negocio_contrato.Rows[0]["id_negociolote"].ToString()));
                        id_ultimo_pago = int.Parse(Formato(tabla_negocio_contrato.Rows[0]["id_ultimo_pago"].ToString()));
                        saldo_capital_revertido = decimal.Parse(Formato(tabla_negocio_contrato.Rows[0]["saldo_capital_revertido"].ToString()));
                        saldo_costo_revertido = decimal.Parse(Formato(tabla_negocio_contrato.Rows[0]["saldo_costo_revertido"].ToString()));
                    }

                    //NEGOCIO_CONTRATO
                    cmd = db1.GetSqlStringCommand("DECLARE @id_negociolote1 int IF @id_negociolote=0 BEGIN SET @id_negociolote1=NULL END ELSE BEGIN	SET @id_negociolote1=@id_negociolote END DECLARE @id_pago1 int IF @id_pago=0 BEGIN 	SET @id_pago1=NULL END ELSE BEGIN SET @id_pago1=@id_pago END INSERT INTO [negocio_contrato] ([id_negocio],[id_contrato],[id_usuario],[id_negociolote],[id_pago],[id_reversion],[fecha],[saldo_capital],[saldo_costo],[anulado])	VALUES (@id_negocio,@id_contrato,@id_usuario,@id_negociolote1,@id_pago1,@id_reversion,@fecha,@saldo_capital,@saldo_costo,0)");
                    db1.AddInParameter(cmd, "id_negocio", DbType.Int32, id_negocio);
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                    db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                    db1.AddInParameter(cmd, "id_negociolote", DbType.Int32, id_negociolote);
                    db1.AddInParameter(cmd, "id_pago", DbType.Int32, id_ultimo_pago);
                    db1.AddInParameter(cmd, "id_reversion", DbType.Int32, id_reversion);
                    db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                    db1.AddInParameter(cmd, "saldo_capital", DbType.Decimal, (sd * (-1)));
                    db1.AddInParameter(cmd, "saldo_costo", DbType.Decimal, saldo_costo_revertido);
                    db1.ExecuteNonQuery(cmd);

                    //ESTADO_LOTE SI ES CONTRATO VENTA
                    cmd = db1.GetSqlStringCommand(" SELECT ISNULL((SELECT [id_lote] FROM [contrato_venta] WHERE [id_contrato]=@id_contrato),0) as 'id_lote'");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                    int id_lote = (int)db1.ExecuteScalar(cmd);
                    if (id_lote > 0)
                    {
                        cmd = db1.GetSqlStringCommand("SELECT [id_estado] FROM [estado] WHERE UPPER([codigo]) = 'DIS'");
                        int id_estado = (int)db1.ExecuteScalar(cmd);
                        cmd = db1.GetSqlStringCommand("IF @id_contrato=0 BEGIN	SELECT @id_contrato = NULL END IF @id_reversion=0 BEGIN	SELECT @id_reversion = NULL	END INSERT INTO [estado_lote]([id_estado],[id_lote],[id_contrato],[id_reversion],[id_usuario],[fecha],[observacion]) VALUES (@id_estado,@id_lote,@id_contrato,@id_reversion,@id_usuario,@fecha,@observacion)");
                        db1.AddInParameter(cmd, "id_estado", DbType.Int32, id_estado);
                        db1.AddInParameter(cmd, "id_lote", DbType.Int32, id_lote);
                        db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                        db1.AddInParameter(cmd, "id_reversion", DbType.Int32, id_reversion);
                        db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                        db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                        db1.AddInParameter(cmd, "observacion", DbType.String, "Reversión");
                        db1.ExecuteNonQuery(cmd);
                    }


                }
                catch (Exception ex)
                {
                    m_reversion.num_error += 1;
                    m_reversion.msg.Add(new Mens("Error", "", "Num. contrato: " + ncontrato + " ; Mensaje de error: " + ex.Message));
                }
            }
            else
            {
                m_reversion.num_repetido += 1;
                m_reversion.msg.Add(new Mens("Repetido", "[reversion]", "Num. contrato: " + ncontrato + " ;"));
            }
        }

        //Los resultados:
        return m_reversion.Datos();
    }

    public static string MigrarICA()
    {
        migracionResumen m_ica = new migracionResumen("Interes Corriente Acumulado", true);
        //Datos a migrar:
        DbCommand cmd = db1.GetSqlStringCommand("select [ncontrato],(SELECT [id_contrato] FROM [contrato] WHERE [numero] = [ncontrato]) as 'id_contrato',SUM([montosus]) as 'monto' from sat_int_acu group by ncontrato having sum(montosus) > 0 order by 1");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_sat_ica = db1.ExecuteDataSet(cmd).Tables[0];
        //Migración de [sat_int_acu]:
        foreach (DataRow fila in tabla_sat_ica.Rows)
        {
            m_ica.num_encontrato += 1;

            int ncontrato = int.Parse(fila["ncontrato"].ToString());
            int id_contrato = int.Parse(fila["id_contrato"].ToString());
            decimal monto = decimal.Parse(fila["monto"].ToString());
            cmd = db1.GetSqlStringCommand("SELECT COUNT([id_contrato]) FROM [interes_acumulado] WHERE [id_contrato]=@id_contrato");
            db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
            if ((int)db1.ExecuteScalar(cmd) == 0)
            {
                try
                {
                    cmd = db1.GetSqlStringCommand("INSERT INTO [interes_acumulado]([id_contrato],[monto]) VALUES (@id_contrato,@monto)");
                    db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                    db1.AddInParameter(cmd, "monto", DbType.Decimal, monto);

                    db1.ExecuteNonQuery(cmd);
                    m_ica.num_migrado += 1;
                }
                catch (Exception ex)
                {
                    m_ica.num_error += 1;
                    m_ica.msg.Add(new Mens("Error", "", "Contrato: " + ncontrato + " ; Mensaje de error: " + ex.Message));
                }
            }
            else
            {
                m_ica.num_repetido += 1;
                m_ica.msg.Add(new Mens("Repetido", "[Contrato]", "Número: " + ncontrato + " ;"));
            }
        }

        //Los resultados:
        return m_ica.Datos();
    }

    public static string ActualizarPlanPago()
    {
        migracionResumen m_pp = new migracionResumen("Actualización de Planes de Pagos", true);
        //Datos a migrar:
        DbCommand cmd = db1.GetSqlStringCommand("SELECT pp.[id_planpago],pp.[mantenimiento_sus] as 'ntrans',ISNULL((SELECT MAX(p.[id_pago]) FROM [pago] as p, [transaccion] as t  WHERE p.[id_transaccion] = t.[id_transaccion] AND t.[ntrans] = pp.[mantenimiento_sus] AND p.[id_contrato] = pp.[id_contrato]),0) as 'id_pago_nuevo' FROM [plan_pago] as pp WHERE pp.[mantenimiento_sus] > 0 ORDER BY 3");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_pagos = db1.ExecuteDataSet(cmd).Tables[0];
        //Migración de []:
        int pagos_cero = 0;
        foreach (DataRow fila in tabla_pagos.Rows)
        {
            m_pp.num_encontrato += 1;

            int id_planpago = int.Parse(fila["id_planpago"].ToString());
            int ntrans = (int)decimal.Parse(fila["ntrans"].ToString());
            int id_pago_nuevo = int.Parse(fila["id_pago_nuevo"].ToString());
            if (id_pago_nuevo > 0)
            {
                cmd = db1.GetSqlStringCommand("SELECT COUNT([id_pago]) FROM [plan_pago] WHERE [id_pago]=@id_pago");
                db1.AddInParameter(cmd, "id_pago", DbType.Int32, id_pago_nuevo);
                if ((int)db1.ExecuteScalar(cmd) == 0)
                {
                    try
                    {
                        cmd = db1.GetSqlStringCommand("UPDATE [plan_pago] SET [id_pago]= @id_pago WHERE [id_planpago]=@id_planpago");
                        db1.AddInParameter(cmd, "id_planpago", DbType.Int32, id_planpago);
                        db1.AddInParameter(cmd, "id_pago", DbType.Int32, id_pago_nuevo);
                        db1.ExecuteNonQuery(cmd);
                        m_pp.num_migrado += 1;
                    }
                    catch (Exception ex)
                    {
                        m_pp.num_error += 1;
                        m_pp.msg.Add(new Mens("Error", "", "ID Plan Pago: " + id_planpago + " ; Mensaje de error: " + ex.Message));
                    }
                }
                else
                {
                    m_pp.num_repetido += 1;
                    m_pp.msg.Add(new Mens("Repetido", "[plan_pago]", "abrev: " + id_planpago + " ; [pago]: " + id_pago_nuevo));
                }
            }
            else
            {
                pagos_cero += 1;
                m_pp.msg.Add(new Mens("[id_pagos] no encontrados '" + pagos_cero + "'", "[id_planpago]", " " + id_planpago + " ;"));
            }
        }



        //Se actualiza la columna [manteniento_sus] a 0 borrando los ntrans para los nuevos registros 
        //cmd = db1.GetSqlStringCommand("UPDATE [plan_pago] SET [mantenimiento_sus] = 0");
        //db1.ExecuteNonQuery(cmd);

        //Los resultados:
        return m_pp.Datos();
    }

    public static string ActualizarNegocioLotes()
    {
        migracionResumen m_pp = new migracionResumen("Actualización de negocio de lotes (Terrasur)", true);
        //Datos a migrar:
        DbCommand cmd = db1.GetSqlStringCommand("(SELECT l.[id_lote] as 'id_lote' FROM [urbanizacion] as u, [manzano] as m, [lote] as l WHERE u.[id_urbanizacion] = m.[id_urbanizacion] AND m.[id_manzano] = l.[id_manzano] AND UPPER(u.[nombre_corto]) LIKE '%LINDA%') UNION (SELECT l.[id_lote] FROM [urbanizacion] as u, [manzano] as m, [lote] as l WHERE u.[id_urbanizacion] = m.[id_urbanizacion] AND m.[id_manzano] = l.[id_manzano] AND UPPER(u.[nombre_corto]) LIKE '%BONIT%') ORDER BY 1");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla_lotes = db1.ExecuteDataSet(cmd).Tables[0];
        //Migración de []:
        foreach (DataRow fila in tabla_lotes.Rows)
        {
            m_pp.num_encontrato += 1;

            int id_lote = int.Parse(fila["id_lote"].ToString());
            if (id_lote > 0)
            {
                //NEGOCIO / TERRASUR
                cmd = db1.GetSqlStringCommand("SELECT [id_negocio] FROM [negocio] WHERE UPPER([codigo])='TERRA'");
                int id_negocio = (int)db1.ExecuteScalar(cmd);
                if (id_negocio > 0)
                {
                    try
                    {

                        cmd = db1.GetSqlStringCommand("UPDATE [negocio_lote] SET [id_negocio]= @id_negocio WHERE [id_negociolote]=@id_negociolote");
                        db1.AddInParameter(cmd, "id_negociolote", DbType.Int32, id_lote);
                        db1.AddInParameter(cmd, "id_negocio", DbType.Int32, id_negocio);
                        db1.ExecuteNonQuery(cmd);
                        m_pp.num_migrado += 1;
                    }
                    catch (Exception ex)
                    {
                        m_pp.num_error += 1;
                        m_pp.msg.Add(new Mens("Error", "", "ID Lote: " + id_lote + " ; Mensaje de error: " + ex.Message));
                    }
                }
            }
            //    else
            //    {
            //        m_pp.num_repetido += 1;
            //        m_pp.msg.Add(new Mens("Repetido", "[plan_pago]", "abrev: " + id_planpago + " ; [pago]: " + id_pago_nuevo));
            //    }
            //}
            else
            {
                m_pp.msg.Add(new Mens("[id_lote] no encontrado", "[id_lote]", " " + id_lote + " ;"));
            }
        }


        //Los resultados:
        return m_pp.Datos();
    }

}
public class migracionResumen
{
    #region Propiedades
    //Propiedades privadas
    private string _nombre = "";
    private int _num_encontrato = 0;
    private int _num_migrado = 0;
    private int _num_repetido = 0;
    private int _num_error = 0;
    private DateTime _fecha_inicio;
    private DateTime _fecha_fin;
    private bool _mostrar_tiempo = false;
    //Propiedades públicas
    public string nombre { get { return _nombre; } set { _nombre = value; } }
    public int num_encontrato { get { return _num_encontrato; } set { _num_encontrato = value; } }
    public int num_migrado { get { return _num_migrado; } set { _num_migrado = value; } }
    public int num_repetido { get { return _num_repetido; } set { _num_repetido = value; } }
    public int num_error { get { return _num_error; } set { _num_error = value; } }
    public List<Mens> msg;
    public bool mostrar_tiempo { get { return _mostrar_tiempo; } set { _mostrar_tiempo = value; } }
    #endregion

    #region Constructores
    public migracionResumen(string Nombre)
    {
        _nombre = Nombre;
        msg = new List<Mens>();
        _fecha_inicio = DateTime.Now;
    }
    public migracionResumen(string Nombre, bool Mostrar_tiempo)
    {
        _nombre = Nombre;
        msg = new List<Mens>();
        _fecha_inicio = DateTime.Now;
        _mostrar_tiempo = Mostrar_tiempo;
    }
    #endregion

    #region Métodos que requieren constructor
    public void NewMens(string Tipo, string Especifico, string Msg)
    {
        msg.Add(new Mens(Tipo, Especifico, Msg));
    }
    public string Datos()
    {
        _fecha_fin = DateTime.Now; ;
        string nueva_linea = "<br/>";
        //char nueva_linea = Convert.ToChar(10);
        StringBuilder str = new StringBuilder();
        if (_mostrar_tiempo == true) str.Append(_nombre + " (" + _fecha_inicio.ToLongTimeString() + " - " + _fecha_fin.ToLongTimeString() + " ; " + _fecha_fin.Subtract(_fecha_inicio).ToString() + ")" + nueva_linea);
        else str.Append(_nombre + nueva_linea);
        str.Append("Nº registros encontrados: " + _num_encontrato.ToString() + nueva_linea);
        if (_num_encontrato > 0 || _num_repetido > 0 || _num_error > 0)
        {
            str.Append("Nº registros migrados: " + _num_migrado.ToString() + nueva_linea);
            str.Append("Nº registros ya existentes: " + _num_repetido.ToString() + nueva_linea);
            str.Append("Nº errores ocurridos: " + _num_error.ToString() + nueva_linea);
            if (msg.Count > 0)
            {
                str.Append("Mensajes:" + nueva_linea);
                foreach (Mens m in msg)
                {
                    str.Append(m.tipo);
                    if (m.especifico.Trim() != "") str.Append(" (" + m.especifico + ")");
                    str.Append(" --> " + m.msg + nueva_linea);
                }
            }
        }
        //str.Append(nueva_linea);
        str.Append("------------------------------------------------------------------------------");
        str.Append(nueva_linea);
        return str.ToString();//.Replace(nueva_linea, "\n");//.Replace('·', Convert.ToChar(10));
    }
    #endregion
}

public class Mens
{
    #region Propiedades
    //Propiedades privadas
    private string _tipo = "";
    private string _especifico = "";
    private string _msg = "";

    //Propiedades públicas
    public string tipo { get { return _tipo; } set { _tipo = value; } }
    public string especifico { get { return _especifico; } set { _especifico = value; } }
    public string msg { get { return _msg; } set { _msg = value; } }
    #endregion

    #region Constructores
    public Mens(string Tipo, string Especifico, string Msg)
    {
        _tipo = Tipo;
        _especifico = Especifico;
        _msg = Msg;
    }
    #endregion

}

