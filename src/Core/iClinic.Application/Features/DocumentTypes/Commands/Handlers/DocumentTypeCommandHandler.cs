using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.DocumentTypes.Commands.Models;
using iClinic.Domain.Entities;
using iClinic.Presistence.Contract;
using MediatR;

namespace iClinic.Application.Features.DocumentTypes.Commands.Handlers
{
    public class DocumentTypeCommandHandler : BaseResponseHandler,
        IRequestHandler<AddDocumentTypeCommand, BaseResponse<string>>,
        IRequestHandler<EditDocumentTypeCommand, BaseResponse<string>>,
        IRequestHandler<DeleteDocumentTypeCommand, BaseResponse<string>>
    {
        #region Fileds
        private readonly IDocumentTypeService _documentTypeService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public DocumentTypeCommandHandler(IMapper mapper, IDocumentTypeService documentTypeService)
        {
            _mapper = mapper;
            _documentTypeService = documentTypeService;
        }
        #endregion

        #region Functions
        public async Task<BaseResponse<string>> Handle(AddDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {


                var IsDocumentTypeExist = await _documentTypeService.IsDocumentTypeExistByNameAsync(request.TypeName);
                if (IsDocumentTypeExist)
                    return BadRequest<string>("This type name already exists.");

                var documentTypeMapper = _mapper.Map<DocumentType>(request);
                var IsAdded = await _documentTypeService.CreateDocumentTypeAsync(documentTypeMapper);
                if (!IsAdded)
                    return BadRequest<string>("Added Operation Failed.");

                return Success("Added Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<BaseResponse<string>> Handle(EditDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {


                var IsDocumentTypeExistByID = await _documentTypeService.IsDocumentTypeExistByIdAsync(request.Id);
                if (!IsDocumentTypeExistByID)
                    return NotFound<string>("This type name not found exists.");

                var IsDocumentTypeExistByName = await _documentTypeService.IsDocumentTypeExistByNameAsync(request.TypeName);
                if (IsDocumentTypeExistByName)
                    return BadRequest<string>("type name already exists.");



                var documentTypeMapper = _mapper.Map<DocumentType>(request);
                var IsEdited = await _documentTypeService.EditDocumentTypeAsync(documentTypeMapper);
                if (!IsEdited)
                    return BadRequest<string>("Edited Operation Failed.");

                return Success("Edited Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<BaseResponse<string>> Handle(DeleteDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {


                var documentTypeExist = await _documentTypeService.GetDocumentTypeByIdAsync(request.Id);
                if (documentTypeExist == null)
                    return NotFound<string>("This type name not found exists with this id.");



                var IsDeleted = await _documentTypeService.DeleteDocumentTypeAsync(documentTypeExist);
                if (!IsDeleted)
                    return BadRequest<string>("Deleted Operation Failed.");

                return Success("Deleted Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }
        #endregion


    }
}
