using AutoMapper;
using Cross;
using Cross.Pagination;
using Entities.Entites;
using Microsoft.IdentityModel.Tokens;
using Repository.Interfaces;
using Service.DTOs;
using Service.Interfaces;

namespace Service.Services
{
    public class ProductManagerService : IProductManagerService
    {
        private readonly IMapper _mapper;
        private readonly IProductManagerRepository _productManagerRepository;

        public ProductManagerService(IMapper mapper, IProductManagerRepository productManagerRepository)
        {
            this._mapper = mapper;
            this._productManagerRepository = productManagerRepository;
        }

        public async Task<List<CardDTO>> GetAll()
        {
            try
            {
                var cards = await _productManagerRepository.GetAll();

                var cardsDtos = this._mapper.Map<List<CardDTO>>(cards);

                cardsDtos.ForEach(card =>
                {
                    var getImage = Cross.ImageHelper.GetImageAsBase64(card.Photo?.UrlImage);
                    if(!string.IsNullOrEmpty(card.Photo?.UrlImage))
                    card.Photo.UrlImage = getImage;
                });

                return cardsDtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CardDTO?> GetById(int id)
        {
            try
            {
                if (id is 0)
                {
                    throw new Exception("Card Not Found");
                }

                var cardById = await _productManagerRepository.GetById(id);
                var cardDTO = this._mapper.Map<CardDTO>(cardById);

                return cardDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Insert(CardDTOInsert cardDto)
        {
            var imagePath = "";
            if (!String.IsNullOrEmpty(cardDto.Photo?.Base64))
            {
                imagePath = ImageHelper.SaveImageFromBase64(cardDto.Photo.Base64);
            }

            if (cardDto is null)
                return await Task.FromResult(false);

            var createCard = new Card
            {
                Name = cardDto.Name,
                Photo = new Photo
                {
                    UrlImage = imagePath
                },
                Status = cardDto.Status,
            };

            await this._productManagerRepository.Create(createCard);

            return await Task.FromResult(true);
        }

        public async Task<bool> Update(CardDTO cardUpdateDto)
        {
            if (cardUpdateDto is null || cardUpdateDto.Id is 0)
            {
                throw new Exception("Card Not Found");
            }

            var cardUpdate = this._mapper.Map<Card>(cardUpdateDto);

            await this._productManagerRepository.Update(cardUpdate);

            return await Task.FromResult(true);
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                if (id is 0)
                {
                    throw new Exception("Failed to delete card");
                }
                var cardResultDelete = await this._productManagerRepository.Delete(id);
                return cardResultDelete;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<CardDTO>> GetAllProducts(ProductsParameters productsParameters)
        {
            try
            {
                var cards = await _productManagerRepository.GetAllProducts(productsParameters);
                var cardsDtos = this._mapper.Map<IEnumerable<CardDTO>>(cards);

                foreach (var card in cardsDtos)
                {
                    var getImage = Cross.ImageHelper.GetImageAsBase64(card.Photo?.UrlImage);
                    if (!string.IsNullOrEmpty(card.Photo?.UrlImage))
                        card.Photo.UrlImage = getImage;
                }

                return cardsDtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
