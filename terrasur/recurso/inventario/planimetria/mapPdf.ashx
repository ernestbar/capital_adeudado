<%@ WebHandler Language="C#" Class="mapPdf" %>

using System;
using System.Collections.Generic;
using System.Web;
using SharpMap;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp;
using System.Drawing;
using SharpMap.Layers;
using System.IO;
using terrasur;

public class mapPdf : IHttpHandler {

    private const int Margin = 25;
    private string sector = string.Empty;
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Write("Error al generar el archivo");

        try
        {
            int id_urbanizacion = Convert.ToInt32(context.Request.QueryString.Get("id").ToString());
            string lista_estados = string.Empty;
            string lista_archivos = string.Empty;
            string archivo_guia_lotes = string.Empty;
            string archivo_guia_datos=string.Empty;

            planimetria.DatosPlanimetriaPorUrbanizacion(id_urbanizacion, ref lista_archivos, ref lista_estados, ref archivo_guia_lotes, ref archivo_guia_datos);

            Map mapa = new planimetria(lista_estados, lista_archivos, archivo_guia_lotes, archivo_guia_datos, new System.Drawing.Size(4000, 4000)).InitializeMap();

            urbanizacion urb = new urbanizacion(id_urbanizacion);
            sector = urb.nombre;

            GeneratePDF(mapa, PageSize.Tabloid, 0, 0, XGraphicsUnit.Inch,context);

        }
        catch (Exception ex) { }

    }
    internal  void GeneratePDF(Map mapCtrl, PageSize pageSize,
            double width, double height, XGraphicsUnit pageUnits,HttpContext context)
    {
        PdfDocument doc = new PdfDocument();
        doc.Info.Title = "Planimetria";
        doc.Options.CompressContentStreams = true;
        doc.Options.NoCompression = false;

        PdfPage page = doc.AddPage();
        page.Size = pageSize;

        if (pageSize == PageSize.Undefined)
        {
            page.Width = new XUnit(width, pageUnits);
            page.Height = new XUnit(height, pageUnits);
        }

        DrawMapOnPage(mapCtrl, page);

        //doc.Save(pdfFileName); 

        context.Response.Clear();
        context.Response.ClearContent();
        context.Response.ClearHeaders();
        context.Response.ContentType = "application/pdf";

        using (MemoryStream ms = new MemoryStream())
        {
            doc.Save(ms, false);
            byte[] buffer = new byte[ms.Length];
            ms.Seek(0, SeekOrigin.Begin);
            ms.Flush();
            ms.Read(buffer, 0, (int)ms.Length);
            context.Response.BinaryWrite(buffer);
        }
        context.Response.Flush();
        doc.Close();
    }

    private  void DrawMapOnPage(Map mapCtrl, PdfPage page)
    {
        Size size = PageSizeConverter.ToSize(page.Size).ToSizeF().ToSize();
        //size = new Size(size.Width - totMargin, size.Height - totMargin);
        size = new Size(size.Width - 1, size.Height - 1);

        XRect titleRect, mapRect, legendRect = XRect.Empty;

        //1.8% of page height for Title
        titleRect = new XRect(Margin, Margin, size.Width, (double)size.Height * 0.05d);

        //80% of page height for Map
        mapRect = new XRect(10, Margin + titleRect.Height, size.Width-Margin, (double)size.Height * 0.84d);

        //18.2% of page height for Legend
        legendRect = new XRect(Margin, Margin + titleRect.Height + mapRect.Height+10,
        size.Width, (double)size.Height * 0.1d);

        using (XGraphics g = XGraphics.FromPdfPage(page))
        {
            XFont xFont = new XFont("Helvetica", 14);
            XFont xFont2 = new XFont("Helvetica", 8);

            using (XForm xForm = new XForm(g, titleRect.Size))
            {
                using (XGraphics xg = XGraphics.FromForm(xForm))
                {
                    XStringFormat format = new XStringFormat();
                    format.Alignment = XStringAlignment.Center;

                    xg.DrawString(sector.ToUpper(), xFont, XBrushes.Black, new XRect(10, 12d, titleRect.Width-100,15d), format);

                    // xg.DrawString("Planimetria", xFont, XBrushes.Black, new XRect(10, 4d, titleRect.Width-100,8d), format);
                    xg.DrawString("Planimetria", xFont2, XBrushes.Black, Margin, 10d);
                    xg.DrawString(string.Format("{0}",DateTime.Today.ToShortDateString()), xFont2, XBrushes.Black, titleRect.Width-120, 10d);
                }

                g.DrawImage(xForm, titleRect);
            }

            //Calculate the size allowed for the map
            size = mapRect.Size.ToSizeF().ToSize();

            //using (Map tempMap = clon)
            //{
            //    tempMap.ZoomToExtents();
            //    ILayer[] layers = new ILayer[tempMap.Layers.Count];

            //    for (int i = 0; i < tempMap.Layers.Count; i++)
            //        layers[i] = tempMap.Layers[i];

            //    foreach (ILayer layer in layers)
            //    {
            //        using (XForm xForm = new XForm(g, mapRect.Size))
            //        {
            //            using (XGraphics xg = XGraphics.FromForm(xForm))
            //            {                                
            //                layer.Render(xg.Graphics, tempMap);
            //            }

            //            g.DrawImage(xForm, mapRect);
            //        }
            //    };
            //}
            mapCtrl.ZoomToExtents();
            Image imagen = mapCtrl.GetMap();
            using (Map tempMap = mapCtrl)
            {
                using (XForm xForm = new XForm(g, mapRect.Size))
                {
                    using (XGraphics xg = XGraphics.FromForm(xForm))
                    {
                        xg.DrawImage(imagen,0,0, mapRect.Width,mapRect.Width);
                    }

                    g.DrawImage(xForm, mapRect);
                }
            }

            using (XForm xForm = new XForm(page.Reference.Document, legendRect.Size))
            {
                using (XGraphics xg = XGraphics.FromForm(xForm))
                {
                    XSolidBrush brush;
                    int x = 0;
                    brush = new XSolidBrush(XColor.FromArgb(245,118,15));
                    xg.DrawRectangle(XPens.White, brush, new XRect(x, 0, 10, 10));
                    xg.DrawString("Disponible", xFont2, XBrushes.Black, x+11, 8d);

                    x += 60;
                    brush = new XSolidBrush(XColor.FromArgb(0, 102, 174));
                    xg.DrawRectangle(XPens.White, brush, new XRect(x, 0, 10, 10));
                    xg.DrawString("Intercambio", xFont2, XBrushes.Black, x+11, 8d);

                    x += 60;
                    brush = new XSolidBrush(XColor.FromArgb(255, 0, 0));
                    xg.DrawRectangle(XPens.White, brush, new XRect(x, 0, 10, 10));
                    xg.DrawString("Cancelado", xFont2, XBrushes.Black, x+11, 8d);

                    x += 60;
                    brush = new XSolidBrush(XColor.FromArgb(246, 249, 11));
                    xg.DrawRectangle(XPens.White, brush, new XRect(x, 0, 10, 10));
                    xg.DrawString("Nafibo", xFont2, XBrushes.Black, x+11, 8d);

                    x += 60;
                    brush = new XSolidBrush(XColor.FromArgb(247, 119, 185));
                    xg.DrawRectangle(XPens.White, brush, new XRect(x, 0, 10, 10));
                    xg.DrawString("Vendido", xFont2, XBrushes.Black, x+11, 8d);

                    x += 60;
                    brush = new XSolidBrush(XColor.FromArgb(0, 255, 255));
                    xg.DrawRectangle(XPens.White, brush, new XRect(x, 0, 10, 10));
                    xg.DrawString("Preasignado", xFont2, XBrushes.Black, x+11, 8d);

                    x += 60;
                    brush = new XSolidBrush(XColor.FromArgb(165, 165, 165));
                    xg.DrawRectangle(XPens.White, brush, new XRect(x, 0, 10, 10));
                    xg.DrawString("Bloqueado", xFont2, XBrushes.Black, x+11, 8d);

                    x += 60;
                    brush = new XSolidBrush(XColor.FromArgb(102, 51, 0));
                    xg.DrawRectangle(XPens.White, brush, new XRect(x, 0, 10, 10));
                    xg.DrawString("Reservado", xFont2, XBrushes.Black, x+11, 8d);

                    x += 60;
                    brush = new XSolidBrush(XColor.FromArgb(0, 0, 0));
                    xg.DrawRectangle(XPens.White, brush, new XRect(x, 0, 10, 10));
                    xg.DrawString("Inexistente", xFont2, XBrushes.Black, x+11, 8d);

                    x = 0;
                    string rutaTxt = HttpContext.Current.Server.MapPath("~/images/estadoLote/");
                    xg.DrawImage(XImage.FromFile(Path.Combine(rutaTxt, "venRetrasado1.jpg")), new XRect(x, 15, 10, 10));
                    xg.DrawString("Retrasado", xFont2, XBrushes.Black, x+11, 24d);

                    x += 60;
                    xg.DrawImage(XImage.FromFile(Path.Combine(rutaTxt, "venMora1.jpg")), new XRect(x, 15, 10, 10));
                    xg.DrawString("En Mora", xFont2, XBrushes.Black, x+11, 24d);
                }

                g.DrawImage(xForm, legendRect);
            }
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}