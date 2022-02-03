using AutoMapper;
using Philcosa.Application.Interfaces.Repositories;
using Philcosa.Domain.Entities;
using Philcosa.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Philcosa.Application.Features.CoverIssuers.Queries.GetById
{
    public class GetCoverIssuerByIdQuery : IRequest<Result<GetCoverIssuerByIdResponse>>
    {
        public int Id { get; set; }
    }

    public class GetCoverIssuerByIdQueryHandler : IRequestHandler<GetCoverIssuerByIdQuery, Result<GetCoverIssuerByIdResponse>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;

        public GetCoverIssuerByIdQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetCoverIssuerByIdResponse>> Handle(GetCoverIssuerByIdQuery query, CancellationToken cancellationToken)
        {
            var coverIssuer = await _unitOfWork.Repository<CoverIssuer>().GetByIdAsync(query.Id);
            var mappedCoverIssuer = new GetCoverIssuerByIdResponse
            {
                Id = coverIssuer.Id,
                Code = coverIssuer.Code,
                Name = coverIssuer.Name
            };
            return await Result<GetCoverIssuerByIdResponse>.SuccessAsync(mappedCoverIssuer);
        }
    }
}