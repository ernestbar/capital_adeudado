<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Generación de Códigos de control" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "codigoControl", "view") == true)
            {
                bool permitir = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "codigoControl", "generar");
                btn_obtener.Visible = permitir;
                btn_reset.Visible = permitir;
            }
            else { Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx"); }
        }
    }

    protected void btn_obtener_Click(object sender, EventArgs e)
    {
        decimal monto_bs = decimal.Parse(txt_monto_bs.Text.Trim());
        int monto_bs_entero = Convert.ToInt32(Math.Round(monto_bs, 0));
        string codigo_control = "";
        try
        {
            Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
            DbCommand cmd = db1.GetStoredProcCommand("parametro_facturacion_Verificacion");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "num_autorizacion", DbType.String, txt_num_autorizacion.Text.Trim());
            db1.AddInParameter(cmd, "num_factura", DbType.String, txt_num_factura.Text.Trim());
            db1.AddInParameter(cmd, "nit_cliente", DbType.String, txt_nit_cliente.Text.Trim());
            db1.AddInParameter(cmd, "fecha_emision", DbType.String, txt_fecha_emision.SelectedDate.ToString("d"));
            db1.AddInParameter(cmd, "monto_bs", DbType.String, monto_bs_entero.ToString());
            db1.AddInParameter(cmd, "llave_dosificacion", DbType.String, txt_llave_dosificacion.Text.Trim());
            codigo_control = db1.ExecuteScalar(cmd).ToString();// +"<br/>" + funciones.ObtenerCodigo(txt_num_autorizacion.Text.Trim(), txt_num_factura.Text.Trim(), txt_nit_cliente.Text.Trim(), txt_fecha_emision.SelectedDate.ToString("d"), monto_bs_entero.ToString(), txt_llave_dosificacion.Text.Trim());
        }
        catch { }
        lbl_codigo_control.Text = codigo_control;
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        txt_num_autorizacion.Text = "";
        txt_num_factura.Text = "";
        txt_nit_cliente.Text = "";
        txt_fecha_emision.SelectedDate = DateTime.Now;
        txt_monto_bs.Text = "";
        txt_llave_dosificacion.Text = "";
        lbl_codigo_control.Text = "";
    }
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
     <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="codigoControl" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
    <tr>
        <td class="priTdTitle">Generación de Códigos de control</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido">
                <tr>
                    <td class="tdFiltro">
                        <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="formTdEnun">Nº autorización:</td>
                                <td class="formTdDato">
                                    <asp:TextBox ID="txt_num_autorizacion" runat="server" MaxLength="20" SkinID="txtSingleLine200"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_num_autorizacion" runat="server" ControlToValidate="txt_num_autorizacion" Display="Dynamic" Text="*" ValidationGroup="codigoControl"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Nº factura:</td>
                                <td class="formTdDato">
                                    <asp:TextBox ID="txt_num_factura" runat="server" MaxLength="50" SkinID="txtSingleLine200"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_num_factura" runat="server" ControlToValidate="txt_num_factura" Display="Dynamic" Text="*" ValidationGroup="codigoControl"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">NIT (del cliente):</td>
                                <td class="formTdDato">
                                    <asp:TextBox ID="txt_nit_cliente" runat="server" MaxLength="<%$ AppSettings:cliente_longitud_nit %>" SkinID="txtSingleLine200"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_nit_cliente" runat="server" ControlToValidate="txt_nit_cliente" Display="Dynamic" Text="*" ValidationGroup="codigoControl"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Fecha de emisión:</td>
                                <td class="formTdDato">
                                    <ew:CalendarPopup ID="txt_fecha_emision" runat="server" DisableTextBoxEntry="false" ></ew:CalendarPopup>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Monto (Bs.):</td>
                                <td class="formTdDato">
                                    <asp:TextBox ID="txt_monto_bs" runat="server" MaxLength="15" SkinID="txtSingleLine200" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_txt_monto_bs" runat="server" ControlToValidate="txt_monto_bs" Display="Dynamic" Text="*" ValidationGroup="codigoControl"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="vc_monto_bs" runat="server" ControlToValidate="txt_monto_bs" Display="Dynamic" Type="Double" Operator="DataTypeCheck" Text="*" ValidationGroup="codigoControl"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Llave de dosificación:</td>
                                <td class="formTdDato">
                                    <asp:TextBox ID="txt_llave_dosificacion" runat="server" MaxLength="300" SkinID="txtSingleLine200"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_llave_dosificacion" runat="server" ControlToValidate="txt_llave_dosificacion" Display="Dynamic" Text="*" ValidationGroup="codigoControl"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btn_obtener" runat="server" Text="Generar" SkinID="btnAccion" OnClick="btn_obtener_Click" CausesValidation="true" ValidationGroup="codigoControl"/>
                                    <asp:Button ID="btn_reset" runat="server" Text="Limpiar" OnClick="btn_reset_Click" CausesValidation="false" OnClientClick="return confirm('¿Esta seguro que desea borrar los datos introducidos?');" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" style="font-size:xx-large; font-weight:bold;">
                                    <asp:TextBox ID="lbl_codigo_control" runat="server" style="font-size:18pt; width:150pt; font-weight:bold; text-align:center;"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

