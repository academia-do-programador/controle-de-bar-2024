using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado.Extensions;

namespace ControleDeBar.WinApp.ModuloProduto
{
    public partial class TelaProdutoForm : Form
    {
        private Produto produto;
        public Produto Produto
        {
            get => produto;
            set
            {
                txtId.Text = value.Id.ToString();
                txtNome.Text = value.Nome;
                numValor.Value = value.Valor;
            }
        }

        public TelaProdutoForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            decimal valor = numValor.Value;

            produto = new Produto(nome, valor);

            List<string> erros = produto.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;

                return;
            }
        }
    }
}
