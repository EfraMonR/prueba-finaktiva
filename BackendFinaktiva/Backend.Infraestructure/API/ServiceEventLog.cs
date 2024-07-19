using Microsoft.Extensions.Configuration;
using Backend.Application.Contracts.Infraestructure;
using Backend.Application.Contracts.Persistence;
using Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
//using Backend.Application.Models;
using System.Globalization;
using Backend.Application.Exceptions;
using Backend.Application.Features.QueryEventLog.Queries.GetEventLogsList;
using AutoMapper;
using Backend.Application.Features.CommandEventLog.Commands.CreateEventLog;
using Microsoft.Graph.Models;
using Azure;

namespace Backend.Infraestructure.API
{
    public class ServiceEventLog<T> : IServiceEventLog<T> where T : class
    {
        private readonly IMapper _mapper;
        private IAsyncRepository<EventLogs> _eventLogsRepository;

        public ServiceEventLog(IMapper mapper, IAsyncRepository<EventLogs> eventLogsRepository)
        {
            _mapper = mapper;
            _eventLogsRepository = eventLogsRepository;
        }

        public async Task<List<ResponseGetEventLogsListQueryVm>> GetEventLogsList()
        { 
            var eventLogsList = await _eventLogsRepository.ListAllAsync();
            return _mapper.Map<List<ResponseGetEventLogsListQueryVm>>(eventLogsList);

        }

        public async Task<ResponseCreateEventLogCommandVm> CreateEventLog(CreateEventLogCommand request)
        {
            var validationResponse = ValidateEventLogFields(request);

            if (!validationResponse.Success)
            {
                return validationResponse;
            }

            var response = new ResponseCreateEventLogCommandVm();
            try
            {
                var eventLog = new EventLogs
                {
                    Fecha = DateTime.Now,
                    Descripcion = request.Descripcion,
                    TipoEvento = request.TipoEvento
                };
                await _eventLogsRepository.AddAsync(eventLog);
                response.Success = true;
                response.Message = "Event log created successfully.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred while creating the event log: {ex.Message}";
            }
            return response;
        }

        private ResponseCreateEventLogCommandVm ValidateEventLogFields(CreateEventLogCommand request)
        {
            var response = new ResponseCreateEventLogCommandVm();

            if (!int.TryParse(request.TipoEvento.ToString(), out int tipoEventoValido))
            {
                response.Success = false;
                response.Message = "The event type must be a valid number.";
                return response;
            }

            response.Success = true;
            response.Message = "Validation successful.";
            return response;
        }
    }

}
