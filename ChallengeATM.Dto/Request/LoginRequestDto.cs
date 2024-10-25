using System.ComponentModel.DataAnnotations;

namespace ChallengeATM.Dto.Request
{
    /// <summary>
    /// Información requerida para iniciar sesión
    /// </summary>
    public class LoginRequestDto
    {
        /// <summary>
        /// Identificador de la tarjeta
        /// </summary>
        [Required]
        public string NumeroTarjeta { get; set; }

        /// <summary>
        /// Clave de la tarjeta
        /// </summary>
        [Required]
        public string Pin { get; set; }
    }
}
