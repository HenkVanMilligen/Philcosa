using AutoMapper;
using TestApi2.Application.Features.Documents.Commands.AddEdit;
using TestApi2.Application.Features.Documents.Queries.GetById;
using TestApi2.Domain.Entities.Misc;

namespace TestApi2.Application.Mappings
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<AddEditDocumentCommand, Document>().ReverseMap();
            CreateMap<GetDocumentByIdResponse, Document>().ReverseMap();
        }
    }
}