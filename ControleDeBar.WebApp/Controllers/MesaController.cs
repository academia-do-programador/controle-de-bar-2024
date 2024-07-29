using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Infra.Orm.ModuloMesa;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers;

public class MesaController : Controller
{
    public ViewResult Listar()
    {
        var db = new ControleDeBarDbContext();
        var repositorioMesa = new RepositorioMesaEmOrm(db);

        var mesas = repositorioMesa.SelecionarTodos();

        var listarMesasVm = mesas // mapeamento
            .Select(m =>
            {
                return new ListarMesaViewModel
                {
                    Id = m.Id,
                    Numero = m.Numero,
                    Ocupada = m.Ocupada ? "Ocupada" : "Livre"
                };
            });

        return View(listarMesasVm);
    }

    public ViewResult Inserir()
    {
        return View();
    }

    [HttpPost]
    public ViewResult Inserir(InserirMesaViewModel inserirMesaVm)
    {
        if (!ModelState.IsValid)
            return View(inserirMesaVm);

        var db = new ControleDeBarDbContext();
        var repositorioMesa = new RepositorioMesaEmOrm(db);

        var novaMesa = new Mesa(inserirMesaVm.Numero);

        repositorioMesa.Inserir(novaMesa);

        HttpContext.Response.StatusCode = 201;

        var mensagem = new MensagemViewModel()
        {
            Mensagem = $"O registro com o ID {novaMesa.Id} foi cadastrado com sucesso!",
            LinkRedirecionamento = "/mesa/listar"
        };

        return View("mensagens", mensagem);
    }

    public ViewResult Editar(int id)
    {
        var db = new ControleDeBarDbContext();
        var repositorioMesa = new RepositorioMesaEmOrm(db);

        var mesa = repositorioMesa.SelecionarPorId(id);

        var editarMesaVm = new EditarMesaViewModel
        {
            Id = id,
            Numero = mesa.Numero,
            Ocupada = mesa.Ocupada
        };

        return View(editarMesaVm);
    }

    [HttpPost]
    public ViewResult Editar(EditarMesaViewModel editarMesaVm)
    {
        if (!ModelState.IsValid)
            return View(editarMesaVm);

        var db = new ControleDeBarDbContext();
        var repositorioMesa = new RepositorioMesaEmOrm(db);

        var mesaOriginal = repositorioMesa.SelecionarPorId(editarMesaVm.Id);

        mesaOriginal.Numero = editarMesaVm.Numero;
        mesaOriginal.Ocupada = editarMesaVm.Ocupada;

        repositorioMesa.Editar(mesaOriginal);

        var mensagem = new MensagemViewModel()
        {
            Mensagem = $"O registro com o ID {mesaOriginal.Id} foi editado com sucesso!",
            LinkRedirecionamento = "/mesa/listar"
        };

        return View("mensagens", mensagem);
    }

    public ViewResult Excluir(int id)
    {
        var db = new ControleDeBarDbContext();
        var repositorioMesa = new RepositorioMesaEmOrm(db);

        var mesa = repositorioMesa.SelecionarPorId(id);

        var excluirMesaVm = new ExcluirMesaViewModel
        {
            Id = id,
            Numero = mesa.Numero,
            Ocupada = mesa.Ocupada ? "Ocupada" : "Livre",
            Contas = mesa.Contas
                .Select(c => new ListarContaMesaViewModel { Titular = c.Titular })
        };

        return View(excluirMesaVm);
    }

    [HttpPost, ActionName("excluir")]
    public ViewResult ExcluirConfirmado(ExcluirMesaViewModel excluirMesaVm)
    {
        var db = new ControleDeBarDbContext();
        var repositorioMesa = new RepositorioMesaEmOrm(db);

        var mesa = repositorioMesa.SelecionarPorId(excluirMesaVm.Id);

        repositorioMesa.Excluir(mesa);

        var mensagem = new MensagemViewModel()
        {
            Mensagem = $"O registro com o ID {mesa.Id} foi excluído com sucesso!",
            LinkRedirecionamento = "/mesa/listar"
        };

        return View("mensagens", mensagem);
    }

    public ViewResult Detalhes(int id)
    {
        var db = new ControleDeBarDbContext();
        var repositorioMesa = new RepositorioMesaEmOrm(db);

        var mesa = repositorioMesa.SelecionarPorId(id);

        var detalhesMesaVm = new DetalhesMesaViewModel
        {
            Id = id,
            Numero = mesa.Numero,
            Ocupada = mesa.Ocupada ? "Ocupada" : "Livre",
            Contas = mesa.Contas
                .Select(c => new ListarContaMesaViewModel { Titular = c.Titular })
        };

        return View(detalhesMesaVm);
    }
}
