using ApplicationAppApi.Models.ApplicationModel;

namespace ApplicationAppApi.Services.Application.Interfaces
{
    public interface IApplication
    {
        Task<bool> CreateApplicationText(ApplicationModel application);
    }
}
