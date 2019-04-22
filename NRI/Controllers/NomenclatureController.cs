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
    public class NomenclatureController : ControllerBase
    {
        ApplicationContext appContext;

        public NomenclatureController(ApplicationContext context)
        {
            this.appContext = context;
        }

        //public NomenclatureController(ApplicationContext applicationContext)
        //{
        //    this.appContext = applicationContext;
        //if (!appContext.nomenclatures.Any())
        //{
        //NomenclatureType nomenclatureType = new NomenclatureType { Name = "Name", Id = 3 };
        //Nomenclature nomenclature = new Nomenclature
        //{
        //    Name = "name",
        //    Id = 3,
        //    ReceiptType = "receipt",
        //    NomenclatureType = nomenclatureType,
        //    TechProcesses = new List<TechProcess>(),
        //    ParentNomenclature = null
        //};

        //appContext.nomenclatureTypes.Add(nomenclatureType);
        //appContext.nomenclatures.Add(nomenclature);
        //appContext.SaveChanges();
        //}

        //}

        // GET: api/Nomenclature
        [HttpGet]
        public List<Nomenclature> Get()
        {
            return appContext.nomenclatures.ToList();
        }

        // GET: api/Nomenclature/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            Nomenclature nomenclature;

            //try {
            nomenclature = appContext.nomenclatures.FirstOrDefault(x => x.Id == id);
            //} catch (ArgumentNullException e) {
            //    return NotFound();
            //}
            if (nomenclature == null)
                return NotFound();
            return new ObjectResult(nomenclature);
        }

        // POST: api/Nomenclature
        [HttpPost]
        public IActionResult Post([FromBody] Nomenclature nomenclature)
        {
            if (nomenclature == null)
                return BadRequest();
            appContext.nomenclatures.Add(nomenclature);
            appContext.SaveChanges();
            return Ok();
        }

        // PUT: api/Nomenclature/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Nomenclature nomenclature)
        {
            //Nomenclature nomenclatureFind;
            //try
            //{
            //    nomenclatureFind = appContext.nomenclatures.FirstOrDefault(x => x.Id == id);
            //}
            //catch (ArgumentNullException e)
            //{
            //    return NotFound();
            //}

            if (nomenclature == null)
                return BadRequest();

            if (!appContext.nomenclatures.Any(x=>x.Id == nomenclature.Id))
                return NotFound();

            appContext.Update(nomenclature);
            appContext.SaveChanges();
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Nomenclature nomenclature;

            try
            {
                nomenclature = appContext.nomenclatures.FirstOrDefault(x => x.Id == id);
            }
            catch (ArgumentNullException e)
            {
                return NotFound();
            }

            //if (nomenclature == null)
            //    return NotFound();
            appContext.nomenclatures.Remove(nomenclature);
            appContext.SaveChanges();
            return Ok();
        }
    }
}
