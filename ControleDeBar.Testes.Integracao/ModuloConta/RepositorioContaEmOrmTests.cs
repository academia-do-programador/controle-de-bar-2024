using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Infra.Orm.ModuloConta;
using ControleDeBar.Infra.Orm.ModuloGarcom;
using ControleDeBar.Infra.Orm.ModuloMesa;
using ControleDeBar.Infra.Orm.ModuloProduto;

namespace ControleDeBar.Testes.Integracao.ModuloConta
{
    [TestClass]
    [TestCategory("Testes de Integração de Conta")]
    public class RepositorioContaEmOrmTests
    {
        ControleDeBarDbContext dbContext = null;

        RepositorioMesaEmOrm repositorioMesa = null;
        RepositorioGarcomEmOrm repositorioGarcom = null;
        RepositorioProdutoEmOrm repositorioProduto = null;
        RepositorioContaEmOrm repositorioConta = null;

        [TestInitialize]
        public void ConfigurarTestes()
        {
            dbContext = new ControleDeBarDbContext();

            dbContext.Contas.RemoveRange(dbContext.Contas);
            dbContext.Pedidos.RemoveRange(dbContext.Pedidos);
            dbContext.Produtos.RemoveRange(dbContext.Produtos);
            dbContext.Garcons.RemoveRange(dbContext.Garcons);
            dbContext.Mesas.RemoveRange(dbContext.Mesas);

            repositorioMesa = new RepositorioMesaEmOrm(dbContext);
            repositorioGarcom = new RepositorioGarcomEmOrm(dbContext);
            repositorioProduto = new RepositorioProdutoEmOrm(dbContext);
            repositorioConta = new RepositorioContaEmOrm(dbContext);
        }

        [TestMethod]
        public void Deve_Inserir_Conta_Corretamente()
        {
            // Arrange
            Mesa mesa = new Mesa("01");
            Garcom garcom = new Garcom("Pedro", "121.222.531-32");

            string titular = "Juninho Testes";

            repositorioMesa.Inserir(mesa);
            repositorioGarcom.Inserir(garcom);

            Conta novaConta = new Conta(titular, mesa, garcom);

            // Act
            repositorioConta.Inserir(novaConta);

            // Assert
            Conta contaSelecionada = repositorioConta.SelecionarPorId(novaConta.Id);

            Assert.AreEqual(novaConta, contaSelecionada);

            Assert.IsTrue(contaSelecionada.EstaAberta);
            Assert.IsTrue(contaSelecionada.Mesa.Ocupada);
        }

        [TestMethod]
        public void Deve_Fechar_Conta_Corretamente()
        {
            // Arrange
            Mesa mesa = new Mesa("01");
            Garcom garcom = new Garcom("Pedro", "121.222.531-32");

            string titular = "Juninho Testes";

            repositorioMesa.Inserir(mesa);
            repositorioGarcom.Inserir(garcom);

            Conta contaParaFechar = new Conta(titular, mesa, garcom);

            repositorioConta.Inserir(contaParaFechar);

            // Act
            contaParaFechar.Fechar();

            repositorioConta.AtualizarStatus(contaParaFechar);

            // Assert
            Conta contaSelecionada = repositorioConta.SelecionarPorId(contaParaFechar.Id);

            Assert.IsFalse(contaSelecionada.EstaAberta);
            Assert.IsFalse(contaSelecionada.Mesa.Ocupada);
        }

        [TestMethod]
        public void Deve_Registrar_Pedido_Corretamente()
        {
            // Arrange
            Mesa mesa = new Mesa("01");
            Garcom garcom = new Garcom("Pedro", "121.222.531-32");
            Produto produto = new Produto("Água Mineral Com Gás 250ml", 2.50m);

            string titular = "Juninho Testes";

            repositorioMesa.Inserir(mesa);
            repositorioGarcom.Inserir(garcom);
            repositorioProduto.Inserir(produto);

            Conta novaConta = new Conta(titular, mesa, garcom);

            // Act
            novaConta.RegistrarPedido(produto, 2);

            repositorioConta.Inserir(novaConta);

            // Assert
            Conta contaSelecionada = repositorioConta.SelecionarPorId(novaConta.Id);

            CollectionAssert.AreEqual(novaConta.Pedidos, contaSelecionada.Pedidos);
        }

        [TestMethod]
        public void Deve_Remover_Pedido_Corretamente()
        {
            // Arrange
            Mesa mesa = new Mesa("01");
            Garcom garcom = new Garcom("Pedro", "121.222.531-32");
            Produto produto = new Produto("Água Mineral Com Gás 250ml", 2.50m);

            string titular = "Juninho Testes";

            repositorioMesa.Inserir(mesa);
            repositorioGarcom.Inserir(garcom);
            repositorioProduto.Inserir(produto);

            Conta contaOriginal = new Conta(titular, mesa, garcom);

            Pedido pedido = contaOriginal.RegistrarPedido(produto, 2);

            repositorioConta.Inserir(contaOriginal);

            // Act
            Conta contaSelecionada = repositorioConta.SelecionarPorId(contaOriginal.Id);

            contaSelecionada.RemoverPedido(pedido);

            List<Pedido> pedidos = [pedido];

            repositorioConta.AtualizarPedidos(contaSelecionada, pedidos);

            // Assert
            CollectionAssert.AreEqual(contaOriginal.Pedidos, contaSelecionada.Pedidos);
        }
    }
}
