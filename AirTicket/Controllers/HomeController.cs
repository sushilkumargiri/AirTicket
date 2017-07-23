using AirTicket.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirTicket.Controllers
{
    public class HomeController : Controller
    {
        public HomeController() { }
        private readonly IFileReadService _fileReadService;
        private readonly IFileTransformService _fileTransformService;
        private readonly IFileWriteService _fileWriteService;
        public HomeController(IFileReadService fileReadService, IFileWriteService fileWriteService, IFileTransformService fileTransformService)
        {
            _fileReadService = fileReadService;
            _fileWriteService = fileWriteService;
            _fileTransformService = fileTransformService;
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
        public ActionResult ProcessXml()
        {
            ViewBag.Title = "XML Process Page";
            var xmlData = _fileReadService.ReadXmlFile();
            var xsltData = _fileReadService.ReadXsltFile();
            int i = 1;
            foreach (var strData in xmlData)
            {
                var htmlData = _fileTransformService.TransformXMLToHTML(strData, xsltData);
                _fileWriteService.WriteHtmlFile(htmlData, i++.ToString() + ".html");
            }
            return View(i);
        }
    }
}
