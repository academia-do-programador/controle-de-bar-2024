using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.WinApp.Compartilhado.Extensions;

namespace ControleDeBar.WinApp.ModuloConta
{
    public partial class TelaFechamentoConta : Form
    {
        public Conta Conta { get; private set; }

        public TelaFechamentoConta(Conta contaSelecionada)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            Conta = contaSelecionada;

            ConfigurarCamposExibicao();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

        }

        private void ConfigurarCamposExibicao()
        {

        }
    }
}
