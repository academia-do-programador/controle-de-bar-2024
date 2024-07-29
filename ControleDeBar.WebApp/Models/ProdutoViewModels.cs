using System.ComponentModel.DataAnnotations;

namespace ControleDeBar.WebApp.Models;

public class InserirProdutoViewModel
{
    [Required(ErrorMessage = "O campo nome é obrigatório!")]
    public string Nome { get; set; }
    
    [Range(0.0, double.MaxValue, ErrorMessage = "O campo valor deve ser maior que zero!")]
    public decimal Valor { get; set; }
}

public class EditarProdutoViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O campo nome é obrigatório!")]
    public string Nome { get; set; }
    
    [Range(0.0, double.MaxValue, ErrorMessage = "O campo valor deve ser maior que zero!")]
    public decimal Valor { get; set; }
}

public class ExcluirProdutoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Valor { get; set; }
}

public class ListarProdutoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Valor { get; set; }
}

public class DetalhesProdutoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Valor { get; set; }
}