using iClinic.Application.Features.Documents.Queries.Responses;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.Documents
{
    public partial class DocumentProfile
    {
        public void GetDocumentByIdMapping()
        {
            CreateMap<Document, GetSingleDocumentResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DocumentId))
                .ForMember(dest => dest.Doctor, opt => opt.MapFrom(src => src.Appointment.Doctor.FirstName + " " + src.Appointment.Doctor.LastName))
                .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentType.TypeName));

        }
    }
}
