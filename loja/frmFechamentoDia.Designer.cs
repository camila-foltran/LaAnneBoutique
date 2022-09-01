namespace loja
{
    partial class frmFechamentoDia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFechamentoDia));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValorCaixa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFecharCaixa = new System.Windows.Forms.Button();
            this.pnlFechamento = new System.Windows.Forms.Panel();
            this.lblValorDinheiro = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblValorAbertura = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigoVendedorFechamento = new System.Windows.Forms.TextBox();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlAbertura = new System.Windows.Forms.Panel();
            this.txtCodigoVendedorAbertura = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAbrirCaixa = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDataAbertura = new System.Windows.Forms.Label();
            this.txtTroco = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblAvisoAbertura = new System.Windows.Forms.Label();
            this.pnlFechamento.SuspendLayout();
            this.pnlAbertura.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código Vendedor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(259, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data:";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(298, 27);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(0, 16);
            this.lblData.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Informe o valor do caixa:";
            // 
            // txtValorCaixa
            // 
            this.txtValorCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorCaixa.Location = new System.Drawing.Point(156, 62);
            this.txtValorCaixa.MaxLength = 10;
            this.txtValorCaixa.Name = "txtValorCaixa";
            this.txtValorCaixa.Size = new System.Drawing.Size(100, 22);
            this.txtValorCaixa.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fechamento do Caixa";
            // 
            // btnFecharCaixa
            // 
            this.btnFecharCaixa.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnFecharCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFecharCaixa.Image = ((System.Drawing.Image)(resources.GetObject("btnFecharCaixa.Image")));
            this.btnFecharCaixa.Location = new System.Drawing.Point(156, 178);
            this.btnFecharCaixa.Name = "btnFecharCaixa";
            this.btnFecharCaixa.Size = new System.Drawing.Size(121, 39);
            this.btnFecharCaixa.TabIndex = 7;
            this.btnFecharCaixa.Text = "Salvar";
            this.btnFecharCaixa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFecharCaixa.UseVisualStyleBackColor = false;
            this.btnFecharCaixa.Click += new System.EventHandler(this.btnFecharCaixa_Click);
            // 
            // pnlFechamento
            // 
            this.pnlFechamento.Controls.Add(this.lblValorDinheiro);
            this.pnlFechamento.Controls.Add(this.label9);
            this.pnlFechamento.Controls.Add(this.lblValorAbertura);
            this.pnlFechamento.Controls.Add(this.label5);
            this.pnlFechamento.Controls.Add(this.txtCodigoVendedorFechamento);
            this.pnlFechamento.Controls.Add(this.txtObs);
            this.pnlFechamento.Controls.Add(this.label7);
            this.pnlFechamento.Controls.Add(this.label4);
            this.pnlFechamento.Controls.Add(this.label1);
            this.pnlFechamento.Controls.Add(this.btnFecharCaixa);
            this.pnlFechamento.Controls.Add(this.label2);
            this.pnlFechamento.Controls.Add(this.lblData);
            this.pnlFechamento.Controls.Add(this.txtValorCaixa);
            this.pnlFechamento.Controls.Add(this.label3);
            this.pnlFechamento.Location = new System.Drawing.Point(9, 12);
            this.pnlFechamento.Name = "pnlFechamento";
            this.pnlFechamento.Size = new System.Drawing.Size(474, 409);
            this.pnlFechamento.TabIndex = 10;
            this.pnlFechamento.Visible = false;
            // 
            // lblValorDinheiro
            // 
            this.lblValorDinheiro.AutoSize = true;
            this.lblValorDinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDinheiro.Location = new System.Drawing.Point(235, 116);
            this.lblValorDinheiro.Name = "lblValorDinheiro";
            this.lblValorDinheiro.Size = new System.Drawing.Size(0, 16);
            this.lblValorDinheiro.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(190, 16);
            this.label9.TabIndex = 13;
            this.label9.Text = "Valor das vendas em dinheiro:";
            // 
            // lblValorAbertura
            // 
            this.lblValorAbertura.AutoSize = true;
            this.lblValorAbertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorAbertura.Location = new System.Drawing.Point(241, 93);
            this.lblValorAbertura.Name = "lblValorAbertura";
            this.lblValorAbertura.Size = new System.Drawing.Size(0, 16);
            this.lblValorAbertura.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(232, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Valor registrado na abertura do caixa:";
            // 
            // txtCodigoVendedorFechamento
            // 
            this.txtCodigoVendedorFechamento.Location = new System.Drawing.Point(156, 27);
            this.txtCodigoVendedorFechamento.Name = "txtCodigoVendedorFechamento";
            this.txtCodigoVendedorFechamento.Size = new System.Drawing.Size(97, 20);
            this.txtCodigoVendedorFechamento.TabIndex = 4;
            // 
            // txtObs
            // 
            this.txtObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObs.Location = new System.Drawing.Point(156, 147);
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(312, 22);
            this.txtObs.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Observação:";
            // 
            // pnlAbertura
            // 
            this.pnlAbertura.Controls.Add(this.lblAvisoAbertura);
            this.pnlAbertura.Controls.Add(this.txtCodigoVendedorAbertura);
            this.pnlAbertura.Controls.Add(this.label6);
            this.pnlAbertura.Controls.Add(this.label8);
            this.pnlAbertura.Controls.Add(this.btnAbrirCaixa);
            this.pnlAbertura.Controls.Add(this.label11);
            this.pnlAbertura.Controls.Add(this.lblDataAbertura);
            this.pnlAbertura.Controls.Add(this.txtTroco);
            this.pnlAbertura.Controls.Add(this.label13);
            this.pnlAbertura.Location = new System.Drawing.Point(489, 13);
            this.pnlAbertura.Name = "pnlAbertura";
            this.pnlAbertura.Size = new System.Drawing.Size(474, 408);
            this.pnlAbertura.TabIndex = 11;
            // 
            // txtCodigoVendedorAbertura
            // 
            this.txtCodigoVendedorAbertura.Location = new System.Drawing.Point(160, 26);
            this.txtCodigoVendedorAbertura.Name = "txtCodigoVendedorAbertura";
            this.txtCodigoVendedorAbertura.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoVendedorAbertura.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Abertura de Caixa";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Código Vendedor:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // btnAbrirCaixa
            // 
            this.btnAbrirCaixa.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnAbrirCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirCaixa.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrirCaixa.Image")));
            this.btnAbrirCaixa.Location = new System.Drawing.Point(160, 116);
            this.btnAbrirCaixa.Name = "btnAbrirCaixa";
            this.btnAbrirCaixa.Size = new System.Drawing.Size(121, 39);
            this.btnAbrirCaixa.TabIndex = 3;
            this.btnAbrirCaixa.Text = "Salvar";
            this.btnAbrirCaixa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbrirCaixa.UseVisualStyleBackColor = false;
            this.btnAbrirCaixa.Click += new System.EventHandler(this.btnAbrirCaixa_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(266, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 17);
            this.label11.TabIndex = 2;
            this.label11.Text = "Data:";
            // 
            // lblDataAbertura
            // 
            this.lblDataAbertura.AutoSize = true;
            this.lblDataAbertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataAbertura.Location = new System.Drawing.Point(308, 27);
            this.lblDataAbertura.Name = "lblDataAbertura";
            this.lblDataAbertura.Size = new System.Drawing.Size(0, 15);
            this.lblDataAbertura.TabIndex = 3;
            // 
            // txtTroco
            // 
            this.txtTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTroco.Location = new System.Drawing.Point(161, 64);
            this.txtTroco.MaxLength = 10;
            this.txtTroco.Name = "txtTroco";
            this.txtTroco.Size = new System.Drawing.Size(100, 23);
            this.txtTroco.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(162, 17);
            this.label13.TabIndex = 4;
            this.label13.Text = "Informe o valor do troco:";
            // 
            // lblAvisoAbertura
            // 
            this.lblAvisoAbertura.AutoSize = true;
            this.lblAvisoAbertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvisoAbertura.ForeColor = System.Drawing.Color.Red;
            this.lblAvisoAbertura.Location = new System.Drawing.Point(10, 96);
            this.lblAvisoAbertura.Name = "lblAvisoAbertura";
            this.lblAvisoAbertura.Size = new System.Drawing.Size(0, 17);
            this.lblAvisoAbertura.TabIndex = 7;
            // 
            // frmFechamentoDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 478);
            this.Controls.Add(this.pnlAbertura);
            this.Controls.Add(this.pnlFechamento);
            this.Name = "frmFechamentoDia";
            this.Text = "Fechamento de caixa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFechamentoDia_Load);
            this.pnlFechamento.ResumeLayout(false);
            this.pnlFechamento.PerformLayout();
            this.pnlAbertura.ResumeLayout(false);
            this.pnlAbertura.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtValorCaixa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFecharCaixa;
        private System.Windows.Forms.Panel pnlFechamento;
        private System.Windows.Forms.Panel pnlAbertura;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAbrirCaixa;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDataAbertura;
        private System.Windows.Forms.TextBox txtTroco;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCodigoVendedorAbertura;
        private System.Windows.Forms.TextBox txtCodigoVendedorFechamento;
        private System.Windows.Forms.Label lblValorAbertura;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblValorDinheiro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblAvisoAbertura;
    }
}