using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class Mode
    {
        //private int id;
        //private String name;
        //private List<Resource> resources;
        //private String time; //TODO время подготовки, штучной обработки и т.д.

        public string Name { get; set; }
        public List<Resource> Resources { get; set; }
        public string Time { get; set; }
        public int Id { get ; set; }
    }
}
