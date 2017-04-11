using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GiftExchange.Services;

namespace GiftExchange.Controllers
{
    public class PresentstController : Controller
    {
        // GET: Presentst
        public ActionResult Index()
        {
            var presents = new GiftServices().GetAllPresents();
            return View(presents);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}