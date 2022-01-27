using AutoMapper;
using TestApi2.Application.Features.Products.Commands.AddEdit;
using TestApi2.Domain.Entities.Catalog;

namespace TestApi2.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddEditProductCommand, Product>().ReverseMap();
        }
    }
}