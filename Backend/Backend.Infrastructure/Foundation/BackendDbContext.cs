using Microsoft.EntityFrameworkCore;
using MusicStore.Backend.Infrastructure.Configurations;

namespace MusicStore.Backend.Infrastructure.Foundation
{
    public class BackendDbContext : DbContext
    {
        public BackendDbContext( DbContextOptions<BackendDbContext> options )
            : base( options )
        {
        }

        protected override void OnModelCreating( ModelBuilder builder )
        {
            builder.ApplyConfiguration( new UserConfiguration() );
            builder.ApplyConfiguration( new UserLoginTokenConfiguration() );
        }
    }
}
