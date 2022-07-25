using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NutriApp.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "adfb4631-5400-4d8a-9ef8-6883d19ffc5a",
                    UserId = "879a52be-3b60-4ba1-9c5d-471462a1e7bc"

                },
               new IdentityUserRole<string>
               {
                   RoleId = "f9ac8f40-ac43-404b-b89b-68241972cc27",
                   UserId = "19bf6e7e-ad20-4d38-afc8-d2a6960dd65b"

               }
                );
        }
    }
}
