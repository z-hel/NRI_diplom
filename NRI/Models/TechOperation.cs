using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class TechOperation
    {
        private int id;
        private String name;
        private List<Mode> modes;
        private int serialNumber;
        private List<TechOperationNeed> techOperationNeeds;
        private List<TechOperationOut> techOperationOuts;
        
        public string Name { get => name; set => name = value; }
        public List<Mode> Modes { get => modes; set => modes = value; }
        public int SerialNumber { get => serialNumber; set => serialNumber = value; }
        public List<TechOperationNeed> TechOperationNeeds { get => techOperationNeeds; set => techOperationNeeds = value; }
        public List<TechOperationOut> TechOperationOuts { get => techOperationOuts; set => techOperationOuts = value; }
        public int Id { get => id; set => id = value; }
    }
}
