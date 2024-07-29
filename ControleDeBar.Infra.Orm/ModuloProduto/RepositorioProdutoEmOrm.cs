using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Infra.Orm.ModuloProduto
{
    public class RepositorioProdutoEmOrm : RepositorioBaseEmOrm<Produto>, IRepositorioProduto
    {
        public RepositorioProdutoEmOrm(ControleDeBarDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Produto> ObterRegistros()
        {
            return dbContext.Produtos;
        }
    }
}
