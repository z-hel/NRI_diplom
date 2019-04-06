using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class Setup
    {
        private int id;
        private Mode currentMode;
        private Mode previousMode;
        private Mode nextMode;

        public Mode CurrentMode { get => currentMode; set => currentMode = value; }
        public Mode PreviousMode { get => previousMode; set => previousMode = value; }
        public Mode NextMode { get => nextMode; set => nextMode = value; }
        public int Id { get => id; set => id = value; }
    }
}
