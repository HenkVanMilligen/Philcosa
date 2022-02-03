using AutoMapper;
using Philcosa.Application.Interfaces.Repositories;
using Philcosa.Domain.Entities;
using Philcosa.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Philcosa.Application.Features.CoverTypes.Queries.GetById
{
    public class GetCoverIssuerByIdQuery : IRequest<Result<GetCoverIssuerByIdResponse>>
    {
        public int Id { get; set; }
    }

    public class GetCoverTypeByIdQueryHandler : IRequestHandler<GetCoverIssuerByIdQuery, Result<GetCoverIssuerByIdResponse>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;

        public GetCoverTypeByIdQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetCoverIssuerByIdResponse>> Handle(GetCoverIssuerByIdQuery query, CancellationToken cancellationToken)
        {
            var coverType = await _unitOfWork.Repository<CoverType>().GetByIdAsync(query.Id);
            var mappedCoverType = new GetCoverIssuerByIdResponse
            {
                Id = coverType.Id,
                Code = coverType.Code,
                Name = coverType.Name
            };
            return await Result<GetCoverIssuerByIdResponse>.SuccessAsync(mappedCoverType);
        }
    }
}