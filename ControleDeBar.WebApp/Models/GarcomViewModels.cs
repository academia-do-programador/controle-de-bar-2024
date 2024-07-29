using System.ComponentModel.DataAnnotations;

namespace ControleDeBar.WebApp.Models;

public class InserirGarcomViewModel
{
    [Required(ErrorMessage = "O campo nome é obrigatório!")]
    [MinLength(3, ErrorMessage = "O campo nome necessita de ao menos 3 caracteres")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O campo CPF é obrigatório!")]
    [MinLength(11, ErrorMessage = "O campo CPF necessita de ao menos 11 caracteres")]
    public string CPF { get; set; }
}

public class EditarGarcomViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O campo nome é obrigatório!")]
    [MinLength(3, ErrorMessage = "O campo nome necessita de ao menos 3 caracteres")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O campo CPF é obrigatório!")]
    [MinLength(11, ErrorMessage = "O campo CPF necessita de ao menos 11 caracteres")]
    public string CPF { get; set; }
}

public class ExcluirGarcomViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
}

public class ListarGarcomViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
}

public class DetalhesGarcomViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
}