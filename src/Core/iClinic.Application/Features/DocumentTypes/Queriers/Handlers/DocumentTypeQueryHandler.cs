using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.DocumentTypes.Queriers.Models;
using iClinic.Application.Features.DocumentTypes.Queriers.Response;
using iClinic.Application.Features.DocumentTypes.Queriers.Responses;
using  iClinic.Application.Abstracts.Presistence;
using MediatR;

namespace iClinic.Application.Features.DocumentTypes.Queriers.Handlers
{
    public class DocumentTypeQueryHandler : BaseResponseHandler,
        IRequestHandler<GetDocumentTypeListQuery, BaseResponse<List<GetDocumentTypeListResponse>>>,
        IRequestHandler<GetDocumentTypeByIdQuery, BaseResponse<GetDocumentTypeByIdResponse>>
    {
        #region Fileds
        private readonly IDocumentTypeService _documentTypeService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public DocumentTypeQueryHandler(IMapper mapper, IDocumentTypeService documentTypeService)
        {
            _mapper = mapper;
            _documentTypeService = documentTypeService;
        }
        #endregion

        #region Functions
        public async Task<BaseResponse<List<GetDocumentTypeListResponse>>> Handle(GetDocumentTypeListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var DocumentTypeList = await _documentTypeService.GetDocumentTypeAsync();
                var DocumentTypeListMapper = _mapper.Map<List<GetDocumentTypeListResponse>>(DocumentTypeList);

                return Success(DocumentTypeListMapper);

            }
            catch (Exception ex)
            {
                return ServerError<List<GetDocumentTypeListResponse>>(ex.Message);
            }
        }

        public async Task<BaseResponse<GetDocumentTypeByIdResponse>> Handle(GetDocumentTypeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var DocumentType = await _documentTypeService.GetDocumentTypeByIdAsync(request.Id);
                if (DocumentType == null)
                    return NotFound<GetDocumentTypeByIdResponse>("DocumentType with this id not found.");

                var DocumentTypeMapper = _mapper.Map<GetDocumentTypeByIdResponse>(DocumentType);

                return Success(DocumentTypeMapper);

            }
            catch (Exception ex)
            {
                return ServerError<GetDocumentTypeByIdResponse>(ex.Message);
            }
        }
        #endregion

    }
}
