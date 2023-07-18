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
        public CompanyController(IRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var companies = await _companyRepo.GetCompanies();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("Test")]
        public IActionResult Testapp()
        {
            try
            {
                var a = ExcelReaderService.ReadExcel();
                return Ok(a);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
