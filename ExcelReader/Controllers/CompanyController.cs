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
        private readonly ILogger _logger;
        public CompanyController(IRepository companyRepo, IExcelUploadService excelService, ILogger logger)
        {
            _excelService = excelService;
            _companyRepo = companyRepo;
            _logger = logger;
        }
       

        [HttpGet("Read")]
        public IActionResult ReadExcel(short periodDate)
        {
           
            var a = ExcelReadService.ReadExcel( file , periodDate);
            return Ok(a);
        }
        [HttpPost("Upload")]
        public IActionResult UploadExcel(IFormFile file , short periodDate)
        {
            
            _logger.LogInformation(file.FileName);

            var a =_excelService.UploadExcel(file , periodDate);
                return Ok(a);
        }
    }
}
