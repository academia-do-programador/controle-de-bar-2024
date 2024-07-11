using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloConta
{
    public class ControladorConta : ControladorBase, IControladorFiltravel, IControladorVisualizavel
    {
        public override string TipoCadastro => "Contas";
        public override string ToolTipAdicionar => "Abrir Conta";
        public override string ToolTipEditar => "Atualizar Produtos";
        public override string ToolTipExcluir => "Fechar Conta";
        public string ToolTipFiltrar => "Filtrar Contas";
        public string ToolTipVisualizar => "Visualizar Faturamento";

        public Bitmap IconeAdicionarProduto => Properties.Resources.btnAdicionarProduto;
        public Bitmap IconeFecharConta => Properties.Resources.btnFecharConta;

        TabelaContaControl tabelaConta;

        IRepositorioProduto repositorioProduto;
        IRepositorioMesa repositorioMesa;
        IRepositorioGarcom repositorioGarcom;
        IRepositorioConta repositorioConta;

        public ControladorConta(IRepositorioProduto repositorioProduto, IRepositorioMesa repositorioMesa, IRepositorioGarcom repositorioGarcom, IRepositorioConta repositorioConta)
        {
            this.repositorioProduto = repositorioProduto;
            this.repositorioMesa = repositorioMesa;
            this.repositorioGarcom = repositorioGarcom;
            this.repositorioConta = repositorioConta;
        }

        public override void Adicionar()
        {
            List<Mesa> mesas = repositorioMesa.SelecionarTodos();

            List<Garcom> garcons = repositorioGarcom.SelecionarTodos();

            List<Produto> produtos = repositorioProduto.SelecionarTodos();

            TelaContaForm telaConta = new TelaContaForm(mesas, garcons, produtos);

            DialogResult resultado = telaConta.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Conta contaCriada = telaConta.Conta;

            repositorioConta.Inserir(contaCriada);

            CarregarRegistros();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"Conta de \"{contaCriada.Titular}\" aberta com sucesso!");
        }

        public override void Editar()
        {
            AtualizarProdutos();
        }

        public override void Excluir()
        {
            FecharConta();
        }

        public void AtualizarProdutos()
        {
            List<Mesa> mesas = repositorioMesa.SelecionarTodos();

            List<Garcom> garcons = repositorioGarcom.SelecionarTodos();

            List<Produto> produtos = repositorioProduto.SelecionarTodos();

            int idSelecionado = tabelaConta.ObterRegistroSelecionado();

            Conta contaSelecionada = repositorioConta.SelecionarPorId(idSelecionado);

            if (contaSelecionada == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            TelaContaForm telaConta = new TelaContaForm(mesas, garcons, produtos);

            telaConta.Conta = contaSelecionada;

            DialogResult resultado = telaConta.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Conta contaAtualizada = telaConta.Conta;

            List<Pedido> pedidosRemovidos = telaConta.PedidosRemovidos;

            repositorioConta.AtualizarPedidos(contaAtualizada, pedidosRemovidos);

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"Conta de \"{contaAtualizada.Titular}\" foi atualizada com sucesso!");
        }

        public void FecharConta()
        {
            int idSelecionado = tabelaConta.ObterRegistroSelecionado();

            Conta contaSelecionada = repositorioConta.SelecionarPorId(idSelecionado);

            if (contaSelecionada == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!contaSelecionada.EstaAberta)
            {
                MessageBox.Show(
                    "Esta conta já foi fechada!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            TelaFechamentoConta telaFechamentoConta =
                new TelaFechamentoConta(contaSelecionada);

            DialogResult resultado = telaFechamentoConta.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Conta contaFechada = telaFechamentoConta.Conta;

            repositorioConta.AtualizarStatus(contaFechada);

            CarregarRegistros();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"Conta de \"{contaSelecionada.Titular}\" foi fechada com sucesso!");
        }

        public void Filtrar()
        {
            TelaFiltroContasForm telaFiltro = new TelaFiltroContasForm();

            DialogResult dialogResult = telaFiltro.ShowDialog();

            if (dialogResult != DialogResult.OK) return;

            TipoFiltroContaEnum filtroSelecionado = telaFiltro.FiltroSelecionado;

            List<Conta> contasFiltradas;

            switch (filtroSelecionado)
            {
                case TipoFiltroContaEnum.Abertas:
                    contasFiltradas = repositorioConta.SelecionarContasEmAberto();
                    break;

                case TipoFiltroContaEnum.Fechadas:
                    contasFiltradas = repositorioConta.SelecionarContasFechadas();
                    break;

                default:
                    contasFiltradas = repositorioConta.SelecionarContas();
                    break;
            }

            tabelaConta.AtualizarRegistros(contasFiltradas);
        }

        public void Visualizar()
        {
            List<Conta> contasFechadas = repositorioConta.SelecionarContasFaturamento();

            TelaVisualizarFaturamentoForm telaFaturamento =
                new TelaVisualizarFaturamentoForm(contasFechadas);

            telaFaturamento.ShowDialog();
        }

        public override void CarregarRegistros()
        {
            List<Conta> contas = repositorioConta.SelecionarContas();

            tabelaConta.AtualizarRegistros(contas);
        }

        public override UserControl ObterListagem()
        {
            if (tabelaConta == null)
                tabelaConta = new TabelaContaControl();

            CarregarRegistros();

            return tabelaConta;
        }
    }
}
