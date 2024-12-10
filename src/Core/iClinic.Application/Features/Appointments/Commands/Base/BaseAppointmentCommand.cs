using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iClinic.Application.Features.Appointments.Commands.Base
{
    public record BaseAppointmentCommand
    {
        public int Id { get; set; }
    }
}
