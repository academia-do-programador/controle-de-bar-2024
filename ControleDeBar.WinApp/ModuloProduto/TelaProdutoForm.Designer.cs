namespace ControleDeBar.WinApp.ModuloProduto
{
    partial class TelaProdutoForm
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
            lblValor = new Label();
            numValor = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numValor).BeginInit();
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
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Font = new Font("Segoe UI", 11.25F);
            lblValor.Location = new Point(42, 102);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(46, 20);
            lblValor.TabIndex = 13;
            lblValor.Text = "Valor:";
            // 
            // numValor
            // 
            numValor.DecimalPlaces = 2;
            numValor.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numValor.Location = new Point(94, 99);
            numValor.Margin = new Padding(3, 2, 3, 2);
            numValor.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numValor.Name = "numValor";
            numValor.Size = new Size(105, 27);
            numValor.TabIndex = 19;
            numValor.ThousandsSeparator = true;
            // 
            // TelaProdutoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 233);
            Controls.Add(numValor);
            Controls.Add(btnCacnelar);
            Controls.Add(btnGravar);
            Controls.Add(txtNome);
            Controls.Add(lblValor);
            Controls.Add(txtId);
            Controls.Add(lblNome);
            Controls.Add(label1);
            Name = "TelaProdutoForm";
            Text = "Cadastro de Produto";
            ((System.ComponentModel.ISupportInitialize)numValor).EndInit();
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
        private Label lblValor;
        private NumericUpDown numValor;
    }
}