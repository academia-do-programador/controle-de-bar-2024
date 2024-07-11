namespace ControleDeBar.WinApp.ModuloConta
{
    partial class TelaVisualizarFaturamentoForm
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
            btnVoltar = new Button();
            groupFaturamento = new GroupBox();
            gridFaturamento = new DataGridView();
            lblFiltro = new Label();
            cmbTiposFiltro = new ComboBox();
            label5 = new Label();
            lblValorTotal = new Label();
            txtDataInicial = new DateTimePicker();
            lblDataInicial = new Label();
            lblDataFinal = new Label();
            txtDataFinal = new DateTimePicker();
            btnFiltrar = new Button();
            groupFaturamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridFaturamento).BeginInit();
            SuspendLayout();
            // 
            // btnVoltar
            // 
            btnVoltar.DialogResult = DialogResult.OK;
            btnVoltar.Location = new Point(478, 521);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(121, 41);
            btnVoltar.TabIndex = 1;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = true;
            // 
            // groupFaturamento
            // 
            groupFaturamento.Controls.Add(gridFaturamento);
            groupFaturamento.Location = new Point(12, 148);
            groupFaturamento.Name = "groupFaturamento";
            groupFaturamento.Size = new Size(587, 346);
            groupFaturamento.TabIndex = 1;
            groupFaturamento.TabStop = false;
            groupFaturamento.Text = "Tabela de Faturamento";
            // 
            // gridFaturamento
            // 
            gridFaturamento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridFaturamento.Dock = DockStyle.Fill;
            gridFaturamento.Location = new Point(3, 23);
            gridFaturamento.Name = "gridFaturamento";
            gridFaturamento.Size = new Size(581, 320);
            gridFaturamento.TabIndex = 0;
            // 
            // lblFiltro
            // 
            lblFiltro.AutoSize = true;
            lblFiltro.Location = new Point(12, 30);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.Size = new Size(155, 20);
            lblFiltro.TabIndex = 2;
            lblFiltro.Text = "Filtro do Faturamento:";
            // 
            // cmbTiposFiltro
            // 
            cmbTiposFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTiposFiltro.FormattingEnabled = true;
            cmbTiposFiltro.Location = new Point(173, 27);
            cmbTiposFiltro.Name = "cmbTiposFiltro";
            cmbTiposFiltro.Size = new Size(421, 28);
            cmbTiposFiltro.TabIndex = 0;
            cmbTiposFiltro.SelectedIndexChanged += cmbTiposFiltro_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(9, 539);
            label5.Name = "label5";
            label5.Size = new Size(85, 21);
            label5.TabIndex = 17;
            label5.Text = "Valor Total:";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblValorTotal
            // 
            lblValorTotal.AutoSize = true;
            lblValorTotal.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValorTotal.ForeColor = Color.ForestGreen;
            lblValorTotal.Location = new Point(101, 537);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Size = new Size(83, 25);
            lblValorTotal.TabIndex = 16;
            lblValorTotal.Text = "R$ 0,00 ";
            lblValorTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtDataInicial
            // 
            txtDataInicial.Format = DateTimePickerFormat.Short;
            txtDataInicial.Location = new Point(173, 68);
            txtDataInicial.Name = "txtDataInicial";
            txtDataInicial.Size = new Size(158, 27);
            txtDataInicial.TabIndex = 18;
            txtDataInicial.Visible = false;
            // 
            // lblDataInicial
            // 
            lblDataInicial.AutoSize = true;
            lblDataInicial.Location = new Point(80, 71);
            lblDataInicial.Name = "lblDataInicial";
            lblDataInicial.Size = new Size(87, 20);
            lblDataInicial.TabIndex = 2;
            lblDataInicial.Text = "Data Inicial:";
            lblDataInicial.Visible = false;
            // 
            // lblDataFinal
            // 
            lblDataFinal.AutoSize = true;
            lblDataFinal.Location = new Point(351, 71);
            lblDataFinal.Name = "lblDataFinal";
            lblDataFinal.Size = new Size(79, 20);
            lblDataFinal.TabIndex = 2;
            lblDataFinal.Text = "Data Final:";
            lblDataFinal.Visible = false;
            // 
            // txtDataFinal
            // 
            txtDataFinal.Format = DateTimePickerFormat.Short;
            txtDataFinal.Location = new Point(436, 68);
            txtDataFinal.Name = "txtDataFinal";
            txtDataFinal.Size = new Size(158, 27);
            txtDataFinal.TabIndex = 18;
            txtDataFinal.Visible = false;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(478, 113);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(121, 29);
            btnFiltrar.TabIndex = 1;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // TelaVisualizarFaturamentoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(611, 574);
            Controls.Add(txtDataFinal);
            Controls.Add(txtDataInicial);
            Controls.Add(label5);
            Controls.Add(lblValorTotal);
            Controls.Add(lblDataFinal);
            Controls.Add(cmbTiposFiltro);
            Controls.Add(lblDataInicial);
            Controls.Add(lblFiltro);
            Controls.Add(groupFaturamento);
            Controls.Add(btnFiltrar);
            Controls.Add(btnVoltar);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TelaVisualizarFaturamentoForm";
            Text = "Visualizar Faturamento";
            groupFaturamento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridFaturamento).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVoltar;
        private GroupBox groupFaturamento;
        private DataGridView gridFaturamento;
        private Label lblFiltro;
        private ComboBox cmbTiposFiltro;
        private Label label5;
        private Label lblValorTotal;
        private DateTimePicker txtDataInicial;
        private Label lblDataInicial;
        private Label lblDataFinal;
        private DateTimePicker txtDataFinal;
        private Button btnFiltrar;
    }
}