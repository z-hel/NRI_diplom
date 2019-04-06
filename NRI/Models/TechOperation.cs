using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class TechOperation
    {
        //private int id;
        //private String name;
        //private List<Mode> modes;
        //private int serialNumber;
        //private List<TechOperationNeed> techOperationNeeds;
        //private List<TechOperationOut> techOperationOuts;
        
        public string Name { get; set; }
        public List<Mode> Modes { get; set; }
        public int SerialNumber { get; set; }
        public List<TechOperationNeed> TechOperationNeeds { get; set; }
        public List<TechOperationOut> TechOperationOuts { get; set; }
        public int Id { get; set; }
    }
}
