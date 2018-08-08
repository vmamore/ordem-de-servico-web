namespace Tecdisa.OS.Domain.ValueObjects
{
    public class Financeiro : Usuario
    {
        public Financeiro()
        {
            this.Cargo = CARGO.Financeiro;
        }

        public string Email { get; set; }
    }
}
