using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Features.QueryRemainder.Queries.GetRemainder
{
    public class GetEventLogsQuery : IRequest<List<ResponseGetEventLogsVm>>
    {
    }
}
