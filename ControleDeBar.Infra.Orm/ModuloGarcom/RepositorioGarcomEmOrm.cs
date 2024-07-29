using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Infra.Orm.ModuloGarcom
{
    public class RepositorioGarcomEmOrm : RepositorioBaseEmOrm<Garcom>, IRepositorioGarcom
    {
        public RepositorioGarcomEmOrm(ControleDeBarDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Garcom> ObterRegistros()
        {
            return dbContext.Garcons;
        }
    }
}
