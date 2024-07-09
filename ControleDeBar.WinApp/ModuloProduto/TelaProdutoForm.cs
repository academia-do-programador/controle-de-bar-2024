using ControleDeBar.Dominio.Compartilhado.Extensions;
using ControleDeBar.Dominio.ModuloProduto;
namespace ControleDeBar.WinApp.ModuloProduto
{
    public partial class TelaProdutoForm : Form
    {
        public Produto Produto
        {
            get => produto;
            set
            {
                txtId.Text = value.Id.ToString();
                txtNome.Text = value.Nome;
            }
        }
        private Produto produto;

        private List<Produto> produtosCadastrados;

        public TelaProdutoForm(List<Produto> produtosCadastrados)
        {
            InitializeComponent();

            if (produtosCadastrados.Count > 0)
                txtId.Text = (produtosCadastrados.Last().Id + 1).ToString();
            else txtId.Text = "1";

            this.produtosCadastrados = produtosCadastrados;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            produto = new Produto(txtNome.Text, txtPreco.Value);

            List<string> erros = produto.Validar();

            if (ProdutoTemNomeDuplicado())
                erros.Add("Já existe um produto com este nome, tente utilizar outro!");

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }
        private bool ProdutoTemNomeDuplicado() => produtosCadastrados.Any(d => d.Nome.Validation() == produto.Nome.Validation());
    }
}
