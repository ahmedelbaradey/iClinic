using iClinic.Application.Base;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace iClinic.Application.Features.DocumentTypes.Commands.Models
{
    public class AddDocumentTypeCommand : IRequest<BaseResponse<string>>
    {
        [Required(ErrorMessage = "Type Name can't be blank.")]
        public string TypeName { get; set; } = null!;
    }
}
