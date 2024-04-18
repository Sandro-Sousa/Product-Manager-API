using System.ComponentModel.DataAnnotations;

namespace Service.DTOs
{
    public class CardDTOInsert
    {
        public virtual PhotoDTOInsert? Photo { get; set; }

        [Required(ErrorMessage = "The field Name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The field Status is required.")]
        public string? Status { get; set; }
    }
}
