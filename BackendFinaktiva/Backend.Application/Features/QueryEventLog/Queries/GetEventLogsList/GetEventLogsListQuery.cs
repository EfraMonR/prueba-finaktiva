using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Features.QueryEventLog.Queries.GetEventLogsList
{
    public class GetEventLogsListQuery : IRequest<List<ResponseGetEventLogsListQueryVm>>
    {
    }
}
