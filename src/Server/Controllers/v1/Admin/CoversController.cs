using Philcosa.Application.Features.Covers.Commands.AddEdit;
using Philcosa.Application.Features.Covers.Commands.Delete;
using Philcosa.Application.Features.Covers.Queries.GetAllPaged;
using Philcosa.Application.Features.Covers.Queries.GetCoverImage;
using Philcosa.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Philcosa.Server.Controllers.v1.Admin
{
    public class CoversController : BaseApiController<CoversController>
    {
        //[Authorize(Policy = Permissions.Products.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize, string searchString)
        {
            var products = await _mediator.Send(new GetAllCoversQuery(pageNumber, pageSize, searchString));
            return Ok(products);
        }

        //[Authorize(Policy = Permissions.Products.View)]
        [HttpGet("image/{id}")]
        public async Task<IActionResult> GetCoverImageAsync(int id)
        {
            var result = await _mediator.Send(new GetCoverImageQuery(id));
            return Ok(result);
        }

        //[Authorize(Policy = Permissions.Products.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(AddEditCoverCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        //[Authorize(Policy = Permissions.Products.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteCoverCommand { Id = id }));
        }

        //[Authorize(Policy = Permissions.Products.View)]
        //[HttpGet("export")]
        //public async Task<IActionResult> Export()
        //{
        //    return Ok(await _mediator.Send(new ExportQuery()));
        //}
    }
}