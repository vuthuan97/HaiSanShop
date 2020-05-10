using HaiSanSamSon.Data.EF;
using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaiSanShop.WebApp.Views.QLSanPham
{
    [Authorize(Roles = "QLDonDatHang")]
    public class QLDonHangController : Controller
    {
        private readonly HaiSanHopDbContext db = null;
        public QLDonHangController()
        {
            db = new HaiSanHopDbContext();
        }
        // GET: QLDonHang
        //DON HANG MOI
        public ActionResult Index()
        {
            var lstddh = db.dondathangs.Where(c => c.DaThanhToan == false && c.DaGiao == false).ToList();
            return View(lstddh);
           
        }
        public ActionResult ChuaNhanHang()
        {
            var lstddh = db.dondathangs.Where(c => c.DaThanhToan == true && c.DaGiao == false).ToList(); ;
            return View(lstddh);

        }


        public ActionResult HoanTat()
        {
            var lstddh = db.dondathangs.Where(c => c.DaThanhToan == true && c.DaGiao == true).ToList();
            return View(lstddh);
        }
        public ActionResult DuyetDon(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            DonDatHang ddh = db.dondathangs.SingleOrDefault(c => c.MaDDH == id);
            if (ddh == null)
            {
                return HttpNotFound();
            }

            ViewBag.lstchitiet = db.chitietdondathangs.Where(c => c.MaDDH == ddh.MaDDH).ToList(); 
            return View(ddh);
        }
        [HttpPost]
        public ActionResult DuyetDon(DonDatHang ddh)
        {
            DonDatHang ddhupdate = db.dondathangs.SingleOrDefault(c => c.MaDDH == ddh.MaDDH);
            ddhupdate.DaGiao = ddh.DaGiao;
            ddhupdate.DaThanhToan = ddh.DaThanhToan;
            ddhupdate.NgayGiao = DateTime.Now;
            db.SaveChanges();
            ViewBag.lstchitiet = db.chitietdondathangs.Where(c => c.MaDDH == ddh.MaDDH).ToList();
            return View(ddhupdate);
        }
    }
}