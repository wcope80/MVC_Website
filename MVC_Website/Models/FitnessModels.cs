using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Website.Models
{
    public class FitnessModels
    {
    }




    public class MaxAttempt
    {
        [Key]
        public int MaxAttemptId { get; set; }
        public string Exercise { get; set; }
        public int Weight { get; set; }
        public int Reps { get; set; }
        public int CalculatedMax { get; set; }
        public DateTime MaxDate { get; set; }
    }

    public class ClpmDirectory
    {
        public List<Unit> directory { get; set; }
    }

    public class Unit
    {
        public string unitName { get; set; }
        public List<CLPM> Clpms { get; set; }

    }



    public class CLPM
    {
        public string name { get; set; }
        public string rank { get; set; }
        public string squadron { get; set; }

    }
}