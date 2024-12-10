using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.Documents.Queries.Models;
using iClinic.Application.Features.Documents.Queries.Responses;
using iClinic.Application.Wappers;
using iClinic.Domain.Entities;
using  iClinic.Application.Abstracts.Presistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace iClinic.Application.Features.Documents.Queries.Handlers
{
    public class DocumentQueryHandler : BaseResponseHandler,
        IRequestHandler<GetDocumentListQuery, BaseResponse<List<GetDocumentListResponse>>>,
        IRequestHandler<GetDocumentByIdQuery, BaseResponse<GetSingleDocumentResponse>>,
        IRequestHandler<GetDocumentPaginatedQuery, PaginatedResult<GetDocumentPaginatedResponse>>
    {


        #region Fileds
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;
        private ILogger<DocumentQueryHandler> _logger;
        #endregion

        #region Constructors
        public DocumentQueryHandler(IDocumentService documentService, IMapper mapper, ILogger<DocumentQueryHandler> logger)
        {
            _documentService = documentService;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region Functions
        public async Task<BaseResponse<List<GetDocumentListResponse>>> Handle(GetDocumentListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var DocumentList = await _documentService.GetDocumentListAsync();
                var DocumentListMapper = _mapper.Map<List<GetDocumentListResponse>>(DocumentList);

                return Success(DocumentListMapper);

            }
            catch (Exception ex)
            {
                return ServerError<List<GetDocumentListResponse>>(ex.Message);
            }
        }

        public async Task<BaseResponse<GetSingleDocumentResponse>> Handle(GetDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var Document = await _documentService.GetDocumentByIdAsync(request.Id);
                if (Document == null)
                    return NotFound<GetSingleDocumentResponse>("not found this Id.");

                var DocumentMapper = _mapper.Map<GetSingleDocumentResponse>(Document);
                return Success(DocumentMapper);

            }
            catch (Exception ex)
            {
                return ServerError<GetSingleDocumentResponse>(ex.Message);
            }
        }

        public async Task<PaginatedResult<GetDocumentPaginatedResponse>> Handle(GetDocumentPaginatedQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<Document, GetDocumentPaginatedResponse>> expression =
                    entity => new GetDocumentPaginatedResponse(entity.DocumentId,
                    entity.DocumentName, entity.TimeCreated, entity.Details, entity.DocumentType.TypeName,
                    entity.Appointment.Doctor.FirstName + " " + entity.Appointment.Doctor.LastName);

                var filterResult = _documentService.FilterDocumentPaginatedQuerable(request.DoctorName, request.TypeName);
                var paginatedList = await filterResult.Select(expression).ToPaginatedListAsync(request.PageNumber,
                    request.PageSize);

                return paginatedList;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetDocumentPaginatedQuery");
                throw;
            }
        }
        #endregion

    }
}
