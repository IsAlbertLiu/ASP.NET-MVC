using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookMall.Models;

namespace bookMall.Controllers
{
    public class loginController : Controller
    {
        //
        // GET: /login/

        BookStoreEntities2 db = new BookStoreEntities2();

        // 显示用户登录界面
        public ActionResult Index()
        {
            return View();
        }

        // 用户登陆界面的发送请求
        [HttpPost]
        public ActionResult Index(string userName,string passWord)
        {
            // 查询用户是否存在
            var haveUser = db.userTable.Where(user=>user.userName == userName && user.passWord == passWord).SingleOrDefault();
            if (haveUser != null)
            {
                Session["name"] = userName;
                if (haveUser.role == "admin")
                {
                    return RedirectToAction("Select","Admin");
                }
                else
                {
                    return RedirectToAction("user");
                }
            }
            return View();
        }

        // admin page
        public ActionResult admin()
        {
            var user = new List<userTable>();
            
                return View(user);
        }

        // user page
        public ActionResult user()
        {
            // 判断用户是否登陆
            if (Session["name"] == null)
            {
                return RedirectToAction("unLogging","Books");
            }
            return View();
        }

        // user register page
        public ActionResult register()
        {
            return View();
        }

         
        // user register page HttpPost method
        [HttpPost]
        public ActionResult register(string userName,string passWord,string passWordAgain)
        {
            // have user already exist?
            var exist = db.userTable.Where(user => user.userName == userName).Count();
            // not exist 
            if (exist == 0)
            {
                // are the two passwords equal?
                if (passWord == passWordAgain)
                {
                    // add to database
                    var newUser = new userTable()
                    {
                        userName = userName,
                        passWord = passWord,
                        role = "user"
                    };
                    db.userTable.Add(newUser);
                    db.SaveChanges();
                    // redirect to index page
                    ViewBag.message = "注册成功！";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.message = "两次输入的密码不相同，请重新输入！";
                }
            }
            else
            {
                ViewBag.message = "用户已经存在，请重新输入用户名！";
            }
            return View();
        }


        public ActionResult List()
        {
            var user = new List<userTable>();
            
            return View(user);
        }

        // change passWord
        public ActionResult changePassword()
        {
            return View();
        }

        // change passWord post method
        [HttpPost]
        public ActionResult changePassword(string passWord,string newPassWord,string newPassWordAgain)
        {
            // 
            var pageValue = Session["name"].ToString();
            var userExist = db.userTable.Where(b => b.userName == pageValue && b.passWord == passWord).SingleOrDefault();
            if (userExist != null)
            {
                if (newPassWord == newPassWordAgain)
                {
                    userExist.passWord = newPassWord;
                    db.SaveChanges();
                    ViewBag.message = "修改成功";
                }
                else
                {
                    ViewBag.message = "两次的密码不一致";
                }
            }
            else
            {
                ViewBag.message = "原始密码错误";
            }
            return View();
        }

       
    }
}
