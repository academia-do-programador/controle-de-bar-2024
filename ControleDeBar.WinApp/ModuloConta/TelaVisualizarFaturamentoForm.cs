using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.WinApp.Compartilhado.Extensions;

namespace ControleDeBar.WinApp.ModuloConta
{
    public partial class TelaVisualizarFaturamentoForm : Form
    {
        private List<Conta> contasFechadas;

        public TelaVisualizarFaturamentoForm(List<Conta> contasFechadas)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            this.contasFechadas = contasFechadas;

            gridFaturamento.ConfigurarGridSomenteLeitura();
            gridFaturamento.ConfigurarGridZebrado();
            gridFaturamento.Columns.AddRange(ObterColunas());
        }

        private void cmbTiposFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id" },
                new DataGridViewTextBoxColumn { Name = "Fechamento", HeaderText = "Fechamento" },
                new DataGridViewTextBoxColumn { Name = "Titular", HeaderText = "Titular", },
                new DataGridViewTextBoxColumn { Name = "Mesa.Numero", HeaderText = "Mesa" },
                new DataGridViewTextBoxColumn { Name = "Garcom.Nome", HeaderText = "Garçom" },
                new DataGridViewTextBoxColumn { Name = "Total", HeaderText = "Total" },
            };

            return colunas;
        }
    }
}
