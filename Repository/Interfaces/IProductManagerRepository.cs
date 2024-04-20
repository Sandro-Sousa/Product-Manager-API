using Entities.Entites;
using Cross.Pagination;

namespace Repository.Interfaces
{
    public interface IProductManagerRepository
    {
        Task<IEnumerable<Card>> GetAllProducts(ProductsParameters productsParameters);
        Task<IEnumerable<Card>> GetAll();
        Task<bool> Create(Card card);
        Task<Card?> GetById(int id);
        Task<bool> Update(Card cardEdit);
        Task<bool> Delete(int id);
    }
}

