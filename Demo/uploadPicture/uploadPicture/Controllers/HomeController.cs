using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace uploadPicture.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
         public ActionResult UploadImg()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadImg(int id)
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase f = Request.Files["file1"];
                f.SaveAs(@"D:\" + f.FileName);
            }
            return View();
        }

    }
}
