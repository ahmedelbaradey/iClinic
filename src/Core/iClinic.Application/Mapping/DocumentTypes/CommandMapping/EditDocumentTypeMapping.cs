using iClinic.Application.Features.DocumentTypes.Commands.Models;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.DocumentTypes
{
    public partial class DocumentTypeProfile
    {
        public void EditDocumentTypeMapping()
        {
            CreateMap<EditDocumentTypeCommand, DocumentType>().ForMember(dest => dest.DocumentTypeId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
