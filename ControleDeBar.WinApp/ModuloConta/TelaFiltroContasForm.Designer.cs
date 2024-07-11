namespace ControleDeBar.WinApp.ModuloConta
{
    partial class TelaFiltroContasForm
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
            btnCacnelar = new Button();
            btnGravar = new Button();
            groupBox1 = new GroupBox();
            rdbContasFechadas = new RadioButton();
            rdbContasAbertas = new RadioButton();
            rdbTodasContas = new RadioButton();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCacnelar
            // 
            btnCacnelar.DialogResult = DialogResult.Cancel;
            btnCacnelar.Font = new Font("Segoe UI", 11.25F);
            btnCacnelar.Location = new Point(332, 152);
            btnCacnelar.Name = "btnCacnelar";
            btnCacnelar.Size = new Size(94, 39);
            btnCacnelar.TabIndex = 3;
            btnCacnelar.Text = "Cancelar";
            btnCacnelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Font = new Font("Segoe UI", 11.25F);
            btnGravar.Location = new Point(232, 152);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(94, 39);
            btnGravar.TabIndex = 4;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdbContasFechadas);
            groupBox1.Controls.Add(rdbContasAbertas);
            groupBox1.Controls.Add(rdbTodasContas);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(414, 134);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Selecione um filtro";
            // 
            // rdbContasFechadas
            // 
            rdbContasFechadas.AutoSize = true;
            rdbContasFechadas.Location = new Point(26, 97);
            rdbContasFechadas.Name = "rdbContasFechadas";
            rdbContasFechadas.Size = new Size(137, 24);
            rdbContasFechadas.TabIndex = 2;
            rdbContasFechadas.TabStop = true;
            rdbContasFechadas.Text = "Contas Fechadas";
            rdbContasFechadas.UseVisualStyleBackColor = true;
            // 
            // rdbContasAbertas
            // 
            rdbContasAbertas.AutoSize = true;
            rdbContasAbertas.Location = new Point(26, 67);
            rdbContasAbertas.Name = "rdbContasAbertas";
            rdbContasAbertas.Size = new Size(127, 24);
            rdbContasAbertas.TabIndex = 1;
            rdbContasAbertas.TabStop = true;
            rdbContasAbertas.Text = "Contas Abertas";
            rdbContasAbertas.UseVisualStyleBackColor = true;
            // 
            // rdbTodasContas
            // 
            rdbTodasContas.AutoSize = true;
            rdbTodasContas.Checked = true;
            rdbTodasContas.Location = new Point(26, 37);
            rdbTodasContas.Name = "rdbTodasContas";
            rdbTodasContas.Size = new Size(133, 24);
            rdbTodasContas.TabIndex = 0;
            rdbTodasContas.TabStop = true;
            rdbTodasContas.Text = "Todas as Contas";
            rdbTodasContas.UseVisualStyleBackColor = true;
            // 
            // TelaFiltroContasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 203);
            Controls.Add(groupBox1);
            Controls.Add(btnCacnelar);
            Controls.Add(btnGravar);
            Name = "TelaFiltroContasForm";
            Text = "Filtro de Visualização de Contas";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnCacnelar;
        private Button btnGravar;
        private GroupBox groupBox1;
        private RadioButton rdbContasFechadas;
        private RadioButton rdbContasAbertas;
        private RadioButton rdbTodasContas;
    }
}