using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inform.Models
{
    public class InFormData
    {
        public DateTime? Date { get; set; }
        public int PassAccuracyInPercentage { get; set; }
        public int AvgBPM { get; set; }
        public int NumberOfSprints { get; set; }
        public int TopSpeed { get; set; }
        public int BallTouches { get; set; }
        public int InMatchKMRan { get; set; }
        public int InMatchGoals { get; set; }
        public int InMatchAssists { get; set; }
        public int InMatchAvgBPM { get; set; }
        public int InMatchSprints { get; set; }
        public int InMatchTopSpeed { get; set; }
        public int InMatchBallTouches { get; set; }
        public int PerformancePercentage { get; set; }
    }
}