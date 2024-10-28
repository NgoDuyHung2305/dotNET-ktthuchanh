using ktthuchanh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;

namespace ktthuchanh.Controllers
{
    public class HomeController : Controller
    {
        QlxemayContext db = new QlxemayContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listxe = db.Xemays.AsNoTracking().OrderBy(x=>x.Tenxe);
            PagedList<Xemay> list = new PagedList<Xemay>(listxe, pageNumber, pageSize);
            return View(list);
        }
        public IActionResult XeTheoLoai(string loai)
        { 
            List<Xemay> listxe = db.Xemays.Where(x=>x.Loai == loai).OrderBy(x=>x.Tenxe).ToList();
            return View(listxe);
        }
        public IActionResult ChiTietXe(string idxe)
        {
            var xe = db.Xemays.SingleOrDefault(x => x.Idxe == idxe);
            return View(xe);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
