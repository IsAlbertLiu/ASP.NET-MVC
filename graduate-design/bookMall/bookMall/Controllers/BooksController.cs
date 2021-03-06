﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookMall.Models;

namespace bookMall.Controllers
{
    public class BooksController : Controller
    {
        BookStoreEntities3 db = new BookStoreEntities3();

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
            // 判断用户是否登陆
            if (Session["name"] == null)
            {
                return RedirectToAction("unLogging", "Books");
            }
            else
            {
                var userName = Session["name"].ToString();
            }


            var book = db.Books.Where(b => b.BookId == id).FirstOrDefault();
            ViewBag.bookId = id;
            ViewBag.bookId1 = id;
            ViewBag.bookTitle = book.BookTitle;
            ViewBag.bookPrice = book.Price;
            ViewBag.bookAuthors = book.Authors;
            ViewBag.bookPublishing = book.Publishing;
            ViewBag.bookPublishDate = book.PublishDate;
            return View();
        }

        // 买书的 POST 请求
        [HttpPost]
        public ActionResult buyBook(int id, string address, int count)
        {
            var userName = "";
            // 判断用户是否登陆
            if (Session["name"] == null)
            {
                return RedirectToAction("unLogging", "Books");
            }
            else
            {
                 userName = Session["name"].ToString();
            }
            var order = new Orders() { BookId = id, Address = address, Num = count,userName = userName };
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("historyOrders");
        }

        // 查询历史的订单，
        public ActionResult historyOrders()
        {
            var userName = "";
            // 判断用户是否登陆
            if (Session["name"] == null)
            {
                return RedirectToAction("unLogging", "Books");
            }
            else
            {
                userName = Session["name"].ToString();
            }

            var a = db.Orders.Where(b => b.userName == userName);
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


        // 搜索图书
        public ActionResult srearchBooks()
        {
            return View();
        }

        // 发送搜索书籍的 POST 请求
        [HttpPost]
        public ActionResult srearchBooks(String bookTitle)
        {
            // 在跳转页面的时候 携带 要搜索图书的名称
            return RedirectToAction("resultOfSearchBooks", new { bookTitle = bookTitle });
        }

        // 显示搜索书籍的结果
        public ActionResult resultOfSearchBooks(string bookTitle)
        {
            var search = db.Books.Where(b => b.BookTitle.Contains(bookTitle));
            return View(search);
        }




    }
}
