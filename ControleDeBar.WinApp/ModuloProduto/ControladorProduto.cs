using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloProduto
{
    public class ControladorProduto : ControladorBase
    {
        public override string TipoCadastro => "Produtos";
        public override string ToolTipAdicionar => "Cadastrar novo Produto";
        public override string ToolTipEditar => "Editar um Produto existente";
        public override string ToolTipExcluir => "Excluir um Produto existente";

        TabelaProdutoControl tabelaProduto;

        IRepositorioProduto repositorioProduto;

        public ControladorProduto(IRepositorioProduto repositorioProduto)
        {
            this.repositorioProduto = repositorioProduto;
        }

        public override void Adicionar()
        {
            TelaProdutoForm telaProduto = new TelaProdutoForm();

            DialogResult resultado = telaProduto.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Produto produtoCriado = telaProduto.Produto;

            repositorioProduto.Inserir(produtoCriado);

            CarregarRegistros();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{produtoCriado.Nome}\" foi cadastrado com sucesso!");
        }

        public override void Editar()
        {
            int idSelecionado = tabelaProduto.ObterRegistroSelecionado();

            Produto produtoSelecionado = repositorioProduto.SelecionarPorId(idSelecionado);

            if (produtoSelecionado == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            TelaProdutoForm telaProduto = new TelaProdutoForm();

            telaProduto.Produto = produtoSelecionado;

            DialogResult resultado = telaProduto.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Produto produtoAtualizado = telaProduto.Produto;

            repositorioProduto.Editar(produtoSelecionado, produtoAtualizado);

            CarregarRegistros();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{produtoAtualizado.Nome}\" foi editado com sucesso!");
        }

        public override void Excluir()
        {
            int idSelecionado = tabelaProduto.ObterRegistroSelecionado();

            Produto produtoSelecionado = repositorioProduto.SelecionarPorId(idSelecionado);

            if (produtoSelecionado == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult resposta = MessageBox.Show(
                $"Você deseja realmente excluir o registro \"{produtoSelecionado.Nome}\" ",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );

            if (resposta != DialogResult.Yes)
                return;

            repositorioProduto.Excluir(produtoSelecionado);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"O registro \"{produtoSelecionado.Nome}\" foi exluído com sucesso!");
        }

        public override void CarregarRegistros()
        {
            List<Produto> produtos = repositorioProduto.SelecionarTodos();

            tabelaProduto.AtualizarRegistros(produtos);
        }

        public override UserControl ObterListagem()
        {
            if (tabelaProduto == null)
                tabelaProduto = new TabelaProdutoControl();

            CarregarRegistros();

            return tabelaProduto;
        }
    }
}
