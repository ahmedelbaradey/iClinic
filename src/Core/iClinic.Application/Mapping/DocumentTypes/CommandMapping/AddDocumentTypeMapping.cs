using iClinic.Application.Features.DocumentTypes.Commands.Models;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.DocumentTypes
{
    public partial class DocumentTypeProfile
    {
        public void AddDocumentTypeMapping()
        {
            CreateMap<AddDocumentTypeCommand, DocumentType>();
        }
    }
}
