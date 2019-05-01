using Microsoft.EntityFrameworkCore;
using MusicStore.Backend.Application.Entities.Users;

namespace MusicStore.Backend.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure( Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder )
        {
            builder.ToTable( nameof( User ) ).HasKey( t => t.Email );
            builder.Property( t => t.Email ).ValueGeneratedNever();

            builder
                .HasOne( User.LoginTokenProperty )
                .WithOne()
                .HasForeignKey<UserLoginToken>( t => t.Email );
        }
    }
}
