using ApplicationAppApi.ApplicationDataBaseContext;
using ApplicationAppApi.Models.Applicant;
using ApplicationAppApi.Models.Application;
using ApplicationAppApi.Models.Application.DTO;
using ApplicationAppApi.Models.Supervisor;
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

            var applicant = await _applicationDbContext.Applicants.FirstOrDefaultAsync(x => x.AlbumNumber == application.ApplicantModelAlbumNumber);

            var order = await _applicationDbContext.SupervisorsOrder.FirstOrDefaultAsync(x => x.OrderNo == application.SupervisorModelOrderNo);


            var applicationTextToGenerate = new ApplicationDtoModel();

            _mapper.Map(application, applicationTextToGenerate);
            _mapper.Map(applicant, applicationTextToGenerate);
            _mapper.Map(order, applicationTextToGenerate);

            var _filePath = Path.Combine(filePath, $"Nagrodówka_{applicationId}.txt");
            
            await GenerateTxtFileFromObj(applicationTextToGenerate, _filePath);

        }

        private async Task GenerateTxtFileFromObj(ApplicationDtoModel? application, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Wartości dla ApplicationDtoModel
                foreach (var item in application.GetType().GetProperties())
                {
                    await writer.WriteLineAsync($"{item.Name}: {item.GetValue(application)}");
                }

            }
        }

    }
}
