using System.Linq;
using System.Web.Mvc;
using PaginacaoByGoogle.Models;

namespace PaginacaoByGoogle.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(int? pagina)
        {
            //Gera uma quantidade X de items
            var items = Enumerable.Range(1, 150).Select(x => "Item " + x);

            //Efetua a paginação dos items
            var paginador = new Paginador(items.Count(), pagina);


            var viewModel = new PaginadorViewModel
            {
                Items = items.Skip((paginador.PaginaAtual - 1) * (paginador.ItemsPorPagina))
                .Take(paginador.ItemsPorPagina),
                Paginador = paginador
            };

            return View(viewModel);
        }

       
    }
}