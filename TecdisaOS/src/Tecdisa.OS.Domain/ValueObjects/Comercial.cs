﻿namespace Tecdisa.OS.Domain.ValueObjects
{
    public class Comercial : Usuario
    {
        public Comercial()
        {
            this.Cargo = CARGO.Comercial;
        }

        public string Email { get; set; }
    }
}
