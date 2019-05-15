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
    public class PatternController : ControllerBase
    {
        ApplicationContext appContext;

        public PatternController(ApplicationContext context)
        {
            this.appContext = context;
        }

        // GET: api/pattern
        [HttpGet]
        public List<Pattern> Get()
        {
            return appContext.patterns.ToList();
        }

        // GET: api/pattern/5
        [HttpGet("{id}", Name = "GetPattern")]
        public IActionResult Get(int id)
        {
            Pattern pattern;
            
            pattern = appContext.patterns.FirstOrDefault(x => x.Id == id);
          
            if (pattern == null)
                return NotFound();
            return new ObjectResult(pattern);
        }

        // POST: api/pattern
        [HttpPost]
        public IActionResult Post([FromBody] Pattern pattern)
        {
            if (pattern == null)
                return BadRequest();
            appContext.patterns.Add(pattern);
            appContext.SaveChanges();
            return Ok();
        }

        // PUT: api/pattern/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pattern pattern)
        {
            if (pattern == null)
                return BadRequest();

            if (!appContext.patterns.Any(x=>x.Id == pattern.Id))
                return NotFound();

            appContext.Update(pattern);
            appContext.SaveChanges();
            return Ok();
        }

        // DELETE: api/pattern/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Pattern pattern;

            try
            {
                pattern = appContext.patterns.FirstOrDefault(x => x.Id == id);
            }
            catch (ArgumentNullException e)
            {
                return NotFound();
            }
            
            appContext.patterns.Remove(pattern);
            appContext.SaveChanges();
            return Ok();
        }
    }
}
