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
                                          join paciente in _context.Pacientes! on consulta.PacienteId equals paciente.Id
                                          where consulta.Id == id
                                          select new
                                          {
                                              FechaConsulta = consulta.FechaCreacion,
                                              NombrePaciente = $"{paciente.Nombre} {paciente.Apellido}",
                                              EmailPaciente = paciente.Email
                                          }).FirstOrDefaultAsync();
            var detalleConsulta = await (from alimentosConsulta in _context.ConsultasPacientesAlimentos
                                         where alimentosConsulta.ConsultaPacienteId == id
                                         select alimentosConsulta).ToListAsync();
            var comidasAgrupadas = (from alimentosConsulta in _context.ConsultasPacientesAlimentos
                                    where alimentosConsulta.ConsultaPacienteId == id
                                    select alimentosConsulta).ToList().GroupBy(x => x.NumeroComida).Select(x => new
                                    {
                                        NumeroComida = x.Key,
                                        HoraComida = x.FirstOrDefault()?.Hora
                                    }).OrderBy(x => x.HoraComida).ToList();
            //Suplementos
            var suplementosConsult = await (from suplementosConsulta in _context.ConsultasPacientesSuplementos
                                            where suplementosConsulta.ConsultaPacienteId == id
                                            select 
                                            new IGenSuplementosConMedicionDTO { TextoAdicional = suplementosConsulta.Suplemento })
                                            .ToListAsync();

            var listaConsulta = new List<GetPatientConsultInfoFoodVm>();
            foreach (var comida in comidasAgrupadas)
            {
                var alimentosSeleccionados = new List<GetPatientConsultUpdateInfoFoodDTO>();
                var comidasPorNComida = detalleConsulta.Where(x => x.NumeroComida == comida.NumeroComida).OrderBy(x => x.NumeroComida).ToList();
                var nuevoRenglon = new GetPatientConsultInfoFoodVm
                {
                    Hora = comida!.HoraComida,
                    NombrePaciente = cabeceroConsulta!.NombrePaciente,
                    Numero = comida!.NumeroComida,
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
            //Notes
            var notas = await _context.ConsultasPacientesNotas.FirstOrDefaultAsync(x => x.ConsultaPacienteId == id);

            GetPatientConsultDTO dtoResponse = new()
            {
                IdDietaPaciente = id,
                Alimentos = listaConsulta,
                Notas = notas?.Nota ?? String.Empty,
                Suplementos = suplementosConsult

            };
            return dtoResponse;

        }
    }
}
