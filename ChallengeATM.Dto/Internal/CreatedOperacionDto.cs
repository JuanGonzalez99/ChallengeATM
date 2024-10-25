namespace ChallengeATM.Dto.Internal
{
    public class CreatedOperacionDto
    {
        public int Id { get; set; }
        public int TarjetaId { get; set; }
        public string TipoOperacionCodigo { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public decimal SaldoAnterior { get; set; }
        public decimal Monto { get; set; }
        public decimal SaldoPosterior { get; set; }
    }
}
