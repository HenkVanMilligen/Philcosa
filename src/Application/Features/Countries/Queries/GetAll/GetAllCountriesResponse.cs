using Philcosa.Domain.Entities;
using System.Collections.Generic;

namespace Philcosa.Application.Features.Countries.Queries.GetAll
{
    public class GetAllCountriesResponse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

    }
}