namespace ControleDeBar.WinApp.ModuloPedido
{
    partial class TelaPedidoForm
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
            btnCancelar = new Button();
            txtId = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            txtQnt = new NumericUpDown();
            cmbProduto = new ComboBox();
            label4 = new Label();
            txtTotal = new TextBox();
            label5 = new Label();
            cmbGarcom = new ComboBox();
            lblAumentarQnt = new Label();
            ((System.ComponentModel.ISupportInitialize)txtQnt).BeginInit();
            SuspendLayout();
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(319, 207);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 23);
            btnGravar.TabIndex = 5;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(12, 207);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtId.Location = new Point(77, 17);
            txtId.Name = "txtId";
            txtId.Size = new Size(52, 23);
            txtId.TabIndex = 19;
            txtId.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 55);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 16;
            label2.Text = "Garçom:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 20);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 15;
            label1.Text = "Id:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(249, 94);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 20;
            label3.Text = "Quantidade:";
            // 
            // txtQnt
            // 
            txtQnt.Enabled = false;
            txtQnt.Location = new Point(324, 91);
            txtQnt.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            txtQnt.Name = "txtQnt";
            txtQnt.Size = new Size(52, 23);
            txtQnt.TabIndex = 2;
            txtQnt.ValueChanged += txtQnt_ValueChanged;
            txtQnt.DataContextChanged += txtQnt_DataContextChanged;
            // 
            // cmbProduto
            // 
            cmbProduto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProduto.FormattingEnabled = true;
            cmbProduto.Location = new Point(77, 90);
            cmbProduto.Name = "cmbProduto";
            cmbProduto.Size = new Size(152, 23);
            cmbProduto.TabIndex = 1;
            cmbProduto.SelectionChangeCommitted += cmbProduto_SelectionChangeCommitted;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 93);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 22;
            label4.Text = "Produto:";
            // 
            // txtTotal
            // 
            txtTotal.Enabled = false;
            txtTotal.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            txtTotal.Location = new Point(77, 147);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(52, 23);
            txtTotal.TabIndex = 3;
            txtTotal.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label5.Location = new Point(38, 150);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 24;
            label5.Text = "Valor:";
            // 
            // cmbGarcom
            // 
            cmbGarcom.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGarcom.FormattingEnabled = true;
            cmbGarcom.Location = new Point(77, 52);
            cmbGarcom.Name = "cmbGarcom";
            cmbGarcom.Size = new Size(152, 23);
            cmbGarcom.TabIndex = 25;
            // 
            // lblAumentarQnt
            // 
            lblAumentarQnt.AutoSize = true;
            lblAumentarQnt.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblAumentarQnt.Location = new Point(159, 150);
            lblAumentarQnt.Name = "lblAumentarQnt";
            lblAumentarQnt.Size = new Size(132, 15);
            lblAumentarQnt.TabIndex = 26;
            lblAumentarQnt.Text = "Aumente a quantidade!";
            // 
            // TelaPedidoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(406, 242);
            Controls.Add(lblAumentarQnt);
            Controls.Add(cmbGarcom);
            Controls.Add(txtTotal);
            Controls.Add(label5);
            Controls.Add(cmbProduto);
            Controls.Add(label4);
            Controls.Add(txtQnt);
            Controls.Add(label3);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Controls.Add(txtId);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaPedidoForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Mesa";
            ((System.ComponentModel.ISupportInitialize)txtQnt).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGravar;
        private Button btnCancelar;
        private TextBox txtId;
        private Label label2;
        private Label label1;
        private Label label3;
        private NumericUpDown txtQnt;
        private ComboBox cmbProduto;
        private Label label4;
        private TextBox txtTotal;
        private Label label5;
        private ComboBox cmbGarcom;
        private Label lblAumentarQnt;
    }
}