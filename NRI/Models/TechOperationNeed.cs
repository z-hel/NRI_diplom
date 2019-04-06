using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class TechOperationNeed
    {
        private int id;
        private TechOperation techOperation;
        private Nomenclature nomenclatureNeed;
        private int count;

        public TechOperation TechOperation { get => techOperation; set => techOperation = value; }
        public Nomenclature NomenclatureNeed { get => nomenclatureNeed; set => nomenclatureNeed = value; }
        public int Count { get => count; set => count = value; }
        public int Id { get => id; set => id = value; }
    }
}
