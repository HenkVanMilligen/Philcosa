using Philcosa.Application.Features.CoverTypes.Queries.GetAll;
using Philcosa.Application.Features.CoverTypes.Queries.GetById;
using Philcosa.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Philcosa.Application.Features.CoverTypes.Commands.AddEdit;
using Philcosa.Application.Features.CoverTypes.Commands.Delete;

namespace Philcosa.Server.Controllers.v1.Admin
{
    public class CoverTypesController : BaseApiController<CoverTypesController>
    {
        //[Authorize(Policy = Permissions.CoverTypes.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var coverTypes = await _mediator.Send(new GetAllCoverTypesQuery());
            return Ok(coverTypes);
        }

        //[Authorize(Policy = Permissions.CoverTypes.View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var coverType = await _mediator.Send(new GetCoverIssuerByIdQuery() { Id = id });
            return Ok(coverType);
        }

        //[Authorize(Policy = Permissions.CoverTypes.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(AddEditCoverTypeCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        //[Authorize(Policy = Permissions.CoverTypes.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteCoverTypeCommand { Id = id }));
        }
    }
}