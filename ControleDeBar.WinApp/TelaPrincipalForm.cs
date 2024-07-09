using ControladeDeBar.Infra.Orm.Compartilhado;
using ControladeDeBar.Infra.SQL.ModuloConta;
using ControladeDeBar.Infra.SQL.ModuloGarcom;
using ControladeDeBar.Infra.SQL.ModuloMesa;
using ControladeDeBar.Infra.SQL.ModuloPedido;
using ControladeDeBar.Infra.SQL.ModuloProduto;
using ControleDeBar.Dominio.Compartilhado;
using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado;
using ControleDeBar.WinApp.ModuloConta;
using ControleDeBar.WinApp.ModuloGarcom;
using ControleDeBar.WinApp.ModuloMesa;
using ControleDeBar.WinApp.ModuloPedido;
using ControleDeBar.WinApp.ModuloProduto;
namespace ControleDeBar.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        public static TelaPrincipalForm Instancia { get; private set; }

        ControladorBase controlador;
        ControleDeBarDbContext dbContext;

        IRepositorioGarcom repositorioGarcom;
        IRepositorioProduto repositorioProduto;
        IRepositorioPedido repositorioPedido;
        IRepositorioMesa repositorioMesa;
        IRepositorioConta repositorioConta;

        public TelaPrincipalForm()
        {
            InitializeComponent();

            lblTipoCadastro.Text = string.Empty;

            dbContext = new();

            repositorioGarcom = new RepositorioGarcomEmOrm(dbContext);
            repositorioProduto = new RepositorioProdutoEmOrm(dbContext);
            repositorioPedido = new RepositorioPedidoEmOrm(dbContext);
            repositorioMesa = new RepositorioMesaEmOrm(dbContext);
            repositorioConta = new RepositorioContaEmOrm(dbContext);

            Instancia = this;
        }
        public void AtualizarRodape(string texto) => statusLabelPrincipal.Text = texto;


        #region Seleção de módulo
        private void garcomMenuItem_Click(object sender, EventArgs e)
            => SelecionaModulo(ref controlador, () => controlador = new ControladorGarcom(repositorioGarcom, dbContext),
                    repositorioGarcom.SelecionarTodos().Count);
        private void produtoMenuItem_Click(object sender, EventArgs e)
            => SelecionaModulo(ref controlador, () => controlador = new ControladorProduto(repositorioProduto, dbContext),
                    repositorioProduto.SelecionarTodos().Count);
        private void btnCadastroPedido_Click(object sender, EventArgs e)
            => SelecionaModulo(ref controlador, () => controlador = new ControladorPedido(repositorioPedido, dbContext),
                repositorioPedido.SelecionarTodos().Count);
        private void mesaMenuItem_Click(object sender, EventArgs e)
            => SelecionaModulo(ref controlador, () => controlador = new ControladorMesa(repositorioMesa, dbContext),
                repositorioMesa.SelecionarTodos().Count);
        private void contaMenuItem_Click(object sender, EventArgs e)
            => SelecionaModulo(ref controlador, () => controlador = new ControladorConta(repositorioConta, dbContext),
                repositorioConta.SelecionarTodos().Count);
        private void barMenuItem_Click(object sender, EventArgs e) { }
        /*                => SelecionaModulo(ref controlador, () => controlador = new ControladorGarcom(repositorioGarcom),
                    repositorioGarcom.SelecionarTodos().Count);*/
        #endregion

        #region Botões
        private void btnAdicionar_Click_1(object sender, EventArgs e)
            => controlador.Adicionar();
        private void btnEditar_Click(object sender, EventArgs e)
            => controlador.Editar();
        private void btnExcluir_Click(object sender, EventArgs e)
            => controlador.Excluir();
        private void btnContas_Click(object sender, EventArgs e)
        {
            if (controlador is IControladorContaDaMesa controladorContaDaMesa)
                controladorContaDaMesa.AdministrarContaDaMesa();
        }
        #endregion

        #region Auxiliares
        private void SelecionaModulo(ref ControladorBase controlador, Action controladorSelecionado, int numRegistros)
        {
            controladorSelecionado();
            lblTipoCadastro.Text = "Cadastro de " + controlador.TipoCadastro;

            ConfigurarToolBox(controlador);
            ConfigurarListagem(controlador);
            AtualizarRodape($"Visualizando {numRegistros} registro(s)...");
        }
        private void ConfigurarToolBox(ControladorBase controladorSelecionado)
        {
            btnAdicionar.Enabled = true;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;

            btnCadastroPedido.Enabled = controladorSelecionado is IControladorGeraPedido;
            btnContaDaMesa.Enabled = controladorSelecionado is IControladorContaDaMesa;

            ConfigurarToolTips(controladorSelecionado);
        }
        private void ConfigurarToolTips(ControladorBase controladorSelecionado)
        {
            btnAdicionar.ToolTipText = controladorSelecionado.ToolTipAdicionar;
            btnEditar.ToolTipText = controladorSelecionado.ToolTipEditar;
            btnExcluir.ToolTipText = controladorSelecionado.ToolTipExcluir;

            if (controladorSelecionado is IControladorGeraPedido controladorGeraPedido)
                btnCadastroPedido.ToolTipText = controladorGeraPedido.ToolTipGerarPedido;

            if (controladorSelecionado is IControladorContaDaMesa controladorContaDaMesa)
                btnContaDaMesa.ToolTipText = controladorContaDaMesa.ToolTipContaDaMesa;
        }
        private void ConfigurarListagem(ControladorBase controladorSelecionado)
        {
            UserControl listagemContato = controladorSelecionado.ObterListagem();

            listagemContato.Dock = DockStyle.Fill;
            pnlRegistros.Controls.Clear();
            pnlRegistros.Controls.Add(listagemContato);
        }
        #endregion
    }
}
