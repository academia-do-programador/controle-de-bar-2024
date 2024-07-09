
using ControleDeBar.Dominio.Compartilhado;

namespace ControleDeBar.Dominio.ModuloProduto
{
    public class Produto : EntidadeBase
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public Produto() { }

        public Produto(string nome, decimal valor)
        {
            Nome = nome;
            Valor = valor;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Produto produtoAtualizado = (Produto)registroAtualizado;

            Nome = produtoAtualizado.Nome;
            Valor = produtoAtualizado.Valor;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"Nome\" é obrigatorio");

            if (Valor == 0.0m)
                erros.Add("O campo \"Valor\" é obrigatorio");

            return erros;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
