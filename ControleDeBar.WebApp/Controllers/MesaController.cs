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

        var listarMesasVm = mesas
            .Select(m => new ListarMesaViewModel
            {
                Id = m.Id,
                Numero = m.Numero,
                Ocupada = m.Ocupada ? "Ocupada" : "Livre"
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
        {
            return View(inserirMesaVm);
        }
        
        var db = new ControleDeBarDbContext();
        var repositorioMesa = new RepositorioMesaEmOrm(db);

        var mesa = new Mesa(inserirMesaVm.Numero);
        
        repositorioMesa.Inserir(mesa);

        HttpContext.Response.StatusCode = 201;
        
        var notificacaoVm = new NotificacaoViewModel
        {
            Mensagem = $"O registro com o ID [{mesa.Id}] foi cadastrado com sucesso!",
            LinkRedirecionamento =  "/mesa/listar"
        };

        return View("mensagens", notificacaoVm);
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
        {
            return View(editarMesaVm);
        }
        
        var db = new ControleDeBarDbContext();
        var repositorioMesa = new RepositorioMesaEmOrm(db);

        var mesaOriginal = repositorioMesa.SelecionarPorId(editarMesaVm.Id);

        mesaOriginal.Numero = editarMesaVm.Numero;
        mesaOriginal.Ocupada = editarMesaVm.Ocupada;
        
        repositorioMesa.Editar(mesaOriginal);

        var notificacaoVm = new NotificacaoViewModel
        {
            Mensagem = $"O registro com o ID [{mesaOriginal.Id}] foi editado com sucesso!",
            LinkRedirecionamento =  "/mesa/listar"
        };

        return View("mensagens", notificacaoVm);
    }

    public ViewResult Excluir(int id)
    {
        var db = new ControleDeBarDbContext();
        var repositorioMesa = new RepositorioMesaEmOrm(db);

        var mesa = repositorioMesa.SelecionarPorId(id);

        var excluirMesaVm = new ExcluirMesaViewModel()
        {
            Id = mesa.Id,
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

        var notificacaoVm = new NotificacaoViewModel
        {
            Mensagem = $"O registro com o ID [{mesa.Id}] foi excluído com sucesso!",
            LinkRedirecionamento =  "/mesa/listar"
        };

        return View("mensagens", notificacaoVm);
    }

    public ViewResult Detalhes(int id)
    {
        var db = new ControleDeBarDbContext();
        var repositorioMesa = new RepositorioMesaEmOrm(db);

        var mesa = repositorioMesa.SelecionarPorId(id);

        var detalhesMesaVm = new DetalhesMesaViewModel()
        {
            Id = mesa.Id,
            Numero = mesa.Numero,
            Ocupada = mesa.Ocupada ? "Ocupada" : "Livre",
            Contas = mesa.Contas
                .Select(c => new ListarContaMesaViewModel { Titular = c.Titular })
        };

        return View(detalhesMesaVm);
    }
}
