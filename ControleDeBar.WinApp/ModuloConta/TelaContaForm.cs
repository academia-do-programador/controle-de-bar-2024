using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado.Extensions;

namespace ControleDeBar.WinApp.ModuloConta
{
    public partial class TelaContaForm : Form
    {
        public Conta Conta
        {
            get => conta;
            set
            {
            }
        }

        public List<Pedido> PedidosRemovidos { get; set; }

        private Conta conta;
        private List<Mesa> mesas;
        private List<Garcom> garcons;
        private List<Produto> produtos;

        public TelaContaForm(List<Mesa> mesas, List<Garcom> garcons, List<Produto> produtos)
        {
            InitializeComponent();

            this.ConfigurarDialog();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

        }

        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoverProduto_Click(object sender, EventArgs e)
        {

        }

        private void ResetarQuantidadeSolicitada()
        {

        }

        private void ConfigurarCamposAtualizacaoConta()
        {

        }

        private void AtualizarLabelValorTotal()
        {

        }

        private Conta ObterConta()
        {
            string titular = txtTitular.Text;
            Mesa mesa = (Mesa)cmbMesas.SelectedItem;
            Garcom garcom = (Garcom)cmbGarcons.SelectedItem;

            return new Conta(titular, mesa, garcom);
        }

        private bool ContaPodeSerUtilizada()
        {
            bool dadosEstaoPreenchidos =
                !string.IsNullOrEmpty(txtTitular.Text) &&
                cmbMesas.SelectedItem != null &&
                cmbGarcons.SelectedItem != null;

            return dadosEstaoPreenchidos || conta != null;
        }
    }
}