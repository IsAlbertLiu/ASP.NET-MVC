using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class aController : Controller
    {
        //
        // GET: /a/
        aEntities db = new aEntities();
        public ActionResult Index()
        {
            return View();
        }
      
        // 查询
        public ActionResult cx()
        {
            var a = db.s.GroupBy(b => b.xy).Select(c => c.FirstOrDefault());
            // 给下拉列表赋值
            ViewBag.xy = new SelectList(a, "xy", "xy");
            return View(db.s);
        }

        // 按照指定的条件进行查询，所以是一个 POST 请求
        [HttpPost]
        public ActionResult cx(string xh,string xm,string xy)//这里的三个参数就是三个页面的三个控件的名称
        {
            var a11 = db.s.GroupBy(b => b.xy).Select(c => c.FirstOrDefault());//在学生表中查询去重的学院信息
            ViewBag.xy = new SelectList(a11, "xy", "xy");//给学院下拉框赋值
           
            if (xy == "")//下拉框的第一项显示的值是全部，但是存的值是为空字符串，xy1匹配的是存的值，而不是显示的值
            {
                var a = db.s.Where(b => b.name.Contains(xm) && b.sno.Contains(xh));//如果学院为全部，相当于没有学院这个查询条件
                return View(a);
            }
            else 
            {
                var a1 = db.s.Where(b => b.name.Contains(xm) && b.sno.Contains(xh) && b.xy==xy);
                return View(a1);
            }
          
        }


        // 修改，只需要一个 学号 作为参数
        public ActionResult xg(string id)
        {
            var a1 = db.s.GroupBy(b => b.xy).Select(c => c.FirstOrDefault());//在学生表中查询去重的学院信息
            ViewBag.xy2 = new SelectList(a1, "xy", "xy");//给学院下拉框赋值



            var a2 = db.s.GroupBy(b => b.zy).Select(c => c.FirstOrDefault());
            ViewBag.zy2 = new SelectList(a2, "zy", "zy");//给专业下拉框赋值
            var a3 = db.s.GroupBy(b => b.sex).Select(c => c.FirstOrDefault());
            ViewBag.xb2 = new SelectList(a3, "sex", "sex");//给性别下拉框赋值


            var a = db.s.Where(b => b.sno == id).FirstOrDefault();//根据传过来的id来查询学生信息

            ViewBag.xh = id;
            ViewBag.xm = a.name;
            ViewBag.xb = a.sex;
          ViewBag.xy1 = a.xy;
           ViewBag.zy1 = a.zy;
            return View();
        }

        // 修改的时候，会进行大量的数据传递，所以是一个有很多的参数的 POST 请求
        [HttpPost]
        public ActionResult xg(string id,string xm,string xb,string xy1,string zy1)
        {
            var a = db.s.Where(b => b.sno == id).FirstOrDefault();
            a.name = xm;
            a.sex = xb;
            a.xy = xy1;
            a.zy = zy1;
            db.SaveChanges();
            return RedirectToAction("cx");
        }

        // 删除，也只需要一个 学号 作为参数
        public ActionResult sc(string id)
        {
            var a = db.s.Where(b => b.sno == id).FirstOrDefault();
            ViewBag.xh = id;
            ViewBag.xm = a.name;
            ViewBag.xb = a.sex;
            ViewBag.xy1 = a.xy;
            ViewBag.zy1 = a.zy;
            return View();
        }

        // 删除的 POST 请求，此处的a1,是为了避免报错，才刻意加上去的。
       [HttpPost]
        public ActionResult sc(string id,string a1)
        {
            var a = db.s.Where(b => b.sno == id).FirstOrDefault();
            db.s.Remove(a);
            db.SaveChanges();
            return RedirectToAction("cx");
        }


        // 添加，添加学生
        public ActionResult tj()
       {
          
           var a = db.s.GroupBy(b => b.xy).Select(c => c.FirstOrDefault());
           ViewBag.xy1 = new SelectList(a, "xy", "xy");
           var a1 = db.s.GroupBy(b => b.zy).Select(c => c.FirstOrDefault());
           ViewBag.zy1 = new SelectList(a1, "zy", "zy");
           var a2 = db.s.GroupBy(b => b.sex).Select(c => c.FirstOrDefault());
           ViewBag.xb = new SelectList(a2, "sex", "sex");
           return View();
         
       }

        // 添加学生的 POST 请求
        [HttpPost]
        public ActionResult tj(string xh, string xm, string xb, string xy1)
        {
            s a = new s() { sno = xh, name = xm, sex = xb, xy = xy1 };
            db.s.Add(a);
            db.SaveChanges();

            return RedirectToAction("cx");
        }
    }
}
