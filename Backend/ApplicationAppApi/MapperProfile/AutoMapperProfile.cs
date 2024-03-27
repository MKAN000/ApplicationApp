using ApplicationAppApi.Models.ApplicantModel;
using ApplicationAppApi.Models.ApplicantModel.DTO;
using AutoMapper;

namespace ApplicationAppApi.MapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
                CreateMap<ApplicantModel, ApplicantModelDto>();
        }
    }
}
