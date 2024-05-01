using ApplicationAppApi.ApplicationDataBaseContext;
using ApplicationAppApi.Models.Applicant;
using ApplicationAppApi.Models.Applicant.DTO;
using ApplicationAppApi.Services.Applicant.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApplicationAppApi.Services.Applicant
{
    public class ApplicantService : IApplicant
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
       
        public ApplicantService
        (
            ApplicationDbContext applicationDbContext,
            IMapper mapper
        )
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<bool> CreateApplicantAccount(ApplicantModel applicantModel)
        {
            try
            {
                _applicationDbContext.Applicants.Add(applicantModel);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ApplicantModelDto> GetApplicantData(int albumNumber)
        {
            try
            {
                var applicantData = await _applicationDbContext.Applicants.Where(x=>x.AlbumNumber == albumNumber).FirstOrDefaultAsync();
                var applicantDataToDisplay = _mapper.Map<ApplicantModelDto>(applicantData);
                return applicantDataToDisplay;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}
