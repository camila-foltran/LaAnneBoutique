using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loja
{
    public partial class menu : UserControl
    {
        public menu()
        {
            InitializeComponent();
        }

        private void fabricanteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frmCategoria = new Form1();
            frmCategoria.Show();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduto formProd = new frmProduto();

            formProd.Show();
        }

        private void movimentosDeEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoque formEstoque = new frmEstoque();
            formEstoque.Show();
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }
    }
}
