using HaiSanSamSon.Data.EF;
using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaiSanShop.WebApp.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly HaiSanHopDbContext db= null;
        public KhachHangController()
        {
            db = new HaiSanHopDbContext();
        }
        // GET: KhachHang
        public ActionResult ThongTin(int? MaKH)
        {
            if (MaKH == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var tv = db.thanhviens.SingleOrDefault(c => c.MaTV == MaKH);
            if(tv== null)
            {
                return HttpNotFound();
            }
            return View(tv);
        }
        public ActionResult SuaTT(ThanhVien  tv)
        {
            string result = "Sửa Thất Bại";
            var tvs = db.thanhviens.SingleOrDefault(c => c.MaTV == tv.MaTV);
            if(tvs!=null)
            {
                tvs.HoTen = tv.HoTen;
                tvs.SDT = tv.SDT;
                tvs.DiaChi = tv.DiaChi;
                db.SaveChanges();
                    result = "Sửa thành Công";
                
                
            }
            
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        public ActionResult SuaMK(ThanhVien tv)
        {
            string result = "Sửa Thất Bại";
            var tvs = db.thanhviens.SingleOrDefault(c => c.MaTV == tv.MaTV);
            if (tvs != null)
            {
                tvs.MatKhau = tv.MatKhau;
                db.SaveChanges();
                result = "Sửa Thành Công";


            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}