<%@ Control Language="C#" ClassName="contratoOtrosDatos" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>

<script runat="server">
    public string datos_otros { get { return lbl_datos_otros.Text; } set { lbl_datos_otros.Text = value; } }
    public string datos_obs { get { return lbl_datos_obs.Text; } set { lbl_datos_obs.Text = value; } }
    private int id_contrato { get { return int.Parse(lbl_id_contrato.Text); } set { lbl_id_contrato.Text = value.ToString(); } }
    
    public void CargarDatos(int Id_contrato)
    {
        string _num_contrato = "";
        string _negocio = "";
        string _estado_nombre = "";
        DateTime _estado_fecha = DateTime.Now;
        string _estado_otro = "";
        string _observacion = "";
        string _cliente_titular = "";

        DataTable tabla = TablaOtrosDatos(Id_contrato, ref _num_contrato, ref _negocio, ref _estado_nombre, ref _estado_fecha, ref _estado_otro, ref _observacion, ref _cliente_titular);

        id_contrato = Id_contrato;
        if (tabla.Rows.Count > 1)
        {
            lbl_primer_titular.Visible = true;
            gv1.Visible = true;
            
            lbl_primer_titular.Text = "Otros contratos de " + _cliente_titular.Replace(" )",")");
            gv1.DataSource = tabla;
            gv1.DataBind();
        }
        else
        {
            lbl_primer_titular.Visible = false;
            gv1.Visible = false;
        }

        string estado_fecha_otro = "";
        if (string.IsNullOrEmpty(_estado_otro)) { estado_fecha_otro = _estado_fecha.ToString("d"); }
        else { estado_fecha_otro = _estado_fecha.ToString("d") + " - " + _estado_otro; }
        datos_otros = string.Format("Contrato: {0} ({1}) ; {2} ({3})", _num_contrato, _negocio, _estado_nombre, estado_fecha_otro);
        datos_obs = _observacion;
        //if (string.IsNullOrEmpty(_observacion)) { datos_obs = ""; } else { datos_obs = "Observación: " + _observacion; }
    }


    private DataTable TablaOtrosDatos(int Id_contrato
        , ref string _num_contrato, ref string _negocio, ref string _estado_nombre, ref DateTime _estado_fecha
        , ref string _estado_otro, ref string _observacion, ref string _cliente_titular)
    {
        Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        DbCommand cmd = db1.GetStoredProcCommand("contrato_ReporteOtrosDatos");
        db1.AddInParameter(cmd, "id_contrato", DbType.Int32, Id_contrato);

        db1.AddOutParameter(cmd, "num_contrato", DbType.String, 20);
        db1.AddOutParameter(cmd, "negocio", DbType.String, 20);
        db1.AddOutParameter(cmd, "estado_nombre", DbType.String, 20);
        db1.AddOutParameter(cmd, "estado_fecha", DbType.DateTime, 50);
        db1.AddOutParameter(cmd, "estado_otro", DbType.String, 50);
        db1.AddOutParameter(cmd, "observacion", DbType.String, 200);
        db1.AddOutParameter(cmd, "cliente_titular", DbType.String, 100);

        DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];

        _num_contrato = (string)db1.GetParameterValue(cmd, "num_contrato");
        _negocio = (string)db1.GetParameterValue(cmd, "negocio");
        _estado_nombre = (string)db1.GetParameterValue(cmd, "estado_nombre");
        _estado_fecha = (DateTime)db1.GetParameterValue(cmd, "estado_fecha");
        _estado_otro = (string)db1.GetParameterValue(cmd, "estado_otro");
        _observacion = (string)db1.GetParameterValue(cmd, "observacion");
        _cliente_titular = (string)db1.GetParameterValue(cmd, "cliente_titular");
        return tabla;
    }

    protected string tiene_observacion(string obs) { if (!string.IsNullOrEmpty(obs)) { return "*"; } else { return ""; } }

    protected void gv1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int _id_contrato = (int)DataBinder.Eval(e.Row.DataItem, "id_contrato");

            if (contrato_estado_especial.BloquearContrato(_id_contrato, Profile.entorno.codigo_modulo) == true)
            {
                //e.Row.Cells[0].Controls[0].Visible = false;
                //e.Row.Cells[6].Text = "";
                e.Row.Cells[5].Text = "";
            }
            if (_id_contrato == id_contrato) { e.Row.CssClass = "gvRowSelected"; }
            if (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "observacion").ToString()))
            {
                ((Label)e.Row.FindControl("lbl_observacion")).ForeColor = System.Drawing.Color.White;
            }
            else { ((Label)e.Row.FindControl("lbl_observacion")).ForeColor = System.Drawing.Color.Black; }
        }
    }

    protected void gv1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "ver")
        //{
        //    Session["id_contrato"] = int.Parse(gv1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
        //    WinPopUp1.Show();
        //}
    }
</script>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_datos_otros" runat="server" Visible="false"></asp:Label>
<asp:Label ID="lbl_datos_obs" runat="server" Visible="false"></asp:Label>
<table>
    <tr>
        <td align="left">
            <asp:Label ID="lbl_primer_titular" runat="server" SkinID="lblEnun">
            </asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <%--[id_cliente],[id_contrato],[cliente_orden],[cliente_titular],[cliente_nombre],[cliente_ci]
            [num_contrato],[negocio],[estado_nombre],[estado_fecha],[estado_otro],[saldo],[lote_servicio],[tipo_titular],[observacion]--%>
            <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="false" DataKeyNames="id_contrato" OnRowDataBound="gv1_RowDataBound" OnRowCommand="gv1_RowCommand">
                <Columns>
                    <%--<asp:ButtonField CommandName="ver" Text="Estado de cuenta" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />--%>
                    <asp:TemplateField HeaderText="Nº ctto." ItemStyle-CssClass="gvCell1">
                        <ItemTemplate>
                            <asp:Label ID="lbl_num_contrato" runat="server" Text='<%# Eval("num_contrato") %>' ToolTip='<%# Eval("observacion") %>'></asp:Label>
                            <asp:Label ID="lbl_observacion" runat="server" Text="*" ToolTip='<%# Eval("observacion") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Negocio" DataField="negocio" />
                    <asp:BoundField HeaderText="Estado" DataField="estado_nombre" />
                    <asp:BoundField HeaderText="" DataField="estado_fecha" />
                    <asp:BoundField HeaderText="" DataField="estado_otro" />
                    <asp:BoundField HeaderText="Saldo" DataField="saldo" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1"/>
                    <asp:BoundField HeaderText="Lote/Servicio" DataField="lote_servicio" />
                    <asp:BoundField HeaderText="Titular" DataField="tipo_titular" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
<%--<asp:WinPopUp id="WinPopUp1" runat="server" Win_Height="500" Win_Width="900" NavigateUrl="~/recurso/contrato/reporteContrato/reporteContratoEstadoCuenta.aspx"></asp:WinPopUp>--%>