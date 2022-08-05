using Nutri.Application.Features.Suplements.Queries.GetSuplementsCustomList;
using Nutri.Application.Features.Suplements.Queries.GetSuplementsMedition;
using Nutri.Domain.DTOS;
using Nutri.Domain.Models;

namespace Nutri.Application.Contracts.Persistence
{
    public interface ISuplementsRepository : IAsyncRepository<Suplemento>
    {
        List<GetSuplementsCustomListVm> GetSuplementsCustomList();
        List<GetSuplementsMeditionVm> GetSuplementsMedition();
        Task SaveCustomList(AddCustomListDTO dto);
    }
}
