using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace inform.Models
{
    public class InFormPredictionOutput
    {
        public double PredictionBPM { get; set; }
        public double PredictionBallTouches { get; set; }
        public double PredictionSprints { get; set; }
        public double PredictionTopSpeed { get; set; }
    }
}