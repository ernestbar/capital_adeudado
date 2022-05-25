<%@ WebHandler Language="C#" Class="MapHandler" %>

using System;
using System.Web;

/// <summary>
/// The maphandler class takes a set of GET or POST parameters and returns a map as PNG (this reminds in many ways of the way a WMS server work).
/// Required parameters are: WIDTH, HEIGHT, ZOOM, X, Y, MAP
/// </summary>
public class MapHandler : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
{
	internal static System.Globalization.NumberFormatInfo numberFormat_EnUS = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
    public void ProcessRequest(HttpContext context)
    {
        int Width = 0;
        int Height = 0;
        double Zoom = 0;
        double centerX = 0;
        double centerY = 0;
        //Parse request parameters
        if (context.Request.Params["MAP"] == null) throw (new ArgumentException("Invalid parameter"));
        if (!int.TryParse(context.Request.Params["WIDTH"], out Width)) throw (new ArgumentException("Invalid parameter"));
        if (!int.TryParse(context.Request.Params["HEIGHT"], out Height)) throw (new ArgumentException("Invalid parameter"));
        if (!double.TryParse(context.Request.Params["ZOOM"], System.Globalization.NumberStyles.Float, numberFormat_EnUS, out Zoom)) throw (new ArgumentException("Invalid parameter"));
        if (!double.TryParse(context.Request.Params["X"], System.Globalization.NumberStyles.Float, numberFormat_EnUS, out centerX)) throw (new ArgumentException("Invalid parameter"));
        if (!double.TryParse(context.Request.Params["Y"], System.Globalization.NumberStyles.Float, numberFormat_EnUS, out centerY)) throw (new ArgumentException("Invalid parameter"));
        string ListaArchivos = context.Request.Params["ListaArchivos"];
        //string ListaEstados = context.Request.Params["ListaEstados"];
        string ListaEstados = HttpContext.Current.Session["lista_estados"].ToString();
        string ArchivoGuiaLotes = context.Request.Params["ArchivoGuiaLotes"];
        string ArchivoGuiaDatos = context.Request.Params["ArchivoGuiaDatos"];

        //Se inicializa el mapa (en formato ShareMap)
        //SharpMap.Map map = MapHelper.InitializeMap(new System.Drawing.Size(Width, Height), Lista);
        SharpMap.Map map = new terrasur.planimetria(ListaEstados, ListaArchivos, ArchivoGuiaLotes, ArchivoGuiaDatos, new System.Drawing.Size(Width, Height)).InitializeMap();
        if (map == null) throw (new ArgumentException("Invalid map"));

        //Set visible map extents
        map.Center = new SharpMap.Geometries.Point(centerX, centerY);
        map.Zoom = Zoom;
        //Se genera el archivo del mapa
        System.Drawing.Bitmap img = (System.Drawing.Bitmap)map.GetMap();

        //Se encia el mapa (formato png) a la página Web
        context.Response.ContentType = "image/png";
        System.IO.MemoryStream MS = new System.IO.MemoryStream();
        img.Save(MS, System.Drawing.Imaging.ImageFormat.Png);
        img.Dispose();
        byte[] buffer = MS.ToArray();
        context.Response.OutputStream.Write(buffer, 0, buffer.Length);
    }

    public bool IsReusable { get { return false; } }

}