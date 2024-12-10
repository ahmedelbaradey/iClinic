using iClinic.Application.Features.Documents.Commands.Models;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.Documents
{
    public partial class DocumentProfile
    {
        public void AddDocumentMapping()
        {
            CreateMap<AddDocumentCommand, Document>();

        }
    }
}
