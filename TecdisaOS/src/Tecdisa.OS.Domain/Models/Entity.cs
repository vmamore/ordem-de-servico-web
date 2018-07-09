using System;

namespace Tecdisa.OS.Domain.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public abstract bool EhValido();
    }
}
