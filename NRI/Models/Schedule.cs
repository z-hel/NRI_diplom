using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class Schedule
    {
        private int id;
        private String name;
        private DateTime dateTimeStart;
        private DateTime dateTimeEnd;
        private Pattern pattern;
        private bool isAccessisAccessibility;

        public string Name { get => name; set => name = value; }
        public DateTime DateTimeStart { get => dateTimeStart; set => dateTimeStart = value; }
        public DateTime DateTimeEnd { get => dateTimeEnd; set => dateTimeEnd = value; }
        public Pattern Pattern { get => pattern; set => pattern = value; }
        public bool IsAccessisAccessibility { get => isAccessisAccessibility; set => isAccessisAccessibility = value; }
        public int Id { get => id; set => id = value; }
    }
}
