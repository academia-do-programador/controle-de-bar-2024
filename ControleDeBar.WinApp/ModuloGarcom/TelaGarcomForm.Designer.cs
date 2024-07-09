namespace ControleDeBar.WinApp.ModuloGarcom
{
    partial class TelaGarcomForm
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
            txtNome = new TextBox();
            txtId = new TextBox();
            lblNome = new Label();
            label1 = new Label();
            btnCacnelar = new Button();
            btnGravar = new Button();
            lblCpf = new Label();
            txtCpf = new MaskedTextBox();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Segoe UI", 11.25F);
            txtNome.Location = new Point(94, 67);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(390, 27);
            txtNome.TabIndex = 15;
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
            lblNome.Location = new Point(35, 70);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(53, 20);
            lblNome.TabIndex = 13;
            lblNome.Text = "Nome:";
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
            btnCacnelar.Location = new Point(390, 186);
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
            btnGravar.Location = new Point(290, 186);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(94, 39);
            btnGravar.TabIndex = 17;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // lblCpf
            // 
            lblCpf.AutoSize = true;
            lblCpf.Font = new Font("Segoe UI", 11.25F);
            lblCpf.Location = new Point(52, 103);
            lblCpf.Name = "lblCpf";
            lblCpf.Size = new Size(36, 20);
            lblCpf.TabIndex = 13;
            lblCpf.Text = "CPF:";
            // 
            // txtCpf
            // 
            txtCpf.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCpf.Location = new Point(94, 100);
            txtCpf.Mask = "000.000.000-00";
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(197, 27);
            txtCpf.TabIndex = 19;
            // 
            // TelaGarcomForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 233);
            Controls.Add(txtCpf);
            Controls.Add(btnCacnelar);
            Controls.Add(btnGravar);
            Controls.Add(txtNome);
            Controls.Add(lblCpf);
            Controls.Add(txtId);
            Controls.Add(lblNome);
            Controls.Add(label1);
            Name = "TelaGarcomForm";
            Text = "Cadastro de Garçom";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNome;
        private TextBox txtId;
        private Label lblNome;
        private Label label1;
        private Button btnCacnelar;
        private Button btnGravar;
        private Label lblCpf;
        private MaskedTextBox txtCpf;
    }
}