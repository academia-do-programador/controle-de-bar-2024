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

        }

        public override void Editar()
        {
            AdicionarProduto();
        }

        public override void Excluir()
        {
            FecharConta();
        }

        public void AdicionarProduto()
        {

        }

        public void FecharConta()
        {

        }

        public void Filtrar()
        {

        }

        public void Visualizar()
        {

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
