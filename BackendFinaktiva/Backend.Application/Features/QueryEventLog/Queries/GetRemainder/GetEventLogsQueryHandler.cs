using AutoMapper;
using Azure;
using MediatR;
using Microsoft.Extensions.Configuration;
using Backend.Application.Contracts.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Features.QueryRemainder.Queries.GetRemainder
{
    public class GetEventLogsQueryHandler : IRequestHandler<GetEventLogsQuery, List<ResponseGetEventLogsVm>>
    {
        private readonly IServiceEventLog<ResponseGetEventLogsVm> _operateService;
        private readonly IMapper _mapper;

        public GetEventLogsQueryHandler(IServiceEventLog<ResponseGetEventLogsVm> operateService, IMapper mapper, IConfiguration configuration)
        {
            _operateService = operateService;
            _mapper = mapper;
        }

        public async Task<List<ResponseGetEventLogsVm>> Handle(GetEventLogsQuery request, CancellationToken cancellationToken)
        { 
            List<ResponseGetEventLogsVm> response = new List<ResponseGetEventLogsVm>();
            try
            {
                return response;
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }
    }
}
