using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class Personal
    {
        private String name;
        private String qualification;
        private int change;
        private int id;

        public string Name { get => name; set => name = value; }
        public string Qualification { get => qualification; set => qualification = value; }
        public int Change { get => change; set => change = value; }
        public int Id { get => id; set => id = value; }
    }
}
