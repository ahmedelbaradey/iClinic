using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.Clinics.Queries.Models
{
    public class IsClinicExistByIdQuery : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }

        public IsClinicExistByIdQuery(int id)
        {
            Id = id;
        }
    }
}
