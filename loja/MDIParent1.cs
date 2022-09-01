using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loja
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
            this.VerificaPermissao();
        }

        private void VerificaPermissao()
        {
            try
            {
                //vendedor só pode ter acesso a abertura/fechamento de caixa e tela de vendas
                if(Utilitarios.strPerfil == "VENDEDOR")
                {
                    //categoriaToolStripMenuItem.Visible = false;
                   // produtoToolStripMenuItem.Visible = false;
                   // movimentosDeEstoqueToolStripMenuItem.Visible = false;
                   usuárioToolStripMenuItem.Visible = false;
                   // marcaToolStripMenuItem.Visible = false;
                    //   marcasMaisVendidasToolStripMenuItem.Visible = false;
                    //  produtosMaisVendidosToolStripMenuItem.Visible = false;
                    relatóriosToolStripMenuItem.Visible = false;
                    
                }
            }
            catch(Exception ex)
            {
                Utilitarios.SalvarLog(ex.Message, "MDIFORM - VerificaPermissao()");
            }
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        #region Eventos não utilizados
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        #endregion

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frmcategoria = new Form1();
            frmcategoria.MdiParent = this;
            frmcategoria.Show();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduto formProduto = new frmProduto();
            formProduto.MdiParent = this;
            formProduto.Show();
        }

        private void movimentosDeEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoque formEstoque = new frmEstoque();
            formEstoque.MdiParent = this;
            formEstoque.Show();
        }

        private void registrarVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utilitarios.blnAberturaCaixa)
            {
                frmVenda formVenda = new frmVenda();
                formVenda.MdiParent = this;

                formVenda.Show();
            }
            else
            {
                MessageBox.Show("O caixa ainda não foi aberto!");
                frmFechamentoDia formcaixa = new frmFechamentoDia();
                formcaixa.MdiParent = this;
                formcaixa.Show();
            }
        }

        private void fechamentoDeCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFechamentoDia formFechamentoDiario = new frmFechamentoDia();
            formFechamentoDiario.MdiParent = this;
            formFechamentoDiario.Show();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente formCliente = new frmCliente();
            formCliente.MdiParent = this;
            formCliente.Show();
        }

        private void registrarTrocaDeProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTroca formTroca = new frmTroca();
            formTroca.MdiParent = this;
            formTroca.Show();
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario formUsuario = new frmUsuario();
            formUsuario.MdiParent = this;
            formUsuario.Show();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFabricante formFabricante = new frmFabricante();
            formFabricante.MdiParent = this;
            formFabricante.Show();
        }

        private void vendasDiáriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListagemVendas formVendas = new frmListagemVendas();
            formVendas.MdiParent = this;
            formVendas.Show();
        }

        private void vendasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEstatistica formEst = new frmEstatistica();
            formEst.MdiParent = this;
            formEst.Show();
        }

        private void alterarSenhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlteraSenha formSenha = new frmAlteraSenha();
            formSenha.MdiParent = this;
            formSenha.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void vendasPorVendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVendasVendedor formVendasVendedor = new frmVendasVendedor();
            formVendasVendedor.MdiParent = this;
            formVendasVendedor.Show();
        }

        private void marcasMaisVendidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarcasVendidas formMarcasVendidas = new frmMarcasVendidas();
            formMarcasVendidas.MdiParent = this;
            formMarcasVendidas.Show();
        }

        private void produtosMaisVendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProdutosVendidos formProdutosVendidos = new frmProdutosVendidos();
            formProdutosVendidos.MdiParent = this;
            formProdutosVendidos.Show();
        }

        private void comprasRealizadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompras formCompras = new frmCompras();
            formCompras.MdiParent = this;
            formCompras.Show();
        }
    }
}
