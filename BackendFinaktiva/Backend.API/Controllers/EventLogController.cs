using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Application.Exceptions;
using Backend.Application.Features.QueryEventLog.Queries.GetEventLogsList;
using Backend.Application.Features.CommandEventLog.Commands.CreateEventLog;

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

        [Route("GetEventsLogList")]
        [HttpGet]
        public async Task<ActionResult<ResponseGetEventLogsListQueryVm>> GetRemainders()
        {
            try
            {
                var response = await _mediator.Send(new GetEventLogsListQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("CreateEventLog")]
        [HttpPost]
        public async Task<ActionResult<ResponseCreateEventLogCommandVm>> CreateEventLog([FromBody] CreateEventLogCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
