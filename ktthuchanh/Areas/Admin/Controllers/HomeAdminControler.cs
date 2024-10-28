using Azure;
using ktthuchanh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace ktthuchanh.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminControler : Controller
    {
        QlxemayContext db = new QlxemayContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listxe = db.Xemays.AsNoTracking().OrderBy(x => x.Tenxe);
            PagedList<Xemay> list = new PagedList<Xemay>(listxe, pageNumber, pageSize);
            return View(list);
        }
        [Route("themsanpham")]
        [HttpGet]
        public IActionResult ThemSanPham()
        {
            return View();
        }
        [Route("themsanpham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPham(Xemay xemay)
        {
            if (ModelState.IsValid)
            {
                db.Xemays.Add(xemay);
                db.SaveChanges();
                return RedirectToAction("danhmucsanpham");
            }
            return View(xemay);
        }

        private IActionResult RedirectToAction(string v)
        {
            throw new NotImplementedException();
        }
        [Route("suasanpham")]
        [HttpGet]
        public IActionResult SuaSanPham(string idxe)
        {
            var sanpham = db.Xemays.Find(idxe);
            return View();
        }
        [Route("suasanpham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(Xemay xemay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(xemay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("danhmucsanpham");
            }
            return View(xemay);
        }
        [Route("xoasanpham")]
        [HttpGet]
        public IActionResult XoaSanPham(string idxe)
        {
            var sanpham = db.Xemays.Where(x => x.Idxe == idxe).ToList();
            if(sanpham.Count()>0)
            {
                TempData["Message"] = "khong xoa duoc san pham nay";
                return RedirectToAction("danhmucsanpham");
            }
            db.Remove(db.Xemays.Find(idxe));
            db.SaveChanges();
            TempData["Message"] = "da xoa san pham";    
            return RedirectToAction("danhmucsanpham");
        }
    }
}

