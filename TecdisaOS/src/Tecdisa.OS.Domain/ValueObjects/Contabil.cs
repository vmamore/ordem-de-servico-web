namespace Tecdisa.OS.Domain.ValueObjects
{
    public class Contabil : Usuario
    {
        public Contabil()
        {
            Cargo = CARGO.Contabil;
        }

        public string Email { get; set; }
    }
}
