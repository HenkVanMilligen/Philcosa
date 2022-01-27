using AutoMapper;
using TestApi2.Application.Features.DocumentTypes.Commands.AddEdit;
using TestApi2.Application.Features.DocumentTypes.Queries.GetAll;
using TestApi2.Application.Features.DocumentTypes.Queries.GetById;
using TestApi2.Domain.Entities.Misc;

namespace TestApi2.Application.Mappings
{
    public class DocumentTypeProfile : Profile
    {
        public DocumentTypeProfile()
        {
            CreateMap<AddEditDocumentTypeCommand, DocumentType>().ReverseMap();
            CreateMap<GetDocumentTypeByIdResponse, DocumentType>().ReverseMap();
            CreateMap<GetAllDocumentTypesResponse, DocumentType>().ReverseMap();
        }
    }
}