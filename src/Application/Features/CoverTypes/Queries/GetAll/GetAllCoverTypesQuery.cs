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

namespace Philcosa.Application.Features.CoverTypes.Queries.GetAll
{
    public class GetAllCoverTypesQuery : IRequest<Result<List<GetAllCoverTypesResponse>>>
    {
        public GetAllCoverTypesQuery()
        {
        }
    }

    public class GetAllCoverTypesCachedQueryHandler : IRequestHandler<GetAllCoverTypesQuery, Result<List<GetAllCoverTypesResponse>>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllCoverTypesCachedQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllCoverTypesResponse>>> Handle(GetAllCoverTypesQuery request, CancellationToken cancellationToken)
        {
            Func<Task<List<CoverType>>> getAllCoverTypes = () => _unitOfWork.Repository<CoverType>().GetAllAsync();
            var coverTypeList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllCoverTypesCacheKey, getAllCoverTypes);
            var mappedCoverTypes = new List<GetAllCoverTypesResponse>();
            foreach (var coverType in coverTypeList)
            {
                mappedCoverTypes.Add(new GetAllCoverTypesResponse
                {
                    Id = coverType.Id,
                    Code = coverType.Code,
                    Name = coverType.Name
                });
            }
            return await Result<List<GetAllCoverTypesResponse>>.SuccessAsync(mappedCoverTypes);
        }
    }
}