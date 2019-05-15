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
    public class SetupController : ControllerBase
    {
        ApplicationContext appContext;

        public SetupController(ApplicationContext context)
        {
            this.appContext = context;
        }

        // GET: api/setup
        [HttpGet]
        public List<Setup> Get()
        {
            return appContext.setups.ToList();
        }

        // GET: api/setup/5
        [HttpGet("{id}", Name = "GetSetup")]
        public IActionResult Get(int id)
        {
            Setup setup;
            
            setup = appContext.setups.FirstOrDefault(x => x.Id == id);
          
            if (setup == null)
                return NotFound();
            return new ObjectResult(setup);
        }

        // POST: api/setup
        [HttpPost]
        public IActionResult Post([FromBody] Setup setup)
        {
            if (setup == null)
                return BadRequest();
            appContext.setups.Add(setup);
            appContext.SaveChanges();
            return Ok();
        }

        // PUT: api/setup/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Setup setup)
        {
            if (setup == null)
                return BadRequest();

            if (!appContext.setups.Any(x=>x.Id == setup.Id))
                return NotFound();

            appContext.Update(setup);
            appContext.SaveChanges();
            return Ok();
        }

        // DELETE: api/setup/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Setup setup;

            try
            {
                setup = appContext.setups.FirstOrDefault(x => x.Id == id);
            }
            catch (ArgumentNullException e)
            {
                return NotFound();
            }
            
            appContext.setups.Remove(setup);
            appContext.SaveChanges();
            return Ok();
        }
    }
}
