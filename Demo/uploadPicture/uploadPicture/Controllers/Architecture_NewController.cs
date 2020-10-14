using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace uploadPicture.Controllers
{
    public class Architecture_NewController : Controller
    {
        //
        // GET: /Architecture_New/

        public ActionResult Index()
        {
            return View();
        }

     [HttpPost]
        public Boolean NewSave()
        {
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase File = files["File"];
            string FileName = File.FileName; //上传的原文件名
            string guid="";
            if (FileName != null && FileName != "")
            {
                string FileType = FileName.Substring(FileName.LastIndexOf(".") + 1); //得到文件的后缀名
                guid = System.Guid.NewGuid().ToString() + "." + FileType; //得到重命名的文件名
                File.SaveAs(Server.MapPath("/Upload/") + guid); //保存操作
 
            }
            return true;
        }
    }
}
