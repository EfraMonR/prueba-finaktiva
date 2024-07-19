using AutoMapper;
using Backend.Application.Contracts.Infraestructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Features.QueryEventLog.Queries.GetEventLogsList
{
    public class GetEventLogsListQueryHandler : IRequestHandler<GetEventLogsListQuery, List<ResponseGetEventLogsListQueryVm>>
    {
        private readonly IServiceEventLog<ResponseGetEventLogsListQueryVm> _operateService;

        public GetEventLogsListQueryHandler(IServiceEventLog<ResponseGetEventLogsListQueryVm> operateService)
        {
            _operateService = operateService;
        }

        public async Task<List<ResponseGetEventLogsListQueryVm>> Handle(GetEventLogsListQuery request, CancellationToken cancellationToken)
        {
            List<ResponseGetEventLogsListQueryVm> response = new List<ResponseGetEventLogsListQueryVm>();
            try
            {
                response = await _operateService.GetEventLogsList();
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }


}
