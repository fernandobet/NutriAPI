using Microsoft.EntityFrameworkCore;
using Nutri.Application.Contracts.Persistence;
using Nutri.Application.DTO.Patients;
using Nutri.Application.DTO.Patiients;
using Nutri.Application.Features.Patients.Queries.GetPatientConsult;
using Nutri.Domain.Models;
using Nutri.Infrastructure.Persistence;

namespace Nutri.Infrastructure.Repositories
{
    public class PatientsRepository : RepositoryBase<Paciente>, IPatientsRepository
    {
        private readonly NutriAppContext _context;
        public PatientsRepository(NutriAppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ConsultaPaciente>> GetAllHistory(int idPaciente)
        {
            return await (from consultas in _context.ConsultasPacientes
                          where consultas.PacienteId == idPaciente
                          select consultas).ToListAsync();
        }

        public async Task<GetPatientConsultDTO> GetPatientConsult(int id)
        {
            var cabeceroConsulta = await (from consulta in _context.ConsultasPacientes
                                          join paciente in _context.Pacientes! on consulta.Id equals paciente.Id
                                          where consulta.Id == id
                                          select new
                                          {
                                              FechaConsulta = consulta.FechaCreacion,
                                              NombrePaciente = $"{paciente.Nombre} {paciente.Apellido}",
                                              EmailPaciente = paciente.Email
                                          }).FirstOrDefaultAsync();
            var detalleConsulta = await (from alimentosConsulta in _context.ConsultasPacientesAlimentos
                                         where alimentosConsulta.Id == id
                                         select alimentosConsulta).ToListAsync();
            var comidasAgrupadas = (from alimentosConsulta in _context.ConsultasPacientesAlimentos
                                    where alimentosConsulta.Id == id
                                    select alimentosConsulta).ToList().GroupBy(x => x.NumeroComida).Select(x => new
                                    {
                                        NumeroComida = x.Key,
                                        HoraComida = x.FirstOrDefault()?.Hora
                                    }).OrderBy(x => x.HoraComida).ToList();
            var listaConsulta = new List<GetPatientConsultInfoFoodVm>();
            foreach (var comida in comidasAgrupadas)
            {
                var alimentosSeleccionados = new List<GetPatientConsultUpdateInfoFoodDTO>();
                var comidasPorNComida = detalleConsulta.Where(x => x.NumeroComida == comida.NumeroComida).OrderBy(x => x.NumeroComida).ToList();
                var nuevoRenglon = new GetPatientConsultInfoFoodVm
                {
                    Hora = comida!.HoraComida,
                    NombrePaciente = cabeceroConsulta!.NombrePaciente,
                    Numero = comida.NumeroComida,
                    FechaCreacion = cabeceroConsulta.FechaConsulta.ToShortDateString(),
                    EmailPaciente = cabeceroConsulta.EmailPaciente
                };
                foreach (var renglonPorComida in comidasPorNComida)
                {
                    alimentosSeleccionados.Add(new GetPatientConsultUpdateInfoFoodDTO
                    {
                        Alimento = renglonPorComida.Comida
                    });
                }
                nuevoRenglon.AlimentosSeleccionados = alimentosSeleccionados;
                listaConsulta.Add(nuevoRenglon);
            }
            return new GetPatientConsultDTO { Alimentos = listaConsulta };

        }
    }
}
