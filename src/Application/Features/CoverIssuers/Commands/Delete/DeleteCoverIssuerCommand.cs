using Philcosa.Application.Interfaces.Repositories;
using Philcosa.Domain.Entities.Catalog;
using Philcosa.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using Philcosa.Shared.Constants.Application;

namespace Philcosa.Application.Features.CoverIssuers.Commands.Delete
{
    public class DeleteCoverIssuerCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteCoverIssuerCommandHandler : IRequestHandler<DeleteCoverIssuerCommand, Result<int>>
    {
        private readonly ICoverIssuerRepository _coverIssuerRepository;
        private readonly IStringLocalizer<DeleteCoverIssuerCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public DeleteCoverIssuerCommandHandler(IUnitOfWork<int> unitOfWork, ICoverIssuerRepository coverIssuerRepository, IStringLocalizer<DeleteCoverIssuerCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _coverIssuerRepository = coverIssuerRepository;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(DeleteCoverIssuerCommand command, CancellationToken cancellationToken)
        {
            return await Result<int>.FailAsync("Deletion Not Allowed");
            //var isCountryUsed = await _countryRepository.IsCountryUsed(command.Id);
            //if (!isCountryUsed)
            //{
            //    var Country = await _unitOfWork.Repository<Country>().GetByIdAsync(command.Id);
            //    await _unitOfWork.Repository<Country>().DeleteAsync(Country);
            //    await _unitOfWork.ComitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllCountriesCacheKey);
            //    return await Result<int>.SuccessAsync(Country.Id, _localizer["Country Deleted"]);
            //}
            //else
            //{
            //    return await Result<int>.FailAsync(_localizer["Deletion Not Allowed"]);
            //}
        }
    }
}