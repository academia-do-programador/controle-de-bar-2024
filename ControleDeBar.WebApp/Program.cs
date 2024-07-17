
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

            app.Run();
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

            IEnumerable<string> mesasStrings = repositorioMesa
                .SelecionarTodos()
                .Select(mesa => "-> " + mesa.ToString());

            string resposta = string.Join('\n', mesasStrings);

            context.Response.ContentType = "text/plain; charset=utf-8";

            return context.Response.WriteAsync(resposta);
        }

        private static Task OlaMundo(HttpContext context)
        {
            context.Response.ContentType = "text/plain; charset=utf-8";

            return context.Response.WriteAsync("Olá, mundo!");
        }
    }
}
