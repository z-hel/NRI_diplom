using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class Nomenclature
    {
        private int id;
        private String name;
        private List<TechProcess> techProcesses;
        private String receiptType;
        private NomenclatureType nomenclatureType;
        private Nomenclature parentNomenclature;

        public string Name { get => name; set => name = value; }
        public List<TechProcess> TechProcesses { get => techProcesses; set => techProcesses = value; }
        public string ReceiptType { get => receiptType; set => receiptType = value; }
        public NomenclatureType NomenclatureType { get => nomenclatureType; set => nomenclatureType = value; }
        public Nomenclature ParentNomenclature { get => parentNomenclature; set => parentNomenclature = value; }
        public int Id { get => id; set => id = value; }
    }
}
