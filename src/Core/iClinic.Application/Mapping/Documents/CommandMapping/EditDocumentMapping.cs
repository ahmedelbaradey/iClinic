using iClinic.Application.Features.Documents.Commands.Models;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.Documents
{
    public partial class DocumentProfile
    {
        public void EditDocumentMapping()
        {
            CreateMap<EditDocumentCommand, Document>().ForMember(dest => dest.DocumentId,
                opt => opt.MapFrom(src => src.Id));

        }
    }
}
