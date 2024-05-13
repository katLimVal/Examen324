using Ejercicio3_324.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace Ejercicio3_324.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            using (Model1 context = new Model1())
            {
                return View(context.persona.ToList());
            }
        }

        // GET: Persona/Details/5
        public ActionResult Details(int id)
        {
            using (Model1 context = new Model1())
            {
                return View(context.persona.Where(x => x.ci == id));
            }
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
             return View();
            
        }

        // POST: Persona/Create
        [HttpPost]
        public ActionResult Create(persona per)
        {
            try
            {
                // TODO: Add insert logic here
                using (Model1 context = new Model1()) {
                    context.persona.Add(per);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int id)
        {
            using (Model1 context = new Model1())
            {
                return View(context.persona.Where(x => x.ci == id).FirstOrDefault());
            }
        }

        // POST: Persona/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, persona per)
        {
            try
            {
                // TODO: Add update logic here
                using (Model1 context = new Model1())
                {
                    context.Entry(per).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int id)
        {
            using (Model1 context = new Model1())
            {
                return View(context.persona.Where(x => x.ci == id).FirstOrDefault());
            }
        }

        // POST: Persona/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (Model1 context = new Model1()) { 
                    persona per=context.persona.Where(x=>x.ci==id).FirstOrDefault();
                    context.persona.Remove(per);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
