using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class bController : Controller
    {
        //
        // GET: /b/
        BookStoreEntities1 db = new BookStoreEntities1();
        public ActionResult Index()
        {
            var a = db.Books;
            return View(a);
        }

        // 买书
        public ActionResult ms(int id)
        {s
            var a = db.Books.Where(b => b.BookId == id).FirstOrDefault();
            ViewBag.id1 = id;
            ViewBag.id2 = id;
            ViewBag.mc = a.BookTitle;
            ViewBag.jc = a.Price;
            ViewBag.zz = a.Authors;
            return View();
        }

        // 买书的 POST 请求
        [HttpPost]
        public ActionResult ms(int id,int sl,string dz)
        {
            var a = new Orders() { BookId = id, Address = dz, Num = sl };
            db.Orders.Add(a);
            db.SaveChanges();
            return RedirectToAction("xq");
        }

        // 查询历史的订单，
        public ActionResult xq()
        {
            var a = db.Orders;
            return View(a);
        }

    }
}
