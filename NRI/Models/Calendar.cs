using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class Calendar
    {
        private int id;
        private String name;
        private List<Schedule> schedules;
        private String viewType;

        public string Name { get => name; set => name = value; }
        public List<Schedule> Schedules { get => schedules; set => schedules = value; }
        public string ViewType { get => viewType; set => viewType = value; }
        public int Id { get => id; set => id = value; }
    }
}
