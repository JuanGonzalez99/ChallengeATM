using ChallengeATM.Dto.Internal;
using ChallengeATM.Dto.Response;

namespace ChallengeATM.Business.Services.Interfaces
{
    public interface IOperacionService
    {
        Task<CreatedOperacionDto> CrearOperacionAsync(CreateOperacionCriteriaDto createOperacionDto, CancellationToken cancellationToken);
        Task<PaginatedResponseDto<OperacionResponseDto>> GetOperacionesAsync(int idTarjeta, int pageNumber, CancellationToken cancellationToken);
    }
}
