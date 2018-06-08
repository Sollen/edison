using System.Collections.Generic;
using System.Web.Mvc;
using Edison.Models;

namespace Edison.Controllers
{
    public class HomeController : Controller
    {
        private readonly SessionController _session;


        public HomeController()
        {
            _session = new SessionController();
            _session.SetSessionContent("Psychics", _session.GetSessionContent("Psychics") ?? 
                    new List<Psychic>()
                    {
                        new Psychic(0, "Psychic 0"),
                        new Psychic(1, "Psychic 1"),
                        new Psychic(2, "Psychic 2"),

                    });

            _session.SetSessionContent("PlayerNumber", _session.GetSessionContent("PlayerNumber") ?? new List<int>());
           






        }

        public ActionResult Index()
        {
            return View(_session.GetSessionContent("Psychics") as List<Psychic>);
        }

        public JsonResult AddConfidence(int idPsychic)
        {
            List<Psychic> psys = _session.GetSessionContent("Psychics") as List<Psychic>;
            psys.Find(psy => psy.Id == idPsychic).Confidence++;
            _session.SetSessionContent("Psychics", psys);
            return Json(200, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPsychics()
        {
            var psys = _session.GetSessionContent("Psychics") as List<Psychic>;
            return Json(psys, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPlayer()
        {
            return Json(_session.GetSessionContent("PlayerNumber") as List<int>, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TestPsychics(int? number)
        {
            int numb = number ?? 0;
            if(numb <10 || numb > 99)
            {
                return Json("Введите двузначное число", JsonRequestBehavior.AllowGet);
            }
            var playerNumber = _session.GetSessionContent("PlayerNumber") as List<int> ?? new List<int>();
            var psychics = _session.GetSessionContent("Psychics") as List<Psychic> ?? new List<Psychic>();

            playerNumber.Add(numb);
            foreach (var psy in psychics)
            {

                psy.Confidence = numb == psy.GetPrediction() ? ++psy.Confidence : --psy.Confidence; ;
            }

            _session.SetSessionContent("Psychics", psychics);
            return Json(0, JsonRequestBehavior.AllowGet);
        }
    }
}