using ChallengeATM.Business.Constants;
using ChallengeATM.Business.Mappers.Dto;
using ChallengeATM.Business.Mappers.Entities;
using ChallengeATM.Business.Services.Interfaces;
using ChallengeATM.Data.Repositories.Interfaces;
using ChallengeATM.Dto.Internal;
using ChallengeATM.Dto.Response;
using Microsoft.Extensions.Configuration;

namespace ChallengeATM.Business.Services
{
    public class OperacionService(IOperacionRepository operacionRepository, IConfiguration configuration) : IOperacionService
    {
        private readonly IOperacionRepository _operacionRepository = operacionRepository;
        private readonly IConfiguration _configuration = configuration;

        public async Task<CreatedOperacionDto> CrearOperacionAsync(CreateOperacionCriteriaDto createOperacionDto, CancellationToken cancellationToken)
        {
            var operacion = createOperacionDto.MapToEntity(TipoOperaciones.CodigoExtraccion);

            await _operacionRepository.AddAsync(operacion);

            var operacionCreada = operacion.MapToCreatedOperacionDto();

            return operacionCreada;
        }

        public async Task<PaginatedResponseDto<OperacionResponseDto>> GetOperacionesAsync(int idTarjeta, int pageNumber, CancellationToken cancellationToken)
        {
            //TODO: Pasar a clase Options que agarre los valores del appsettings automáticamente
            var pageSizeConfig = _configuration["OperacionesPageSize"];
            var pageSize = Convert.ToInt32(pageSizeConfig);

            var skip = (pageNumber - 1) * pageSize;

            var (operaciones, cantidadTotal) = await _operacionRepository.GetPaginatedOperacionesAsync(idTarjeta, skip, pageSize, cancellationToken);

            var operacionesDto = operaciones.MapToOperacionResponseDto();

            var paginatedResponse = new PaginatedResponseDto<OperacionResponseDto>(operacionesDto, cantidadTotal, pageNumber, pageSize);

            return paginatedResponse;
        }
    }
}
