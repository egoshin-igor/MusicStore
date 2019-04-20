using Microsoft.EntityFrameworkCore;
using MusicStore.Products.Infrastructure.Configurations;

namespace MusicStore.Products.Infrastructure.Foundation
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext( DbContextOptions<ProductsDbContext> options )
            : base( options )
        {
        }

        protected override void OnModelCreating( ModelBuilder builder )
        {
            builder.ApplyConfiguration( new ProductConfiguration() );
        }
    }
}
