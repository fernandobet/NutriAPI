using Nutri.Application.Contracts.Persistence;
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
            listaPersonalizada = listaEntidad.GroupBy(x => new { x.Id, x.Nombre }).Select(x => new GetSuplementsCustomListVm
            {
                Id = x.Key.Id,
                NombreLista = x.Key.Nombre,
                Contenido = new List<string>(x.Select(x => x.DescripcionSuplemento))
            }).ToList();
            return listaPersonalizada;
        }

        public List<GetSuplementsMeditionVm> GetSuplementsMedition()
        {
            var resultado = (from suplementos in _context.Suplementos
                             join mediciones in _context.MedicionesSuplementos! on suplementos.Id equals mediciones.Id
                             select new GetSuplementsMeditionVm()
                             {
                                 IdMedicion = mediciones.Id,
                                 IdSuplemento = suplementos.Id,
                                 Medicion = mediciones.Decripcion,
                                 Suplemento = suplementos.Nombre
                             }
                 ).ToList();
            return resultado;
        }

        public async Task SaveCustomList(AddCustomListDTO dto)
        {
            var finalList = new List<ListaSuplementoPersonalizada>();
            short renglon = 1;

            foreach (var item in dto.Contenido)
            {
                await _context.ListasSuplementosPersonalizada!.AddAsync(new ListaSuplementoPersonalizada { 
                    Nombre = dto.NombreLista,
                    DescripcionSuplemento = item,
                    Renglon = renglon
                });
                renglon++;
            }
        }
    }
}
