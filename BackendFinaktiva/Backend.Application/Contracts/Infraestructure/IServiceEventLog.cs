using Backend.Application.Features.QueryRemainder.Queries.GetRemainder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Contracts.Infraestructure
{
    public interface IServiceEventLog<T> : IApiService<T> where T : class
    {

    }
}
