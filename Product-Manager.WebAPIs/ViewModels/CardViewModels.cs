using Service.DTOs;

namespace Product_Manager.WebAPIs.ViewModels
{
    public class CardViewModels
    {
        public virtual PhotoViewModels? Photo { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
    }
}
