using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NRI.Models;

namespace NRI.Services
{
    public class ModelService : IModelService
    {
        public IEnumerable<String> List()
        {
            return new List<String>
            {
                "Выходы",
                "Графики",
                "Инструменты",
                "Наладки",
                "Номенклатура",
                "Оборудование",
                "Персонал",
                "Потребности",
                "Производственные подразделения",
                "Режимы",
                "Ресурсы",
                "Технологические операции",
                "Технологические процессы",
                "Шаблоны"
            };
        }
    }

    public interface IModelService
    {
        IEnumerable<String> List();
    }
}
