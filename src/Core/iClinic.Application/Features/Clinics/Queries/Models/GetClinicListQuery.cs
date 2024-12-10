using iClinic.Application.Base;
using iClinic.Application.Features.Clinics.Queries.Response;
using MediatR;

namespace iClinic.Application.Features.Clinics.Queries.Models
{
    public class GetClinicListQuery : IRequest<BaseResponse<List<GetClinicListResponse>>>
    {

    }
}
