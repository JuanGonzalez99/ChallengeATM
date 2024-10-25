using ChallengeATM.Data.Entities;
using ChallengeATM.Data.Repositories.Base;

namespace ChallengeATM.Data.Repositories.Interfaces
{
    public interface ITarjetaRepository : IBaseRepository<Tarjeta>
    {
        Task<Tarjeta?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<Tarjeta?> GetByNumeroTarjetaAsync(string numeroTarjeta, CancellationToken cancellationToken);
    }
}
