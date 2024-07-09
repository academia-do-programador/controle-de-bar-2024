namespace ControleDeBar.WinApp.Compartilhado
{
    public interface IControladorFiltravel
    {
        string ToolTipFiltrar { get; }

        void Filtrar();
    }

    public interface IControladorVisualizavel
    {
        string ToolTipVisualizar { get; }

        void Visualizar();
    }
}
