using Entities.Entites;
using Service.DTOs;

namespace Service.Interfaces
{
    public interface IProductManagerService
    {
        Task<List<CardDTO>> GetAll();
        Task<bool> Insert(CardDTOInsert card);
        Task<CardDTO?> GetById(int id);
        Task<bool> Update(CardDTO cardEdit);
        Task<bool> Delete(int id);
    }
}
