using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Przepisnik.Data;
using Przepisnik.Models;

namespace Przepisnik.Controllers
{
    public class RecipeCategoryController : Controller
    {
        private RecipesDBContext db = new RecipesDBContext();

        // GET: RecipeCategory
        public ActionResult Index()
        {
            var recipeCategories = db.RecipeCategories.Include(r => r.Category).Include(r => r.Recipe);
            return View(recipeCategories.ToList());
        }

        // GET: RecipeCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeCategory recipeCategory = db.RecipeCategories.Find(id);
            if (recipeCategory == null)
            {
                return HttpNotFound();
            }
            return View(recipeCategory);
        }

        // GET: RecipeCategory/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.RecipeID = new SelectList(db.Recipes, "RecipeID", "Title");
            return View();
        }

        // POST: RecipeCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RecipeID,CategoryID")] RecipeCategory recipeCategory)
        {
            if (ModelState.IsValid)
            {
                db.RecipeCategories.Add(recipeCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", recipeCategory.CategoryID);
            ViewBag.RecipeID = new SelectList(db.Recipes, "RecipeID", "Title", recipeCategory.RecipeID);
            return View(recipeCategory);
        }

        // GET: RecipeCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeCategory recipeCategory = db.RecipeCategories.Find(id);
            if (recipeCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", recipeCategory.CategoryID);
            ViewBag.RecipeID = new SelectList(db.Recipes, "RecipeID", "Title", recipeCategory.RecipeID);
            return View(recipeCategory);
        }

        // POST: RecipeCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RecipeID,CategoryID")] RecipeCategory recipeCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipeCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", recipeCategory.CategoryID);
            ViewBag.RecipeID = new SelectList(db.Recipes, "RecipeID", "Title", recipeCategory.RecipeID);
            return View(recipeCategory);
        }

        // GET: RecipeCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeCategory recipeCategory = db.RecipeCategories.Find(id);
            if (recipeCategory == null)
            {
                return HttpNotFound();
            }
            return View(recipeCategory);
        }

        // POST: RecipeCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecipeCategory recipeCategory = db.RecipeCategories.Find(id);
            db.RecipeCategories.Remove(recipeCategory);
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
