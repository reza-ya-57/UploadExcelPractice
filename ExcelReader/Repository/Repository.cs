using ExcelReader.Data;
using ExcelReader.Models;
using Dapper;
namespace ExcelReader.Repository
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var query = "SELECT * FROM Company";
    using (var connection = _context.CreateConnection())
    {
        var companies = await connection.QueryAsync<Company>(query);
        return companies.ToList();
    }
        }
    }
}
