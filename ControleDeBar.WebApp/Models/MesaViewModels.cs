namespace ControleDeBar.WebApp.Models;

public class ListarMesaViewModel
{
    public int Id { get; set; }
    public string Numero { get; set; }
    public string Ocupada { get; set; }
}

public class InserirMesaViewModel
{
    public string Numero { get; set; }
}

public class EditarMesaViewModel
{
    public int Id { get; set; }
    public string Numero { get; set; }
    public bool Ocupada { get; set; }
}

public class ExcluirMesaViewModel
{
    public int Id { get; set; }
    public string Numero { get; set; }
    public string Ocupada { get; set; }

    public IEnumerable<ListarContaMesaViewModel> Contas { get; set; }
}

public class DetalhesMesaViewModel
{
    public int Id { get; set; }
    public string Numero { get; set; }
    public string Ocupada { get; set; }

    public IEnumerable<ListarContaMesaViewModel> Contas { get; set; }
}


public class ListarContaMesaViewModel
{
    public string Titular { get; set; }
}
