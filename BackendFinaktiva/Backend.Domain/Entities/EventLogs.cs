using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities
{
    public class EventLogs
    {
        [Key]
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int TipoEvento { get; set; }
    }
}
