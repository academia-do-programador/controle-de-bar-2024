using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Infra.Orm.ModuloConta;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers
{
    public class ContaController : Controller
    {
        public ViewResult Listar(TipoFiltroContaEnum status)
        {
            var db = new ControleDeBarDbContext();
            var repositorioConta = new RepositorioContaEmOrm(db);

            var contas = status switch
            {
                TipoFiltroContaEnum.Abertas => repositorioConta.SelecionarContasEmAberto(),
                TipoFiltroContaEnum.Fechadas => repositorioConta.SelecionarContasFechadas(),
                _ => repositorioConta.SelecionarContas()
            };

            ViewBag.Contas = contas;

            return View();
        }
    }
}
