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

namespace Philcosa.Application.Features.CoverImages.Queries.GetAll
{
    public class GetAllCoverImagesQuery : IRequest<Result<List<GetAllCoverImagesResponse>>>
    {
        public GetAllCoverImagesQuery()
        {
        }
    }

    public class GetAllCoverImagesCachedQueryHandler : IRequestHandler<GetAllCoverImagesQuery, Result<List<GetAllCoverImagesResponse>>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllCoverImagesCachedQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllCoverImagesResponse>>> Handle(GetAllCoverImagesQuery request, CancellationToken cancellationToken)
        {
            Func<Task<List<CoverType>>> GetAllCoverImages = () => _unitOfWork.Repository<CoverType>().GetAllAsync();
            var coverImagesList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllCoverImagesCacheKey, GetAllCoverImages);
            var mappedCoverImages = new List<GetAllCoverImagesResponse>();
            foreach (var coverImage in coverImagesList)
            {
                mappedCoverImages.Add(new GetAllCoverImagesResponse
                {
                    Id = coverImage.Id,
                    Code = coverImage.Code,
                    Name = coverImage.Name
                });
            }
            return await Result<List<GetAllCoverImagesResponse>>.SuccessAsync(mappedCoverImages);
        }
    }
}