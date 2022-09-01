namespace loja
{
    partial class frmEstatistica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstatistica));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlVendedor = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rgvTotais = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.vendaVendedor = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlTotais = new System.Windows.Forms.Panel();
            this.rgvVendedor = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rgvVenda = new System.Windows.Forms.DataGridView();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.rgvTotalMes = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.lblTituloVendedor = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.rgvAno = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlVendedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvTotais)).BeginInit();
            this.pnlTotais.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvVendedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvVenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvTotalMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvAno)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlVendedor
            // 
            this.pnlVendedor.Controls.Add(this.pictureBox1);
            this.pnlVendedor.Controls.Add(this.btnEntrar);
            this.pnlVendedor.Controls.Add(this.label3);
            this.pnlVendedor.Controls.Add(this.txtSenha);
            this.pnlVendedor.Controls.Add(this.label2);
            this.pnlVendedor.Controls.Add(this.txtLogin);
            this.pnlVendedor.Controls.Add(this.label1);
            this.pnlVendedor.Location = new System.Drawing.Point(5, 5);
            this.pnlVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.pnlVendedor.Name = "pnlVendedor";
            this.pnlVendedor.Size = new System.Drawing.Size(1289, 106);
            this.pnlVendedor.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 31);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnEntrar
            // 
            this.btnEntrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEntrar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrar.Image = ((System.Drawing.Image)(resources.GetObject("btnEntrar.Image")));
            this.btnEntrar.Location = new System.Drawing.Point(915, 38);
            this.btnEntrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(201, 43);
            this.btnEntrar.TabIndex = 6;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEntrar.UseVisualStyleBackColor = false;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Acesso Restrito ao vendedor";
            // 
            // txtSenha
            // 
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(677, 46);
            this.txtSenha.Margin = new System.Windows.Forms.Padding(4);
            this.txtSenha.MaxLength = 50;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(216, 26);
            this.txtSenha.TabIndex = 3;
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(509, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Informe sua senha:";
            // 
            // txtLogin
            // 
            this.txtLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogin.Location = new System.Drawing.Point(284, 46);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(4);
            this.txtLogin.MaxLength = 50;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(216, 26);
            this.txtLogin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(105, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Informe seu usuário:";
            // 
            // rgvTotais
            // 
            this.rgvTotais.AllowUserToAddRows = false;
            this.rgvTotais.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.rgvTotais.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.rgvTotais.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rgvTotais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rgvTotais.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.vendaVendedor});
            this.rgvTotais.Location = new System.Drawing.Point(0, 68);
            this.rgvTotais.Margin = new System.Windows.Forms.Padding(4);
            this.rgvTotais.Name = "rgvTotais";
            this.rgvTotais.ReadOnly = true;
            this.rgvTotais.Size = new System.Drawing.Size(1271, 527);
            this.rgvTotais.TabIndex = 24;
            this.rgvTotais.Visible = false;
            this.rgvTotais.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rgvTotais_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Image = ((System.Drawing.Image)(resources.GetObject("Column1.Image")));
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // vendaVendedor
            // 
            this.vendaVendedor.HeaderText = "";
            this.vendaVendedor.Image = global::loja.Properties.Resources.menu_relParceiro;
            this.vendaVendedor.Name = "vendaVendedor";
            this.vendaVendedor.ReadOnly = true;
            this.vendaVendedor.ToolTipText = "Visualizar total vendido por venda";
            this.vendaVendedor.Width = 50;
            // 
            // pnlTotais
            // 
            this.pnlTotais.Controls.Add(this.rgvAno);
            this.pnlTotais.Controls.Add(this.rgvVendedor);
            this.pnlTotais.Controls.Add(this.lblTotal);
            this.pnlTotais.Controls.Add(this.label4);
            this.pnlTotais.Controls.Add(this.rgvVenda);
            this.pnlTotais.Controls.Add(this.btnVoltar);
            this.pnlTotais.Controls.Add(this.rgvTotalMes);
            this.pnlTotais.Controls.Add(this.lblVendedor);
            this.pnlTotais.Controls.Add(this.lblTituloVendedor);
            this.pnlTotais.Controls.Add(this.lblTitulo);
            this.pnlTotais.Controls.Add(this.rgvTotais);
            this.pnlTotais.Location = new System.Drawing.Point(5, 5);
            this.pnlTotais.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTotais.Name = "pnlTotais";
            this.pnlTotais.Size = new System.Drawing.Size(1289, 683);
            this.pnlTotais.TabIndex = 25;
            this.pnlTotais.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTotais_Paint);
            // 
            // rgvVendedor
            // 
            this.rgvVendedor.AllowUserToAddRows = false;
            this.rgvVendedor.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            this.rgvVendedor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.rgvVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rgvVendedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rgvVendedor.Location = new System.Drawing.Point(0, 68);
            this.rgvVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.rgvVendedor.Name = "rgvVendedor";
            this.rgvVendedor.ReadOnly = true;
            this.rgvVendedor.Size = new System.Drawing.Size(1271, 527);
            this.rgvVendedor.TabIndex = 33;
            this.rgvVendedor.Visible = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(105, 631);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 20);
            this.lblTotal.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 631);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 31;
            this.label4.Text = "TOTAL:";
            // 
            // rgvVenda
            // 
            this.rgvVenda.AllowUserToAddRows = false;
            this.rgvVenda.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            this.rgvVenda.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.rgvVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rgvVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rgvVenda.Location = new System.Drawing.Point(0, 67);
            this.rgvVenda.Margin = new System.Windows.Forms.Padding(4);
            this.rgvVenda.Name = "rgvVenda";
            this.rgvVenda.ReadOnly = true;
            this.rgvVenda.Size = new System.Drawing.Size(1271, 528);
            this.rgvVenda.TabIndex = 30;
            this.rgvVenda.Visible = false;
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Image = global::loja.Properties.Resources.voltar32;
            this.btnVoltar.Location = new System.Drawing.Point(1089, 618);
            this.btnVoltar.Margin = new System.Windows.Forms.Padding(4);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(181, 48);
            this.btnVoltar.TabIndex = 29;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Visible = false;
            this.btnVoltar.Click += new System.EventHandler(this.button1_Click);
            // 
            // rgvTotalMes
            // 
            this.rgvTotalMes.AllowUserToAddRows = false;
            this.rgvTotalMes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            this.rgvTotalMes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.rgvTotalMes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rgvTotalMes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rgvTotalMes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn1});
            this.rgvTotalMes.Location = new System.Drawing.Point(0, 67);
            this.rgvTotalMes.Margin = new System.Windows.Forms.Padding(4);
            this.rgvTotalMes.Name = "rgvTotalMes";
            this.rgvTotalMes.ReadOnly = true;
            this.rgvTotalMes.Size = new System.Drawing.Size(1267, 528);
            this.rgvTotalMes.TabIndex = 28;
            this.rgvTotalMes.Visible = false;
            this.rgvTotalMes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rgvTotalMes_CellContentClick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendedor.Location = new System.Drawing.Point(141, 43);
            this.lblVendedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(0, 20);
            this.lblVendedor.TabIndex = 27;
            // 
            // lblTituloVendedor
            // 
            this.lblTituloVendedor.AutoSize = true;
            this.lblTituloVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloVendedor.Location = new System.Drawing.Point(11, 43);
            this.lblTituloVendedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloVendedor.Name = "lblTituloVendedor";
            this.lblTituloVendedor.Size = new System.Drawing.Size(106, 20);
            this.lblTituloVendedor.TabIndex = 26;
            this.lblTituloVendedor.Text = "Vendedor(a):";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(11, 17);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(327, 20);
            this.lblTitulo.TabIndex = 25;
            this.lblTitulo.Text = "Listagem de vendas referente ao ano ";
            // 
            // rgvAno
            // 
            this.rgvAno.AllowUserToAddRows = false;
            this.rgvAno.AllowUserToDeleteRows = false;
            this.rgvAno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rgvAno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn2});
            this.rgvAno.Location = new System.Drawing.Point(0, 67);
            this.rgvAno.Margin = new System.Windows.Forms.Padding(4);
            this.rgvAno.Name = "rgvAno";
            this.rgvAno.ReadOnly = true;
            this.rgvAno.Size = new System.Drawing.Size(1270, 528);
            this.rgvAno.TabIndex = 68;
            this.rgvAno.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rgvAno_CellContentClick);
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::loja.Properties.Resources.lupa;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Width = 40;
            // 
            // frmEstatistica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 703);
            this.Controls.Add(this.pnlTotais);
            this.Controls.Add(this.pnlVendedor);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEstatistica";
            this.Text = "Estatísticas das vendas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEstatistica_Load);
            this.pnlVendedor.ResumeLayout(false);
            this.pnlVendedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvTotais)).EndInit();
            this.pnlTotais.ResumeLayout(false);
            this.pnlTotais.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvVendedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvVenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvTotalMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvAno)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlVendedor;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView rgvTotais;
        private System.Windows.Forms.Panel pnlTotais;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Label lblTituloVendedor;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView rgvTotalMes;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.DataGridView rgvVenda;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView rgvVendedor;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewImageColumn vendaVendedor;
        private System.Windows.Forms.DataGridView rgvAno;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
    }
}