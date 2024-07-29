using System.ComponentModel.DataAnnotations;
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
    [Required(ErrorMessage = "O campo nome é obrigatório!")]
    [MinLength(3, ErrorMessage = "O campo titular necessita de ao menos 3 caracteres")]
    public string Titular { get; set; }

    [Required(ErrorMessage = "É necessário selecionar uma mesa!")]
    public int IdMesa { get; set; }
    
    [Required(ErrorMessage = "É necessário selecionar um garçom!")]
    public int IdGarcom { get; set; }
    
    public List<SelectListItem> Mesas { get; set; }
    public List<SelectListItem> Garcons { get; set; }
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