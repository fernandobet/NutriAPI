using Microsoft.EntityFrameworkCore;
using Nutri.Domain.Models;

namespace Nutri.Infrastructure.Persistence
{
    public class NutriAppContext:DbContext
    {
        public DbSet<Alimento>? Alimentos { get; set; }
        public DbSet<ConsultaPaciente>? ConsultasPacientes { get; set; }
        public DbSet<ConsultaPacienteAlimentos>? ConsultasPacientesAlimentos { get; set; }
        public DbSet<FamiliaAlimento>? FamiliasAlimentos { get; set; }
        public DbSet<ListaSuplementoPersonalizada>? ListasSuplementosPersonalizada { get; set; }
        public DbSet<MedicionAlimento>? MedicionesAlimentos { get; set; }
        public DbSet<MedicionSuplemento>? MedicionesSuplementos { get; set; }
        public DbSet<Paciente>? Pacientes { get; set; }
        public DbSet<Suplemento>? Suplementos { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }

        public NutriAppContext(DbContextOptions<NutriAppContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsultaPacienteAlimentos>()
                .HasKey(x => new { x.Id, x.RenglonComida });
            modelBuilder.Entity<ListaSuplementoPersonalizada>()
                .HasKey(x => new { x.Id, x.Renglon });
        }
    }
}
