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
    public class ResourceController : ControllerBase
    {
        ApplicationContext appContext;

        public ResourceController(ApplicationContext context)
        {
            this.appContext = context;
        }

        // GET: api/resource
        [HttpGet]
        public List<Resource> Get()
        {
            return appContext.resources.ToList();
        }

        // GET: api/resource/5
        [HttpGet("{id}", Name = "GetResource")]
        public IActionResult Get(int id)
        {
            Resource resource;
            
            resource = appContext.resources.FirstOrDefault(x => x.Id == id);
          
            if (resource == null)
                return NotFound();
            return new ObjectResult(resource);
        }

        // POST: api/resource
        [HttpPost]
        public IActionResult Post([FromBody] Resource resource)
        {
            if (resource == null)
                return BadRequest();
            appContext.resources.Add(resource);
            appContext.SaveChanges();
            return Ok(resource);
        }

        // PUT: api/resource/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Resource resource)
        {
            if (resource == null)
                return BadRequest();

            if (!appContext.resources.Any(x=>x.Id == resource.Id))
                return NotFound();

            appContext.Update(resource);
            appContext.SaveChanges();
            return Ok(resource);
        }

        // DELETE: api/resource/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Resource resource;

            try
            {
                resource = appContext.resources.FirstOrDefault(x => x.Id == id);
            }
            catch (ArgumentNullException e)
            {
                return NotFound();
            }
            
            appContext.resources.Remove(resource);
            appContext.SaveChanges();
            return Ok(resource);
        }
    }
}
