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

namespace Philcosa.Application.Features.Countries.Queries.GetAll
{
    public class GetAllCountriesQuery : IRequest<Result<List<GetAllCountriesResponse>>>
    {
        public GetAllCountriesQuery()
        {
        }
    }

    public class GetAllCountriesCachedQueryHandler : IRequestHandler<GetAllCountriesQuery, Result<List<GetAllCountriesResponse>>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllCountriesCachedQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllCountriesResponse>>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            Func<Task<List<Country>>> getAllCountries = () => _unitOfWork.Repository<Country>().GetAllAsync();
            var countryList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllCountriesCacheKey, getAllCountries);
            var mappedCountries = new List<GetAllCountriesResponse>();
            foreach (var country in countryList)
            {
                mappedCountries.Add(new GetAllCountriesResponse
                {
                    Id = country.Id,
                    Code = country.Code,
                    Name = country.Name
                });
            }
            return await Result<List<GetAllCountriesResponse>>.SuccessAsync(mappedCountries);
        }
    }
}