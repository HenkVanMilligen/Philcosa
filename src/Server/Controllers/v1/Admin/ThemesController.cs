using Philcosa.Application.Features.Themes.Queries.GetAll;
using Philcosa.Application.Features.Themes.Queries.GetById;
using Philcosa.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Philcosa.Application.Features.Themes.Commands.AddEdit;
using Philcosa.Application.Features.Themes.Commands.Delete;

namespace Philcosa.Server.Controllers.v1.Admin
{
    public class ThemesController : BaseApiController<ThemesController>
    {
        //[Authorize(Policy = Permissions.Themes.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _mediator.Send(new GetAllThemesQuery());
            return Ok(countries);
        }

        //[Authorize(Policy = Permissions.Themes.View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var theme = await _mediator.Send(new GetThemeByIdQuery() { Id = id });
            return Ok(theme);
        }

        //[Authorize(Policy = Permissions.Themes.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(AddEditThemeCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        //[Authorize(Policy = Permissions.Themes.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteThemeCommand { Id = id }));
        }
    }
}