using ApplicationAppApi.ApplicationDataBaseContext;
using ApplicationAppApi.Models.ApplicantModel;
using ApplicationAppApi.Services.Applicant.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace ApplicationAppApi.Services.Applicant
{
    public class ApplicantService : IApplicant
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
       
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
    }
}
