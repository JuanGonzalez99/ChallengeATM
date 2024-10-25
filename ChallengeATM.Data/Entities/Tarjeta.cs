namespace ChallengeATM.Data.Entities
{
    public class Tarjeta
    {
        public int Id { get; set; }
        public string NumeroTarjeta { get; set; }
        public string Pin { get; set; }
        public int CuentaId { get; set; }
        public Cuenta? Cuenta { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public DateTime? FechaUltimaExtraccion { get; set; }
        public int IntentosFallidos { get; set; }
        public bool EstaBloqueada { get; set; }
    }
}
