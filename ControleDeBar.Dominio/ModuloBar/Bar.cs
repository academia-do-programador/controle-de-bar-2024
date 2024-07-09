using ControleDeBar.Dominio.Compartilhado;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloProduto;

namespace ControleDeBar.Dominio.Estabelecimento
{
    public class Bar : EntidadeBase
    {
        public string Nome { get; set; }
        public decimal Faturamento { get; set; }
        public Mesa Mesa { get; set; }
        public Garcom Garcom { get; set; }
        public Produto Produto { get; set; }

        public Bar()
        {
            
        }

        public Bar(string nome, decimal faturamento, Mesa mesa, Garcom garcom, Produto produto)
        {
            Nome = nome;
            Faturamento = faturamento;
            Mesa = mesa;
            Garcom = garcom;
            Produto = produto;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            throw new NotImplementedException();
        }

        public override List<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}