using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIRouting.Models
{
    public class TranscriptModel
    {
        public string StudentName { get; set; }
        public string StudentId { get; set; }
        public QuarterModel[] Quarters { get; set; }
        
    }

    public class QuarterModel
    {
        public string Term { get; set; }
        public string ClassName { get; set; }
        public float Grade { get; set; }
    }

}