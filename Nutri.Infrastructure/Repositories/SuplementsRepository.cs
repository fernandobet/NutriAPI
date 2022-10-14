using Microsoft.EntityFrameworkCore;
using Nutri.Application.Contracts.Persistence;
using Nutri.Application.Features.Suplements.Commands.EditCustomSuplementList;
using Nutri.Application.Features.Suplements.Queries.GetSuplementsCustomList;
using Nutri.Application.Features.Suplements.Queries.GetSuplementsMedition;
using Nutri.Domain.DTOS;
using Nutri.Domain.Models;
using Nutri.Infrastructure.Persistence;

namespace Nutri.Infrastructure.Repositories
{
    public class SuplementsRepository:RepositoryBase<Suplemento>, ISuplementsRepository
    {
        private readonly NutriAppContext _context;
        public SuplementsRepository(NutriAppContext context):base(context)
        {
            _context = context;
        }

        public List<GetSuplementsCustomListVm> GetSuplementsCustomList()
        {
            var listaPersonalizada = new List<GetSuplementsCustomListVm>();

            var listaEntidad = _context.ListasSuplementosPersonalizada!.ToList();
            if (listaEntidad == null)
                return listaPersonalizada;
            foreach (var lista in listaEntidad)
            {
                listaPersonalizada.Add(new GetSuplementsCustomListVm { 
                Id = lista.Id,
                NombreLista = lista.Nombre
                });
            }
            return listaPersonalizada;
        }

        public List<GetSuplementsMeditionVm> GetSuplementsMedition()
        {
            var resultado = (from suplementos in _context.Suplementos
                             join mediciones in _context.MedicionesSuplementos! on suplementos.MedicionSuplementoId equals mediciones.Id
                             select new GetSuplementsMeditionVm()
                             {
                                 IdMedicion = mediciones.Id,
                                 IdSuplemento = suplementos.Id,
                                 Medicion = mediciones.Descripcion,
                                 Suplemento = suplementos.Nombre
                             }
                 ).ToList();
            return resultado;
        }

        public async Task EditCustomList(AddCustomListDTO dto)
        {
            var cabecero = _context.ListasSuplementosPersonalizada!.FirstOrDefault(x => x.Id == dto.Id);
            cabecero!.Nombre = dto.NombreLista;
            _context.ListasSuplementosPersonalizada!.Update(cabecero);
            var detalle = await _context.ListasSuplementosPersonalizadasDetalle!.Where(x => x.ListaPersonalizadaId == dto.Id).ToListAsync();
            _context.ListasSuplementosPersonalizadasDetalle!.RemoveRange(detalle);
            var nuevoDetalle = new List<ListaSuplementoPersonalizadaDetalle>();
            foreach (var suplemento in dto.Contenido)
            {
                nuevoDetalle.Add(new ListaSuplementoPersonalizadaDetalle
                {
                    ListaPersonalizadaId = cabecero.Id,
                    DescripcionSuplemento = suplemento,
                    FechaCreacion = DateTime.Now,
                    ListaPersonalizada = cabecero
                });
            }
            await _context.ListasSuplementosPersonalizadasDetalle!.AddRangeAsync(nuevoDetalle);
            await _context.SaveChangesAsync();
        }
        public async Task SaveCustomList(AddCustomListDTO dto)
        {
            var cabecero = new ListasSuplementosPersonalizadasDetalle { 
            Nombre = dto.NombreLista,
            FechaCreacion = DateTime.Now
            };
            await _context.ListasSuplementosPersonalizada!.AddAsync(cabecero);
            var detalle = new List<ListaSuplementoPersonalizadaDetalle>();
            foreach (var suplemento in dto.Contenido)
            {
                detalle.Add(new ListaSuplementoPersonalizadaDetalle { 
                ListaPersonalizadaId = cabecero.Id,
                DescripcionSuplemento = suplemento,
                FechaCreacion = DateTime.Now,
                ListaPersonalizada = cabecero
                });
            }
            await _context.ListasSuplementosPersonalizadasDetalle!.AddRangeAsync(detalle);
        }
        public async Task<List<ListaSuplementoPersonalizadaDetalle>> GetSuplementCustomListDetailById(int id)
        {
            return await (from customListDetail in _context.ListasSuplementosPersonalizadasDetalle
                    where customListDetail.ListaPersonalizadaId == id
                    select customListDetail).ToListAsync();
        }
    }
}
