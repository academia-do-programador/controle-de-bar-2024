using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloGarcom
{
    public class ControladorGarcom : ControladorBase
    {
        public override string TipoCadastro => "Garçons";
        public override string ToolTipAdicionar => "Cadastrar um Garçom";
        public override string ToolTipEditar => "Editar um Garçom existente";
        public override string ToolTipExcluir => "Excluir um Garçom existente";

        TabelaGarcomControl tabelaGarcom;

        IRepositorioGarcom repositorioGarcom;

        public ControladorGarcom(IRepositorioGarcom repositorioGarcom)
        {
            this.repositorioGarcom = repositorioGarcom;
        }

        public override void Adicionar()
        {
            TelaGarcomForm telaGarcom = new TelaGarcomForm();

            DialogResult resultado = telaGarcom.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Garcom garcomCriado = telaGarcom.Garcom;

            repositorioGarcom.Inserir(garcomCriado);

            CarregarRegistros();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{garcomCriado.Nome}\" foi cadastrado com sucesso!");
        }

        public override void Editar()
        {
            int idSelecionado = tabelaGarcom.ObterRegistroSelecionado();

            Garcom garcomSelecionado = repositorioGarcom.SelecionarPorId(idSelecionado);

            if (garcomSelecionado == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            TelaGarcomForm telaGarcom = new TelaGarcomForm();

            telaGarcom.Garcom = garcomSelecionado;

            DialogResult resultado = telaGarcom.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Garcom garcomAtualizado = telaGarcom.Garcom;

            repositorioGarcom.Editar(garcomSelecionado, garcomAtualizado);

            CarregarRegistros();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{garcomAtualizado.Nome}\" foi editado com sucesso!");
        }

        public override void Excluir()
        {
            int idSelecionado = tabelaGarcom.ObterRegistroSelecionado();

            Garcom garcomSelecionado = repositorioGarcom.SelecionarPorId(idSelecionado);

            if (garcomSelecionado == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult resposta = MessageBox.Show(
                $"Você deseja realmente excluir o registro \"{garcomSelecionado.Nome}\" ",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );

            if (resposta != DialogResult.Yes)
                return;

            repositorioGarcom.Excluir(garcomSelecionado);

            CarregarRegistros();

            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{garcomSelecionado.Nome}\" foi exluído com sucesso!");
        }

        public override void CarregarRegistros()
        {
            List<Garcom> garcons = repositorioGarcom.SelecionarTodos();

            tabelaGarcom.AtualizarRegistros(garcons);
        }

        public override UserControl ObterListagem()
        {
            if (tabelaGarcom == null)
                tabelaGarcom = new TabelaGarcomControl();

            CarregarRegistros();

            return tabelaGarcom;
        }
    }
}
