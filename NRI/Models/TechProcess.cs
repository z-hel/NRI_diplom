using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class TechProcess
    {
        private int id;
        private String name;
        private List<TechOperation> techOperations;
        private String version;
        private int launchBatch;
        private int minBatch;
        private int maxBatch;

        public string Name { get => name; set => name = value; }
        public List<TechOperation> TechOperations { get => techOperations; set => techOperations = value; }
        public string Version { get => version; set => version = value; }
        public int LaunchBatch { get => launchBatch; set => launchBatch = value; }
        public int MinBatch { get => minBatch; set => minBatch = value; }
        public int MaxBatch { get => maxBatch; set => maxBatch = value; }
        public int Id { get => id; set => id = value; }
    }
}
