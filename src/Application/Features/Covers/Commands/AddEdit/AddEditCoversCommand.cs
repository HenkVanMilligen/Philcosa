using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Philcosa.Application.Interfaces.Repositories;
using Philcosa.Application.Interfaces.Services;
using Philcosa.Application.Requests;
using Philcosa.Domain.Entities;
using Philcosa.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Philcosa.Application.Features.Covers.Commands.AddEdit
{
    public partial class AddEditCoverCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        [Required]
        public DateTime? CoverDate { get; set; }
        public int? CoverIssuerId { get; set; }
        //public string CoverIssuer { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public string AmountIssued { get; set; }
        public string Atlas { get; set; }
        public string Alberta { get; set; }
        //public string CoverType { get; set; }
        public int? CoverTypeId { get; set; }
        //public string CoverValue { get; set; }
        public int? ValueId { get; set; }
        //public string Country { get; set; }
        public int? CountryId { get; set; }
        public string ImageDataURL { get; set; }
        public int? Theme1Id { get; set; }
        public int? Theme2Id { get; set; }
        public int? Theme3Id { get; set; }
        public int? Theme4Id { get; set; }
        public UploadRequest UploadRequest { get; set; }
    }

    public class AddEditCoverCommandHandler : IRequestHandler<AddEditCoverCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IUploadService _uploadService;
        private readonly IStringLocalizer<AddEditCoverCommandHandler> _localizer;

        public AddEditCoverCommandHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IUploadService uploadService, IStringLocalizer<AddEditCoverCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _uploadService = uploadService;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(AddEditCoverCommand command, CancellationToken cancellationToken)
        {
            var uploadRequest = command.UploadRequest;
            if (uploadRequest != null)
            {
                uploadRequest.FileName = $"C-{command.CountryId}.{command.CoverDate.Value.ToShortDateString()}.{command.Number}{uploadRequest.Extension}";
            }

            //var coverIssuer = command.CoverIssuerId != null ? await _unitOfWork.Repository<CoverIssuer>().GetByIdAsync(command.CoverIssuerId.Value) : null;
            //var coverType = command.CoverTypeId != null ? await _unitOfWork.Repository<CoverType>().GetByIdAsync(command.CoverTypeId.Value) : null;
            //var coverValue = command.CoverValueId != null ? await _unitOfWork.Repository<CoverValue>().GetByIdAsync(command.CoverValueId.Value) : null;
            //var country = command.CountryId != null ? await _unitOfWork.Repository<Country>().GetByIdAsync(command.CountryId.Value) : null;

            var coverThemes = new List<CoverTheme>();
            //var theme1 = command.Theme1Id != null ? await _unitOfWork.Repository<Theme>().GetByIdAsync(command.Theme1Id.Value) : null;
            if (command.Theme1Id != null) {
                var coverTheme1 = new CoverTheme
                {
                    CreatedBy = "UiCreation",
                    CreatedOn = DateTime.Now,
                    LastModifiedBy = null,
                    LastModifiedOn = null,
                    CoverId = command.Id,
                    ThemeId = command.Theme1Id.Value
                };
                coverThemes.Add(coverTheme1);
            }
            //var theme2 = command.Theme2Id != null ? await _unitOfWork.Repository<Theme>().GetByIdAsync(command.Theme2Id.Value) : null;
            if (command.Theme2Id != null)
            {
                var coverTheme2 = new CoverTheme
                {
                    CreatedBy = "UiCreation",
                    CreatedOn = DateTime.Now,
                    LastModifiedBy = null,
                    LastModifiedOn = null,
                    CoverId = command.Id,
                    ThemeId = command.Theme2Id.Value
                };
                coverThemes.Add(coverTheme2);
            }
            //var theme3 = command.Theme3Id != null ? await _unitOfWork.Repository<Theme>().GetByIdAsync(command.Theme3Id.Value) : null;
            if (command.Theme3Id != null)
            {
                var coverTheme3 = new CoverTheme
                {
                    CreatedBy = "UiCreation",
                    CreatedOn = DateTime.Now,
                    LastModifiedBy = null,
                    LastModifiedOn = null,
                    CoverId = command.Id,
                    ThemeId = command.Theme3Id.Value
                };
                coverThemes.Add(coverTheme3);
            }
            //var theme4 = command.Theme4Id != null ? await _unitOfWork.Repository<Theme>().GetByIdAsync(command.Theme4Id.Value) : null;
            if (command.Theme4Id != null)
            {
                var coverTheme4 = new CoverTheme
                {
                    CreatedBy = "UiCreation",
                    CreatedOn = DateTime.Now,
                    LastModifiedBy = null,
                    LastModifiedOn = null,
                    CoverId = command.Id,
                    ThemeId = command.Theme4Id.Value
                };
                coverThemes.Add(coverTheme4);
            }
            if (command.Id == 0)
            {
                var cover = new Cover
                {                    
                    CreatedBy = "UiCreation",
                    CreatedOn = DateTime.Now,
                    LastModifiedBy = null,
                    LastModifiedOn = null,

                    CoverDate = command.CoverDate.Value,                    
                    CoverIssuerId = command.CoverIssuerId,
                    Number = command.Number,
                    Description = command.Description,
                    AmountIssued = command.AmountIssued,
                    Atlas = command.Atlas,
                    Alberta = command.Alberta,
                    CoverTypeId = command.CoverTypeId,
                    ValueId = command.ValueId,
                    CountryId = command.CountryId,
                    CoverThemes = coverThemes
                    //ImageDataUrl = imageFileName

                };
                //var cover = _mapper.Map<Cover>(command);
                if (uploadRequest != null)
                {
                    cover.ImageDataUrl = _uploadService.UploadAsync(uploadRequest);
                }
                await _unitOfWork.Repository<Cover>().AddAsync(cover);
                await _unitOfWork.Commit(cancellationToken);
                return await Result<int>.SuccessAsync(cover.Id, _localizer["Cover Saved"]);
            }
            else
            {
                var cover = await _unitOfWork.Repository<Cover>().GetByIdAsync(command.Id);
                if (cover != null)
                {
                    cover.CountryId = command.CountryId ?? cover.CountryId;
                    cover.CoverDate = command.CoverDate ?? cover.CoverDate;
                    cover.CoverTypeId = command.CoverTypeId ?? cover.CoverTypeId;
                    cover.CoverIssuerId = command.CoverIssuerId ?? cover.CoverIssuerId;
                    cover.ValueId = command.ValueId ?? cover.ValueId;                    
                    cover.Description = command.Description ?? cover.Description;
                    cover.AmountIssued = command.AmountIssued ?? cover.AmountIssued;
                    cover.Atlas = command.Atlas ?? cover.Atlas;

                    var allCoverThemes = await _unitOfWork.Repository<CoverTheme>().GetAllAsync();
                    var maxCoverThemeId = allCoverThemes.Max(x => x.Id);
                    var existingCoverThemes = allCoverThemes.Where(x => x.CoverId == cover.Id).OrderBy(x => x.Id);
                    foreach (var item in existingCoverThemes)
                    {
                        var coverThemeToRemove = coverThemes.SingleOrDefault(x => x.CoverId == cover.Id && x.ThemeId == item.ThemeId);
                        if (coverThemeToRemove != null) {
                            coverThemes.Remove(coverThemeToRemove);
                        }
                    }

                    foreach (var ct in coverThemes)
                    {
                        ct.Id = maxCoverThemeId++;
                        cover.CoverThemes.Add(ct);
                    }                    

                    if (uploadRequest != null)
                    {
                        cover.ImageDataUrl = _uploadService.UploadAsync(uploadRequest);
                    }
                    await _unitOfWork.Repository<Cover>().UpdateAsync(cover);
                    await _unitOfWork.Commit(cancellationToken);
                    return await Result<int>.SuccessAsync(cover.Id, _localizer["Cover Updated"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Cover Not Found!"]);
                }
            }
        }
    }
}