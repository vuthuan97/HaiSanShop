using HaiSanSamSon.Data.EF;
using HaiSanShop.Application.Public;
using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.IO;

namespace HaiSanShop.WebApp.Controllers
{
    //[Authorize(Roles = "QLSanPham,QLNhapHang")]
    
    public class QLSanPhamController : Controller
    {
        private readonly HaiSanHopDbContext db = null;
        public QLSanPhamController()
        {
            db = new HaiSanHopDbContext();
        }

        //show ds sản phẩm
        [Authorize(Roles = "QLSanPham")]
        public ActionResult Index(int? page)
        {
            var listsp = db.SanPhams.Where(c => c.DaXoa == false).ToList();
            int pagesize = 10;
            int pagenumber = (page ?? 1);
                return View(listsp.OrderByDescending(c=>c.MaSP).ToPagedList(pagenumber,pagesize));
            
        }
        [Authorize(Roles = "QLSanPham")]
        [HttpGet]
        public ActionResult ThemMoi()
        {
            ViewBag.MaDM = db.DanhMucSanPhams.ToList();
            ViewBag.MaLoaiSP = db.LoaiSanPhams.ToList();
            return View();
        }
        [Authorize(Roles = "QLSanPham")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(SanPham sp , HttpPostedFileBase HinhAnh)
        {

            ViewBag.MaDM = db.DanhMucSanPhams.OrderBy(c => c.TenDanhMuc);
            ViewBag.MaLoaiSP = db.LoaiSanPhams.OrderBy(c => c.TenLoai);
            
            try
            {

                if (HinhAnh != null)
                {
                    if (HinhAnh.ContentLength > 0)
                    {
                        if (HinhAnh.ContentType != "image/jpeg" && HinhAnh.ContentType != "image/png" && HinhAnh.ContentType != "image/jfif" && HinhAnh.ContentType != "image/jpg")
                        {
                            ViewBag.ThongBaoUpload = "Định dạng hình ảnh không hợp lệ , vui lòng kiểm tra lại";
                            
                        }
                        else
                        {
                            // kiểm tra hình ảnh đã tồn tại chưa
                            var filename = Path.GetFileName(HinhAnh.FileName);
                            var path = Path.Combine(Server.MapPath("~/Content/ImageSanPham"), filename);
                            if (System.IO.File.Exists(path))
                            {
                                ViewBag.ThonBaoUpload = "Hình ảnh  đã tồn tại, hãy chọn ảnh khác";
                               
                            }
                            else HinhAnh.SaveAs(path);
                            sp.HinhAnh = filename;

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ViewBag.ThongBao = "Lỗi Thực Thi " + ex.Message;
            }
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return RedirectToAction("Index", "QLSanPham");
            }
            else
            {
                ViewBag.ThongBao = "Thêm Mới Sản Phẩm Thất Bại , Vui Lòng Kiểm Tra Lại";
                return View();
            }

           
        }
        [Authorize(Roles = "QLSanPham")]
        [HttpGet]
        public ActionResult SuaSanPham(int? MaSP)
        {
            if (MaSP == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            SanPham sp = db.SanPhams.SingleOrDefault(c => c.MaSP == MaSP && c.DaXoa == false);
            if (sp == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSanPhams.OrderBy(c => c.TenLoai), "MaLoaiSP", "TenLoai", sp.MaLoaiSP);
            ViewBag.MaDM = new SelectList(db.DanhMucSanPhams.OrderBy(c => c.TenDanhMuc), "MaDM", "TenDanhMuc", sp.MaDM);
            

            return View(sp);
        }
        [Authorize(Roles = "QLSanPham")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaSanPham(SanPham sp, HttpPostedFileBase HinhAnh)
        {
            ViewBag.MaDM = db.DanhMucSanPhams.OrderBy(c => c.TenDanhMuc);
             ViewBag.MaLoaiSP = db.LoaiSanPhams.OrderBy(c => c.TenLoai);
            if (HinhAnh != null)
            {
                if (HinhAnh.ContentLength > 0)
                {
                    if (HinhAnh.ContentType != "image/jpeg" && HinhAnh.ContentType != "image/png" && HinhAnh.ContentType != "image/jfif" && HinhAnh.ContentType != "image/jpg")
                    {
                        ViewBag.ThongBaoUpload = "Định dạng hình ảnh không hợp lệ , vui lòng kiểm tra lại";

                    }
                    else
                    {
                        // kiểm tra hình ảnh đã tồn tại chưa
                        var filename = Path.GetFileName(HinhAnh.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/ImageSanPham"), filename);
                        if (System.IO.File.Exists(path))
                        {
                            ViewBag.ThonBaoUpload = "Hình ảnh  đã tồn tại, hãy chọn ảnh khác";

                        }
                        else HinhAnh.SaveAs(path);
                        sp.HinhAnh = filename;

                    }
                }

            }

            if (ModelState.IsValid)
            {
                    db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
                    if (db.SaveChanges() > 0)
                    {
                        TempData["msg"] = "Update thành công";
                        return RedirectToAction("Index");
                    }

            }
            else
            {
                ViewBag.ThongBao = "Dữ Liệu Update không hợp lệ";
                return View(sp);
            }

            return View(sp);
            
        }
        [Authorize(Roles = "QLSanPham")]
        [HttpPost]
        public JsonResult XoaSanPham(int? MaSP)
        {
            bool result = false;
            SanPham sp = db.SanPhams.SingleOrDefault(c => c.MaSP == MaSP && c.DaXoa == false);
            if (sp != null)
            {
                sp.DaXoa = true;
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //Nhập Sản Phẩm
        [Authorize(Roles = "QLNhapHang")]
        public ActionResult HangHet()
        {
            var lstsp = db.SanPhams.Where(c => c.SoLuongTon <= 5);
            return View(lstsp.ToList());
           
        }
        [Authorize(Roles = "QLNhapHang")]
        [HttpGet]
        public ActionResult NhapHangDon(int? MaSP)
        {
            if (MaSP == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            SanPham sp = db.SanPhams.SingleOrDefault(c => c.MaSP == MaSP);
            if (sp == null)
            {
                HttpNotFound();
            }

            return View(sp);

        }
        [Authorize(Roles = "QLNhapHang")]
        [HttpPost]
        public ActionResult NhapHangDon(PhieuNhap pn ,ChiTietPhieuNhap chitiet)
        {
            try
            {
                pn.DaXoa = false;
                db.phieunhaps.Add(pn);
                db.SaveChanges();

                SanPham sp = db.SanPhams.SingleOrDefault(c => c.MaSP == chitiet.MaSP);
                sp.SoLuongTon += chitiet.SoLuongNhap;
                chitiet.MaPN = pn.MaPN;
                db.chitietphieunhaps.Add(chitiet);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("HangHet", "QLSanPham");

        }
        [Authorize(Roles = "QLNhapHang")]
        [HttpGet]
        public ActionResult NhapNhieuSP()
        {
            ViewBag.MaDM = new SelectList(db.DanhMucSanPhams.OrderBy(c => c.MaDM), "MaDM", "TenDanhMuc");
            return View();
        }
        [Authorize(Roles = "QLNhapHang")]
        [HttpPost]
        public ActionResult NhapNhieuSP(PhieuNhap pn , IEnumerable<ChiTietPhieuNhap> lstpn, FormCollection f)
        {
            ViewBag.MaDM = new SelectList(db.DanhMucSanPhams.OrderBy(c => c.MaDM), "MaDM", "TenDanhMuc");
            pn.DaXoa = false;

            db.phieunhaps.Add(pn);
            db.SaveChanges();
            SanPham sp;
            foreach (var item in lstpn)
            {
                sp = db.SanPhams.SingleOrDefault(c => c.MaSP == item.MaSP);
                sp.SoLuongTon += item.SoLuongNhap;
                item.MaPN = pn.MaPN;
            }
            db.chitietphieunhaps.AddRange(lstpn);
            db.SaveChanges();
            return View();
            
        }
        public ActionResult loadSPChoPatial(int? MaDM)
        {
            var lst = db.SanPhams.Where(c => c.MaDM == MaDM).ToList();
            ViewBag.lstsp = new SelectList(lst, "MaSP", "TenSP");
            return PartialView("dropdowlistsp");
        }
       

    }
}