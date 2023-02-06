using Microsoft.AspNetCore.Mvc;
using SqlDataGonderim.Models;
using System.Diagnostics;

namespace SqlDataGonderim.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KisilerContext _context;

        public HomeController(ILogger<HomeController> logger, KisilerContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.FormPanel = false;
            return View();
        }


        [HttpPost]
        public IActionResult Index(string kisiname)
        {
            Kisiler kisi = new Kisiler();
            kisi.KisiName = kisiname;

            _context.Add(kisi);
            _context.SaveChanges();

            ViewBag.FormPanel = true;
            return View();
        }


        [HttpPost]
        [Route("ajaks/kisi/ekleme")]
        public IActionResult SqlPostAjaksKisiler(string kisiname)
        {
            Kisiler kisi = new Kisiler();
            kisi.KisiName = kisiname;

            _context.Add(kisi);
            _context.SaveChanges();
            return Ok("true");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}