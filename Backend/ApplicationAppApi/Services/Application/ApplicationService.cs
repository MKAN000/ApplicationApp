using ApplicationAppApi.ApplicationDataBaseContext;
using ApplicationAppApi.Models.Application;
using ApplicationAppApi.Services.Application.Interfaces;
using AutoMapper;
using System.Text;

namespace ApplicationAppApi.Services.Application
{
    public class ApplicationService : IApplication
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _applicationDbContext;
        public ApplicationService
        (
            ApplicationDbContext applicationDbContext,
            IMapper mapper
        )
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<bool> CreateApplicationText(ApplicationModel application)
        {
            try
            {
                _applicationDbContext.Applications.Add(application);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
