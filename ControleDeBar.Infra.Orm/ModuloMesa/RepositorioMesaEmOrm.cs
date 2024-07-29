using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Infra.Orm.ModuloMesa
{
    public class RepositorioMesaEmOrm : RepositorioBaseEmOrm<Mesa>, IRepositorioMesa
    {
        public RepositorioMesaEmOrm(ControleDeBarDbContext dbContext): base(dbContext)
        {
        }

        protected override DbSet<Mesa> ObterRegistros()
        {
            return dbContext.Mesas;
        }

        public override bool Editar(Mesa registroOriginal, Mesa registroAtualizado)
        {
            if (registroOriginal == null || registroAtualizado == null)
                return false;

            registroOriginal.AtualizarInformacoes(registroAtualizado);

            ObterRegistros().Update(registroOriginal);

            dbContext.SaveChanges();

            return true;
        }

        public override Mesa SelecionarPorId(int id)
        {
            return dbContext.Mesas
                .Include(m => m.Contas)
                .FirstOrDefault(m => m.Id == id)!;
        }
    }
}
