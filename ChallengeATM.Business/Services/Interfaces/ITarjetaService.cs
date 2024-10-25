using ChallengeATM.Dto.Internal;
using ChallengeATM.Dto.Response;

namespace ChallengeATM.Business.Services.Interfaces
{
    public interface ITarjetaService
    {
        Task<SaldoResponseDto?> GetSaldoAsync(int idTarjeta, CancellationToken cancellationToken);
        Task<RetiroResponseDto> RetirarMontoAsync(int idTarjeta, decimal monto, CancellationToken cancellationToken);
        Task<TarjetaDto?> GetTarjetaAsync(string numeroTarjeta, CancellationToken cancellationToken);
        Task AgregarIntentoFallidoAsync(int idTarjeta, CancellationToken cancellationToken);
        Task ReiniciarIntentosFallidosAsync(int idTarjeta, CancellationToken cancellationToken);
    }
}
