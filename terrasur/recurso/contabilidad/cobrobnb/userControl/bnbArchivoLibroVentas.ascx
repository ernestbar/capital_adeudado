<%@ Control Language="C#" ClassName="bnbArchivoLibroVentas" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Text" %>

<script runat="server">
    public int id_institucion { get { return int.Parse(lbl_id_institucion.Text); } set { lbl_id_institucion.Text = value.ToString(); } }
    public string codigo_tipo_archivo { get { return lbl_codigo_tipo_archivo.Text; } set { lbl_codigo_tipo_archivo.Text = value; panel_archivo.Visible = value.Equals("E"); } }


    protected void btn_cargar_Click(object sender, EventArgs e)
    {
        string nombre_archivo = fu_confirmacion.FileName;
        string anio_archivo = DateTime.Now.Year.ToString();
        string ruta_archivo = Server.MapPath(ConfigurationManager.AppSettings["bnb_files"] + anio_archivo + "/" + nombre_archivo);

        if (fu_confirmacion.HasFile == true)
        {
            if (System.IO.File.Exists(ruta_archivo) == false)
            {
                try
                {
                    fu_confirmacion.SaveAs(ruta_archivo);
                    Msg1.Text = "El archivo de libro de ventas se cargó correctamente";
                    if (System.IO.File.Exists(ruta_archivo) == true)
                    {
                        List<string> lista_items = new List<string>();
                        System.IO.StreamReader archivo = new System.IO.StreamReader(ruta_archivo);
                        string linea = archivo.ReadLine();
                        while (linea != null && linea.Trim() != "") { lista_items.Add(linea); linea = archivo.ReadLine(); }
                        archivo.Close();

                        int num_reg_procesados = 0;
                        int num_reg_aceptados = 0;

                        if (lista_items.Count > 0)
                        {
                            for (int j = 0; j < lista_items.Count; j++)
                            {
                                num_reg_procesados += 1;
                                if (lista_items[j].Contains("|") == true)
                                {
                                    string[] elementos_lista = lista_items[j].Split('|');
                                    if (elementos_lista.Length == 12)
                                    {
                                        bool correcto = true;
                                        decimal cliente_nit; string cliente_nombre; int num_factura; decimal num_autorizacion; DateTime fecha; decimal monto_bs; string estado_factura; string numero_control;
                                        if (decimal.TryParse(elementos_lista[0].Trim(), out cliente_nit) == false) { correcto = false; }
                                        cliente_nombre = elementos_lista[1].Trim();
                                        if (int.TryParse(elementos_lista[2].Trim(), out num_factura) == false) { correcto = false; }
                                        if (decimal.TryParse(elementos_lista[3].Trim(), out num_autorizacion) == false) { correcto = false; }
                                        if (DateTime.TryParse(elementos_lista[4].Trim(), out fecha) == false) { correcto = false; }

                                        //if (decimal.TryParse(elementos_lista[5].Trim(), out monto_bs) == false) { correcto = false; }
                                        string monto_bs_string = elementos_lista[5].Trim();
                                        monto_bs_string = monto_bs_string.Replace(",", "");
                                        monto_bs_string = monto_bs_string.Replace(".", ",");
                                        if (decimal.TryParse(monto_bs_string, out monto_bs) == false) { correcto = false; }

                                        estado_factura = elementos_lista[10].Trim();
                                        numero_control = elementos_lista[11].Trim();
                                        if (correcto == true && estado_factura == "V")
                                        {
                                            try
                                            {
                                                Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
                                                DbCommand cmd = db1.GetStoredProcCommand("bnb_archivo_LibroVentas");
                                                db1.AddInParameter(cmd, "id_institucion", DbType.Int32, id_institucion);
                                                db1.AddInParameter(cmd, "cliente_nit", DbType.Decimal, cliente_nit);
                                                db1.AddInParameter(cmd, "cliente_nombre", DbType.String, cliente_nombre);
                                                db1.AddInParameter(cmd, "num_factura", DbType.Int32, num_factura);
                                                db1.AddInParameter(cmd, "num_autorizacion", DbType.Decimal, num_autorizacion);
                                                db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
                                                db1.AddInParameter(cmd, "monto_bs", DbType.Decimal, monto_bs);
                                                db1.AddInParameter(cmd, "estado_factura", DbType.String, estado_factura);
                                                db1.AddInParameter(cmd, "numero_control", DbType.String, numero_control);
                                                db1.ExecuteNonQuery(cmd);
                                                num_reg_aceptados += 1;
                                            }
                                            catch { }
                                        }
                                    }
                                }
                            }
                        }
                        Msg1.Text = "Número de facturas actualizadas (" + num_reg_aceptados + " de " + num_reg_procesados + ")";
                    }
                    else { Msg1.Text = "El archivo de libro de ventas no existe en el directorio de archivos del BNB"; }
                }
                catch { Msg1.Text = "El archivo de libro de ventas NO se cargó correctamente"; }
            }
            else { Msg1.Text = "El archivo de libro de ventas YA FUE CARGADO PREVIAMENTE"; }
        }
        else { Msg1.Text = "Debe elegir el archivo de Libro de Ventas"; }
    }
</script>
<asp:Label ID="lbl_id_institucion" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_codigo_tipo_archivo" runat="server" Text="" Visible="false"></asp:Label>

<asp:Panel ID="panel_archivo" runat="server" Width="100%" GroupingText="BNB Archivo E - Libro de ventas">
    <table class="formTable" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="3">
                <asp:Msg ID="Msg1" runat="server"></asp:Msg> 
            </td>
        </tr>
        <tr>
            <td class="formTdEnun">Archivo del libro de ventas:</td>
            <td class="formTdDato"><asp:FileUpload ID="fu_confirmacion" runat="server" /></td>
            <td><asp:Button ID="btn_cargar" runat="server" Text="Cargar archivo" OnClick="btn_cargar_Click" /></td>
        </tr>
    </table>
</asp:Panel>