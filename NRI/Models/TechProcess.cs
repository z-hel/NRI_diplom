using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class TechProcess
    {
        //private int id;
        //private String name;
        //private List<TechOperation> techOperations;
        //private String version;
        //private int launchBatch;
        //private int minBatch;
        //private int maxBatch;

        public string Name { get; set; }
        public int NomenclatureId { get; set; }
        public int LaunchBatch { get; set; }
        public int MinBatch { get; set; }
        public int MaxBatch { get; set; }
        public int Id { get; set; }
    }
}
