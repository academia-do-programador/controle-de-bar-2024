using ControleDeBar.Dominio.Compartilhado;
using ControleDeBar.Dominio.Compartilhado.Extensions;
namespace ControleDeBar.Dominio.ModuloGarcom
{
    public class Garcom(string nome) : EntidadeBase
    {
        public string Nome { get; set; } = nome;

        #region Overrides
        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Garcom atualizado = (Garcom)novoRegistro;
            Nome = atualizado.Nome;
        }
        public override List<string> Validar()
        {
            List<string> erros = [];
            VerificaNulo(ref erros, Nome, "Nome");

            return erros;
        }
        public override string ToString() => Nome.ToTitleCase();
        #endregion
    }
}