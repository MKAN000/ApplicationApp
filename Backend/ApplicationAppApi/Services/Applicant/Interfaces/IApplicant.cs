using ApplicationAppApi.Models.ApplicantModel;

namespace ApplicationAppApi.Services.Applicant.Interfaces
{
    public interface IApplicant
    {
        Task<bool> CreateApplicantAccount(ApplicantModel applicantModel);

    }
}
