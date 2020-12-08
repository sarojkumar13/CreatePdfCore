using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CreatePdfCore.Services
{
    public class CreateFile: ICreateFile
    {
        public byte[] Create()
        {
            MemoryStream ms = new MemoryStream();
            PdfWriter pd = new PdfWriter(ms);
            PdfDocument pdf = new PdfDocument(pd);
            Document doc = new Document(pdf, iText.Kernel.Geom.PageSize.A4);
            //doc.SetMargins(65, 35, 60, 35);

            //string webRootPath = _webHostEnvironment.WebRootPath;

            //string path = "";
            //path = Path.Combine(webRootPath, "assets/Test.jpg");

            Image img = new Image(ImageDataFactory.Create(@"D:\Stuff\Test.jpg")).SetHeight(45).SetWidth(40);



            Table tbl1 = new Table(2).UseAllAvailableWidth().SetBorder(Border.NO_BORDER)
                .SetBackgroundColor(Color.ConvertRgbToCmyk((DeviceRgb)DeviceRgb.RED)).SetHeight(50).SetMarginTop(-40)
                .SetMarginLeft(-40).SetMarginRight(-40);
            Cell cell11 = new Cell().Add(new Paragraph("")).SetWidth(1000).SetBorder(Border.NO_BORDER);
            Cell cell12 = new Cell().Add(new Paragraph("")).Add(img).SetWidth(40).SetBorder(Border.NO_BORDER);
            tbl1.AddCell(cell11);
            tbl1.AddCell(cell12);
            doc.Add(tbl1);

            Table tbl = new Table(1).UseAllAvailableWidth().SetBorder(Border.NO_BORDER).SetMarginTop(20);
            Cell cell = new Cell().Add(new Paragraph("Thank You").SetFontSize(20)).SetBorder(Border.NO_BORDER)
                .SetTextAlignment(TextAlignment.CENTER).SetFontColor(Color.ConvertRgbToCmyk((DeviceRgb)DeviceRgb.RED));
            tbl.AddCell(cell);
            cell = new Cell().Add(new Paragraph("You can add custome messages, paragaraph, color, indentation etc... You can also customerize layout and font.")).SetBorder(Border.NO_BORDER);

            tbl.AddCell(cell);
            doc.Add(tbl);

            doc.Close();
            byte[] byteStream = ms.ToArray();
            ms = new MemoryStream();
            ms.Write(byteStream, 0, byteStream.Length);
            ms.Position = 0;
            return byteStream;
        }
    }
}
