using AutoMapper;
using Philcosa.Application.Interfaces.Repositories;
using Philcosa.Domain.Entities;
using Philcosa.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Philcosa.Application.Features.Countries.Queries.GetById
{
    public class GetCountryByIdQuery : IRequest<Result<GetCountryByIdResponse>>
    {
        public int Id { get; set; }
    }

    public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, Result<GetCountryByIdResponse>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;

        public GetCountryByIdQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetCountryByIdResponse>> Handle(GetCountryByIdQuery query, CancellationToken cancellationToken)
        {
            var country = await _unitOfWork.Repository<Country>().GetByIdAsync(query.Id);
            var mappedCountry = new GetCountryByIdResponse
            {
                Id = country.Id,
                Code = country.Code,
                Name = country.Name
            };
            return await Result<GetCountryByIdResponse>.SuccessAsync(mappedCountry);
        }
    }
}