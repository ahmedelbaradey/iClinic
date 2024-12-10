using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.Clinics.Queries.Models
{
    public class IsClinicExistByNameQuery : IRequest<BaseResponse<string>>
    {
        public string ClinicName { get; set; } = null!;
    }
}
