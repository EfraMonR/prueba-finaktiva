using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Application.Exceptions;
using Backend.Application.Features.QueryRemainder.Queries.GetRemainder;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventLogController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EventLogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("GetEventsLog")]
        [HttpGet]
        public async Task<ActionResult<ResponseGetEventLogsVm>> GetRemainders()
        {
            try
            {
                var response = await _mediator.Send(new GetEventLogsQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
