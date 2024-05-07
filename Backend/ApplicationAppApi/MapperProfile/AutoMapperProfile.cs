using ApplicationAppApi.Models.Applicant;
using ApplicationAppApi.Models.Applicant.DTO;
using ApplicationAppApi.Models.Application;
using ApplicationAppApi.Models.Application.DTO;
using ApplicationAppApi.Models.Supervisor;
using ApplicationAppApi.Models.Supervisor.DTO;
using ApplicationAppApi.Services.Applicant.Interfaces;
using AutoMapper;
using static System.Net.Mime.MediaTypeNames;

namespace ApplicationAppApi.MapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicantModel, ApplicantModelDto>();
            CreateMap<SupervisorModel, SupervisorModelDto>();
            CreateMap<ApplicationModel, ApplicationDtoModel>();
            CreateMap<ApplicantModel, ApplicationDtoModel>();
            CreateMap<SupervisorModel, ApplicationDtoModel>();
        }


    }
}
