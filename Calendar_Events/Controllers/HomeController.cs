using Calendar_Events.DBContext;
using Calendar_Events.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar_Events.Controllers
{
    public class HomeController : Controller
    {
        protected db_context dc { get; set; }

        public HomeController(db_context contexts)
        {
            dc = contexts;

        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            var Data = dc.Events.ToList();
            return new JsonResult(Data);
        }

        [HttpPost]
        public JsonResult SaveEvent(Events e)
        {
            var Data = false;
            if (e.EventID > 0) // Update
            {
                //Update the event
                var v = dc.Events.Where(a => a.EventID == e.EventID).FirstOrDefault();
                if (v != null)
                {
                    v.Subject = e.Subject;
                    //v.Start = e.Start;
                    //v.Start = e.strStartDate != null ? Convert.ToDateTime(e.strStartDate) : DateTime.Now;
                    //v.End = e.End;
                    //v.End = e.strEndDate != null ? Convert.ToDateTime(e.strEndDate) : DateTime.Now;
                    e.Start = e.strStartDate != null ? DateTime.ParseExact(e.strStartDate, "dd/MM/yyyy HH:mm tt", null) : DateTime.Now;
                    e.End = e.strEndDate != null ? DateTime.ParseExact(e.strEndDate, "dd/MM/yyyy HH:mm tt", null) : DateTime.Now;
                    v.Description = e.Description;
                    v.IsFullDay = e.IsFullDay;
                    v.ThemeColor = e.ThemeColor;
                }
            }
            else // Add
            {
                
                e.Start = e.strStartDate != null ? DateTime.ParseExact(e.strStartDate, "dd/MM/yyyy HH:mm tt", null) : DateTime.Now;
                e.End = e.strEndDate != null ? DateTime.ParseExact(e.strEndDate, "dd/MM/yyyy HH:mm tt", null) : DateTime.Now;
                dc.Events.Add(e);
            }

            dc.SaveChanges();
            Data = true;


            return new JsonResult(Data);
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var Data = false;

            var v = dc.Events.Where(a => a.EventID == eventID).FirstOrDefault();
            if (v != null)
            {
                dc.Events.Remove(v);
                dc.SaveChanges();
                Data = true;
            }
            return new JsonResult(Data);
        }
    }
}
