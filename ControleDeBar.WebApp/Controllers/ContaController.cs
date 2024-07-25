using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Infra.Orm.ModuloConta;
using ControleDeBar.Infra.Orm.ModuloGarcom;
using ControleDeBar.Infra.Orm.ModuloMesa;
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

        public ViewResult Abrir()
        {
            var db = new ControleDeBarDbContext();

            var repositorioMesa = new RepositorioMesaEmOrm(db);
            var repositorioGarcom = new RepositorioGarcomEmOrm(db);

            var mesas = repositorioMesa.SelecionarTodos();
            var garcons = repositorioGarcom.SelecionarTodos();

            ViewBag.Mesas = mesas;
            ViewBag.Garcons = garcons;

            return View();
        }

        [HttpPost]
        public ViewResult Abrir(string titular, int idMesa, int idGarcom)
        {
            var db = new ControleDeBarDbContext();
            var repositorioConta = new RepositorioContaEmOrm(db);
            var repositorioMesa = new RepositorioMesaEmOrm(db);
            var repositoriogarcom = new RepositorioGarcomEmOrm(db);

            var mesa = repositorioMesa.SelecionarPorId(idMesa);
            var garcom = repositoriogarcom.SelecionarPorId(idGarcom);

            var conta = new Conta(titular, mesa, garcom);

            repositorioConta.Inserir(conta);

            ViewBag.Mensagem = $"O registro com o ID [{conta.Id}] foi cadastrado com sucesso!";
            ViewBag.Link = "/conta/listar";

            return View("mensagens");
        }
    }
}
