<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Reporte de cartera vigente (versión Nafibo)" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Text" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContabilidad", "reporteCarteraVigenteNafibo") == true)
            {
                //bool permiso_cartera_vigente_con_retraso = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContabilidad", "reporteCarteraVigente2_retraso");
			}
            else { Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx"); }
        }
    }

    protected void btn_mostrar_Click(object sender, EventArgs e)
    {
        cargarReporte();
    }

    public void cargarReporte()
    {
        string Codigo_moneda = "$us";
        int Id_moneda = 1;
        DataTable tabla = CarteraVigente_Nafibo(cp_fecha.SelectedDate, Id_moneda);
        rpt_cartera_vigente_nafibo reporte = new rpt_cartera_vigente_nafibo();
        reporte.CargarDatos(cp_fecha.SelectedDate, Codigo_moneda, tabla.Rows.Count);
        reporte.DataSource = tabla;

        Reporte1.WebView.Report = reporte;
    }

    private static DataTable CarteraVigente_Nafibo(DateTime Fecha, int Id_moneda)
    {
        Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        DbCommand cmd = db1.GetStoredProcCommand("contabilidad_CarteraVigente_Nafibo");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
        db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
        return db1.ExecuteDataSet(cmd).Tables[0];
    }

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteContabilidad" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
    <tr>
        <td class="priTdTitle">Reporte de cartera vigente (versión Nafibo)</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido" align="center">
                <tr>
                    <td class="tdFiltro">
                        <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="formTdEnun">
                                    <asp:Label ID="lbl_fecha" runat="server" Text="A la fecha:"></asp:Label></td>
                                <td class="formTdDato">
                                    <ew:CalendarPopup ID="cp_fecha" runat="server" AutoPostBack="false">
                                    </ew:CalendarPopup>
                                </td>
                            </tr>
                            <tr>
                                <td class="formEntTdButton" colspan="2">
                                   <asp:Button ID="btn_mostrar" runat="server" SkinID="btnAccion" Text="Mostrar reporte" CausesValidation="true" ValidationGroup="filtro" OnClick="btn_mostrar_Click" />
                                </td>
                            </tr>
                         </table>
                    </td>
                </tr>
                <tr>
                    <td class="tdGrid">
                    <uc1:reporte ID="Reporte1" runat="server" NombreReporte="CarteraVigente" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>
