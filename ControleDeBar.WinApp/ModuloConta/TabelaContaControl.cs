using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.WinApp.Compartilhado.Extensions;

namespace ControleDeBar.WinApp.ModuloConta
{
    public partial class TabelaContaControl : UserControl
    {
        public TabelaContaControl()
        {
            InitializeComponent();

            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id" },
                new DataGridViewTextBoxColumn { Name = "Abertura", HeaderText = "Abertura", },
                new DataGridViewTextBoxColumn { Name = "Titular", HeaderText = "Titular", },
                new DataGridViewTextBoxColumn { Name = "Mesa.Numero", HeaderText = "Mesa" },
                new DataGridViewTextBoxColumn { Name = "Garcom.Nome", HeaderText = "Garçom" },
                new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status" },
            };

            return colunas;
        }

        public int ObterRegistroSelecionado()
        {
            return grid.SelecionarId();
        }

        public void AtualizarRegistros(List<Conta> contas)
        {
            grid.Rows.Clear();

            foreach (Conta conta in contas)
            {
                string statusConta = conta.EstaAberta ? "Aberta" : "Fechada";

                grid.Rows.Add(
                    conta.Id,
                    conta.Abertura.ToShortDateString(),
                    conta.Titular,
                    conta.Mesa.Numero,
                    conta.Garcom.Nome,
                    statusConta
                );
            }
        }
    }
}
