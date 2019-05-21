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
    public class TechOperationController : ControllerBase
    {
        ApplicationContext appContext;

        public TechOperationController(ApplicationContext context)
        {
            this.appContext = context;
        }

        // GET: api/TechOperation
        [HttpGet]
        public List<TechOperation> Get()
        {
            return appContext.techOperations.ToList();
        }

        // GET: api/TechOperation/5
        [HttpGet("{id}", Name = "GetTechOperation")]
        public IActionResult Get(int id)
        {
            TechOperation techOperation;
            techOperation = appContext.techOperations.FirstOrDefault(x => x.Id == id);
            
            if (techOperation == null)
                return NotFound();
            return new ObjectResult(techOperation);
        }

        // POST: api/TechOperation
        [HttpPost]
        public IActionResult Post([FromBody] TechOperation techOperation)
        {
            if (techOperation == null)
                return BadRequest();
            appContext.techOperations.Add(techOperation);
            appContext.SaveChanges();
            return Ok(techOperation);
        }

        // PUT: api/TechOperation/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TechOperation techOperation)
        {
            
            if (techOperation == null)
                return BadRequest();

            if (!appContext.techOperations.Any(x=>x.Id == techOperation.Id))
                return NotFound();

            appContext.Update(techOperation);
            appContext.SaveChanges();
            return Ok(techOperation);
        }

        // DELETE: api/TechOperation/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TechOperation techOperation;

            try
            {
                techOperation = appContext.techOperations.FirstOrDefault(x => x.Id == id);
            }
            catch (ArgumentNullException e)
            {
                return NotFound();
            }
            
            appContext.techOperations.Remove(techOperation);
            appContext.SaveChanges();
            return Ok(techOperation);
        }
    }
}
