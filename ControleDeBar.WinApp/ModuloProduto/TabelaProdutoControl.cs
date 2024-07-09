using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado.Extensions;

namespace ControleDeBar.WinApp.ModuloProduto
{
    public partial class TabelaProdutoControl : UserControl
    {
        public TabelaProdutoControl()
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
                new DataGridViewTextBoxColumn { Name = "Valor", HeaderText = "Valor" },
            };

            return colunas;
        }

        public int ObterRegistroSelecionado()
        {
            return grid.SelecionarId();
        }

        public void AtualizarRegistros(List<Produto> produtos)
        {
            grid.Rows.Clear();

            foreach (Produto produto in produtos)
            {

                grid.Rows.Add(
                    produto.Id,
                    produto.Nome,
                    produto.Valor.ToString("C2")
                );
            }
        }
    }
}
