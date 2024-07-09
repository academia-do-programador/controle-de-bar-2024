using ControladeDeBar.Infra.Orm.Compartilhado;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.WinApp.Compartilhado;
namespace ControleDeBar.WinApp.ModuloGarcom
{
    public class ControladorGarcom(IRepositorioGarcom repositorioGarcom, ControleDeBarDbContext dbContext) : ControladorBase
    {
        TabelaGarcomControl tabelaGarcom;

        #region ToolTips
        public override string TipoCadastro { get => "Garçom"; }
        public override string ToolTipAdicionar { get => "Cadastrar um novo garçom"; }
        public override string ToolTipEditar { get => "Editar um garçom existente"; }
        public override string ToolTipExcluir { get => "Excluir um garçom existente"; }
        #endregion

        #region CRUD
        public override void Adicionar()
        {
            TelaGarcomForm telaProduto = new([.. dbContext.Garcons]);
            DialogResult resultado = telaProduto.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Garcom novoRegistro = telaProduto.Garcom;

            RealizarAcao(
                () => repositorioGarcom.Cadastrar(novoRegistro),
                novoRegistro, "cadastrado");
        }
        public override void Editar()
        {
            int idSelecionado = tabelaGarcom.ObterRegistroSelecionado();

            Garcom registroSelecionado = repositorioGarcom.SelecionarPorId(idSelecionado);

            if (SemSeleção(registroSelecionado)) return;

            List<Garcom> disciplinasCadastradas = repositorioGarcom.SelecionarTodos();

            TelaGarcomForm telaGarcom = new([.. dbContext.Garcons])
            {
                Garcom = registroSelecionado
            };

            DialogResult resultado = telaGarcom.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Garcom registroEditado = telaGarcom.Garcom;

            RealizarAcao(
                () => repositorioGarcom.Editar(registroSelecionado.Id, registroEditado),
                registroEditado, "editado");
        }
        public override void Excluir()
        {
            int idSelecionado = tabelaGarcom.ObterRegistroSelecionado();

            Garcom registroSelecionado = repositorioGarcom.SelecionarPorId(idSelecionado);

            if (SemSeleção(registroSelecionado) || !DesejaRealmenteExcluir(registroSelecionado)) return;

            RealizarAcao(
                () => repositorioGarcom.Excluir(registroSelecionado.Id),
                registroSelecionado, "excluído");
        }
        #endregion

        public override UserControl ObterListagem()
        {
            tabelaGarcom ??= new TabelaGarcomControl();

            CarregarRegistros();

            return tabelaGarcom;
        }
        public override void CarregarRegistros()
            => tabelaGarcom.AtualizarRegistros(repositorioGarcom.SelecionarTodos());
    }
}
