using ExcelReader.Models;

namespace ExcelReader.Repository
{
    public interface IRepository
    {
        public Task<IEnumerable<Company>> GetCompanies();
    }
}
