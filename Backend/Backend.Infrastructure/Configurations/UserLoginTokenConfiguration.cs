using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Backend.Application.Entities.Users;

namespace MusicStore.Backend.Infrastructure.Configurations
{
    public class UserLoginTokenConfiguration : IEntityTypeConfiguration<UserLoginToken>
    {
        public void Configure( EntityTypeBuilder<UserLoginToken> builder )
        {
            builder.ToTable( nameof( UserLoginToken ) ).HasKey( t => t.Email );
            builder.Property( t => t.Email ).ValueGeneratedNever();
        }
    }
}
