using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookMall.Models;

namespace bookMall.Controllers
{
    public class AdminController : Controller
    {
        BookStoreEntities1 db = new BookStoreEntities1();

        /*
            这个页面是实现 admin 功能的页面。实现对用户和对图书的 ** 增删查改 ** 功能。 
         */


        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        // 查询
        public ActionResult Select()
        {
            //var a = db.userTable.GroupBy(b => b.).Select(c => c.FirstOrDefault());
            //return View(db.userTable);
            return View(db.userTable);
        }

        [HttpPost]
        public ActionResult Select(string userName)
        {
            var a = db.userTable.Where(b => b.userName.Contains(userName) );//如果查询的用户姓名包含，就返回该学生
            return View(a);
        }


        
        // 修改页面
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
            //ViewBag.userName = id;

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
    }
}
