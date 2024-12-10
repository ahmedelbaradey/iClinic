using iClinic.Application.Features.DocumentTypes.Queriers.Responses;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.DocumentTypes
{
    public partial class DocumentTypeProfile
    {
        public void GetDocumentTypeByIdMapping()
        {
            CreateMap<DocumentType, GetDocumentTypeByIdResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DocumentTypeId));
        }
    }
}
