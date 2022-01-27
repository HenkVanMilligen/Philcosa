using AutoMapper;
using TestApi2.Application.Features.Brands.Commands.AddEdit;
using TestApi2.Application.Features.Brands.Queries.GetAll;
using TestApi2.Application.Features.Brands.Queries.GetById;
using TestApi2.Domain.Entities.Catalog;

namespace TestApi2.Application.Mappings
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<AddEditBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsResponse, Brand>().ReverseMap();
        }
    }
}