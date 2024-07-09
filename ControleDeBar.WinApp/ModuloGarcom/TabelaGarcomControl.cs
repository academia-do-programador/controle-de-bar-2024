using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.WinApp.Compartilhado.Extensions;

namespace ControleDeBar.WinApp.ModuloGarcom
{
    public partial class TabelaGarcomControl : UserControl
    {
        public TabelaGarcomControl()
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
                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", },
                new DataGridViewTextBoxColumn { Name = "CPF", HeaderText = "CPF" },
            };

            return colunas;
        }

        public int ObterRegistroSelecionado()
        {
            return grid.SelecionarId();
        }

        public void AtualizarRegistros(List<Garcom> garcons)
        {
            grid.Rows.Clear();

            foreach (Garcom garcom in garcons)
            {
                grid.Rows.Add(
                    garcom.Id,
                    garcom.Nome,
                    garcom.CPF
                );
            }
        }
    }
}
