using ApplicationAppApi.Models.Applicant;
using ApplicationAppApi.Models.Applicant.DTO;
using ApplicationAppApi.Models.Supervisor;
using ApplicationAppApi.Models.Supervisor.DTO;
using AutoMapper;

namespace ApplicationAppApi.MapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicantModel, ApplicantModelDto>();
            CreateMap<SupervisorModel, SupervisorModelDto>();
            
        }
    }
}
