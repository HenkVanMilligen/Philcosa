using AutoMapper;
using Philcosa.Application.Interfaces.Repositories;
using Philcosa.Domain.Entities;
using Philcosa.Shared.Constants.Application;
using Philcosa.Shared.Wrapper;
using LazyCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Philcosa.Application.Features.CoverIssuers.Queries.GetAll
{
    public class GetAllCoverIssuersQuery : IRequest<Result<List<GetAllCoverIssuersResponse>>>
    {
        public GetAllCoverIssuersQuery()
        {
        }
    }

    public class GetAllCoverIssuersCachedQueryHandler : IRequestHandler<GetAllCoverIssuersQuery, Result<List<GetAllCoverIssuersResponse>>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllCoverIssuersCachedQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllCoverIssuersResponse>>> Handle(GetAllCoverIssuersQuery request, CancellationToken cancellationToken)
        {
            Func<Task<List<CoverIssuer>>> getAllCoverIssuers = () => _unitOfWork.Repository<CoverIssuer>().GetAllAsync();
            var coverIssuerList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllCoverIssuersCacheKey, getAllCoverIssuers);
            var mappedCoverIssuers = new List<GetAllCoverIssuersResponse>();
            foreach (var coverIssuer in coverIssuerList)
            {
                mappedCoverIssuers.Add(new GetAllCoverIssuersResponse
                {
                    Id = coverIssuer.Id,
                    Code = coverIssuer.Code,
                    Name = coverIssuer.Name
                });
            }
            return await Result<List<GetAllCoverIssuersResponse>>.SuccessAsync(mappedCoverIssuers);
        }
    }
}