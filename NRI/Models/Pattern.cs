using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class Pattern
    {
        private String name;
        private DateTime dateTimeStart;
        private DateTime dateTimeEnd;
        private int id;

        public string Name { get => name; set => name = value; }
        public DateTime DateTimeStart { get => dateTimeStart; set => dateTimeStart = value; }
        public DateTime DateTimeEnd { get => dateTimeEnd; set => dateTimeEnd = value; }
        public int Id { get => id; set => id = value; }
    }
}
