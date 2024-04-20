using Cross.Pagination;
using Entities.Entites;
using Microsoft.EntityFrameworkCore;
using Repository.Commom;
using Repository.Interfaces;


namespace Repository.Repositories
{
    public class ProductManagerRepository : IProductManagerRepository
    {
        protected readonly ProductManagerDbContext ProductManagerDbContext;
        public ProductManagerRepository(ProductManagerDbContext productManagerDbContext)
        {
            ProductManagerDbContext = productManagerDbContext;
        }
        public async Task<IEnumerable<Card>> GetAll()
        {
            var cardList = await ProductManagerDbContext.Cards
                .Select(x => new Card
                {
                    Id = x.Id,
                    IdPhoto = x.IdPhoto,
                    Photo = x.Photo != null ? new Photo
                    {
                        Id = x.Photo.Id,
                        Base64 = x.Photo.Base64
                    } : null,
                    Name = x.Name,
                    Status = x.Status,

                }).ToListAsync();

            return cardList.AsEnumerable();
        }

        public async Task<Card?> GetById(int id)
        {
            if (id is 0)
            {
                return null;
            }

            try
            {
                var getById = await ProductManagerDbContext.Cards
               .Select(x => new Card
               {
                   Id = x.Id,
                   IdPhoto = x.IdPhoto,
                   Photo = x.Photo != null ? new Photo
                   {
                       Id = x.Photo.Id,
                       Base64 = x.Photo.Base64
                   } : null,
                   Name = x.Name,
                   Status = x.Status,

               }).FirstOrDefaultAsync();

                return getById;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Unable to find card {ex}");
            }

        }

        public async Task<bool> Create(Card card)
        {
            if (card is null)
            {
                return false;
            }

            try
            {
                if (card.Photo != null)
                    ProductManagerDbContext.Photos.Add(card.Photo);
                await ProductManagerDbContext.SaveChangesAsync();

                if (card.Photo != null)
                    card.IdPhoto = card.Photo.Id;

                ProductManagerDbContext.Cards.Add(card);
                await ProductManagerDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Unable to create card {ex}");
            }
        }

        public async Task<bool> Update(Card cardEdit)
        {
            if (cardEdit is null)
            {
                return false;
            }

            var existingCard = await ProductManagerDbContext.Cards.FindAsync(cardEdit.Id);
            if (existingCard == null)
            {
                return false;
            }

            try
            {
                existingCard.IdPhoto = cardEdit.IdPhoto;
                existingCard.Name = cardEdit.Name;
                existingCard.Status = cardEdit.Status;
                existingCard.Photo = cardEdit.Photo;
                ProductManagerDbContext.UpdateRange(existingCard);
                await ProductManagerDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Unable to update card {ex}");
            }

        }

        public async Task<bool> Delete(int id)
        {
            if (id < 0)
            {
                return false;
            }

            var cardDelete = await ProductManagerDbContext.Cards.FindAsync(id);

            if (cardDelete is null)
            {
                throw new ArgumentException("User not found");
            }

            try
            {
                ProductManagerDbContext.RemoveRange(cardDelete);
                await ProductManagerDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Card>> GetAllProducts(ProductsParameters productsParameters)
        {
            return (await GetAll())
            .OrderBy(p => p.Id)
            .Skip((productsParameters.PageNumber - 1) * productsParameters.PageSize)
            .Take(productsParameters.PageSize)
            .ToList();
        }
    }
}
