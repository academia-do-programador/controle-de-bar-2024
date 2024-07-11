using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Infra.Orm.ModuloConta
{
    public class RepositorioContaEmOrm : IRepositorioConta
    {
        ControleDeBarDbContext dbContext;

        public RepositorioContaEmOrm(ControleDeBarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Inserir(Conta conta)
        {
            dbContext.Contas.Add(conta);

            dbContext.SaveChanges();
        }

        public bool AtualizarPedidos(Conta contaAtualizada, List<Pedido> pedidosRemovidos)
        {
            if (contaAtualizada == null)
                return false;

            dbContext.Contas.Update(contaAtualizada);

            dbContext.Pedidos.RemoveRange(pedidosRemovidos);

            dbContext.SaveChanges();

            return true;
        }

        public void AtualizarStatus(Conta contaFechada)
        {
            dbContext.Contas.Update(contaFechada);

            dbContext.SaveChanges();
        }

        public Conta SelecionarPorId(int id)
        {
            return dbContext.Contas
                .Include(c => c.Mesa)
                .Include(c => c.Garcom)
                .Include(c => c.Pedidos)
                .ThenInclude(p => p.Produto)
                .FirstOrDefault(c => c.Id == id)!;
        }

        public List<Conta> SelecionarContas()
        {
            return dbContext.Contas
                .Include(c => c.Mesa)
                .Include(c => c.Garcom)
                .ToList();
        }

        public List<Conta> SelecionarContasEmAberto()
        {
            return dbContext.Contas
                .Where(c => c.EstaAberta)
                .Include(c => c.Mesa)
                .Include(c => c.Garcom)
                .ToList();
        }

        public List<Conta> SelecionarContasFechadas()
        {
            return dbContext.Contas
                .Where(c => !c.EstaAberta)
                .Include(c => c.Mesa)
                .Include(c => c.Garcom)
                .ToList();
        }

        public List<Conta> SelecionarContasFaturamento()
        {
            return dbContext.Contas
                .Where(c => !c.EstaAberta)
                .Include(c => c.Mesa)
                .Include(c => c.Garcom)
                .Include(c => c.Pedidos)
                .ThenInclude(p => p.Produto)
                .AsNoTracking()
                .ToList();
        }
    }
}
