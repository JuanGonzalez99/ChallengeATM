using ChallengeATM.Data.Entities;
using ChallengeATM.Dto.Internal;
using ChallengeATM.Dto.Response;

namespace ChallengeATM.Business.Mappers.Entities
{
    public static class OperacionExtensions
    {
        public static CreatedOperacionDto MapToCreatedOperacionDto(this Operacion operacion) => new()
        {
            Id = operacion.Id,
            TarjetaId = operacion.TarjetaId,
            TipoOperacionCodigo = operacion.TipoOperacionCodigo,
            FechaHoraCreacion = operacion.FechaHoraCreacion,
            SaldoAnterior = operacion.SaldoAnterior,
            Monto = operacion.Monto,
            SaldoPosterior = operacion.SaldoPosterior
        };

        public static OperacionResponseDto MapToOperacionResponseDto(this Operacion operacion) => new()
        {
            NumeroTarjeta = operacion.Tarjeta!.NumeroTarjeta,
            TipoOperacion = operacion.TipoOperacionCodigo,
            SaldoAnterior = operacion.SaldoAnterior,
            Monto = operacion.Monto,
            SaldoPosterior = operacion.SaldoPosterior,
            FechaHoraCreacion = operacion.FechaHoraCreacion
        };

        public static List<OperacionResponseDto> MapToOperacionResponseDto(this List<Operacion> operaciones) => 
            operaciones.ConvertAll(o => o.MapToOperacionResponseDto());
    }
}
