namespace ControleDeBar.Dominio.ModuloMesa
{
    public interface IRepositorioMesa
    {
        void Cadastrar(Mesa mesa);
        bool Editar(int id, Mesa mesa);
        bool Excluir(int id);
        Mesa SelecionarPorId(int id);
        List<Mesa> SelecionarTodos();
    }
}
