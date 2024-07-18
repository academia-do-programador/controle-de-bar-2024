namespace ControleDeBar.WebApp;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        WebApplication app = builder.Build();

        app.MapControllerRoute("rotas-padrao", "{controller}/{action}/{id:int?}");

        app.Run();
    }
}
