using Philcosa.Application.Features.CoverIssuers.Queries.GetAll;
using Philcosa.Application.Features.CoverIssuers.Queries.GetById;
using Philcosa.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Philcosa.Application.Features.CoverIssuers.Commands.AddEdit;
using Philcosa.Application.Features.CoverIssuers.Commands.Delete;

namespace Philcosa.Server.Controllers.v1.Admin
{
    public class CoverIssuersController : BaseApiController<CoverIssuersController>
    {
        //[Authorize(Policy = Permissions.CoverIssuers.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var coverIssuers = await _mediator.Send(new GetAllCoverIssuersQuery());
            return Ok(coverIssuers);
        }

        //[Authorize(Policy = Permissions.CoverIssuers.View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var coverIssuer = await _mediator.Send(new GetCoverIssuerByIdQuery() { Id = id });
            return Ok(coverIssuer);
        }

        //[Authorize(Policy = Permissions.CoverIssuers.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(AddEditCoverIssuerCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        //[Authorize(Policy = Permissions.CoverIssuers.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteCoverIssuerCommand { Id = id }));
        }
    }
}