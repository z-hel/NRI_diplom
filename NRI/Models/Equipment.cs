using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class Equipment
    {

        private int id;
        private String name;
        private List<Setup> setups; //TODO list?

        public string Name { get => name; set => name = value; }
        public List<Setup> Setups { get => setups; set => setups = value; }
        public int Id { get => id; set => id = value; }
    }
}
