using iClinic.Application.Base;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace iClinic.Application.Features.DocumentTypes.Commands.Models
{
    public class EditDocumentTypeCommand : IRequest<BaseResponse<string>>
    {
        [Required(ErrorMessage = "Id: can't be blank.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Type Name can't be blank.")]
        public string TypeName { get; set; } = null!;
    }
}
