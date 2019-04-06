using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class ProductionUnit
    {
        private int id;
        private String name;
        private List<Resource> resources;
        private ProductionUnit parentProductionUnit;

        public string Name { get => name; set => name = value; }
        public ProductionUnit ParentProductionUnit { get => parentProductionUnit; set => parentProductionUnit = value; }
        public List<Resource> Resources { get => resources; set => resources = value; }
        public int Id { get => id; set => id = value; }
    }
}
