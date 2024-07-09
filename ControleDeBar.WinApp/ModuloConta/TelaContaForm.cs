using ControladeDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.Dominio.ModuloProduto;
namespace ControleDeBar.WinApp.ModuloConta
{
    public partial class TelaContaForm : Form
    {
        public Conta Conta
        {
            get => conta;
            set
            {
                txtId.Text = numeroMesa.ToString();

                foreach (Pedido p in value.Pedidos)
                    listPedidos.Items.Add(p);
            }
        }
        private Conta conta;
        ControleDeBarDbContext dbContext;
        readonly int numeroMesa;

        public TelaContaForm(ControleDeBarDbContext dbContext)
        {
            InitializeComponent();
            this.dbContext = dbContext;

            CarregarMesas();
            CarregarGarcons();
            CarregarProdutos();
        }

        private void CarregarMesas()
        {
            List<Garcom> garconsCadastrados = [.. dbContext.Garcons];

            foreach (Garcom g in garconsCadastrados)
                cmbGarcom.Items.Add(g);
        }
        private void CarregarGarcons()
        {
            List<Garcom> garconsCadastrados = [.. dbContext.Garcons];

            foreach (Garcom g in garconsCadastrados)
                cmbGarcom.Items.Add(g);
        }
        private void CarregarProdutos()
        {
            List<Produto> produtosCadastrados = [.. dbContext.Produtos];

            foreach (Produto p in produtosCadastrados)
                cmbProduto.Items.Add(p);
        }
        private void btnRemoverlist_Click(object sender, EventArgs e)
        {
            Pedido pedidoSelecionado = (Pedido)listPedidos.SelectedItem;

            if (pedidoSelecionado == null) return;

            Conta.Pedidos.Remove(pedidoSelecionado);
            listPedidos.Items.Remove(pedidoSelecionado);
        }
    }
}
