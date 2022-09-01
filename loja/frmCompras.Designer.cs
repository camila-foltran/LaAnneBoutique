namespace loja
{
    partial class frmCompras
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
            this.rgvMes = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.rgvCompras = new System.Windows.Forms.DataGridView();
            this.pnlAno = new System.Windows.Forms.Panel();
            this.rgvAno = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlMes = new System.Windows.Forms.Panel();
            this.btnVoltarMes = new System.Windows.Forms.Button();
            this.lblMes = new System.Windows.Forms.Label();
            this.pnlDia = new System.Windows.Forms.Panel();
            this.btnVoltarDia = new System.Windows.Forms.Button();
            this.lblDias = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rgvMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvCompras)).BeginInit();
            this.pnlAno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvAno)).BeginInit();
            this.pnlMes.SuspendLayout();
            this.pnlDia.SuspendLayout();
            this.SuspendLayout();
            // 
            // rgvMes
            // 
            this.rgvMes.AllowUserToAddRows = false;
            this.rgvMes.AllowUserToDeleteRows = false;
            this.rgvMes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rgvMes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn1});
            this.rgvMes.Location = new System.Drawing.Point(9, 38);
            this.rgvMes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rgvMes.Name = "rgvMes";
            this.rgvMes.ReadOnly = true;
            this.rgvMes.Size = new System.Drawing.Size(1309, 554);
            this.rgvMes.TabIndex = 67;
            this.rgvMes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rgvMes_CellContentClick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::loja.Properties.Resources.lupa;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 40;
            // 
            // rgvCompras
            // 
            this.rgvCompras.AllowUserToAddRows = false;
            this.rgvCompras.AllowUserToDeleteRows = false;
            this.rgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rgvCompras.Location = new System.Drawing.Point(9, 43);
            this.rgvCompras.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rgvCompras.Name = "rgvCompras";
            this.rgvCompras.ReadOnly = true;
            this.rgvCompras.Size = new System.Drawing.Size(1313, 546);
            this.rgvCompras.TabIndex = 68;
            // 
            // pnlAno
            // 
            this.pnlAno.Controls.Add(this.rgvAno);
            this.pnlAno.Location = new System.Drawing.Point(16, 15);
            this.pnlAno.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlAno.Name = "pnlAno";
            this.pnlAno.Size = new System.Drawing.Size(1328, 666);
            this.pnlAno.TabIndex = 69;
            // 
            // rgvAno
            // 
            this.rgvAno.AllowUserToAddRows = false;
            this.rgvAno.AllowUserToDeleteRows = false;
            this.rgvAno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rgvAno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.rgvAno.Location = new System.Drawing.Point(0, 4);
            this.rgvAno.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rgvAno.Name = "rgvAno";
            this.rgvAno.ReadOnly = true;
            this.rgvAno.Size = new System.Drawing.Size(1319, 619);
            this.rgvAno.TabIndex = 67;
            this.rgvAno.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rgvAno_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Image = global::loja.Properties.Resources.lupa;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 40;
            // 
            // pnlMes
            // 
            this.pnlMes.Controls.Add(this.btnVoltarMes);
            this.pnlMes.Controls.Add(this.lblMes);
            this.pnlMes.Controls.Add(this.rgvMes);
            this.pnlMes.Location = new System.Drawing.Point(12, 15);
            this.pnlMes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlMes.Name = "pnlMes";
            this.pnlMes.Size = new System.Drawing.Size(1328, 666);
            this.pnlMes.TabIndex = 70;
            this.pnlMes.Visible = false;
            // 
            // btnVoltarMes
            // 
            this.btnVoltarMes.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnVoltarMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltarMes.Image = global::loja.Properties.Resources.voltar32;
            this.btnVoltarMes.Location = new System.Drawing.Point(1141, 599);
            this.btnVoltarMes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVoltarMes.Name = "btnVoltarMes";
            this.btnVoltarMes.Size = new System.Drawing.Size(177, 60);
            this.btnVoltarMes.TabIndex = 69;
            this.btnVoltarMes.Text = "Voltar";
            this.btnVoltarMes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoltarMes.UseVisualStyleBackColor = false;
            this.btnVoltarMes.Click += new System.EventHandler(this.btnVoltarMes_Click);
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes.Location = new System.Drawing.Point(11, 14);
            this.lblMes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(59, 20);
            this.lblMes.TabIndex = 68;
            this.lblMes.Text = "label1";
            // 
            // pnlDia
            // 
            this.pnlDia.Controls.Add(this.btnVoltarDia);
            this.pnlDia.Controls.Add(this.lblDias);
            this.pnlDia.Controls.Add(this.rgvCompras);
            this.pnlDia.Location = new System.Drawing.Point(12, 15);
            this.pnlDia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlDia.Name = "pnlDia";
            this.pnlDia.Size = new System.Drawing.Size(1328, 663);
            this.pnlDia.TabIndex = 71;
            this.pnlDia.Visible = false;
            // 
            // btnVoltarDia
            // 
            this.btnVoltarDia.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnVoltarDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltarDia.Image = global::loja.Properties.Resources.voltar32;
            this.btnVoltarDia.Location = new System.Drawing.Point(1141, 597);
            this.btnVoltarDia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVoltarDia.Name = "btnVoltarDia";
            this.btnVoltarDia.Size = new System.Drawing.Size(181, 48);
            this.btnVoltarDia.TabIndex = 70;
            this.btnVoltarDia.Text = "Voltar";
            this.btnVoltarDia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoltarDia.UseVisualStyleBackColor = false;
            this.btnVoltarDia.Click += new System.EventHandler(this.btnVoltarDia_Click);
            // 
            // lblDias
            // 
            this.lblDias.AutoSize = true;
            this.lblDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDias.Location = new System.Drawing.Point(5, 18);
            this.lblDias.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDias.Name = "lblDias";
            this.lblDias.Size = new System.Drawing.Size(59, 20);
            this.lblDias.TabIndex = 69;
            this.lblDias.Text = "label1";
            // 
            // frmCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 694);
            this.Controls.Add(this.pnlMes);
            this.Controls.Add(this.pnlDia);
            this.Controls.Add(this.pnlAno);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmCompras";
            this.Text = "Compras realizadas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.rgvMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvCompras)).EndInit();
            this.pnlAno.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgvAno)).EndInit();
            this.pnlMes.ResumeLayout(false);
            this.pnlMes.PerformLayout();
            this.pnlDia.ResumeLayout(false);
            this.pnlDia.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView rgvMes;
        private System.Windows.Forms.DataGridView rgvCompras;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Panel pnlAno;
        private System.Windows.Forms.Panel pnlMes;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.Panel pnlDia;
        private System.Windows.Forms.Label lblDias;
        private System.Windows.Forms.Button btnVoltarDia;
        private System.Windows.Forms.DataGridView rgvAno;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.Button btnVoltarMes;
    }
}