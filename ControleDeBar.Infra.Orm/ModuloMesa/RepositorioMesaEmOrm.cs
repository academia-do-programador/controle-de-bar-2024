using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Infra.Orm.ModuloMesa
{
    public class RepositorioMesaEmOrm : IRepositorioMesa
    {
        ControleDeBarDbContext dbContext;

        public RepositorioMesaEmOrm(ControleDeBarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Inserir(Mesa registro)
        {
            dbContext.Mesas.Add(registro);

            dbContext.SaveChanges();
        }

        public bool Editar(Mesa registroOriginal, Mesa registroAtualizado)
        {
            if (registroOriginal == null || registroAtualizado == null)
                return false;

            registroOriginal.AtualizarInformacoes(registroAtualizado);

            dbContext.Mesas.Update(registroOriginal);

            dbContext.SaveChanges();

            return true;
        }

        public bool Excluir(Mesa registro)
        {
            if (registro == null)
                return false;

            dbContext.Mesas.Remove(registro);

            dbContext.SaveChanges();

            return true;
        }

        public Mesa SelecionarPorId(int id)
        {
            return dbContext.Mesas
                .Include(m => m.Contas)
                .FirstOrDefault(m => m.Id == id)!;
        }

        public List<Mesa> SelecionarTodos()
        {
            return dbContext.Mesas.ToList();
        }
    }
}
