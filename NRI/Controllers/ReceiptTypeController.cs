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
    public class ReceiptTypeController : ControllerBase
    {
        ApplicationContext appContext;

        public ReceiptTypeController(ApplicationContext context)
        {
            this.appContext = context;
        }

        // GET: api/receiptType
        [HttpGet]
        public List<ReceiptType> Get()
        {
            return appContext.receiptTypes.ToList();
        }

        // GET: api/receiptType/5
        [HttpGet("{id}", Name = "GetReceiptType")]
        public IActionResult Get(int id)
        {
            ReceiptType receiptType;
            
            receiptType = appContext.receiptTypes.FirstOrDefault(x => x.Id == id);
          
            if (receiptType == null)
                return NotFound();
            return new ObjectResult(receiptType);
        }

        // POST: api/receiptType
        [HttpPost]
        public IActionResult Post([FromBody] ReceiptType receiptType)
        {
            if (receiptType == null)
                return BadRequest();
            appContext.receiptTypes.Add(receiptType);
            appContext.SaveChanges();
            return Ok();
        }

        // PUT: api/receiptType/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ReceiptType receiptType)
        {
            if (receiptType == null)
                return BadRequest();

            if (!appContext.receiptTypes.Any(x=>x.Id == receiptType.Id))
                return NotFound();

            appContext.Update(receiptType);
            appContext.SaveChanges();
            return Ok();
        }

        // DELETE: api/receiptType/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ReceiptType receiptType;

            try
            {
                receiptType = appContext.receiptTypes.FirstOrDefault(x => x.Id == id);
            }
            catch (ArgumentNullException e)
            {
                return NotFound();
            }
            
            appContext.receiptTypes.Remove(receiptType);
            appContext.SaveChanges();
            return Ok();
        }
    }
}
