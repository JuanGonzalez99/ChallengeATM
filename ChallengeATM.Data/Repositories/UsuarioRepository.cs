using ChallengeATM.Data.Entities;
using ChallengeATM.Data.Repositories.Base;
using ChallengeATM.Data.Repositories.Interfaces;

namespace ChallengeATM.Data.Repositories
{
    public class UsuarioRepository(ChallengeATMDbContext dbContext) : BaseRepository<Usuario>(dbContext), IUsuarioRepository
    {
    }
}
