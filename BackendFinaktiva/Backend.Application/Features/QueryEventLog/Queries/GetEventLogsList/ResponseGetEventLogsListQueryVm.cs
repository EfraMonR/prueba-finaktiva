using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Features.QueryEventLog.Queries.GetEventLogsList
{
    public class ResponseGetEventLogsListQueryVm
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int TipoEvento { get; set; }
    }
}
