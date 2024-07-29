using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Infra.Orm.ModuloConta;
using ControleDeBar.Infra.Orm.ModuloGarcom;
using ControleDeBar.Infra.Orm.ModuloMesa;
using ControleDeBar.Infra.Orm.ModuloProduto;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleDeBar.WebApp.Controllers;

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

        var listarContasVm = contas
            .Select(MapearListarContaViewModel);

        return View(listarContasVm);
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

        var abrirContaVm = MapearAbrirContaViewModel(mesas, garcons);

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

        var novaConta = new Conta(abrirContaVm.Titular, mesa, garcom);

        repositorioConta.Inserir(novaConta);

        var notificacaoVm = new NotificacaoViewModel
        {
            Mensagem = $"A conta com o ID [{novaConta.Id}] foi aberta com sucesso!",
            LinkRedirecionamento = "/conta/listar"
        };

        return View("mensagens", notificacaoVm);
    }
        
    [HttpGet, Route("/conta/{id:int}/fechar")]
    public ViewResult Fechar(int id)
    {
        var db = new ControleDeBarDbContext();
        var repositorioConta = new RepositorioContaEmOrm(db);

        var conta = repositorioConta.SelecionarPorId(id);

        var fecharContaVm = MapearFecharContaViewModel(conta);

        return View(fecharContaVm);
    }

    [HttpPost]
    public ViewResult FecharConfirmado(FecharContaViewModel fecharContaVm)
    {
        var db = new ControleDeBarDbContext();
        var repositorioConta = new RepositorioContaEmOrm(db);

        var contaSelecionada = repositorioConta.SelecionarPorId(fecharContaVm.Id);

        contaSelecionada.Fechar();

        repositorioConta.AtualizarStatus(contaSelecionada);

        var notificacaoVm = new NotificacaoViewModel
        {
            Mensagem = $"A conta com o ID [{contaSelecionada.Id}] foi fechada com sucesso!",
            LinkRedirecionamento = "/conta/listar"
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
    
    private static ListarContaViewModel MapearListarContaViewModel(Conta c)
    {
        return new ListarContaViewModel
        {
            Id = c.Id,
            Titular = c.Titular,
            Mesa = c.Mesa.Numero,
            Garcom = c.Garcom.Nome,
            EstaAberta = c.EstaAberta ? "Aberta" : "Fechada",
            Abertura = c.Abertura,
            Fechamento = c.Fechamento,
            Pedidos = c.Pedidos.Select(p =>
            {
                return new PedidoContaViewModel
                {
                    Id = p.Id,
                    Produto = p.Produto.Nome,
                    QuantidadeSolicitada = p.QuantidadeSolicitada,
                    TotalParcial = p.CalcularTotalParcial()
                };
            })
        };
    }
    
    private static AbrirContaViewModel MapearAbrirContaViewModel(IEnumerable<SelectListItem> mesas, IEnumerable<SelectListItem> garcons)
    {
        return new AbrirContaViewModel
        {
            Mesas = mesas.ToList(),
            Garcons = garcons.ToList()
        };
    }
    
    private static FecharContaViewModel MapearFecharContaViewModel(Conta conta)
    {
        return new FecharContaViewModel
        {
            Id = conta.Id,
            Titular = conta.Titular,
            Mesa = conta.Mesa.Numero,
            Garcom = conta.Garcom.Nome,
            ValorTotal = conta.CalcularValorTotal(),
            Pedidos = conta.Pedidos.Select(p =>
            {
                return new PedidoContaViewModel
                {
                    Id = p.Id,
                    Produto = p.Produto.Nome,
                    QuantidadeSolicitada = p.QuantidadeSolicitada,
                    TotalParcial = p.CalcularTotalParcial()
                };
            })
        };
    }
}