using System.ComponentModel.DataAnnotations;

namespace Service.DTOs
{
    public class CardDTO
    {
        public int Id { get; set; }
        public int IdPhoto { get; set; }
        public virtual PhotoDTO? Photo { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
    }
}
