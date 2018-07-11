namespace Tecdisa.OS.Domain.ValueObjects
{
    public enum CARGO
    {
        Comercial,
        Expedicao,
        Financeiro,
        Faturista,
        TI,
        Contabil
    }

    public abstract class Usuario
    {
        public string Nome { get; set; }
        public CARGO Cargo { get; set; }
    }
}
