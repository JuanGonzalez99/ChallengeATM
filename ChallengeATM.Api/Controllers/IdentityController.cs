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
        /// Punto de entrada de la aplicación.
        /// </summary>
        /// <remarks>
        /// - En caso de hallar una tarjeta y pin coincidentes, devolverá un JWT.
        /// - En caso de que no exista la combinación de tarjeta y pin, o la tarjeta esté bloqueada,
        /// devolverá un valor nulo.
        /// </remarks>
        /// <param name="request">Información requerida para iniciar sesión</param>
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
                return Unauthorized("Credenciales inválidas");
            }

            return Ok(token);
        }
    }
}
