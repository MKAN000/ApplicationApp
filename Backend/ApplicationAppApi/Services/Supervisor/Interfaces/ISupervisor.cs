using ApplicationAppApi.Models.Supervisor;
using ApplicationAppApi.Models.Supervisor.DTO;

namespace ApplicationAppApi.Services.Supervisor.Interfaces
{
    public interface ISupervisor
    {
        Task<bool> CreateSupervisorOrder(SupervisorModel supervisorModel);
        Task<SupervisorModelDto> GetSupervisorOrderDetails(string orderNo);
    }
}
