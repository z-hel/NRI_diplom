using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NRI.Models;
using OfficeOpenXml;

namespace NRI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechProcessController : ControllerBase
    {
        ApplicationContext appContext;

        public TechProcessController(ApplicationContext context)
        {
            this.appContext = context;
        }

        //public ViewResult TechProcessView(int id)
        //{
        //    TechProcess techProcess = appContext.techProcesses.Find(id);
        //    return View(techProcess);
        //}

        // GET: api/techProcess
        [HttpGet]
        public List<TechProcess> Get()
        {
            return appContext.techProcesses.ToList();
        }

        // GET: api/techProcess/5
        [HttpGet("{id}", Name = "GetTechProcess")]
        public IActionResult Get(int id)
        {
            TechProcess techProcess;
            techProcess = appContext.techProcesses.FirstOrDefault(x => x.Id == id);

            if (techProcess == null)
                return NotFound();
            return new ObjectResult(techProcess);
        }

        // POST: api/techProcess
        [HttpPost]
        public IActionResult Post([FromBody] TechProcess techProcess)
        {
            if (techProcess == null)
                return BadRequest();
            appContext.techProcesses.Add(techProcess);
            appContext.SaveChanges();
            return Ok(techProcess);
        }

        [HttpPost] //("import")
        [Route("import")]
        public IActionResult Import() //IFormFile fileExcel
        {
            IFormFile fileExcel = Request.Form.Files[0];
            //Stream stream = fileExcel.OpenReadStream();
            Console.WriteLine(fileExcel + "!!!!!!!!!!!!!!!!!!!!!!!!!!");
            if (fileExcel != null)
            {
                
                var memoryStream = new MemoryStream();
                fileExcel.OpenReadStream().CopyTo(memoryStream);

                List<TechProcess> techProcesses = new List<TechProcess>();
                List<TechOperation> techOperations = new List<TechOperation>();

                Console.WriteLine(memoryStream + " !!!!!!!!!!!!!!!!!!!!!!!!!!");

                //var newfile = new FileInfo(fileExcel.FileName);
                using (ExcelPackage package = new ExcelPackage(memoryStream))
                {
                    ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
                    int totalRows = workSheet.Dimension.Rows;

                    //List<Customers> customerList = new List<Customers>();

                    for (int i = 1; i <= totalRows; i++)
                    {
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!" + workSheet.Cells[i, 0].Value.ToString());
                        TechProcess techProcess = new TechProcess();
                        techProcess.Id = int.Parse(workSheet.Cells[i, 0].Value.ToString());
                        techProcess.Name = workSheet.Cells[i, 1].Value.ToString();

                        TechOperation techOperation = new TechOperation();
                        techOperation.Id = int.Parse(workSheet.Cells[i, 2].Value.ToString());
                        techOperation.Name = workSheet.Cells[i, 3].Value.ToString();
                        techOperation.SerialNumber = int.Parse(workSheet.Cells[i, 4].Value.ToString());
                        techOperation.TechProcessId = int.Parse(workSheet.Cells[i, 0].Value.ToString());

                        techProcess.NomenclatureId = int.Parse(workSheet.Cells[i, 5].Value.ToString());
                        techProcess.LaunchBatch = int.Parse(workSheet.Cells[i, 6].Value.ToString());
                        techProcess.MinBatch = int.Parse(workSheet.Cells[i, 7].Value.ToString());
                        techProcess.MaxBatch = int.Parse(workSheet.Cells[i, 8].Value.ToString());


                        techProcesses.Add(techProcess);
                        techOperations.Add(techOperation);
                        this.Post(techProcess);

                        TechOperationController techOperationController = new TechOperationController(appContext);
                        techOperationController.Post(techOperation);


                        //customerList.Add(new Customers
                        //{
                        //    CustomerName = workSheet.Cells[i, 1].Value.ToString(),
                        //    CustomerEmail = workSheet.Cells[i, 2].Value.ToString(),
                        //    CustomerCountry = workSheet.Cells[i, 3].Value.ToString()
                        //});
                    }

                    //_db.Customers.AddRange(customerList);
                    //_db.SaveChanges();

                    //return customerList;
                }
                return Ok(techProcesses);


                /*using (XLWorkbook workBook = new XLWorkbook(memoryStream, XLEventTracking.Disabled)) // TODO ??? fileExcel.InputStream
                {
                    IXLWorksheet worksheet = workBook.Worksheets.First();

                    foreach (IXLColumn column in worksheet.ColumnsUsed())
                    {
                        foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                        {
                            try
                            {
                                TechProcess techProcess = new TechProcess();
                                techProcess.Id = int.Parse(row.Cell(0).Value.ToString());
                                techProcess.Name = row.Cell(1).Value.ToString();

                                TechOperation techOperation = new TechOperation();
                                techOperation.Id = int.Parse(row.Cell(2).Value.ToString());
                                techOperation.Name = row.Cell(3).Value.ToString();
                                techOperation.SerialNumber = int.Parse(row.Cell(4).Value.ToString());
                                techOperation.TechProcessId = int.Parse(row.Cell(0).Value.ToString());

                                techProcess.NomenclatureId = int.Parse(row.Cell(5).Value.ToString());
                                techProcess.LaunchBatch = int.Parse(row.Cell(6).Value.ToString());
                                techProcess.MinBatch = int.Parse(row.Cell(7).Value.ToString());
                                techProcess.MaxBatch = int.Parse(row.Cell(8).Value.ToString());


                                techProcesses.Add(techProcess);
                                techOperations.Add(techOperation);
                                this.Post(techProcess);

                                TechOperationController techOperationController = new TechOperationController(appContext);
                                techOperationController.Post(techOperation);

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }

                    }
                }*/
                //return Ok(techProcesses);
            }
            return RedirectToAction("");
        }

        // PUT: api/techProcess/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TechProcess techProcess)
        {

            if (techProcess == null)
                return BadRequest();

            if (!appContext.techProcesses.Any(x => x.Id == techProcess.Id))
                return NotFound();

            appContext.Update(techProcess);
            appContext.SaveChanges();
            return Ok(techProcess);
        }

        // DELETE: api/techProcess/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TechProcess techProcess;

            try
            {
                techProcess = appContext.techProcesses.FirstOrDefault(x => x.Id == id);
            }
            catch (ArgumentNullException e)
            {
                return NotFound();
            }

            appContext.techProcesses.Remove(techProcess);
            appContext.SaveChanges();
            return Ok(techProcess);
        }


    }
}
