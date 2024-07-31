using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ControleDeBar.WebApp.Models;

public class AbrirContaViewModel
{
    [Required(ErrorMessage = "É necessário preencher o titular!")]
    [MinLength(3, ErrorMessage = "O campo titular necessita de ao menos 3 caracteres")]
    public string Titular { get; set; }
    
    [Required(ErrorMessage = "É necessário selecionar uma mesa!")]
    public int? IdMesa { get; set; }
    
    [Required(ErrorMessage = "É necessário selecionar um garçom!")]
    public int? IdGarcom { get; set; }
    public IEnumerable<SelectListItem>? Mesas { get; set; }
    public IEnumerable<SelectListItem>? Garcons { get; set; }
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
}

public class DetalhesContaViewModel
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

public class GerenciarPedidosViewModel
{
    public DetalhesContaViewModel Conta { get; set; }
    public IEnumerable<SelectListItem> Produtos { get; set; }
}

public class AdicionarPedidoViewModel
{
    public int IdProduto { get; set; }
    public int QuantidadeSolicitada { get; set; }
}