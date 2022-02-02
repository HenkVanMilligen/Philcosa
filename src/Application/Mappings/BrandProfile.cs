using AutoMapper;
using Philcosa.Application.Features.Brands.Commands.AddEdit;
using Philcosa.Application.Features.Brands.Queries.GetAll;
using Philcosa.Application.Features.Brands.Queries.GetById;
using Philcosa.Domain.Entities.Catalog;

namespace Philcosa.Application.Mappings
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