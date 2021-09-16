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
    public class BranchesController : Controller
    {
        private BTContext db = new BTContext();
        static int maxs1 = 0;
        // GET: Branches/Create
        public ActionResult Create()
        {
            foreach (var br in db.Branch)
            {
                if (br.ID_branch >= maxs1)
                {
                    maxs1 = br.ID_branch;
                }
            }
            return View();
        }

        // POST: Branches/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_branch,Name")] Branch branch)
        {
            branch.ID_branch = maxs1 + 1;
            if (ModelState.IsValid)
            {
                db.Branch.Add(branch);
                db.SaveChanges();
                return RedirectToAction("Index", "Business_trip");
            }

            return View(branch);
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
