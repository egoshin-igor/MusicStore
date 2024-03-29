﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicStore.Backend.Infrastructure.Foundation;

namespace MusicStore.Backend.Api.Migrations
{
    [DbContext(typeof(BackendDbContext))]
    [Migration("20190501143053_AddUserAggregate")]
    partial class AddUserAggregate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MusicStore.Backend.Application.Entities.Users.User", b =>
                {
                    b.Property<string>("Email");

                    b.Property<string>("Role");

                    b.HasKey("Email");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MusicStore.Backend.Application.Entities.Users.UserLoginToken", b =>
                {
                    b.Property<string>("Email");

                    b.Property<DateTime>("ExpiratedOnUtc");

                    b.Property<string>("Token");

                    b.HasKey("Email");

                    b.ToTable("UserLoginToken");
                });

            modelBuilder.Entity("MusicStore.Backend.Application.Entities.Users.UserLoginToken", b =>
                {
                    b.HasOne("MusicStore.Backend.Application.Entities.Users.User")
                        .WithOne("_loginToken")
                        .HasForeignKey("MusicStore.Backend.Application.Entities.Users.UserLoginToken", "Email")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
