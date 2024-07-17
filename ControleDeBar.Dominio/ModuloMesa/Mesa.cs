using ControleDeBar.Dominio.Compartilhado;
using ControleDeBar.Dominio.ModuloConta;

namespace ControleDeBar.Dominio.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        public string Numero { get; set; }
        public bool Ocupada { get; set; }
        public List<Conta> Contas { get; set; }

        public Mesa()
        {
            Contas = new List<Conta>();
        }

        public Mesa(string numeroMesa) : this()
        {
            Numero = numeroMesa;
        }

        public void Ocupar()
        {
            Ocupada = true;
        }

        public void Desocupar()
        {
            Ocupada = false;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Mesa mesaAtualizada = (Mesa)registroAtualizado;

            Numero = mesaAtualizada.Numero;
            Ocupada = mesaAtualizada.Ocupada;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Numero.Trim()))
                erros.Add("O campo \"Número da Mesa\" é obrigatorio");

            return erros;
        }

        public override string ToString()
        {
            return Numero;
        }
    }
}
