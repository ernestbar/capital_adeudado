<%@ Page Language="VB" %>
<%@ Register TagPrefix="smap" Namespace="SharpMap.Web.UI.Ajax" Assembly="SharpMap.UI" %>
<%@ Import Namespace="System.Web.Services" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Protected Property id_urbanizacion() As Integer
        Get
            Return Integer.Parse(lbl_id_urbanizacion.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_urbanizacion.Text = value
        End Set
    End Property
    Protected Property lista_archivos() As String
        Get
            Return lbl_lista_archivos.Text
        End Get
        Set(ByVal value As String)
            lbl_lista_archivos.Text = value
        End Set
    End Property
    Protected Property lista_estados() As String
        Get
            Return lbl_lista_estados.Text
        End Get
        Set(ByVal value As String)
            lbl_lista_estados.Text = value
        End Set
    End Property
    Protected Property archivo_guia_lotes() As String
        Get
            Return lbl_archivo_guia_lotes.Text
        End Get
        Set(ByVal value As String)
            lbl_archivo_guia_lotes.Text = value
        End Set
    End Property
    Protected Property archivo_guia_datos() As String
        Get
            Return lbl_archivo_guia_datos.Value
        End Get
        Set(ByVal value As String)
            lbl_archivo_guia_datos.Value = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Request.QueryString("id") IsNot Nothing Then
            If id_urbanizacion = 0 Then
                id_urbanizacion = Integer.Parse(Request.QueryString("id"))
                CargarDatosUrbanizacion()
                Session("lista_estados") = lista_estados
            End If
            ajaxMap.Map = New planimetria(lista_estados, lista_archivos, archivo_guia_lotes, archivo_guia_datos, New System.Drawing.Size(10, 10)).InitializeMap
            If Not Page.IsPostBack And Not Page.IsCallback Then
                If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "lote", "view") = False Then
                    If rblMapTools.Items.FindByValue("2") IsNot Nothing Then
                        rblMapTools.Items.Remove(rblMapTools.Items.FindByValue("2"))
                    End If
                End If
                If Request.QueryString("id_lote") IsNot Nothing Then
                    Dim sh As New SharpMap.Data.Providers.ShapeFile(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings("shape_dir") + archivo_guia_lotes), True)
                    sh.Open()
                    Dim id_lote As Integer = Integer.Parse(Request.QueryString("id_lote"))
                    Dim idx As Integer = -1
                    For i As Integer = 0 To sh.GetFeatureCount - 1
                        If sh.GetFeature(i)("ID").ToString.Equals(id_lote.ToString) Then
                            idx = i
                            Exit For
                        End If
                    Next
                    If idx >= 0 Then
                        ajaxMap.Map.ZoomToBox(sh.GetGeometryByID(idx).GetBoundingBox)
                        ajaxMap.Map.Zoom = ajaxMap.Map.Zoom * 3
                    Else
                        ajaxMap.Map.ZoomToExtents()
                    End If
                    sh.Close()
                Else
                    ajaxMap.Map.ZoomToExtents()
                End If
                ajaxMap.FadeSpeed = 0
                ajaxMap.ZoomSpeed = 15
            End If
            ajaxMap.ResponseFormat = "maphandler.ashx?MAP=SimpleWorld&Width=[WIDTH]&Height=[HEIGHT]&Zoom=[ZOOM]&X=[X]&Y=[Y]&ListaArchivos=" + lista_archivos + "&ArchivoGuiaLotes=" + archivo_guia_lotes + "&ArchivoGuiaDatos=" + archivo_guia_datos
            'ajaxMap.ResponseFormat = "maphandler.ashx?MAP=SimpleWorld&Width=[WIDTH]&Height=[HEIGHT]&Zoom=[ZOOM]&X=[X]&Y=[Y]&ListaArchivos=" + lista_archivos + "&ListaEstados=" + lista_estados + "&ArchivoGuiaLotes=" + archivo_guia_lotes
        End If
    End Sub

    Protected Sub CargarDatosUrbanizacion()
        Dim _lista_archivos As String = "", _lista_estados As String = "", _archivo_guia_lotes As String = "", _archivo_guia_datos As String = ""
        If id_urbanizacion > 0 Then
            planimetria.DatosPlanimetriaPorUrbanizacion(id_urbanizacion, _lista_archivos, _lista_estados, _archivo_guia_lotes, _archivo_guia_datos)
        End If
        lista_archivos = _lista_archivos
        lista_estados = _lista_estados
        archivo_guia_lotes = _archivo_guia_lotes
        archivo_guia_datos = _archivo_guia_datos
    End Sub

    <WebMethod()> _
    Public Shared Function LoteElegido(ByVal shape_guia As String, ByVal x As Double, ByVal y As Double) As Integer
        If shape_guia <> "" Then
            Dim _layer As New SharpMap.Layers.VectorLayer("LayerGuia")
            _layer.DataSource = New SharpMap.Data.Providers.ShapeFile(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings("shape_dir") & shape_guia))
            Dim worldQueryBox As New SharpMap.Geometries.BoundingBox(x - 1, y - 1, x + 1, y + 1)
            Dim fds As New SharpMap.Data.FeatureDataSet()
            _layer.DataSource.Open()
            _layer.DataSource.ExecuteIntersectionQuery(worldQueryBox, fds)
            If fds.Tables.Count > 0 Then
                Dim tabla_res As System.Data.DataTable = fds.Tables(0)
                If tabla_res.Rows.Count > 0 Then
                    Return Integer.Parse(tabla_res.Rows(0)(0).ToString())
                End If
            End If
        End If
        Return 0
    End Function
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body style="margin:0;">
    <form id="form1" runat="server">
        <asp:Label ID="lbl_id_urbanizacion" runat="server" Text="0" Visible="false"></asp:Label>
        <asp:Label ID="lbl_lista_archivos" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lbl_lista_estados" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lbl_archivo_guia_lotes" runat="server" Visible="false"></asp:Label>
        <%--<asp:Label ID="lbl_archivo_guia_datos" runat="server" Visible="false"></asp:Label>--%>
        <input id="lbl_archivo_guia_datos" type="hidden" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center">
                    <div style="float:left;position:absolute">
                        <button onclick="exportarPdf();return false;">Exportar PDF</button>
                    </div>
                    <asp:RadioButtonList ID="rblMapTools" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                        <asp:ListItem Value="0" Text="Acercar" Selected="True" onClick="ajaxMapObj.disableClickEvent(); ajaxMapObj.zoomAmount = 2;"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Alejar" onClick="ajaxMapObj.disableClickEvent(); ajaxMapObj.zoomAmount = 0.5;" ></asp:ListItem>
                        <asp:ListItem Value="2" Text="Datos del lote" onClick="ajaxMapObj.enableClickEvent();"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <smap:AjaxMapControl width="100%" height="640" id="ajaxMap" runat="server" DisplayStatusBar="false" OnClickEvent="MostrarDatosLote(event,ajaxMapObj);MapClicked" OnViewChange="ViewChanged" OnViewChanging="ViewChanging" />
                </td>
            </tr>
        </table>
        <script type="text/javascript">
        function ScriptCallback(result) {
            if (result > 0) 
                window.open('datosLote.aspx?id=' + result,'mywindow','width=800,height=500,left=100,top=100,toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,copyhistory=no,resizable=yes')
            //alert(result);
        }
        function MostrarDatosLote(event,obj) 
        {  
            var mousePos = SharpMap_GetRelativePosition(event.clientX,event.clientY,obj.container);
            var pnt = SharpMap_PixelToMap(mousePos.x,mousePos.y,obj);
            var field = document.getElementById('<%= lbl_archivo_guia_datos.ClientID %>');
            PageMethods.LoteElegido(field.value, pnt.x, pnt.y, ScriptCallback);
        }
        //Fired when query is selected and map is clicked
        function MapClicked(event,obj)
        {
            var mousePos = SharpMap_GetRelativePosition(event.clientX,event.clientY,obj.container);
            var pnt = SharpMap_PixelToMap(mousePos.x,mousePos.y,obj);
            //var field = document.getElementById('dataContents');
            //field.innerHTML = "You clicked map at: " + pnt.x + "," + pnt.y;
        }
        //Fired when a new map starts to load
        function ViewChanging(obj)
        {
            //var field = document.getElementById('dataContents');
            //field.innerHTML = "Cargando...";
        }
        //Fired when a map has loaded
        function ViewChanged(obj)
        {
            //var field = document.getElementById('dataContents');
            //field.innerHTML = "Coordenadas: " + obj.GetCenter().x + "," + obj.GetCenter().y;	
        }
            function exportarPdf() {
            window.open("mapPdf.ashx?id=<%= id_urbanizacion %>", "_blank", "toolbar=no,location=no,scrollbars=yes,resizable=yes,top=50,left=50,width=1024,height=768");  
        }
        </script>
    </form>
</body>
</html>
