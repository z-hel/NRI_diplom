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
    public class ResourceUsageTypeController : ControllerBase
    {
        ApplicationContext appContext;

        public ResourceUsageTypeController(ApplicationContext context)
        {
            this.appContext = context;
        }

        // GET: api/resourceUsageType
        [HttpGet]
        public List<ResourceUsageType> Get()
        {
            return appContext.resourceUsageTypes.ToList();
        }

        // GET: api/resourceUsageType/5
        [HttpGet("{id}", Name = "GetResourceUsageType")]
        public IActionResult Get(int id)
        {
            ResourceUsageType resourceUsageType;
            
            resourceUsageType = appContext.resourceUsageTypes.FirstOrDefault(x => x.Id == id);
          
            if (resourceUsageType == null)
                return NotFound();
            return new ObjectResult(resourceUsageType);
        }

        // POST: api/resourceUsageType
        [HttpPost]
        public IActionResult Post([FromBody] ResourceUsageType resourceUsageType)
        {
            if (resourceUsageType == null)
                return BadRequest();
            appContext.resourceUsageTypes.Add(resourceUsageType);
            appContext.SaveChanges();
            return Ok(resourceUsageType);
        }

        // PUT: api/resourceUsageType/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ResourceUsageType resourceUsageType)
        {
            if (resourceUsageType == null)
                return BadRequest();

            if (!appContext.resourceUsageTypes.Any(x=>x.Id == resourceUsageType.Id))
                return NotFound();

            appContext.Update(resourceUsageType);
            appContext.SaveChanges();
            return Ok(resourceUsageType);
        }

        // DELETE: api/resourceUsageType/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ResourceUsageType resourceUsageType;

            try
            {
                resourceUsageType = appContext.resourceUsageTypes.FirstOrDefault(x => x.Id == id);
            }
            catch (ArgumentNullException e)
            {
                return NotFound();
            }
            
            appContext.resourceUsageTypes.Remove(resourceUsageType);
            appContext.SaveChanges();
            return Ok(resourceUsageType);
        }
    }
}
