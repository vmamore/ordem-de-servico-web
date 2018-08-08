using System.Collections.Generic;

namespace Tecdisa.OS.Domain.DTO
{
    public class Paged<T> where T : class
    {
        public IEnumerable<T> Lista { get; set; }
        public int Count { get; set; }
    }
}
