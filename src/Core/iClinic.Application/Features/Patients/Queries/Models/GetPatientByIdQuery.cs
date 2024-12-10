using iClinic.Application.Base;
using iClinic.Application.Features.Patients.Queries.Responses;
using MediatR;

namespace iClinic.Application.Features.Patients.Queries.Models
{
    public class GetPatientByIdQuery : IRequest<BaseResponse<GetPatientByIdResponse>>
    {
        public int Id { get; set; }

        public GetPatientByIdQuery(int id)
        {
            Id = id;
        }
    }
}
