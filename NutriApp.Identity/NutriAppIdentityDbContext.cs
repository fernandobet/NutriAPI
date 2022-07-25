using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NutriApp.Identity.Configurations;
using NutriApp.Identity.Models;

namespace NutriApp.Identity
{
    public class NutriAppIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public NutriAppIdentityDbContext(DbContextOptions<NutriAppIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
