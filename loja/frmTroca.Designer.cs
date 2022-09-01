namespace loja
{
    partial class frmTroca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTroca));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnTrocar = new System.Windows.Forms.Button();
            this.btnCancelarTroca = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigoTroca = new System.Windows.Forms.TextBox();
            this.ddlProdutoTroca = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalTroca = new System.Windows.Forms.Label();
            this.rgvProdutosTroca = new System.Windows.Forms.DataGridView();
            this.Excluir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rgvProdutosNovaVenda = new System.Windows.Forms.DataGridView();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.ddlProdutoVenda = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodigoVenda = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ddlCartao = new System.Windows.Forms.ComboBox();
            this.txtValorDinheiro = new System.Windows.Forms.TextBox();
            this.lblValorDinheiro = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblTroco = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAcrescimo = new System.Windows.Forms.TextBox();
            this.txtCodigoVendedor = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtValorRecebido = new System.Windows.Forms.TextBox();
            this.lblValorRecebido = new System.Windows.Forms.Label();
            this.ddlFormaPagto = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalVenda = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvProdutosTroca)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvProdutosNovaVenda)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTrocar
            // 
            this.btnTrocar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnTrocar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrocar.ForeColor = System.Drawing.Color.Black;
            this.btnTrocar.Image = ((System.Drawing.Image)(resources.GetObject("btnTrocar.Image")));
            this.btnTrocar.Location = new System.Drawing.Point(6, 375);
            this.btnTrocar.Name = "btnTrocar";
            this.btnTrocar.Size = new System.Drawing.Size(121, 43);
            this.btnTrocar.TabIndex = 35;
            this.btnTrocar.Text = "Finalizar Troca";
            this.btnTrocar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTrocar.UseVisualStyleBackColor = false;
            this.btnTrocar.Click += new System.EventHandler(this.btnTrocar_Click);
            // 
            // btnCancelarTroca
            // 
            this.btnCancelarTroca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancelarTroca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarTroca.ForeColor = System.Drawing.Color.Black;
            this.btnCancelarTroca.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarTroca.Image")));
            this.btnCancelarTroca.Location = new System.Drawing.Point(133, 375);
            this.btnCancelarTroca.Name = "btnCancelarTroca";
            this.btnCancelarTroca.Size = new System.Drawing.Size(127, 43);
            this.btnCancelarTroca.TabIndex = 38;
            this.btnCancelarTroca.Text = "Cancelar Troca";
            this.btnCancelarTroca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelarTroca.UseVisualStyleBackColor = false;
            this.btnCancelarTroca.Click += new System.EventHandler(this.btnCancelarTroca_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 43;
            this.label1.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(146, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 44;
            this.label2.Text = "Produto";
            // 
            // txtCodigoTroca
            // 
            this.txtCodigoTroca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtCodigoTroca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCodigoTroca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoTroca.Location = new System.Drawing.Point(6, 33);
            this.txtCodigoTroca.MaxLength = 50;
            this.txtCodigoTroca.Name = "txtCodigoTroca";
            this.txtCodigoTroca.Size = new System.Drawing.Size(134, 23);
            this.txtCodigoTroca.TabIndex = 45;
            this.txtCodigoTroca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoTroca_KeyDown);
            // 
            // ddlProdutoTroca
            // 
            this.ddlProdutoTroca.DropDownWidth = 250;
            this.ddlProdutoTroca.FormattingEnabled = true;
            this.ddlProdutoTroca.Location = new System.Drawing.Point(149, 33);
            this.ddlProdutoTroca.Name = "ddlProdutoTroca";
            this.ddlProdutoTroca.Size = new System.Drawing.Size(528, 21);
            this.ddlProdutoTroca.TabIndex = 46;
            this.ddlProdutoTroca.SelectedIndexChanged += new System.EventHandler(this.ddlProdutoTroca_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTotalTroca);
            this.panel1.Controls.Add(this.rgvProdutosTroca);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ddlProdutoTroca);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCodigoTroca);
            this.panel1.Location = new System.Drawing.Point(12, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 232);
            this.panel1.TabIndex = 49;
            // 
            // lblTotalTroca
            // 
            this.lblTotalTroca.AutoSize = true;
            this.lblTotalTroca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTroca.ForeColor = System.Drawing.Color.Black;
            this.lblTotalTroca.Location = new System.Drawing.Point(50, 208);
            this.lblTotalTroca.Name = "lblTotalTroca";
            this.lblTotalTroca.Size = new System.Drawing.Size(0, 17);
            this.lblTotalTroca.TabIndex = 54;
            // 
            // rgvProdutosTroca
            // 
            this.rgvProdutosTroca.AllowUserToAddRows = false;
            this.rgvProdutosTroca.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvProdutosTroca.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.rgvProdutosTroca.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rgvProdutosTroca.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rgvProdutosTroca.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.rgvProdutosTroca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rgvProdutosTroca.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Excluir});
            this.rgvProdutosTroca.Location = new System.Drawing.Point(6, 69);
            this.rgvProdutosTroca.Name = "rgvProdutosTroca";
            this.rgvProdutosTroca.ReadOnly = true;
            this.rgvProdutosTroca.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rgvProdutosTroca.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue;
            this.rgvProdutosTroca.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.rgvProdutosTroca.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvProdutosTroca.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
            this.rgvProdutosTroca.Size = new System.Drawing.Size(671, 127);
            this.rgvProdutosTroca.TabIndex = 47;
            this.rgvProdutosTroca.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rgvProdutosTroca_CellContentClick);
            // 
            // Excluir
            // 
            this.Excluir.HeaderText = "";
            this.Excluir.Name = "Excluir";
            this.Excluir.ReadOnly = true;
            this.Excluir.Text = "Excluir";
            this.Excluir.UseColumnTextForButtonValue = true;
            this.Excluir.Width = 50;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(4, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 17);
            this.label7.TabIndex = 53;
            this.label7.Text = "Total:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 17);
            this.label3.TabIndex = 50;
            this.label3.Text = "Produto da Troca:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(13, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 17);
            this.label4.TabIndex = 52;
            this.label4.Text = "Novo Produto:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblTotalVenda);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.rgvProdutosNovaVenda);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.ddlProdutoVenda);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtCodigoVenda);
            this.panel2.Location = new System.Drawing.Point(13, 295);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(686, 231);
            this.panel2.TabIndex = 51;
            // 
            // rgvProdutosNovaVenda
            // 
            this.rgvProdutosNovaVenda.AllowUserToAddRows = false;
            this.rgvProdutosNovaVenda.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvProdutosNovaVenda.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.rgvProdutosNovaVenda.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rgvProdutosNovaVenda.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rgvProdutosNovaVenda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.rgvProdutosNovaVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rgvProdutosNovaVenda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewButtonColumn1});
            this.rgvProdutosNovaVenda.Location = new System.Drawing.Point(6, 70);
            this.rgvProdutosNovaVenda.Name = "rgvProdutosNovaVenda";
            this.rgvProdutosNovaVenda.ReadOnly = true;
            this.rgvProdutosNovaVenda.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rgvProdutosNovaVenda.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Blue;
            this.rgvProdutosNovaVenda.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.rgvProdutosNovaVenda.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvProdutosNovaVenda.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
            this.rgvProdutosNovaVenda.Size = new System.Drawing.Size(671, 127);
            this.rgvProdutosNovaVenda.TabIndex = 48;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Text = "Excluir";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(3, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 43;
            this.label5.Text = "Código";
            // 
            // ddlProdutoVenda
            // 
            this.ddlProdutoVenda.DropDownWidth = 250;
            this.ddlProdutoVenda.FormattingEnabled = true;
            this.ddlProdutoVenda.Location = new System.Drawing.Point(149, 33);
            this.ddlProdutoVenda.Name = "ddlProdutoVenda";
            this.ddlProdutoVenda.Size = new System.Drawing.Size(528, 21);
            this.ddlProdutoVenda.TabIndex = 46;
            this.ddlProdutoVenda.SelectedIndexChanged += new System.EventHandler(this.ddlProdutoVenda_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(146, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 17);
            this.label6.TabIndex = 44;
            this.label6.Text = "Produto";
            // 
            // txtCodigoVenda
            // 
            this.txtCodigoVenda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtCodigoVenda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCodigoVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoVenda.Location = new System.Drawing.Point(6, 33);
            this.txtCodigoVenda.MaxLength = 50;
            this.txtCodigoVenda.Name = "txtCodigoVenda";
            this.txtCodigoVenda.Size = new System.Drawing.Size(134, 23);
            this.txtCodigoVenda.TabIndex = 45;
            this.txtCodigoVenda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoVenda_KeyDown);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.ddlCartao);
            this.panel3.Controls.Add(this.txtValorDinheiro);
            this.panel3.Controls.Add(this.lblValorDinheiro);
            this.panel3.Controls.Add(this.txtCPF);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.btnCancelarTroca);
            this.panel3.Controls.Add(this.lblVendedor);
            this.panel3.Controls.Add(this.btnTrocar);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.lblTroco);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.lblTotalPagar);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.txtSubTotal);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.txtAcrescimo);
            this.panel3.Controls.Add(this.txtCodigoVendedor);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.txtDesconto);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txtValorRecebido);
            this.panel3.Controls.Add(this.lblValorRecebido);
            this.panel3.Controls.Add(this.ddlFormaPagto);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(705, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(272, 497);
            this.panel3.TabIndex = 53;
            // 
            // ddlCartao
            // 
            this.ddlCartao.DropDownWidth = 250;
            this.ddlCartao.FormattingEnabled = true;
            this.ddlCartao.Location = new System.Drawing.Point(4, 181);
            this.ddlCartao.Name = "ddlCartao";
            this.ddlCartao.Size = new System.Drawing.Size(139, 21);
            this.ddlCartao.TabIndex = 39;
            this.ddlCartao.Visible = false;
            // 
            // txtValorDinheiro
            // 
            this.txtValorDinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorDinheiro.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtValorDinheiro.Location = new System.Drawing.Point(146, 148);
            this.txtValorDinheiro.Name = "txtValorDinheiro";
            this.txtValorDinheiro.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtValorDinheiro.Size = new System.Drawing.Size(114, 23);
            this.txtValorDinheiro.TabIndex = 38;
            this.txtValorDinheiro.Visible = false;
            // 
            // lblValorDinheiro
            // 
            this.lblValorDinheiro.AutoSize = true;
            this.lblValorDinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDinheiro.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblValorDinheiro.Location = new System.Drawing.Point(3, 151);
            this.lblValorDinheiro.Name = "lblValorDinheiro";
            this.lblValorDinheiro.Size = new System.Drawing.Size(143, 17);
            this.lblValorDinheiro.TabIndex = 37;
            this.lblValorDinheiro.Text = "Valor em Dinheiro:";
            this.lblValorDinheiro.Visible = false;
            // 
            // txtCPF
            // 
            this.txtCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPF.Location = new System.Drawing.Point(146, 10);
            this.txtCPF.MaxLength = 50;
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(114, 23);
            this.txtCPF.TabIndex = 36;
            this.txtCPF.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(3, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(103, 17);
            this.label19.TabIndex = 35;
            this.label19.Text = "CPF do cliente:";
            this.label19.Visible = false;
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendedor.ForeColor = System.Drawing.Color.Black;
            this.lblVendedor.Location = new System.Drawing.Point(98, 69);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(0, 17);
            this.lblVendedor.TabIndex = 26;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(3, 69);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(92, 17);
            this.label18.TabIndex = 25;
            this.label18.Text = "Vendedor(a):";
            // 
            // lblTroco
            // 
            this.lblTroco.AutoSize = true;
            this.lblTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTroco.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTroco.Location = new System.Drawing.Point(141, 336);
            this.lblTroco.MinimumSize = new System.Drawing.Size(80, 0);
            this.lblTroco.Name = "lblTroco";
            this.lblTroco.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTroco.Size = new System.Drawing.Size(80, 17);
            this.lblTroco.TabIndex = 18;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DarkRed;
            this.label14.Location = new System.Drawing.Point(3, 336);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 17);
            this.label14.TabIndex = 17;
            this.label14.Text = "Troco:";
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.AutoSize = true;
            this.lblTotalPagar.BackColor = System.Drawing.Color.Blue;
            this.lblTotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagar.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblTotalPagar.Location = new System.Drawing.Point(133, 306);
            this.lblTotalPagar.MinimumSize = new System.Drawing.Size(127, 0);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalPagar.Size = new System.Drawing.Size(127, 17);
            this.lblTotalPagar.TabIndex = 16;
            this.lblTotalPagar.Text = "0,00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Blue;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.AliceBlue;
            this.label13.Location = new System.Drawing.Point(3, 306);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 17);
            this.label13.TabIndex = 15;
            this.label13.Text = "Total a Pagar:";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtSubTotal.Location = new System.Drawing.Point(146, 269);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSubTotal.Size = new System.Drawing.Size(114, 23);
            this.txtSubTotal.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(2, 275);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 17);
            this.label12.TabIndex = 13;
            this.label12.Text = "Sub Total:";
            // 
            // txtAcrescimo
            // 
            this.txtAcrescimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcrescimo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtAcrescimo.Location = new System.Drawing.Point(146, 240);
            this.txtAcrescimo.Name = "txtAcrescimo";
            this.txtAcrescimo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAcrescimo.Size = new System.Drawing.Size(114, 23);
            this.txtAcrescimo.TabIndex = 9;
            // 
            // txtCodigoVendedor
            // 
            this.txtCodigoVendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtCodigoVendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCodigoVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoVendedor.Location = new System.Drawing.Point(146, 38);
            this.txtCodigoVendedor.MaxLength = 50;
            this.txtCodigoVendedor.Name = "txtCodigoVendedor";
            this.txtCodigoVendedor.Size = new System.Drawing.Size(55, 23);
            this.txtCodigoVendedor.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(3, 246);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 17);
            this.label11.TabIndex = 11;
            this.label11.Text = "Acréscimo:";
            // 
            // txtDesconto
            // 
            this.txtDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesconto.ForeColor = System.Drawing.Color.Black;
            this.txtDesconto.Location = new System.Drawing.Point(146, 208);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesconto.Size = new System.Drawing.Size(114, 23);
            this.txtDesconto.TabIndex = 8;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(3, 44);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(140, 17);
            this.label17.TabIndex = 22;
            this.label17.Text = "Código Vendedor(a):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(3, 214);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "Desconto:";
            // 
            // txtValorRecebido
            // 
            this.txtValorRecebido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorRecebido.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtValorRecebido.Location = new System.Drawing.Point(146, 179);
            this.txtValorRecebido.Name = "txtValorRecebido";
            this.txtValorRecebido.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtValorRecebido.Size = new System.Drawing.Size(114, 23);
            this.txtValorRecebido.TabIndex = 7;
            // 
            // lblValorRecebido
            // 
            this.lblValorRecebido.AutoSize = true;
            this.lblValorRecebido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorRecebido.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblValorRecebido.Location = new System.Drawing.Point(3, 179);
            this.lblValorRecebido.Name = "lblValorRecebido";
            this.lblValorRecebido.Size = new System.Drawing.Size(124, 17);
            this.lblValorRecebido.TabIndex = 7;
            this.lblValorRecebido.Text = "Valor Recebido:";
            // 
            // ddlFormaPagto
            // 
            this.ddlFormaPagto.FormattingEnabled = true;
            this.ddlFormaPagto.Location = new System.Drawing.Point(4, 117);
            this.ddlFormaPagto.Name = "ddlFormaPagto";
            this.ddlFormaPagto.Size = new System.Drawing.Size(256, 21);
            this.ddlFormaPagto.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(3, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Forma de Pagamento:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(2, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 17);
            this.label9.TabIndex = 54;
            this.label9.Text = "Total:";
            // 
            // lblTotalVenda
            // 
            this.lblTotalVenda.AutoSize = true;
            this.lblTotalVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVenda.ForeColor = System.Drawing.Color.Black;
            this.lblTotalVenda.Location = new System.Drawing.Point(49, 204);
            this.lblTotalVenda.Name = "lblTotalVenda";
            this.lblTotalVenda.Size = new System.Drawing.Size(0, 17);
            this.lblTotalVenda.TabIndex = 55;
            // 
            // frmTroca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 571);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Name = "frmTroca";
            this.Text = "Troca de Produtos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvProdutosTroca)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvProdutosNovaVenda)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnTrocar;
        private System.Windows.Forms.Button btnCancelarTroca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtCodigoTroca;
        private System.Windows.Forms.ComboBox ddlProdutoTroca;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ddlProdutoVenda;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtCodigoVenda;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox ddlCartao;
        private System.Windows.Forms.TextBox txtValorDinheiro;
        private System.Windows.Forms.Label lblValorDinheiro;
        public System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblTroco;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAcrescimo;
        private System.Windows.Forms.TextBox txtCodigoVendedor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDesconto;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtValorRecebido;
        private System.Windows.Forms.Label lblValorRecebido;
        private System.Windows.Forms.ComboBox ddlFormaPagto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView rgvProdutosNovaVenda;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridView rgvProdutosTroca;
        private System.Windows.Forms.DataGridViewButtonColumn Excluir;
        private System.Windows.Forms.Label lblTotalTroca;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalVenda;
        private System.Windows.Forms.Label label9;
    }
}