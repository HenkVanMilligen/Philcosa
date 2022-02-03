using Philcosa.Application.Interfaces.Repositories;
using Philcosa.Domain.Entities.Catalog;
using Philcosa.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using Philcosa.Shared.Constants.Application;

namespace Philcosa.Application.Features.Themes.Commands.Delete
{
    public class DeleteThemeCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteThemeCommandHandler : IRequestHandler<DeleteThemeCommand, Result<int>>
    {
        private readonly IThemeRepository _themeRepository;
        private readonly IStringLocalizer<DeleteThemeCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public DeleteThemeCommandHandler(IUnitOfWork<int> unitOfWork, IThemeRepository themeRepository, IStringLocalizer<DeleteThemeCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _themeRepository = themeRepository;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(DeleteThemeCommand command, CancellationToken cancellationToken)
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