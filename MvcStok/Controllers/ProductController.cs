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
    public class ProductController : Controller
    {
        // GET: Product
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        public ActionResult Index()
        {
            var value = db.TBLURUNLERs.ToList();

            return View(value);
        }

        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> values = (from i in db.TBLKATEGORILERs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.value = values;
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(TBLURUNLER p)
        {
            var ktg = db.TBLKATEGORILERs.Where(m => m.ID == p.TBLKATEGORILER.ID).FirstOrDefault();
            p.TBLKATEGORILER = ktg;
            db.TBLURUNLERs.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var product = db.TBLURUNLERs.Find(id);
            db.TBLURUNLERs.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductGet(TBLURUNLER t)
        {
            var product = db.TBLURUNLERs.Find(t.ID);
            List<SelectListItem> values = (from i in db.TBLKATEGORILERs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.value = values;
            return View("ProductGet", product);
        }

        public ActionResult Update(TBLURUNLER t)
        {
            var product = db.TBLURUNLERs.Find(t.ID);
            product.AD = t.AD;
            product.MARKA = t.MARKA;
            product.STOK = t.STOK;
            product.FIYAT= t.FIYAT;
            var ktg = db.TBLKATEGORILERs.Where(m => m.ID == t.TBLKATEGORILER.ID).FirstOrDefault();
            product.KATEGORI = ktg.ID;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}