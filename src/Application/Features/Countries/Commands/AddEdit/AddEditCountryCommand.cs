using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Philcosa.Domain.Entities;
using Philcosa.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using Philcosa.Shared.Constants.Application;
using Philcosa.Application.Interfaces.Repositories;

namespace Philcosa.Application.Features.Countries.Commands.AddEdit
{
    public partial class AddEditCountryCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public class AddEditCountryCommandHandler : IRequestHandler<AddEditCountryCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditCountryCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public AddEditCountryCommandHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IStringLocalizer<AddEditCountryCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(AddEditCountryCommand command, CancellationToken cancellationToken)
        {
            if (command.Id == 0)
            {
                var country = new Country
                {
                    Id = _unitOfWork.Repository<Country>().GetAllAsync().Result.Count + 1,
                    Code = command.Code,
                    Name = command.Name
                };
                    
                await _unitOfWork.Repository<Country>().AddAsync(country);
                await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllCountriesCacheKey);
                return await Result<int>.SuccessAsync(country.Id, _localizer["Country Saved"]);
            }
            else
            {
                var country = await _unitOfWork.Repository<Country>().GetByIdAsync(command.Id);
                if (country != null)
                {
                    country.Code = command.Code ?? country.Code;
                    country.Name = command.Name ?? country.Name;
                    await _unitOfWork.Repository<Country>().UpdateAsync(country);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllCountriesCacheKey);
                    return await Result<int>.SuccessAsync(country.Id, _localizer["Country Updated"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Country Not Found!"]);
                }
            }
        }
    }
}