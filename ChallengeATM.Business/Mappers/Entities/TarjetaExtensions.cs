using ChallengeATM.Data.Entities;
using ChallengeATM.Dto.Internal;
using ChallengeATM.Dto.Response;

namespace ChallengeATM.Business.Mappers.Entities
{
    public static class TarjetaExtensions
    {
        public static TarjetaDto MapToDto(this Tarjeta tarjeta) => new()
        {
            Id = tarjeta.Id,
            Pin = tarjeta.Pin,
            EstaBloqueada = tarjeta.EstaBloqueada
        };

        public static SaldoResponseDto MapToSaldoResponseDto(this Tarjeta tarjeta) => new()
        {
            NumeroCuenta = tarjeta.Cuenta!.NumeroCuenta,
            SaldoActual = tarjeta.Cuenta!.Saldo,
            NombreUsuario = tarjeta.Usuario!.Nombre,
            FechaUltimaExtraccion = tarjeta.FechaUltimaExtraccion
        };

        public static CreateOperacionCriteriaDto MapToCreateOperacionCriteriaDto(this Tarjeta tarjeta, decimal monto) => new()
        {
            TarjetaId = tarjeta.Id,
            SaldoAnterior = tarjeta.Cuenta!.Saldo,
            Monto = monto
        };
    }
}
