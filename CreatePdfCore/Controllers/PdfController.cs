using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CreatePdfCore.Services;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Path = System.IO.Path;

namespace CreatePdfCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PdfController : ControllerBase
    {
        private readonly ICreateFile _file;

        public PdfController(ICreateFile file)
        {
            _file = file;
        }

        [HttpGet("api/GetPdf")]
        public ActionResult GetPdf()
        {
            return File (_file.Create(), "application/pdf", "TestCap.pdf");
        }
    }
}
