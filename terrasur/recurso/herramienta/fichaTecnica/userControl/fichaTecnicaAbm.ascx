<%@ Control Language="C#" ClassName="fichaTecnicaAbm" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>

<script runat="server">
    protected int id_contrato { get { return int.Parse(lbl_id_contrato.Text); } set { lbl_id_contrato.Text = value.ToString(); } }
    
    public void Reset()
    {
        id_contrato = 0;
        ddl_verif_dom.SelectedIndex = 0;
        ddl_certif_lab.SelectedIndex = 0;
        txt_testimonio.Text = "";
        txt_texto_avaluos.Text = "";
        txt_avaluo_fecha.Text = "";
        txt_avaluo_comercial.Text = "0";
        txt_avaluo_rapida.Text = "0";
        txt_avaluo_terreno.Text = "0";
        txt_avaluo_construc.Text = "0";
        txt_avaluo_valuador.Text = "";
        txt_funcionario.Text = "M.C.V.";
    }

    public void RecuperarDatos(int Id_contrato)
    {
        id_contrato = Id_contrato;
        Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        DbCommand cmd = db1.GetStoredProcCommand("ficha_tecnica_DatosContrato");
        db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
        if (tabla.Rows.Count > 0)
        {
            ddl_verif_dom.SelectedValue = tabla.Rows[0]["verif_dom"].ToString();
            ddl_certif_lab.SelectedValue = tabla.Rows[0]["certif_lab"].ToString();
            txt_testimonio.Text = tabla.Rows[0]["testimonio"].ToString();
            txt_texto_avaluos.Text = tabla.Rows[0]["texto_avaluos"].ToString();
            txt_avaluo_fecha.Text = tabla.Rows[0]["avaluo_fecha"].ToString();
            txt_avaluo_comercial.Text = tabla.Rows[0]["avaluo_comercial"].ToString();
            txt_avaluo_rapida.Text = tabla.Rows[0]["avaluo_rapida"].ToString();
            txt_avaluo_terreno.Text = tabla.Rows[0]["avaluo_terreno"].ToString();
            txt_avaluo_construc.Text = tabla.Rows[0]["avaluo_construc"].ToString();
            txt_avaluo_valuador.Text = tabla.Rows[0]["avaluo_valuador"].ToString();
            txt_funcionario.Text = tabla.Rows[0]["funcionario"].ToString();
        }
        else { Reset(); id_contrato = Id_contrato; }
    }
    
    public bool Guardar()
    {
        //if (Id_contrato > 0) id_contrato = Id_contrato;
        if (id_contrato > 0)
        {
            try
            {
                Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
                DbCommand cmd = db1.GetStoredProcCommand("ficha_tecnica_Guardar");
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                db1.AddInParameter(cmd, "verif_dom", DbType.String, ddl_verif_dom.SelectedValue);
                db1.AddInParameter(cmd, "certif_lab", DbType.String, ddl_certif_lab.SelectedValue);
                db1.AddInParameter(cmd, "avaluo_fecha", DbType.String, txt_avaluo_fecha.Text.Trim());
                db1.AddInParameter(cmd, "avaluo_comercial", DbType.String, txt_avaluo_comercial.Text.Trim());
                db1.AddInParameter(cmd, "avaluo_rapida", DbType.String, txt_avaluo_rapida.Text.Trim());
                db1.AddInParameter(cmd, "avaluo_terreno", DbType.String, txt_avaluo_terreno.Text.Trim());
                db1.AddInParameter(cmd, "avaluo_construc", DbType.String, txt_avaluo_construc.Text.Trim());
                db1.AddInParameter(cmd, "avaluo_valuador", DbType.String, txt_avaluo_valuador.Text.Trim());
                db1.AddInParameter(cmd, "funcionario", DbType.String, txt_funcionario.Text.Trim());
                db1.AddInParameter(cmd, "testimonio", DbType.String, txt_testimonio.Text.Trim());
                db1.AddInParameter(cmd, "texto_avaluos", DbType.String, txt_texto_avaluos.Text.Trim());
                db1.ExecuteNonQuery(cmd);
                Msg1.Text = "Los datos de la ficha técnica se guardaron correctamente";
                return true;
            }
            catch
            {
                Msg1.Text = "Los datos de la ficha técnica se guardaron correctamente";
                return false;
            }
        }
        else
        {
            Msg1.Text = "Debe elegir un contrato para guardar los datos del mismo";
            return false;
        }
    }
</script>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server" Show="false"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos de la ficha técnica"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Verificación domiciliaria:</td>
        <td class="formTdDato">
            <asp:DropDownList ID="ddl_verif_dom" runat="server">
                <asp:ListItem Text="Teléfono" Value="Teléfono" />
                <asp:ListItem Text="Factura de luz" Value="Factura de luz" />
                <asp:ListItem Text="Factura de agua" Value="Factura de agua" />
                <asp:ListItem Text="Boleta de pago" Value="Boleta de pago" />
                <asp:ListItem Text="Otro" Value="Otro" />
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Certificación laboral:</td>
        <td class="formTdDato">
            <asp:DropDownList ID="ddl_certif_lab" runat="server">
                <asp:ListItem Text="Boleta de pago" Value="Boleta de pago" />
                <asp:ListItem Text="Otro" Value="Otro" />
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Testimonio de Propiedad TERRASUR:</td>
        <td class="formTdDato"><asp:TextBox ID="txt_testimonio" runat="server" SkinID="txtSingleLine100" MaxLength="200"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="formTdEnun">Avalúos:</td>
        <td class="formTdDato"><asp:TextBox ID="txt_texto_avaluos" runat="server" SkinID="txtSingleLine100" MaxLength="200"></asp:TextBox></td>
    </tr>

    <tr><td class="formTdEnun" colspan="2">Avaluo</td></tr>
    <tr>
        <td class="formTdEnun">Fecha Avaluo:</td>
        <td class="formTdDato"><asp:TextBox ID="txt_avaluo_fecha" runat="server" SkinID="txtSingleLine50" MaxLength="200"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="formTdEnun">Valor Comercial:</td>
        <td class="formTdDato"><asp:TextBox ID="txt_avaluo_comercial" runat="server" SkinID="txtSingleLine50" MaxLength="200"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="formTdEnun">Valor Vta. Rápida:</td>
        <td class="formTdDato"><asp:TextBox ID="txt_avaluo_rapida" runat="server" SkinID="txtSingleLine50" MaxLength="200"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="formTdEnun">Valor Terreno:</td>
        <td class="formTdDato"><asp:TextBox ID="txt_avaluo_terreno" runat="server" SkinID="txtSingleLine50" MaxLength="200"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="formTdEnun">Valor Constr.</td>
        <td class="formTdDato"><asp:TextBox ID="txt_avaluo_construc" runat="server" SkinID="txtSingleLine50" MaxLength="200"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="formTdEnun">Avaluador</td>
        <td class="formTdDato"><asp:TextBox ID="txt_avaluo_valuador" runat="server" SkinID="txtSingleLine50" MaxLength="200"></asp:TextBox></td>
    </tr>
    <tr><td colspan="2"><br /></td></tr>
    <tr>
        <td class="formTdEnun">Funcionario:</td>
        <td class="formTdDato"><asp:TextBox ID="txt_funcionario" runat="server" SkinID="txtSingleLine100" MaxLength="200"></asp:TextBox></td>
    </tr>

</table>

