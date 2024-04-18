using Cross;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Repository.Commom
{
    public class ProductManagerDbContextFactory : IDesignTimeDbContextFactory<ProductManagerDbContext>
    {
        public ProductManagerDbContext CreateDbContext(string[] arg)
        {
            var builder = new DbContextOptionsBuilder<ProductManagerDbContext>();

            return new ProductManagerDbContext(builder.Options);
        }
    }
}
