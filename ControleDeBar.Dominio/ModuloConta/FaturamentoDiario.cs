namespace ControleDeBar.Dominio.ModuloConta
{
    public class FaturamentoDiario
    {
        private List<Conta> contasFechadas;

        public FaturamentoDiario(List<Conta> contas)
        {
            contasFechadas = contas;
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;

            foreach (Conta conta in contasFechadas)
                total += conta.CalcularValorTotal();

            return total;
        }
    }
}
