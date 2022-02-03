using Philcosa.Application.Features.Covers.Queries.GetAllPaged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philcosa.Client.Models.Catalog
{
    public class GetAllPagedCoversViewModel
    {

        public GetAllPagedCoversViewModel(GetAllPagedCoversResponse response)
        {
            Id = response.Id;
            CoverDate = response.CoverDate;
            IdOnDate = response.IdOnDate ?? throw new ArgumentNullException(nameof(response.IdOnDate));
            CoverIssuer = response.CoverIssuer ?? throw new ArgumentNullException(nameof(response.CoverIssuer));
            CoverIssuerId = response.CoverIssuerId;
            Number = response.Number ?? throw new ArgumentNullException(nameof(response.Number));
            Description = response.Description ?? throw new ArgumentNullException(nameof(response.Description));
            AmountIssued = response.AmountIssued ?? throw new ArgumentNullException(nameof(AmountIssued));
            Atlas = response.Atlas ?? throw new ArgumentNullException(nameof(Atlas));
            Alberta = response.Alberta ?? throw new ArgumentNullException(nameof(Alberta));
            CoverType = response.CoverType ?? throw new ArgumentNullException(nameof(CoverType));
            CoverTypeId = response.CoverTypeId;
            CoverValue = response.CoverValue ?? throw new ArgumentNullException(nameof(CoverValue));
            CoverValueId = response.CoverValueId;
            Country = response.Country ?? throw new ArgumentNullException(nameof(Country));
            CountryId = response.CountryId;
            Theme1 = response.Theme1 ?? throw new ArgumentNullException(nameof(Theme1));
            Theme1Id = response.Theme1Id;
            Theme2 = response.Theme2 ?? throw new ArgumentNullException(nameof(Theme2));
            Theme2Id = response.Theme2Id;
            Theme3 = response.Theme3 ?? throw new ArgumentNullException(nameof(Theme3));
            Theme3Id = response.Theme3Id;
            Theme4 = response.Theme4 ?? throw new ArgumentNullException(nameof(Theme4));
            Theme4Id = response.Theme4Id;
            ShowDetails = false;
        }

        public int Id { get; set; }
        public DateTime CoverDate { get; set; }
        public string IdOnDate { get; set; }
        public string CoverIssuer { get; set; }
        public int? CoverIssuerId { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public string AmountIssued { get; set; }
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
