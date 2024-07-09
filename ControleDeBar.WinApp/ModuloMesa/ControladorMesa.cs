using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloMesa
{
    public class ControladorMesa : ControladorBase
    {
        public override string TipoCadastro => "Mesas";
        public override string ToolTipAdicionar => "Cadastrar nova Mesa";
        public override string ToolTipEditar => "Editar uma Mesa existente";
        public override string ToolTipExcluir => "Excluir uma Mesa existente";

        TabelaMesaControl tabelaMesa;

        IRepositorioMesa repositorioMesa;

        public ControladorMesa(IRepositorioMesa repositorioMesa)
        {
            this.repositorioMesa = repositorioMesa;
        }

        public override void Adicionar()
        {
            TelaMesaForm telaMesa = new TelaMesaForm();

            DialogResult resultado = telaMesa.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Mesa mesaCriada = telaMesa.Mesa;

            repositorioMesa.Inserir(mesaCriada);

            CarregarRegistros();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{mesaCriada.Numero}\" foi cadastrado com sucesso!");
        }

        public override void Editar()
        {
            int idSelecionado = tabelaMesa.ObterRegistroSelecionado();

            Mesa mesaSelecionada = repositorioMesa.SelecionarPorId(idSelecionado);

            if (mesaSelecionada == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            TelaMesaForm telaMesa = new TelaMesaForm();

            telaMesa.Mesa = mesaSelecionada;

            DialogResult resultado = telaMesa.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Mesa mesaAtualizada = telaMesa.Mesa;

            repositorioMesa.Editar(mesaSelecionada, mesaAtualizada);

            CarregarRegistros();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{mesaAtualizada.Numero}\" foi editado com sucesso!");
        }

        public override void Excluir()
        {
            int idSelecionado = tabelaMesa.ObterRegistroSelecionado();

            Mesa mesaSelecionada = repositorioMesa.SelecionarPorId(idSelecionado);

            if (mesaSelecionada == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult resposta = MessageBox.Show(
                $"Você deseja realmente excluir o registro \"{mesaSelecionada.Numero}\" ",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );

            if (resposta != DialogResult.Yes)
                return;

            repositorioMesa.Excluir(mesaSelecionada);

            CarregarRegistros();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{mesaSelecionada.Numero}\" foi exluído com sucesso!");
        }

        public override void CarregarRegistros()
        {
            List<Mesa> mesas = repositorioMesa.SelecionarTodos();

            tabelaMesa.AtualizarRegistros(mesas);
        }

        public override UserControl ObterListagem()
        {
            if (tabelaMesa == null)
                tabelaMesa = new TabelaMesaControl();

            CarregarRegistros();

            return tabelaMesa;
        }
    }
}
