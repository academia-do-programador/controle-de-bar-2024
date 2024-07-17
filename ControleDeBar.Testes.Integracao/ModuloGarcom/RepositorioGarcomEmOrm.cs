using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Infra.Orm.ModuloGarcom;

namespace ControleDeBar.Testes.Integracao.ModuloGarcom
{
    [TestClass]
    [TestCategory("Testes de Integração de Garçom")]
    public class RepositorioGarcomEmOrmTests
    {
        ControleDeBarDbContext dbContext = null;
        RepositorioGarcomEmOrm repositorioGarcom = null;

        [TestInitialize]
        public void ConfigurarTestes()
        {
            dbContext = new ControleDeBarDbContext();
            dbContext.Garcons.RemoveRange(dbContext.Garcons);

            repositorioGarcom = new RepositorioGarcomEmOrm(dbContext);
        }

        [TestMethod]
        public void Deve_Inserir_Garcom_Corretamente()
        {
            // Arrange
            Garcom novoGarcom = new Garcom("Pedro Xerife", "321.222.502-13");

            // Act
            repositorioGarcom.Inserir(novoGarcom);

            // Assert
            Garcom garcomSelecionado = repositorioGarcom.SelecionarPorId(novoGarcom.Id);

            Assert.AreEqual(novoGarcom, garcomSelecionado);
        }

        [TestMethod]
        public void Deve_Editar_Garcom_Corretamente()
        {
            // Arrange
            Garcom garcomOriginal = new Garcom("Pedro Xerife", "321.222.502-13");

            repositorioGarcom.Inserir(garcomOriginal);

            Garcom garcomParaAtualizacao = repositorioGarcom.SelecionarPorId(garcomOriginal.Id);

            // Act
            garcomParaAtualizacao.Nome = "Juninho Testes";

            repositorioGarcom.Editar(garcomOriginal, garcomParaAtualizacao);

            // Assert
            Assert.AreEqual(garcomOriginal, garcomParaAtualizacao);
        }

        [TestMethod]
        public void Deve_Excluir_Garcom_Corretamente()
        {
            // Arrange
            Garcom garcom = new Garcom("Pedro Xerife", "321.222.502-13");

            repositorioGarcom.Inserir(garcom);

            // Act
            repositorioGarcom.Excluir(garcom);

            // Assert
            Garcom garcomSelecionado = repositorioGarcom.SelecionarPorId(garcom.Id);

            Assert.IsNull(garcomSelecionado);
        }

        [TestMethod]
        public void Deve_Selecionar_Garcons_Corretamente()
        {
            // Arrange
            List<Garcom> garconsParaCadastro =
            [
                new Garcom("Pedro Xerife", "121.222.531-32"),
                new Garcom("Juninho Testes", "512.352.191-12"),
                new Garcom("Júlia Testes", "321.533.123-76"),
            ];

            foreach (Garcom garcom in garconsParaCadastro)
                repositorioGarcom.Inserir(garcom);

            // Act
            List<Garcom> garconsSelecionados = repositorioGarcom.SelecionarTodos();

            // Assert
            CollectionAssert.AreEqual(garconsParaCadastro, garconsSelecionados);
        }
    }
}
