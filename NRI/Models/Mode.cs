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
        public string SingleProcessingTime { get; set; } //Продолжительность обработки 1 шт. изделия
        public string ExecOperationTime { get; set; } //Заключительное время выполнения операции
        public string ExecResourceTime { get; set; } //Заключительное время использования ресурса
        public int Id { get ; set; }
    }
}
