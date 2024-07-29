using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Infra.Orm.ModuloProduto;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers;

public class ProdutoController : Controller
{
    public ViewResult Listar()
    {
        var db = new ControleDeBarDbContext();
        var repositorioProduto = new RepositorioProdutoEmOrm(db);

        var produtos = repositorioProduto.SelecionarTodos();

        var listarProdutosVm = produtos
            .Select(p => new ListarProdutoViewModel { Id = p.Id, Nome = p.Nome, Valor = p.Valor });

        return View(listarProdutosVm);
    }

    public ViewResult Inserir()
    {
        return View();
    }

    [HttpPost]
    public ViewResult Inserir(InserirProdutoViewModel inserirProdutoVm)
    {
        if (!ModelState.IsValid)
            return View(inserirProdutoVm);
        
        var db = new ControleDeBarDbContext();
        var repositorioProduto = new RepositorioProdutoEmOrm(db);

        var produto = new Produto(inserirProdutoVm.Nome, inserirProdutoVm.Valor);

        repositorioProduto.Inserir(produto);

        var notificacaoVm = new NotificacaoViewModel
        {
            Mensagem = $"O registro com o ID [{produto.Id}] foi inserido com sucesso!",
            LinkRedirecionamento =  "/produto/listar"
        };
        HttpContext.Response.StatusCode = 201;

        return View("mensagens", notificacaoVm);
    }

    public ViewResult Editar(int id)
    {
        var db = new ControleDeBarDbContext();
        var repositorioProduto = new RepositorioProdutoEmOrm(db);

        var produto = repositorioProduto.SelecionarPorId(id);

        var editarProdutoVm = new EditarProdutoViewModel
        {
            Id = id,
            Nome = produto.Nome,
            Valor = produto.Valor
        };

        return View(editarProdutoVm);
    }

    [HttpPost]
    public ViewResult Editar(EditarProdutoViewModel editarProdutoVm)
    {
        if (!ModelState.IsValid)
            return View(editarProdutoVm);
        
        var db = new ControleDeBarDbContext();
        var repositorioProduto = new RepositorioProdutoEmOrm(db);

        var produtoOriginal = repositorioProduto.SelecionarPorId(editarProdutoVm.Id);

        produtoOriginal.Nome = editarProdutoVm.Nome;
        produtoOriginal.Valor = editarProdutoVm.Valor;
        
        repositorioProduto.Editar(produtoOriginal);

        var notificacaoVm = new NotificacaoViewModel
        {
            Mensagem = $"O registro com o ID [{produtoOriginal.Id}] foi editado com sucesso!",
            LinkRedirecionamento =  "/produto/listar"
        };

        return View("mensagens", notificacaoVm);
    }

    public ViewResult Excluir(int id)
    {
        var db = new ControleDeBarDbContext();
        var repositorioProduto = new RepositorioProdutoEmOrm(db);

        var produto = repositorioProduto.SelecionarPorId(id);

        var excluirProdutoVm = new ExcluirProdutoViewModel
        {
            Id = id,
            Nome = produto.Nome,
            Valor = produto.Valor
        };

        return View(excluirProdutoVm);
    }

    [HttpPost, ActionName("excluir")]
    public ViewResult ExcluirConfirmado(ExcluirProdutoViewModel excluirProdutoVm)
    {
        var db = new ControleDeBarDbContext();
        var repositorioProduto = new RepositorioProdutoEmOrm(db);

        var produto = repositorioProduto.SelecionarPorId(excluirProdutoVm.Id);

        repositorioProduto.Excluir(produto);

        var notificacaoVm = new NotificacaoViewModel
        {
            Mensagem = $"O registro com o ID [{produto.Id}] foi excluído com sucesso!",
            LinkRedirecionamento =  "/produto/listar"
        };

        return View("mensagens", notificacaoVm);
    }

    public ViewResult Detalhes(int id)
    {
        var db = new ControleDeBarDbContext();
        var repositorioProduto = new RepositorioProdutoEmOrm(db);

        var produto = repositorioProduto.SelecionarPorId(id);

        var detalhesProdutoVm = new DetalhesProdutoViewModel
        {
            Id = id,
            Nome = produto.Nome,
            Valor = produto.Valor
        };

        return View(detalhesProdutoVm);
    }
}