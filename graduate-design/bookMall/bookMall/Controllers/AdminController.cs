﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookMall.Models;

namespace bookMall.Controllers
{
    public class AdminController : Controller
    {
        BookStoreEntities3 db = new BookStoreEntities3();

        /*
            这个页面是实现 admin 功能的页面。实现对用户和对图书的 ** 增删查改 ** 功能。 
         */

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        // 查询所有的用户
        public ActionResult Select()
        {
            return View(db.userTable);
        }

        // 根据特定的条件进行查询用户
        [HttpPost]
        public ActionResult Select(string userName)
        {
            var a = db.userTable.Where(b => b.userName.Contains(userName) );
            return View(a);
        }


        
        // 修改 用户 页面
        public ActionResult Modify(string id)
        {
            var itRole = db.userTable.GroupBy(b => b.role).Select(c => c.FirstOrDefault());//在用户表里面查询角色信息
            ViewBag.role2 = new SelectList(itRole, "role", "role");//给角色下拉框赋值

            var info = db.userTable.Where(b => b.userName == id).FirstOrDefault();//根据传过来的 userName 来查询用户信息
            ViewBag.userName = id;
            ViewBag.passWord = info.passWord;
            ViewBag.role = info.role;
            return View();
        }

        [HttpPost]
        public ActionResult Modify(string userName, string passWord, string role)
        {
            var info = db.userTable.Where(b => b.userName == userName).FirstOrDefault();
            info.userName = userName;
            info.passWord = passWord;
            info.role = role;
            db.SaveChanges();
            return RedirectToAction("Select");
        }


        // 删除用户
        public ActionResult Delete(string id)
        {
            var deleteInfo = db.userTable.Where(b => b.userName == id).FirstOrDefault();
            ViewBag.userName = id;
            ViewBag.passWord = deleteInfo.passWord;
            ViewBag.role = deleteInfo.role;

            return View();
        }

        [HttpPost]
        public ActionResult Delete(string id,string Others)
        {
            var deleteUser = db.userTable.Where(b => b.userName == id).FirstOrDefault();
            db.userTable.Remove(deleteUser);
            db.SaveChanges();
            return RedirectToAction("Select");
        }

        // 增加用户
        public ActionResult AddUser()
        {
            // 给角色下拉框添加内容
            var itRole = db.userTable.GroupBy(b => b.role).Select(c => c.FirstOrDefault());
            ViewBag.role = new SelectList(itRole, "role", "role");
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(string userName,string passWord, string role )
        {
            userTable addUser = new userTable() { userName = userName,  passWord= passWord, role = role };
            db.userTable.Add(addUser);
            db.SaveChanges();

            return RedirectToAction("Select");
        }


        // 新增图书
        public ActionResult AddBooks() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBooks(string bookTitle, int bookPrice, string bookAuthor, string bookPublishing,string bookPublishingDate, FormCollection form)
        {

            string filename;

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
                string target = Server.MapPath("/") + ("/Content/Images/");//取得目标文件夹的路径
                 filename = file.FileName;//取得文件名字
                 string path = target + filename;//获取存储的目标地址
                ViewBag.url = path;
                file.SaveAs(path);
            }

            Books addBook = new Books() { BookTitle = bookTitle, Price = bookPrice, Authors = bookAuthor, PublishDate = bookPublishingDate, Publishing = bookPublishing,  BookCoverUrl = "/Content/Images/" + filename };
            db.Books.Add(addBook);
            db.SaveChanges();

            return RedirectToAction("manageBooks");

        }


        // 管理图书
        public ActionResult manageBooks()
        {

            var showBooks = db.Books;
            return View(showBooks);
        }

        // 删除图书
        public ActionResult delBooks(int id )
        {
            var deleteBook = db.Books.Where(b => b.BookId == id).FirstOrDefault();
            db.Books.Remove(deleteBook);
            db.SaveChanges();
            return RedirectToAction("manageBooks");
        }

        // 修改图书
        public ActionResult midifyBooks(int id) {

            var info = db.Books.Where(b => b.BookId == id).FirstOrDefault();//根据传过来的 书籍 id 来查询书籍信息
            ViewBag.bookId = id;
            ViewBag.bookTitle = info.BookTitle;
            ViewBag.bookPrice = info.Price;
            ViewBag.bookAuthor = info.Authors;
            ViewBag.bookPublishing = info.Publishing;
            ViewBag.bookPublishingDate = info.PublishDate;
            return View();
        }

        // 修改图书
        [HttpPost]
        public ActionResult midifyBooks(int id, string bookTitle, float bookPrice, string bookAuthor, string bookPublishing, string bookPublishingDate, FormCollection form)
        {
            string filename;

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
                string target = Server.MapPath("/") + ("/Content/Images/");//取得目标文件夹的路径
                filename = file.FileName;//取得文件名字
                string path = target + filename;//获取存储的目标地址
                ViewBag.url = path;
                file.SaveAs(path);
            }
           
            var info = db.Books.Where(b => b.BookId == id).FirstOrDefault();
            info.BookTitle = bookTitle;
            info.Price = (decimal)bookPrice;
            info.Authors = bookAuthor;
            info.BookCoverUrl = "/Content/Images/" + filename;
            info.Publishing = bookPublishing;
            info.PublishDate = bookPublishingDate;
            db.SaveChanges();
            return RedirectToAction("manageBooks");
        }



        // 生成一个管理面板
        public ActionResult managePanel() {
            return View();
        }
    }
}
