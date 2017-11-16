using System.Collections.Generic;

namespace PaginacaoByGoogle.Models
{
    public sealed class PaginadorViewModel
    {
        public IEnumerable<string> Items { get; set; }
        public Paginador Paginador { get; set; }
    }
}