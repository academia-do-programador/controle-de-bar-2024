
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

            // parâmetro de rota
            app.MapGet("/mesas/inserir/{numeroMesa}", InserirMesa);

            app.MapGet("/mesas/detalhes/{id:int}", ExibirPaginaDetalhesMesa);

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

        private static Task InserirMesa(HttpContext context)
        {
            ControleDeBarDbContext db = new ControleDeBarDbContext();
            IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

            string numero = context.GetRouteValue("numeroMesa")!.ToString()!;

            Mesa novaMesa = new Mesa(numero);

            repositorioMesa.Inserir(novaMesa);

            context.Response.StatusCode = 201;
            context.Response.ContentType = "text/plain; charset=utf-8";

            return context
                .Response
                .WriteAsync($"A mesa id \"{novaMesa.Id}\" foi adicionada com sucesso!");
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
