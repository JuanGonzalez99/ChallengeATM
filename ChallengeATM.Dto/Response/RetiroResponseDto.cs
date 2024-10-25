namespace ChallengeATM.Dto.Response
{
    /// <summary>
    /// Resumen del retiro realizado
    /// </summary>
    public class RetiroResponseDto
    {
        /// <summary>
        /// Número de tarjeta con el que se produjo el retiro
        /// </summary>
        public string NumeroTarjeta { get; set; }

        /// <summary>
        /// Saldo de la cuenta anterior al retiro
        /// </summary>
        public decimal SaldoAnterior { get; set; }

        /// <summary>
        /// Monto retirado
        /// </summary>
        public decimal Monto { get; set; }

        /// <summary>
        /// Saldo de la cuenta posterior al retiro
        /// </summary>
        public decimal SaldoPosterior { get; set; }

        /// <summary>
        /// Fecha del retiro
        /// </summary>
        public DateTime FechaHoraCreacion { get; set; }
    }
}
