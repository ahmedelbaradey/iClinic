using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iClinic.Application.Base
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
