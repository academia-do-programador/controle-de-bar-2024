using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.WinApp.Compartilhado.Extensions;

namespace ControleDeBar.WinApp.ModuloMesa
{
    public partial class TabelaMesaControl : UserControl
    {
        public TabelaMesaControl()
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
                new DataGridViewTextBoxColumn { Name = "Numero", HeaderText = "Número" },
                new DataGridViewTextBoxColumn { Name = "Ocupada", HeaderText = "Status" },
            };

            return colunas;
        }

        public int ObterRegistroSelecionado()
        {
            return grid.SelecionarId();
        }

        public void AtualizarRegistros(List<Mesa> mesas)
        {
            grid.Rows.Clear();

            foreach (Mesa mesa in mesas)
            {
                string status = mesa.Ocupada ? "Ocupada" : "Livre";

                grid.Rows.Add(
                    mesa.Id,
                    mesa.Numero,
                    status
                );
            }
        }
    }
}
