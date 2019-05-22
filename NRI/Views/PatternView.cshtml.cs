using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NRI.Controllers;
using NRI.Models;
using Microsoft.AspNetCore.Http;

namespace NRI.Views
{
    public class PatternViewModel : PageModel
    {
        public void OnGet()
        {

        }
        //private static ApplicationContext context;
        //TechOperationOutController controller = new TechOperationOutController(context);

        //public List<TechOperationOut> OnGet()
        //{
        //    List<TechOperationOut> list = controller.Get();
        //    return list;
        //    //ViewBag.list = list;
        //    //return View(list);
        //}

        //public IActionResult OnGetById(int id)
        //{
        //    IActionResult result = controller.Get(id);
        //    //ViewBag.ById = result;
        //    return result;
        //}
    }
}