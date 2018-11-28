using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering.Pdf;

namespace Lesson5
{
    class Program
    {
        private static readonly ManualResetEvent IsFinished = new ManualResetEvent(false);

        private static void Main(string[] args)

        {
            var htmlDocument = new HTMLDocument();
            //htmlDocument.OnLoad += MakeImage;
            htmlDocument.OnReadyStateChange += MakePDF;
            htmlDocument.Navigate("http://jv.gilead.org.il/pg/22759-h/");
            IsFinished.WaitOne();
            htmlDocument.Dispose();
        }

        private static void MakePDF(object sender, Aspose.Html.Dom.Events.Event e)

        {
            Console.WriteLine("<MakePDF>");
            if (sender is HTMLDocument doc)
                if (doc.ReadyState.Equals("complete"))
                {
                    Console.WriteLine(doc.ReadyState);
                    var pdfOptions = new PdfRenderingOptions();
                    pdfOptions.PageSetup.AnyPage.Margin = new Aspose.Html.Drawing.Margin(
                        Unit.FromMillimeters(15),
                        Unit.FromMillimeters(10),
                        Unit.FromMillimeters(5),
                        Unit.FromMillimeters(10));
                    pdfOptions.PageSetup.AnyPage.Size = new Aspose.Html.Drawing.Size(Unit.FromCentimeters(14.8), Unit.FromCentimeters(21));
                    using (var pdfDevice = new PdfDevice(pdfOptions, "Adventures.pdf"))
                    using (var renderer = new HtmlRenderer())
                    {
                        // Render the output using HtmlRenderer
                        renderer.Render(pdfDevice, doc);
                    }
                    IsFinished.Set();
                }
                else
                {
                    Console.WriteLine(doc.ReadyState);
                }
            Console.WriteLine("</MakePDF>");
        }

        private static void MakeImageJpeg(object sender, Aspose.Html.Dom.Events.Event e)

        {
            Console.WriteLine("<MakeImage>");
            if (sender is HTMLDocument doc)
                if (doc.ReadyState.Equals("complete"))
                {
                    Console.WriteLine(doc.ReadyState);
                    var imgOptions = new ImageRenderingOptions();
                    imgOptions.Format = ImageFormat.Jpeg;
                    imgOptions.PageSetup.AnyPage.Margin = new Aspose.Html.Drawing.Margin(Unit.FromCentimeters(1));
                    imgOptions.PageSetup.AnyPage.Size = new Aspose.Html.Drawing.Size(Unit.FromCentimeters(14.8), Unit.FromCentimeters(21));
                    using (var imgDevice = new ImageDevice(imgOptions, "Aspose_HTML.png"))
                    using (var renderer = new HtmlRenderer())
                    {
                        // Render the output using HtmlRenderer
                        renderer.Render(imgDevice, doc);
                    }
                    IsFinished.Set();
                }
                else
                {
                    Console.WriteLine(doc.ReadyState);
                }
            Console.WriteLine("</MakeImage>");
        }

        private static void MakeImageTiff(object sender, Aspose.Html.Dom.Events.Event e)

        {
            Console.WriteLine("<MakeImage>");
            if (sender is HTMLDocument doc)
                if (doc.ReadyState.Equals("complete"))
                {
                    Console.WriteLine(doc.ReadyState);
                    var imgOptions = new ImageRenderingOptions();
                    imgOptions.Format = ImageFormat.Tiff;
                    imgOptions.Compression = ImageRenderingOptions.Comression.LZW;
                    imgOptions.PageSetup.AnyPage.Margin = new Aspose.Html.Drawing.Margin(Unit.FromCentimeters(1));
                    imgOptions.PageSetup.AnyPage.Size = new Aspose.Html.Drawing.Size(Unit.FromCentimeters(14.8), Unit.FromCentimeters(21));
                    using (var imgDevice = new ImageDevice(imgOptions, "Aspose_HTML.Tiff"))
                    using (var renderer = new HtmlRenderer())
                    {
                        // Render the output using HtmlRenderer
                        renderer.Render(imgDevice, doc);
                    }
                    IsFinished.Set();
                }
                else
                {
                    Console.WriteLine(doc.ReadyState);
                }
            Console.WriteLine("</MakeImage>");
        }
    }
}
