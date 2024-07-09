using ControladeDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Dominio.ModuloGarcom;
namespace ControladeDeBar.Infra.SQL.ModuloGarcom
{
    public class RepositorioGarcomEmOrm(ControleDeBarDbContext dbContext) : IRepositorioGarcom
    {
        public void Cadastrar(Garcom garcom)
        {
            dbContext.Garcons.Add(garcom);
            dbContext.SaveChanges();
        }

        public bool Editar(int id, Garcom garcomAtualizada)
        {
            Garcom garcom = dbContext.Garcons.Find(id)!;

            if (garcom == null)
                return false;

            garcom.AtualizarRegistro(garcomAtualizada);

            dbContext.Garcons.Update(garcom);
            dbContext.SaveChanges();

            return true;
        }

        public bool Excluir(int id)
        {
            Garcom garcom = dbContext.Garcons.Find(id)!;

            if (garcom == null)
                return false;

            dbContext.Garcons.Remove(garcom);
            dbContext.SaveChanges();

            return true;
        }

        public Garcom SelecionarPorId(int id) => dbContext.Garcons.Find(id)!;
        public List<Garcom> SelecionarTodos() => [.. dbContext.Garcons];
    }
}
