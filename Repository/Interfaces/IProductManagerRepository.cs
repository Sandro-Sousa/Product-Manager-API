using Entities.Entites;

namespace Repository.Interfaces
{
    public interface IProductManagerRepository
    {
        Task<IEnumerable<Card>> GetAll();
        Task<bool> Create(Card card);
        Task<Card?> GetById(int id);
        Task<bool> Update(Card cardEdit);
        Task<bool> Delete(int id);
    }
}

