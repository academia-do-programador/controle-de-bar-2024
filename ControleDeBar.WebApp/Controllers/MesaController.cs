using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Infra.Orm.ModuloMesa;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ControleDeBar.WebApp.Controllers;

public class MesaController : Controller
{
    [HttpGet, ActionName("listar")]
    public ViewResult ListarMesas()
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

        List<Mesa> mesas = repositorioMesa.SelecionarTodos();

        ViewBag.Mesas = mesas;

        return View("listar-mesas");
    }

    [HttpGet, ActionName("inserir")]
    public Task ExibirFormularioInserirMesa()
    {
        string form = System.IO.File.ReadAllText("Html/inserir-mesa-form.html");

        return HttpContext.Response.WriteAsync(form);
    }

    [HttpPost, ActionName("inserir")]
    public Task InserirMesa(Mesa novaMesa) // data binding
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

        repositorioMesa.Inserir(novaMesa);

        HttpContext.Response.StatusCode = 201;

        string html = System.IO.File.ReadAllText("Html/mensagens-mesa.html");

        html = html.Replace("#mensagem#", $"A mesa \"{novaMesa.Id}\" foi cadastrada com sucesso!");

        return HttpContext.Response.WriteAsync(html);
    }

    [HttpGet, ActionName("editar")]
    public Task ExibirFormularioEditarMesa(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

        Mesa mesa = repositorioMesa.SelecionarPorId(id);

        string html = System.IO.File.ReadAllText("Html/editar-mesa-form.html");

        html = html.Replace("#id#", mesa.Id.ToString());

        html = html.Replace("#numero#", mesa.Numero.ToString());

        if (mesa.Ocupada)
            html = html.Replace("<input name=\"ocupada\" type=\"checkbox\" />", "<input name=\"ocupada\" type=\"checkbox\" checked/>");

        return HttpContext.Response.WriteAsync(html);
    }

    [HttpPost, ActionName("editar")]
    public Task EditarMesa(int id, Mesa mesaAtualizada)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

        Mesa mesaOriginal = repositorioMesa.SelecionarPorId(id);

        mesaAtualizada.Ocupada =
            HttpContext.Request.Form["ocupada"] == "on";

        repositorioMesa.Editar(mesaOriginal, mesaAtualizada);

        string html = System.IO.File.ReadAllText("Html/mensagens-mesa.html");

        html = html.Replace("#mensagem#", $"A mesa id \"{mesaOriginal.Id}\" foi atualizada!");

        return HttpContext.Response.WriteAsync(html);
    }

    [HttpGet, ActionName("excluir")]
    public Task ExibirFormularioExcluirMesa(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

        Mesa mesa = repositorioMesa.SelecionarPorId(id);

        string html = System.IO.File.ReadAllText("Html/excluir-mesa-form.html");

        StringBuilder sb = new StringBuilder(html);

        sb.Replace("#numeromesa#", mesa.Numero);

        sb.Replace("#id#", mesa.Id.ToString());

        return HttpContext.Response.WriteAsync(sb.ToString());
    }


    [HttpPost, ActionName("excluir")]
    public Task ExcluirMesa(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

        Mesa mesa = repositorioMesa.SelecionarPorId(id);

        repositorioMesa.Excluir(mesa);

        string html = System.IO.File.ReadAllText("Html/mensagens-mesa.html");

        StringBuilder sb = new StringBuilder(html);

        sb.Replace("#mensagem#", $"O registro ID \"{mesa.Id}\" foi excluído com sucesso!");

        return HttpContext.Response.WriteAsync(sb.ToString());
    }

    [HttpGet, ActionName("detalhes")]
    public Task ExibirPaginaDetalhesMesa(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

        Mesa mesa = repositorioMesa.SelecionarPorId(id);

        string html = System.IO.File.ReadAllText("Html/detalhes-mesa.html");

        StringBuilder detalhes = new StringBuilder(html);

        detalhes.Replace("#id#", mesa.Id.ToString());
        detalhes.Replace("#numero#", mesa.Numero);
        detalhes.Replace("#status#", (mesa.Ocupada ? "Ocupada" : "Livre"));

        if (mesa.Contas.Count > 0)
        {
            foreach (Conta c in mesa.Contas)
                detalhes.Replace("#conta#", $"<li>{c.ToString()}</li> #conta#");

            detalhes.Replace("#conta#", "");
        }

        return HttpContext.Response.WriteAsync(detalhes.ToString());
    }
}
