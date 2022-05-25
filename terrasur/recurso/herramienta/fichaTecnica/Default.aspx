<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Ficha técnica de contratos" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register src="~/recurso/herramienta/fichaTecnica/userControl/fichaTecnicaAbm.ascx" tagname="fichaTecnicaAbm" tagprefix="uc2" %>


<script runat="server">
    protected int id_contrato { get { return int.Parse(lbl_id_contrato.Text); } set { lbl_id_contrato.Text = value.ToString(); } }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "fichaTecnica", "view") == true)
            {
                btn_guardar.Enabled = false;
                btn_ficha.Enabled = false;
                btn_evaluacion.Enabled = false;
                txt_contrato.Text = "";
                txt_contrato.Focus();
            }
        }
    }

    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        int _id_contrato = contrato.IdPorNumero(txt_contrato.Text.Trim());
        if (_id_contrato > 0)
        {
            id_contrato = _id_contrato;
            fichaTecnicaAbm1.RecuperarDatos(id_contrato);
            btn_guardar.Enabled = true;
            btn_ficha.Enabled = true;
            btn_evaluacion.Enabled = true;
            
            txt_contrato.Focus();
        }
        else
        {
            id_contrato = 0;
            fichaTecnicaAbm1.Reset();
            btn_guardar.Enabled = false;
            btn_ficha.Enabled = false;
            btn_evaluacion.Enabled = false;
            
            txt_contrato.Focus();
            Msg1.Text = "Contrato inexistente";
        }
    }

    protected void btn_guardar_Click(object sender, EventArgs e)
    {
        if (fichaTecnicaAbm1.Guardar() == true) { }
    }

    protected void btn_ficha_Click(object sender, EventArgs e)
    {
        if (fichaTecnicaAbm1.Guardar() == true)
        {
            Session["id_contrato"] = id_contrato;
            Session["fecha"] = cp_fecha.SelectedDate;
            WinPopUp1.Show();
        }
    }

    protected void btn_evaluacion_Click(object sender, EventArgs e)
    {
        Session["id_contrato"] = id_contrato;
        WinPopUp2.Show(); 
    }
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="fichaTecnica" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:Label runat="server" id="lbl_id_contrato" Visible="false"  Text="0"/>
    <asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/herramienta/fichaTecnica/ficha.aspx" Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="0" Win_Left="0" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True" Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="0" Win_Width="0">[WinPopUp1]</asp:WinPopUp>
    <asp:WinPopUp ID="WinPopUp2" runat="server" NavigateUrl="~/recurso/herramienta/fichaTecnica/evaluacion.aspx" Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="0" Win_Left="0" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True" Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="0" Win_Width="0">[WinPopUp1]</asp:WinPopUp>

    <table class="priTable">
        <tr><td class="priTdTitle">Ficha técnica de contratos</td></tr>
        <tr>
            <td class="priTdContenido">
                <table align="center">
                    <tr>
                        <td>
                            <asp:Panel ID="panel_contrato" runat="server" DefaultButton="btn_buscar">
                                <table align="left">
                                    <tr>
                                        <td><asp:Label ID="lbl_fecha" runat="server" Text="Fecha:" SkinID="lblEnun"></asp:Label></td>
                                        <td><ew:CalendarPopup ID="cp_fecha" runat="server"></ew:CalendarPopup></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="lbl_contrato" runat="server" Text="Nº contrato:" SkinID="lblEnun"></asp:Label></td>
                                        <td><asp:TextBox ID="txt_contrato" runat="server" SkinID="txtSingleLine100"></asp:TextBox></td>
                                        <td><asp:Button ID="btn_buscar" runat="server" Text="Buscar contrato" OnClick="btn_buscar_Click" /></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td class="formTdMsg">
                            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            
                            <uc2:fichaTecnicaAbm ID="fichaTecnicaAbm1" runat="server" />
                            
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btn_guardar" runat="server" Text="Guardar datos" OnClick="btn_guardar_Click" />
                            <asp:Button ID="btn_ficha" runat="server" Text="Ver ficha técnica" OnClick="btn_ficha_Click" />
                            <asp:Button ID="btn_evaluacion" runat="server" Text="Evaluación de la operación" OnClick="btn_evaluacion_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>


