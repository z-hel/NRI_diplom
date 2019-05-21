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
    public class CalendarController : ControllerBase
    {
        ApplicationContext appContext;

        public CalendarController(ApplicationContext context)
        {
            this.appContext = context;
        }

        // GET: api/calendar
        [HttpGet]
        public List<Calendar> Get()
        {
            return appContext.calendars.ToList();
        }

        // GET: api/calendar/5
        [HttpGet("{id}", Name = "GetCalendar")]
        public IActionResult Get(int id)
        {
            Calendar calendar;
            
            calendar = appContext.calendars.FirstOrDefault(x => x.Id == id);
          
            if (calendar == null)
                return NotFound();
            return new ObjectResult(calendar);
        }

        // POST: api/calendar
        [HttpPost]
        public IActionResult Post([FromBody] Calendar calendar)
        {
            if (calendar == null)
                return BadRequest();
            appContext.calendars.Add(calendar);
            appContext.SaveChanges();
            return Ok(calendar);
        }

        // PUT: api/calendar/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Calendar calendar)
        {
            if (calendar == null)
                return BadRequest();

            if (!appContext.calendars.Any(x=>x.Id == calendar.Id))
                return NotFound();

            appContext.Update(calendar);
            appContext.SaveChanges();
            return Ok(calendar);
        }

        // DELETE: api/calendar/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Calendar calendar;

            try
            {
                calendar = appContext.calendars.FirstOrDefault(x => x.Id == id);
            }
            catch (ArgumentNullException e)
            {
                return NotFound();
            }
            
            appContext.calendars.Remove(calendar);
            appContext.SaveChanges();
            return Ok(calendar);
        }
    }
}
