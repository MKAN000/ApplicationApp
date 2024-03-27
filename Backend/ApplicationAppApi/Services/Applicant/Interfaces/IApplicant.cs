using ApplicationAppApi.Models.ApplicantModel;
using ApplicationAppApi.Models.ApplicantModel.DTO;

namespace ApplicationAppApi.Services.Applicant.Interfaces
{
    public interface IApplicant
    {
        Task<bool> CreateApplicantAccount(ApplicantModel applicantModel);
        Task<ApplicantModelDto> GetApplicantData(int albumNumber); 

    }
}
