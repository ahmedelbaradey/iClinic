using AutoMapper;

namespace iClinic.Application.Mapping.DocumentTypes
{
    public partial class DocumentTypeProfile : Profile
    {
        public DocumentTypeProfile()
        {
            AddDocumentTypeMapping();
            EditDocumentTypeMapping();
            GetDocumentTypeListMapping();
            GetDocumentTypeByIdMapping();
        }
    }
}
