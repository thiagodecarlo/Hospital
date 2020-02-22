using AutoMapper;

namespace Hospital.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Domain.Entities.Hospital, Domain.Dtos.Hospital>();
            CreateMap<Domain.Dtos.Hospital, Domain.Entities.Hospital>();

            CreateMap<Domain.Entities.Nurse, Domain.Dtos.Nurse>();
            CreateMap<Domain.Dtos.Nurse, Domain.Entities.Nurse>();
        }
    }
}
