using AutoMapper;
using TestApi2.Infrastructure.Models.Audit;
using TestApi2.Application.Responses.Audit;

namespace TestApi2.Infrastructure.Mappings
{
    public class AuditProfile : Profile
    {
        public AuditProfile()
        {
            CreateMap<AuditResponse, Audit>().ReverseMap();
        }
    }
}