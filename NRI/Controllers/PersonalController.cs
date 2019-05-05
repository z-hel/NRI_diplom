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
    public class PersonalController : ControllerBase
    {
        ApplicationContext appContext;

        public PersonalController(ApplicationContext context)
        {
            this.appContext = context;
        }

        // GET: api/personal
        [HttpGet]
        public List<Personal> Get()
        {
            return appContext.personals.ToList();
        }

        // GET: api/personal/5
        [HttpGet("{id}", Name = "GetPersonal")]
        public IActionResult Get(int id)
        {
            Personal personal;
            
            personal = appContext.personals.FirstOrDefault(x => x.Id == id);
          
            if (personal == null)
                return NotFound();
            return new ObjectResult(personal);
        }

        // POST: api/personal
        [HttpPost]
        public IActionResult Post([FromBody] Personal personal)
        {
            if (personal == null)
                return BadRequest();
            appContext.personals.Add(personal);
            appContext.SaveChanges();
            return Ok();
        }

        // PUT: api/personal/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Personal personal)
        {
            if (personal == null)
                return BadRequest();

            if (!appContext.personals.Any(x=>x.Id == personal.Id))
                return NotFound();

            appContext.Update(personal);
            appContext.SaveChanges();
            return Ok();
        }

        // DELETE: api/personal/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Personal personal;

            try
            {
                personal = appContext.personals.FirstOrDefault(x => x.Id == id);
            }
            catch (ArgumentNullException e)
            {
                return NotFound();
            }
            
            appContext.personals.Remove(personal);
            appContext.SaveChanges();
            return Ok();
        }
    }
}
