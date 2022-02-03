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

namespace Philcosa.Application.Features.CoverIssuers.Commands.AddEdit
{
    public partial class AddEditCoverIssuerCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public class AddEditCoverIssuerCommandHandler : IRequestHandler<AddEditCoverIssuerCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditCoverIssuerCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public AddEditCoverIssuerCommandHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IStringLocalizer<AddEditCoverIssuerCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(AddEditCoverIssuerCommand command, CancellationToken cancellationToken)
        {
            if (command.Id == 0)
            {
                var coverIssuer = new CoverIssuer
                {
                    Id = _unitOfWork.Repository<CoverIssuer>().GetAllAsync().Result.Count + 1,
                    Code = command.Code,
                    Name = command.Name
                };
                await _unitOfWork.Repository<CoverIssuer>().AddAsync(coverIssuer);
                await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllCoverIssuersCacheKey);
                return await Result<int>.SuccessAsync(coverIssuer.Id, _localizer["CoverIssuer Saved"]);
            }
            else
            {
                var coverIssuer = await _unitOfWork.Repository<CoverIssuer>().GetByIdAsync(command.Id);
                if (coverIssuer != null)
                {
                    coverIssuer.Code = command.Code ?? coverIssuer.Code;
                    coverIssuer.Name = command.Name ?? coverIssuer.Name;
                    await _unitOfWork.Repository<CoverIssuer>().UpdateAsync(coverIssuer);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllCoverIssuersCacheKey);
                    return await Result<int>.SuccessAsync(coverIssuer.Id, _localizer["CoverIssuer Updated"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["CoverIssuer Not Found!"]);
                }
            }
        }
    }
}