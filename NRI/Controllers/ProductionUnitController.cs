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
    public class ProductionUnitController : ControllerBase
    {
        ApplicationContext appContext;

        public ProductionUnitController(ApplicationContext context)
        {
            this.appContext = context;
        }

        // GET: api/productionUnit
        [HttpGet]
        public List<ProductionUnit> Get()
        {
            return appContext.productionUnits.ToList();
        }

        // GET: api/productionUnit/5
        [HttpGet("{id}", Name = "GetProductionUnit")]
        public IActionResult Get(int id)
        {
            ProductionUnit productionUnit;
            
            productionUnit = appContext.productionUnits.FirstOrDefault(x => x.Id == id);
          
            if (productionUnit == null)
                return NotFound();
            return new ObjectResult(productionUnit);
        }

        // POST: api/productionUnit
        [HttpPost]
        public IActionResult Post([FromBody] ProductionUnit productionUnit)
        {
            if (productionUnit == null)
                return BadRequest();
            appContext.productionUnits.Add(productionUnit);
            appContext.SaveChanges();
            return Ok(productionUnit);
        }

        // PUT: api/productionUnit/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductionUnit productionUnit)
        {
            if (productionUnit == null)
                return BadRequest();

            if (!appContext.productionUnits.Any(x=>x.Id == productionUnit.Id))
                return NotFound();

            appContext.Update(productionUnit);
            appContext.SaveChanges();
            return Ok(productionUnit);
        }

        // DELETE: api/productionUnit/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ProductionUnit productionUnit;

            try
            {
                productionUnit = appContext.productionUnits.FirstOrDefault(x => x.Id == id);
            }
            catch (ArgumentNullException e)
            {
                return NotFound();
            }
            
            appContext.productionUnits.Remove(productionUnit);
            appContext.SaveChanges();
            return Ok(productionUnit);
        }
    }
}
