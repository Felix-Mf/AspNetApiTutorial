using AutoMapper;
using Supermarket.Domain.Models;
using Supermarket.Resources;

namespace Supermarket.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();

            CreateMap<SaveProductResource, Product>()
                .ForMember(src => src.UnitOfMeasurement, opt => opt.MapFrom(src => src.UnitOfMeasurement));
        }
    }
}