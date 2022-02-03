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

namespace Philcosa.Application.Features.Themes.Queries.GetAll
{
    public class GetAllThemesQuery : IRequest<Result<List<GetAllThemesResponse>>>
    {
        public GetAllThemesQuery()
        {
        }
    }

    public class GetAllThemesCachedQueryHandler : IRequestHandler<GetAllThemesQuery, Result<List<GetAllThemesResponse>>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllThemesCachedQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllThemesResponse>>> Handle(GetAllThemesQuery request, CancellationToken cancellationToken)
        {
            Func<Task<List<Theme>>> getAllThemes = () => _unitOfWork.Repository<Theme>().GetAllAsync();
            var themeList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllThemesCacheKey, getAllThemes);
            var mappedThemes = new List<GetAllThemesResponse>();
            foreach (var theme in themeList)
            {
                mappedThemes.Add(new GetAllThemesResponse
                {
                    Id = theme.Id,
                    Name = theme.Name
                });
            }
            return await Result<List<GetAllThemesResponse>>.SuccessAsync(mappedThemes.OrderBy(x => x.Name).ToList());
        }
    }
}