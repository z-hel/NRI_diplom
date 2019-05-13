﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class Calendar
    {
        public string Name { get; set; }
        public List<Schedule> Schedules { get; set; }
        public CalendarDisplayType DisplayType { get; set; }
        public int Id { get; set; }
    }
}
