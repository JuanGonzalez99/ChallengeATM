using ChallengeATM.Dto.Internal;
using ChallengeATM.Dto.Response;

namespace ChallengeATM.Business.Mappers.Dto
{
    public static class CreatedOperacionDtoExtensions
    {
        public static RetiroResponseDto MapToRetiroResponse(this CreatedOperacionDto createdOperacionDto, string numeroTarjeta) => new()
        {
            NumeroTarjeta = numeroTarjeta,
            SaldoAnterior = createdOperacionDto.SaldoAnterior,
            Monto = createdOperacionDto.Monto,
            SaldoPosterior = createdOperacionDto.SaldoPosterior,
            FechaHoraCreacion = createdOperacionDto.FechaHoraCreacion
        };
    }
}
