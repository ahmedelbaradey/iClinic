using iClinic.Application.Base;
using iClinic.Application.Features.DocumentTypes.Queriers.Responses;
using MediatR;

namespace iClinic.Application.Features.DocumentTypes.Queriers.Models
{
    public class GetDocumentTypeByIdQuery : IRequest<BaseResponse<GetDocumentTypeByIdResponse>>
    {
        public GetDocumentTypeByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }


    }
}
