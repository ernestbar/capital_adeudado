<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte de cartera vigente" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContabilidad", "reporteCarteraVigente") Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
      
    Public Sub cargarReporte()
        Dim Codigo_moneda As String = New moneda(Integer.Parse(rbl_moneda.SelectedValue)).codigo

        Dim reporte As New rpt_cartera_vigente()
        reporte.DataSource = contabilidadReporte.CarteraVigente(cp_fecha.SelectedDate, general.StringNegocios(True, cbl_negocio.Items), Integer.Parse(ddl_localizacion.SelectedValue), Integer.Parse(ddl_urbanizacion.SelectedValue), Integer.Parse(ddl_manzano.SelectedValue), Integer.Parse(rbl_moneda.SelectedValue), rbl_consolidado.SelectedValue.Equals("True"))
        reporte.CargarDatos(cp_fecha.SelectedDate, general.StringNegocios(False, cbl_negocio.Items), ddl_localizacion.SelectedItem.Text, ddl_urbanizacion.SelectedItem.Text, ddl_manzano.SelectedItem.Text, rbl_moneda.SelectedItem.Text.ToUpper, rbl_consolidado.SelectedItem.Text.ToUpper, Codigo_moneda)
        Reporte1.WebView.Report = reporte
    End Sub
   
    Protected Sub btn_mostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        cargarReporte()
    End Sub

    Protected Sub ddl_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_localizacion.DataBound, ddl_urbanizacion.DataBound, ddl_manzano.DataBound
        CType(sender, DropDownList).Items.Insert(0, New ListItem("Todos", "0"))
    End Sub

    Protected Sub cbl_negocio_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbl_negocio.DataBound
        Dim casas_edif As String = ConfigurationManager.AppSettings("negocios_casas")
        For Each item As ListItem In cbl_negocio.Items
            item.Selected = casas_edif.Contains("|" + item.Text + "|").Equals(False)
        Next
    End Sub

    Protected Sub rbl_moneda_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_moneda.DataBound
        If rbl_moneda.Items.Count > 0 Then
            rbl_moneda.SelectedIndex = 0
        End If
    End Sub
    Protected Sub rbl_consolidado_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_consolidado.DataBound
        If rbl_consolidado.Items.Count > 0 Then
            rbl_consolidado.SelectedIndex = 0
        End If
        lbl_consolidado_enun.Text = "Datos contemplados:"
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteContabilidad" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
    <tr>
        <td class="priTdTitle">Reporte de cartera vigente</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido">
                <tr>
                    <td class="tdButtonVolver">
                    </td>
                </tr>
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
                                <td class="formTdEnun">Localización:</td>
                                <td class="formTdDato">
                                    <asp:DropDownList ID="ddl_localizacion" runat="server" AutoPostBack="true" DataSourceID="ods_localizacion_lista" DataTextField="nombre" DataValueField="id_localizacion"></asp:DropDownList>
                                    <%--[id_localizacion],[nombre]--%>
                                    <asp:ObjectDataSource ID="ods_localizacion_lista" runat="server" TypeName="terrasur.localizacion" SelectMethod="Lista"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Sector:</td>
                                <td class="formTdDato">
                                    <asp:DropDownList ID="ddl_urbanizacion" runat="server" AutoPostBack="true" DataSourceID="ods_urb_lista" DataTextField="nombre_completo" DataValueField="id_urbanizacion"></asp:DropDownList>
                                    <%--[id_urbanizacion],[nombre]--%>
                                    <asp:ObjectDataSource ID="ods_urb_lista" runat="server" TypeName="terrasur.urbanizacion" SelectMethod="Lista">
                                        <SelectParameters>
                                            <asp:ControlParameter Name="Id_localizacion" Type="Int32" ControlID="ddl_localizacion" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Manzano:</td>
                                <td class="formTdDato">
                                    <asp:DropDownList ID="ddl_manzano" runat="server" DataSourceID="ods_manzano_lista" DataTextField="codigo" DataValueField="id_manzano"></asp:DropDownList>
                                    <%--[id_manzano],[codigo]--%>
                                    <asp:ObjectDataSource ID="ods_manzano_lista" runat="server" TypeName="terrasur.manzano" SelectMethod="Lista">
                                        <SelectParameters>
                                            <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="ddl_urbanizacion" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Negocio:</td>
                                <td class="formTdDato">
                                    <asp:CheckBoxList ID="cbl_negocio" runat="server" DataSourceID="ods_lista_negocio" DataTextField="nombre" DataValueField="id_negocio" CellPadding="0" CellSpacing="0" RepeatColumns="2"></asp:CheckBoxList>
                                    <asp:ObjectDataSource ID="ods_lista_negocio" runat="server" TypeName="terrasur.negocio" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Moneda:</td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_moneda" runat="server" DataSourceID="ods_lista_moneda" DataValueField="id_moneda" DataTextField="nombre_completo" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                    <%--[id_moneda],[codigo],[nombre],[nombre_completo]--%>
                                    <asp:ObjectDataSource ID="ods_lista_moneda" runat="server" TypeName="terrasur.moneda" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun"><asp:Label ID="lbl_consolidado_enun" runat="server"></asp:Label></td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_consolidado" runat="server" DataSourceID="ods_lista_consolidado" DataValueField="valor" DataTextField="texto" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                    <%--[valor],[texto]--%>
                                    <asp:ObjectDataSource ID="ods_lista_consolidado" runat="server" TypeName="terrasur.general" SelectMethod="ListaOpcionesConsolidado">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formEntTdButton" colspan="2">
                                   <asp:Button ID="btn_mostrar" runat="server"  SkinID="btnAccion" Text="Mostrar reporte"/>
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

