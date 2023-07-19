namespace ExcelReader.Services
{
    public interface IExcelUploadService
    {
        public List<dynamic> UploadExcel(IFormFile file , short periodDate);
    }
}
