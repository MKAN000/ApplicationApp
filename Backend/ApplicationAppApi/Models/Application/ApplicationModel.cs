using ApplicationAppApi.Models.Applicant;
using ApplicationAppApi.Models.Supervisor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationAppApi.Models.Application
{
    public class ApplicationModel
    {
        [Key]
        public int Id { get; set; }
        public int SupervisorModelId { get; set; }
        [ForeignKey("SupervisorModelId")]
        public SupervisorModel SupervisorModel { get; set; }
        public int ApplicantModelId { get; set; }
        [ForeignKey("ApplicantModelId")]
        public ApplicantModel ApplicantModel { get; set; }
        public string ApplicationPurpose { get; set; }
        public string ToWhom { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Reason { get; set; }
        public bool IsOnDuty { get; set; }
        public bool IsHavingClasses { get; set; }
        public string arrears { get; set; }
        public bool IsHavingDisciplinaryPenalty { get; set; }
        public string VacDestination { get; set; }
    }
}
