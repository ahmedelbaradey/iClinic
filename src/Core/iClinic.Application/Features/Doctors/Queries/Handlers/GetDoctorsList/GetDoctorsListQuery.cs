using iClinic.Application.Base;
using iClinic.Application.Features.Doctors.Queries.Response;
using MediatR;

namespace iClinic.Application.Features.Doctors.Queries.Handlers.GetDoctorsList
{
    public class GetDoctorsListQuery : IQuery<BaseResponse<List<GetDoctorsListResponse>>>
    {

    }
}
