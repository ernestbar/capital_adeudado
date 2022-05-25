<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Contratos bloqueados para Síntesis" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register src="~/recurso/sintesis/sBloqueado/userControl/sBloqueadoAbm.ascx" tagname="sBloqueadoAbm" tagprefix="uc2" %>

<script runat="server">
    Protected Property permiso_desbloquear() As Boolean
        Get
            Return Boolean.Parse(lbl_permiso_desbloquear.text)
        End Get
        Set(ByVal value As Boolean)
            lbl_permiso_desbloquear.text = value
        End Set
    End Property
    
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sBloqueado", "view") Then
                permiso_desbloquear = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sBloqueado", "desbloquear")
                btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sBloqueado", "bloquear")
                btn_historial.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sBloqueado", "historial")
                MostrarControles("reset", 0)
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub MostrarControles(ByVal acccion As String, ByVal id_bloqueado As Integer)
        If acccion = "reset" Then
            btn_nuevo.Enabled = True
            panel_abm.Visible = False
        ElseIf acccion = "bloquear" Then
            btn_nuevo.Enabled = False
            panel_abm.Visible = True
            panel_abm.GroupingText = "Bloqueo de contrato"
            panel_abm.DefaultButton = "btn_bloquear"
            sBloqueadoAbm1.CargarBloquear()
            btn_bloquear.Visible = True
            btn_desbloquear.Visible = False
        ElseIf acccion = "desbloquear" Then
            btn_nuevo.Enabled = False
            panel_abm.Visible = True
            panel_abm.GroupingText = "Desbloqueo de contrato"
            panel_abm.DefaultButton = "btn_desbloquear"
            sBloqueadoAbm1.CargarDesbloquear(id_bloqueado)
            btn_bloquear.Visible = False
            btn_desbloquear.Visible = True
        End If
    End Sub
    
   
    Protected Sub gv_contrato_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_contrato.DataBound
        gv_contrato.Columns(0).Visible = permiso_desbloquear
    End Sub
    Protected Sub gv_contrato_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv_contrato.RowCommand
        If e.CommandName = "desbloquear" Then
            MostrarControles("desbloquear", Integer.Parse(e.CommandArgument.ToString))
        End If
    End Sub
    

    Protected Sub gv_contrato_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_contrato.RowDataBound
        general.OnMouseOver(sender, e)
    End Sub

    Protected Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MostrarControles("bloquear", 0)
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MostrarControles("reset", 0)
    End Sub

    Protected Sub btn_bloquear_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If sBloqueadoAbm1.Bloquear() Then
            gv_contrato.DataBind()
            MostrarControles("reset", 0)
        End If
    End Sub

    Protected Sub btn_desbloquear_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If sBloqueadoAbm1.Desbloquear() Then
            gv_contrato.DataBind()
            MostrarControles("reset", 0)
        End If
    End Sub

    Protected Sub btn_historial_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        WinPopUp1.Show()
    End Sub
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="sBloqueado" MostrarLink="true"/>
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:WinPopUp id="WinPopUp1" runat="server" NavigateUrl="~/recurso/sintesis/sBloqueado/historial.aspx"></asp:WinPopUp>

<asp:Label ID="lbl_permiso_desbloquear" runat="server" Text="false" Visible="false"></asp:Label>

<table class="priTable" width="100%">
    <tr><td class="priTdTitle">Contratos bloqueados para Síntesis</td></tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido" align="center">
                <tr>
                    <td>
                        <table width="100%"> 
                            <tr>
                                <td align="left"><asp:Button ID="btn_nuevo" runat="server" Text="Bloquear contrato" OnClick="btn_nuevo_Click" /></td>
                                <td align="right"><asp:Button ID="btn_historial" runat="server" Text="Historial de bloqueos" OnClick="btn_historial_Click" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <%--<td valign="top"></td>--%>
                                <td valign="top">
                                    <asp:Panel ID="panel_abm" runat="server">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td><uc2:sBloqueadoAbm ID="sBloqueadoAbm1" runat="server" /></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btn_bloquear" runat="server" Text="Bloquear" CausesValidation="true" ValidationGroup="contrato" OnClick="btn_bloquear_Click" />
                                                    <asp:Button ID="btn_desbloquear" runat="server" Text="Desbloquear" CausesValidation="true" ValidationGroup="contrato" OnClick="btn_desbloquear_Click" />
                                                    <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" CausesValidation="false" OnClick="btn_cancelar_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="tdMsg">
                        <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                    </td>
                </tr>
                <tr>
                    <td class="tdGrid">
                        <asp:GridView ID="gv_contrato" runat="server" AutoGenerateColumns="False" DataSourceID="ods_lista_contratos" DataKeyNames="id_bloqueado">
                            <Columns>
                                <asp:TemplateField><ItemTemplate><asp:LinkButton ID="lb_desbloquear" runat="server" Text="Desploquear" CommandName="desbloquear" CommandArgument='<%# Eval("id_bloqueado") %>'></asp:LinkButton></ItemTemplate></asp:TemplateField>
                                <asp:BoundField HeaderText="Nº contrato" DataField="num_contrato" ItemStyle-CssClass="gvCell1" />
                                <asp:BoundField HeaderText="Estado" DataField="estado" />
                                <asp:BoundField HeaderText="Fecha (bloq.)" DataField="activo_fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate" />
                                <asp:BoundField HeaderText="Usuario (bloq.)" DataField="activo_usuario" />
                                <asp:BoundField HeaderText="Observación (bloq.)" DataField="activo_observacion" />
                            </Columns>
                        </asp:GridView>
                        <%--[id_bloqueado],[num_contrato],[estado],[activo_fecha],[activo_usuario],[activo_observacion]--%>
                        <asp:ObjectDataSource ID="ods_lista_contratos" runat="server" TypeName="terrasur.sintesis.s_bloqueado" SelectMethod="ListaActivo">
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>

        </td>
    </tr>
    </table>
</asp:Content>

