using Cross.Pagination;
using Entities.Entites;
using Service.DTOs;

namespace Service.Interfaces
{
    public interface IProductManagerService
    {
        public Task<IEnumerable<CardDTO>> GetAllProducts(ProductsParameters productsParameters);
        Task<List<CardDTO>> GetAll();
        Task<bool> Insert(CardDTOInsert card);
        Task<CardDTO?> GetById(int id);
        Task<bool> Update(CardDTO cardEdit);
        Task<bool> Delete(int id);
    }
}
