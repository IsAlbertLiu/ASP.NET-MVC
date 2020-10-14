using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace uploadPicture.Controllers
{
    public class Default1Controller : Controller
    {
        //
        // GET: /Default1/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public bool UploadFiles()
        {
            // 文件数为0证明上传不成功
            if (Request.Files.Count == 0)
            {
                throw new Exception("请选择上传文件！");
            }

            string uploadPath = Server.MapPath("../UploadFiles/");

            // 如果UploadFiles文件夹不存在则先创建
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            // 保存文件到UploadFiles文件夹
            for (int i = 0; i < Request.Files.Count; ++i)
            {
                HttpPostedFileBase file = Request.Files[i];
                // 文件名为空证明没有选择上传文件
                if (file.FileName == "")
                {
                    return false;
                }

                string filePath = uploadPath + Path.GetFileName(file.FileName);
                string fileName = file.FileName;

                // 检查上传文件的类型是否合法
                string fileExtension = Path.GetExtension(filePath).ToLower();
                string fileFilter = ConfigurationManager.AppSettings["FileFilter"];
                if (fileFilter.IndexOf(fileExtension) <= -1)
                {
                    Response.Write("对不起！请上传图片！！");
                    return false;
                }

                // 如果服务器上已经存在该文件则要修改文件名与其储存路径
                while (System.IO.File.Exists(filePath))
                {
                    Random rand = new Random();
                    fileName = rand.Next().ToString() + "-" + file.FileName;
                    filePath = uploadPath + Path.GetFileName(fileName);
                }
                // 把文件的存储路径保存起来
                // 保存文件到服务器
                file.SaveAs(filePath);
            }

            return true;
        }

       
    }
}
