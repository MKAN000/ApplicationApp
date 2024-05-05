using ApplicationAppApi.Models.Applicant;
using ApplicationAppApi.Models.Applicant.DTO;
using ApplicationAppApi.Models.Application;
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
            CreateMap<ApplicationModel, TextFileModel>()
            .ForMember(dest => dest.application, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.applicant, opt => opt.Ignore())
            .ForMember(dest => dest.supervisor, opt => opt.Ignore());

        }
    }
}
