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
        [HttpGet("{id}", Name = "GetNomenclature")]
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
            return Ok(nomenclature);
        }



        [HttpPost] //("import")
        [Route("import")]
        public IActionResult Import()
        {
            IFormFile fileExcel = Request.Form.Files[0];
            if (fileExcel != null)
            {

                List<Nomenclature> nomenclatures = new List<Nomenclature>();
                List<TechOperationNeed> needs = new List<TechOperationNeed>();
                List<TechOperationOut> outs = new List<TechOperationOut>();
                try
                {
                    using (var package = new OfficeOpenXml.ExcelPackage())
                    {

                        using (var stream = fileExcel.OpenReadStream())
                        {
                            package.Load(stream);
                        }

                        var workSheetNomenclature = package.Workbook.Worksheets.First();
                        var workSheetTechOperation = package.Workbook.Worksheets.ElementAt(1);
                        int totalRowsNomenclature = workSheetNomenclature.Dimension.Rows;
                        int totalRowsTechOperation = workSheetTechOperation.Dimension.Rows;

                        for (int i = 2; i <= totalRowsNomenclature; i++)
                        {
                            Nomenclature nomenclature = new Nomenclature();
                            TechOperationNeed TONeed = new TechOperationNeed();
                            TechOperationOut TOOut = new TechOperationOut();

                            //var id = int.Parse(workSheet.Cells[i, 1].Value.ToString());
                            var code = workSheetNomenclature.Cells[i, 1].Value.ToString();
                            var name = workSheetNomenclature.Cells[i, 2].Value.ToString();
                            var nomTypeId = int.Parse(workSheetNomenclature.Cells[i, 3].Value.ToString());
                            var receiptTypeId = int.Parse(workSheetNomenclature.Cells[i, 4].Value.ToString());
                            var specPositionId = int.Parse(workSheetNomenclature.Cells[i, 5].Value.ToString());
                            var specParentId = int.Parse(workSheetNomenclature.Cells[i, 6].Value.ToString());
                            var count = int.Parse(workSheetNomenclature.Cells[i, 7].Value.ToString());
                            var techProcessId = int.Parse(workSheetNomenclature.Cells[i, 8].Value.ToString());

                            nomenclature.Id = specPositionId;
                            nomenclature.Name = name;
                            nomenclature.Code = code;
                            nomenclature.NomenclatureTypeId = nomTypeId;
                            nomenclature.ReceiptTypeId = receiptTypeId;

                            TechProcessController techProcessController = new TechProcessController(appContext);
                            var techProcess = techProcessController.Get(techProcessId);

                            if (techProcess != NotFound())
                            {
                                
                                var techOperationId = 0;
                                List<int> techOperationsList = new List<int>();

                                for (int y = 2; y <= totalRowsTechOperation; y++)
                                {
                                    var processId = int.Parse(workSheetTechOperation.Cells[i, 1].Value.ToString());
                                    if (processId == techProcessId)
                                    {
                                        techOperationsList.Add(int.Parse(workSheetTechOperation.Cells[i, 2].Value.ToString()));
                                    }
                                }
                                var techOperationIdOut = techOperationsList.Last();
                                var techOperationIdNeed = techOperationsList.First();

                                TechOperationController techOperationController = new TechOperationController(appContext);
                                var techOperationForOut = techOperationController.Get(techOperationIdOut);
                                var techOperationForNeed = techOperationController.Get(techOperationIdNeed);

                                for (int x = 2; x <= totalRowsTechOperation; x++)
                                {
                                    var id = int.Parse(workSheetTechOperation.Cells[x, 2].Value.ToString());
                                    if ((techOperationForNeed == NotFound() || techOperationForOut == NotFound()) && (techOperationIdNeed == id || techOperationIdOut == id))
                                    {
                                        TechOperation techOperation = new TechOperation();
                                        techOperation.Id = id;
                                        techOperation.Name = workSheetTechOperation.Cells[x, 3].Value.ToString();
                                        techOperation.TechProcessId = int.Parse(workSheetTechOperation.Cells[x, 1].Value.ToString());
                                        techOperation.SerialNumber = int.Parse(workSheetTechOperation.Cells[x, 4].Value.ToString());
                                        techOperationController.Post(techOperation);
                                    }
                                }

                                if (specPositionId == specParentId)
                                {
                                    TOOut.NomenclatureOutId = specParentId;
                                    TOOut.Count = count;
                                    TOOut.TechOperationId = techOperationIdOut;
                                    //TOOut.Id = specPositionId;
                                    nomenclature.ParentNomenclatureId = null;
                                }
                                else
                                {
                                    TONeed.NomenclatureNeedId = specPositionId;
                                    TONeed.Count = count;
                                    TONeed.TechOperationId = techOperationIdNeed;
                                    //TONeed.Id = specPositionId;
                                    nomenclature.ParentNomenclatureId = specParentId;
                                }



                                nomenclatures.Add(nomenclature);
                                needs.Add(TONeed);
                                outs.Add(TOOut);


                            }
                            else
                            {
                                return NotFound();
                            }
                        }

                    }
                    IEnumerable<Nomenclature> distinctNomenclature = nomenclatures.Distinct();
                    foreach (Nomenclature nomenclature in distinctNomenclature)
                    {
                        if (nomenclature.Id != 0)
                        {
                            IActionResult result = this.Get(nomenclature.Id);
                            //Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! nomenclature " + result.GetType());
                            if (result.ToString().Equals("Microsoft.AspNetCore.Mvc.NotFoundResult"))
                            {
                                this.Post(nomenclature);
                            }
                        }

                    }

                    IEnumerable<TechOperationNeed> distinctNeeds = needs.Distinct();
                    TechOperationNeedController techOperationNeedController = new TechOperationNeedController(appContext);
                    foreach (TechOperationNeed need in distinctNeeds)
                    {
                        if (need.NomenclatureNeedId != 0)
                        {
                            //IActionResult result = techOperationNeedController.Get(need.Id);
                            ////Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! TechOperationNeed " + result.GetType());
                            //if (result.ToString().Equals("Microsoft.AspNetCore.Mvc.NotFoundResult"))
                            //{

                            techOperationNeedController.Post(need);
                            //}
                        }
                    }

                    IEnumerable<TechOperationOut> distinctOuts = outs.Distinct();
                    TechOperationOutController techOperationOutController = new TechOperationOutController(appContext);
                    foreach (TechOperationOut out1 in distinctOuts)
                    {
                        if (out1.NomenclatureOutId != 0)
                        {
                            //IActionResult result = techOperationOutController.Get(out1.Id);
                            ////Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! TechOperationOut " + result.GetType());
                            //if (result.ToString().Equals("Microsoft.AspNetCore.Mvc.NotFoundResult"))
                            //{

                            techOperationOutController.Post(out1);
                            //}
                        }
                    }
                    
                    return Ok(nomenclatures);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! " + ex.Message);
                }

            }
            return RedirectToAction("");
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
            return Ok(nomenclature);
        }

        // DELETE: api/nomenclature/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Nomenclature nomenclature;
            Nomenclature parentNomenclature;

            try
            {
                nomenclature = appContext.nomenclatures.FirstOrDefault(x => x.Id == id);
                try { 
                    parentNomenclature = appContext.nomenclatures.FirstOrDefault(x => x.Id == nomenclature.ParentNomenclatureId);
                } catch (ArgumentNullException e)
                {
                    nomenclature.ParentNomenclatureId = null;
                }
            }
            catch (ArgumentNullException e)
            {
                return NotFound();
            }

            //if (nomenclature == null)
            //    return NotFound();
            appContext.nomenclatures.Remove(nomenclature);
            appContext.SaveChanges();
            return Ok(nomenclature);
        }
    }
}
