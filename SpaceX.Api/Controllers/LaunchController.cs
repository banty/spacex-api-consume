using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpaceX.Applicaiton.Query;
using SpaceX.Domain;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpaceX.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LaunchController : ControllerBase
    {
        private readonly IMediator mediator;

     
        public LaunchController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        /// <summary>
        /// Get all spacex launches
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Launch>>>  GetLaunchesAsync()
        {
            var request = new GetLaunchesQuery();
            return await mediator.Send(request);
        }
       
        /// <summary>
        /// Get past spacex launches
        /// </summary>
        /// <returns></returns>
        [HttpGet("past")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Launch>>> GetPastLaunchAsync()
        {
            var request = new GetLaunchesQuery("past");
            return await mediator.Send(request);
        }
     /// <summary>
     /// Get upcoming spacex launches
     /// </summary>
     /// <returns></returns>
        [HttpGet("upcoming")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Launch>>> GetUpcomingLaunchAsync()
        {
            var request = new GetLaunchesQuery("upcoming");
            return await mediator.Send(request);
        }
        /// <summary>
        /// Get spacex launhes by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Launch>> GetLaunchAsync(string id)
        {
            var request = new GetLaunchDetailQuery(id);
            return await mediator.Send(request);
        }
    }
}

