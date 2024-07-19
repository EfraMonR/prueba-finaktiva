using AutoMapper;
using Backend.Application.Features.QueryEventLog.Queries.GetEventLogsList;
using Backend.Domain.Entities;

//using Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EventLogs, ResponseGetEventLogsListQueryVm>().ReverseMap();
        }
    }
}
