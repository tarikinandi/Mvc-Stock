using MvcStok.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    public class SalesController : Controller
    {
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        // GET: Sales
        public ActionResult Index()
        {
            // Ürün listesini dolduralım
            List<SelectListItem> products = db.TBLURUNLERs.Select(i => new SelectListItem
            {
                Text = i.AD,
                Value = i.ID.ToString()
            }).ToList();
            ViewBag.product = products;

            // Müşteri listesini dolduralım
            List<SelectListItem> customers = db.TBLMUSTERILERs.Select(i => new SelectListItem
            {
                Text = i.AD + " " + i.SOYAD,
                Value = i.ID.ToString()
            }).ToList();
            ViewBag.customer = customers;

            return View();
        }

    

        [HttpGet]
        public ActionResult NewSales(int? selectedProductId)
        {
          

            return View();
        }
        [HttpPost]
        public ActionResult NewSales(TBLSATISLAR p)
        {
            try
            {
                var urn = db.TBLURUNLERs.Where(m => m.ID == p.TBLURUNLER.ID).FirstOrDefault();
                p.TBLURUNLER = urn;

                var mus = db.TBLMUSTERILERs.Where(m => m.ID == p.TBLMUSTERILER.ID).FirstOrDefault();
                p.TBLMUSTERILER = mus;

                db.TBLSATISLARs.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}