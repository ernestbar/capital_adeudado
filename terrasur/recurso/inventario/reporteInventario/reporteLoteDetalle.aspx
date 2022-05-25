<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Inventario de lotes (Detalle)" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteInventario", "reporteLoteDetalle") Then
                lbl_id_estado_bloqueado.Text = New estado("blo").id_estado
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
      
    Protected Sub ddl_localizacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Reporte1.WebView.ClearCachedReport()
        ddl_urbanizacion.DataBind()
        ddl_manzano.DataBind()
    End Sub
    
    Protected Sub ddl_urbanizacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddl_manzano.DataBind()
    End Sub

    Protected Sub cbl_negocio_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbl_negocio.DataBound
        For Each item As ListItem In cbl_negocio.Items
            item.Selected = True
        Next
    End Sub
    
    Protected Sub ddl_estado_lote_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        ddl_estado_lote.Items.Insert(0, New ListItem("Todos", "0"))
    End Sub

    Protected Sub ddl_estado_lote_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddl_motivo_bloqueo.Visible = Integer.Parse(ddl_estado_lote.SelectedValue).Equals(Integer.Parse(lbl_id_estado_bloqueado.Text))
    End Sub

    Protected Sub ddl_localizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        'ddl_localizacion.Items.Insert(0, New ListItem("Todos", "0"))
    End Sub

    Protected Sub ddl_urbanizacion_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        ddl_urbanizacion.Items.Insert(0, New ListItem("Todos", "0"))
    End Sub

    Protected Sub ddl_manzano_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        ddl_manzano.Items.Insert(0, New ListItem("Todos", "0"))
    End Sub

    Protected Sub ddl_motivo_bloqueo_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_motivo_bloqueo.DataBound
        ddl_motivo_bloqueo.Items.Insert(0, New ListItem("Todos", "0"))
    End Sub

    Protected Sub btn_mostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        cargarReporte()
    End Sub
    
    Public Sub cargarReporte()
        Dim id_motivobloqueo As Integer = 0
        Dim nombre_estado_lote As String = ddl_estado_lote.SelectedItem.Text
        
        If Integer.Parse(ddl_estado_lote.SelectedValue) = Integer.Parse(lbl_id_estado_bloqueado.Text) Then
            If Integer.Parse(ddl_motivo_bloqueo.SelectedValue) > 0 Then
                id_motivobloqueo = Integer.Parse(ddl_motivo_bloqueo.SelectedValue)
                nombre_estado_lote = nombre_estado_lote & " (" + ddl_motivo_bloqueo.SelectedItem.Text + ")"
            End If
        End If
        
        Dim reporte As New rpt_lote_detalle_comentario()
        reporte.CargarDatos(cp_fecha.SelectedDate, ddl_localizacion.SelectedItem.Text, ddl_urbanizacion.SelectedItem.Text, ddl_manzano.SelectedItem.Text, nombre_estado_lote, general.StringNegocios(False, cbl_negocio.Items))
        reporte.DataSource = inventarioReporte.ReporteLoteDetalle(cp_fecha.SelectedDate, Int32.Parse(ddl_localizacion.SelectedValue.Trim()), Int32.Parse(ddl_urbanizacion.SelectedValue.Trim()), Int32.Parse(ddl_manzano.SelectedValue.Trim()), Int32.Parse(ddl_estado_lote.SelectedValue.Trim()), general.StringNegocios(True, cbl_negocio.Items), id_motivobloqueo)
        Reporte1.WebView.Report = reporte
    End Sub

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteInventario" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:Label ID="lbl_id_estado_bloqueado" runat="server" Text="0" Visible="false"></asp:Label>
<table class="priTable">
    <tr>
        <td class="priTdTitle">Inventario de lotes (Detalle)</td>
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
                                <td class="formTdEnun"><asp:Label ID="lbl_fecha" runat="server" Text="Inventario al:"></asp:Label></td>
                                <td class="formTdDato">
                                    <ew:CalendarPopup ID="cp_fecha" runat="server" AutoPostBack="false" >
                                    </ew:CalendarPopup>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun"><asp:Label ID="lbl_localizacion_enun" runat="server" Text="Localización:"></asp:Label></td>
                                <td class="formTdDato">
                                    <asp:DropDownList ID="ddl_localizacion" runat="server" AutoPostBack="true" DataSourceID="ods_localizacion_lista" DataTextField="nombre" DataValueField="id_localizacion" OnSelectedIndexChanged="ddl_localizacion_SelectedIndexChanged" OnDataBound="ddl_localizacion_DataBound">
                                    </asp:DropDownList>
                                    <%--[id_localizacion],[nombre]--%>
                                    <asp:ObjectDataSource ID="ods_localizacion_lista" runat="server" TypeName="terrasur.localizacion" SelectMethod="Lista"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun"><asp:Label ID="lbl_urbanizacion_enun" runat="server" Text="Sector:"></asp:Label></td>
                                <td class="formTdDato">
                                    <asp:DropDownList ID="ddl_urbanizacion" runat="server" AutoPostBack="true" DataSourceID="ods_urb_lista" DataTextField="nombre_completo" DataValueField="id_urbanizacion" OnSelectedIndexChanged="ddl_urbanizacion_SelectedIndexChanged" OnDataBound="ddl_urbanizacion_DataBound">
                                    </asp:DropDownList>
                                    <%--[id_urbanizacion],[nombre]--%>
                                    <asp:ObjectDataSource ID="ods_urb_lista" runat="server" TypeName="terrasur.urbanizacion" SelectMethod="Lista">
                                        <SelectParameters>
                                            <asp:ControlParameter Name="Id_localizacion" Type="Int32" ControlID="ddl_localizacion" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun"><asp:Label ID="lbl_manzano_enun" runat="server" Text="Manzano:"></asp:Label></td>
                                <td class="formTdDato">
                                    <asp:DropDownList ID="ddl_manzano" runat="server" AutoPostBack="false" DataSourceID="ods_manzano_lista" DataTextField="codigo" DataValueField="id_manzano" OnDataBound="ddl_manzano_DataBound" >
                                    </asp:DropDownList>
                                    <%--[id_manzano],[codigo]--%>
                                    <asp:ObjectDataSource ID="ods_manzano_lista" runat="server" TypeName="terrasur.manzano" SelectMethod="Lista">
                                        <SelectParameters>
                                            <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="ddl_urbanizacion" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun"><asp:Label ID="lbl_estado_lote_enun" runat="server" Text="Estado:"></asp:Label></td>
                                <td class="formTdDato">
                                    <asp:DropDownList ID="ddl_estado_lote" runat="server" DataSourceID="ods_estado_lote_lista" DataTextField="nombre" DataValueField="id_estado" OnDataBound="ddl_estado_lote_DataBound" AutoPostBack="true" OnSelectedIndexChanged="ddl_estado_lote_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <%--[id_lote],[codigo]--%>
                                    <asp:ObjectDataSource ID="ods_estado_lote_lista" runat="server" TypeName="terrasur.estado" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                    <asp:DropDownList ID="ddl_motivo_bloqueo" runat="server" DataSourceID="ods_lista_motivo_bloqueo" DataTextField="nombre" DataValueField="id_motivobloqueo" Visible="false">
                                    </asp:DropDownList>
                                    <%--[id_motivobloqueo],[codigo],[nombre]--%>
                                    <asp:ObjectDataSource ID="ods_lista_motivo_bloqueo" runat="server" TypeName="terrasur.motivo_bloqueo" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun"><asp:Label ID="lbl_negocio" runat="server" Text="Negocio:"></asp:Label></td>
                                <td class="formTdDato">
                                    <asp:CheckBoxList ID="cbl_negocio" runat="server" AutoPostBack="false" DataSourceID="ods_negocio_lista" DataTextField="nombre" DataValueField="id_negocio" CellPadding="0" CellSpacing="0" RepeatColumns="2"></asp:CheckBoxList>
                                    <%--[id_lote],[codigo]--%>
                                    <asp:ObjectDataSource ID="ods_negocio_lista" runat="server" TypeName="terrasur.negocio" SelectMethod="Lista"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <%--<tr>
                                <td class="formTdEnun">Observaciones:</td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_comentario" runat="server" CellPadding="0" CellSpacing="0">
                                        <asp:ListItem Text="Mostrar observaciones del estado actual de los lotes" Value="true" Selected="true"></asp:ListItem>
                                        <asp:ListItem Text="No mostrar observaciones del estado actual de los lotes" Value="true"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>--%>
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
                    <uc1:reporte ID="Reporte1" runat="server" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

