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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Categoria objCategoria = new Categoria();
                DataTable dtCategoria = new DataTable();
                objCategoria.Status = true;
                dtCategoria = objCategoria.Listar(objCategoria);
                rgvCategoria.DataSource = dtCategoria;
                rgvCategoria.Columns[2].Width = 50;
                rgvCategoria.Columns[3].Width = 300;
                rgvCategoria.Columns[4].Width = 70;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "CATEGORIA - Form1_Load");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.PopularListagem();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "CATEGORIA - button1_Click");
            }
        }

        public void PopularListagem()
        {
            try
            {
                Categoria objCategoria = new Categoria();
                objCategoria.Descricao = txtDescricaoFiltro.Text.ToUpper();
                DataTable dtCategoria = new DataTable();
                dtCategoria = objCategoria.Listar(objCategoria);
                rgvCategoria.DataSource = dtCategoria;
            }
            catch (Exception ex)
            {
                Utilitarios.SalvarLog(ex.Message, "CATEGORIA - PopularListagem()");
            }
        }

        private void rgvCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 0)//editar; popular dados com o código 
                    {
                        Categoria objCategoria = new Categoria();
                        DataTable dtCategoria = new DataTable();
                        objCategoria.Codigo = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);
                        dtCategoria = objCategoria.Listar(objCategoria);
                        //popular campos de edição

                        lblTituloCadastro.Text = "Alterar categoria";
                        lblCodigo.Text = dtCategoria.Rows[0]["Código"].ToString();
                        txtDescricao.Text = dtCategoria.Rows[0]["Descrição"].ToString();
                        chkStatus.Checked = Convert.ToBoolean(dtCategoria.Rows[0]["Status"]);
                        pnlFiltro.Visible = false;
                        pnlCadastro.Visible = true;
                    }
                    else if (e.ColumnIndex == 1)//excluir
                    {
                        if (MessageBox.Show("Confirma exclusão da categoria?", "Exclusão de categoria", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            Categoria objCategoria = new Categoria();
                            objCategoria.Codigo = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);
                            objCategoria.Excluir(objCategoria);
                        }
                        
                    }

                    this.PopularListagem();
                }
            }
            catch (Exception ex)
            {
                 //tratar aqui caso o produto esteja relacionado com alguma venda
                if (ex.Message.Contains("FK_tb_cat_categoria_tb_pro_produto"))
                {
                    MessageBox.Show("A categoria não pode ser excluída, pois existe(m) produto(s) vinculado(s).");
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                    Utilitarios.SalvarLog(ex.Message, "CATEGORIA - rgvCategoria_CellContentClick");
                }
            }
                
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlFiltro.Visible = true;
            pnlCadastro.Visible = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria objCategoria = new Categoria();
                
                objCategoria.Descricao = txtDescricao.Text.ToUpper();
                objCategoria.Status = chkStatus.Checked;

                if (!string.IsNullOrEmpty(lblCodigo.Text))//edição
                {
                    objCategoria.Codigo = Convert.ToInt32(lblCodigo.Text);
                    objCategoria.Alterar(objCategoria);
                }
                else //inclusao
                    objCategoria.Inserir(objCategoria);

                this.PopularListagem();

                pnlFiltro.Visible = true;
                pnlCadastro.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "CATEGORIA - btnSalvar_Click");
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            txtDescricaoFiltro.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            chkStatus.Checked = true;
            pnlFiltro.Visible = false;
            pnlCadastro.Visible = true;
            lblTituloCadastro.Text = "Adicionar categoria";
        }

        private void txtDescricaoFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!string.IsNullOrEmpty(txtDescricaoFiltro.Text))
                    button1.PerformClick();
                   
            }
        }

        private void txtDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!string.IsNullOrEmpty(txtDescricao.Text))
                    chkStatus.Focus();
                else
                    MessageBox.Show("Digite uma descrição!");
            }
        }
    }
}
