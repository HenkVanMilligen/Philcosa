using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Philcosa.Application.Interfaces.Repositories;
using Philcosa.Domain.Entities;
using Philcosa.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using Philcosa.Shared.Constants.Application;

namespace Philcosa.Application.Features.Themes.Commands.AddEdit
{
    public partial class AddEditThemeCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public class AddEditThemeCommandHandler : IRequestHandler<AddEditThemeCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditThemeCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public AddEditThemeCommandHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IStringLocalizer<AddEditThemeCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(AddEditThemeCommand command, CancellationToken cancellationToken)
        {
            if (command.Id == 0)
            {
                var theme = new Theme
                {
                    Id = _unitOfWork.Repository<Theme>().GetAllAsync().Result.Count + 1,
                    Name = command.Name
                };
                await _unitOfWork.Repository<Theme>().AddAsync(theme);
                await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllThemesCacheKey);
                return await Result<int>.SuccessAsync(theme.Id, _localizer["Theme Saved"]);
            }
            else
            {
                var theme = await _unitOfWork.Repository<Theme>().GetByIdAsync(command.Id);
                if (theme != null)
                {
                    theme.Name = command.Name ?? theme.Name;
                    await _unitOfWork.Repository<Theme>().UpdateAsync(theme);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllThemesCacheKey);
                    return await Result<int>.SuccessAsync(theme.Id, _localizer["Theme Updated"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Theme Not Found!"]);
                }
            }
        }
    }
}