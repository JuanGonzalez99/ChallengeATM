using ChallengeATM.Business.Exceptions;
using ChallengeATM.Business.Mappers.Dto;
using ChallengeATM.Business.Mappers.Entities;
using ChallengeATM.Business.Services.Interfaces;
using ChallengeATM.Data.Repositories.Interfaces;
using ChallengeATM.Dto.Internal;
using ChallengeATM.Dto.Response;
using Microsoft.Extensions.Configuration;

namespace ChallengeATM.Business.Services
{
    public class TarjetaService(ITarjetaRepository tarjetaRepository, IOperacionService operacionService, IConfiguration configuration) : ITarjetaService
    {
        private readonly ITarjetaRepository _tarjetaRepository = tarjetaRepository;
        private readonly IOperacionService _operacionService = operacionService;
        private readonly IConfiguration _configuration = configuration;

        public async Task<SaldoResponseDto?> GetSaldoAsync(int idTarjeta, CancellationToken cancellationToken)
        {
            var tarjeta = await _tarjetaRepository.GetByIdAsync(idTarjeta, cancellationToken);

            if (tarjeta == null)
            {
                return null;
            }

            var saldoResponseDto = tarjeta.MapToSaldoResponseDto();

            return saldoResponseDto;
        }

        public async Task<RetiroResponseDto> RetirarMontoAsync(int idTarjeta, decimal monto, CancellationToken cancellationToken)
        {
            var tarjeta = await _tarjetaRepository.GetByIdAsync(idTarjeta, cancellationToken);

            if (tarjeta == null)
            {
                throw new NotFoundException($"No se encontró la tarjeta con id {idTarjeta}.");
            }

            if (monto > tarjeta.Cuenta!.Saldo)
            {
                throw new BadRequestException($"Fondos insuficientes. Se intentó retirar {monto}, pero el saldo disponible es {tarjeta.Cuenta.Saldo}.");
            }

            var createOperacionCriteriaDto = tarjeta.MapToCreateOperacionCriteriaDto(monto);

            var createdOperacionDto = await _operacionService.CrearOperacionAsync(createOperacionCriteriaDto, cancellationToken);

            tarjeta.Cuenta.Saldo = createdOperacionDto.SaldoPosterior;
            tarjeta.FechaUltimaExtraccion = createdOperacionDto.FechaHoraCreacion;

            //TODO: Implementar UnitOfWork para el manejo de transactions
            await _tarjetaRepository.UpdateAsync(tarjeta);

            var retiroResponseDto = createdOperacionDto.MapToRetiroResponse(tarjeta.NumeroTarjeta);

            return retiroResponseDto;
        }

        public async Task<TarjetaDto?> GetTarjetaAsync(string numeroTarjeta, CancellationToken cancellationToken)
        {
            var tarjeta = await _tarjetaRepository.GetByNumeroTarjetaAsync(numeroTarjeta, cancellationToken);

            if (tarjeta == null)
            {
                return null;
            }

            var tarjetaDto = tarjeta.MapToDto();

            return tarjetaDto;
        }

        public async Task AgregarIntentoFallidoAsync(int idTarjeta, CancellationToken cancellationToken)
        {
            var tarjeta = await _tarjetaRepository.GetByIdAsync(idTarjeta, cancellationToken);

            if (tarjeta == null)
            {
                throw new NotFoundException($"No se encontró la tarjeta con id {idTarjeta}.");
            }

            tarjeta.IntentosFallidos++;

            //TODO: Pasar a clase Options que agarre los valores del appsettings automáticamente
            var intentosStr = _configuration["MaxIntentosFallidosPermitidos"];
            var intentosFallidosMax = Convert.ToInt32(intentosStr);

            if (tarjeta.IntentosFallidos == intentosFallidosMax)
            {
                tarjeta.EstaBloqueada = true;
            }

            await _tarjetaRepository.UpdateAsync(tarjeta);
        }

        public async Task ReiniciarIntentosFallidosAsync(int idTarjeta, CancellationToken cancellationToken)
        {
            var tarjeta = await _tarjetaRepository.GetByIdAsync(idTarjeta, cancellationToken);

            if (tarjeta == null)
            {
                throw new NotFoundException($"No se encontró la tarjeta con id {idTarjeta}.");
            }

            tarjeta.IntentosFallidos = 0;

            await _tarjetaRepository.UpdateAsync(tarjeta);
        }
    }
}
