using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Infra.Orm.ModuloMesa;

namespace ControleDeBar.Testes.Integracao.ModuloMesa
{
    [TestClass]
    [TestCategory("Testes de Integração de Mesa")]
    public class RepositorioMesaEmOrmTests
    {
        RepositorioMesaEmOrm repositorioMesa;
        ControleDeBarDbContext dbContext;

        [TestInitialize]
        public void ConfigurarTestes()
        {
            dbContext = new ControleDeBarDbContext();
            repositorioMesa = new RepositorioMesaEmOrm(dbContext);

            dbContext.Mesas.RemoveRange(dbContext.Mesas);
        }

        [TestMethod]
        public void Deve_Inserir_Mesa_Corretamente()
        {
            // Arrange
            Mesa novaMesa = new Mesa("01-T");

            // act
            repositorioMesa.Inserir(novaMesa);

            // Assert
            Mesa mesaSelecionada = repositorioMesa.SelecionarPorId(novaMesa.Id);

            Assert.AreEqual(novaMesa, mesaSelecionada);
        }

        [TestMethod]
        public void Deve_Editar_Mesa_Corretamente()
        {
            // Arrange 
            Mesa mesaOriginal = new Mesa("01-T");

            repositorioMesa.Inserir(mesaOriginal);

            Mesa mesaParaAtualizacao = repositorioMesa.SelecionarPorId(mesaOriginal.Id);

            mesaParaAtualizacao.Numero = "07-E";

            // Act
            repositorioMesa.Editar(mesaOriginal, mesaParaAtualizacao);

            // Assert
            Assert.AreEqual(mesaOriginal, mesaParaAtualizacao);
        }

        [TestMethod]
        public void Deve_Excluir_Mesa_Corretamente()
        {
            // Arrange
            Mesa mesa = new Mesa("01");

            repositorioMesa.Inserir(mesa);

            // Act
            repositorioMesa.Excluir(mesa);

            // Assert
            Mesa mesaSelecionada = repositorioMesa.SelecionarPorId(mesa.Id);

            Assert.IsNull(mesaSelecionada);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_Corretamente()
        {
            // Arrange
            List<Mesa> mesasParaInserir =
            [
                new Mesa("01"),
                new Mesa("02"),
                new Mesa("03")
            ];

            foreach (Mesa mesa in mesasParaInserir)
                repositorioMesa.Inserir(mesa);

            // Act
            List<Mesa> mesasSelecionadas = repositorioMesa.SelecionarTodos();

            // Assert
            CollectionAssert.AreEqual(mesasParaInserir, mesasSelecionadas);
        }
    }
}