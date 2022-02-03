using Philcosa.Domain.Entities;
using System.Collections.Generic;

namespace Philcosa.Application.Features.CoverImages.Queries.GetAll
{
    public class GetAllCoverImagesResponse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

    }
}