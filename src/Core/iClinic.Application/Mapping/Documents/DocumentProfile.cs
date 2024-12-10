using AutoMapper;

namespace iClinic.Application.Mapping.Documents
{
    public partial class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            AddDocumentMapping();
            EditDocumentMapping();
            GetDocumentListMapping();
            GetDocumentByIdMapping();
        }
    }
}
