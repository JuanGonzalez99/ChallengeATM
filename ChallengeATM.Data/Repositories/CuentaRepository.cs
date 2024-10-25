using ChallengeATM.Data.Entities;
using ChallengeATM.Data.Repositories.Base;
using ChallengeATM.Data.Repositories.Interfaces;

namespace ChallengeATM.Data.Repositories
{
    public class CuentaRepository(ChallengeATMDbContext dbContext) : BaseRepository<Cuenta>(dbContext), ICuentaRepository
    {
    }
}
