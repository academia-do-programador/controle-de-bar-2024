namespace ControleDeBar.WebApp.Models;

public class InserirGarcomViewModel
{
    public string Nome { get; set; }
    public string CPF { get; set; }
}

public class EditarGarcomViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
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