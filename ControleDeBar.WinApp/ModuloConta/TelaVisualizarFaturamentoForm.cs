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

            Array valoresEnum = Enum.GetValues(typeof(TipoFaturamentoEnum));

            foreach (object valor in valoresEnum)
                cmbTiposFiltro.Items.Add(valor);

            cmbTiposFiltro.SelectedIndex = 0;
        }

        private void cmbTiposFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoFaturamentoEnum tipoSelecionado =
              (TipoFaturamentoEnum)cmbTiposFiltro.SelectedItem;

            if (tipoSelecionado == TipoFaturamentoEnum.Periodo)
            {
                lblDataInicial.Visible = true;
                lblDataFinal.Visible = true;

                txtDataInicial.Visible = true;
                txtDataInicial.MinDate = new DateTime(2020, 01, 01);
                txtDataInicial.MaxDate = DateTime.Today;
                txtDataInicial.Value = DateTime.Now.AddDays(-7);

                txtDataFinal.Visible = true;
                txtDataFinal.MinDate = txtDataInicial.MinDate;
                txtDataFinal.MaxDate = DateTime.Now;
                txtDataFinal.Value = DateTime.Today;
            }
            else
            {
                lblDataInicial.Visible = false;
                lblDataFinal.Visible = false;

                txtDataInicial.Visible = false;
                txtDataFinal.Visible = false;
            }

            gridFaturamento.Rows.Clear();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            TipoFaturamentoEnum tipoSelecionado =
                (TipoFaturamentoEnum)cmbTiposFiltro.SelectedItem;

            Faturamento faturamento = new Faturamento(tipoSelecionado, contasFechadas);

            decimal totalFaturamento;
            List<Conta> contasFaturamento;

            if (tipoSelecionado == TipoFaturamentoEnum.Periodo)
            {
                DateTime inicioPeriodo = txtDataInicial.Value;
                DateTime finalPeriodo = txtDataFinal.Value.AddHours(23);

                totalFaturamento = faturamento
                    .CalcularTotalPeriodo(inicioPeriodo, finalPeriodo, out contasFaturamento);
            }
            else
                totalFaturamento = faturamento.CalcularTotal(out contasFaturamento);

            lblValorTotal.Text = totalFaturamento.ToString("C2");

            gridFaturamento.Rows.Clear();

            foreach (Conta c in contasFaturamento)
            {
                gridFaturamento.Rows.Add(
                    c.Id,
                    c.Fechamento.ToShortDateString(),
                    c.Titular,
                    c.Mesa,
                    c.Garcom,
                    c.CalcularValorTotal().ToString("C2")
                );
            }
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
