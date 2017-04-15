using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MtgLife.Website.Models;

namespace MtgLife.Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(GameViewModel viewModel)
        {

            return Redirect("/");
        }
    }
}