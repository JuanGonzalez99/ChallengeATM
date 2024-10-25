using ChallengeATM.Business.Services.Interfaces;
using ChallengeATM.Dto.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ChallengeATM.Api.Controllers
{
    [ApiController]
    [Route("api/identity")]
    public class IdentityController(IIdentityService identityService) : ControllerBase
    {
        private readonly IIdentityService _identityService = identityService;

        /// <summary>
        /// Punto de entrada de la aplicaci�n.
        /// </summary>
        /// <remarks>
        /// - En caso de hallar una tarjeta y pin coincidentes, devolver� un JWT.
        /// - En caso de que no exista la combinaci�n de tarjeta y pin, o la tarjeta est� bloqueada,
        /// devolver� un valor nulo.
        /// </remarks>
        /// <param name="request">Informaci�n requerida para iniciar sesi�n</param>
        /// <param name="cancellationToken"></param>
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(string))]
        public async Task<IActionResult> LoginAsync(LoginRequestDto request, CancellationToken cancellationToken)
        {
            var token = await _identityService.LoginAsync(request, cancellationToken);

            if (token == null)
            {
                return Unauthorized("Credenciales inv�lidas");
            }

            return Ok(token);
        }
    }
}
