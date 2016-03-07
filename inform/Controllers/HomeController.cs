using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using inform.Models;
using inform.WebService;

namespace inform.Controllers
{
    public class HomeController : Controller
    {
        private readonly InFormWebService _incomeWebService;
        public InFormResult InFormResult { get; set; }

        public HomeController()
        {
            _incomeWebService = new InFormWebService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetPredictionFromWebService()
        {
            var passAcc = Request.Form["passAcc"];
            var avgBPM = Request.Form["avgBPM"];
            var sprints = Request.Form["sprints"];
            var topSpeed = Request.Form["topspeed"];
            var ballTouches = Request.Form["balltouches"];

            if (!string.IsNullOrEmpty(avgBPM) && !string.IsNullOrEmpty(sprints)
                && !string.IsNullOrEmpty(topSpeed) &&
                !string.IsNullOrEmpty(ballTouches))
            {
                var resultResponse = _incomeWebService.InvokeRequestResponseService<string>("0",
                    avgBPM, sprints, topSpeed, ballTouches).Result;

                if (resultResponse != null)
                {
                }
            }


            /*
            var gender = Request.Form["gender"];
            var age = Request.Form["age"];

            if (!string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(age))
            {
                var resultResponse = _incomeWebService.InvokeRequestResponseService<ResultOutcome>(gender, age).Result;

                if (resultResponse != null)
                {
                    var result = resultResponse.Results.Output1.Value.Values;
                    PersonResult = new Person
                    {
                        Gender = result[0, 0],
                        Age = Int32.Parse(result[0, 1]),
                        Income = float.Parse(result[0, 3], CultureInfo.InvariantCulture.NumberFormat)
                    };
                }
            } */

            return View("Index");
        }
    }
}