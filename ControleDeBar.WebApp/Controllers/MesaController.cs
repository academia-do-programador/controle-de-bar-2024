using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Infra.Orm.ModuloMesa;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ControleDeBar.WebApp.Controllers;

public class MesaController : Controller
{
    [HttpGet, ActionName("listar")]
    public Task ListarMesas()
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

        List<Mesa> mesas = repositorioMesa.SelecionarTodos();

        string conteudoArquivo = System.IO.File.ReadAllText("Html/listar-mesas.html");

        StringBuilder sb = new StringBuilder(conteudoArquivo);

        foreach (Mesa m in mesas)
        {
            string itemLista = $"<li>{m.ToString()} - <a href='/mesa/editar/{m.Id}'>[Editar]</a> <a href='/mesa/excluir/{m.Id}'>[Excluir]</a> </li> #mesa#";

            sb.Replace("#mesa#", itemLista);
        }

        sb.Replace("#mesa#", "");

        return HttpContext.Response.WriteAsync(sb.ToString());
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
}
