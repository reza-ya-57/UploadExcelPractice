using ExcelDataReader;
using ExcelReader.Models;
using System.Text;

namespace ExcelReader.Services
{
    public static class ExcelReadService
    {
        public static List<ReportCompanyScore> ReadExcel(IFormFile file,short date)
        {

            /*var originalFileName = @"C:\Users\Rpipc\Documents\pezhman\ASI-Dashboard- EDIT.xlsx";*/
            var reportCompanyScores = new List<ReportCompanyScore>();


            
          


            
                // Choose one of either 1 or 2:
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                using (var reader = ExcelReaderFactory.CreateReader(file.OpenReadStream()))
                {

                    // 1. Use the reader methods
                    do
                    {
                        while (reader.Read())
                        {
                            // reader.GetDouble(0);
                        }
                    } while (reader.NextResult());

                    // 2. Use the AsDataSet extension method


                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {





                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {

                            UseHeaderRow = true,
                        }
                    });



                    int headerSkipped = 0;
                    while (reader.Read())
                    {

                        if (headerSkipped < 2)
                        {
                            headerSkipped++;
                            continue;
                        }
                        /*if (
                            reader.GetString(i) == "*" ||
                            reader.GetString(i) == "-" ||
                            reader.GetString(i) == "_" ||
                            reader.GetString(i) == "." )
                        {
                            continue;
                        }*/

                        var id = Convert.ToInt32(reader.GetValue(0));
                        dynamic name = null;
                        if (reader.GetFieldType(1) == typeof(string)) { name = reader.GetString(1); }
                        dynamic weight = null;
                        if (reader.GetFieldType(2) == typeof(string)) { weight = reader.GetString(2); }
                        dynamic asisystem = null;
                        if (reader.GetFieldType(3) == typeof(double)) { asisystem = reader.GetDouble(3); }
                        dynamic agencyScore = null;
                        if (reader.GetFieldType(4) == typeof(double)) { agencyScore = reader.GetDouble(4); }
                        dynamic customerSatisfaction = null;
                        if (reader.GetFieldType(5) == typeof(double)) { customerSatisfaction = reader.GetDouble(5); }
                        dynamic performanceResult = null;
                        if (reader.GetFieldType(6) == typeof(double)) { performanceResult = reader.GetDouble(6); }
                        dynamic dsiscore = null;
                        if (reader.GetFieldType(7) == typeof(double)) { dsiscore = reader.GetDouble(7); }
                        dynamic finalScore = null;
                        if (reader.GetFieldType(8) == typeof(double)) { finalScore = reader.GetDouble(8); }
                        dynamic rank = null;
                        if (reader.GetFieldType(9) == typeof(byte)) { rank = reader.GetByte(9); }
                        dynamic agencyCount = null;
                        if (reader.GetFieldType(10) == typeof(int)) { agencyCount = reader.GetInt32(10); }
                        var companyScore = new ReportCompanyScore
                        {
                            CompanyId = id,
                            Name = name,
                            Weight = weight,
                            Asisystem = asisystem,
                            AgenciesScore = agencyScore,
                            CustomerSatisfaction = customerSatisfaction,
                            PerformanceResult = performanceResult,
                            Dsiscore = dsiscore,
                            FinalScore = finalScore,
                            Rank = rank,
                            AgencyCount = agencyCount,
                            PeriodDate = date
                        };
                        reportCompanyScores.Add(companyScore);
                    }
                }
            
            return reportCompanyScores;


        }
    }
}
