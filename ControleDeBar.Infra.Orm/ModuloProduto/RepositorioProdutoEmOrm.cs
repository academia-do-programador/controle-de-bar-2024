using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infra.Orm.Compartilhado;

namespace ControleDeBar.Infra.Orm.ModuloProduto
{
    public class RepositorioProdutoEmOrm : IRepositorioProduto
    {
        ControleDeBarDbContext dbContext;

        public RepositorioProdutoEmOrm(ControleDeBarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Inserir(Produto registro)
        {
            dbContext.Produtos.Add(registro);

            dbContext.SaveChanges();
        }

        public bool Editar(Produto registroOriginal, Produto registroAtualizado)
        {
            if (registroOriginal == null || registroAtualizado == null)
                return false;

            registroOriginal.AtualizarInformacoes(registroAtualizado);

            dbContext.Produtos.Update(registroOriginal);

            dbContext.SaveChanges();

            return true;
        }

        public bool Excluir(Produto registro)
        {
            if (registro == null)
                return false;

            dbContext.Produtos.Remove(registro);

            dbContext.SaveChanges();

            return true;
        }

        public Produto SelecionarPorId(int id)
        {
            return dbContext.Produtos.Find(id)!;
        }

        public List<Produto> SelecionarTodos()
        {
            return dbContext.Produtos.ToList();
        }
    }
}
