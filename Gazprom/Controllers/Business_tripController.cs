using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gazprom.Models;
using ClosedXML;
using ClosedXML.Excel;
using System.IO;

namespace Gazprom.Controllers
{
    public class Business_tripController : Controller
    {
        private BTContext db = new BTContext();

        

        // GET: Business_trip
        public ActionResult Index(string date)
        {
            Employee employee = db.Employee.Find(User.Identity.Name);
            EmployeeBT employeebt = new EmployeeBT();
            int idacc = employee.ID_access;

            if (employee.ID_access == 0)
            {
                //var business_trip = db.Business_trip.Include(b => b.Counterparty).Include(b => b.Employee).Include(b => b.Status).Include(b => b.Tariff_daily).Where(b => b.Login == User.Identity.Name);
                //ViewBag.Employee = new SelectList(db.Employee, "ID_access", "Доступ", employee.ID_access);
                ////return View(business_trip.ToList());
                
                var business_trip = db.Business_trip.Include(b => b.Counterparty).Include(b => b.Employee).Include(b => b.Status).Include(b => b.Tariff_daily).Where(b => b.Employee.ID_subdivision == employee.ID_subdivision && b.Employee.ID_branch == employee.ID_branch);
                var filter = business_trip;
                var filter1 = business_trip;
                if (date== "Следующий месяц") {
                    filter = business_trip.Where(i => i.StartBT >= DateTime.Today);
                    DateTime dateplus = new DateTime();
                    dateplus = DateTime.Now.AddMonths(1);
                    filter1 = filter.Where(i => i.StartBT <= dateplus);
                    
                }
                if (date == "Квартал")
                {
                    filter = business_trip.Where(i => i.StartBT >= DateTime.Today);
                    DateTime dateplus = new DateTime();
                    dateplus = DateTime.Now.AddMonths(3);
                    filter1 = filter.Where(i => i.StartBT <= dateplus);
                }
                if (date == "Год")
                {
                    filter = business_trip.Where(i => i.StartBT >= DateTime.Today);
                    DateTime dateplus = new DateTime();
                    dateplus = DateTime.Now.AddMonths(12);
                    filter1 = filter.Where(i => i.StartBT <= dateplus);
                }
                if (date == "Все")
                {
                    filter1 = business_trip;
                    
                }

                FilteredBT fl = new FilteredBT()
                {
                    BusinessTrips = filter1.ToList().OrderByDescending(d => d.StartBT).ToList(),
                    id_access = idacc,
                    TimeFilter = new SelectList(new List<string>()
                    {
                        "Все",
                        "Следующий месяц",                    
                        "Квартал",
                        "Год", 
                      

                    })

                };
                

                return View(fl);


            }
            if (employee.ID_access == 1)
            {
                //var business_trip = db.Business_trip.Include(b => b.Counterparty).Include(b => b.Employee).Include(b => b.Status).Include(b => b.Tariff_daily).Where(b => b.Employee.ID_subdivision == employee.ID_subdivision && b.Employee.ID_branch == employee.ID_branch);
                //return View(business_trip.ToList());
                var business_trip = db.Business_trip.Include(b => b.Counterparty).Include(b => b.Employee).Include(b => b.Status).Include(b => b.Tariff_daily).Where(b => b.Employee.ID_subdivision == employee.ID_subdivision && b.Employee.ID_branch == employee.ID_branch);
                var filter = business_trip;
                var filter1 = business_trip;
                if (date == "Следующий месяц")
                {
                    filter = business_trip.Where(i => i.StartBT >= DateTime.Today);
                    DateTime dateplus = new DateTime();
                    dateplus = DateTime.Now.AddMonths(1);
                    filter1 = filter.Where(i => i.StartBT <= dateplus);

                }
                if (date == "Квартал")
                {
                    filter = business_trip.Where(i => i.StartBT >= DateTime.Today);
                    DateTime dateplus = new DateTime();
                    dateplus = DateTime.Now.AddMonths(3);
                    filter1 = filter.Where(i => i.StartBT <= dateplus);
                }
                if (date == "Год")
                {
                    filter = business_trip.Where(i => i.StartBT >= DateTime.Today);
                    DateTime dateplus = new DateTime();
                    dateplus = DateTime.Now.AddMonths(12);
                    filter1 = filter.Where(i => i.StartBT <= dateplus);
                }
                if ((date == "Все"||date==null) )
                {
                   
                    filter1 = filter;

                }

                FilteredBT fl = new FilteredBT()
                {
                    BusinessTrips = filter1.ToList().OrderByDescending(d => d.StartBT).ToList(),
                    id_access = idacc,
                    TimeFilter = new SelectList(new List<string>()
                    {
                        "Все",
                        "Следующий месяц",
                        "Квартал",
                        "Год",
                        "Старые"

                    })

                };
                return View(fl);
            }
            if (employee.ID_access == 2)
            {
                //var business_trip = db.Business_trip.Include(b => b.Counterparty).Include(b => b.Employee).Include(b => b.Status).Include(b => b.Tariff_daily).Where(b => b.Employee.ID_subdivision == employee.ID_subdivision && b.Employee.ID_branch == employee.ID_branch);
                //return View(business_trip.ToList());
                var business_trip = db.Business_trip.Include(b => b.Counterparty).Include(b => b.Employee).Include(b => b.Status).Include(b => b.Tariff_daily).Where(b => b.Employee.ID_branch == employee.ID_branch);
                var filter = business_trip;
                var filter1 = business_trip;
                if (date == "Следующий месяц")
                {
                    filter = business_trip.Where(i => i.StartBT >= DateTime.Today);
                    DateTime dateplus = new DateTime();
                    dateplus = DateTime.Now.AddMonths(1);
                    filter1 = filter.Where(i => i.StartBT <= dateplus);

                }
                if (date == "Квартал")
                {
                    filter = business_trip.Where(i => i.StartBT >= DateTime.Today);
                    DateTime dateplus = new DateTime();
                    dateplus = DateTime.Now.AddMonths(3);
                    filter1 = filter.Where(i => i.StartBT <= dateplus);
                }
                if (date == "Год")
                {
                    filter = business_trip.Where(i => i.StartBT >= DateTime.Today);
                    DateTime dateplus = new DateTime();
                    dateplus = DateTime.Now.AddMonths(12);
                    filter1 = filter.Where(i => i.StartBT <= dateplus);
                }
                if (date == "Все" || date == null)
                {
                    filter1 = business_trip;

                }

                FilteredBT fl = new FilteredBT()
                {
                    BusinessTrips = filter1.ToList().OrderByDescending(d => d.StartBT).ToList(),
                    id_access = idacc,
                    TimeFilter = new SelectList(new List<string>()
                    {
                        "Все",
                        "Следующий месяц",
                        "Квартал",
                        "Год",
                        "Старые"

                    })

                };
                return View(fl);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Business_trip business_trip = db.Business_trip.Find(id);
            if (business_trip == null)
            {
                return HttpNotFound();
            }
            return View(business_trip);
        }

        // GET: Business_trip/Create
        public ActionResult Create()
        {
            ViewBag.ID_CP = new SelectList(db.Counterparty, "ID_CP", "Name");
            ViewBag.Login = new SelectList(db.Employee, "Login", "Lastname");
            ViewBag.ID_status = new SelectList(db.Status, "ID_status", "Name");
            ViewBag.Cost = new SelectList(db.Tariff_daily, "Cost", "Cost");
            return View();
        }

        // POST: Business_trip/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_businesstrip,Region,District,Locality,Purpose,StartBT,EndBT,OvernightStay,CostLiving,Fare,Login,Cost,ID_CP,ID_status")] Business_trip business_trip)
        {
            business_trip.ID_status = 1;
            if (business_trip.Region == null)
            {
                business_trip.Region = "не указан";
                business_trip.ID_status = 4;
            }
            if (business_trip.District == null)
            {
                business_trip.Region = "не указан";
                business_trip.ID_status = 4;
            }
            if (business_trip.Locality == null)
            {
                business_trip.District = "не указан";
                business_trip.ID_status = 4;
            }
            if (business_trip.Purpose == null)
            {
                business_trip.Purpose = "не указан";
                business_trip.ID_status = 4;
            }
            business_trip.Login = User.Identity.Name;
                business_trip.ID_businesstrip = Guid.NewGuid();      
                business_trip.DifferencesDays= Convert.ToInt32((business_trip.EndBT - business_trip.StartBT).TotalDays);
                business_trip.SummCost = business_trip.DifferencesDays * business_trip.Cost;
                business_trip.SummLiving = business_trip.OvernightStay * business_trip.CostLiving;
                business_trip.TotalSumm = business_trip.SummLiving + business_trip.SummCost + business_trip.Fare;
                
                business_trip.Employee = db.Employee.Find(business_trip.Login);
                business_trip.Status = db.Status.Find(business_trip.ID_status);
                business_trip.Tariff_daily = db.Tariff_daily.Find(business_trip.Cost);
            
         
                db.Business_trip.Add(business_trip);
                db.SaveChanges();
                return RedirectToAction("Index");
            

            //ViewBag.ID_CP = new SelectList(db.Counterparty, "ID_CP", "Name", business_trip.ID_CP);
            //ViewBag.Login = new SelectList(db.Employee, "Login", "Lastname", business_trip.Login);
            //ViewBag.ID_status = new SelectList(db.Status, "ID_status", "Name", business_trip.ID_status);
            //ViewBag.Cost = new SelectList(db.Tariff_daily, "Cost", "Cost", business_trip.Cost);
            //return View(business_trip);
        }

        // GET: Business_trip/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Business_trip business_trip = db.Business_trip.Find(id);
            if (business_trip == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CP = new SelectList(db.Counterparty, "ID_CP", "Name", business_trip.ID_CP);
            //ViewBag.Login = new SelectList(db.Employee, "Login", "Lastname", business_trip.Login);
            ViewBag.ID_status = new SelectList(db.Status, "ID_status", "Name", business_trip.ID_status);
            ViewBag.Cost = new SelectList(db.Tariff_daily, "Cost", "Cost", business_trip.Cost);
            return View(business_trip);
        }

        // POST: Business_trip/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_businesstrip,Region,District,Locality,Purpose,StartBT,EndBT,OvernightStay,CostLiving,Fare,Cost,ID_CP,ID_status")] Business_trip business_trip)
        {
            business_trip.ID_status = 1;
            if (business_trip.Region == null)
            {
                business_trip.Region = "не указан";
                business_trip.ID_status = 4;
            }
            if (business_trip.District == null)
            {
                business_trip.Region = "не указан";
                business_trip.ID_status = 4;
            }
            if(business_trip.Locality == null)
            {
                business_trip.District = "не указан";
                business_trip.ID_status = 4;
            }
            if (business_trip.Purpose == null)
            {
                business_trip.Purpose = "не указан";
                business_trip.ID_status = 4;
            }
            
            business_trip.DifferencesDays = Convert.ToInt32((business_trip.EndBT - business_trip.StartBT).TotalDays);
            business_trip.SummCost = business_trip.DifferencesDays * business_trip.Cost;
            business_trip.SummLiving = business_trip.OvernightStay * business_trip.CostLiving;
            business_trip.TotalSumm = business_trip.SummLiving + business_trip.SummCost + business_trip.Fare;
            business_trip.Counterparty = db.Counterparty.Find(business_trip.ID_CP);
            business_trip.Login = User.Identity.Name;
            business_trip.Employee = db.Employee.Find(business_trip.Login);
            business_trip.Status= db.Status.Find(business_trip.ID_status);
            business_trip.Tariff_daily = db.Tariff_daily.Find(business_trip.Cost);
            db.Entry(business_trip).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            //        //if (ModelState.IsValid)
            //        //{

            //db.Entry(business_trip).State = EntityState.Modified;
            //db.SaveChanges();
            //return RedirectToAction("Index");

            //        //if (!ModelState.IsValid)
            //        {
            //            var errors = ModelState
            //.Where(x => x.Value.Errors.Count > 0)
            //.Select(x => new { x.Key, x.Value.Errors })
            //.ToArray();

            //            // Breakpoint, Log or examine the list with Exceptions.
            //        }
            //ViewBag.ID_CP = new SelectList(db.Counterparty, "ID_CP", "Name", business_trip.ID_CP);
            //ViewBag.Login = new SelectList(db.Employee, "Login", "Lastname", business_trip.Login);
            //ViewBag.ID_status = new SelectList(db.Status, "ID_status", "Name", business_trip.ID_status);
            //ViewBag.Cost = new SelectList(db.Tariff_daily, "Cost", "Cost", business_trip.Cost);
            //return View(business_trip);
        }
        public ActionResult Copy(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Business_trip business_trip = db.Business_trip.Find(id);
            if (business_trip == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CP = new SelectList(db.Counterparty, "ID_CP", "Name", business_trip.ID_CP);
            //ViewBag.Login = new SelectList(db.Employee, "Login", "Lastname", business_trip.Login);
            ViewBag.ID_status = new SelectList(db.Status, "ID_status", "Name", business_trip.ID_status);
            ViewBag.Cost = new SelectList(db.Tariff_daily, "Cost", "Cost", business_trip.Cost);
            return View(business_trip);
        }

        // POST: Business_trip/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Copy([Bind(Include = "ID_businesstrip,Region,District,Locality,Purpose,StartBT,EndBT,OvernightStay,CostLiving,Fare,Cost,ID_CP,ID_status")] Business_trip business_trip)
        {
            business_trip.ID_status = 1;
            if (business_trip.Region == null)
            {
                business_trip.Region = "не указан";
                business_trip.ID_status = 4;
            }
            if (business_trip.District == null)
            {
                business_trip.Region = "не указан";
                business_trip.ID_status = 4;
            }
            if (business_trip.Locality == null)
            {
                business_trip.District = "не указан";
                business_trip.ID_status = 4;
            }
            if (business_trip.Purpose == null)
            {
                business_trip.Purpose = "не указан";
                business_trip.ID_status = 4;
            }
            business_trip.ID_businesstrip = Guid.NewGuid();
            business_trip.DifferencesDays = Convert.ToInt32((business_trip.EndBT - business_trip.StartBT).TotalDays);
            business_trip.SummCost = business_trip.DifferencesDays * business_trip.Cost;
            business_trip.SummLiving = business_trip.OvernightStay * business_trip.CostLiving;
            business_trip.TotalSumm = business_trip.SummLiving + business_trip.SummCost + business_trip.Fare;
            business_trip.Counterparty = db.Counterparty.Find(business_trip.ID_CP);
            business_trip.Login = User.Identity.Name;
            business_trip.Employee = db.Employee.Find(business_trip.Login);
            business_trip.Status = db.Status.Find(business_trip.ID_status);
            business_trip.Tariff_daily = db.Tariff_daily.Find(business_trip.Cost);
            //db.Entry(business_trip).State = EntityState.Modified;
            db.Business_trip.Add(business_trip);
           
            db.SaveChanges();
            return RedirectToAction("Index");
            //        //if (ModelState.IsValid)
            //        //{

            //db.Entry(business_trip).State = EntityState.Modified;
            //db.SaveChanges();
            //return RedirectToAction("Index");

            //        //if (!ModelState.IsValid)
            //        {
            //            var errors = ModelState
            //.Where(x => x.Value.Errors.Count > 0)
            //.Select(x => new { x.Key, x.Value.Errors })
            //.ToArray();

            //            // Breakpoint, Log or examine the list with Exceptions.
            //        }
            //ViewBag.ID_CP = new SelectList(db.Counterparty, "ID_CP", "Name", business_trip.ID_CP);
            //ViewBag.Login = new SelectList(db.Employee, "Login", "Lastname", business_trip.Login);
            //ViewBag.ID_status = new SelectList(db.Status, "ID_status", "Name", business_trip.ID_status);
            //ViewBag.Cost = new SelectList(db.Tariff_daily, "Cost", "Cost", business_trip.Cost);
            //return View(business_trip);
        }
        // GET: Business_trip/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Business_trip business_trip = db.Business_trip.Find(id);
            if (business_trip == null)
            {
                return HttpNotFound();
            }
            return View(business_trip);
        }

        // POST: Business_trip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Business_trip business_trip = db.Business_trip.Find(id);
            db.Business_trip.Remove(business_trip);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        // GET: Business_trip/Reject/5
        public ActionResult Reject(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Business_trip business_trip = db.Business_trip.Find(id);
            return View(business_trip);
        }
        // Post: Business_trip/Reject/5
        [HttpPost, ActionName("Reject")]
        [ValidateAntiForgeryToken]
        public ActionResult RejectConfirmed(Guid? id)
        {
            
            if (ModelState.IsValid)
            {
                Business_trip business_trip = db.Business_trip.Find(id);
                business_trip.ID_status = 0;
                db.Entry(business_trip).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        // GET: Business_trip/Confirm/5
        public ActionResult Confirm(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Business_trip business_trip = db.Business_trip.Find(id);
            return View(business_trip);
        }
        // Post: Business_trip/Confirm/5
        [HttpPost, ActionName("Confirm")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmConfirmed(Guid? id)
        {

            if (ModelState.IsValid)
            {
                Business_trip business_trip = db.Business_trip.Find(id);
                if (business_trip.ID_status == 2)
                {
                    business_trip.ID_status = 3;
                }
                if (business_trip.ID_status == 1) {
                    business_trip.ID_status = 2;
                }
               
                db.Entry(business_trip).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        public ActionResult Export()
        {
            Employee employee = db.Employee.Find(User.Identity.Name);
            List<Business_trip> btrip = new List<Business_trip>();
            if (employee.ID_access == 1)
            {
                using (BTContext db = new BTContext())
                {
                    foreach (Business_trip bt in db.Business_trip)
                    {
                        if (bt.Employee.Branch.ID_branch == employee.Branch.ID_branch && bt.Employee.ID_subdivision == employee.ID_subdivision && bt.ID_status==3)
                        {
                            btrip.Add(bt);
                        }
                    }

                }
            }
            if (employee.ID_access == 0)
            {
                using (BTContext db = new BTContext())
                {
                    foreach (Business_trip bt in db.Business_trip)
                    {
                        if (bt.Employee.Login==User.Identity.Name && bt.ID_status == 3)
                        {
                            btrip.Add(bt);
                        }
                    }

                }
            }
            if (employee.ID_access == 2)
            {
                using (BTContext db = new BTContext())
                {
                    foreach (Business_trip bt in db.Business_trip)
                    {
                        if (bt.Employee.Branch.ID_branch == employee.Branch.ID_branch && bt.ID_status == 3)
                        {
                            btrip.Add(bt);
                        }
                    }

                }
            }
            using (XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled))
                {


                    
                    var worksheet = workbook.Worksheets.Add("Командировки");
                    worksheet.Range("A9:U11").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Range("A9:U11").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    worksheet.Cell("A3").Value = "План служебных командировок";
                    worksheet.Cell("A4").Value = "Филиал:";
                    worksheet.Cell("D4").Value = employee.Branch.Name;
                    worksheet.Cell("A5").Value = "Период:";
                    worksheet.Cell("D5").Value = "Июль";
                    worksheet.Cell("A6").Value = "Исполнитель:";
                    worksheet.Cell("D6").Value = employee.Lastname+" "+employee.FirstName+" "+employee.Patronymic;
                    worksheet.Cell("A9").Value = "N";
                    var range = worksheet.Range("A9:B9");
                    range.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    worksheet.Cell("A10").Value = "Код";
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    var range99 = worksheet.Range("A10:A11");
                    range99.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range99.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("B10").Value = "п/п";
                    var range98 = worksheet.Range("B10:B11");
                    range98.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range98.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("C9").Value = "Фамилия";
                    var range1 = worksheet.Range("C9:C11");
                    range1.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range1.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("D9").Value = "Имя";
                    var range2 = worksheet.Range("D9:D11");
                    range2.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range2.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    

                    worksheet.Cell("E9").Value = "Отчество";
                    var range3 = worksheet.Range("E9:E11");
                    range3.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range3.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("F9").Value = "Должность";
                    var range4 = worksheet.Range("F9:F11");
                    range4.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range4.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("G9").Value = "Место назначения";
                    var range5 = worksheet.Range("G9:J9");
                    range5.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range5.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("G10").Value = "Регион";
                    var range6 = worksheet.Range("G10:G11");
                    range6.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range6.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("H10").Value = "Район";
                    var range7 = worksheet.Range("H10:H11");
                    range7.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range7.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("I10").Value = "Нас. Пункт";
                    var range8 = worksheet.Range("I10:I11");
                    range8.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range8.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("J10").Value = "Контрагент";
                    var range9 = worksheet.Range("J10:J11");
                    range9.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range9.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("K9").Value = "Цель командировки";
                    var range10 = worksheet.Range("K9:K11");
                    range10.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range10.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("L9").Value = "Период командировки";
                    var range11 = worksheet.Range("L9:N9");
                    range11.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range11.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("L10").Value = "Начало";
                    var range12 = worksheet.Range("L10:L11");
                    range12.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range12.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("M10").Value = "Окончание";
                    var range13 = worksheet.Range("M10:M11");
                    range13.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    range13.Merge().Style.Font.SetBold().Font.FontSize = 11;

                    worksheet.Cell("N10").Value = "Длит.";
                    var range14 = worksheet.Range("N10:N11");
                    range14.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range14.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("O9").Value = "Расходы на командировку (тыс. руб)";
                    var range15 = worksheet.Range("O9:U9");
                    range15.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range15.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("O10").Value = "Суточные";
                    var range16 = worksheet.Range("O10:P10");
                    range16.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range16.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("Q10").Value = "Проживание";
                    var range17 = worksheet.Range("Q10:S10");
                    range17.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range17.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("T10").Value = "Проезд";
                    var range18 = worksheet.Range("T10:T11");
                    range18.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range18.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("U10").Value = "Всего";
                    var range19 = worksheet.Range("U10:U11");
                    range19.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range19.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("O11").Value = "Тариф";
                    var range20 = worksheet.Range("O11");
                    range20.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range20.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("P11").Value = "Сумма";
                    var range21 = worksheet.Range("P11");
                    range21.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range21.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("Q11").Value = "Кол-во суток";
                    var range22 = worksheet.Range("Q11");
                    range22.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range22.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("R11").Value = "Стоимость";
                    var range23 = worksheet.Range("R11");
                    range23.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range23.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("S11").Value = "Итог";
                    var range24 = worksheet.Range("S11");
                    range24.Merge().Style.Font.SetBold().Font.FontSize = 11;
                    range24.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;


                    worksheet.Column(1).Width = 5;
                    worksheet.Column(2).Width = 5;
                    worksheet.Column(3).Width = 15;
                    worksheet.Column(4).Width = 15;
                    worksheet.Column(5).Width = 15;
                    worksheet.Column(6).Width = 15;
                    worksheet.Column(7).Width = 15;
                    worksheet.Column(8).Width = 15;
                    worksheet.Column(9).Width = 15;
                    worksheet.Column(10).Width = 15;
                    worksheet.Column(11).Width = 20;
                    worksheet.Column(12).Width = 12;
                    worksheet.Column(13).Width = 12;
                    worksheet.Column(14).Width = 7;
                    worksheet.Column(17).Width = 14;
                    worksheet.Column(18).Width = 14;
                    worksheet.Column(19).Width = 7;
                    worksheet.Column(20).Width = 7;
                    worksheet.Column(21).Width = 7;



                worksheet.Row(1).Style.Font.Bold = true;
                int i = 11;
                    foreach (var t in btrip)
                    {
                        
                        worksheet.Cell(i + 1, 1).Value = t.Employee.ID_subdivision;
                        worksheet.Cell(i + 1, 2).Value = i-10;
                        worksheet.Cell(i + 1, 3).Value = t.Employee.Lastname;
                        worksheet.Cell(i + 1, 4).Value = t.Employee.FirstName;
                        worksheet.Cell(i + 1, 5).Value = t.Employee.Patronymic;
                        worksheet.Cell(i + 1, 6).Value = t.Employee.Position;
                        worksheet.Cell(i + 1, 7).Value = t.Region;
                        worksheet.Cell(i + 1, 8).Value = t.District;
                        worksheet.Cell(i + 1, 9).Value = t.Locality;
                        worksheet.Cell(i + 1, 10).Value = db.Counterparty.Find(t.ID_CP).Name;
                        worksheet.Cell(i + 1, 11).Value = t.Purpose;
                        worksheet.Cell(i + 1, 12).Value = t.StartBT;
                        worksheet.Cell(i + 1, 13).Value = t.EndBT;
                        worksheet.Cell(i + 1, 14).Value = t.DifferencesDays;
                        worksheet.Cell(i + 1, 15).Value = t.Cost;
                        worksheet.Cell(i + 1, 16).Value = t.SummCost;
                        worksheet.Cell(i + 1, 17).Value = t.OvernightStay;
                        worksheet.Cell(i + 1, 18).Value = t.CostLiving;
                        worksheet.Cell(i + 1, 19).Value = t.SummLiving;
                        worksheet.Cell(i + 1, 20).Value = t.Fare;
                        worksheet.Cell(i + 1, 21).Value = t.TotalSumm;
                        range22.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        
                        i++;

                    }
                    string u = "A12:U" + Convert.ToInt32(i);
                    var range50 = worksheet.Range(u);
                    //range50.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;


                    //worksheet.Columns(1,21).AdjustToContents(3);
                    worksheet.Rows(9,11).AdjustToContents();
                    worksheet.Rows(12,i).Style.Alignment.WrapText = true;
                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        stream.Flush();
                        return new FileContentResult(stream.ToArray(),
                            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                        {
                            FileDownloadName = $"brands_{DateTime.UtcNow.ToShortDateString()}.xlsx"
                        };
                    
                }
                //return RedirectToAction("Index");
            }
            
            
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
