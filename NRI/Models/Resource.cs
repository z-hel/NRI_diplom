using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class Resource
    {
        private int id;
        private String name;
        private Personal personal;
        private Equipment equipment;
        private Tool tool;
        private Calendar calendar;
        private int usageType;
        private bool isAccessibility;
        private float workCost;
        private float setupCost;
        private float downtimeCost;

        public string Name { get => name; set => name = value; }
        public Personal Personal { get => personal; set => personal = value; }
        public Equipment Equipment { get => equipment; set => equipment = value; }
        public Tool Tool { get => tool; set => tool = value; }
        public Calendar Calendar { get => calendar; set => calendar = value; }
        public int UsageType { get => usageType; set => usageType = value; }
        public bool IsAccessibility { get => isAccessibility; set => isAccessibility = value; }
        public float WorkCost { get => workCost; set => workCost = value; }
        public float SetupCost { get => setupCost; set => setupCost = value; }
        public float DowntimeCost { get => downtimeCost; set => downtimeCost = value; }
        public int Id { get => id; set => id = value; }
    }
}
