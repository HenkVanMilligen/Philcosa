using AutoMapper;
using Philcosa.Application.Interfaces.Repositories;
using Philcosa.Domain.Entities;
using Philcosa.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Philcosa.Application.Features.CoverImages.Queries.GetById
{
    public class GetCoverImageByIdQuery : IRequest<Result<GetCoverImageByIdResponse>>
    {
        public int Id { get; set; }
    }

    public class GetCoverTypeByIdQueryHandler : IRequestHandler<GetCoverImageByIdQuery, Result<GetCoverImageByIdResponse>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;

        public GetCoverTypeByIdQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetCoverImageByIdResponse>> Handle(GetCoverImageByIdQuery query, CancellationToken cancellationToken)
        {
            var coverType = await _unitOfWork.Repository<CoverType>().GetByIdAsync(query.Id);
            var mappedCoverType = new GetCoverImageByIdResponse
            {
                Id = coverType.Id,
                Code = coverType.Code,
                Name = coverType.Name
            };
            return await Result<GetCoverImageByIdResponse>.SuccessAsync(mappedCoverType);
        }
    }
}