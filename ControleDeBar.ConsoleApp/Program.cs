using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Infra.Orm.ModuloMesa;

namespace ControleDeBar.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ControleDeBarDbContext dbContext = new ControleDeBarDbContext();
            RepositorioMesaEmOrm repositorioMesa = new RepositorioMesaEmOrm(dbContext);

            List<Mesa> mesasCadastradas = repositorioMesa.SelecionarTodos();

            foreach (Mesa mesa in mesasCadastradas)
                Console.WriteLine($"Id: {mesa.Id}, Numero: {mesa.Numero}, Ocupada: {mesa.Ocupada}");

            Console.ReadLine();
        }
    }
}
