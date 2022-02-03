using AutoMapper;
using Philcosa.Application.Interfaces.Repositories;
using Philcosa.Domain.Entities;
using Philcosa.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Philcosa.Application.Features.Themes.Queries.GetById
{
    public class GetThemeByIdQuery : IRequest<Result<GetThemeByIdResponse>>
    {
        public int Id { get; set; }
    }

    public class GetThemesByIdQueryHandler : IRequestHandler<GetThemeByIdQuery, Result<GetThemeByIdResponse>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;

        public GetThemesByIdQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetThemeByIdResponse>> Handle(GetThemeByIdQuery query, CancellationToken cancellationToken)
        {
            var coverType = await _unitOfWork.Repository<Theme>().GetByIdAsync(query.Id);
            var mappedTheme = new GetThemeByIdResponse
            {
                Id = coverType.Id,
                Name = coverType.Name
            };
            return await Result<GetThemeByIdResponse>.SuccessAsync(mappedTheme);
        }
    }
}