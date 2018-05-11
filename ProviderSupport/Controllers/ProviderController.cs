using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProviderSupport.DAL;
using ProviderSupport.Models;
using PagedList;
using System.Data.Entity.Infrastructure;

namespace ProviderSupport.Controllers
{
    public class ProviderController : Controller
    {
        private ProviderSupportContext db = new ProviderSupportContext();

        // GET: Provider
        // sort by name or date
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var providers = from s in db.Providers
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                providers = providers.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    providers = providers.OrderByDescending(s => s.FirstName);
                    break;
                case "Date":
                    providers = providers.OrderBy(s => s.CprExpDate);
                    break;
                case "date_desc":
                    providers = providers.OrderByDescending(s => s.CprExpDate);
                    break;
                default:
                    providers = providers.OrderBy(s => s.FirstName);
                    break;
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(providers.ToPagedList(pageNumber, pageSize));
        }

        // GET: Provider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        // GET: Provider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Provider/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,PhoneNum,Email,BirthDate,PayRate,CprExpDate,Archived")] Provider provider)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Providers.Add(provider);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException  /* dex */)
            {
                // Log the error - can uncomment dex var to write to a log)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the proble persists, contact your system administrator.");
            }

            return View(provider);
        }

        // GET: Provider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        // POST: Provider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var providerToUpdate = db.Providers.Find(id);
            if (TryUpdateModel(providerToUpdate, "",
               new string[] { "LastName", "FirstName", "PhoneNum", "Email","BirthDate","PayRate","CprExpDate", "Archived" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException  /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(providerToUpdate);
        }

        // GET: Provider/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        // POST: Provider/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                //Provider provider = db.Providers.Find(id);
                //db.Providers.Remove(provider);
                //next two lines improve performance by avoiding  an unnecessary SQL query
                Provider providerToDelete = new Provider() { ProviderID = id };
                db.Entry(providerToDelete).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
