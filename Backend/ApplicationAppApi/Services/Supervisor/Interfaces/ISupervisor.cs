using ApplicationAppApi.Models.SupervisorModel;
using ApplicationAppApi.Models.SupervisorModel.DTO;

namespace ApplicationAppApi.Services.Supervisor.Interfaces
{
    public interface ISupervisor
    {
        Task<bool> CreateSupervisorOrder(SupervisorModel supervisorModel);
        Task<SupervisorModelDto> GetSupervisorOrderDetails(string orderNo);
    }
}
