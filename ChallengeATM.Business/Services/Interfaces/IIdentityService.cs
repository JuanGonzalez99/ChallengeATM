using ChallengeATM.Dto.Request;

namespace ChallengeATM.Business.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<string?> LoginAsync(LoginRequestDto loginRequestDto, CancellationToken cancellationToken);
    }
}
