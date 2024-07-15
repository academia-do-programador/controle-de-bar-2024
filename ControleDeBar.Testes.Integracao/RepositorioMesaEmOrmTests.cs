using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Infra.Orm.ModuloMesa;

namespace ControleDeBar.Testes.Integracao
{
    [TestClass]
    [TestCategory("Testes de Integração de Mesa")]
    public class RepositorioMesaEmOrmTests
    {
        RepositorioMesaEmOrm repositorioMesa;
        ControleDeBarDbContext dbContext;

        [TestMethod]
        public void Deve_Inserir_Mesa()
        {
            // Arrange
            Mesa novaMesa = new Mesa("01-T");

            dbContext = new ControleDeBarDbContext();
            repositorioMesa = new RepositorioMesaEmOrm(dbContext);

            // act
            repositorioMesa.Inserir(novaMesa);

            // Assert
            Mesa mesaSelecionada = repositorioMesa.SelecionarPorId(novaMesa.Id);

            Assert.AreEqual(novaMesa, mesaSelecionada);
        }
    }
}