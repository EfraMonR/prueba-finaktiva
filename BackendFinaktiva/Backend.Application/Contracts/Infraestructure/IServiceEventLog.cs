using Backend.Application.Features.CommandEventLog.Commands.CreateEventLog;
using Backend.Application.Features.QueryEventLog.Queries.GetEventLogsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Contracts.Infraestructure
{
    public interface IServiceEventLog<T> : IApiService<T> where T : class
    {
        Task<ResponseCreateEventLogCommandVm> CreateEventLog(CreateEventLogCommand request);
        Task<List<ResponseGetEventLogsListQueryVm>> GetEventLogsList();
    }
}
