using Philcosa.Domain.Entities;
using System.Collections.Generic;

namespace Philcosa.Application.Features.CoverTypes.Queries.GetAll
{
    public class GetAllCoverTypesResponse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

    }
}