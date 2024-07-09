namespace ControleDeBar.WinApp.ModuloMesa
{
    partial class TelaMesaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNumero = new TextBox();
            txtId = new TextBox();
            lblNome = new Label();
            label1 = new Label();
            btnCacnelar = new Button();
            btnGravar = new Button();
            checkOcupada = new CheckBox();
            SuspendLayout();
            // 
            // txtNumero
            // 
            txtNumero.Font = new Font("Segoe UI", 11.25F);
            txtNumero.Location = new Point(94, 67);
            txtNumero.Name = "txtNumero";
            txtNumero.PlaceholderText = "O número da mesa pode conter caracteres";
            txtNumero.Size = new Size(390, 27);
            txtNumero.TabIndex = 15;
            // 
            // txtId
            // 
            txtId.Font = new Font("Segoe UI", 11.25F);
            txtId.Location = new Point(94, 34);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(67, 27);
            txtId.TabIndex = 16;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI", 11.25F);
            lblNome.Location = new Point(22, 70);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(66, 20);
            lblNome.TabIndex = 13;
            lblNome.Text = "Número:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F);
            label1.Location = new Point(63, 37);
            label1.Name = "label1";
            label1.Size = new Size(25, 20);
            label1.TabIndex = 14;
            label1.Text = "Id:";
            // 
            // btnCacnelar
            // 
            btnCacnelar.DialogResult = DialogResult.Cancel;
            btnCacnelar.Font = new Font("Segoe UI", 11.25F);
            btnCacnelar.Location = new Point(390, 153);
            btnCacnelar.Name = "btnCacnelar";
            btnCacnelar.Size = new Size(94, 39);
            btnCacnelar.TabIndex = 18;
            btnCacnelar.Text = "Cancelar";
            btnCacnelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Font = new Font("Segoe UI", 11.25F);
            btnGravar.Location = new Point(290, 153);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(94, 39);
            btnGravar.TabIndex = 17;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // checkOcupada
            // 
            checkOcupada.AutoSize = true;
            checkOcupada.Enabled = false;
            checkOcupada.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkOcupada.Location = new Point(94, 100);
            checkOcupada.Name = "checkOcupada";
            checkOcupada.Size = new Size(127, 24);
            checkOcupada.TabIndex = 19;
            checkOcupada.Text = "Mesa Ocupada";
            checkOcupada.UseVisualStyleBackColor = true;
            // 
            // TelaMesaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 199);
            Controls.Add(checkOcupada);
            Controls.Add(btnCacnelar);
            Controls.Add(btnGravar);
            Controls.Add(txtNumero);
            Controls.Add(txtId);
            Controls.Add(lblNome);
            Controls.Add(label1);
            Name = "TelaMesaForm";
            Text = "Cadastro de Mesa";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNumero;
        private TextBox txtId;
        private Label lblNome;
        private Label label1;
        private Button btnCacnelar;
        private Button btnGravar;
        private CheckBox checkOcupada;
    }
}