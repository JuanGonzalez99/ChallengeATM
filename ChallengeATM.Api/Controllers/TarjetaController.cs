using ChallengeATM.Api.Identity;
using ChallengeATM.Business.Exceptions;
using ChallengeATM.Business.Services.Interfaces;
using ChallengeATM.Dto.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ChallengeATM.Api.Controllers
{
    [ApiController]
    [Route("api/tarjetas")]
    public class TarjetaController(ITarjetaService tarjetaService, IOperacionService operacionService) : ControllerBase
    {
        private readonly ITarjetaService _tarjetaService = tarjetaService;
        private readonly IOperacionService _operacionService = operacionService;

        /// <summary>
        /// Devuelve información relacionada con la tarjeta
        /// </summary>
        /// <remarks>
        /// Requiere de autenticación con JWT, mediante el cual se obtendrá el identificador de la tarjeta.
        /// </remarks>
        /// <param name="cancellationToken"></param>
        [HttpGet("saldo")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SaldoResponseDto))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetSaldoAsync(CancellationToken cancellationToken)
        {
            var idTarjeta = User.GetIdTarjeta();

            var saldoResponse = await _tarjetaService.GetSaldoAsync(idTarjeta, cancellationToken);

            if (saldoResponse == null)
            {
                return NotFound();
            }

            return Ok(saldoResponse);
        }

        /// <summary>
        /// Realiza un retiro de dinero de una tarjeta.
        /// </summary>
        /// <remarks>
        /// Requiere de autenticación con JWT, mediante el cual se obtendrá el identificador de la tarjeta.
        /// 
        /// - En caso de retiro exitoso, devolverá un resumen de la operación realizada.
        /// - En caso de que el monto supere el saldo disponible, devolverá un error informando la situación.
        /// </remarks>
        /// <param name="monto">Monto a retirar. Debe ser positivo</param>
        /// <param name="cancellationToken"></param>
        [HttpPut("retiro")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(RetiroResponseDto))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
        public async Task<IActionResult> RetiroAsync(decimal monto, CancellationToken cancellationToken)
        {
            try
            {
                if (monto <= 0)
                {
                    return BadRequest("El monto debe ser positivo.");
                }

                var idTarjeta = User.GetIdTarjeta();

                var retiroResponseDto = await _tarjetaService.RetirarMontoAsync(idTarjeta, monto, cancellationToken);

                return Ok(retiroResponseDto);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Devuelve las operaciones realizadas con la tarjeta en páginas de 10 registros.
        /// </summary>
        /// <remarks>
        /// Requiere de autenticación con JWT, mediante el cual se obtendrá el identificador de la tarjeta.
        /// </remarks>
        /// <param name="pageNumber">Número de página a consultar. Debe ser positivo. Por defecto es 1.</param>
        /// <param name="cancellationToken"></param>
        [HttpGet("operaciones")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PaginatedResponseDto<OperacionResponseDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetOperacionesAsync(int pageNumber = 1, CancellationToken cancellationToken = default)
        {
            if (pageNumber < 1)
            {
                return BadRequest("El número de página debe ser positivo.");
            }

            var idTarjeta = User.GetIdTarjeta();

            var operacionesDto = await _operacionService.GetOperacionesAsync(idTarjeta, pageNumber, cancellationToken);

            return Ok(operacionesDto);
        }
    }
}
