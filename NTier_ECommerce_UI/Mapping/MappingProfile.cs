using AutoMapper;
using NTier_ECommerce_Entities;
using NTier_ECommerce_UI.ViewModels;

namespace NTier_ECommerce_UI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VMNewMovie, Movie>().ReverseMap();
        }
    }
}
