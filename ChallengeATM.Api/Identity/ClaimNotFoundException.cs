namespace ChallengeATM.Api.Identity
{
    public class ClaimNotFoundException(string claimName) : Exception($"El claim {claimName} no fue encontrado")
    {
    }
}
