using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.WinApp.Compartilhado.Extensions;

namespace ControleDeBar.WinApp.ModuloConta
{
    public partial class TelaFiltroContasForm : Form
    {
        public TipoFiltroContaEnum FiltroSelecionado { get; set; }

        public TelaFiltroContasForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

        }
    }
}
