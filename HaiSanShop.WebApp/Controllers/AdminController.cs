using HaiSanSamSon.Data.EF;
using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HaiSanShop.WebApp.Controllers
{
   
    public class AdminController : Controller
    {
        private readonly HaiSanHopDbContext db = null;
        public AdminController()
        {
            db = new HaiSanHopDbContext();
        }
        // GET: Admin

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.truycap = HttpContext.Application["PageView"];
                ViewBag.online = HttpContext.Application["Online"];
                ViewBag.tongtien = thongkedoanhthu();
                return View();
            }
            else {
               return RedirectToAction("LoginAdmin");
            } 

        }
        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(ThanhVien tv)
        {
            using (HaiSanHopDbContext db = new HaiSanHopDbContext())
            {
                string tk = tv.TaiKhoan;
                string mk = tv.MatKhau;
                var tvlogin = db.thanhviens.SingleOrDefault(c => c.TaiKhoan == tk && c.MatKhau == mk);
                
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

                        PhanQuyen(tvlogin.TaiKhoan.ToString(), Quyen);
                        Session["dangnhap"] = tvlogin;
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        ViewBag.thongbao = "Bạn không được quyền truy cập trang web này";
                        return View();
                    }
                }
                else
                {
                    ViewBag.thongbao = "Tài Khoản hoặc mật khẩu không chính xác";
                    return View();

                }
            }
        }
        public void PhanQuyen(string tk, string quyen)
        {
            FormsAuthentication.Initialize();
            var ticket = new FormsAuthenticationTicket(1,
                tk, DateTime.Now, DateTime.Now.AddHours(3), false, quyen, FormsAuthentication.FormsCookiePath);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
            Response.Cookies.Add(cookie);
        }
        public ActionResult DangXuat()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        public ActionResult ThongKe()
        {
            return View();
        }
        public string thongkedoanhthu()
        {
            decimal tongdoanhthu = db.chitietdondathangs.Sum(c => c.SoLuong * c.DonGia);
            return tongdoanhthu.ToString("#,##");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(db!=null)
                {
                    db.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}