using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{

    public sealed class IndexViewModel
    {
        public IEnumerable<string> Items { get; set; }
        public Paginador Paginador { get; set; }
    }

    /// <summary>
    /// Efetua a Paginação dos items
    /// </summary>
    public sealed class Paginador
    {
        public Paginador(int qtdRegistros, int? pagina, int qtdPagina = 10)
        {
            EfetuaPaginacao(qtdRegistros, pagina, qtdPagina);
        }

        public int TotalRegistros { get; private set; }
        public int PaginaAtual { get; private set; }
        public int ItemsPorPagina { get; private set; }
        public int TotalPaginas { get; private set; }
        public int PrimeiraPagina { get; private set; }
        public int UltimaPagina { get; private set; }

        private void EfetuaPaginacao(int qtdRegistros, int? pagina, int qtdPagina = 10)
        {
            var totalPaginas = (int)Math.Ceiling((decimal) qtdRegistros / qtdPagina);
            var paginaAtual = pagina != null ? (int)pagina : 1;
            var primeiraPagina = paginaAtual - 5;
            var ultimaPagina = paginaAtual + 4;

            if (primeiraPagina <= 0)
            {
                ultimaPagina -= (primeiraPagina--);
                primeiraPagina = 1;
            }
            if (ultimaPagina > totalPaginas)
            {
                ultimaPagina = totalPaginas;

                if (ultimaPagina > 10)
                {
                    primeiraPagina = ultimaPagina - 9;
                }
            }

            TotalRegistros = qtdRegistros;
            PaginaAtual = paginaAtual;
            ItemsPorPagina = qtdPagina;
            TotalPaginas = totalPaginas;
            PrimeiraPagina = primeiraPagina;
            UltimaPagina = ultimaPagina;
        }
    }
}
