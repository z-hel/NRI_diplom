using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class TechOperationOut
    {
        private int id;
        private TechOperation techOperation;
        private Nomenclature nomenclatureOut;
        private int count;

        public TechOperation TechOperation { get => techOperation; set => techOperation = value; }
        public Nomenclature NomenclatureOut { get => nomenclatureOut; set => nomenclatureOut = value; }
        public int Count { get => count; set => count = value; }
        public int Id { get => id; set => id = value; }
    }
}
