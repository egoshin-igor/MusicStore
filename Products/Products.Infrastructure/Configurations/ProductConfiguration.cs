using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Products.Core.Products;

namespace MusicStore.Products.Infrastructure.Configurations
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure( EntityTypeBuilder<Product> builder )
        {
            builder.ToTable( nameof( Product ) ).HasKey( t => t.Id );
            builder.Property( t => t.Id ).HasColumnName( "ProductId" );
            builder.HasIndex( t => t.Category );
        }
    }
}
