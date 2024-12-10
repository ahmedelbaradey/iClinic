using iClinic.Application.Base;
using iClinic.Application.Features.Doctors.Queries.Response;
using MediatR;

namespace iClinic.Application.Features.Doctors.Queries.Handlers.GetDoctorById
{
    public class GetDoctorByIdQuery : IQuery<BaseResponse<GetSingleDoctorResponse>>
    {
        public int Id { get; set; }
        public GetDoctorByIdQuery(int id)
        {
            Id = id;
        }
    }
}
