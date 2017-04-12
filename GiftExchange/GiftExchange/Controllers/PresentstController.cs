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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var Contents = collection["Contents"];
            var GiftHint = collection["GiftHint"];
            var ColorWrappingPaper = collection["ColorWrappingPaper"];
            var Height = collection["Height"];
            var Width = collection["Width"];
            var Depth = collection["Depth"];
            var Weight = collection["Weight"];
            var IsOpened = collection["IsOpened"];

            return RedirectToAction("Index");
        }
    }
}