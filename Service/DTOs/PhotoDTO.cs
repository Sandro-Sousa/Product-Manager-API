using System.ComponentModel.DataAnnotations;

namespace Service.DTOs
{
    public class PhotoDTO
    {
        public int Id { get; set; }

        public string? UrlImage { get; set; }
    }
}
