using Philcosa.Application.Features.CoverValues.Queries.GetAll;
using Philcosa.Application.Features.CoverValues.Queries.GetById;
using Philcosa.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Philcosa.Application.Features.CoverValues.Commands.AddEdit;
using Philcosa.Application.Features.CoverValues.Commands.Delete;

namespace Philcosa.Server.Controllers.v1.Admin
{
    public class CoverValuesController : BaseApiController<CoverValuesController>
    {
        //[Authorize(Policy = Permissions.CoverValues.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var coverValues = await _mediator.Send(new GetAllCoverValuesQuery());
            return Ok(coverValues);
        }

        //[Authorize(Policy = Permissions.CoverValues.View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var coverValue = await _mediator.Send(new GetCoverValueByIdQuery() { Id = id });
            return Ok(coverValue);
        }

        //[Authorize(Policy = Permissions.CoverValues.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(AddEditCoverValueCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        //[Authorize(Policy = Permissions.CoverValues.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteCoverValueCommand { Id = id }));
        }
    }
}