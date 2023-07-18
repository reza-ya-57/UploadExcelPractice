using Microsoft.Extensions.Configuration.UserSecrets;
using ExcelDataReader;
using System.Data;
using System.Text.RegularExpressions;
using ExcelReader.Models;
using Microsoft.Office.Interop.Excel;
using Microsoft.Data.SqlClient;
using Dapper;

namespace ExcelReader.Services
{
    public class ExcelReaderService
    {
        public static List<ReportCompanyScore> ReadExcel()
        {
            
            var originalFileName = @"C:\Users\Rpipc\Documents\pezhman\ASI-Dashboard- EDIT.xlsx";
            var reportCompanyScores = new List<ReportCompanyScore>();
            using (var stream = File.Open(originalFileName, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader;

                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream);

                //// reader.IsFirstRowAsColumnNames
                var conf = new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };

                var dataSet = reader.AsDataSet(conf);

                // Now you can get data from each sheet by its index or its "name"
                var dataTable = dataSet.Tables[0];

                var cellStr = "AB2"; // var cellStr = "A1";
                var match = Regex.Match(cellStr, @"(?<col>[A-Z]+)(?<row>\d+)");
                var colStr = match.Groups["col"].ToString();
                var col = colStr.Select((t, i) => (colStr[i] - 64) * Math.Pow(26, colStr.Length - i - 1)).Sum();
                var row = int.Parse(match.Groups["row"].ToString());

                for (var i = row+1; i < dataTable.Rows.Count+2; i++)
                {
                        
                        var companyScore = new ReportCompanyScore
                        {
                           Id = Convert.ToInt32(dataTable.Rows[i][1]),
                            Name = dataTable.Rows[i][2].ToString().Trim(),
                            Weight = dataTable.Rows[i][3].ToString(),
                            Asisystem = Convert.ToDouble(dataTable.Rows[i][4]),
                            AgenciesScore = Convert.ToDouble(dataTable.Rows[i][5]),
                            CustomerSatisfaction = Convert.ToDouble(dataTable.Rows[i][6]),
                            PerformanceResult = Convert.ToDouble(dataTable.Rows[i][7]),
                            Dsiscore = Convert.ToDouble(dataTable.Rows[i][8]),
                            FinalScore = Convert.ToDouble(dataTable.Rows[i][9]),
                            Rank = Convert.ToByte(dataTable.Rows[i][10]),
                            AgencyCount = Convert.ToInt32(dataTable.Rows[i][11])
                        };
                        reportCompanyScores.Add(companyScore);
                    }
                }
                return reportCompanyScores;

                /*using (var connection = new SqlConnection("DefaultConnectionString"))
                {
                    var sql = "INSERT INTO Customers VALUES (@Id, @Name, @Weight, @Asisystem, @AgenciesScore, @CustomerSatisfaction, @PerformanceResult, @Dsiscore, @FinalScore, @Rank, @AgencyCount )";
                    // 3. Call the `Execute` method
                    {
                        // 3a. The first time, we will pass parameters values with an anonymous type
                        var anonymousCustomer = new { Name = "ZZZ Projects", Email = "zzzprojects@example.com" };
                        var rowsAffected = connection.Execute(sql, anonymousCustomer);
                        Console.WriteLine($"{rowsAffected} row(s) inserted.");
                    }
                    {
                        // 3b. The second time, we will pass parameters values by providing the customer entity
                        var customer = new Customer() { Name = "Learn Dapper", Email = "learndapper@example.com" };
                        var rowsAffected = connection.Execute(sql, customer);
                        Console.WriteLine($"{rowsAffected} row(s) inserted.");
                    }
                    var insertedCustomers = connection.Query<Customer>("SELECT * FROM Customers").ToList();

                }*/

            }
        }
    }


