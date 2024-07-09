using ControleDeBar.Dominio.ModuloConta;
namespace ControleDeBar.Dominio.ModuloConta
{
    public interface IRepositorioConta
    {
        void Cadastrar(Conta conta);
        bool Editar(int id, Conta conta);
        bool Excluir(int id);
        Conta SelecionarPorId(int id);
        List<Conta> SelecionarTodos();
    }
}
