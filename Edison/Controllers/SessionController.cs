using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edison.Controllers
{
    public class SessionController : Controller
    {
        public void SetSessionContent(string nameSession, object data)
        {
            System.Web.HttpContext.Current.Session[nameSession] = data;
        }

        public object GetSessionContent(string nameSession)
        {
            return System.Web.HttpContext.Current.Session[nameSession];
        }
    }
}