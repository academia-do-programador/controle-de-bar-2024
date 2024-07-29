using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleDeBar.WebApp.Models;

public class AbrirContaViewModel
{
    public string Titular { get; set; }
    public List<SelectListItem> Mesas { get; set; }
    public List<SelectListItem> Garcons { get; set; }

    public int IdMesa { get; set; }
    public int IdGarcom { get; set; }
}