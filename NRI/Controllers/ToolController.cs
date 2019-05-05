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
    public class ToolController : ControllerBase
    {
        ApplicationContext appContext;

        public ToolController(ApplicationContext context)
        {
            this.appContext = context;
        }

        // GET: api/tool
        [HttpGet]
        public List<Tool> Get()
        {
            return appContext.tools.ToList();
        }

        // GET: api/tool/5
        [HttpGet("{id}", Name = "GetTool")]
        public IActionResult Get(int id)
        {
            Tool tool;
            
            tool = appContext.tools.FirstOrDefault(x => x.Id == id);
          
            if (tool == null)
                return NotFound();
            return new ObjectResult(tool);
        }

        // POST: api/tool
        [HttpPost]
        public IActionResult Post([FromBody] Tool tool)
        {
            if (tool == null)
                return BadRequest();
            appContext.tools.Add(tool);
            appContext.SaveChanges();
            return Ok();
        }

        // PUT: api/tool/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Tool tool)
        {
            if (tool == null)
                return BadRequest();

            if (!appContext.tools.Any(x=>x.Id == tool.Id))
                return NotFound();

            appContext.Update(tool);
            appContext.SaveChanges();
            return Ok();
        }

        // DELETE: api/tool/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Tool tool;

            try
            {
                tool = appContext.tools.FirstOrDefault(x => x.Id == id);
            }
            catch (ArgumentNullException e)
            {
                return NotFound();
            }
            
            appContext.tools.Remove(tool);
            appContext.SaveChanges();
            return Ok();
        }
    }
}
