using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class TechOperationOut
    {
        //private int id;
        //private TechOperation techOperation;
        //private Nomenclature nomenclatureOut;
        //private int count;

        public TechOperation TechOperation { get; set; }
        public Nomenclature NomenclatureOut { get; set; }
        public int Count { get; set; }
        public int Id { get; set; }
    }
}
