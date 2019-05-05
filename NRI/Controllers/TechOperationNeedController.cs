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
    public class TechOperationNeedController : ControllerBase
    {
        ApplicationContext appContext;

        public TechOperationNeedController(ApplicationContext context)
        {
            this.appContext = context;
        }

        // GET: api/TechOperationNeed
        [HttpGet]
        public List<TechOperationNeed> Get()
        {
            return appContext.techOperationNeeds.ToList();
        }

        // GET: api/TechOperationNeed/5
        [HttpGet("{id}", Name = "GetTechOperationNeed")]
        public IActionResult Get(int id)
        {
            TechOperationNeed techOperationNeed;
            techOperationNeed = appContext.techOperationNeeds.FirstOrDefault(x => x.Id == id);
            
            if (techOperationNeed == null)
                return NotFound();
            return new ObjectResult(techOperationNeed);
        }

        // POST: api/TechOperationNeed
        [HttpPost]
        public IActionResult Post([FromBody] TechOperationNeed techOperationNeed)
        {
            if (techOperationNeed == null)
                return BadRequest();
            appContext.techOperationNeeds.Add(techOperationNeed);
            appContext.SaveChanges();
            return Ok();
        }

        // PUT: api/TechOperationNeed/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TechOperationNeed techOperationNeed)
        {
            
            if (techOperationNeed == null)
                return BadRequest();

            if (!appContext.techOperationNeeds.Any(x=>x.Id == techOperationNeed.Id))
                return NotFound();

            appContext.Update(techOperationNeed);
            appContext.SaveChanges();
            return Ok();
        }

        // DELETE: api/TechOperationNeed/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TechOperationNeed techOperationNeed;

            try
            {
                techOperationNeed = appContext.techOperationNeeds.FirstOrDefault(x => x.Id == id);
            }
            catch (ArgumentNullException e)
            {
                return NotFound();
            }
            
            appContext.techOperationNeeds.Remove(techOperationNeed);
            appContext.SaveChanges();
            return Ok();
        }
    }
}
