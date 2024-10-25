using ChallengeATM.Data.Entities;
using ChallengeATM.Data.Repositories.Base;

namespace ChallengeATM.Data.Repositories.Interfaces
{
    public interface IOperacionRepository : IBaseRepository<Operacion>
    {
        Task<(List<Operacion> operaciones, int cantidadTotal)> GetPaginatedOperacionesAsync(int idTarjeta, int skip, int take, CancellationToken cancellationToken);
    }
}
