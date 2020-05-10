using HaiSanSamSon.Data.EF;
using HaiSanShop.Application.Public;
using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaiSanShop.WebApp.Controllers
{
    
    public class GioHangController : Controller
    {
        private readonly HaiSanHopDbContext db = null;
        public GioHangController()
        {
            db = new HaiSanHopDbContext();
        }
        // GET: GioHang
        
        public List<ItemGioHang> LayGioHang()
        {
            List<ItemGioHang> lstGioHang = Session["GioHang"] as List<ItemGioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<ItemGioHang>();
                Session["GioHang"] = lstGioHang;
                return lstGioHang;
            }
            return lstGioHang;
        }
        public decimal TongTien()
        {
            List<ItemGioHang> lstgiohang = LayGioHang();
            if (lstgiohang == null)
            {
                return 0;
            }

            return lstgiohang.Sum(c => c.ThanhTien);
        }
        public double TongSL()
        {
            List<ItemGioHang> lstgiohang = LayGioHang();
            if (lstgiohang == null)
            {
                return 0;
            }

            return lstgiohang.Sum(c => c.SoLuong);
        }
        public ActionResult ThemGioHang(int MaSP, string strURL)
        {
            // kiểm tra sự tồn tịa của sản phầm
            SanPham sp = db.SanPhams.Single(c => c.MaSP == MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            // Lấy giỏ hàng
            List<ItemGioHang> lstgiohang = LayGioHang();
            //TH sp đã tồn tịa trong giỏ hàng
            ItemGioHang spcheck = lstgiohang.SingleOrDefault(c => c.MaSP == MaSP);
            if (spcheck != null)
            {
                //kiểm tra lượng hàng tồn tại trong kho
                if (spcheck.SoLuong > sp.SoLuongTon)
                {
                    return View("ThongBao");
                }
                spcheck.SoLuong++;
                spcheck.ThanhTien = spcheck.SoLuong * spcheck.DonGia;
                return Redirect(strURL);
            }


            ItemGioHang spmoi = new ItemGioHang(MaSP);
            if (spmoi.SoLuong > sp.SoLuongTon)
            {
                return View("ThongBao");
            }
            lstgiohang.Add(spmoi);

            if (TongSL() == 0)
            {
                ViewBag.SoLuong = 0;
                ViewBag.ThanhTien = 0;
            }

            ViewBag.SoLuong = TongSL();
            ViewBag.ThanhTien = TongTien();

            return Redirect(strURL);

        }
        public ActionResult XemGioHang()
        {
            List<ItemGioHang> lstgiohang = LayGioHang();
            return View(lstgiohang);
        }
        public ActionResult XoaGioHang(int MaSP)
        {
            if (Session["GioHang"] == null)
            {
                RedirectToAction("XemGioHang");
            }
            SanPham sp = db.SanPhams.SingleOrDefault(c => c.MaSP == MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<ItemGioHang> listgiohang = LayGioHang();
            ItemGioHang spcheck = listgiohang.SingleOrDefault(c => c.MaSP == MaSP);
            if (spcheck == null)
            {
                return RedirectToAction("XemGiohang");
            }
            listgiohang.Remove(spcheck);
            return RedirectToAction("XemGioHang");
        }
        public ActionResult UpdateGioHang(ItemGioHang itemGH)
        {
            List<ItemGioHang> listgiohang = LayGioHang();

            SanPham spcheck = db.SanPhams.SingleOrDefault(c => c.MaSP == itemGH.MaSP);
            if (spcheck.SoLuongTon < itemGH.SoLuong)
            {
                return View("ThongBao");
            }

            ItemGioHang spupdate = listgiohang.Find(c => c.MaSP == itemGH.MaSP);
            spupdate.SoLuong = itemGH.SoLuong;
            spupdate.ThanhTien = spupdate.SoLuong * spupdate.DonGia;

            return RedirectToAction("XemGioHang");
        }
        public ActionResult DatHang(KhachHang kh)
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            KhachHang khachhang = new KhachHang();
           
            if (User.Identity.IsAuthenticated)
            {
                ThanhVien tv = Session["DangNhap"] as ThanhVien;
                khachhang.TenKH = tv.HoTen;
                khachhang.DiaChi = tv.DiaChi;
                khachhang.SoDienThoai = tv.SDT;
                khachhang.MaTV = tv.MaTV;
                db.KhachHangs.Add(khachhang);
                db.SaveChanges();
            }
            
            // them don dat hang
            DonDatHang ddh = new DonDatHang();
            ddh.NgayDat = DateTime.Now;
            ddh.DaGiao= false;
            ddh.DaThanhToan = false;
            ddh.UuDai = 0;
            ddh.DaHuy = false;
            ddh.DaXoa = false;
            ddh.MaKH = khachhang.MaKH;
            db.dondathangs.Add(ddh);
            db.SaveChanges();

            // them chi tiet don dat hang
            List<ItemGioHang> lst = LayGioHang();
            foreach (var item in lst)
            {
                ChiTietDonDatHang detail = new ChiTietDonDatHang();
                detail.MaDDH = ddh.MaDDH;
                detail.MaSP = item.MaSP;
                detail.TenSP = item.TenSP;
                detail.DonGia = item.DonGia;
                detail.SoLuong = item.SoLuong;
                db.chitietdondathangs.Add(detail);
            }
            db.SaveChanges();
            Session["GioHang"] = null;
            return RedirectToAction("DatHangx", "GioHang",new{MaDDH = ddh.MaDDH});
        }
    
    [HttpGet]
        public ActionResult DatHangx(int? MaDDH)
        {
            if(MaDDH== null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var ddh = db.dondathangs.SingleOrDefault(c => c.MaDDH == MaDDH);
            if(ddh == null)
            {
                return HttpNotFound();
            }

            return View(ddh);
        }


    }
}