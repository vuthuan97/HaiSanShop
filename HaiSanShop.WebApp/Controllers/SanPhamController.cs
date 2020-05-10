using HaiSanSamSon.Data.EF;
using HaiSanShop.Application.Public;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HaiSanShop.WebApp.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly SanPhamPublic db = null;
        public SanPhamController()
        {
            db = new SanPhamPublic();
        }
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult SanPhamHomePartial()
        {

            return PartialView();
        }
        public ActionResult DanhMuc(int? MaLoai, int? MaDM, int? page)
        {
            if(MaLoai==null || MaDM == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var list = db.GetListDMAndLoai(MaLoai, MaDM);
            if (list == null)
            {
                return HttpNotFound();
            }
            int pagesize = 6;
            int pagenumber = (page ?? 1);
            ViewBag.maloai = MaLoai;
            ViewBag.madm = MaDM;
            ViewBag.tenloai = db.gettenloai(MaDM);
            return View(list.ToPagedList(pagenumber,pagesize));
        }
        public ActionResult ChiTiet(int? MaSP)
        {
            if (MaSP == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (db.getDetail(MaSP) == null)
            {
                return HttpNotFound();

            }
            return View(db.getDetail(MaSP));
        }
        [HttpGet]
        public ActionResult Search(string keyword, int? page)
        {
            if(Request.HttpMethod != "GET")
            {
                page = 1;
            }
            int pagesize = 9;
            int pagenumber = (page ?? 1);
            ViewBag.key = keyword;
            return View(db.Search(keyword).ToPagedList(pagenumber,pagesize));
        }
        [HttpPost]
        public ActionResult Search(string keyword, FormCollection f)
        {
            
            return View(db.Search(keyword));
        }

    }
}