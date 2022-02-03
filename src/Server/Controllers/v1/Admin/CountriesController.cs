using Philcosa.Application.Features.Countries.Queries.GetAll;
using Philcosa.Application.Features.Countries.Queries.GetById;
using Philcosa.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Philcosa.Application.Features.Countries.Commands.AddEdit;
using Philcosa.Application.Features.Countries.Commands.Delete;

namespace Philcosa.Server.Controllers.v1.Admin
{
    public class CountriesController : BaseApiController<CountriesController>
    {
        //[Authorize(Policy = Permissions.Countries.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _mediator.Send(new GetAllCountriesQuery());
            return Ok(countries);
        }

        //[Authorize(Policy = Permissions.Countries.View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var country = await _mediator.Send(new GetCountryByIdQuery() { Id = id });
            return Ok(country);
        }

        //[Authorize(Policy = Permissions.Countries.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(AddEditCountryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        //[Authorize(Policy = Permissions.Countries.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteCountryCommand { Id = id }));
        }
    }
}