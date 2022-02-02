using AutoMapper;
using Philcosa.Application.Responses.Audit;
using Philcosa.Infrastructure.Models.Audit;

namespace Philcosa.Infrastructure.Mappings
{
    public class AuditProfile : Profile
    {
        public AuditProfile()
        {
            CreateMap<AuditResponse, Audit>().ReverseMap();
        }
    }
}