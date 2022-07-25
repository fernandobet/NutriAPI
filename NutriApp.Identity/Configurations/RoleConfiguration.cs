
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NutriApp.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole { 
                    Id= "adfb4631-5400-4d8a-9ef8-6883d19ffc5a",
                    Name ="Administrator",
                    NormalizedName ="ADMINISTRATOR"
                },
                new IdentityRole {
                    Id = "f9ac8f40-ac43-404b-b89b-68241972cc27",
                    Name = "Operator",
                    NormalizedName = "OPERATOR"
                }
                );
        }
    }
}
