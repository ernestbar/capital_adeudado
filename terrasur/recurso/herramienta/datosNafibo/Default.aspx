<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Generación de datos Nafibo" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>

<%@ Register src="~/recurso/herramienta/datosNafibo/userControl/ejecutadoProyectado.ascx" tagname="ejecutadoProyectado" tagprefix="uc2" %>
<%@ Register src="~/recurso/herramienta/datosNafibo/userControl/tablas.ascx" tagname="tablas" tagprefix="uc3" %>
<%@ Register src="~/recurso/herramienta/datosNafibo/userControl/formatoNafibo.ascx" tagname="formatoNafibo" tagprefix="uc4" %>

<script runat="server">
    Protected Property permiso_ejecutado_proyectado() As Boolean
        Get
            Return Boolean.Parse(lbl_permiso_ejecutado_proyectado.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_permiso_ejecutado_proyectado.Text = value.ToString
        End Set
    End Property
    Protected Property permiso_formato_nafibo() As Boolean
        Get
            Return Boolean.Parse(lbl_permiso_formato_nafibo.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_permiso_formato_nafibo.Text = value.ToString
        End Set
    End Property
    Protected Property permiso_generar_tablas() As Boolean
        Get
            Return Boolean.Parse(lbl_permiso_generar_tablas.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_permiso_generar_tablas.Text = value.ToString
        End Set
    End Property
    Protected Property permiso_ingresar_ajuste_pago() As Boolean
        Get
            Return Boolean.Parse(lbl_permiso_ingresar_ajuste_pago.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_permiso_ingresar_ajuste_pago.Text = value.ToString
        End Set
    End Property
   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            permiso_ejecutado_proyectado = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "datosNafibo", "ejecutado_proyectado")
            permiso_formato_nafibo = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "datosNafibo", "formato_nafibo")
            permiso_generar_tablas = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "datosNafibo", "generar_tablas")
            permiso_ingresar_ajuste_pago = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "datosNafibo", "ingresar_ajuste_pago")
            
            If permiso_ejecutado_proyectado = True Or permiso_formato_nafibo = True Or permiso_generar_tablas = True Or permiso_ingresar_ajuste_pago = True Then
                HabilitarPaneles()
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    Protected Sub HabilitarPaneles()
        panel_ejecutadoProyectado.Visible = permiso_ejecutado_proyectado
        If permiso_ejecutado_proyectado = True Then
            ejecutadoProyectado1.Reset()
        End If
        
        panel_tablas.Visible = permiso_generar_tablas
        If permiso_generar_tablas = True Then
            tablas1.Reset()
        End If
        
        panel_formato_nafibo.Visible = permiso_formato_nafibo
        If permiso_formato_nafibo = True Then
            formatoNafibo1.Reset()
        End If
        
        panel_ajuste_pago.Visible = permiso_ingresar_ajuste_pago
    End Sub

    Protected Sub btn_ajuste_pago_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ajuste_pago.Click
        Response.Redirect("~/recurso/herramienta/datosNafibo/contratoEspecial.aspx")
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
     <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="datosNafibo" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:Label ID="lbl_permiso_ejecutado_proyectado" runat="server" Text="False" Visible="false"></asp:Label>
<asp:Label ID="lbl_permiso_formato_nafibo" runat="server" Text="False" Visible="false"></asp:Label>
<asp:Label ID="lbl_permiso_generar_tablas" runat="server" Text="False" Visible="false"></asp:Label>
<asp:Label ID="lbl_permiso_ingresar_ajuste_pago" runat="server" Text="False" Visible="false"></asp:Label>
<table class="priTable">
    <tr>
        <td class="priTdTitle">Generación de datos Nafibo</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido">
                <tr>
                    <td>
                        <table align="center">
                            <tr>
                                <td valign="top">
                                    <asp:Panel ID="panel_ejecutadoProyectado" runat="server" GroupingText="Generación de Ejecutado y Proyectado">
                                        <uc2:ejecutadoProyectado ID="ejecutadoProyectado1" runat="server" />
                                    </asp:Panel>
                                </td>
                                <td valign="top">
                                    <asp:Panel ID="panel_tablas" runat="server" GroupingText="Generación de tablas para Titularización">
                                        <uc3:tablas ID="tablas1" runat="server" />
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Panel ID="panel_formato_nafibo" runat="server" GroupingText="Generación de datos en formato Nafibo">
                                        <uc4:formatoNafibo ID="formatoNafibo1" runat="server" />
                                    </asp:Panel>
                                </td>
                                <td valign="top">
                                    <asp:Panel ID="panel_ajuste_pago" runat="server" GroupingText="Contratos especiales y ajustes de montos de pago">
                                        <table align="center">
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="panel_contrato" runat="server" Height="200" ScrollBars="Vertical">
                                                    <asp:GridView ID="gv_contrato" runat="server" DataSourceID="ods_lista_contrato_especial" AutoGenerateColumns="false" DataKeyNames="id_contrato">
                                                        <Columns>
                                                            <%--<asp:BoundField DataField="num_contrato" HeaderText="Nº contrato" ItemStyle-CssClass="gvCell1" />--%>
                                                            <asp:TemplateField ItemStyle-CssClass="gvCell1"><ItemTemplate><asp:Label ID="lbl_lote" runat="server" Text='<%# Eval("num_contrato") %>' ToolTip='<%# Eval("observacion") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                                            <asp:BoundField DataField="lote" HeaderText="Lote" />
                                                            <asp:BoundField DataField="cuota_frecuente" HeaderText="Cuota frecuente" ItemStyle-CssClass="gvCell1" />
                                                            <asp:BoundField DataField="cuota_base" HeaderText="Cuota base" ItemStyle-CssClass="gvCell1" />
                                                        </Columns>
                                                    </asp:GridView>
                                                    </asp:Panel>
                                                    <%--[id_contrato],[num_contrato],[lote],[cuota_base],[cuota_frecuente]--%>
                                                    <asp:ObjectDataSource ID="ods_lista_contrato_especial" runat="server" TypeName="terrasur.contrato_especial_nafibo" SelectMethod="Lista">
                                                    </asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btn_ajuste_pago" runat="server" Text="Contratos especiales y ajustes de montos de pago" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
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

