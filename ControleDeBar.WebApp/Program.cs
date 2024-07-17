
using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Infra.Orm.ModuloMesa;
using System.Text;

namespace ControleDeBar.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            WebApplication app = builder.Build();

            app.MapGet("/", OlaMundo);

            app.MapGet("/mesas/listar", ListarMesas);

            app.MapGet("/mesas/detalhes/{id:int}", ExibirPaginaDetalhesMesa);

            app.MapGet("/mesas/inserir", ExibirFormularioInserirMesa);

            app.MapPost("/mesas/inserir", InserirMesa);

            app.MapGet("/mesas/editar/{id:int}", ExibirFormularioEditarMesa);

            app.MapPost("/mesas/editar/{id:int}", EditarMesa);

            app.MapGet("/mesas/excluir/{id:int}", ExibirFormularioExcluirMesa);

            app.MapPost("/mesas/excluir/{id:int}", ExcluirMesa);

            app.Run();
        }

        private static Task ExcluirMesa(HttpContext context)
        {
            ControleDeBarDbContext db = new ControleDeBarDbContext();
            IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

            int id = Convert.ToInt32(context.GetRouteValue("id"));

            Mesa mesa = repositorioMesa.SelecionarPorId(id);

            repositorioMesa.Excluir(mesa);

            context.Response.StatusCode = 200;

            string html = File.ReadAllText("Html/mensagens-mesa.html");

            html = html.Replace("#mensagem#", $"A mesa id \"{mesa.Id}\" foi excluída com sucesso!");

            return context.Response.WriteAsync(html);
        }

        private static Task ExibirFormularioExcluirMesa(HttpContext context)
        {
            ControleDeBarDbContext db = new ControleDeBarDbContext();
            IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

            int id = Convert.ToInt32(context.GetRouteValue("id"));

            Mesa mesa = repositorioMesa.SelecionarPorId(id);

            string html = File.ReadAllText("Html/excluir-mesa-form.html");

            html = html.Replace("#numeromesa#", mesa.Numero);

            html = html.Replace("#id#", mesa.Id.ToString());

            context.Response.ContentType = "text/html";

            return context.Response.WriteAsync(html);
        }

        private static Task ExibirFormularioEditarMesa(HttpContext context)
        {
            ControleDeBarDbContext db = new ControleDeBarDbContext();
            IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

            int id = Convert.ToInt32(context.GetRouteValue("id"));

            Mesa mesa = repositorioMesa.SelecionarPorId(id);

            string html = File.ReadAllText("Html/editar-mesa-form.html");

            html = html.Replace("#id#", mesa.Id.ToString());

            html = html.Replace("#numero#", mesa.Numero.ToString());

            if (mesa.Ocupada)
                html = html.Replace("<input name=\"ocupada\" type=\"checkbox\" />", "<input name=\"ocupada\" type=\"checkbox\" checked/>");

            context.Response.ContentType = "text/html";

            return context.Response.WriteAsync(html);
        }

        private static Task EditarMesa(HttpContext context)
        {
            ControleDeBarDbContext db = new ControleDeBarDbContext();
            IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

            int id = Convert.ToInt32(context.GetRouteValue("id"));

            Mesa mesaOriginal = repositorioMesa.SelecionarPorId(id);

            Mesa mesaAtualizada = new Mesa()
            {
                Numero = Convert.ToString(context.Request.Form["numero"]),
                Ocupada = context.Request.Form["ocupada"] == "on"
            };

            repositorioMesa.Editar(mesaOriginal, mesaAtualizada);

            context.Response.StatusCode = 200;

            string html = File.ReadAllText("Html/mensagens-mesa.html");

            html = html.Replace("#mensagem#", $"A mesa id \"{mesaOriginal.Id}\" foi atualizada!");

            return context.Response.WriteAsync(html);
        }

        private static Task ExibirPaginaDetalhesMesa(HttpContext context)
        {
            ControleDeBarDbContext db = new ControleDeBarDbContext();
            IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

            int id = Convert.ToInt32(context.GetRouteValue("id"));

            Mesa mesa = repositorioMesa.SelecionarPorId(id);

            StringBuilder detalhes = new StringBuilder();

            detalhes.AppendLine("Id: " + mesa.Id);
            detalhes.AppendLine("Número: " + mesa.ToString());
            detalhes.AppendLine("Status: " + (mesa.Ocupada ? "Ocupada" : "Livre"));

            detalhes.AppendLine();

            if (mesa.Contas.Count > 0)
            {
                detalhes.AppendLine("Contas relacionadas à mesa:");

                foreach (Conta c in mesa.Contas)
                    detalhes.AppendLine("-> " + c.ToString());
            }

            context.Response.ContentType = "text/plain; charset=utf-8";

            return context.Response.WriteAsync(detalhes.ToString());
        }

        private static Task ExibirFormularioInserirMesa(HttpContext context)
        {
            // HTML
            string form = File.ReadAllText("Html/inserir-mesa-form.html");

            context.Response.ContentType = "text/html";

            return context.Response.WriteAsync(form);
        }

        private static Task InserirMesa(HttpContext context)
        {
            ControleDeBarDbContext db = new ControleDeBarDbContext();
            IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

            string numero = context.Request.Form["numero"].ToString();

            Mesa novaMesa = new Mesa(numero);

            repositorioMesa.Inserir(novaMesa);

            context.Response.StatusCode = 201;
            context.Response.ContentType = "text/html";

            string html = File.ReadAllText("Html/mensagens-mesa.html");

            html = html.Replace("#mensagem#", $"A mesa \"{novaMesa.Id}\" foi cadastrada com sucesso!");

            return context.Response.WriteAsync(html);
        }

        private static Task ListarMesas(HttpContext context)
        {
            ControleDeBarDbContext db = new ControleDeBarDbContext();
            IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

            List<Mesa> mesas = repositorioMesa.SelecionarTodos();

            string conteudoArquivo = File.ReadAllText("Html/listar-mesas.html");

            foreach (Mesa m in mesas)
            {
                string itemLista = $"<li>{m.ToString()}</li> #mesa#";

                conteudoArquivo =
                    conteudoArquivo
                        .Replace("#mesa#", itemLista);
            }

            conteudoArquivo = conteudoArquivo.Replace("#mesa#", "");

            return context.Response.WriteAsync(conteudoArquivo);
        }

        private static Task OlaMundo(HttpContext context)
        {
            context.Response.ContentType = "text/plain; charset=utf-8";

            return context.Response.WriteAsync("Olá, mundo!");
        }
    }
}
