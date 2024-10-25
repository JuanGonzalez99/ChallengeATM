using ChallengeATM.Dto.Internal;

namespace ChallengeATM.Business.Mappers.Dto
{
    public static class TarjetaDtoExtensions
    {
        public static IdentityDto MapToIdentityDto(this TarjetaDto tarjetaDto) => new()
        {
            Id = tarjetaDto.Id
        };
    }
}
