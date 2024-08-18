using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        public ActionResult Index()
        {
            var values = db.TBLMUSTERILERs.ToList();
            return View(values);
          
        }

        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCustomer(TBLMUSTERILER t)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCustomer");
            }
            db.TBLMUSTERILERs.Add(t);
            db.SaveChanges();
            return View();
        }

        public ActionResult Delete(int id)
        { 
            var customer = db.TBLMUSTERILERs.Find(id);
            db.TBLMUSTERILERs.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CustomerGet(int id)
        {
            var customer = db.TBLMUSTERILERs.Find(id);
            return View("CustomerGet", customer);
        }

        public ActionResult Update(TBLMUSTERILER t)
        {
            var customer = db.TBLMUSTERILERs.Find(t.ID);
            customer.AD = t.AD;
            customer.SOYAD = t.SOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        } 

    }
}