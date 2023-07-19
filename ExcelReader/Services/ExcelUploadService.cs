using Microsoft.Extensions.Configuration.UserSecrets;
using ExcelDataReader;
using System.Data;
using System.Text.RegularExpressions;
using ExcelReader.Models;

using Dapper;
using System.Reflection.PortableExecutable;
using Microsoft.Data.SqlClient;
using ExcelReader.Data;

namespace ExcelReader.Services
{
    public class ExcelUploadService:IExcelUploadService
    {
        private readonly DataContext _context;
        public ExcelUploadService(DataContext context)
        {
            _context = context;
        }
        
        
        public  List<dynamic> UploadExcel(IFormFile file , short date)
        {
            var list = ExcelReadService.ReadExcel( file,  date);
            using (var connection = new SqlConnection("Server=rezayari.ir;Database=TaskManagerCodeFirst;User Id=InterviewAccess;Password=InterviewAccess@InterviewAccess;TrustServerCertificate=True"))
            {
                var q = "INSERT INTO Report.CompanyScore (Id, Name, Weight, Asisystem, AgenciesScore, CustomerSatisfaction, PerformanceResult, Dsiscore, FinalScore, Rank, AgencyCount, PeriodDate ) VALUES (@Id, @Name, @Weight, @Asisystem, @AgenciesScore, @CustomerSatisfaction, @PerformanceResult, @Dsiscore, @FinalScore, @Rank, @AgencyCount ,@PeriodDate)";
                // 3. Call the `Execute` method
                {
                    // 3a. The first time, we will pass parameters values with an anonymous type
                    foreach(var company in list) {
                        connection.Execute(q, company);
                    }
                    
                   
                }
                
                return connection.Query<dynamic>("SELECT * FROM Report.CompanyScore").ToList();

            }


        }
    }
}



