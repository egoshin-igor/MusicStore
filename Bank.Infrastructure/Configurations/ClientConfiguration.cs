using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Bank.Core.Clients;

namespace MusicStore.Bank.Infrastructure.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure( EntityTypeBuilder<Client> builder )
        {
            builder.ToTable( nameof( Client ) ).HasKey( t => t.Email );
            builder.Property( t => t.Email ).ValueGeneratedNever();

            builder
                .HasMany<TransactionsHistory>()
                .WithOne()
                .HasForeignKey( t => t.Email );
        }
    }
}
