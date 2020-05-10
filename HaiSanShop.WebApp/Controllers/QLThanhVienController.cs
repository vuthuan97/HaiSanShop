using HaiSanSamSon.Data.EF;
using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaiSanShop.WebApp.Controllers
{
    //[Authorize(Roles = "QLQuyen,QLThanhVien")]
    public class QLThanhVienController : Controller
    {
        private readonly HaiSanHopDbContext db = null;
        public QLThanhVienController()
        {
            db = new HaiSanHopDbContext();
        }
        // GET: QLThanhVien
        [Authorize(Roles = "QLThanhVien")]
        public ActionResult Index()
        {
            var thanhvien = db.thanhviens.ToList();

            return View(thanhvien);
        }
        [Authorize(Roles = "QLThanhVien")]
        [HttpPost]
        public ActionResult SuaLoai(int? MaTV, int? MaLoaiTV)
        {
            bool result = false;
            if(MaTV==null || MaLoaiTV == null)
            {
                result = false;
            }
            var thanhvien = db.thanhviens.SingleOrDefault(c => c.MaTV == MaTV);
            if(thanhvien!=null)
            {
                thanhvien.MaLoaiTV = int.Parse(MaLoaiTV.ToString());
                db.SaveChanges();
                result = true;
            }
           
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles = "QLThanhVien")]
        [HttpPost]
        public ActionResult XoaTV(int MaTV)
        {
            bool result = false;
            var tv = db.thanhviens.SingleOrDefault(c => c.MaTV == MaTV);
            if (tv != null)
            {
                db.thanhviens.Remove(tv);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }




        [Authorize(Roles = "QLQuyen")]
        public ActionResult Quyen()
        {
            var lstquyen = db.quyens.ToList();
            return View(lstquyen);
            
        }
        [Authorize(Roles = "QLQuyen")]
        [HttpPost]
        public void ThemQ(Quyen q)
        {
            db.quyens.Add(q);
            db.SaveChanges();
        }
        [Authorize(Roles = "QLQuyen")]
        [HttpPost]
        public ActionResult XoaQuyen(string MaQ)
        {
            bool result = false;
            var quyen = db.quyens.SingleOrDefault(c => c.MaQuyen == MaQ);
            if (quyen != null)
            {
                db.quyens.Remove(quyen);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles = "QLQuyen")]
        [HttpPost]
        public ActionResult SuaQ(Quyen q)
        {
            bool result = false;
            db.Entry(q).State = System.Data.Entity.EntityState.Modified;
            if (db.SaveChanges() > 0)
            {
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        [Authorize(Roles = "QLQuyen")]
        public ActionResult PhanQuyen()
        {
            var lstltv = db.loaithanhviens.ToList();
           
            return PartialView(lstltv);
        }
        [Authorize(Roles = "QLQuyen")]
        [HttpGet]
        public ActionResult PhanQuyenTV(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var ltv = db.loaithanhviens.SingleOrDefault(c => c.MaLoaiTV == id);
            if (ltv == null)
            {
                return HttpNotFound();
            }
            //lấy ra ds quyền  và ds quyền của loại thành viên
            ViewBag.dsquyen = db.quyens.ToList();
            ViewBag.dsphanquyen = db.phanquyens.Where(c => c.MaLoaiTV == ltv.MaLoaiTV).ToList();
            return View(ltv);
        }
        [Authorize(Roles = "QLQuyen")]
        [HttpPost]
        public ActionResult PhanQuyenTV(int? MaLoaiTV, IEnumerable<PhanQuyen> pq)
        {
            var lstdaphanquyen = db.phanquyens.Where(c => c.MaLoaiTV == MaLoaiTV).ToList();
            if (lstdaphanquyen.Count() != 0)
            {
                db.phanquyens.RemoveRange(lstdaphanquyen);
                db.SaveChanges();
            }
            if (pq != null)
            {
                foreach (var item in pq)
                {
                    item.MaLoaiTV = int.Parse(MaLoaiTV.ToString());
                    db.phanquyens.Add(item);
                }
                db.SaveChanges();
            }
            var ltv = db.loaithanhviens.SingleOrDefault(c => c.MaLoaiTV == MaLoaiTV);
            ViewBag.dsquyen = db.quyens.ToList();
            ViewBag.dsphanquyen = db.phanquyens.Where(c => c.MaLoaiTV == MaLoaiTV).ToList();
            return View(ltv);
        }
    }
}