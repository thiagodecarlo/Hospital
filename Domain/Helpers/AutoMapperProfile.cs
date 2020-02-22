using AutoMapper;

namespace Domain.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Entities.Nurse, Dtos.Nurse>();
            CreateMap<Dtos.Hospital, Entities.Hospital>();
        }
    }
}
