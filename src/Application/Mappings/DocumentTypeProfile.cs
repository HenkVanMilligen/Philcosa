using AutoMapper;
using Philcosa.Application.Features.DocumentTypes.Commands.AddEdit;
using Philcosa.Application.Features.DocumentTypes.Queries.GetAll;
using Philcosa.Application.Features.DocumentTypes.Queries.GetById;
using Philcosa.Domain.Entities.Misc;

namespace Philcosa.Application.Mappings
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