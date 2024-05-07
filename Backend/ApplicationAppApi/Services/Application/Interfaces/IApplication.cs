using ApplicationAppApi.Models.Application;
using ApplicationAppApi.Models.Application.DTO;

namespace ApplicationAppApi.Services.Application.Interfaces
{
    public interface IApplication
    {
        Task<bool> CreateApplicationText(ApplicationModel application);
        Task CreateFilePath(string filePath, int applicationId);
        Task<ApplicationDtoModel> GeneratePdf(int applicationId);
    }
}
