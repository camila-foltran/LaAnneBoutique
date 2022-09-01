namespace loja
{
    partial class frmVendasVendedor
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
            this.rgvVenda = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rgvVenda)).BeginInit();
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
            this.rgvVenda.Location = new System.Drawing.Point(12, 42);
            this.rgvVenda.Name = "rgvVenda";
            this.rgvVenda.ReadOnly = true;
            this.rgvVenda.Size = new System.Drawing.Size(446, 449);
            this.rgvVenda.TabIndex = 31;
            this.rgvVenda.Visible = false;
            // 
            // frmVendasVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 518);
            this.Controls.Add(this.rgvVenda);
            this.Name = "frmVendasVendedor";
            this.Text = "frmVendasVendedor";
            ((System.ComponentModel.ISupportInitialize)(this.rgvVenda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView rgvVenda;
    }
}