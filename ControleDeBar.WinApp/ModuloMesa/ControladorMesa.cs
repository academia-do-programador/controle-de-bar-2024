using ControladeDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Dominio.Compartilhado;
using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.WinApp.Compartilhado;
using ControleDeBar.WinApp.ModuloConta;
using ControleDeBar.WinApp.ModuloPedido;
namespace ControleDeBar.WinApp.ModuloMesa
{
    public class ControladorMesa(IRepositorioMesa repositorioMesa, ControleDeBarDbContext dbContext) : ControladorBase, IControladorGeraPedido
    {
        TabelaMesaControl tabelaMesa;

        #region ToolTips
        public override string TipoCadastro { get => "Mesa"; }
        public override string ToolTipAdicionar { get => "Cadastrar um novo mesa"; }
        public override string ToolTipEditar { get => "Editar um mesa existente"; }
        public override string ToolTipExcluir { get => "Excluir um mesa existente"; }
        public string ToolTipGerarPedido { get => "Cadastrar um novo pedido"; }
        public string ToolTipContaDaMesa { get => "Visualizar conta da mesa"; }
        #endregion

        #region CRUD
        public override void Adicionar()
        {
            TelaMesaForm telaMesa = new(dbContext);
            DialogResult resultado = telaMesa.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Mesa novoRegistro = telaMesa.Mesa;

            RealizarAcao(
                () => repositorioMesa.Cadastrar(novoRegistro),
                novoRegistro, "cadastrado");
        }
        public override void Editar()
        {
            int idSelecionado = tabelaMesa.ObterRegistroSelecionado();

            Mesa registroSelecionado = repositorioMesa.SelecionarPorId(idSelecionado);

            if (SemSeleção(registroSelecionado)) return;

            List<Mesa> disciplinasCadastradas = repositorioMesa.SelecionarTodos();

            TelaMesaForm telaMesa = new(dbContext)
            {
                Mesa = registroSelecionado
            };

            DialogResult resultado = telaMesa.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Mesa registroEditado = telaMesa.Mesa;

            RealizarAcao(
                () => repositorioMesa.Editar(registroSelecionado.Id, registroEditado),
                registroEditado, "editado");
        }
        public override void Excluir()
        {
            int idSelecionado = tabelaMesa.ObterRegistroSelecionado();

            Mesa registroSelecionado = repositorioMesa.SelecionarPorId(idSelecionado);

            if (SemSeleção(registroSelecionado) || !DesejaRealmenteExcluir(registroSelecionado)) return;

            RealizarAcao(
                () => repositorioMesa.Excluir(registroSelecionado.Id),
                registroSelecionado, "excluído");
        }
        #endregion

        public override UserControl ObterListagem()
        {
            tabelaMesa ??= new();

            CarregarRegistros();

            return tabelaMesa;
        }
        public override void CarregarRegistros()
            => tabelaMesa.AtualizarRegistros(repositorioMesa.SelecionarTodos());
    }
}
