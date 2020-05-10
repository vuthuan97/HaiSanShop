using HaiSanSamSon.Data.EF;
using HaiSanShop.Application.Public;
using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HaiSanShop.WebApp.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly SanPhamPublic db= null;
        public HomeController()
        {
            db = new SanPhamPublic();
        }
        public ActionResult Index()
        {
            
            ViewBag.spmuoi = db.GetLoai(3, 3);

            ViewBag.spvo = db.GetLoai(4, 3);
            
            ViewBag.sptuoisong = db.GetLoai(2, 3);

            ViewBag.spdokho = db.GetLoai(1, 3);
            return View();
        }
        [ChildActionOnly]
        public ActionResult menutop()
        {
            var list = db.GetAllSP();
            return PartialView(list);
        }

        [HttpPost]
        public ActionResult DangNhap(ThanhVien tv)
        {
            using (HaiSanHopDbContext db = new HaiSanHopDbContext())
            {
                string tk = tv.TaiKhoan;
                string mk = tv.MatKhau;
                var tvlogin = db.thanhviens.SingleOrDefault(c => c.TaiKhoan == tk && c.MatKhau == mk);
                string result = "";
                if (tvlogin != null)
                {
                    IEnumerable<PhanQuyen> lstquyen = db.phanquyens.Where(c => c.MaLoaiTV == tvlogin.MaLoaiTV).ToList();
                    string Quyen = "";

                    if (lstquyen.Count() != 0)
                    {
                        foreach (var item in lstquyen)
                        {
                            var q = item.Quyens.MaQuyen.ToString();
                            Quyen += q + ",";
                        }
                        Quyen = Quyen.Substring(0, Quyen.Length - 1);


                    }
                    PhanQuyen(tvlogin.TaiKhoan.ToString(), Quyen);
                    Session["dangnhap"] = tvlogin;
                    
                    result = "true";
                }
                else
                {
                    result = "false";
                    
                }

                return Json(result, JsonRequestBehavior.AllowGet);
            }
                

        }
        public void PhanQuyen(string tk, string quyen)
        {
            FormsAuthentication.Initialize();
            var ticket = new FormsAuthenticationTicket(1,
                                             tk,//Tài Khoản Đăng Nhập
                                             DateTime.Now,
                                             DateTime.Now.AddHours(3),
                                             false,//cho luu lai lan dang nhap
                                             quyen,//quyen cua tk dang nhap
                                             FormsAuthentication.FormsCookiePath);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, 
                FormsAuthentication.Encrypt(ticket));
            if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
            Response.Cookies.Add(cookie);
        }
        public ActionResult DangXuat()
        {
            Session["DangNhap"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult DangKy()
        {
          
            return View();
        }
        
        [HttpPost]
        public ActionResult DangKy(ThanhVien tv)
        {
            using (HaiSanHopDbContext db = new HaiSanHopDbContext())
            {

                if (ModelState.IsValid)
                {
                    var user = db.thanhviens.SingleOrDefault(c => c.TaiKhoan == tv.TaiKhoan);
                    if(user!= null)
                    {
                        ViewBag.thongbao = "Tên Tài Khoản Đã Tồn Tại , Hãy Chọn Tên Khác";
                        Session["dangky"] = tv;
                        return View();
                    }

                    tv.MaLoaiTV = 4;
                    ViewBag.thongbao = "Đăng Ký Thành Viên Thành Công . Hãy Đăng Nhập Để Tiếp Tục Mua Hàng ";
                    db.thanhviens.Add(tv);
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.thongbao = "Thêm Thông Tin Thất Bại , Vui Lòng Kiểm Tra Lại";
                }

                return View();
            }
        }
        public ActionResult GioiThieu()
        {
            return View();
        }
        public ActionResult BangGia()
        {
            using (HaiSanHopDbContext db =new HaiSanHopDbContext())
            {
                var bg = db.BangGias.ToList();
                return View(bg);
            }
              

        }
        public ActionResult TrangPhanHoi()
        {
            return View();
        }
        public ActionResult contact()
        {
            return View();
        }
    }
}