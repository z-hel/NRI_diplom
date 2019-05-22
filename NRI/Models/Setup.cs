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

        public int CurrentModeId { get; set; }
        public int? PreviousModeId { get; set; }
        public int? NextModeId { get; set; }
        public int EquipmentId { get; set; }
        public int Duration { get; set; }
        public int Id { get; set; }
    }
}
