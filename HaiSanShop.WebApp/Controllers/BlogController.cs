using HaiSanSamSon.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace HaiSanShop.WebApp.Controllers
{
    public class BlogController : Controller
    {
        private HaiSanHopDbContext db = null;
        public BlogController()
        {
            db = new HaiSanHopDbContext();
        }
        // GET: Blog
        public ActionResult Index(int? page)
        {
            var list = db.Blogs.Where(c => c.DaXoa == false && c.Hien == true).ToList();
            int pagesize = 10;
            int pagenumber = (page ?? 1);
            return View(list.ToPagedList(pagenumber,pagesize));
        }
        public ActionResult ViewBlog(int? Ma)
        {
            if(Ma== null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var blog = db.Blogs.SingleOrDefault(c => c.Ma == Ma);
            if(blog== null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }
        
    }
}