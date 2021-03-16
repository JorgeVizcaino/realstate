using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealState.Application.RealState;
using RealState.WebApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealState.WebApi.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class HausesController : ApiController
    {
        [AllowAnonymous]
        [HttpGet("getSummary")]
        public async Task<ActionResult<HousesModel>> listTaskList()
        {
            var result = await Mediator.Send(new HousesCommand.Command());
            return Ok(result);
        }

    }
}
