using ChallengeATM.Data.Entities;
using ChallengeATM.Data.Repositories.Base;
using ChallengeATM.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChallengeATM.Data.Repositories
{
    public class OperacionRepository(ChallengeATMDbContext dbContext) : BaseRepository<Operacion>(dbContext), IOperacionRepository
    {
        public Task<(List<Operacion> operaciones, int cantidadTotal)> GetPaginatedOperacionesAsync(int idTarjeta, int skip, int take, CancellationToken cancellationToken)
        {
            var baseQuery = Get()
                .Include(o => o.Tarjeta)
                .Where(o => o.TarjetaId == idTarjeta)
                .OrderBy(o => o.Id);

            return GetPaginatedAsync(baseQuery, skip, take, cancellationToken);
        }
    }
}
