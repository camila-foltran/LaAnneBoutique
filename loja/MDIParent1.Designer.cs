namespace loja
{
    partial class MDIParent1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent1));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimentosDeEstoqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarVendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fechamentoDeCaixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendasDiáriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trocaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarTrocaDeProdutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcasMaisVendidasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosMaisVendidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasRealizadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alterarSenhaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem,
            this.vendasToolStripMenuItem,
            this.trocaToolStripMenuItem,
            this.relatóriosToolStripMenuItem,
            this.alterarSenhaToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(737, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoriaToolStripMenuItem,
            this.clienteToolStripMenuItem,
            this.marcaToolStripMenuItem,
            this.movimentosDeEstoqueToolStripMenuItem,
            this.produtoToolStripMenuItem,
            this.usuárioToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cadastrosToolStripMenuItem.Image")));
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // categoriaToolStripMenuItem
            // 
            this.categoriaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("categoriaToolStripMenuItem.Image")));
            this.categoriaToolStripMenuItem.Name = "categoriaToolStripMenuItem";
            this.categoriaToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.categoriaToolStripMenuItem.Text = "Categoria";
            this.categoriaToolStripMenuItem.Click += new System.EventHandler(this.categoriaToolStripMenuItem_Click);
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clienteToolStripMenuItem.Image")));
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // marcaToolStripMenuItem
            // 
            this.marcaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("marcaToolStripMenuItem.Image")));
            this.marcaToolStripMenuItem.Name = "marcaToolStripMenuItem";
            this.marcaToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.marcaToolStripMenuItem.Text = "Marca";
            this.marcaToolStripMenuItem.Click += new System.EventHandler(this.marcaToolStripMenuItem_Click);
            // 
            // movimentosDeEstoqueToolStripMenuItem
            // 
            this.movimentosDeEstoqueToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("movimentosDeEstoqueToolStripMenuItem.Image")));
            this.movimentosDeEstoqueToolStripMenuItem.Name = "movimentosDeEstoqueToolStripMenuItem";
            this.movimentosDeEstoqueToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.movimentosDeEstoqueToolStripMenuItem.Text = "Movimentos de Estoque";
            this.movimentosDeEstoqueToolStripMenuItem.Click += new System.EventHandler(this.movimentosDeEstoqueToolStripMenuItem_Click);
            // 
            // produtoToolStripMenuItem
            // 
            this.produtoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("produtoToolStripMenuItem.Image")));
            this.produtoToolStripMenuItem.Name = "produtoToolStripMenuItem";
            this.produtoToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.produtoToolStripMenuItem.Text = "Produto";
            this.produtoToolStripMenuItem.Click += new System.EventHandler(this.produtoToolStripMenuItem_Click);
            // 
            // usuárioToolStripMenuItem
            // 
            this.usuárioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("usuárioToolStripMenuItem.Image")));
            this.usuárioToolStripMenuItem.Name = "usuárioToolStripMenuItem";
            this.usuárioToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.usuárioToolStripMenuItem.Text = "Vendedor";
            this.usuárioToolStripMenuItem.Click += new System.EventHandler(this.usuárioToolStripMenuItem_Click);
            // 
            // vendasToolStripMenuItem
            // 
            this.vendasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarVendaToolStripMenuItem,
            this.fechamentoDeCaixaToolStripMenuItem,
            this.vendasDiáriasToolStripMenuItem});
            this.vendasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("vendasToolStripMenuItem.Image")));
            this.vendasToolStripMenuItem.Name = "vendasToolStripMenuItem";
            this.vendasToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.vendasToolStripMenuItem.Text = "Vendas";
            // 
            // registrarVendaToolStripMenuItem
            // 
            this.registrarVendaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("registrarVendaToolStripMenuItem.Image")));
            this.registrarVendaToolStripMenuItem.Name = "registrarVendaToolStripMenuItem";
            this.registrarVendaToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.registrarVendaToolStripMenuItem.Text = "Registrar Venda";
            this.registrarVendaToolStripMenuItem.Click += new System.EventHandler(this.registrarVendaToolStripMenuItem_Click);
            // 
            // fechamentoDeCaixaToolStripMenuItem
            // 
            this.fechamentoDeCaixaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fechamentoDeCaixaToolStripMenuItem.Image")));
            this.fechamentoDeCaixaToolStripMenuItem.Name = "fechamentoDeCaixaToolStripMenuItem";
            this.fechamentoDeCaixaToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.fechamentoDeCaixaToolStripMenuItem.Text = "Abertura/Fechamento de caixa";
            this.fechamentoDeCaixaToolStripMenuItem.Click += new System.EventHandler(this.fechamentoDeCaixaToolStripMenuItem_Click);
            // 
            // vendasDiáriasToolStripMenuItem
            // 
            this.vendasDiáriasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("vendasDiáriasToolStripMenuItem.Image")));
            this.vendasDiáriasToolStripMenuItem.Name = "vendasDiáriasToolStripMenuItem";
            this.vendasDiáriasToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.vendasDiáriasToolStripMenuItem.Text = "Vendas realizadas";
            this.vendasDiáriasToolStripMenuItem.Click += new System.EventHandler(this.vendasDiáriasToolStripMenuItem_Click);
            // 
            // trocaToolStripMenuItem
            // 
            this.trocaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarTrocaDeProdutoToolStripMenuItem});
            this.trocaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("trocaToolStripMenuItem.Image")));
            this.trocaToolStripMenuItem.Name = "trocaToolStripMenuItem";
            this.trocaToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.trocaToolStripMenuItem.Text = "Troca";
            this.trocaToolStripMenuItem.Visible = false;
            // 
            // registrarTrocaDeProdutoToolStripMenuItem
            // 
            this.registrarTrocaDeProdutoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("registrarTrocaDeProdutoToolStripMenuItem.Image")));
            this.registrarTrocaDeProdutoToolStripMenuItem.Name = "registrarTrocaDeProdutoToolStripMenuItem";
            this.registrarTrocaDeProdutoToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.registrarTrocaDeProdutoToolStripMenuItem.Text = "Registrar Troca de produto";
            this.registrarTrocaDeProdutoToolStripMenuItem.Click += new System.EventHandler(this.registrarTrocaDeProdutoToolStripMenuItem_Click);
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.marcasMaisVendidasToolStripMenuItem,
            this.produtosMaisVendidosToolStripMenuItem,
            this.vendasToolStripMenuItem1,
            this.comprasRealizadasToolStripMenuItem});
            this.relatóriosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("relatóriosToolStripMenuItem.Image")));
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.relatóriosToolStripMenuItem.Text = "Relatórios";
            // 
            // marcasMaisVendidasToolStripMenuItem
            // 
            this.marcasMaisVendidasToolStripMenuItem.Image = global::loja.Properties.Resources.gerarNotaDebito;
            this.marcasMaisVendidasToolStripMenuItem.Name = "marcasMaisVendidasToolStripMenuItem";
            this.marcasMaisVendidasToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.marcasMaisVendidasToolStripMenuItem.Text = "Marcas mais vendidas";
            this.marcasMaisVendidasToolStripMenuItem.Click += new System.EventHandler(this.marcasMaisVendidasToolStripMenuItem_Click);
            // 
            // produtosMaisVendidosToolStripMenuItem
            // 
            this.produtosMaisVendidosToolStripMenuItem.Image = global::loja.Properties.Resources.grid_libera_fatura_liberado;
            this.produtosMaisVendidosToolStripMenuItem.Name = "produtosMaisVendidosToolStripMenuItem";
            this.produtosMaisVendidosToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.produtosMaisVendidosToolStripMenuItem.Text = "Produtos mais vendidos";
            this.produtosMaisVendidosToolStripMenuItem.Click += new System.EventHandler(this.produtosMaisVendidosToolStripMenuItem_Click);
            // 
            // vendasToolStripMenuItem1
            // 
            this.vendasToolStripMenuItem1.Image = global::loja.Properties.Resources.menu_financeiro;
            this.vendasToolStripMenuItem1.Name = "vendasToolStripMenuItem1";
            this.vendasToolStripMenuItem1.Size = new System.Drawing.Size(205, 26);
            this.vendasToolStripMenuItem1.Text = "Vendas por mês";
            this.vendasToolStripMenuItem1.Click += new System.EventHandler(this.vendasToolStripMenuItem1_Click);
            // 
            // comprasRealizadasToolStripMenuItem
            // 
            this.comprasRealizadasToolStripMenuItem.Name = "comprasRealizadasToolStripMenuItem";
            this.comprasRealizadasToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.comprasRealizadasToolStripMenuItem.Text = "Compras realizadas";
            this.comprasRealizadasToolStripMenuItem.Click += new System.EventHandler(this.comprasRealizadasToolStripMenuItem_Click);
            // 
            // alterarSenhaToolStripMenuItem
            // 
            this.alterarSenhaToolStripMenuItem.Image = global::loja.Properties.Resources.alterasenha;
            this.alterarSenhaToolStripMenuItem.Name = "alterarSenhaToolStripMenuItem";
            this.alterarSenhaToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.alterarSenhaToolStripMenuItem.Text = "Alterar senha";
            this.alterarSenhaToolStripMenuItem.Click += new System.EventHandler(this.alterarSenhaToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Image = global::loja.Properties.Resources.menu_sair;
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // MDIParent1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 488);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MDIParent1";
            this.Text = "La Anne Boutique";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimentosDeEstoqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarVendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fechamentoDeCaixaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trocaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarTrocaDeProdutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendasDiáriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem alterarSenhaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcasMaisVendidasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosMaisVendidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasRealizadasToolStripMenuItem;
    }
}



