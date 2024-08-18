using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        public ActionResult Index()
        {
           var values = db.TBLKATEGORILERs.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCategory(TBLKATEGORILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCategory");
            }
            db.TBLKATEGORILERs.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Delete(int id)
        {
            var category = db.TBLKATEGORILERs.Find(id);
            db.TBLKATEGORILERs.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CategoryGet(int id)
        {
            var category = db.TBLKATEGORILERs.Find(id);
            return View("CategoryGet" , category);
        }
      
        public ActionResult Update(TBLKATEGORILER p1)
        {
            var category = db.TBLKATEGORILERs.Find(p1.ID);
            category.AD = p1.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}