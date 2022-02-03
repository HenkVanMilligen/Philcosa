﻿using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Philcosa.Application.Interfaces.Repositories;
using Philcosa.Domain.Entities;
using Philcosa.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using Philcosa.Shared.Constants.Application;

namespace Philcosa.Application.Features.CoverImages.Commands.UploadToAzureCoverImage
{
    public partial class UploadToAzureCoverImageCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public class UploadToAzureCoverImageCommandHandler : IRequestHandler<UploadToAzureCoverImageCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<UploadToAzureCoverImageCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public UploadToAzureCoverImageCommandHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IStringLocalizer<UploadToAzureCoverImageCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(UploadToAzureCoverImageCommand command, CancellationToken cancellationToken)
        {
            if (command.Id == 0)
            {
                var coverType = new CoverType
                {
                    Id = _unitOfWork.Repository<CoverType>().GetAllAsync().Result.Count + 1,
                    Code = command.Code,
                    Name = command.Name
                };
                await _unitOfWork.Repository<CoverType>().AddAsync(coverType);
                await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllCoverTypesCacheKey);
                return await Result<int>.SuccessAsync(coverType.Id, _localizer["CoverType Saved"]);
            }
            else
            {
                var coverType = await _unitOfWork.Repository<CoverType>().GetByIdAsync(command.Id);
                if (coverType != null)
                {
                    coverType.Code = command.Code ?? coverType.Code;
                    coverType.Name = command.Name ?? coverType.Name;
                    await _unitOfWork.Repository<CoverType>().UpdateAsync(coverType);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllCoverTypesCacheKey);
                    return await Result<int>.SuccessAsync(coverType.Id, _localizer["CoverType Updated"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["CoverType Not Found!"]);
                }
            }
        }
    }
}