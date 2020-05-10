using HaiSanSamSon.Data.EF;
using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace HaiSanShop.WebApp.Controllers
{
    public class QLBlogController : Controller
    {
        private readonly HaiSanHopDbContext db = null;
        public QLBlogController()
        {
            db = new HaiSanHopDbContext();
        }
        // GET: QLBlog
        public ActionResult Index(int? page)
        {
            int pagesize = 10;
            int pagenumber = (page ?? 1);
            var list = db.Blogs.ToList();
            return View(list.ToPagedList(pagenumber,pagesize));
        }
        [HttpGet]
        public ActionResult CreateBlog()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateBlog(Blog b, HttpPostedFileBase HinhAnh)
        {

            if (HinhAnh != null)
            {
                if (HinhAnh.ContentLength > 0)
                {
                    if (HinhAnh.ContentType != "image/jpeg" && HinhAnh.ContentType != "image/png" && HinhAnh.ContentType != "image/jfif" && HinhAnh.ContentType != "image/jpg")
                    {
                        ViewBag.thongbaoUpload = "Định dạng hình ảnh không hợp lệ , vui lòng kiểm tra lại";

                    }
                    else
                    {
                        // kiểm tra hình ảnh đã tồn tại chưa
                        var filename = Path.GetFileName(HinhAnh.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/ImageBlog"), filename);
                        if (System.IO.File.Exists(path))
                        {
                            ViewBag.thongbaoUpload = "Hình ảnh  đã tồn tại, hãy chọn ảnh khác";

                        }
                        else HinhAnh.SaveAs(path);
                        b.AnhMinhHoa = filename;

                    }
                }

            }
            if (ModelState.IsValid)
            {
                b.NgayTao = DateTime.Now;
                db.Blogs.Add(b);

                db.SaveChanges();
                return RedirectToAction("Index");

            }

            else
            {
                ViewBag.thongbao = "Tạo Blog Thất bại";
                return View();
            }
        }
        [HttpPost]
        public ActionResult XoaBlog(int MaBlog)
        {
            bool result = false;
            var blog = db.Blogs.SingleOrDefault(c => c.Ma == MaBlog);
            if (blog != null)
            {
                db.Blogs.Remove(blog);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult SuaBlog(int? MaBlog)
        {
            if (MaBlog == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var blog = db.Blogs.SingleOrDefault(c => c.Ma == MaBlog);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaBlog(Blog bl, HttpPostedFileBase HinhAnh)
        {
            var blog = db.Blogs.SingleOrDefault(c => c.Ma == bl.Ma);

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
                        blog.AnhMinhHoa = filename;

                    }
                }

            }
            
            if (ModelState.IsValid)
            {
                blog.TieuDe = bl.TieuDe;
                blog.VanTat = bl.VanTat;
                blog.Hien = bl.Hien;
                blog.DaXoa = bl.DaXoa;
               
                if (db.SaveChanges() > 0)
                {
                   
                    return RedirectToAction("Index");
                }

            }
            else
            {
                ViewBag.thongbao = "Dữ Liệu Update không hợp lệ";
                return View(bl);
            }



            return View(bl);
        }
    }
}