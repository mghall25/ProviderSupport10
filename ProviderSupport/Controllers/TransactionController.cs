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
using ProviderSupport.ViewModels;

namespace ProviderSupport.Controllers
{
    public class TransactionController : Controller
    {
        private ProviderSupportContext db = new ProviderSupportContext();

        // GET: Transaction
        public ActionResult Index()
        {
            var transactions = db.Transactions.Include(t => t.Client).Include(t => t.Provider).Include(t => t.ServiceType).Include(t => t.ServiceTypeEmpl);
            return View(transactions.ToList());
        }

        // GET: Transaction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transaction/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientFullName");
            ViewBag.ProviderID = new SelectList(db.Providers, "ProviderID", "FullName");
            ViewBag.ServiceTypeID = new SelectList(db.ServiceTypes, "ServiceTypeID", "Desc");
            ViewBag.ServiceTypeEmplID = new SelectList(db.ServiceTypeEmpls, "ServiceTypeEmplID", "Desc");
                      
            //ViewBag.ServiceTypeID = db.ServiceTypes.ToList();   
            return View();
        }

        // POST: Transaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransactionID,TimeStamp,ProviderID,ClientID,DateWorked,ServiceTypeID,TimeIn,TimeOut,ServiceDesc,ProgressNote,OdometerStart,OdometerEnd,TravelPurpose,ExpenseVendor,ExpensePurpose,ExpenseAmount,ServiceTypeEmplID,EmploymentDirSuppHrs,IsDuplicate,WhenInvoiced,WhenSentToExprs,WhenPaidToPayroll")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "PrimeNo", transaction.ClientID);
            ViewBag.ProviderID = new SelectList(db.Providers, "ProviderID", "FullName", transaction.ProviderID);
            ViewBag.ServiceTypeID = new SelectList(db.ServiceTypes, "ServiceTypeID", "Desc", transaction.ServiceTypeID);
            ViewBag.ServiceTypeEmplID = new SelectList(db.ServiceTypeEmpls, "ServiceTypeEmplID", "Desc", transaction.ServiceTypeEmplID);
            return View(transaction);
        }

        // GET: Transaction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "PrimeNo", transaction.ClientID);
            ViewBag.ProviderID = new SelectList(db.Providers, "ProviderID", "FirstName", transaction.ProviderID);
            ViewBag.ServiceTypeID = new SelectList(db.ServiceTypes, "ServiceTypeID", "Desc", transaction.ServiceTypeID);
            ViewBag.ServiceTypeEmplID = new SelectList(db.ServiceTypeEmpls, "ServiceTypeEmplID", "Desc", transaction.ServiceTypeEmplID);
            return View(transaction);
        }

        // POST: Transaction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransactionID,TimeStamp,ProviderID,ClientID,DateWorked,ServiceTypeID,TimeIn,TimeOut,ServiceDesc,ProgressNote,OdometerStart,OdometerEnd,TravelPurpose,ExpenseVendor,ExpensePurpose,ExpenseAmount,ServiceTypeEmplID,EmploymentDirSuppHrs,IsDuplicate,WhenInvoiced,WhenSentToExprs,WhenPaidToPayroll")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "PrimeNo", transaction.ClientID);
            ViewBag.ProviderID = new SelectList(db.Providers, "ProviderID", "FirstName", transaction.ProviderID);
            ViewBag.ServiceTypeID = new SelectList(db.ServiceTypes, "ServiceTypeID", "Desc", transaction.ServiceTypeID);
            ViewBag.ServiceTypeEmplID = new SelectList(db.ServiceTypeEmpls, "ServiceTypeEmplID", "Desc", transaction.ServiceTypeEmplID);
            return View(transaction);
        }

        // GET: Transaction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            db.Transactions.Remove(transaction);
            db.SaveChanges();
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
