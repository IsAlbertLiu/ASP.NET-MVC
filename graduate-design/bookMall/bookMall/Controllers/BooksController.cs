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

    }
}
