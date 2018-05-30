using System.Collections.Generic;
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
                            new Psychic(0, "Psychic 0"),
                            new Psychic(1, "Psychic 1"),
                            new Psychic(2, "Psychic 2"),

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
            var psys = (List<Psychic>) System.Web.HttpContext.Current.Session["Psychics"];
            return Json(psys, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPlayer()
        {
            return Json((List<int>)System.Web.HttpContext.Current.Session["PlayerNumber"], JsonRequestBehavior.AllowGet);
        }

        public ActionResult TestPsychics(int? number)
        {
            int numb = number ?? 0;
            if(numb <10 || numb > 99)
            {
                return Json("Введите двузначное число", JsonRequestBehavior.AllowGet);
            }
            var playerNumber = (List<int>) System.Web.HttpContext.Current.Session["PlayerNumber"];
            var psychics = (List<Psychic>) System.Web.HttpContext.Current.Session["Psychics"];

            playerNumber.Add(numb);
            foreach (var psy in psychics)
            {
                psy.GetPrediction(numb);
            }

            System.Web.HttpContext.Current.Session["Psychics"] = psychics;
            return Json(0, JsonRequestBehavior.AllowGet);
        }
    }
}