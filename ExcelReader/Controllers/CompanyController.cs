using ExcelReader.Models;
using ExcelReader.Repository;
using ExcelReader.Services;
using Microsoft.AspNetCore.Mvc;


namespace ExcelReader.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IRepository _companyRepo;
        private readonly IExcelUploadService _excelService;

        public CompanyController(IRepository companyRepo, IExcelUploadService excelService)
        {
            _excelService = excelService;
            _companyRepo = companyRepo;
         
        }

        [HttpPost("Read")]
        public IActionResult ReadExcelFile(IFormFile file, [FromQuery] short periodDate)
        {
            try
            {
                var a = ExcelReadService.ReadExcel(file, periodDate);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }



        
        [HttpPost("Upload")]
        public IActionResult UploadExcel(IFormFile file , short periodDate)
        {
            
            

            var a =_excelService.UploadExcel(file , periodDate);
                return Ok(a);
        }
    }
}
