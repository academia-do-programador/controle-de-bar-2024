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
                conta = value;

                txtId.Text = value.Id.ToString();
                txtTitular.Text = value.Titular;

                cmbMesas.SelectedItem = value.Mesa;
                cmbGarcons.SelectedItem = value.Garcom;

                foreach (Pedido pedido in value.Pedidos)
                    listPedidos.Items.Add(pedido);

                ConfigurarCamposAtualizacaoConta();

                AtualizarLabelValorTotal();
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

            this.mesas = mesas;
            this.garcons = garcons;
            this.produtos = produtos;

            PedidosRemovidos = new List<Pedido>();

            foreach (Mesa mesa in mesas)
                cmbMesas.Items.Add(mesa);

            cmbMesas.SelectedIndex = 0;

            foreach (Garcom garcon in garcons)
                cmbGarcons.Items.Add(garcon);

            cmbGarcons.SelectedIndex = 0;

            foreach (Produto produto in produtos)
                cmbProdutos.Items.Add(produto);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (conta == null)
                conta = ObterConta();

            List<string> erros = conta.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm
                    .Instancia
                    .AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;

                return;
            }
        }

        private void btnAdicionarPedido_Click(object sender, EventArgs e)
        {
            if (!ContaPodeSerUtilizada())
            {
                TelaPrincipalForm
                    .Instancia
                    .AtualizarRodape("Preencha os campos anteriores antes de criar um pedido!");

                return;
            }

            if (conta == null)
                conta = ObterConta();

            Produto produtoSelecionado = (Produto)cmbProdutos.SelectedItem;
            int quantidadeSolicitada = (int)numQuantidade.Value;

            Pedido pedido = conta.RegistrarPedido(produtoSelecionado, quantidadeSolicitada);

            listPedidos.Items.Add(pedido);

            AtualizarLabelValorTotal();

            ResetarQuantidadeSolicitada();
        }

        private void btnRemoverPedido_Click(object sender, EventArgs e)
        {
            Pedido pedidoSelecionado = (Pedido)listPedidos.SelectedItem;

            if (pedidoSelecionado == null)
            {
                TelaPrincipalForm
                    .Instancia
                    .AtualizarRodape("Um pedido precisa ser selecionado antes de remover!");

                return;
            }

            conta.RemoverPedido(pedidoSelecionado);

            PedidosRemovidos.Add(pedidoSelecionado);

            listPedidos.Items.Remove(pedidoSelecionado);

            AtualizarLabelValorTotal();
        }

        private void ResetarQuantidadeSolicitada()
        {
            numQuantidade.Value = numQuantidade.Minimum;
        }

        private void ConfigurarCamposAtualizacaoConta()
        {
            this.Text = "Gerência de Conta";

            txtTitular.Enabled = false;
            cmbMesas.Enabled = false;
            cmbGarcons.Enabled = false;
        }

        private void AtualizarLabelValorTotal()
        {
            lblValorTotal.Text = conta.CalcularValorTotal().ToString("C2");
        }

        private bool ContaPodeSerUtilizada()
        {
            bool dadosEstaoPreenchidos =
                !string.IsNullOrEmpty(txtTitular.Text) &&
                cmbMesas.SelectedItem != null &&
                cmbGarcons.SelectedItem != null;

            return dadosEstaoPreenchidos || conta != null;
        }


        private Conta ObterConta()
        {
            string titular = txtTitular.Text;
            Mesa mesa = (Mesa)cmbMesas.SelectedItem;
            Garcom garcom = (Garcom)cmbGarcons.SelectedItem;

            return new Conta(titular, mesa, garcom);
        }
    }
}