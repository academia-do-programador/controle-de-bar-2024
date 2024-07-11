namespace ControleDeBar.WinApp.ModuloConta
{
    partial class TelaContaForm
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
            cmbMesas = new ComboBox();
            cmbGarcons = new ComboBox();
            txtId = new TextBox();
            groupBox1 = new GroupBox();
            btnRemoverProduto = new Button();
            listPedidos = new ListBox();
            btnAdicionarProduto = new Button();
            cmbProdutos = new ComboBox();
            numQuantidade = new NumericUpDown();
            label3 = new Label();
            label2 = new Label();
            lblValorTotal = new Label();
            label5 = new Label();
            lblTitular = new Label();
            txtTitular = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantidade).BeginInit();
            SuspendLayout();
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Font = new Font("Segoe UI", 11.25F);
            btnGravar.Location = new Point(340, 522);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(94, 39);
            btnGravar.TabIndex = 6;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCacnelar
            // 
            btnCacnelar.DialogResult = DialogResult.Cancel;
            btnCacnelar.Font = new Font("Segoe UI", 11.25F);
            btnCacnelar.Location = new Point(440, 522);
            btnCacnelar.Name = "btnCacnelar";
            btnCacnelar.Size = new Size(94, 39);
            btnCacnelar.TabIndex = 7;
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
            label7.Location = new Point(292, 92);
            label7.Name = "label7";
            label7.Size = new Size(64, 20);
            label7.TabIndex = 8;
            label7.Text = "Garçom:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F);
            label8.Location = new Point(20, 93);
            label8.Name = "label8";
            label8.Size = new Size(47, 20);
            label8.TabIndex = 9;
            label8.Text = "Mesa:";
            // 
            // cmbMesas
            // 
            cmbMesas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMesas.Font = new Font("Segoe UI", 11.25F);
            cmbMesas.FormattingEnabled = true;
            cmbMesas.Location = new Point(73, 89);
            cmbMesas.Name = "cmbMesas";
            cmbMesas.Size = new Size(144, 28);
            cmbMesas.TabIndex = 1;
            // 
            // cmbGarcons
            // 
            cmbGarcons.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGarcons.Font = new Font("Segoe UI", 11.25F);
            cmbGarcons.FormattingEnabled = true;
            cmbGarcons.Location = new Point(362, 88);
            cmbGarcons.Name = "cmbGarcons";
            cmbGarcons.Size = new Size(172, 28);
            cmbGarcons.TabIndex = 2;
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
            groupBox1.Controls.Add(btnRemoverProduto);
            groupBox1.Controls.Add(listPedidos);
            groupBox1.Controls.Add(btnAdicionarProduto);
            groupBox1.Controls.Add(cmbProdutos);
            groupBox1.Controls.Add(numQuantidade);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI", 11.25F);
            groupBox1.Location = new Point(12, 134);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(522, 367);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Registro de Pedidos";
            // 
            // btnRemoverProduto
            // 
            btnRemoverProduto.Location = new Point(409, 67);
            btnRemoverProduto.Name = "btnRemoverProduto";
            btnRemoverProduto.Size = new Size(104, 34);
            btnRemoverProduto.TabIndex = 18;
            btnRemoverProduto.Text = "Remover";
            btnRemoverProduto.UseVisualStyleBackColor = true;
            btnRemoverProduto.Click += btnRemoverPedido_Click;
            // 
            // listPedidos
            // 
            listPedidos.FormattingEnabled = true;
            listPedidos.ItemHeight = 20;
            listPedidos.Location = new Point(9, 114);
            listPedidos.Name = "listPedidos";
            listPedidos.Size = new Size(504, 244);
            listPedidos.TabIndex = 17;
            // 
            // btnAdicionarProduto
            // 
            btnAdicionarProduto.Location = new Point(409, 29);
            btnAdicionarProduto.Name = "btnAdicionarProduto";
            btnAdicionarProduto.Size = new Size(104, 34);
            btnAdicionarProduto.TabIndex = 5;
            btnAdicionarProduto.Text = "Adicionar";
            btnAdicionarProduto.UseVisualStyleBackColor = true;
            btnAdicionarProduto.Click += btnAdicionarPedido_Click;
            // 
            // cmbProdutos
            // 
            cmbProdutos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProdutos.FormattingEnabled = true;
            cmbProdutos.Location = new Point(105, 33);
            cmbProdutos.Name = "cmbProdutos";
            cmbProdutos.Size = new Size(298, 28);
            cmbProdutos.TabIndex = 3;
            // 
            // numQuantidade
            // 
            numQuantidade.Location = new Point(105, 71);
            numQuantidade.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantidade.Name = "numQuantidade";
            numQuantidade.Size = new Size(86, 27);
            numQuantidade.TabIndex = 4;
            numQuantidade.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 74);
            label3.Name = "label3";
            label3.Size = new Size(90, 20);
            label3.TabIndex = 11;
            label3.Text = "Quantidade:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 37);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 10;
            label2.Text = "Produto:";
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
            txtTitular.Font = new Font("Segoe UI", 11.25F);
            txtTitular.Location = new Point(73, 55);
            txtTitular.Name = "txtTitular";
            txtTitular.PlaceholderText = "Nome do Cliente";
            txtTitular.Size = new Size(461, 27);
            txtTitular.TabIndex = 0;
            // 
            // TelaContaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(546, 572);
            Controls.Add(label5);
            Controls.Add(lblValorTotal);
            Controls.Add(groupBox1);
            Controls.Add(txtTitular);
            Controls.Add(txtId);
            Controls.Add(cmbGarcons);
            Controls.Add(cmbMesas);
            Controls.Add(label8);
            Controls.Add(lblTitular);
            Controls.Add(label7);
            Controls.Add(label1);
            Controls.Add(btnCacnelar);
            Controls.Add(btnGravar);
            Name = "TelaContaForm";
            Text = "Cadastro de Conta";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantidade).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGravar;
        private Button btnCacnelar;
        private Label label1;
        private Label label7;
        private Label label8;
        private ComboBox cmbMesas;
        private ComboBox cmbGarcons;
        private TextBox txtId;
        private GroupBox groupBox1;
        private ComboBox cmbProdutos;
        private NumericUpDown numQuantidade;
        private Label label3;
        private Label label2;
        private Button btnAdicionarProduto;
        private Label lblValorTotal;
        private Label label5;
        private ListBox listPedidos;
        private Button btnRemoverProduto;
        private Label lblTitular;
        private TextBox txtTitular;
    }
}