namespace ChallengeATM.Dto.Response
{
    /// <summary>
    /// Resumen de la operación
    /// </summary>
    public class OperacionResponseDto
    {
        /// <summary>
        /// Número de tarjeta en el que se produjo la operación
        /// </summary>
        public string NumeroTarjeta { get; set; }

        /// <summary>
        /// Tipo de operación realizada ('E': extracción, 'I': ingreso)
        /// </summary>
        public string TipoOperacion { get; set; }

        /// <summary>
        /// Saldo de la cuenta anterior a la operación
        /// </summary>
        public decimal SaldoAnterior { get; set; }

        /// <summary>
        /// Monto la operación
        /// </summary>
        public decimal Monto { get; set; }

        /// <summary>
        /// Saldo de la cuenta anterior a la operación
        /// </summary>
        public decimal SaldoPosterior { get; set; }

        /// <summary>
        /// Fecha de la operación
        /// </summary>
        public DateTime FechaHoraCreacion { get; set; }
    }
}
