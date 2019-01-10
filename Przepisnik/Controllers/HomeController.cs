using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Przepisnik.ViewModels;
using Przepisnik.Data;
using System.Collections;

namespace Przepisnik.Controllers
{
    public class HomeController : Controller
    {
        private RecipesDBContext db = new RecipesDBContext();

        public ActionResult Index()
        {
            return View();

        }
        public ActionResult About()
        {
            IQueryable<PublicRecipes> query = from recipe in db.Recipes
                                              where recipe.IfPublic == true
                                              select new PublicRecipes()
                                              {
                                                  PublicID = recipe.RecipeID,
                                                  Image = recipe.RecipePhotoUrl,
                                                  PreparationT = recipe.PrepTime,
                                                  RecipeTitle = recipe.Title,
                                                  Descr = recipe.Description
                                              };
        
            return View(query.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult AboutRecipes()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}