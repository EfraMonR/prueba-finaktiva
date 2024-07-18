using Microsoft.Extensions.Configuration;
using Backend.Application.Contracts.Infraestructure;
using Backend.Application.Contracts.Persistence;
//using Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
//using Backend.Application.Models;
using Backend.Application.Features.QueryRemainder.Queries.GetRemainder;
using System.Globalization;
using Backend.Application.Exceptions;

namespace Backend.Infraestructure.API
{
    public class ServiceEventLog<T> : IServiceEventLog<T> where T : class
    {
       
    }

}
