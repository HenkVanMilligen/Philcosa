using Philcosa.Application.Interfaces.Repositories;
using Philcosa.Domain.Entities;
using Philcosa.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;

namespace Philcosa.Application.Features.Covers.Commands.Delete
{
    public class DeleteCoverCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteCoverCommandHandler : IRequestHandler<DeleteCoverCommand, Result<int>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IStringLocalizer<DeleteCoverCommandHandler> _localizer;

        public DeleteCoverCommandHandler(IUnitOfWork<int> unitOfWork, IStringLocalizer<DeleteCoverCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(DeleteCoverCommand command, CancellationToken cancellationToken)
        {
            var cover = await _unitOfWork.Repository<Cover>().GetByIdAsync(command.Id);
            await _unitOfWork.Repository<Cover>().DeleteAsync(cover);
            await _unitOfWork.Commit(cancellationToken);
            return await Result<int>.SuccessAsync(cover.Id, _localizer["Cover Deleted"]);
        }
    }
}