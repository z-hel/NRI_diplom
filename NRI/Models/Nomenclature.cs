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
        public int ReceiptTypeId { get; set; }
        public int NomenclatureTypeId { get; set; }
        public int? ParentNomenclatureId { get; set; }
        public string Code { get; set; }
        public int Id { get ; set; }

        //public Nomenclature(string name, List<TechProcess> processes, string receiptType, NomenclatureType nType, Nomenclature nomParent, int id)
        //{
        //    this.Id = id;
        //    this.Name = name;
        //    this.NomenclatureType = nType;
        //    this.ParentNomenclature = nomParent;
        //    this.ReceiptType = receiptType;
        //    this.TechProcesses = processes;
        //}

        //public Nomenclature(string name, int id)
        //{
        //    this.Name = name;
        //    this.Id = id;
        //}
    }
}
