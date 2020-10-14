using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookMall.Models;

namespace bookMall.Controllers
{
    public class BooksController : Controller
    {
        BookStoreEntities1 db = new BookStoreEntities1();

        //
        // GET: /Books/


        // 展示所有书籍
        public ActionResult Index()
        {
            var showBooks = db.Books;
            return View(showBooks);
        }

        // 买书
        public ActionResult buyBook(int id)
        {
            var book = db.Books.Where(b => b.BookId == id).FirstOrDefault();
            ViewBag.bookId = id;
            ViewBag.bookId1 = id;
            ViewBag.bookTitle = book.BookTitle;
            ViewBag.bookPrice = book.Price;
            ViewBag.bookAuthors = book.Authors;
            return View();
        }

        // 买书的 POST 请求
        [HttpPost]
        public ActionResult buyBook(int id, string address, int count)
        {
            var order = new Orders() { BookId = id, Address = address, Num = count };
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("historyOrders");
        }

        // 查询历史的订单，
        public ActionResult historyOrders()
        {
            //var user = Session["name"].ToString();
             // 当用户查看购物车的时候，判断用户是否登陆，如果没登陆，则不显示购物车页面
            if (Session["name"] == null)
            {
                return RedirectToAction("unLogging"); 
            }

            var a = db.Orders;
            return View(a);
        }
        // 没有用户登陆，
        public ActionResult unLogging()
        {
            return View();
        }
        public ActionResult deleteOrder(int id)
        {
            var delete = db.Orders.Where(b => b.OrderId == id).FirstOrDefault();
            ViewBag.OrderId = id;
            ViewBag.Address = delete.Address;
            ViewBag.BookId = delete.BookId;
            ViewBag.Num = delete.Num;
            return View();
        }

        [HttpPost]
        public ActionResult deleteOrder(int id, string Others)
        {
            var delOrder = db.Orders.Where(b => b.OrderId == id).FirstOrDefault();
            db.Orders.Remove(delOrder);
            db.SaveChanges();

            return RedirectToAction("historyOrders");
        }
    }
}
