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
    public class ModeController : ControllerBase
    {
        ApplicationContext appContext;

        public ModeController(ApplicationContext context)
        {
            this.appContext = context;
        }

        // GET: api/Mode
        [HttpGet]
        public List<Mode> Get()
        {
            return appContext.modes.ToList();
        }

        // GET: api/Mode/5
        [HttpGet("{id}", Name = "GetMode")]
        public IActionResult Get(int id)
        {
            Mode mode;
            
            mode = appContext.modes.FirstOrDefault(x => x.Id == id);
          
            if (mode == null)
                return NotFound();
            return new ObjectResult(mode);
        }

        // POST: api/Mode
        [HttpPost]
        public IActionResult Post([FromBody] Mode mode)
        {
            if (mode == null)
                return BadRequest();
            appContext.modes.Add(mode);
            appContext.SaveChanges();
            return Ok(mode);
        }

        // PUT: api/Mode/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Mode mode)
        {
            if (mode == null)
                return BadRequest();

            if (!appContext.modes.Any(x=>x.Id == mode.Id))
                return NotFound();

            appContext.Update(mode);
            appContext.SaveChanges();
            return Ok(mode);
        }

        // DELETE: api/Mode/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Mode mode;

            try
            {
                mode = appContext.modes.FirstOrDefault(x => x.Id == id);
            }
            catch (ArgumentNullException e)
            {
                return NotFound();
            }
            
            appContext.modes.Remove(mode);
            appContext.SaveChanges();
            return Ok(mode);
        }
    }
}
