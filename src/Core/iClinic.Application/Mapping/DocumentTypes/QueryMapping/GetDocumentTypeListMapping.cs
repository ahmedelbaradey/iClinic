using iClinic.Application.Features.DocumentTypes.Queriers.Response;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.DocumentTypes
{
    public partial class DocumentTypeProfile
    {
        public void GetDocumentTypeListMapping()
        {
            CreateMap<DocumentType, GetDocumentTypeListResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DocumentTypeId));
        }
    }
}
