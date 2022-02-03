using AutoMapper;
using Philcosa.Application.Interfaces.Repositories;
using Philcosa.Domain.Entities;
using Philcosa.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Philcosa.Application.Features.CoverValues.Queries.GetById
{
    public class GetCoverValueByIdQuery : IRequest<Result<GetCoverValueByIdResponse>>
    {
        public int Id { get; set; }
    }

    public class GetCoverValueByIdQueryHandler : IRequestHandler<GetCoverValueByIdQuery, Result<GetCoverValueByIdResponse>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;

        public GetCoverValueByIdQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetCoverValueByIdResponse>> Handle(GetCoverValueByIdQuery query, CancellationToken cancellationToken)
        {
            var coverValue = await _unitOfWork.Repository<CoverValue>().GetByIdAsync(query.Id);
            var mappedCoverValue = new GetCoverValueByIdResponse
            {
                Id = coverValue.Id,
                Code = coverValue.Code,
                MinValue = coverValue.MinValue,
                MaxValue = coverValue.MaxValue
            };
            return await Result<GetCoverValueByIdResponse>.SuccessAsync(mappedCoverValue);
        }
    }
}