﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class ProductionUnit
    {
        //private int id;
        //private String name;
        //private List<Resource> resources;
        //private ProductionUnit parentProductionUnit;

        public string Name { get; set; }
        public int ParentProductionUnitId { get; set; }
        public int Id { get; set; }
    }
}
