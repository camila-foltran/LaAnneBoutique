namespace loja
{
    partial class frmEstoque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstoque));
            this.pnlListagem = new System.Windows.Forms.Panel();
            this.pnlSenha = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.btnVerTotais = new System.Windows.Forms.Button();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.lblValorTotalEstoque = new System.Windows.Forms.Label();
            this.lblQtdeTotal = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtMarcaFiltro = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCategoriaFiltro = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtReferenciaFiltro = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.rgvEstoque = new System.Windows.Forms.DataGridView();
            this.Adicionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Excluir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtCodigoFiltro = new System.Windows.Forms.TextBox();
            this.txtNomeFiltro = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlMovimento = new System.Windows.Forms.Panel();
            this.lblQtdeTotalProduto = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblCodProd = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.rgvEstoqueProduto = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.txtValorVenda = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtValorCusto = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtQtde = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTipoMovimento = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCor = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCodigoProduto = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblTamanho = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnlListagem.SuspendLayout();
            this.pnlSenha.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvEstoque)).BeginInit();
            this.pnlMovimento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvEstoqueProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlListagem
            // 
            this.pnlListagem.Controls.Add(this.pnlSenha);
            this.pnlListagem.Controls.Add(this.btnVerTotais);
            this.pnlListagem.Controls.Add(this.pnlTotal);
            this.pnlListagem.Controls.Add(this.txtMarcaFiltro);
            this.pnlListagem.Controls.Add(this.label18);
            this.pnlListagem.Controls.Add(this.txtCategoriaFiltro);
            this.pnlListagem.Controls.Add(this.label19);
            this.pnlListagem.Controls.Add(this.txtReferenciaFiltro);
            this.pnlListagem.Controls.Add(this.label20);
            this.pnlListagem.Controls.Add(this.rgvEstoque);
            this.pnlListagem.Controls.Add(this.btnPesquisar);
            this.pnlListagem.Controls.Add(this.txtCodigoFiltro);
            this.pnlListagem.Controls.Add(this.txtNomeFiltro);
            this.pnlListagem.Controls.Add(this.label12);
            this.pnlListagem.Controls.Add(this.label13);
            this.pnlListagem.Controls.Add(this.label9);
            this.pnlListagem.Location = new System.Drawing.Point(-1, 2);
            this.pnlListagem.Margin = new System.Windows.Forms.Padding(4);
            this.pnlListagem.Name = "pnlListagem";
            this.pnlListagem.Size = new System.Drawing.Size(1356, 684);
            this.pnlListagem.TabIndex = 0;
            // 
            // pnlSenha
            // 
            this.pnlSenha.Controls.Add(this.button1);
            this.pnlSenha.Controls.Add(this.txtSenha);
            this.pnlSenha.Controls.Add(this.label24);
            this.pnlSenha.Location = new System.Drawing.Point(7, 626);
            this.pnlSenha.Name = "pnlSenha";
            this.pnlSenha.Size = new System.Drawing.Size(396, 58);
            this.pnlSenha.TabIndex = 47;
            this.pnlSenha.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::loja.Properties.Resources.menu_financeiro;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(230, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 32);
            this.button1.TabIndex = 61;
            this.button1.Text = "Ver Totais";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSenha
            // 
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(76, 5);
            this.txtSenha.Margin = new System.Windows.Forms.Padding(4);
            this.txtSenha.MaxLength = 20;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(132, 26);
            this.txtSenha.TabIndex = 60;
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(7, 8);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(61, 20);
            this.label24.TabIndex = 59;
            this.label24.Text = "Senha:";
            // 
            // btnVerTotais
            // 
            this.btnVerTotais.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnVerTotais.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerTotais.Image = global::loja.Properties.Resources.menu_financeiro;
            this.btnVerTotais.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerTotais.Location = new System.Drawing.Point(830, 629);
            this.btnVerTotais.Name = "btnVerTotais";
            this.btnVerTotais.Size = new System.Drawing.Size(161, 48);
            this.btnVerTotais.TabIndex = 0;
            this.btnVerTotais.Text = "Ver Totais";
            this.btnVerTotais.UseVisualStyleBackColor = false;
            this.btnVerTotais.Visible = false;
            this.btnVerTotais.Click += new System.EventHandler(this.btnVerTotais_Click);
            // 
            // pnlTotal
            // 
            this.pnlTotal.Controls.Add(this.button2);
            this.pnlTotal.Controls.Add(this.label22);
            this.pnlTotal.Controls.Add(this.lblValorTotalEstoque);
            this.pnlTotal.Controls.Add(this.lblQtdeTotal);
            this.pnlTotal.Controls.Add(this.label21);
            this.pnlTotal.Location = new System.Drawing.Point(8, 624);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(1344, 55);
            this.pnlTotal.TabIndex = 46;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::loja.Properties.Resources.Excluir;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(723, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 42);
            this.button2.TabIndex = 46;
            this.button2.Text = "Fechar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(4, 12);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(201, 20);
            this.label22.TabIndex = 42;
            this.label22.Text = "Qtde total em estoque:";
            // 
            // lblValorTotalEstoque
            // 
            this.lblValorTotalEstoque.AutoSize = true;
            this.lblValorTotalEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotalEstoque.Location = new System.Drawing.Point(549, 12);
            this.lblValorTotalEstoque.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorTotalEstoque.Name = "lblValorTotalEstoque";
            this.lblValorTotalEstoque.Size = new System.Drawing.Size(0, 20);
            this.lblValorTotalEstoque.TabIndex = 45;
            // 
            // lblQtdeTotal
            // 
            this.lblQtdeTotal.AutoSize = true;
            this.lblQtdeTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtdeTotal.Location = new System.Drawing.Point(238, 12);
            this.lblQtdeTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQtdeTotal.Name = "lblQtdeTotal";
            this.lblQtdeTotal.Size = new System.Drawing.Size(0, 20);
            this.lblQtdeTotal.TabIndex = 43;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(311, 12);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(205, 20);
            this.label21.TabIndex = 44;
            this.label21.Text = "Valor total em estoque:";
            // 
            // txtMarcaFiltro
            // 
            this.txtMarcaFiltro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtMarcaFiltro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtMarcaFiltro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMarcaFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarcaFiltro.Location = new System.Drawing.Point(731, 63);
            this.txtMarcaFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.txtMarcaFiltro.MaxLength = 50;
            this.txtMarcaFiltro.Name = "txtMarcaFiltro";
            this.txtMarcaFiltro.Size = new System.Drawing.Size(444, 26);
            this.txtMarcaFiltro.TabIndex = 41;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(631, 66);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(61, 20);
            this.label18.TabIndex = 40;
            this.label18.Text = "Marca:";
            // 
            // txtCategoriaFiltro
            // 
            this.txtCategoriaFiltro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtCategoriaFiltro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCategoriaFiltro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCategoriaFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoriaFiltro.Location = new System.Drawing.Point(731, 27);
            this.txtCategoriaFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.txtCategoriaFiltro.MaxLength = 50;
            this.txtCategoriaFiltro.Name = "txtCategoriaFiltro";
            this.txtCategoriaFiltro.Size = new System.Drawing.Size(444, 26);
            this.txtCategoriaFiltro.TabIndex = 39;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(631, 31);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 20);
            this.label19.TabIndex = 38;
            this.label19.Text = "Categoria:";
            // 
            // txtReferenciaFiltro
            // 
            this.txtReferenciaFiltro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtReferenciaFiltro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtReferenciaFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferenciaFiltro.Location = new System.Drawing.Point(472, 27);
            this.txtReferenciaFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.txtReferenciaFiltro.MaxLength = 50;
            this.txtReferenciaFiltro.Name = "txtReferenciaFiltro";
            this.txtReferenciaFiltro.Size = new System.Drawing.Size(149, 26);
            this.txtReferenciaFiltro.TabIndex = 37;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(367, 31);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(95, 20);
            this.label20.TabIndex = 36;
            this.label20.Text = "Referência:";
            // 
            // rgvEstoque
            // 
            this.rgvEstoque.AllowUserToAddRows = false;
            this.rgvEstoque.AllowUserToDeleteRows = false;
            this.rgvEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rgvEstoque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Adicionar,
            this.Excluir});
            this.rgvEstoque.Location = new System.Drawing.Point(8, 107);
            this.rgvEstoque.Margin = new System.Windows.Forms.Padding(4);
            this.rgvEstoque.Name = "rgvEstoque";
            this.rgvEstoque.ReadOnly = true;
            this.rgvEstoque.Size = new System.Drawing.Size(1344, 514);
            this.rgvEstoque.TabIndex = 35;
            this.rgvEstoque.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rgvEstoque_CellContentClick);
            // 
            // Adicionar
            // 
            this.Adicionar.HeaderText = "";
            this.Adicionar.Name = "Adicionar";
            this.Adicionar.ReadOnly = true;
            this.Adicionar.Text = "Adicionar";
            this.Adicionar.UseColumnTextForButtonValue = true;
            this.Adicionar.Width = 70;
            // 
            // Excluir
            // 
            this.Excluir.HeaderText = "";
            this.Excluir.Name = "Excluir";
            this.Excluir.ReadOnly = true;
            this.Excluir.Text = "Excluir";
            this.Excluir.UseColumnTextForButtonValue = true;
            this.Excluir.Width = 70;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.Location = new System.Drawing.Point(1184, 43);
            this.btnPesquisar.Margin = new System.Windows.Forms.Padding(4);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(168, 48);
            this.btnPesquisar.TabIndex = 34;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtCodigoFiltro
            // 
            this.txtCodigoFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoFiltro.Location = new System.Drawing.Point(164, 31);
            this.txtCodigoFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoFiltro.Name = "txtCodigoFiltro";
            this.txtCodigoFiltro.Size = new System.Drawing.Size(184, 26);
            this.txtCodigoFiltro.TabIndex = 31;
            this.txtCodigoFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoFiltro_KeyDown);
            // 
            // txtNomeFiltro
            // 
            this.txtNomeFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeFiltro.Location = new System.Drawing.Point(164, 63);
            this.txtNomeFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.txtNomeFiltro.Name = "txtNomeFiltro";
            this.txtNomeFiltro.Size = new System.Drawing.Size(457, 26);
            this.txtNomeFiltro.TabIndex = 30;
            this.txtNomeFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNomeFiltro_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(4, 70);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(144, 20);
            this.label12.TabIndex = 29;
            this.label12.Text = "Nome do Produto:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(4, 38);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 20);
            this.label13.TabIndex = 28;
            this.label13.Text = "Código Produto:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 5);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(297, 20);
            this.label9.TabIndex = 24;
            this.label9.Text = "Pesquisar movimentos de estoque";
            // 
            // pnlMovimento
            // 
            this.pnlMovimento.Controls.Add(this.lblQtdeTotalProduto);
            this.pnlMovimento.Controls.Add(this.label23);
            this.pnlMovimento.Controls.Add(this.lblCodProd);
            this.pnlMovimento.Controls.Add(this.label17);
            this.pnlMovimento.Controls.Add(this.rgvEstoqueProduto);
            this.pnlMovimento.Controls.Add(this.btnCancelar);
            this.pnlMovimento.Controls.Add(this.btnAdicionar);
            this.pnlMovimento.Controls.Add(this.txtValorVenda);
            this.pnlMovimento.Controls.Add(this.label16);
            this.pnlMovimento.Controls.Add(this.txtValorCusto);
            this.pnlMovimento.Controls.Add(this.label15);
            this.pnlMovimento.Controls.Add(this.txtQtde);
            this.pnlMovimento.Controls.Add(this.label14);
            this.pnlMovimento.Controls.Add(this.lblTipoMovimento);
            this.pnlMovimento.Controls.Add(this.label2);
            this.pnlMovimento.Controls.Add(this.lblData);
            this.pnlMovimento.Controls.Add(this.label11);
            this.pnlMovimento.Controls.Add(this.lblMarca);
            this.pnlMovimento.Controls.Add(this.label10);
            this.pnlMovimento.Controls.Add(this.lblReferencia);
            this.pnlMovimento.Controls.Add(this.label8);
            this.pnlMovimento.Controls.Add(this.lblCor);
            this.pnlMovimento.Controls.Add(this.label6);
            this.pnlMovimento.Controls.Add(this.lblCodigoProduto);
            this.pnlMovimento.Controls.Add(this.lblCategoria);
            this.pnlMovimento.Controls.Add(this.lblTamanho);
            this.pnlMovimento.Controls.Add(this.lblDescricao);
            this.pnlMovimento.Controls.Add(this.lblNome);
            this.pnlMovimento.Controls.Add(this.label7);
            this.pnlMovimento.Controls.Add(this.label4);
            this.pnlMovimento.Controls.Add(this.label1);
            this.pnlMovimento.Controls.Add(this.label5);
            this.pnlMovimento.Controls.Add(this.label3);
            this.pnlMovimento.Controls.Add(this.lblTitulo);
            this.pnlMovimento.Location = new System.Drawing.Point(-1, 2);
            this.pnlMovimento.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMovimento.Name = "pnlMovimento";
            this.pnlMovimento.Size = new System.Drawing.Size(1356, 597);
            this.pnlMovimento.TabIndex = 1;
            this.pnlMovimento.Visible = false;
            // 
            // lblQtdeTotalProduto
            // 
            this.lblQtdeTotalProduto.AutoSize = true;
            this.lblQtdeTotalProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtdeTotalProduto.Location = new System.Drawing.Point(223, 644);
            this.lblQtdeTotalProduto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQtdeTotalProduto.Name = "lblQtdeTotalProduto";
            this.lblQtdeTotalProduto.Size = new System.Drawing.Size(0, 20);
            this.lblQtdeTotalProduto.TabIndex = 69;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(12, 644);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(179, 20);
            this.label23.TabIndex = 68;
            this.label23.Text = "Qtde total em estoque:";
            // 
            // lblCodProd
            // 
            this.lblCodProd.AutoSize = true;
            this.lblCodProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodProd.Location = new System.Drawing.Point(847, 34);
            this.lblCodProd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodProd.Name = "lblCodProd";
            this.lblCodProd.Size = new System.Drawing.Size(0, 20);
            this.lblCodProd.TabIndex = 67;
            this.lblCodProd.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(12, 374);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(202, 20);
            this.label17.TabIndex = 66;
            this.label17.Text = "Movimentos realizados";
            // 
            // rgvEstoqueProduto
            // 
            this.rgvEstoqueProduto.AllowUserToAddRows = false;
            this.rgvEstoqueProduto.AllowUserToDeleteRows = false;
            this.rgvEstoqueProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rgvEstoqueProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.rgvEstoqueProduto.Location = new System.Drawing.Point(15, 399);
            this.rgvEstoqueProduto.Margin = new System.Windows.Forms.Padding(4);
            this.rgvEstoqueProduto.Name = "rgvEstoqueProduto";
            this.rgvEstoqueProduto.ReadOnly = true;
            this.rgvEstoqueProduto.Size = new System.Drawing.Size(1319, 233);
            this.rgvEstoqueProduto.TabIndex = 65;
            this.rgvEstoqueProduto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rgvEstoqueProduto_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Image = global::loja.Properties.Resources.grid_excluir;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 40;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(188, 315);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(161, 48);
            this.btnCancelar.TabIndex = 64;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionar.Image")));
            this.btnAdicionar.Location = new System.Drawing.Point(15, 315);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(161, 48);
            this.btnAdicionar.TabIndex = 63;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // txtValorVenda
            // 
            this.txtValorVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorVenda.Location = new System.Drawing.Point(456, 277);
            this.txtValorVenda.Margin = new System.Windows.Forms.Padding(4);
            this.txtValorVenda.MaxLength = 10;
            this.txtValorVenda.Name = "txtValorVenda";
            this.txtValorVenda.Size = new System.Drawing.Size(156, 26);
            this.txtValorVenda.TabIndex = 62;
            this.txtValorVenda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValorVenda_KeyDown);
            this.txtValorVenda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorVenda_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(307, 283);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(133, 20);
            this.label16.TabIndex = 61;
            this.label16.Text = "Preço de Venda:";
            // 
            // txtValorCusto
            // 
            this.txtValorCusto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorCusto.Location = new System.Drawing.Point(159, 279);
            this.txtValorCusto.Margin = new System.Windows.Forms.Padding(4);
            this.txtValorCusto.MaxLength = 10;
            this.txtValorCusto.Name = "txtValorCusto";
            this.txtValorCusto.Size = new System.Drawing.Size(132, 26);
            this.txtValorCusto.TabIndex = 60;
            this.txtValorCusto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValorCusto_KeyDown);
            this.txtValorCusto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorCusto_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(12, 286);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(130, 20);
            this.label15.TabIndex = 59;
            this.label15.Text = "Preço de Custo:";
            // 
            // txtQtde
            // 
            this.txtQtde.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtde.Location = new System.Drawing.Point(159, 246);
            this.txtQtde.Margin = new System.Windows.Forms.Padding(4);
            this.txtQtde.MaxLength = 10;
            this.txtQtde.Name = "txtQtde";
            this.txtQtde.Size = new System.Drawing.Size(132, 26);
            this.txtQtde.TabIndex = 58;
            this.txtQtde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQtde_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 247);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 20);
            this.label14.TabIndex = 57;
            this.label14.Text = "Quantidade:";
            // 
            // lblTipoMovimento
            // 
            this.lblTipoMovimento.AutoSize = true;
            this.lblTipoMovimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoMovimento.Location = new System.Drawing.Point(444, 210);
            this.lblTipoMovimento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoMovimento.Name = "lblTipoMovimento";
            this.lblTipoMovimento.Size = new System.Drawing.Size(0, 20);
            this.lblTipoMovimento.TabIndex = 56;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(303, 210);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 55;
            this.label2.Text = "Tipo movimento:";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(68, 210);
            this.lblData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(0, 20);
            this.lblData.TabIndex = 54;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 210);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 20);
            this.label11.TabIndex = 53;
            this.label11.Text = "Data:";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.Location = new System.Drawing.Point(367, 172);
            this.lblMarca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(0, 20);
            this.lblMarca.TabIndex = 50;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(303, 172);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 20);
            this.label10.TabIndex = 49;
            this.label10.Text = "Marca:";
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferencia.Location = new System.Drawing.Point(695, 142);
            this.lblReferencia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(0, 20);
            this.lblReferencia.TabIndex = 48;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(583, 140);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 20);
            this.label8.TabIndex = 47;
            this.label8.Text = "Referência:";
            // 
            // lblCor
            // 
            this.lblCor.AutoSize = true;
            this.lblCor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCor.Location = new System.Drawing.Point(348, 140);
            this.lblCor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCor.Name = "lblCor";
            this.lblCor.Size = new System.Drawing.Size(0, 20);
            this.lblCor.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(304, 140);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 45;
            this.label6.Text = "Cor:";
            // 
            // lblCodigoProduto
            // 
            this.lblCodigoProduto.AutoSize = true;
            this.lblCodigoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoProduto.Location = new System.Drawing.Point(159, 39);
            this.lblCodigoProduto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigoProduto.Name = "lblCodigoProduto";
            this.lblCodigoProduto.Size = new System.Drawing.Size(0, 20);
            this.lblCodigoProduto.TabIndex = 44;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(104, 172);
            this.lblCategoria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(0, 20);
            this.lblCategoria.TabIndex = 43;
            // 
            // lblTamanho
            // 
            this.lblTamanho.AutoSize = true;
            this.lblTamanho.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTamanho.Location = new System.Drawing.Point(104, 140);
            this.lblTamanho.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTamanho.Name = "lblTamanho";
            this.lblTamanho.Size = new System.Drawing.Size(0, 20);
            this.lblTamanho.TabIndex = 42;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricao.Location = new System.Drawing.Point(104, 106);
            this.lblDescricao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(0, 20);
            this.lblDescricao.TabIndex = 41;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(73, 74);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(0, 20);
            this.lblNome.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 172);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 39;
            this.label7.Text = "Categoria:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 38;
            this.label4.Text = "Tamanho:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 37;
            this.label1.Text = "Descrição:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 74);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "Nome:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Código Produto:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(8, 4);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(283, 20);
            this.lblTitulo.TabIndex = 34;
            this.lblTitulo.Text = "Adicionar entrada de mercadoria";
            // 
            // frmEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 693);
            this.Controls.Add(this.pnlMovimento);
            this.Controls.Add(this.pnlListagem);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEstoque";
            this.Text = "Controle de Estoque";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlListagem.ResumeLayout(false);
            this.pnlListagem.PerformLayout();
            this.pnlSenha.ResumeLayout(false);
            this.pnlSenha.PerformLayout();
            this.pnlTotal.ResumeLayout(false);
            this.pnlTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvEstoque)).EndInit();
            this.pnlMovimento.ResumeLayout(false);
            this.pnlMovimento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvEstoqueProduto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlListagem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCodigoFiltro;
        private System.Windows.Forms.TextBox txtNomeFiltro;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Panel pnlMovimento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCodigoProduto;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblTamanho;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        //private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
       // private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.TextBox txtValorVenda;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtValorCusto;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtQtde;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTipoMovimento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView rgvEstoque;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView rgvEstoqueProduto;
        private System.Windows.Forms.TextBox txtMarcaFiltro;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtCategoriaFiltro;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtReferenciaFiltro;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridViewButtonColumn Adicionar;
        private System.Windows.Forms.DataGridViewButtonColumn Excluir;
        private System.Windows.Forms.Label lblValorTotalEstoque;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblQtdeTotal;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblCodProd;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.Label lblQtdeTotalProduto;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel pnlSenha;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Button btnVerTotais;
        private System.Windows.Forms.Button button2;
    }
}