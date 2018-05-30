using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Edison.Models;

namespace Edison.Controllers
{
    public class HomeController : Controller
    {
        
        
        public HomeController()
        {
            System.Web.HttpContext.Current.Session["Psychics"] = 
                System.Web.HttpContext.Current.Session["Psychics"] ?? new List<Psychic>()
                        {
                            new Psychic() {Id=0,Name = "Psychic 1", Confidence = 0},
                            new Psychic() {Id=1,Name = "Psychic 2", Confidence = 0},
                            new Psychic() {Id =2,Name = "Psychic 3", Confidence = 0},

                        };

            System.Web.HttpContext.Current.Session["PlayerNumber"] =
                System.Web.HttpContext.Current.Session["PlayerNumber"] ?? new List<int>();






        }

        public ActionResult Index()
        {
            return View((List<Psychic>)System.Web.HttpContext.Current.Session["Psychics"]);
        }

        public JsonResult AddConfidence(int idPsychic)
        {
            List<Psychic> psys = (List<Psychic>)System.Web.HttpContext.Current.Session["Psychics"];
            psys.Find(psy => psy.Id == idPsychic).Confidence++;
            Session["Psychics"] = psys;
            return Json(200, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPsychics()
        {
            return Json((List<Psychic>)System.Web.HttpContext.Current.Session["Psychics"], JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPlayer()
        {
            return Json((List<Psychic>)System.Web.HttpContext.Current.Session["Psychics"], JsonRequestBehavior.AllowGet);
        }

        public ActionResult TestPsychics(int number)
        {
            var playerNumber = (List<int>) System.Web.HttpContext.Current.Session["PlayerNumber"];
            var psychics = (List<Psychic>) System.Web.HttpContext.Current.Session["Psychics"];

            playerNumber.Add(number);
            foreach (var psy in psychics)
            {
                psy.GetPrediction(number);
            }
            return Json(1, JsonRequestBehavior.AllowGet);
        }
    }
}