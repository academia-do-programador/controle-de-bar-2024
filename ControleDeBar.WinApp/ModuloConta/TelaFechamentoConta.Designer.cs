namespace ControleDeBar.WinApp.ModuloConta
{
    partial class TelaFechamentoConta
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
            btnGravar = new Button();
            btnCacnelar = new Button();
            label1 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtId = new TextBox();
            groupBox1 = new GroupBox();
            listPedidos = new ListBox();
            lblValorTotal = new Label();
            label5 = new Label();
            lblTitular = new Label();
            txtTitular = new TextBox();
            txtMesa = new TextBox();
            txtGarcom = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Font = new Font("Segoe UI", 11.25F);
            btnGravar.ForeColor = SystemColors.ControlText;
            btnGravar.Image = Properties.Resources.btnFecharConta;
            btnGravar.Location = new Point(282, 522);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(152, 39);
            btnGravar.TabIndex = 1;
            btnGravar.Text = "Fechar Conta";
            btnGravar.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnFecharConta_Click;
            // 
            // btnCacnelar
            // 
            btnCacnelar.DialogResult = DialogResult.Cancel;
            btnCacnelar.Font = new Font("Segoe UI", 11.25F);
            btnCacnelar.Location = new Point(440, 522);
            btnCacnelar.Name = "btnCacnelar";
            btnCacnelar.Size = new Size(94, 39);
            btnCacnelar.TabIndex = 0;
            btnCacnelar.Text = "Cancelar";
            btnCacnelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F);
            label1.Location = new Point(42, 25);
            label1.Name = "label1";
            label1.Size = new Size(25, 20);
            label1.TabIndex = 2;
            label1.Text = "Id:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F);
            label7.Location = new Point(291, 91);
            label7.Name = "label7";
            label7.Size = new Size(64, 20);
            label7.TabIndex = 8;
            label7.Text = "Garçom:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F);
            label8.Location = new Point(20, 91);
            label8.Name = "label8";
            label8.Size = new Size(47, 20);
            label8.TabIndex = 9;
            label8.Text = "Mesa:";
            // 
            // txtId
            // 
            txtId.Font = new Font("Segoe UI", 11.25F);
            txtId.Location = new Point(73, 22);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(67, 27);
            txtId.TabIndex = 12;
            txtId.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listPedidos);
            groupBox1.Font = new Font("Segoe UI", 11.25F);
            groupBox1.Location = new Point(12, 134);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(522, 370);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Produtos Consumidos";
            // 
            // listPedidos
            // 
            listPedidos.FormattingEnabled = true;
            listPedidos.ItemHeight = 20;
            listPedidos.Location = new Point(9, 34);
            listPedidos.Name = "listPedidos";
            listPedidos.Size = new Size(504, 324);
            listPedidos.TabIndex = 17;
            // 
            // lblValorTotal
            // 
            lblValorTotal.AutoSize = true;
            lblValorTotal.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValorTotal.ForeColor = Color.ForestGreen;
            lblValorTotal.Location = new Point(101, 529);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Size = new Size(83, 25);
            lblValorTotal.TabIndex = 14;
            lblValorTotal.Text = "R$ 0,00 ";
            lblValorTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(9, 531);
            label5.Name = "label5";
            label5.Size = new Size(85, 21);
            label5.TabIndex = 15;
            label5.Text = "Valor Total:";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitular
            // 
            lblTitular.AutoSize = true;
            lblTitular.Font = new Font("Segoe UI", 11.25F);
            lblTitular.Location = new Point(13, 58);
            lblTitular.Name = "lblTitular";
            lblTitular.Size = new Size(54, 20);
            lblTitular.TabIndex = 2;
            lblTitular.Text = "Titular:";
            // 
            // txtTitular
            // 
            txtTitular.Enabled = false;
            txtTitular.Font = new Font("Segoe UI", 11.25F);
            txtTitular.Location = new Point(73, 55);
            txtTitular.Name = "txtTitular";
            txtTitular.PlaceholderText = "Nome do Cliente";
            txtTitular.Size = new Size(461, 27);
            txtTitular.TabIndex = 12;
            txtTitular.TabStop = false;
            // 
            // txtMesa
            // 
            txtMesa.Enabled = false;
            txtMesa.Font = new Font("Segoe UI", 11.25F);
            txtMesa.Location = new Point(73, 88);
            txtMesa.Name = "txtMesa";
            txtMesa.PlaceholderText = "Número da Mesa";
            txtMesa.Size = new Size(175, 27);
            txtMesa.TabIndex = 12;
            txtMesa.TabStop = false;
            // 
            // txtGarcom
            // 
            txtGarcom.Enabled = false;
            txtGarcom.Font = new Font("Segoe UI", 11.25F);
            txtGarcom.Location = new Point(361, 88);
            txtGarcom.Name = "txtGarcom";
            txtGarcom.PlaceholderText = "Nome do Garçom";
            txtGarcom.Size = new Size(173, 27);
            txtGarcom.TabIndex = 12;
            txtGarcom.TabStop = false;
            // 
            // TelaFechamentoConta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(546, 572);
            Controls.Add(label5);
            Controls.Add(lblValorTotal);
            Controls.Add(groupBox1);
            Controls.Add(txtGarcom);
            Controls.Add(txtMesa);
            Controls.Add(txtTitular);
            Controls.Add(txtId);
            Controls.Add(label8);
            Controls.Add(lblTitular);
            Controls.Add(label7);
            Controls.Add(label1);
            Controls.Add(btnCacnelar);
            Controls.Add(btnGravar);
            Name = "TelaFechamentoConta";
            Text = "Fechamento de Conta";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGravar;
        private Button btnCacnelar;
        private Label label1;
        private Label label7;
        private Label label8;
        private TextBox txtId;
        private GroupBox groupBox1;
        private Label lblValorTotal;
        private Label label5;
        private ListBox listPedidos;
        private Label lblTitular;
        private TextBox txtTitular;
        private TextBox txtMesa;
        private TextBox txtGarcom;
    }
}