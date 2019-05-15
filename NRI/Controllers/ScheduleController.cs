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
    public class ScheduleController : ControllerBase
    {
        ApplicationContext appContext;

        public ScheduleController(ApplicationContext context)
        {
            this.appContext = context;
        }

        // GET: api/schedule
        [HttpGet]
        public List<Schedule> Get()
        {
            return appContext.schedules.ToList();
        }

        // GET: api/schedule/5
        [HttpGet("{id}", Name = "GetSchedule")]
        public IActionResult Get(int id)
        {
            Schedule schedule;
            
            schedule = appContext.schedules.FirstOrDefault(x => x.Id == id);
          
            if (schedule == null)
                return NotFound();
            return new ObjectResult(schedule);
        }

        // POST: api/schedule
        [HttpPost]
        public IActionResult Post([FromBody] Schedule schedule)
        {
            if (schedule == null)
                return BadRequest();
            appContext.schedules.Add(schedule);
            appContext.SaveChanges();
            return Ok();
        }

        // PUT: api/schedule/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Schedule schedule)
        {
            if (schedule == null)
                return BadRequest();

            if (!appContext.schedules.Any(x=>x.Id == schedule.Id))
                return NotFound();

            appContext.Update(schedule);
            appContext.SaveChanges();
            return Ok();
        }

        // DELETE: api/schedule/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Schedule schedule;

            try
            {
                schedule = appContext.schedules.FirstOrDefault(x => x.Id == id);
            }
            catch (ArgumentNullException e)
            {
                return NotFound();
            }
            
            appContext.schedules.Remove(schedule);
            appContext.SaveChanges();
            return Ok();
        }
    }
}
