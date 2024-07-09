using ControleDeBar.Dominio.Compartilhado;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloProduto;

namespace ControleDeBar.Dominio.ModuloPedido
{
    public class Pedido() : EntidadeBase
    {
        public Garcom Garcom { get; set; }
        public Produto Produto { get; set; }
        public Mesa Mesa { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Valor { get; set; }

        public Pedido(Garcom garcom, Produto produto, decimal quantidade, decimal valor) : this()
        {
            Garcom = garcom;
            Produto = produto;
            Quantidade = quantidade;
            Valor = valor;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Pedido atualizado = (Pedido)novoRegistro;

            Garcom = atualizado.Garcom;
            Produto = atualizado.Produto;
            Quantidade = atualizado.Quantidade;
            Valor = atualizado.Valor;
        }
        public override List<string> Validar()
        {
            List<string> erros = [];

            VerificaNulo(ref erros, Garcom, "Garçom");
            VerificaNulo(ref erros, Produto, "Produto");
            VerificaNulo(ref erros, Quantidade, "Quantidade");

            return erros;
        }
        public override string ToString() => $"Mesa {Id}";
    }
}