using System.ComponentModel.DataAnnotations;

namespace Service.DTOs
{
    public class PhotoDTOInsert
    {
        [Required(ErrorMessage = "The Image is mandatory.")]
        public string? Base64 { get; set; }
    }
}
