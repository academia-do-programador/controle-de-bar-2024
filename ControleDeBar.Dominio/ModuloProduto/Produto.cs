using ControleDeBar.Dominio.Compartilhado;
using ControleDeBar.Dominio.Compartilhado.Extensions;
namespace ControleDeBar.Dominio.ModuloProduto
{
    public class Produto (string nome, decimal preco) : EntidadeBase
    {
        public string Nome { get; set; } = nome;
        public decimal Preco { get; set; } = preco;

        #region Overrides
        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Produto atualizado = (Produto)novoRegistro;
            Nome = atualizado.Nome;
            Preco = atualizado.Preco;
        }
        public override List<string> Validar()
        {
            List<string> erros = [];
            VerificaNulo(ref erros, Nome, "Nome");
            VerificaNulo(ref erros, Preco, "Preço");

            return erros;
        }
        public override string ToString() => Nome.ToTitleCase();
        #endregion
    }
}