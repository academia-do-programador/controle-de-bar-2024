using ControleDeBar.Dominio.Compartilhado.Extensions;
using ControleDeBar.Dominio.ModuloGarcom;
namespace ControleDeBar.WinApp.ModuloGarcom
{
    public partial class TelaGarcomForm : Form
    {
        public Garcom Garcom
        {
            get => garcom;
            set
            {
                txtId.Text = value.Id.ToString();
                txtNome.Text = value.Nome;
            }
        }
        private Garcom garcom;

        private List<Garcom> garconsCadastrados;

        public TelaGarcomForm(List<Garcom> garconsCadastrados)
        {
            InitializeComponent();

            if (garconsCadastrados.Count > 0)
                txtId.Text = (garconsCadastrados.Last().Id + 1).ToString();
            else txtId.Text = "1";

            this.garconsCadastrados = garconsCadastrados;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            garcom = new Garcom(txtNome.Text);

            List<string> erros = garcom.Validar();

            if (GarcomTemNomeDuplicado())
                erros.Add("Já existe um garçom com este nome, tente utilizar outro!");

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }
        private bool GarcomTemNomeDuplicado() => garconsCadastrados.Any(d => d.Nome.Validation() == garcom.Nome.Validation());
    }
}
