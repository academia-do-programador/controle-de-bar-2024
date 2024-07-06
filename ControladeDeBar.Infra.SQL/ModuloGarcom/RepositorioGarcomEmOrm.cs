﻿using ControleDeBar.Dominio.ModuloGarcom;
namespace ControladeDeBar.Infra.SQL.ModuloGarcom
{
    public class RepositorioGarcomEmOrm(GeradorTestesDbContext dbContext) : IRepositorioGarcom
    {
        public void Cadastrar(Garcom garcom)
        {
            dbContext.Garcoms.Add(garcom);
            dbContext.SaveChanges();
        }

        public bool Editar(int id, Garcom garcomAtualizada)
        {
            Garcom garcom = dbContext.Garcoms.Find(id)!;

            if (garcom == null)
                return false;

            garcom.AtualizarRegistro(garcomAtualizada);

            dbContext.Garcoms.Update(garcom);
            dbContext.SaveChanges();

            return true;
        }

        public bool Excluir(int id)
        {
            Garcom garcom = dbContext.Garcoms.Find(id)!;

            if (garcom == null)
                return false;

            dbContext.Garcoms.Remove(garcom);
            dbContext.SaveChanges();

            return true;
        }

        public Garcom SelecionarPorId(int id) => dbContext.Garcoms.Find(id)!;
        public List<Garcom> SelecionarTodos() => dbContext.Garcoms.ToList();
    }
}
