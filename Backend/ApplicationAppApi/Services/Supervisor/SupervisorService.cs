using ApplicationAppApi.ApplicationDataBaseContext;
using ApplicationAppApi.Models.Supervisor;
using ApplicationAppApi.Models.Supervisor.DTO;
using ApplicationAppApi.Services.Supervisor.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApplicationAppApi.Services.Supervisor
{
    public class SupervisorService : ISupervisor
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public SupervisorService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;

        }
        public async Task<bool> CreateSupervisorOrder(SupervisorModel supervisorModel)
        {
            try
            {
                _applicationDbContext.SupervisorsOrder.Add(supervisorModel);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public async Task<SupervisorModelDto> GetSupervisorOrderDetails(string orderNo)
        {
            try
            {
                var orderDetails = await _applicationDbContext.SupervisorsOrder.Where(x => x.OrderNo == orderNo).FirstOrDefaultAsync();
                var orderDetailsToDisplay = _mapper.Map<SupervisorModelDto>(orderDetails);
                return orderDetailsToDisplay;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
