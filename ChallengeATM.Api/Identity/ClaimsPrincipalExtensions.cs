using ChallengeATM.Business.Constants;
using System.Security.Claims;

namespace ChallengeATM.Api.Identity
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetIdTarjeta(this ClaimsPrincipal user)
        {
            var claimValue = user.FindFirstValue(ClaimNames.IdTarjeta);
            
            if (claimValue == null)
            {
                throw new ClaimNotFoundException(ClaimNames.IdTarjeta); 
            }

            var idTarjeta = Convert.ToInt32(claimValue);

            return idTarjeta;
        }
    }
}
