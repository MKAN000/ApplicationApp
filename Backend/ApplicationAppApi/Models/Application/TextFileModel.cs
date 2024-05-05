using ApplicationAppApi.Models.Applicant;
using ApplicationAppApi.Models.Supervisor;

namespace ApplicationAppApi.Models.Application
{
    public class TextFileModel
    {
        public ApplicantModel applicant { get; set; }
        public ApplicationModel application { get; set; }
        public SupervisorModel supervisor { get; set; }
    }
}
