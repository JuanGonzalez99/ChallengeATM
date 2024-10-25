using ChallengeATM.Business.Constants;
using ChallengeATM.Business.Mappers.Dto;
using ChallengeATM.Business.Services.Interfaces;
using ChallengeATM.Dto.Internal;
using ChallengeATM.Dto.Request;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChallengeATM.Business.Services
{
    public class IdentityService(ITarjetaService tarjetaService, IConfiguration configuration) : IIdentityService
    {
        private readonly ITarjetaService _tarjetaService = tarjetaService;
        private readonly IConfiguration _configuration = configuration;

        public async Task<string?> LoginAsync(LoginRequestDto loginRequestDto, CancellationToken cancellationToken)
        {
            var tarjetaDto = await _tarjetaService.GetTarjetaAsync(loginRequestDto.NumeroTarjeta, cancellationToken);

            if (tarjetaDto == null)
            {
                return null;
            }

            //TODO: Comparar (y almacenar) hashes, no texto plano
            if (tarjetaDto.Pin != loginRequestDto.Pin) 
            {
                await _tarjetaService.AgregarIntentoFallidoAsync(tarjetaDto.Id, cancellationToken);
                return null;
            }

            if (tarjetaDto.EstaBloqueada)
            {
                return null;
            }

            await _tarjetaService.ReiniciarIntentosFallidosAsync(tarjetaDto.Id, cancellationToken);

            var identityDto = tarjetaDto.MapToIdentityDto();

            var token = GenerateToken(identityDto);

            return token;
        }

        private string GenerateToken(IdentityDto identityDto)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]!);
            var tokenLifetime = TimeSpan.FromSeconds(Convert.ToInt32(_configuration["JwtSettings:LifetimeSeconds"]));

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(ClaimNames.IdTarjeta, identityDto.Id.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(tokenLifetime),
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var jwt = tokenHandler.WriteToken(token);

            return jwt;
        }
    }
}
