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

namespace Philcosa.Application.Features.CoverValues.Queries.GetAll
{
    public class GetAllCoverValuesQuery : IRequest<Result<List<GetAllCoverValuesResponse>>>
    {
        public GetAllCoverValuesQuery()
        {
        }
    }

    public class GetAllCoverValuesCachedQueryHandler : IRequestHandler<GetAllCoverValuesQuery, Result<List<GetAllCoverValuesResponse>>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllCoverValuesCachedQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllCoverValuesResponse>>> Handle(GetAllCoverValuesQuery request, CancellationToken cancellationToken)
        {
            Func<Task<List<CoverValue>>> getAllCoverValues = () => _unitOfWork.Repository<CoverValue>().GetAllAsync();
            var coverValueList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllCoverValuesCacheKey, getAllCoverValues);
            var mappedCoverValues = new List<GetAllCoverValuesResponse>();
            foreach (var coverValue in coverValueList)
            {
                mappedCoverValues.Add(new GetAllCoverValuesResponse
                {
                    Id = coverValue.Id,
                    Code = coverValue.Code,
                    MinValue = coverValue.MinValue,
                    MaxValue = coverValue.MaxValue
                });
            }
            return await Result<List<GetAllCoverValuesResponse>>.SuccessAsync(mappedCoverValues);
        }
    }
}