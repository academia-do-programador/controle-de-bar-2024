namespace ControleDeBar.Dominio.ModuloConta
{
    public interface IRepositorioConta
    {
        void Inserir(Conta conta);
        void Editar(Conta contaOriginal, Conta contaEditada);

        List<Conta> SelecionarContasEmAberto();
        List<Conta> SelecionarContasFechadas(DateTime data);
    }
}
