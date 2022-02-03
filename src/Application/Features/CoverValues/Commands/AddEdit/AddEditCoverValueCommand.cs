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

namespace Philcosa.Application.Features.CoverValues.Commands.AddEdit
{
    public partial class AddEditCoverValueCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        public decimal? MinValue { get; set; }

        public decimal? MaxValue { get; set; }


    }

    public class AddEditCoverValueCommandHandler : IRequestHandler<AddEditCoverValueCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditCoverValueCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public AddEditCoverValueCommandHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IStringLocalizer<AddEditCoverValueCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(AddEditCoverValueCommand command, CancellationToken cancellationToken)
        {
            if (command.Id == 0)
            {
                var coverValue = new CoverValue
                {
                    Id = _unitOfWork.Repository<CoverValue>().GetAllAsync().Result.Count + 1,
                    Code = command.Code,
                    MinValue = command.MinValue,
                    MaxValue = command.MaxValue
                };
                await _unitOfWork.Repository<CoverValue>().AddAsync(coverValue);
                await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllCoverValuesCacheKey);
                return await Result<int>.SuccessAsync(coverValue.Id, _localizer["CoverValue Saved"]);
            }
            else
            {
                var coverValue = await _unitOfWork.Repository<CoverValue>().GetByIdAsync(command.Id);
                if (coverValue != null)
                {
                    coverValue.Code = command.Code ?? coverValue.Code;
                    coverValue.MinValue = command.MinValue ?? coverValue.MinValue;
                    coverValue.MaxValue = command.MaxValue ?? coverValue.MaxValue;
                    await _unitOfWork.Repository<CoverValue>().UpdateAsync(coverValue);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllCoverValuesCacheKey);
                    return await Result<int>.SuccessAsync(coverValue.Id, _localizer["CoverValue Updated"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["CoverValue Not Found!"]);
                }
            }
        }
    }
}