using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.WinApp.Compartilhado.Extensions;

namespace ControleDeBar.WinApp.ModuloGarcom
{
    public partial class TelaGarcomForm : Form
    {
        private Garcom garcom;
        public Garcom Garcom
        {
            get => garcom;
            set
            {
                txtId.Text = value.Id.ToString();
                txtNome.Text = value.Nome;
                txtCpf.Text = value.CPF;
            }
        }

        public TelaGarcomForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string cpf = txtCpf.Text;

            garcom = new Garcom(nome, cpf);

            List<string> erros = garcom.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;

                return;
            }
        }
    }
}
