using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iClinic.Application.Features.Doctors.Commands.Base
{
    public record BaseDoctorCommand
    {
        public int Id { get; set; }
    }
}
