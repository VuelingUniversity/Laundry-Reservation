using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WundaWash.Core.Models;
using WundaWash.Infra.Mappers;
using WundaWash.ServiceLibrary.Interfaces;

namespace WundaWash.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMachineService _machineService;
        private readonly IPatronService _patronService;

        public HomeController(IMachineService machineService, IPatronService patronService)
        {
            _machineService = machineService;
            _patronService = patronService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}