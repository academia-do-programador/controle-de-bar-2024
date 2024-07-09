using ControleDeBar.Dominio.Compartilhado;
using ControleDeBar.Dominio.ModuloMesa;

namespace ControleDeBar.Dominio.ModuloGarcom
{
    public class Garcom : EntidadeBase
    {
        public string Nome { get; set; }
        public string CPF { get; set; }

        public Garcom() { }

        public Garcom(string nome, string cpf) : this()
        {
            Nome = nome;
            CPF = cpf;
        }

        public void Atender(Mesa mesa)
        {
            throw new NotImplementedException();
        }

        public override void AtualizarInformacoes(EntidadeBase entidadeAtualizada)
        {
            Garcom garcomAtualizado = (Garcom)entidadeAtualizada;

            Nome = garcomAtualizado.Nome;
            CPF = garcomAtualizado.CPF;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"Nome\" é obrigatório!");

            return erros;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
