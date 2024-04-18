using AutoMapper;
using Service.DTOs;

namespace Service.Helpers
{
    public class ProductManagerProfile : Profile
    {
        public ProductManagerProfile()
        {
            CreateMap<Entities.Entites.Card, DTOs.CardDTO>().ReverseMap();
            CreateMap<Entities.Entites.Photo, DTOs.PhotoDTO>().ReverseMap();
        }
    }
}
