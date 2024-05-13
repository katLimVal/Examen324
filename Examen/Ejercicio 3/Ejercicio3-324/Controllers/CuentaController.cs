using Ejercicio3_324.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ejercicio3_324.Controllers
{
    public class CuentaController : Controller
    {
        // GET: Cuenta
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarElementosPorId(int id)
        {
            using (Model1 context = new Model1())
            {
                var elementosConId = context.cuenta.Where(x => x.persona_id == id).ToList();
                return View(elementosConId);
            }
        }
        

        // GET: Cuenta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cuenta/Create
        [HttpPost]
        public ActionResult Create(cuenta cuen)
        {
            try
            {
                using (Model1 context = new Model1())
                {
                    context.cuenta.Add(cuen);
                    context.SaveChanges();
                }
                int idp = Convert.ToInt32(cuen.persona_id);
                return RedirectToAction("ListarElementosPorId", new { id  = idp });
            }
            catch
            {
                return View();
            }
        }

        // GET: Cuenta/Edit/5
        public ActionResult Edit(int id)
        {
            using (Model1 context = new Model1())
            {
                return View(context.cuenta.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Cuenta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, cuenta c)
        {
            try
            {
                // TODO: Add update logic here
                using (Model1 context = new Model1())
                {
                    context.Entry(c).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cuenta/Delete/5
        public ActionResult Delete(int id)
        {
            using (Model1 context = new Model1())
            {
                return View(context.cuenta.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Cuenta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (Model1 context = new Model1())
                {
                    cuenta c = context.cuenta.Where(x => x.id == id).FirstOrDefault();
                    context.cuenta.Remove(c);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
