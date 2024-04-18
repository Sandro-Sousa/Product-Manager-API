using System.ComponentModel.DataAnnotations;

namespace Service.DTOs
{
    public class PhotoDTO
    {
        public int Id { get; set; }

        public string? Base64 { get; set; }
    }
}
