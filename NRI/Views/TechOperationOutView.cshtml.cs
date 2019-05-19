using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NRI.Models;
using NRI.Controllers;

namespace NRI.Views
{
    public class TechOperationOutViewModel : PageModel
    {
        private static ApplicationContext context;
        TechOperationOutController controller = new TechOperationOutController(context);

        public List<TechOperationOut> OnGet()
        {
            List<TechOperationOut> list = controller.Get();
            //ViewBag.list = list;
            return list;
        }

        public IActionResult OnGetById(int id)
        {
            IActionResult result = controller.Get(id);
            //ViewBag.ById = result;
            return result;
        }
    }
}