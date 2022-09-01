namespace loja
{
    partial class frmListagemVendas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListagemVendas));
            this.rgvVenda = new System.Windows.Forms.DataGridView();
            this.imprimir = new System.Windows.Forms.DataGridViewImageColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.lblTotalDinheiro = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblQtdeTotal = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblTotalCartao = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtDataFim = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataInicio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnImprimirVenda = new System.Windows.Forms.Button();
            this.lblTotalDesconto = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDataFimImpressao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDataInicioImpressao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalCarne = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rgvVenda)).BeginInit();
            this.pnlFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // rgvVenda
            // 
            this.rgvVenda.AllowUserToAddRows = false;
            this.rgvVenda.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.rgvVenda.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.rgvVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rgvVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rgvVenda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.imprimir});
            this.rgvVenda.Location = new System.Drawing.Point(16, 101);
            this.rgvVenda.Margin = new System.Windows.Forms.Padding(4);
            this.rgvVenda.Name = "rgvVenda";
            this.rgvVenda.ReadOnly = true;
            this.rgvVenda.Size = new System.Drawing.Size(1289, 414);
            this.rgvVenda.TabIndex = 23;
            this.rgvVenda.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rgvVenda_CellContentClick);
            this.rgvVenda.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.rgvVenda_CellFormatting);
            // 
            // imprimir
            // 
            this.imprimir.HeaderText = "";
            this.imprimir.Image = global::loja.Properties.Resources.Impressao16;
            this.imprimir.Name = "imprimir";
            this.imprimir.ReadOnly = true;
            this.imprimir.ToolTipText = "Imprimir comprovante";
            this.imprimir.Width = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Data:";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(71, 11);
            this.lblData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(0, 20);
            this.lblData.TabIndex = 25;
            // 
            // lblTotalDinheiro
            // 
            this.lblTotalDinheiro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalDinheiro.AutoSize = true;
            this.lblTotalDinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDinheiro.Location = new System.Drawing.Point(209, 604);
            this.lblTotalDinheiro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalDinheiro.Name = "lblTotalDinheiro";
            this.lblTotalDinheiro.Size = new System.Drawing.Size(0, 20);
            this.lblTotalDinheiro.TabIndex = 39;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(16, 604);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(161, 20);
            this.label19.TabIndex = 38;
            this.label19.Text = "Total em dinheiro:";
            // 
            // lblQtdeTotal
            // 
            this.lblQtdeTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblQtdeTotal.AutoSize = true;
            this.lblQtdeTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtdeTotal.Location = new System.Drawing.Point(308, 569);
            this.lblQtdeTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQtdeTotal.Name = "lblQtdeTotal";
            this.lblQtdeTotal.Size = new System.Drawing.Size(0, 20);
            this.lblQtdeTotal.TabIndex = 37;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(16, 569);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(251, 20);
            this.label18.TabIndex = 36;
            this.label18.Text = "Qtde total de itens vendidos:";
            // 
            // lblTotalCartao
            // 
            this.lblTotalCartao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalCartao.AutoSize = true;
            this.lblTotalCartao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCartao.Location = new System.Drawing.Point(560, 604);
            this.lblTotalCartao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalCartao.Name = "lblTotalCartao";
            this.lblTotalCartao.Size = new System.Drawing.Size(0, 20);
            this.lblTotalCartao.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(388, 604);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 20);
            this.label3.TabIndex = 40;
            this.label3.Text = "Total em cartão:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1092, 604);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 42;
            this.label2.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(1163, 604);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 20);
            this.lblTotal.TabIndex = 43;
            // 
            // pnlFiltro
            // 
            this.pnlFiltro.Controls.Add(this.btnPesquisar);
            this.pnlFiltro.Controls.Add(this.txtDataFim);
            this.pnlFiltro.Controls.Add(this.label5);
            this.pnlFiltro.Controls.Add(this.txtDataInicio);
            this.pnlFiltro.Controls.Add(this.label4);
            this.pnlFiltro.Location = new System.Drawing.Point(16, 37);
            this.pnlFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(1289, 57);
            this.pnlFiltro.TabIndex = 44;
            this.pnlFiltro.Visible = false;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.Location = new System.Drawing.Point(400, 2);
            this.btnPesquisar.Margin = new System.Windows.Forms.Padding(4);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(176, 48);
            this.btnPesquisar.TabIndex = 38;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtDataFim
            // 
            this.txtDataFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataFim.Location = new System.Drawing.Point(288, 14);
            this.txtDataFim.Margin = new System.Windows.Forms.Padding(4);
            this.txtDataFim.Name = "txtDataFim";
            this.txtDataFim.Size = new System.Drawing.Size(103, 26);
            this.txtDataFim.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(244, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Até:";
            // 
            // txtDataInicio
            // 
            this.txtDataInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataInicio.Location = new System.Drawing.Point(128, 12);
            this.txtDataInicio.Margin = new System.Windows.Forms.Padding(4);
            this.txtDataInicio.Name = "txtDataInicio";
            this.txtDataInicio.Size = new System.Drawing.Size(107, 26);
            this.txtDataInicio.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Período - De:";
            // 
            // btnImprimirVenda
            // 
            this.btnImprimirVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImprimirVenda.BackColor = System.Drawing.Color.PaleGreen;
            this.btnImprimirVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirVenda.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimirVenda.Image")));
            this.btnImprimirVenda.Location = new System.Drawing.Point(948, 640);
            this.btnImprimirVenda.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimirVenda.Name = "btnImprimirVenda";
            this.btnImprimirVenda.Size = new System.Drawing.Size(357, 48);
            this.btnImprimirVenda.TabIndex = 39;
            this.btnImprimirVenda.Text = "Imprimir Total Vendido";
            this.btnImprimirVenda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimirVenda.UseVisualStyleBackColor = false;
            this.btnImprimirVenda.Click += new System.EventHandler(this.btnImprimirVenda_Click);
            // 
            // lblTotalDesconto
            // 
            this.lblTotalDesconto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalDesconto.AutoSize = true;
            this.lblTotalDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDesconto.Location = new System.Drawing.Point(908, 604);
            this.lblTotalDesconto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalDesconto.Name = "lblTotalDesconto";
            this.lblTotalDesconto.Size = new System.Drawing.Size(0, 20);
            this.lblTotalDesconto.TabIndex = 48;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(743, 604);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 20);
            this.label9.TabIndex = 47;
            this.label9.Text = "Total Desconto:";
            // 
            // txtDataFimImpressao
            // 
            this.txtDataFimImpressao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDataFimImpressao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataFimImpressao.Location = new System.Drawing.Point(824, 651);
            this.txtDataFimImpressao.Margin = new System.Windows.Forms.Padding(4);
            this.txtDataFimImpressao.Name = "txtDataFimImpressao";
            this.txtDataFimImpressao.Size = new System.Drawing.Size(103, 26);
            this.txtDataFimImpressao.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(780, 654);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 20);
            this.label6.TabIndex = 51;
            this.label6.Text = "Até:";
            // 
            // txtDataInicioImpressao
            // 
            this.txtDataInicioImpressao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDataInicioImpressao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataInicioImpressao.Location = new System.Drawing.Point(664, 650);
            this.txtDataInicioImpressao.Margin = new System.Windows.Forms.Padding(4);
            this.txtDataInicioImpressao.Name = "txtDataInicioImpressao";
            this.txtDataInicioImpressao.Size = new System.Drawing.Size(107, 26);
            this.txtDataInicioImpressao.TabIndex = 50;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(540, 654);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 20);
            this.label7.TabIndex = 49;
            this.label7.Text = "Período - De:";
            // 
            // lblTotalCarne
            // 
            this.lblTotalCarne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalCarne.AutoSize = true;
            this.lblTotalCarne.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCarne.ForeColor = System.Drawing.Color.Black;
            this.lblTotalCarne.Location = new System.Drawing.Point(209, 650);
            this.lblTotalCarne.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalCarne.Name = "lblTotalCarne";
            this.lblTotalCarne.Size = new System.Drawing.Size(0, 20);
            this.lblTotalCarne.TabIndex = 54;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(64, 650);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 20);
            this.label10.TabIndex = 53;
            this.label10.Text = "Total Carnê:";
            // 
            // frmListagemVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 703);
            this.Controls.Add(this.lblTotalCarne);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDataFimImpressao);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDataInicioImpressao);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblTotalDesconto);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnImprimirVenda);
            this.Controls.Add(this.pnlFiltro);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalCartao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotalDinheiro);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lblQtdeTotal);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rgvVenda);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmListagemVendas";
            this.Text = "Vendas realizadas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListagemVendas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvVenda)).EndInit();
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView rgvVenda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblTotalDinheiro;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblQtdeTotal;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblTotalCartao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel pnlFiltro;
        private System.Windows.Forms.TextBox txtDataFim;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDataInicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnImprimirVenda;
        private System.Windows.Forms.Label lblTotalDesconto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDataFimImpressao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDataInicioImpressao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewImageColumn imprimir;
        private System.Windows.Forms.Label lblTotalCarne;
        private System.Windows.Forms.Label label10;
    }
}