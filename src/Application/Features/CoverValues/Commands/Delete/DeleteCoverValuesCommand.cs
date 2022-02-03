using Philcosa.Application.Interfaces.Repositories;
using Philcosa.Domain.Entities.Catalog;
using Philcosa.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using Philcosa.Shared.Constants.Application;

namespace Philcosa.Application.Features.CoverValues.Commands.Delete
{
    public class DeleteCoverValueCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteCoverValueCommandHandler : IRequestHandler<DeleteCoverValueCommand, Result<int>>
    {
        private readonly ICoverValueRepository _coverValueRepository;
        private readonly IStringLocalizer<DeleteCoverValueCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public DeleteCoverValueCommandHandler(IUnitOfWork<int> unitOfWork, ICoverValueRepository coverValueRepository, IStringLocalizer<DeleteCoverValueCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _coverValueRepository = coverValueRepository;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(DeleteCoverValueCommand command, CancellationToken cancellationToken)
        {
            return await Result<int>.FailAsync("Deletion Not Allowed");
            //var isCoverValueUsed = await _countryRepository.IsCoverValueUsed(command.Id);
            //if (!isCoverValueUsed)
            //{
            //    var CoverValue = await _unitOfWork.Repository<CoverValue>().GetByIdAsync(command.Id);
            //    await _unitOfWork.Repository<CoverValue>().DeleteAsync(CoverValue);
            //    await _unitOfWork.ComitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllCoverValuesCacheKey);
            //    return await Result<int>.SuccessAsync(CoverValue.Id, _localizer["CoverValue Deleted"]);
            //}
            //else
            //{
            //    return await Result<int>.FailAsync(_localizer["Deletion Not Allowed"]);
            //}
        }
    }
}