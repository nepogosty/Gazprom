using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gazprom.Models;

namespace Gazprom.Controllers
{
    public class SubdivisionsController : Controller
    {
        static int maxs = 0;
        private BTContext db = new BTContext();

        

        // GET: Subdivisions/Create
        public ActionResult Create()
        {
            foreach(var sub in db.Subdivision)
            {
                if (sub.ID_subdivision >= maxs)
                {
                    maxs = sub.ID_subdivision;
                }
            }
            return View();
        }

        // POST: Subdivisions/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_subdivision,Name")] Subdivision subdivision)
        {

            subdivision.ID_subdivision = maxs + 1;
            if (ModelState.IsValid)
            {
                db.Subdivision.Add(subdivision);
                db.SaveChanges();
                return RedirectToAction("Index","Business_trip");
            }

            return View(subdivision);
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
