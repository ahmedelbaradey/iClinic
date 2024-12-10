using iClinic.Application.Base;
using iClinic.Application.Features.PatientCases.Queries.Responses;
using MediatR;

namespace iClinic.Application.Features.PatientCases.Queries.Models
{
    public class GetPatientCaseByIdQuery : IRequest<BaseResponse<GetSinglePatientCaseResponse>>
    {
        public int Id { get; set; }
        public GetPatientCaseByIdQuery(int id)
        {
            Id = id;
        }
    }
}
