using AutoMapper;
using Philcosa.Application.Features.Products.Commands.AddEdit;
using Philcosa.Domain.Entities.Catalog;

namespace Philcosa.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddEditProductCommand, Product>().ReverseMap();
        }
    }
}