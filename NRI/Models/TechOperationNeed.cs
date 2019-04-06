using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class TechOperationNeed
    {
        //private int id;
        //private TechOperation techOperation;
        //private Nomenclature nomenclatureNeed;
        //private int count;

        public TechOperation TechOperation { get; set; }
        public Nomenclature NomenclatureNeed { get; set; }
        public int Count { get; set; }
        public int Id { get; set; }
    }
}
