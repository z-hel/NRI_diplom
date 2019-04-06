using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class Mode
    {
        private int id;
        private String name;
        private List<Resource> resources;
        private String time; //TODO время подготовки, штучной обработки и т.д.

        public string Name { get => name; set => name = value; }
        public List<Resource> Resources { get => resources; set => resources = value; }
        public string Time { get => time; set => time = value; }
        public int Id { get => id; set => id = value; }
    }
}
