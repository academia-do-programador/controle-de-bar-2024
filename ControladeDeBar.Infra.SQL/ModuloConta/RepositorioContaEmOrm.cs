using ControladeDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloConta;
using Microsoft.EntityFrameworkCore;
namespace ControladeDeBar.Infra.SQL.ModuloConta
{
    public class RepositorioContaEmOrm(ControleDeBarDbContext dbContext) : IRepositorioConta
    {
        public void Cadastrar(Conta conta)
        {
            dbContext.Contas.Add(conta);
            dbContext.SaveChanges();
        }

        public bool Editar(int id, Conta contaAtualizada)
        {
            Conta conta = dbContext.Contas.Find(id)!;

            if (conta == null) return false;

            conta.AtualizarRegistro(contaAtualizada);

            dbContext.Contas.Update(conta);
            dbContext.SaveChanges();

            return true;
        }

        public bool Excluir(int id)
        {
            Conta conta = dbContext.Contas.Find(id)!;

            if (conta == null)
                return false;

            dbContext.Contas.Remove(conta);
            dbContext.SaveChanges();

            return true;
        }

        public Conta SelecionarPorId(int id) => dbContext.Contas.Find(id)!;
        public List<Conta> SelecionarTodos() => [.. dbContext.Contas.Include(c => c.Pedidos)];
    }
}
