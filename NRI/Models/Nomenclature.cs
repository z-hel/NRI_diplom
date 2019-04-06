using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class Nomenclature
    {
        //private int id;
        //private String name;
        //private List<TechProcess> techProcesses;
        //private String receiptType;
        //private NomenclatureType nomenclatureType;
        //private Nomenclature parentNomenclature;

        public string Name { get; set; }
        public List<TechProcess> TechProcesses { get; set; }
        public string ReceiptType { get; set; }
        public NomenclatureType NomenclatureType { get; set; }
        public Nomenclature ParentNomenclature { get; set; }
        public int Id { get ; set; }
    }
}
