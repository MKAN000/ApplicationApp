namespace ApplicationAppApi.Services.Application.Interfaces
{
    public interface IApplication
    {
        Task<bool> UploadFileToCsv(Stream fileStream);
        Task<bool> SaveCsvToDb(string csvData);
    }
}
