using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Infra.Orm.ModuloProduto;

namespace ControleDeBar.Testes.Integracao.ModuloProduto
{
    [TestClass]
    [TestCategory("Testes de Integração de Produto")]
    public class RepositorioProdutoEmOrmTests
    {
        ControleDeBarDbContext dbContext = null;
        RepositorioProdutoEmOrm repositorioProduto = null;

        [TestInitialize]
        public void ConfigurarTestes()
        {
            dbContext = new ControleDeBarDbContext();
            dbContext.Produtos.RemoveRange(dbContext.Produtos);

            repositorioProduto = new RepositorioProdutoEmOrm(dbContext);
        }

        [TestMethod]
        public void Deve_Inserir_Produto_Corretamente()
        {
            Produto novoProduto = new Produto("Água Mineral Com Gás 250ml", 2.50m);

            repositorioProduto.Inserir(novoProduto);

            Produto produtoSelecionado = repositorioProduto.SelecionarPorId(novoProduto.Id);

            Assert.AreEqual(novoProduto, produtoSelecionado);
        }

        [TestMethod]
        public void Deve_Editar_Produto_Corretamente()
        {
            Produto produtoOriginal = new Produto("Água Mineral Com Gás 250ml", 2.50m);

            repositorioProduto.Inserir(produtoOriginal);

            Produto produtoParaAtualizacao = repositorioProduto.SelecionarPorId(produtoOriginal.Id);

            produtoParaAtualizacao.Nome = "Refrigerante Coca-Cola";
            produtoParaAtualizacao.Valor = 4.00m;

            repositorioProduto.Editar(produtoOriginal, produtoParaAtualizacao);

            Assert.AreEqual(produtoOriginal, produtoParaAtualizacao);
        }

        [TestMethod]
        public void Deve_Excluir_Produto_Corretamente()
        {
            Produto produto = new Produto("Água Mineral Com Gás 250ml", 2.50m);

            repositorioProduto.Inserir(produto);

            repositorioProduto.Excluir(produto);

            Produto produtoSelecionado = repositorioProduto.SelecionarPorId(produto.Id);

            Assert.IsNull(produtoSelecionado);
        }

        [TestMethod]
        public void Deve_Selecionar_Produtos_Corretamente()
        {
            List<Produto> produtosParaCadastro =
            [
                new Produto("Água Mineral Com Gás 250ml", 2.50m),
                new Produto("Água Mineral Sem Gás 250ml", 2.00m),
                new Produto("Refrigerante Coca-Cola 250ml", 4.00m),
                new Produto("Refrigerante Sprite 250ml", 3.00m)
            ];

            foreach (Produto produto in produtosParaCadastro)
                repositorioProduto.Inserir(produto);

            List<Produto> produtosSelecionados = repositorioProduto.SelecionarTodos();

            CollectionAssert.AreEqual(produtosParaCadastro, produtosSelecionados);
        }
    }
}
