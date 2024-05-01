using ApplicationAppApi.Models.Applicant;
using ApplicationAppApi.Models.Applicant.DTO;

namespace ApplicationAppApi.Services.Applicant.Interfaces
{
    public interface IApplicant
    {
        Task<bool> CreateApplicantAccount(ApplicantModel applicantModel);
        Task<ApplicantModelDto> GetApplicantData(int albumNumber); 

    }
}
