using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Features.CommandEventLog.Commands.CreateEventLog
{
    public class CreateEventLogCommand : IRequest<ResponseCreateEventLogCommandVm>
    {
        public string Descripcion { get; set; }
        public int TipoEvento { get; set; }
    }
}
