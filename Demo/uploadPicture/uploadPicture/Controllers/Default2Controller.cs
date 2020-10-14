using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace uploadPicture.Controllers
{
    public class Default2Controller : Controller
    {
        //
        // GET: /Default2/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Upload(FormCollection form)
        {
            if (Request.Files.Count == 0)
            {
                //Request.Files.Count 文件数为0上传不成功
                return View();
            }
            var file = Request.Files[0];
            if (file.ContentLength == 0)
            {
                //文件大小大（以字节为单位）为0时，做一些操作
                return View();
            }
            else
            {
                //文件大小不为0
                file = Request.Files[0];
                //保存成自己的文件全路径,newfile就是你上传后保存的文件,
                //服务器上的UpLoadFile文件夹必须有读写权限
                string target = Server.MapPath("/") + ("/Mock/Learning/");//取得目标文件夹的路径
                string filename = file.FileName;//取得文件名字
                string path = target + filename;//获取存储的目标地址
                ViewBag.url = path;
                file.SaveAs(path);
            }
            return View();
        }






    }
}
