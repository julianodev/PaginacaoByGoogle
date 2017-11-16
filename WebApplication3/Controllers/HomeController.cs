using System.Linq;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(int? pagina)
        {
            //Gera uma quantidade X de items
            var items = Enumerable.Range(1, 150).Select(x => "Item " + x);

            //Efetua a paginação dos itens
            var paginador = new Paginador(items.Count(), pagina);


            var viewModel = new IndexViewModel
            {
                Items = items.Skip((paginador.PaginaAtual - 1) * (paginador.ItemsPorPagina))
                .Take(paginador.ItemsPorPagina),
                Paginador = paginador
            };

            return View(viewModel);
        }

       
    }
}