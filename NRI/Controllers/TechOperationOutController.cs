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
    public class TechOperationOutController : Controller
    {
        ApplicationContext appContext;

        public TechOperationOutController(ApplicationContext context)
        {
            this.appContext = context;
        }

        public ActionResult Index()
        {
            TechOperationOut techOperationOut = new TechOperationOut();
            return View(techOperationOut);
        }

        // GET: api/TechOperationOut
        [HttpGet]
        public List<TechOperationOut> Get()
        {
            return appContext.techOperationOuts.ToList();
        }

        // GET: api/TechOperationOut/5
        [HttpGet("{id}", Name = "GetTechOperationOut")]
        public IActionResult Get(int id)
        {
            TechOperationOut techOperationOut;
            techOperationOut = appContext.techOperationOuts.FirstOrDefault(x => x.Id == id);
            
            if (techOperationOut == null)
                return NotFound();
            return new ObjectResult(techOperationOut);
        }

        // POST: api/TechOperationOut
        [HttpPost]
        public IActionResult Post([FromBody] TechOperationOut techOperationOut)
        {
            if (techOperationOut == null)
                return BadRequest();
            appContext.techOperationOuts.Add(techOperationOut);
            appContext.SaveChanges();
            return Ok();
        }

        // PUT: api/TechOperationOut/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TechOperationOut techOperationOut)
        {
            
            if (techOperationOut == null)
                return BadRequest();

            if (!appContext.techOperationOuts.Any(x=>x.Id == techOperationOut.Id))
                return NotFound();

            appContext.Update(techOperationOut);
            appContext.SaveChanges();
            return Ok();
        }

        // DELETE: api/TechOperationOut/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TechOperationOut techOperationOut;

            try
            {
                techOperationOut = appContext.techOperationOuts.FirstOrDefault(x => x.Id == id);
            }
            catch (ArgumentNullException e)
            {
                return NotFound();
            }
            
            appContext.techOperationOuts.Remove(techOperationOut);
            appContext.SaveChanges();
            return Ok();
        }
    }
}
