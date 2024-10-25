using ChallengeATM.Data.Entities;
using ChallengeATM.Dto.Internal;

namespace ChallengeATM.Business.Mappers.Dto
{
    public static class CreateOperacionCriteriaDtoExtensions
    {
        public static Operacion MapToEntity(this CreateOperacionCriteriaDto createOperacionCriteriaDto, string tipoOperacionCodigo) => new()
        {
            TarjetaId = createOperacionCriteriaDto.TarjetaId,
            TipoOperacionCodigo = tipoOperacionCodigo,
            SaldoAnterior = createOperacionCriteriaDto.SaldoAnterior,
            Monto = createOperacionCriteriaDto.Monto,
            SaldoPosterior = createOperacionCriteriaDto.SaldoAnterior - createOperacionCriteriaDto.Monto,
            FechaHoraCreacion = DateTime.UtcNow
        };
    }
}
