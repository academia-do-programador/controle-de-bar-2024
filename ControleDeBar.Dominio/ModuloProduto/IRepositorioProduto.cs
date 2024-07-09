namespace ControleDeBar.Dominio.ModuloProduto
{
    public interface IRepositorioProduto
    {
        void Cadastrar(Produto produto);
        bool Editar(int id, Produto produto);
        bool Excluir(int id);
        Produto SelecionarPorId(int id);
        List<Produto> SelecionarTodos();
    }
}
