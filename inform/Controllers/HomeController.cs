﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
        public InFormPredictionOutput InFormPredictionOutput { get; set; }

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

            System.Threading.Thread.Sleep(4000);

            var passAcc = Request.Form["passAcc"];
            var avgBPM = Request.Form["avgBPM"];
            var sprints = Request.Form["sprints"];
            var topSpeed = Request.Form["topspeed"];
            var ballTouches = Request.Form["balltouches"];

            if (!string.IsNullOrEmpty(avgBPM) && !string.IsNullOrEmpty(sprints)
                && !string.IsNullOrEmpty(topSpeed) &&
                !string.IsNullOrEmpty(ballTouches))
            {
                var resultResponse = _incomeWebService.InvokeRequestResponseService<InFormResult>("0",
                    avgBPM, sprints, topSpeed, ballTouches).Result;

                if (resultResponse != null)
                {
                    var result = resultResponse.Results.InFormOutput.Value.Values;

                    InFormPredictionOutput = new InFormPredictionOutput
                    {
                        PredictionBPM = float.Parse(result[0][0], CultureInfo.InvariantCulture.NumberFormat),
                        PredictionBallTouches = float.Parse(result[0][1], CultureInfo.InvariantCulture.NumberFormat),
                        PredictionSprints = float.Parse(result[0][2], CultureInfo.InvariantCulture.NumberFormat),
                        PredictionTopSpeed = float.Parse(result[0][3], CultureInfo.InvariantCulture.NumberFormat)
                    };
                }
            }

            return View("Index");
        }
    }
}