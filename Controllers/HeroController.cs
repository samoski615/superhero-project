using SuperHeroProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroProject.Controllers
{
    public class HeroController : Controller
    {
        ApplicationDbContext db;

        public HeroController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Hero
        public ActionResult Index() 
        {
            List<Superhero> s = db.Superheroes.ToList();

            return View(s);
        }

        // GET: Hero/Details/5
        public ActionResult Details(int id)  //display a list of superheroes from db on details page
        {
            var viewSuperhero = db.Superheroes.Where(s => s.Id == id).Single();
            return View(viewSuperhero);           
        }

        // GET: Hero/Create
        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View(superhero);
        }

        // POST: Hero/Create
        [HttpPost]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                db.Superheroes.Add(superhero);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }
            catch
            {
                return View(superhero);
            }
        }

        // GET: Hero/Edit/5
        public ActionResult Edit(int id)
        {
            var editSuperhero = db.Superheroes.Where(s => s.Id == id).SingleOrDefault();
            
            return View(editSuperhero);
        }

        // POST: Hero/Edit/5
        [HttpPost]
        public ActionResult Edit(Superhero superhero)
        {
            try
            {
                var superheroInDb = db.Superheroes.Where(s => s.Id == superhero.Id).SingleOrDefault();
                superheroInDb.SuperHeroName = superhero.SuperHeroName;
                superheroInDb.AlterEgo = superhero.AlterEgo;
                superheroInDb.PrimaryAbility = superhero.PrimaryAbility;
                superheroInDb.SecondaryAbility = superhero.SecondaryAbility;
                superheroInDb.Catchphrase = superhero.Catchphrase;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: Hero/Delete/5
        public ActionResult Delete(int id)
        {
            var deleteSuperhero = db.Superheroes.Find(id);
            if (deleteSuperhero == null)
            {
                return HttpNotFound();
            }
            return View(deleteSuperhero);
        }

        // POST: Hero/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                var deleteSuperhero = db.Superheroes.Find(id);
                db.Superheroes.Remove(deleteSuperhero);
                db.SaveChanges();
                return RedirectToAction("Index");




                // TODO: Add delete logic here
                //db.Superheroes.Find();
                //db.SaveChanges();
            }
            catch
            {
                return View();
            }
        }
    }
}
