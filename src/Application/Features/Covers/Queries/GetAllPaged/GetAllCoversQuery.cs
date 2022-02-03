using Philcosa.Application.Extensions;
using Philcosa.Application.Interfaces.Repositories;
using Philcosa.Application.Specifications;
using Philcosa.Domain.Entities;
using Philcosa.Shared.Wrapper;
using MediatR;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Philcosa.Application.Features.Covers.Queries.GetAllPaged
{
    public class GetAllCoversQuery : IRequest<PaginatedResult<GetAllPagedCoversResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }

        public GetAllCoversQuery(int pageNumber, int pageSize, string searchString)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchString = searchString;
        }
    }

    public class GetAllCoversQueryHandler : IRequestHandler<GetAllCoversQuery, PaginatedResult<GetAllPagedCoversResponse>>
    {
        private readonly ICoverRepository _coverRepository;
        private readonly IUnitOfWork<int> _unitOfWork;

        public GetAllCoversQueryHandler(IUnitOfWork<int> unitOfWork, ICoverRepository coverRepository)
        {
            _unitOfWork = unitOfWork;
            _coverRepository = coverRepository;
        }

        public async Task<PaginatedResult<GetAllPagedCoversResponse>> Handle(GetAllCoversQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Cover, GetAllPagedCoversResponse>> expression = item => new GetAllPagedCoversResponse
            {
                Id = item.Id,
                CoverDate = item.CoverDate,
                IdOnDate = item.IdOnDate,
                CoverIssuer = item.CoverIssuer.Code,
                CoverIssuerId = item.CoverIssuerId,
                Number = item.Number,
                Description = item.Description.Trim(),
                AmountIssued = item.AmountIssued,
                ImageDataUrl = item.ImageDataUrl,
                Atlas = item.Atlas,
                Alberta = item.Alberta,
                CoverType = item.CoverType.Code,
                CoverTypeId = item.CoverTypeId,
                CoverValue = item.Value.Code,
                CoverValueId = item.ValueId,
                Country = item.Country.Code,
                CountryId = item.CountryId,
                ShowDetails = false

            };

            var coverFilterSpec = new CoverFilterSpecification(request.SearchString);
            var data = await _coverRepository
                .IncludeLinkedEntities(new string[] { "CoverIssuer", "CoverType", "Value", "Country", "CoverThemes", "CoverThemes.Theme" })
               .Specify(coverFilterSpec)
               .Select(expression)
               .OrderBy(c => c.Id)
               .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            foreach (var cover in data.Data)
            {
                var themes = _unitOfWork.Repository<CoverTheme>()
                    .Entities
                    .Include(c => c.Theme)
                    .Where(x => x.CoverId == cover.Id)
                    .OrderBy(x => x.Id)
                    .Select(x => x.Theme)
                    .AsEnumerable();

                var theme1 = themes.ElementAtOrDefault(0);
                var theme2 = themes.ElementAtOrDefault(1);
                var theme3 = themes.ElementAtOrDefault(2);
                var theme4 = themes.ElementAtOrDefault(3);

                cover.Theme1 = theme1?.Name;
                cover.Theme1Id = theme1?.Id;
                cover.Theme2 = theme2?.Name;
                cover.Theme2Id = theme2?.Id;
                cover.Theme3 = theme3?.Name;
                cover.Theme3Id = theme3?.Id;
                cover.Theme4 = theme4?.Name;
                cover.Theme4Id = theme4?.Id;
            }

            return data;
        }
    }
}

//namespace Philcosa.Application.Features.Covers.Queries.GetAllPaged
//{
//    public class GetAllCoversQuery : IRequest<List<GetAllPagedCoversResponse>>
//    {
//        public int PageNumber { get; set; }
//        public int PageSize { get; set; }
//        public string SearchString { get; set; }

//        public GetAllCoversQuery(int pageNumber, int pageSize, string searchString)
//        {
//            PageNumber = pageNumber;
//            PageSize = pageSize;
//            SearchString = searchString;
//        }
//    }

//    public class GetAllCoversQueryHandler : IRequestHandler<GetAllCoversQuery, List<GetAllPagedCoversResponse>>
//    {
//        private readonly ICoverRepository _coverRepository;
//        private readonly IUnitOfWork<int> _unitOfWork;

//        public GetAllCoversQueryHandler(IUnitOfWork<int> unitOfWork, ICoverRepository coverRepository)
//        {
//            _unitOfWork = unitOfWork;
//            _coverRepository = coverRepository;
//        }

//        public async Task<List<GetAllPagedCoversResponse>> Handle(GetAllCoversQuery request, CancellationToken cancellationToken)
//        {
//            Expression<Func<Cover, GetAllPagedCoversResponse>> expression = item => new GetAllPagedCoversResponse
//            {
//                Id = item.Id,
//                CoverDate = item.CoverDate,
//                IdOnDate = item.IdOnDate,
//                CoverIssuer = item.CoverIssuer.Code,
//                CoverIssuerId = item.CoverIssuerId,
//                Number = item.Number,
//                Description = item.Description.Trim(),
//                AmountIssued = item.AmountIssued,
//                ImageDataUrl = item.ImageDataUrl,
//                Atlas = item.Atlas,
//                Alberta = item.Alberta,
//                CoverType = item.CoverType.Code,
//                CoverTypeId = item.CoverTypeId,
//                CoverValue = item.Value.Code,
//                CoverValueId = item.ValueId,
//                Country = item.Country.Code,
//                CountryId = item.CountryId,
//                ShowDetails = false

//            };

//            var coverFilterSpec = new CoverFilterSpecification(request.SearchString);
//            var data = await _coverRepository
//                .IncludeLinkedEntities(new string[] { "CoverIssuer", "CoverType", "Value", "Country", "CoverThemes", "CoverThemes.Theme" })
//               .Specify(coverFilterSpec)
//               .Select(expression)
//               .OrderBy(c => c.Id)
//               .ToListAsync(request.PageNumber, request.PageSize);

//            foreach (var cover in data)
//            {
//                var themes = _unitOfWork.Repository<CoverTheme>()
//                    .Entities
//                    .Include(c => c.Theme)
//                    .Where(x => x.CoverId == cover.Id)
//                    .Select(x => x.Theme)
//                    .AsEnumerable();

//                var theme1 = themes.ElementAtOrDefault(0);
//                var theme2 = themes.ElementAtOrDefault(1);
//                var theme3 = themes.ElementAtOrDefault(2);
//                var theme4 = themes.ElementAtOrDefault(3);

//                cover.Theme1 = theme1?.Name;
//                cover.Theme1Id = theme1?.Id;
//                cover.Theme2 = theme2?.Name;
//                cover.Theme2Id = theme2?.Id;
//                cover.Theme3 = theme3?.Name;
//                cover.Theme3Id = theme3?.Id;
//                cover.Theme4 = theme4?.Name;
//                cover.Theme4Id = theme4?.Id;
//            }

//            return data;
//        }
//    }
//}
