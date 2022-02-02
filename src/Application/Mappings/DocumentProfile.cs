using AutoMapper;
using Philcosa.Application.Features.Documents.Commands.AddEdit;
using Philcosa.Application.Features.Documents.Queries.GetById;
using Philcosa.Domain.Entities.Misc;

namespace Philcosa.Application.Mappings
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