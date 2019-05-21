using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NRI.Models
{
    public class Resource
    {
        //    private int id;
        //    private String name;
        //    private Personal personal;
        //    private Equipment equipment;
        //    private Tool tool;
        //    private Calendar calendar;
        //    private int usageType;
        //    private bool isAccessibility;
        //    private float workCost;
        //    private float setupCost;
        //    private float downtimeCost;
        
        public int PersonalId { get; set; }
        public int EquipmentId { get; set; }
        public int ToolId { get; set; }
        public int CalendarId { get; set; }
        public int UsageTypeId { get; set; }
        public int ModeId { get; set; }
        public int ProductionUnitId { get; set; }
        public bool IsAccessibility { get; set; }
        public float WorkCost { get; set; }
        public float SetupCost { get; set ; }
        public float DowntimeCost { get; set; }
        public int Id { get; set; }
    }
    
}
