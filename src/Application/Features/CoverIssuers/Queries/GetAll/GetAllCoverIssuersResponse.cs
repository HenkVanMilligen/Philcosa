using Philcosa.Domain.Entities;
using System.Collections.Generic;

namespace Philcosa.Application.Features.CoverIssuers.Queries.GetAll
{
    public class GetAllCoverIssuersResponse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

    }
}