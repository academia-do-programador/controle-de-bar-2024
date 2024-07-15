using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloProduto;

namespace ControleDeBar.Testes.Unidade
{
    [TestClass]
    [TestCategory("Testes de Unidade de Conta")]
    public class ContaTests
    {
        [TestMethod]
        public void Deve_Validar_Conta_Corretamente()
        {
            // AAA - Triple A
            // Arrange (preparação do teste)
            Conta contaInvalida = new Conta("", null, null);

            List<string> errosEsperados =
            [
                "O campo \"Titular\" necessita de ao menos 3 caracteres",
                "O campo \"Garçom\" é obrigatorio",
                "O campo \"Mesa\" é obrigatorio"
            ];

            // Act (ação do teste)
            List<string> erros = contaInvalida.Validar();

            // Assert (asserção do teste)
            CollectionAssert.AreEqual(errosEsperados, erros);
        }

        [TestMethod]
        public void Deve_Abrir_Conta_Corretamente()
        {
            // Arrange
            Mesa mesa = new Mesa("01");
            Garcom garcom = new Garcom("Pedro", "121.222.531-32");

            string titular = "Juninho Testes";

            // Act
            Conta contaAberta = new Conta(titular, mesa, garcom);

            // Assert
            Assert.IsTrue(contaAberta.EstaAberta);
            Assert.IsTrue(contaAberta.Mesa.Ocupada);

            Assert.AreNotEqual(DateTime.MinValue, contaAberta.Abertura);
        }

        [TestMethod]
        public void Deve_Fechar_Conta_Corretamente()
        {
            // Arrange
            Mesa mesa = new Mesa("01");
            Garcom garcom = new Garcom("Pedro", "121.222.531-32");

            string titular = "Juninho Testes";

            Conta novaConta = new Conta(titular, mesa, garcom);

            // Act
            novaConta.Fechar();

            // Assert
            Assert.IsFalse(novaConta.EstaAberta);
            Assert.IsFalse(novaConta.Mesa.Ocupada);

            Assert.AreNotEqual(DateTime.MinValue, novaConta.Fechamento);
        }

        [TestMethod]
        public void Deve_Calcular_Total_Corretamente()
        {
            // Arrange
            Mesa mesa = new Mesa("01");
            Garcom garcom = new Garcom("Pedro", "121.222.531-32");

            string titular = "Juninho Testes";

            Conta novaConta = new Conta(titular, mesa, garcom);

            Produto produto = new Produto("Água Mineral Com Gás 250ml", 2.50m);
            Produto produto2 = new Produto("Água Mineral Sem Gás 250ml", 2.00m);

            novaConta.RegistrarPedido(produto, 1);
            novaConta.RegistrarPedido(produto2, 2);

            // Act
            decimal total = novaConta.CalcularValorTotal();

            // Assert
            decimal totalEsperado = 6.50m;

            Assert.AreEqual(totalEsperado, total);
        }
    }
}