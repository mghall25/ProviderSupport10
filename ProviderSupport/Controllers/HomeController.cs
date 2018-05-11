using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProviderSupport.DAL;
using ProviderSupport.ViewModels;

namespace ProviderSupport.Controllers
{
    public class HomeController : Controller
    {
        private ProviderSupportContext db = new ProviderSupportContext();       

        public ActionResult Index()
        {
            ViewBag.ProviderCount = db.Providers.Count();
            ViewBag.ClientCount = db.Clients.Count();
            ViewBag.TransactionCount = db.Transactions.Count();

            return View();
        }

        public ActionResult About()
        {
            IQueryable<BirthDateGroup> data = from provider in db.Providers
                                                   group provider by provider.CprExpDate into dateGroup
                                                   select new BirthDateGroup()
                                                   {
                                                       CprExpDate = dateGroup.Key,
                                                       ProviderCount = dateGroup.Count()
                                                   };
            return View(data.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }        

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Invoices()
        {           
            return View();
        }

    }
}