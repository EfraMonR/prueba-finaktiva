using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Features.CommandEventLog.Commands.CreateEventLog
{
    public class ResponseCreateEventLogCommandVm
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
