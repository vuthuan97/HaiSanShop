using HaiSanSamSon.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaiSanShop.WebApp.Controllers
{
    public class TestController : Controller
    {
        private HaiSanHopDbContext db = null;
        public TestController()
        {
            db = new HaiSanHopDbContext();
        }
        // GET: Test
        public ActionResult Index()
        {
            var lst = db.SanPhams.ToList();
            ViewBag.lst = lst;
            return View();
        }
    }
}