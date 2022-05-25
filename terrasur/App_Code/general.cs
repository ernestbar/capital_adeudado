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
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Xml;
using System.Text;
/// <summary>
/// Summary description for general
/// </summary>
namespace terrasur
{
    public class general
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        //#region Propiedades
        ////Propiedades privadas

        ////Propiedades públicas
        //#endregion

        //#region Constructores
        //#endregion

        //#region Métodos que NO requieren constructor
        //#endregion

        //#region Métodos que requieren constructor
        //#endregion


        #region Impresonalización para impresión de Facturas, Recibos y Comprobantes
        private static int LOGON32_LOGON_INTERACTIVE = 2;
        private static int LOGON32_PROVIDER_DEFAULT = 0;
        private static WindowsImpersonationContext impersonationContext;

        //[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [DllImport("advapi32.dll")]
        private static extern bool LogonUserA(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
        //[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [DllImport("advapi32.dll", SetLastError = true)]
        private extern static bool DuplicateToken(IntPtr ExistingTokenHandle, int SECURITY_IMPERSONATION_LEVEL, out IntPtr DuplicateTokenHandle);
        //[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool RevertToSelf();
        //[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);

        public static bool Impersonate_Context(string username, string domain, string password)
        {
            WindowsIdentity tmpWindowsIdentity;
            IntPtr token = IntPtr.Zero;

            IntPtr tokenDuplicate = IntPtr.Zero;
            bool impersonateValid = false;
            if (RevertToSelf())
            {
                if (LogonUserA(username, domain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref token))
                {
                    if (DuplicateToken(token, 2, out tokenDuplicate))
                    {
                        tmpWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                        impersonationContext = tmpWindowsIdentity.Impersonate();
                        if (impersonationContext != null)
                            impersonateValid = true;
                    }
                }
            }
            if (tokenDuplicate.Equals(IntPtr.Zero) == false) CloseHandle(tokenDuplicate);
            if (token.Equals(IntPtr.Zero) == false) CloseHandle(token);
            return impersonateValid;
        }
        public static void Impersonate_Undo() { impersonationContext.Undo(); }
        #endregion



        public general() { }
        public static string StringRandom(int Longitud)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            for (int j = 0; j < Longitud; j++)
            {
                Random rnd = new Random(j * DateTime.Now.Millisecond);
                int num = 97 + Convert.ToInt32(25 * rnd.NextDouble());
                str.Append(Convert.ToChar(num));
            }
            return str.ToString().TrimEnd(',');
        }
        public static void OnMouseOver(ref object sender, ref System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((GridView)sender).SelectedRowStyle.CssClass.Trim() != "")
                {
                    e.Row.Attributes.Add("onmouseover", "this.originalclass=this.className; this.className='" + ((GridView)sender).SelectedRowStyle.CssClass.Trim() + "';");
                    e.Row.Attributes.Add("onmouseout", "this.className=this.originalclass;");
                }
            }
        }
        public static void CambiarMasterPage(ref Page p, bool normal)
        {
            if (normal == true) p.MasterPageFile = "~/modulo/normal.master";
            else p.MasterPageFile = "~/modulo/simple.master";
        }
        public static string StringActivo(string activo)
        {
            if (bool.Parse(activo) == true) return "Activo";
            else return "Inactivo";
        }
        public static string Capitalize(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            return input[0].ToString().ToUpper() + input.ToLower().Substring(1, input.Length - 1);
        }
        public static string StringNegocios(bool query, ListItemCollection lista_items)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            int num_elegidos = 0;
            foreach (ListItem item in lista_items)
            {
                if (item.Selected)
                {
                    if (query) str.Append(item.Value + ",");
                    else str.Append(item.Text + ", ");
                    num_elegidos += 1;
                }
            }
            if (query)
            {
                if (num_elegidos > 0) return "," + str.ToString();
                else return "";
            }
            else
            {

                if (num_elegidos == lista_items.Count) return "Todos";
                else if (num_elegidos == 0) return "Ninguno";
                else return str.ToString().Trim().TrimEnd(',');
            }
        }

        public static void automatico_RevertirPreasignados()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("init_contrato_RevertirPreasignados");
                db1.ExecuteNonQuery(cmd);
            }
            catch { }
        }

        public static string MenuStringEliminados(int Id_usuario, int Id_rol/*, string codigo_modulo*/)
        {
            XmlDocument doc = new XmlDocument();
            //doc.Load(HttpContext.Current.Server.MapPath("~/modulo/" + codigo_modulo + "/mapa.sitemap"));
            doc.Load(HttpContext.Current.Server.MapPath("~/Web.sitemap"));
            StringBuilder sFinal = new StringBuilder();

            XmlNodeList xGrupoRecurso = doc.LastChild.FirstChild.ChildNodes;
            for (int g = 0; g < xGrupoRecurso.Count; g++)
            {
                StringBuilder sRecurso = new StringBuilder();
                int num_recurso_activo = 0;
                XmlNodeList xRecurso = xGrupoRecurso[g].ChildNodes;
                for (int r = 0; r < xRecurso.Count; r++)
                {
                    if (xRecurso[r].HasChildNodes)
                    {
                        StringBuilder sPermiso = new StringBuilder();
                        int num_permiso_activo = 0;
                        XmlNodeList xPermiso = xRecurso[r].ChildNodes;
                        for (int p = 0; p < xPermiso.Count; p++)
                        {
                            if (VerificarGrupoRecursoPermiso(Id_usuario, Id_rol, xGrupoRecurso[g].Attributes["resourceKey"].Value, xRecurso[r].Attributes["resourceKey"].Value, xPermiso[p].Attributes["resourceKey"].Value) == false)
                                sPermiso.Append(g.ToString() + "," + r.ToString() + "|" + p.ToString() + ";");
                            else num_permiso_activo += 1;
                        }
                        if (num_permiso_activo == 0) sRecurso.Append(g.ToString() + "," + r.ToString() + ";");
                        else
                        {
                            if (sPermiso.ToString() != "") sRecurso.Append(sPermiso.ToString());
                            num_recurso_activo += 1;
                        }
                    }
                    else
                    {
                        if (VerificarGrupoRecursoPermiso(Id_usuario, Id_rol, xGrupoRecurso[g].Attributes["resourceKey"].Value, xRecurso[r].Attributes["resourceKey"].Value, "") == false)
                            sRecurso.Append(g.ToString() + "," + r.ToString() + ";");
                        else { num_recurso_activo += 1; }
                    }
                }
                if (num_recurso_activo == 0) sFinal.Append(g.ToString() + ";");
                else { if (sRecurso.ToString() != "") sFinal.Append(sRecurso.ToString()); }
            }
            return sFinal.ToString().TrimEnd(';');
        }
        public static void MenuEliminarNodos(ref Menu menu, string eliminar)
        {
            //if (eliminar != "")
            //{
                string[] elim = eliminar.Split(';');
                for (int el = elim.Length - 1; el >= 0; el--)
                {
                    if (elim[el].Contains("|"))
                    {
                        int g = int.Parse(elim[el].Split(',')[0]);
                        int r = int.Parse(elim[el].Split(',')[1].Split('|')[0]);
                        int p = int.Parse(elim[el].Split(',')[1].Split('|')[1]);
                        if (menu.Items[0].ChildItems[g].ChildItems[r].ChildItems[p] != null)
                            menu.Items[0].ChildItems[g].ChildItems[r].ChildItems.RemoveAt(p);
                    }
                    else if (elim[el].Contains(","))
                    {
                        int g = int.Parse(elim[el].Split(',')[0]);
                        int r = int.Parse(elim[el].Split(',')[1]);
                        if (menu.Items[0].ChildItems[g].ChildItems[r] != null)
                            menu.Items[0].ChildItems[g].ChildItems.RemoveAt(r);
                    }
                    else if (elim[el] != "")
                    {
                        int g = int.Parse(elim[el]);
                        if (menu.Items[0].ChildItems[g] != null)
                            menu.Items[0].ChildItems.RemoveAt(g);
                    }
                }
            //}
        }
        private static bool VerificarGrupoRecursoPermiso(int Id_usuario, int Id_rol, string Grupo_recurso, string Recurso, string Permiso)
        {
            DbCommand cmd = db1.GetStoredProcCommand("usuario_MenuVerificarRecursoPermiso");
            db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Id_usuario);
            db1.AddInParameter(cmd, "id_rol", DbType.Int32, Id_rol);
            db1.AddInParameter(cmd, "gruporecurso", DbType.String, Grupo_recurso);
            db1.AddInParameter(cmd, "recurso", DbType.String, Recurso);
            db1.AddInParameter(cmd, "permiso", DbType.String, Permiso);
            if ((int)db1.ExecuteScalar(cmd) > 0) return true;
            else return false;
        }

        #region Temporal
        public static void LlenarModulos(TreeNode node)
        {
            DbCommand cmd1 = db1.GetStoredProcCommand("general_cargar_modulo");
            cmd1.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            foreach (DataRow row in db1.ExecuteDataSet(cmd1).Tables[0].Rows)
            {
                TreeNode NewNode = new TreeNode(row["nombre"].ToString() + " (" + row["codigo"].ToString() + ")", row["id_modulo"].ToString());
                //TreeNode NewNode = new TreeNode(row["nombre"].ToString(), row["id_modulo"].ToString());
                NewNode.PopulateOnDemand = true;
                NewNode.SelectAction = TreeNodeSelectAction.Expand;
                NewNode.Expanded = false;
                node.ChildNodes.Add(NewNode);
            }
        }
        public static void LlenarGrupoRecursos(TreeNode node)
        {
            DbCommand cmd1 = db1.GetStoredProcCommand("general_cargar_gruporecursos");
            cmd1.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd1, "id_modulo", DbType.Int32, Int32.Parse(node.Value));

            foreach (DataRow row in db1.ExecuteDataSet(cmd1).Tables[0].Rows)
            {
                TreeNode NewNode = new TreeNode(row["nombre"].ToString() + " (" + row["codigo"].ToString() + ")", row["id_gruporecurso"].ToString());
                //TreeNode NewNode = new TreeNode(row["nombre"].ToString(), row["id_gruporecurso"].ToString());
                NewNode.PopulateOnDemand = true;
                NewNode.SelectAction = TreeNodeSelectAction.Expand;
                NewNode.Expanded = false;
                node.ChildNodes.Add(NewNode);
            }
        }
        public static void LlenarRecursos(TreeNode node)
        {
            DbCommand cmd1 = db1.GetStoredProcCommand("general_cargar_recursos");
            cmd1.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd1, "id_gruporecurso", DbType.Int32, Int32.Parse(node.Value));
            foreach (DataRow row in db1.ExecuteDataSet(cmd1).Tables[0].Rows)
            {
                TreeNode NewNode = new TreeNode(row["nombre"].ToString() + " (" + row["codigo"].ToString() + ")", row["id_recurso"].ToString());
                //TreeNode NewNode = new TreeNode(row["nombre"].ToString(), row["id_recurso"].ToString());
                NewNode.PopulateOnDemand = true;
                NewNode.SelectAction = TreeNodeSelectAction.Expand;
                NewNode.Expanded = false;
                node.ChildNodes.Add(NewNode);
            }
        }
        public static void LlenarPermisos(TreeNode node)
        {
            DbCommand cmd1 = db1.GetStoredProcCommand("general_cargar_permisos");
            cmd1.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd1, "id_recurso", DbType.Int32, Int32.Parse(node.Value));
            foreach (DataRow row in db1.ExecuteDataSet(cmd1).Tables[0].Rows)
            {
                TreeNode NewNode = new TreeNode(row["nombre"].ToString() + " (" + row["codigo"].ToString() + ")", row["id_permiso"].ToString());
                //TreeNode NewNode = new TreeNode(row["nombre"].ToString(), row["id_permiso"].ToString());
                NewNode.PopulateOnDemand = false;
                NewNode.SelectAction = TreeNodeSelectAction.Expand;
                NewNode.Expanded = false;
                node.ChildNodes.Add(NewNode);
            }
        }
        public static void LlenarRoles(TreeNode node)
        {
            DbCommand cmd1 = db1.GetStoredProcCommand("general_cargar_roles");
            cmd1.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd1, "id_modulo", DbType.Int32, Int32.Parse(node.Value));
            foreach (DataRow row in db1.ExecuteDataSet(cmd1).Tables[0].Rows)
            {
                TreeNode NewNode = new TreeNode(row["nombre"].ToString() + " (" + row["codigo"].ToString() + ")", row["id_rol"].ToString());
                //TreeNode NewNode = new TreeNode(row["nombre"].ToString(), row["id_rol"].ToString());
                NewNode.PopulateOnDemand = false;
                NewNode.SelectAction = TreeNodeSelectAction.Expand;
                NewNode.Expanded = false;
                node.ChildNodes.Add(NewNode);
            }
        }
        public static void LlenarUsuarios(TreeNode node)
        {
            DbCommand cmd1 = db1.GetStoredProcCommand("general_cargar_permisos");
            cmd1.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd1, "id_recurso", DbType.Int32, Int32.Parse(node.Value));
            foreach (DataRow row in db1.ExecuteDataSet(cmd1).Tables[0].Rows)
            {
                //TreeNode NewNode = new TreeNode(row["nombre"].ToString() + " (" + row["codigo"].ToString() + ")", row["id_permiso"].ToString());
                TreeNode NewNode = new TreeNode(row["nombre"].ToString(), row["id_permiso"].ToString());
                NewNode.PopulateOnDemand = false;
                NewNode.SelectAction = TreeNodeSelectAction.Expand;
                NewNode.Expanded = false;
                node.ChildNodes.Add(NewNode);
            }
        }
        public static void LlenarGrupoRecursosLista(TreeNode node)
        {
            DbCommand cmd1 = db1.GetStoredProcCommand("general_cargar_gruporecursos_lista");
            cmd1.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            foreach (DataRow row in db1.ExecuteDataSet(cmd1).Tables[0].Rows)
            {
                TreeNode NewNode = new TreeNode(row["nombre"].ToString() + " (" + row["codigo"].ToString() + ")", row["id_gruporecurso"].ToString());
                //TreeNode NewNode = new TreeNode(row["nombre"].ToString(), row["id_gruporecurso"].ToString());
                NewNode.PopulateOnDemand = true;
                NewNode.SelectAction = TreeNodeSelectAction.Expand;
                NewNode.Expanded = false;
                node.ChildNodes.Add(NewNode);
            }
        }
        #endregion



        public static DataTable ConsolidarReporte(DataTable tabla_sus, DataTable tabla_bs, string codigo_moneda,
            string col_tipo_cambio, string col_datos, bool redondear, bool sumar_datos, string col_criterio_suma, string col_orden)
        {
            //Se convierten todos los elementos de "lista_datos" según el elemento "col_tipo_cambio"
            if (codigo_moneda == "$us")
            {
                if (tabla_bs.Rows.Count > 0)
                {
                    string[] lista_datos = col_datos.TrimStart(',').TrimEnd(',').Split(',');
                    foreach (DataRow fila in tabla_bs.Rows)
                    {
                        decimal tc = (decimal)fila[col_tipo_cambio];
                        if (tc != null && tc > 0)
                        {
                            for (int j = 0; j < lista_datos.Length; j++)
                            {
                                string nombre_columna = lista_datos[j];
                                if (redondear == true) { fila[nombre_columna] = Math.Round((((decimal)fila[nombre_columna]) / tc), 2); }
                                else { fila[nombre_columna] = Math.Round((((decimal)fila[nombre_columna]) / tc), 2); }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < lista_datos.Length; j++)
                            {
                                string nombre_columna = lista_datos[j];
                                fila[nombre_columna] = 0;
                            }
                        }
                    }
                }
            }
            else if (codigo_moneda == "Bs")
            {
                if (tabla_sus.Rows.Count > 0)
                {
                    string[] lista_datos = col_datos.TrimStart(',').TrimEnd(',').Split(',');
                    foreach (DataRow fila in tabla_sus.Rows)
                    {
                        decimal tc = (decimal)fila[col_tipo_cambio];
                        if (tc != null && tc > 0)
                        {
                            for (int j = 0; j < lista_datos.Length; j++)
                            {
                                string nombre_columna = lista_datos[j];
                                if (redondear == true) { fila[nombre_columna] = Math.Round((((decimal)fila[nombre_columna]) * tc), 2); }
                                else { fila[nombre_columna] = ((decimal)fila[nombre_columna]) * tc; }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < lista_datos.Length; j++)
                            {
                                string nombre_columna = lista_datos[j];
                                fila[nombre_columna] = 0;
                            }
                        }
                    }
                }
            }

            //Se verifica si es necesario unir las tablas
            bool se_combinan_tablas = false;
            DataTable tabla_resultado;
            if (tabla_sus.Rows.Count == 0 && tabla_bs.Rows.Count == 0) { tabla_resultado = tabla_sus; }
            else if (tabla_sus.Rows.Count > 0 && tabla_bs.Rows.Count == 0) { tabla_resultado = tabla_sus; }
            else if (tabla_sus.Rows.Count == 0 && tabla_bs.Rows.Count > 0) { tabla_resultado = tabla_bs; }
            else
            {
                se_combinan_tablas = true;
                //Por defecto se unen las dos tablas
                tabla_sus.Merge(tabla_bs, true);
                tabla_resultado = tabla_sus;

                //De ser necesario se suman los elementos de las tablas
                if (sumar_datos == true && col_criterio_suma.Trim() != "" && col_datos.Trim() != "")
                {
                    string[] lista_criterio = col_criterio_suma.TrimStart(',').TrimEnd(',').Split(',');
                    string[] lista_datos = col_datos.TrimStart(',').TrimEnd(',').Split(',');
                    int num_filas = tabla_resultado.Rows.Count;
                    //Se recorre las filas de la tabla de forma ascendente
                    for (int j = 0; j < num_filas; j++)
                    {
                        //Se verifica si el elemento j de la tabla todavía existe, de no ser así se termina la iteración
                        if (j < tabla_resultado.Rows.Count)
                        {
                            //Se obtiene la fila a evaluar
                            DataRow fila = tabla_resultado.Rows[j];

                            //Se recorre la tabla de forma inversa buscando las filas que coincidan con los criterios definidos
                            for (int k = tabla_resultado.Rows.Count - 1; k > j; k--)
                            {
                                //Se obtiene la fila x que se
                                DataRow filax = tabla_resultado.Rows[k];

                                //Se evalua si la filax cumple con el criterio de suma de la fila que esta siendo evaluada
                                bool coincide = true;
                                for (int q = 0; q < lista_criterio.Length; q++)
                                {
                                    string nombre_columna = lista_criterio[q];
                                    if (fila[nombre_columna].ToString() != filax[nombre_columna].ToString())
                                    {
                                        coincide = false;
                                        break;
                                    }
                                }

                                //En caso de que los criterios coincidan se SUMAN los datos de evaluación
                                if (coincide == true)
                                {
                                    //Se realiza la suma de los elementos
                                    for (int z = 0; z < lista_datos.Length; z++)
                                    {
                                        string nombre_columna = lista_datos[z];
                                        tabla_resultado.Rows[j][nombre_columna] = ((decimal)tabla_resultado.Rows[j][nombre_columna]) + ((decimal)tabla_resultado.Rows[k][nombre_columna]);
                                    }
                                    //Se elimina la fila que se sumó
                                    tabla_resultado.Rows.RemoveAt(k);
                                }
                            }

                        }
                        else { break; }
                    }
                }
            }
            
            if (se_combinan_tablas == false) { return tabla_resultado; }
            else
            {
                //De ser necesario se ordena la tabla
                if (col_orden.Trim() == "") { return tabla_resultado; }
                else
                {
                    tabla_resultado.DefaultView.Sort = col_orden;
                    return tabla_resultado.DefaultView.ToTable();
                }
            }
        }

        public static DataTable ListaOpcionesConsolidado()
        {
            //[valor],[texto]
            DataSet ds = new DataSet();
            ds.ReadXml(HttpContext.Current.Server.MapPath("~/App_Data/listaOpcionesConsolidado.xml"));
            return ds.Tables[0];
        }
    }

}