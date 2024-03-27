using ApplicationAppApi.ApplicationDataBaseContext;
using ApplicationAppApi.Services.Application.Interfaces;
using AutoMapper;
using System.Text;

namespace ApplicationAppApi.Services.Application
{
    public class ApplicationService : IApplication
    {
       // private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public ApplicationService
        (
            //ApplicationDbContext applicationDbContext,
            IMapper mapper
        )
        {
            //_applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public Task<bool> SaveCsvToDb(string csvData)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UploadFileToCsv(Stream fileStream)
        {
            throw new NotImplementedException();
        }
    }
}
