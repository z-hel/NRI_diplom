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
    public class CalendarDisplayTypeController : ControllerBase
    {
        ApplicationContext appContext;

        public CalendarDisplayTypeController(ApplicationContext context)
        {
            this.appContext = context;
        }

        // GET: api/calendarDisplayType
        [HttpGet]
        public List<CalendarDisplayType> Get()
        {
            return appContext.calendarDisplayTypes.ToList();
        }

        // GET: api/calendarDisplayType/5
        [HttpGet("{id}", Name = "GetCalendarDisplayType")]
        public IActionResult Get(int id)
        {
            CalendarDisplayType calendarDisplayType;
            
            calendarDisplayType = appContext.calendarDisplayTypes.FirstOrDefault(x => x.Id == id);
          
            if (calendarDisplayType == null)
                return NotFound();
            return new ObjectResult(calendarDisplayType);
        }

        // POST: api/calendarDisplayType
        [HttpPost]
        public IActionResult Post([FromBody] CalendarDisplayType calendarDisplayType)
        {
            if (calendarDisplayType == null)
                return BadRequest();
            appContext.calendarDisplayTypes.Add(calendarDisplayType);
            appContext.SaveChanges();
            return Ok();
        }

        // PUT: api/calendarDisplayType/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CalendarDisplayType calendarDisplayType)
        {
            if (calendarDisplayType == null)
                return BadRequest();

            if (!appContext.calendarDisplayTypes.Any(x=>x.Id == calendarDisplayType.Id))
                return NotFound();

            appContext.Update(calendarDisplayType);
            appContext.SaveChanges();
            return Ok();
        }

        // DELETE: api/calendarDisplayType/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            CalendarDisplayType calendarDisplayType;

            try
            {
                calendarDisplayType = appContext.calendarDisplayTypes.FirstOrDefault(x => x.Id == id);
            }
            catch (ArgumentNullException e)
            {
                return NotFound();
            }
            
            appContext.calendarDisplayTypes.Remove(calendarDisplayType);
            appContext.SaveChanges();
            return Ok();
        }
    }
}
