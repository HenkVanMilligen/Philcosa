using Philcosa.Domain.Entities;
using System.Collections.Generic;

namespace Philcosa.Application.Features.CoverValues.Queries.GetAll
{
    public class GetAllCoverValuesResponse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }

    }
}