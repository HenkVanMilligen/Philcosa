using Philcosa.Application.Interfaces.Repositories;
using Philcosa.Domain.Entities;
using Philcosa.Shared.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Philcosa.Application.Features.Covers.Queries.GetCoverImage
{
    public class GetCoverImageQuery : IRequest<Result<string>>
    {
        public int Id { get; set; }

        public GetCoverImageQuery(int coverId)
        {
            Id = coverId;
        }
    }

    public class GetCoverImageQueryHandler : IRequestHandler<GetCoverImageQuery, Result<string>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;

        public GetCoverImageQueryHandler(IUnitOfWork<int> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(GetCoverImageQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<Cover>().Entities.Where(p => p.Id == request.Id).Select(a => a.ImageDataUrl).FirstOrDefaultAsync(cancellationToken);
            return await Result<string>.SuccessAsync(data: data);
        }
    }
}