﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        //
        // GET: /HelloWorld/

        //public string Index()
        //{
        //    return "This is my <b>default</b> action...";
        //}
        // GET: /HelloWorld/Welcome/
        //public string Welcome()
        //{
        //    return "This is the Welcome action method...";
        //}

        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            return View();
        }
    }
}
