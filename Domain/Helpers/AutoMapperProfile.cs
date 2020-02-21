using AutoMapper;

namespace Domain.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Entities.User, Dtos.User >();
            CreateMap<Dtos.User, Entities.User>();
        }
    }
}
