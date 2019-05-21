using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Bank.Core.Clients;

namespace MusicStore.Bank.Infrastructure.Configurations
{
    public class TransactionHistoryConfiguration : IEntityTypeConfiguration<TransactionsHistory>
    {
        public void Configure( EntityTypeBuilder<TransactionsHistory> builder )
        {
            builder.ToTable( nameof( TransactionsHistory ) ).HasKey( t => t.Id );
            builder.Property( t => t.Id ).ValueGeneratedNever();
            builder.Property( t => t.Id ).HasColumnName( "TransactionId" );
            builder.HasIndex( t => t.Email );
        }
    }
}
