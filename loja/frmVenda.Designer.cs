namespace loja
{
    partial class frmVenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVenda));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ddlCartao = new System.Windows.Forms.ComboBox();
            this.txtValorDinheiro = new System.Windows.Forms.TextBox();
            this.lblValorDinheiro = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnCadastrarVenda = new System.Windows.Forms.Button();
            this.btnCancelarVenda = new System.Windows.Forms.Button();
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
            this.label15 = new System.Windows.Forms.Label();
            this.lblCodigoVenda = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblDataVenda = new System.Windows.Forms.Label();
            this.rgvProdutos = new System.Windows.Forms.DataGridView();
            this.Excluir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ddlProduto = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblValorUnit = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvProdutos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(199, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Produto";
            // 
            // txtCodigo
            // 
            this.txtCodigo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtCodigo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(20, 47);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodigo.MaxLength = 50;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(177, 26);
            this.txtCodigo.TabIndex = 2;
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ddlCartao);
            this.panel2.Controls.Add(this.txtValorDinheiro);
            this.panel2.Controls.Add(this.lblValorDinheiro);
            this.panel2.Controls.Add(this.txtCPF);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.lblVendedor);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.btnCadastrarVenda);
            this.panel2.Controls.Add(this.btnCancelarVenda);
            this.panel2.Controls.Add(this.lblTroco);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.lblTotalPagar);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txtSubTotal);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtAcrescimo);
            this.panel2.Controls.Add(this.txtCodigoVendedor);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtDesconto);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtValorRecebido);
            this.panel2.Controls.Add(this.lblValorRecebido);
            this.panel2.Controls.Add(this.ddlFormaPagto);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(943, 6);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(362, 611);
            this.panel2.TabIndex = 17;
            // 
            // ddlCartao
            // 
            this.ddlCartao.DropDownWidth = 250;
            this.ddlCartao.FormattingEnabled = true;
            this.ddlCartao.Location = new System.Drawing.Point(5, 223);
            this.ddlCartao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlCartao.Name = "ddlCartao";
            this.ddlCartao.Size = new System.Drawing.Size(184, 24);
            this.ddlCartao.TabIndex = 39;
            this.ddlCartao.Visible = false;
            // 
            // txtValorDinheiro
            // 
            this.txtValorDinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorDinheiro.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtValorDinheiro.Location = new System.Drawing.Point(195, 182);
            this.txtValorDinheiro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtValorDinheiro.Name = "txtValorDinheiro";
            this.txtValorDinheiro.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtValorDinheiro.Size = new System.Drawing.Size(151, 26);
            this.txtValorDinheiro.TabIndex = 38;
            this.txtValorDinheiro.Visible = false;
            this.txtValorDinheiro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValorDinheiro_KeyDown);
            this.txtValorDinheiro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorDinheiro_KeyPress);
            // 
            // lblValorDinheiro
            // 
            this.lblValorDinheiro.AutoSize = true;
            this.lblValorDinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDinheiro.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblValorDinheiro.Location = new System.Drawing.Point(4, 186);
            this.lblValorDinheiro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorDinheiro.Name = "lblValorDinheiro";
            this.lblValorDinheiro.Size = new System.Drawing.Size(167, 20);
            this.lblValorDinheiro.TabIndex = 37;
            this.lblValorDinheiro.Text = "Valor em Dinheiro:";
            this.lblValorDinheiro.Visible = false;
            // 
            // txtCPF
            // 
            this.txtCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPF.Location = new System.Drawing.Point(195, 12);
            this.txtCPF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCPF.MaxLength = 50;
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(151, 26);
            this.txtCPF.TabIndex = 36;
            this.txtCPF.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(4, 16);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(124, 20);
            this.label19.TabIndex = 35;
            this.label19.Text = "CPF do cliente:";
            this.label19.Visible = false;
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendedor.Location = new System.Drawing.Point(131, 85);
            this.lblVendedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(0, 20);
            this.lblVendedor.TabIndex = 26;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(4, 85);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(106, 20);
            this.label18.TabIndex = 25;
            this.label18.Text = "Vendedor(a):";
            // 
            // btnCadastrarVenda
            // 
            this.btnCadastrarVenda.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnCadastrarVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrarVenda.Image = ((System.Drawing.Image)(resources.GetObject("btnCadastrarVenda.Image")));
            this.btnCadastrarVenda.Location = new System.Drawing.Point(8, 453);
            this.btnCadastrarVenda.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCadastrarVenda.Name = "btnCadastrarVenda";
            this.btnCadastrarVenda.Size = new System.Drawing.Size(179, 58);
            this.btnCadastrarVenda.TabIndex = 11;
            this.btnCadastrarVenda.Text = "Cadastrar Venda";
            this.btnCadastrarVenda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCadastrarVenda.UseVisualStyleBackColor = false;
            this.btnCadastrarVenda.Click += new System.EventHandler(this.btnCadastrarVenda_Click);
            // 
            // btnCancelarVenda
            // 
            this.btnCancelarVenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancelarVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarVenda.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarVenda.Image")));
            this.btnCancelarVenda.Location = new System.Drawing.Point(188, 453);
            this.btnCancelarVenda.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelarVenda.Name = "btnCancelarVenda";
            this.btnCancelarVenda.Size = new System.Drawing.Size(165, 58);
            this.btnCancelarVenda.TabIndex = 12;
            this.btnCancelarVenda.Text = "Cancelar Venda";
            this.btnCancelarVenda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelarVenda.UseVisualStyleBackColor = false;
            this.btnCancelarVenda.Click += new System.EventHandler(this.btnCancelarVenda_Click);
            // 
            // lblTroco
            // 
            this.lblTroco.AutoSize = true;
            this.lblTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTroco.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTroco.Location = new System.Drawing.Point(188, 414);
            this.lblTroco.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTroco.MinimumSize = new System.Drawing.Size(107, 0);
            this.lblTroco.Name = "lblTroco";
            this.lblTroco.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTroco.Size = new System.Drawing.Size(107, 20);
            this.lblTroco.TabIndex = 18;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DarkRed;
            this.label14.Location = new System.Drawing.Point(4, 414);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 20);
            this.label14.TabIndex = 17;
            this.label14.Text = "Troco:";
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.AutoSize = true;
            this.lblTotalPagar.BackColor = System.Drawing.Color.Blue;
            this.lblTotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagar.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblTotalPagar.Location = new System.Drawing.Point(177, 377);
            this.lblTotalPagar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalPagar.MinimumSize = new System.Drawing.Size(169, 0);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalPagar.Size = new System.Drawing.Size(169, 20);
            this.lblTotalPagar.TabIndex = 16;
            this.lblTotalPagar.Text = "0,00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Blue;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.AliceBlue;
            this.label13.Location = new System.Drawing.Point(4, 377);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 20);
            this.label13.TabIndex = 15;
            this.label13.Text = "Total a Pagar:";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtSubTotal.Location = new System.Drawing.Point(195, 331);
            this.txtSubTotal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSubTotal.Size = new System.Drawing.Size(151, 26);
            this.txtSubTotal.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(3, 338);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 20);
            this.label12.TabIndex = 13;
            this.label12.Text = "Sub Total:";
            // 
            // txtAcrescimo
            // 
            this.txtAcrescimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcrescimo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtAcrescimo.Location = new System.Drawing.Point(195, 295);
            this.txtAcrescimo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAcrescimo.Name = "txtAcrescimo";
            this.txtAcrescimo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAcrescimo.Size = new System.Drawing.Size(151, 26);
            this.txtAcrescimo.TabIndex = 9;
            this.txtAcrescimo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAcrescimo_KeyDown);
            this.txtAcrescimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcrescimo_KeyPress);
            this.txtAcrescimo.Leave += new System.EventHandler(this.txtAcrescimo_Leave);
            // 
            // txtCodigoVendedor
            // 
            this.txtCodigoVendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtCodigoVendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCodigoVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoVendedor.Location = new System.Drawing.Point(195, 47);
            this.txtCodigoVendedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodigoVendedor.MaxLength = 50;
            this.txtCodigoVendedor.Name = "txtCodigoVendedor";
            this.txtCodigoVendedor.Size = new System.Drawing.Size(72, 26);
            this.txtCodigoVendedor.TabIndex = 24;
            this.txtCodigoVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoVendedor_KeyDown);
            this.txtCodigoVendedor.Leave += new System.EventHandler(this.txtCodigoVendedor_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(4, 303);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 20);
            this.label11.TabIndex = 11;
            this.label11.Text = "Acréscimo:";
            // 
            // txtDesconto
            // 
            this.txtDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesconto.ForeColor = System.Drawing.Color.Black;
            this.txtDesconto.Location = new System.Drawing.Point(195, 256);
            this.txtDesconto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesconto.Size = new System.Drawing.Size(151, 26);
            this.txtDesconto.TabIndex = 8;
            this.txtDesconto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDesconto_KeyDown);
            this.txtDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDesconto_KeyPress);
            this.txtDesconto.Leave += new System.EventHandler(this.txtDesconto_Leave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(4, 54);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(163, 20);
            this.label17.TabIndex = 22;
            this.label17.Text = "Código Vendedor(a):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(4, 263);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "Desconto:";
            // 
            // txtValorRecebido
            // 
            this.txtValorRecebido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorRecebido.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtValorRecebido.Location = new System.Drawing.Point(195, 220);
            this.txtValorRecebido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtValorRecebido.Name = "txtValorRecebido";
            this.txtValorRecebido.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtValorRecebido.Size = new System.Drawing.Size(151, 26);
            this.txtValorRecebido.TabIndex = 7;
            this.txtValorRecebido.Click += new System.EventHandler(this.txtValorRecebido_Click);
            this.txtValorRecebido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValorRecebido_KeyDown);
            this.txtValorRecebido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorRecebido_KeyPress);
            this.txtValorRecebido.Leave += new System.EventHandler(this.txtValorRecebido_Leave);
            // 
            // lblValorRecebido
            // 
            this.lblValorRecebido.AutoSize = true;
            this.lblValorRecebido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorRecebido.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblValorRecebido.Location = new System.Drawing.Point(4, 220);
            this.lblValorRecebido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorRecebido.Name = "lblValorRecebido";
            this.lblValorRecebido.Size = new System.Drawing.Size(143, 20);
            this.lblValorRecebido.TabIndex = 7;
            this.lblValorRecebido.Text = "Valor Recebido:";
            // 
            // ddlFormaPagto
            // 
            this.ddlFormaPagto.FormattingEnabled = true;
            this.ddlFormaPagto.Location = new System.Drawing.Point(5, 144);
            this.ddlFormaPagto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlFormaPagto.Name = "ddlFormaPagto";
            this.ddlFormaPagto.Size = new System.Drawing.Size(340, 24);
            this.ddlFormaPagto.TabIndex = 6;
            this.ddlFormaPagto.SelectedIndexChanged += new System.EventHandler(this.ddlFormaPagto_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 118);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(174, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "Forma de Pagamento:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(13, 660);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(141, 20);
            this.label15.TabIndex = 18;
            this.label15.Text = "Código da Venda:";
            // 
            // lblCodigoVenda
            // 
            this.lblCodigoVenda.AutoSize = true;
            this.lblCodigoVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoVenda.Location = new System.Drawing.Point(171, 660);
            this.lblCodigoVenda.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigoVenda.Name = "lblCodigoVenda";
            this.lblCodigoVenda.Size = new System.Drawing.Size(0, 20);
            this.lblCodigoVenda.TabIndex = 19;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(287, 660);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(125, 20);
            this.label16.TabIndex = 20;
            this.label16.Text = "Data da Venda:";
            // 
            // lblDataVenda
            // 
            this.lblDataVenda.AutoSize = true;
            this.lblDataVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataVenda.Location = new System.Drawing.Point(424, 660);
            this.lblDataVenda.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataVenda.Name = "lblDataVenda";
            this.lblDataVenda.Size = new System.Drawing.Size(0, 20);
            this.lblDataVenda.TabIndex = 21;
            // 
            // rgvProdutos
            // 
            this.rgvProdutos.AllowUserToAddRows = false;
            this.rgvProdutos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvProdutos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.rgvProdutos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rgvProdutos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rgvProdutos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.rgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rgvProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Excluir});
            this.rgvProdutos.Location = new System.Drawing.Point(12, 110);
            this.rgvProdutos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rgvProdutos.Name = "rgvProdutos";
            this.rgvProdutos.ReadOnly = true;
            this.rgvProdutos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rgvProdutos.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Blue;
            this.rgvProdutos.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.rgvProdutos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgvProdutos.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
            this.rgvProdutos.Size = new System.Drawing.Size(895, 479);
            this.rgvProdutos.TabIndex = 15;
            this.rgvProdutos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rgvProdutos_CellContentClick);
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ddlProduto);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblValorUnit);
            this.panel1.Controls.Add(this.rgvProdutos);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(931, 611);
            this.panel1.TabIndex = 16;
            // 
            // ddlProduto
            // 
            this.ddlProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.ddlProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlProduto.DropDownWidth = 250;
            this.ddlProduto.FormattingEnabled = true;
            this.ddlProduto.Location = new System.Drawing.Point(203, 39);
            this.ddlProduto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlProduto.Name = "ddlProduto";
            this.ddlProduto.Size = new System.Drawing.Size(703, 24);
            this.ddlProduto.TabIndex = 42;
            this.ddlProduto.SelectedIndexChanged += new System.EventHandler(this.ddlProduto_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 85);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 20);
            this.label5.TabIndex = 29;
            this.label5.Text = "Itens da venda";
            // 
            // lblValorUnit
            // 
            this.lblValorUnit.AutoSize = true;
            this.lblValorUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorUnit.ForeColor = System.Drawing.Color.Blue;
            this.lblValorUnit.Location = new System.Drawing.Point(913, 42);
            this.lblValorUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorUnit.Name = "lblValorUnit";
            this.lblValorUnit.Size = new System.Drawing.Size(0, 20);
            this.lblValorUnit.TabIndex = 14;
            this.lblValorUnit.Visible = false;
            // 
            // frmVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 703);
            this.Controls.Add(this.lblDataVenda);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblCodigoVenda);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmVenda";
            this.Text = "Vendas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvProdutos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCadastrarVenda;
        private System.Windows.Forms.Button btnCancelarVenda;
        private System.Windows.Forms.Label lblTroco;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAcrescimo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDesconto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtValorRecebido;
        private System.Windows.Forms.Label lblValorRecebido;
        private System.Windows.Forms.ComboBox ddlFormaPagto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblCodigoVenda;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblDataVenda;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtCodigoVendedor;
        private System.Windows.Forms.DataGridView rgvProdutos;
        private System.Windows.Forms.DataGridViewButtonColumn Excluir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblValorUnit;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.TextBox txtCodigo;
        public System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtValorDinheiro;
        private System.Windows.Forms.Label lblValorDinheiro;
        private System.Windows.Forms.ComboBox ddlCartao;
        private System.Windows.Forms.ComboBox ddlProduto;
    }
}