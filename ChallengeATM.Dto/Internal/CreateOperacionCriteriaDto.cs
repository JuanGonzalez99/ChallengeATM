namespace ChallengeATM.Dto.Internal
{
    public class CreateOperacionCriteriaDto
    {
        public int TarjetaId { get; set; }
        public decimal SaldoAnterior { get; set; }
        public decimal Monto { get; set; }
    }
}
