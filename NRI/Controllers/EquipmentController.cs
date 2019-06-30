using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NRI.Models;

namespace NRI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        ApplicationContext appContext;

        public EquipmentController(ApplicationContext context)
        {
            this.appContext = context;
        }

        // GET: api/equipment
        [HttpGet]
        public List<Equipment> Get()
        {
            return appContext.equipments.ToList();
        }

        // GET: api/equipment/5
        [HttpGet("{id}", Name = "GetEquipment")]
        public IActionResult Get(int id)
        {
            Equipment equipment;
            
            equipment = appContext.equipments.FirstOrDefault(x => x.Id == id);
          
            if (equipment == null)
                return NotFound();
            return new ObjectResult(equipment);
        }

        // POST: api/equipment
        [HttpPost]
        public IActionResult Post([FromBody] Equipment equipment)
        {
            if (equipment == null)
                return BadRequest();
            appContext.equipments.Add(equipment);
            appContext.SaveChanges();
            return Ok(equipment);
        }

        [HttpPost] //("import")
        [Route("import")]
        public IActionResult Import()
        {
            IFormFile fileExcel = Request.Form.Files[0];
            if (fileExcel != null)
            {

                List<Equipment> equipments = new List<Equipment>();
                try
                {
                    using (var package = new OfficeOpenXml.ExcelPackage())
                    {

                        using (var stream = fileExcel.OpenReadStream())
                        {
                            package.Load(stream);
                        }

                        var workSheet = package.Workbook.Worksheets.First();
                        int totalRows = workSheet.Dimension.Rows;

                        for (int i = 2; i <= totalRows; i++)
                        {
                            Equipment equipment = new Equipment();
                            equipment.Id = int.Parse(workSheet.Cells[i, 1].Value.ToString());
                            equipment.Name = workSheet.Cells[i, 2].Value.ToString();
                            equipment.Code = workSheet.Cells[i, 3].Value.ToString();

                            equipments.Add(equipment);
                        }

                    }
                    IEnumerable<Equipment> distinctEquipment = equipments.Distinct();
                    foreach (Equipment equipment in distinctEquipment)
                    {
                        IActionResult result = this.Get(equipment.Id);
                        //Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! TECHPROCESS " + result.GetType());
                        if (result.ToString().Equals("Microsoft.AspNetCore.Mvc.NotFoundResult"))
                        {
                            this.Post(equipment);
                        }
                    
                    }
                    return Ok(equipments);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! " + ex.Message);
                }

            }
            return RedirectToAction("");
        }

        // PUT: api/equipment/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Equipment equipment)
        {
            if (equipment == null)
                return BadRequest();

            if (!appContext.equipments.Any(x=>x.Id == equipment.Id))
                return NotFound();

            appContext.Update(equipment);
            appContext.SaveChanges();
            return Ok(equipment);
        }

        // DELETE: api/equipment/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Equipment equipment;

            try
            {
                equipment = appContext.equipments.FirstOrDefault(x => x.Id == id);
            }
            catch (ArgumentNullException e)
            {
                return NotFound();
            }
            
            appContext.equipments.Remove(equipment);
            appContext.SaveChanges();
            return Ok(equipment);
        }
    }
}
