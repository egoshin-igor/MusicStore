using Microsoft.EntityFrameworkCore;
using MusicStore.Bank.Infrastructure.Configurations;

namespace MusicStore.Banks.Infrastructure.Foundation
{
    public class BanksDbContext : DbContext
    {
        public BanksDbContext( DbContextOptions<BanksDbContext> options )
            : base( options )
        {
        }

        protected override void OnModelCreating( ModelBuilder builder )
        {
            builder.ApplyConfiguration( new ClientConfiguration() );
            builder.ApplyConfiguration( new TransactionHistoryConfiguration() );
        }
    }
}
