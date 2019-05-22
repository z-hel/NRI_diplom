using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class Schedule
    {
        //private int id;
        //private String name;
        //private DateTime dateTimeStart;
        //private DateTime dateTimeEnd;
        //private Pattern pattern;
        //private bool isAccessisAccessibility;

        public string Name { get; set; }
        public string DateTimeStart { get; set; }
        public string DateTimeEnd { get; set; }
        public int PatternId { get; set; }
        public int ResourceId { get; set; }
        public bool IsAccessibility { get; set; }
        public int Id { get; set; }
    }
}
