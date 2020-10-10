using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using bookStore.Models;

namespace bookStore.Controllers
{
    public class StoreController : Controller
    {
        ICategoryRespository _categoryRepository;

        public StoreController()
        {
            _categoryRepository = new ICategoryRepository();
        }

        
        // GET: /Store/

        public ActionResult Index()
        {
            return View();
        }

    }
}
