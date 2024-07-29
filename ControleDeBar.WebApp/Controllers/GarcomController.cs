using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Infra.Orm.ModuloGarcom;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers;

public class GarcomController : Controller
{
    public ViewResult Listar()
    {
        var dbContext = new ControleDeBarDbContext();
        var repositorioGarcom = new RepositorioGarcomEmOrm(dbContext);

        var garcons = repositorioGarcom.SelecionarTodos();

        var listarGarconsVm = garcons
            .Select(g => new ListarGarcomViewModel { Id = g.Id, Nome = g.Nome, CPF = g.CPF });

        return View(listarGarconsVm);
    }

    public ViewResult Inserir()
    {
        return View();
    }

    [HttpPost]
    public ViewResult Inserir(InserirGarcomViewModel inserirGarcomVm)
    {
        if (!ModelState.IsValid)
            return View(inserirGarcomVm);
        
        var db = new ControleDeBarDbContext();
        var repositorioGarcom = new RepositorioGarcomEmOrm(db);

        var garcom = new Garcom(inserirGarcomVm.Nome, inserirGarcomVm.CPF);

        repositorioGarcom.Inserir(garcom);

        HttpContext.Response.StatusCode = 201;
        
        var notificacaoVm = new NotificacaoViewModel
        {
            Mensagem = $"O registro com o ID [{garcom.Id}] foi excluído com sucesso!",
            LinkRedirecionamento =  "/garcom/listar"
        };

        return View("mensagens", notificacaoVm);
    }

    public ViewResult Editar(int id)
    {
        var db = new ControleDeBarDbContext();
        var repositorioGarcom = new RepositorioGarcomEmOrm(db);

        var garcomOriginal = repositorioGarcom.SelecionarPorId(id);

        var editarGarcomVm = new EditarGarcomViewModel
        {
            Id = id,
            Nome = garcomOriginal.Nome,
            CPF = garcomOriginal.CPF
        };

        return View(editarGarcomVm);
    }

    [HttpPost]
    public ViewResult Editar(EditarGarcomViewModel editarGarcomVm)
    {
        if (!ModelState.IsValid)
            return View(editarGarcomVm);
        
        var db = new ControleDeBarDbContext();
        var repositorioGarcom = new RepositorioGarcomEmOrm(db);

        var garcomOriginal = repositorioGarcom.SelecionarPorId(editarGarcomVm.Id);

        repositorioGarcom.Editar(garcomOriginal);

        var notificacaoVm = new NotificacaoViewModel
        {
            Mensagem = $"O registro com o ID [{garcomOriginal.Id}] foi excluído com sucesso!",
            LinkRedirecionamento =  "/garcom/listar"
        };

        return View("mensagens", notificacaoVm);
    }

    public ViewResult Excluir(int id)
    {
        var db = new ControleDeBarDbContext();
        var repositorioGarcom = new RepositorioGarcomEmOrm(db);

        var garcomParaExcluir = repositorioGarcom.SelecionarPorId(id);

        var excluirGarcomVm = new ExcluirGarcomViewModel
        {
            Id = id,
            Nome = garcomParaExcluir.Nome,
            CPF = garcomParaExcluir.CPF
        };

        return View(excluirGarcomVm);
    }

    [HttpPost, ActionName("excluir")]
    public ViewResult ExcluirConfirmado(ExcluirGarcomViewModel excluirGarcomVm)
    {
        var db = new ControleDeBarDbContext();
        var repositorioGarcom = new RepositorioGarcomEmOrm(db);

        var garcomParaExcluir = repositorioGarcom.SelecionarPorId(excluirGarcomVm.Id);

        repositorioGarcom.Excluir(garcomParaExcluir);

        var notificacaoVm = new NotificacaoViewModel
        {
            Mensagem = $"O registro com o ID [{garcomParaExcluir.Id}] foi excluído com sucesso!",
            LinkRedirecionamento =  "/garcom/listar"
        };

        return View("mensagens", notificacaoVm);
    }

    public ViewResult Detalhes(int id)
    {
        var db = new ControleDeBarDbContext();
        var repositorioGarcom = new RepositorioGarcomEmOrm(db);

        var garcomOriginal = repositorioGarcom.SelecionarPorId(id);

        var detalhesGarcomVm = new DetalhesGarcomViewModel
        {
            Id = id,
            Nome = garcomOriginal.Nome,
            CPF = garcomOriginal.CPF
        };

        return View(detalhesGarcomVm);
    }
}
