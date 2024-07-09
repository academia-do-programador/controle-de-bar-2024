using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.WinApp.Compartilhado.Extensions;
namespace ControleDeBar.WinApp.ModuloMesa
{
    public partial class TabelaMesaControl : UserControl
    {
        public TabelaMesaControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }

        public void AtualizarRegistros(List<Mesa> mesas)
        {
            grid.Rows.Clear();

            foreach (Mesa m in mesas)
                grid.Rows.Add(m.Id, m.Numero, m.Conta);
        }

        public int ObterRegistroSelecionado() => grid.SelecionarId();
        private DataGridViewColumn[] ObterColunas() =>
        [
            new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id" },
            new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número" },
            new DataGridViewTextBoxColumn { DataPropertyName = "Conta", HeaderText = "Conta" },
        ];
    }
}
