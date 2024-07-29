using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Infra.Orm.ModuloConta;
using ControleDeBar.Infra.Orm.ModuloGarcom;
using ControleDeBar.Infra.Orm.ModuloMesa;
using ControleDeBar.Infra.Orm.ModuloProduto;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

            var mesas = repositorioMesa
                .SelecionarTodos()
                .Select(x => new SelectListItem(x.Numero, x.Id.ToString()));
            
            var garcons = repositorioGarcom
                .SelecionarTodos()
                .Select(x => new SelectListItem(x.Nome, x.Id.ToString()));

            var abrirContaVm = new AbrirContaViewModel
            {
                Mesas = mesas.ToList(),
                Garcons = garcons.ToList()
            };

            return View(abrirContaVm);
        }

        [HttpPost]
        public ViewResult Abrir(AbrirContaViewModel abrirContaVm)
        {
            var db = new ControleDeBarDbContext();
            var repositorioConta = new RepositorioContaEmOrm(db);
            var repositorioMesa = new RepositorioMesaEmOrm(db);
            var repositoriogarcom = new RepositorioGarcomEmOrm(db);

            var mesa = repositorioMesa.SelecionarPorId(abrirContaVm.IdMesa);
            var garcom = repositoriogarcom.SelecionarPorId(abrirContaVm.IdGarcom);

            var conta = new Conta(abrirContaVm.Titular, mesa, garcom);

            repositorioConta.Inserir(conta);

            var notificacaoVm = new NotificacaoViewModel
            {
                Mensagem = $"O registro com o ID [{conta.Id}] foi cadastrado com sucesso!",
                LinkRedirecionamento =  "/conta/listar"
            };

            return View("mensagens", notificacaoVm);
        }

        [HttpGet, ActionName("gerenciar-pedidos")]
        [Route("/conta/{id:int}/gerenciar-pedidos")]
        public ViewResult GerenciarPedidos(int id)
        {
            var db = new ControleDeBarDbContext();

            var repositorioProduto = new RepositorioProdutoEmOrm(db);
            var repositorioConta = new RepositorioContaEmOrm(db);

            ViewBag.Produtos = repositorioProduto.SelecionarTodos();
            ViewBag.Conta = repositorioConta.SelecionarPorId(id);

            return View();
        }

        [HttpPost]
        [Route("/conta/{id:int}/adicionar-pedido")]
        public ViewResult AdicionarPedido(int id, int idProduto, int quantidadeSolicitada)
        {
            var db = new ControleDeBarDbContext();

            var repositorioProduto = new RepositorioProdutoEmOrm(db);
            var repositorioConta = new RepositorioContaEmOrm(db);

            var contaSelecionada = repositorioConta.SelecionarPorId(id);
            var produtoSelecionado = repositorioProduto.SelecionarPorId(idProduto);

            contaSelecionada.RegistrarPedido(produtoSelecionado, quantidadeSolicitada);

            repositorioConta.AtualizarPedidos(contaSelecionada, []);

            var produtos = repositorioProduto.SelecionarTodos();

            ViewBag.Produtos = produtos;
            ViewBag.Conta = contaSelecionada;

            return View("gerenciar-pedidos");
        }

        [HttpPost]
        [Route("/conta/{id:int}/remover-pedido/{pedidoId:int}")]
        public ViewResult RemoverPedido(int id, int pedidoId)
        {
            var db = new ControleDeBarDbContext();

            var repositorioProduto = new RepositorioProdutoEmOrm(db);
            var repositorioConta = new RepositorioContaEmOrm(db);

            var conta = repositorioConta.SelecionarPorId(id);

            var pedidoRemovido = conta.RemoverPedido(pedidoId);

            repositorioConta.AtualizarPedidos(conta, [pedidoRemovido]);

            var produtos = repositorioProduto.SelecionarTodos();

            ViewBag.Conta = conta;
            ViewBag.Produtos = produtos;

            return View("gerenciar-pedidos");
        }

        [HttpGet, Route("/conta/{id:int}/fechar")]
        public ViewResult Fechar(int id)
        {
            var db = new ControleDeBarDbContext();
            var repositorioConta = new RepositorioContaEmOrm(db);

            var conta = repositorioConta.SelecionarPorId(id);

            ViewBag.Conta = conta;

            return View();
        }

        [HttpPost, Route("/conta/{id:int}/fechar")]
        public ViewResult FecharConfirmado(int id)
        {
            var db = new ControleDeBarDbContext();
            var repositorioConta = new RepositorioContaEmOrm(db);

            var contaSelecionada = repositorioConta.SelecionarPorId(id);

            contaSelecionada.Fechar();

            repositorioConta.AtualizarStatus(contaSelecionada);

            ViewBag.Mensagem = $"A conta com o ID {contaSelecionada.Id} foi fechada com sucesso!";
            ViewBag.Link = "/conta/listar";

            return View("mensagens");
        }
    }
}
