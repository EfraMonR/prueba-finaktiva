using Backend.Application.Contracts.Infraestructure;
using Backend.Application.Features.QueryEventLog.Queries.GetEventLogsList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Features.CommandEventLog.Commands.CreateEventLog
{
    public class CreateEventLogCommandHandler : IRequestHandler<CreateEventLogCommand, ResponseCreateEventLogCommandVm>
    {
        private readonly IServiceEventLog<ResponseCreateEventLogCommandVm> _operateService;

        public CreateEventLogCommandHandler(IServiceEventLog<ResponseCreateEventLogCommandVm> operateService)
        {
            _operateService = operateService;
        }

        public async Task<ResponseCreateEventLogCommandVm> Handle(CreateEventLogCommand request, CancellationToken cancellationToken)
        {
            ResponseCreateEventLogCommandVm response = new ResponseCreateEventLogCommandVm();
            try
            {
                response = await _operateService.CreateEventLog(request);
                return response;
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }
    }
}
