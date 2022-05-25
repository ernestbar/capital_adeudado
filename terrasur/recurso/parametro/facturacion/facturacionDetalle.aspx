<%@ Page Language="VB" MasterPageFile="~/modulo/simple.master" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc3" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Session("id_parametrofacturacion") IsNot Nothing Then
                Dim pObj As New parametro_facturacion(Integer.Parse(Session("id_parametrofacturacion").ToString))
                lbl_sucursal.Text = New sucursal(pObj.id_sucursal, 0).nombre
                lbl_razon_social.Text = pObj.razon_social
                lbl_nit.Text = pObj.nit
                lbl_fecha.Text = pObj.fecha_limite.ToString("D")
                lbl_autorizacion.Text = pObj.num_autorizacion
                lbl_dosificacion.Text = pObj.llave_dosificacion
                lbl_num_siguiente.Text = pObj.num_siguiente_factura
        
                lbl_encab_empresa.Text = pObj.encabezado_empresa
                lbl_encab_actividad.Text = pObj.encabezado_actividad
                lbl_encab_direccion.Text = pObj.encabezado_direccion
                lbl_encab_telefono.Text = pObj.encabezado_telefono
                lbl_encab_lugar.Text = pObj.encabezado_lugar
                r_negocio.DataSource = parametro_facturacion_negocio.ListaNegocio(pObj.id_parametrofacturacion)
                r_negocio.DataBind()

                Page.Title = "Datos de los parámetros de facturación - " & pObj.razon_social
                Session.Remove("id_parametrofacturacion")
            Else
                Page.Visible = False
            End If
        End If
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc3:recursoMaster ID="RecursoMaster1" runat="server" recurso="facturacion" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="viewEntTable">
        <tr>
            <td class="viewEntTd">
                <table class="viewTable" align="center">
                    <tr><td class="viewTdTitle" colspan="2">Datos de los parámetros de facturación</td></tr>
                    <tr>
                        <td class="viewTdEnun">Sucursal:</td>
                        <td class="viewTdDato"><asp:Label ID="lbl_sucursal" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun">Razón Social:</td>
                        <td class="viewTdDato"><asp:Label ID="lbl_razon_social" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun">NIT:</td>
                        <td class="viewTdDato"><asp:Label ID="lbl_nit" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun">Fecha límite de emisión:</td>
                        <td class="viewTdDato"><asp:Label ID="lbl_fecha" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun">Nº de autorización:</td>
                        <td class="viewTdDato"><asp:Label ID="lbl_autorizacion" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun">Llave de dosificación:</td>
                        <td class="viewTdDato"><asp:Label ID="lbl_dosificacion" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun">Nº siguiente factura:</td>
                        <td class="viewTdDato"><asp:Label ID="lbl_num_siguiente" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun">Encabezado - Empresa:</td>
                        <td class="viewTdDato"><asp:Label ID="lbl_encab_empresa" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun">Encabezado - Actividad:</td>
                        <td class="viewTdDato"><asp:Label ID="lbl_encab_actividad" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun">Encabezado - Dirección:</td>
                        <td class="viewTdDato"><asp:Label ID="lbl_encab_direccion" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun">Encabezado - Teléfono:</td>
                        <td class="viewTdDato"><asp:Label ID="lbl_encab_telefono" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun">Encabezado - Lugar:</td>
                        <td class="viewTdDato"><asp:Label ID="lbl_encab_lugar" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun">Negocios:</td>
                        <td class="viewTdDato">
                            <asp:Repeater ID="r_negocio" runat="server">
                                <HeaderTemplate><table cellpadding="0" cellspacing="0"></HeaderTemplate>
                                <ItemTemplate><tr><td><asp:Label ID="lbl_negocio" runat="server" Text='<%# Eval("negocio") %>'></asp:Label></td></tr></ItemTemplate>
                                <FooterTemplate></table></FooterTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>

                </table>
            </td>
        </tr>
    </table>
</asp:Content>

