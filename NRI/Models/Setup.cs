using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class Setup
    {
        //private int id;
        //private Mode currentMode;
        //private Mode previousMode;
        //private Mode nextMode;

        public Mode CurrentMode { get; set; }
        public Mode PreviousMode { get; set; }
        public Mode NextMode { get; set; }
        public int Duration { get; set; }
        public int Id { get; set; }
    }
}
