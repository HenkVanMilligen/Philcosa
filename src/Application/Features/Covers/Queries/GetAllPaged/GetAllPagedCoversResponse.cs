using System;

namespace Philcosa.Application.Features.Covers.Queries.GetAllPaged
{
    public class GetAllPagedCoversResponse
    {
        public int Id { get; set; }
        public DateTime CoverDate { get; set; }
        public string IdOnDate { get; set; }
        public string CoverIssuer { get; set; }
        public int? CoverIssuerId { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public string AmountIssued { get; set; }
        public string ImageDataUrl { get; set; }
        public string Atlas { get; set; }
        public string Alberta { get; set; }
        public string CoverType { get; set; }
        public int? CoverTypeId { get; set; }
        public string CoverValue { get; set; }
        public int? CoverValueId { get; set; }
        public string Country { get; set; }
        public int? CountryId { get; set; }
        public string Theme1 { get; set; }
        public int? Theme1Id { get; set; }
        public string Theme2 { get; set; }
        public int? Theme2Id { get; set; }
        public string Theme3 { get; set; }
        public int? Theme3Id { get; set; }
        public string Theme4 { get; set; }
        public int? Theme4Id { get; set; }
        public bool ShowDetails { get; set; }

    }
}