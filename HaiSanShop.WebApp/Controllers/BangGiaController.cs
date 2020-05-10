using HaiSanSamSon.Data.EF;
using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaiSanShop.WebApp.Controllers
{
    public class BangGiaController : Controller
    {

        private readonly HaiSanHopDbContext db = null;
        public BangGiaController()
        {
            db = new HaiSanHopDbContext();
        }
        // GET: BangGia
        public ActionResult Index()
        {
            var list = db.BangGias.ToList();
            return View(list);
        }
        [HttpPost]
        public ActionResult SuaGia(int? Ma, int? Gia, string Ten)
        {
            bool result = false;
            if (Ma == null || Gia == null)
            {
                result = false;
            }
            var banggia = db.BangGias.SingleOrDefault(c => c.Ma == Ma);
            if (banggia != null)
            {
                banggia.Gia = int.Parse(Gia.ToString());
                banggia.TenSanPham = Ten;
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult XoaBangGia(int Ma)
        {
            bool result = false;
            var bg= db.BangGias.SingleOrDefault(c => c.Ma == Ma);
            if (bg != null)
            {
                db.BangGias.Remove(bg);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public void Them(BangGia bg )
        {
            db.BangGias.Add(bg);
            db.SaveChanges();
        }
    }
}