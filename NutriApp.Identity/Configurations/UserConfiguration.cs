
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutriApp.Identity.Models;

namespace NutriApp.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser()
                {
                    Id = "879a52be-3b60-4ba1-9c5d-471462a1e7bc",
                    Email = "michbc1994@gmail.com",
                    NormalizedEmail = "michbc1994@gmail.com",
                    Nombre = "Fernando",
                    Apellidos = "Betancourt",
                    UserName = "fbeta",
                    NormalizedUserName = "fbeta",
                    PasswordHash = hasher.HashPassword(null, "AdsaK2021$"),
                    EmailConfirmed = true
                },
                new ApplicationUser()
                {
                    Id = "19bf6e7e-ad20-4d38-afc8-d2a6960dd65b",
                    Email = "fernando.mbc@hotmail.com",
                    NormalizedEmail = "fernando.mbc@hotmail.com",
                    Nombre = "Michelle",
                    Apellidos = "Betancourt",
                    UserName = "Mbeta",
                    NormalizedUserName = "Mbeta",
                    PasswordHash = hasher.HashPassword(null, "AdsaK2021$"),
                    EmailConfirmed = true
                }
                );
        }
    }
}
