using iClinic.Application.Features.Documents.Queries.Responses;
using iClinic.Application.Wappers;
using MediatR;

namespace iClinic.Application.Features.Documents.Queries.Models
{
    public class GetDocumentPaginatedQuery : IRequest<PaginatedResult<GetDocumentPaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public string? DoctorName { get; set; }
        public string? TypeName { get; set; }
    }
}
