using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecdisa.OS.Application.ViewModel
{
    public class PagedViewModel<T> where T : class
    {
        public IEnumerable<T> Lista { get; set; }
        public int Count { get; set; }
    }
}
