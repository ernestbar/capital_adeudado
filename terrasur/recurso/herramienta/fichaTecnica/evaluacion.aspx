<%@ Page Language="C#" MasterPageFile="~/modulo/simple.master" Title="Evaluación de la operación de venta" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            if (Session["id_contrato"] != null)
            {
                int id_contrato = (int)Session["id_contrato"];
                RecuperarDatos(id_contrato);
                Session.Remove("id_contrato");
            }
            else { Page.Visible = false; }
        }
    }
    protected void RecuperarDatos(int id_contrato)
    {
        contrato cObj = new contrato(id_contrato);
        cliente cliObj = new cliente(cObj.id_titular);
        string titulares = cliObj.paterno + ' ' + cliObj.materno + ' ' + cliObj.nombres;
        string adicionales = cliente_contrato.ListaClientesAdicionales_String(id_contrato).Trim();
        if (adicionales != "" && adicionales.ToLower().Contains("ninguno") == false) titulares = titulares + ", " + adicionales;

        titulares = titulares.ToUpper();
        string num_contrato = cObj.numero;

        string texto1 = "Realizada la evaluación de los antecedentes del cliente Sr(a) " + titulares + ", operación No." + num_contrato + ", ";
        texto1 = texto1 + "así como la verificación de los mismos, se ha podido evidenciar su capacidad de pago, además de la ";
        texto1 = texto1 + "estabilidad de su fuente de ingresos, habiéndose además realizado la respectiva consulta de información ";
        texto1 = texto1 + "financiera y legal mediante la empresa Enserbic S.A. (INFO CENTER).";

        string texto2 = "Toda la documentación que respalda el presente informe, se halla debidamente archivada en el respectivo file del cliente";
        texto2 = texto2 + ".";

        //lbl_aux.Text = texto1 + "<br/>" + texto2;

        string texto3 = "DEPARTAMENTO COMERCIAL";
        string texto4 = "TERRASUR";
        evaluacionOperacion rep = new evaluacionOperacion();
        rep.CargarDatos(texto1, texto2, texto3, texto4);
        Reporte1.WebView.Report = rep;
    }

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="fichaTecnica" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <%--<asp:Label ID="lbl_aux" runat="server"></asp:Label>--%>
    <uc1:reporte ID="Reporte1" runat="server" />
</asp:Content>