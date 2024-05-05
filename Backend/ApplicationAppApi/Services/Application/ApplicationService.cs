using ApplicationAppApi.ApplicationDataBaseContext;
using ApplicationAppApi.Models.Application;
using ApplicationAppApi.Services.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task CreateFilePath(string filePath, int applicationId)
        {
            var application = await _applicationDbContext.Applications.FirstOrDefaultAsync(x => x.Id == applicationId);
           

            var _filePath = Path.Combine(filePath, $"Nagrodówka_{applicationId}.txt");
            
            await GenerateTxtFileFromObj(application, _filePath);

        }

        private async Task GenerateTxtFileFromObj(ApplicationModel? application, string filePath)
        {
            using(StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var item in application.GetType().GetProperties())
                {
                    await writer.WriteLineAsync($"{item.Name}: {item.GetValue(application)}");
                }
            }
        }
    }
}
