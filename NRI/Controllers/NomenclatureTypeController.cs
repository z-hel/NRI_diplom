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
    public class NomenclatureTypeController : ControllerBase
    {
        ApplicationContext appContext;

        public NomenclatureTypeController(ApplicationContext context)
        {
            this.appContext = context;
        }
        

        // GET: api/NomenclatureType
        [HttpGet]
        public List<NomenclatureType> Get()
        {
            return appContext.nomenclatureTypes.ToList();
        }

        // GET: api/NomenclatureType/5
        [HttpGet("{id}", Name = "GetNomenclatureType")]
        public IActionResult Get(int id)
        {
            NomenclatureType nomenclatureType;
            
            nomenclatureType = appContext.nomenclatureTypes.FirstOrDefault(x => x.Id == id);
            
            if (nomenclatureType == null)
                return NotFound();
            return new ObjectResult(nomenclatureType);
        }

        // POST: api/NomenclatureType
        [HttpPost]
        public IActionResult Post([FromBody] NomenclatureType nomenclatureType)
        {
            if (nomenclatureType == null)
                return BadRequest();
            appContext.nomenclatureTypes.Add(nomenclatureType);
            appContext.SaveChanges();
            return Ok(nomenclatureType);
        }

        // PUT: api/NomenclatureType/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] NomenclatureType nomenclatureType)
        {
            if (nomenclatureType == null)
                return BadRequest();

            if (!appContext.nomenclatureTypes.Any(x=>x.Id == nomenclatureType.Id))
                return NotFound();

            appContext.Update(nomenclatureType);
            appContext.SaveChanges();
            return Ok(nomenclatureType);
        }

        // DELETE: api/nomenclatureType/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            NomenclatureType nomenclatureType;

            try
            {
                nomenclatureType = appContext.nomenclatureTypes.FirstOrDefault(x => x.Id == id);
            }
            catch (ArgumentNullException e)
            {
                return NotFound();
            }
            
            appContext.nomenclatureTypes.Remove(nomenclatureType);
            appContext.SaveChanges();
            return Ok(nomenclatureType);
        }
    }
}
