using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleDeBar.WebApp.Models;

public class GerenciarPedidosViewModel
{
    public ListarContaViewModel Conta { get; set; }
    public IEnumerable<SelectListItem> Produtos { get; set; }

    public int IdProduto { get; set; }
    public int QuantidadeSolicitada { get; set; }
    
    public int IdPedido { get; set; }
}

public class AbrirContaViewModel
{
    public string Titular { get; set; }
    public List<SelectListItem> Mesas { get; set; }
    public List<SelectListItem> Garcons { get; set; }

    public int IdMesa { get; set; }
    public int IdGarcom { get; set; }
}

public class FecharContaViewModel
{
    public int Id { get; set; }
    public string Titular { get; set; }
    public string Mesa { get; set; }
    public string Garcom { get; set; }
    public decimal ValorTotal { get; set; }
    
    public IEnumerable<PedidoContaViewModel> Pedidos { get; set; }
}

public class ListarContaViewModel
{
    public int Id { get; set; }
    public string Titular { get; set; }
    public string Mesa { get; set; }
    public string Garcom { get; set; }
    public string EstaAberta { get; set; }
    public DateTime Abertura { get; set; }
    public DateTime Fechamento { get; set; }
    public IEnumerable<PedidoContaViewModel> Pedidos { get; set; }
}

public class PedidoContaViewModel
{
    public int Id { get; set; }
    public string Produto { get; set; }
    public int QuantidadeSolicitada { get; set; }
    public decimal TotalParcial { get; set; }
}
