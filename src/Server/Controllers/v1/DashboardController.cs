﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Philcosa.Server.Controllers;
using Philcosa.Shared.Constants.Permission;
using System.Threading.Tasks;
using Philcosa.Application.Features.Dashboards.Queries.GetData;

namespace Philcosa.Server.Controllers.v1
{
    [ApiController]
    public class DashboardController : BaseApiController<DashboardController>
    {
        /// <summary>
        /// Get Dashboard Data
        /// </summary>
        /// <returns>Status 200 OK </returns>
        [Authorize(Policy = Permissions.Dashboards.View)]
        [HttpGet]
        public async Task<IActionResult> GetDataAsync()
        {
            var result = await _mediator.Send(new GetDashboardDataQuery());
            return Ok(result);
        }
    }
}