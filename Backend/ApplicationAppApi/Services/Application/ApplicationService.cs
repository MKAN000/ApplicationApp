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

            var textFileModel = _mapper.Map<ApplicationModel, TextFileModel>(application);

            var applicant = await _applicationDbContext.Applicants.FirstOrDefaultAsync(x => x.AlbumNumber == application.ApplicantModelAlbumNumber);

            var order = await _applicationDbContext.SupervisorsOrder.FirstOrDefaultAsync(x => x.OrderNo == application.SupervisorModelOrderNo);

            textFileModel.applicant = applicant;
            textFileModel.supervisor = order;

            var _filePath = Path.Combine(filePath, $"Nagrodówka_{applicationId}.txt");
            
            await GenerateTxtFileFromObj(textFileModel, _filePath);

        }

        private async Task GenerateTxtFileFromObj(TextFileModel? application, string filePath)
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
