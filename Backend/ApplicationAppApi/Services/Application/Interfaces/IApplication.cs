using ApplicationAppApi.Models.Application;

namespace ApplicationAppApi.Services.Application.Interfaces
{
    public interface IApplication
    {
        Task<bool> CreateApplicationText(ApplicationModel application);
        Task CreateFilePath(string filePath, int applicationId);
    }
}
