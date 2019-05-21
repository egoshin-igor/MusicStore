using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Products.Core.Products;

namespace MusicStore.Products.Infrastructure.Configurations
{
    class ProductHistoryConfiguration : IEntityTypeConfiguration<ProductHistory>
    {
        public void Configure( EntityTypeBuilder<ProductHistory> builder )
        {
            builder.ToTable( nameof( ProductHistory ) ).HasKey( t => t.Id );
            builder.HasIndex( t => new { t.Email, t.TransactionId } );
            builder.Property( t => t.Id ).HasColumnName( "ProductHistoryId" );
        }
    }
}
