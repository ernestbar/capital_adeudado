<%@ Page Language="VB" MasterPageFile="~/modulo/simple.master" Title="Emisión de documentos a clientes" %>

<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>

<%@ Register src="~/recurso/contrato/reporteContrato/userControl/contratoEmisionFiltro.ascx" tagname="contratoEmisionFiltro" tagprefix="uc3" %>

<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            'If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "reporteContratoEmision") Then
            Dim id_contrato As Integer = 0
            If Integer.TryParse(Request.QueryString("ic"), id_contrato) = True Then
                If id_contrato > 0 Then
                    'Dim tipo_documento As String = Request.QueryString("td").ToString()
                    CargarReporte(id_contrato)
                Else
                    Page.Visible = False
                End If
            Else
                Page.Visible = False
            End If
            'Else
            '    Page.Visible = False
            'End If
        End If
    End Sub
    
    Protected Sub CargarReporte(ByVal _id_contrato As Integer)
        Dim num_contrato As String = (New contrato(_id_contrato)).numero
        
        Dim tabla As Data.DataTable = terrasur.emDoc.emision.Lista(DateTime.Parse("01/01/1900"), DateTime.Parse("01/01/2900"), "", 0, num_contrato, "", -1)
        Dim rep As New rpt_contratoEmision
        rep.CargarEncabezado(Profile.nombre_persona, "", "", num_contrato, "", "", "Todos", tabla.Rows.Count)
        rep.DataSource = tabla
        Reporte1.WebView.Report = rep
    End Sub
    
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="emisionDocCliente" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <table class="priTable">
        <tr><td class="priTdTitle"><asp:Label ID="lbl_titulo" runat="server" Text="Emisión de documentos a clientes"></asp:Label></td></tr>
        <tr>
            <td>
                <uc2:reporte ID="Reporte1" runat="server" Formato_Excel="false" Formato_Word="false" />
            </td>
        </tr>
    </table>
</asp:Content>