namespace Tecdisa.OS.Domain.ValueObjects
{
    public enum CARGO
    {
        Comercial,
        Expedicao,
        Financeiro,
        Faturista,
        TI
    }

    public abstract class Usuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public CARGO Cargo { get; set; }
    }
}
