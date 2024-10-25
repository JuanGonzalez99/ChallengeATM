namespace ChallengeATM.Dto.Response
{
    /// <summary>
    /// Información relacionada con una tarjeta
    /// </summary>
    public class SaldoResponseDto
    {
        /// <summary>
        /// Nombre del usuario dueño de la tarjeta
        /// </summary>
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Número de cuenta a la que pertenece la tarjeta
        /// </summary>
        public string NumeroCuenta { get; set; }

        /// <summary>
        /// Saldo de la cuenta a la que pertenece la tarjeta
        /// </summary>
        public decimal SaldoActual { get; set; }

        /// <summary>
        /// Fecha de la última extracción que se produjo con la tarjeta
        /// </summary>
        public DateTime? FechaUltimaExtraccion { get; set; }
    }
}
