using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class Tool
    {
        private int id;
        private String name;
        private int wearCount;

        public string Name { get => name; set => name = value; }
        public int WearCount { get => wearCount; set => wearCount = value; }
        public int Id { get => id; set => id = value; }
    }
}
