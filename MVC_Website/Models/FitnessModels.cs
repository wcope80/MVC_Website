using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Website.Models
{
    public class FitnessModels
    {
    }

    public class MaxAttempt
    {
        public int MaxAttemptId { get; set; }
        public string Exercise { get; set; }
        public int Weight { get; set; }
        public int Reps { get; set; }
        public int CalculatedMax { get; set; }
        public DateTime MaxDate { get; set; }
    }
}