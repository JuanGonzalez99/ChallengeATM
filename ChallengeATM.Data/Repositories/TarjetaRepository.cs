using ChallengeATM.Data.Entities;
using ChallengeATM.Data.Repositories.Base;
using ChallengeATM.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChallengeATM.Data.Repositories
{
    public class TarjetaRepository(ChallengeATMDbContext dbContext) : BaseRepository<Tarjeta>(dbContext), ITarjetaRepository
    {
        public Task<Tarjeta?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return Get()
                .Include(t => t.Cuenta)
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        }

        public Task<Tarjeta?> GetByNumeroTarjetaAsync(string numeroTarjeta, CancellationToken cancellationToken)
        {
            return Get()
                .FirstOrDefaultAsync(t => t.NumeroTarjeta == numeroTarjeta, cancellationToken);
        }
    }
}
