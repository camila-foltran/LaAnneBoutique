using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Loja;

namespace loja
{
    public partial class frmFabricante : Form
    {
        public frmFabricante()
        {
            InitializeComponent();
            this.CarregarForm();
        }

        private void CarregarForm()
        {
            try
            {
                Fabricante objFabricante = new Fabricante();
                DataTable dtMarca = new DataTable();
                objFabricante.Status = true;
                dtMarca = objFabricante.Listar(objFabricante);
                rgvMarca.DataSource = dtMarca;
                rgvMarca.Columns[2].Width = 50;
                rgvMarca.Columns[3].Width = 300;
                rgvMarca.Columns[4].Width = 70;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "FABRICANTE - Form1_Load");
            }
        }

        public void PopularListagem()
        {
            try
            {
                Fabricante objFabricante = new Fabricante();
                DataTable dtMarca = new DataTable();
                objFabricante.Descricao = txtDescricaoFiltro.Text.ToUpper();
                dtMarca = objFabricante.Listar(objFabricante);
                rgvMarca.DataSource = dtMarca;
            }
            catch (Exception ex)
            {
                Utilitarios.SalvarLog(ex.Message, "FABRICANTE - PopularListagem()");
                throw ex;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                this.PopularListagem();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "FABRICANTE - btnPesquisar_Click");
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            txtDescricaoFiltro.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            chkStatus.Checked = true;
            pnlFiltro.Visible = false;
            pnlCadastro.Visible = true;
            lblTituloCadastro.Text = "Adicionar marca";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Fabricante objFabricante = new Fabricante();

                objFabricante.Descricao = txtDescricao.Text.ToUpper();
                objFabricante.Status = chkStatus.Checked;

                if (!string.IsNullOrEmpty(lblCodigo.Text))//edição
                {
                    objFabricante.Codigo = Convert.ToInt32(lblCodigo.Text);
                    objFabricante.Alterar(objFabricante);
                }
                else //inclusao
                    objFabricante.Inserir(objFabricante);

                this.PopularListagem();

                pnlFiltro.Visible = true;
                pnlCadastro.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "FABRICANTE - btnSalvar_Click");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlFiltro.Visible = true;
            pnlCadastro.Visible = false;
        }

        private void txtDescricaoFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!string.IsNullOrEmpty(txtDescricaoFiltro.Text))
                    btnPesquisar.PerformClick();
                   
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

        private void rgvMarca_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 0)//editar; popular dados com o código 
                    {
                        Fabricante objFabricante = new Fabricante();
                        DataTable dtFabricante = new DataTable();
                        objFabricante.Codigo = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);
                        dtFabricante = objFabricante.Listar(objFabricante);
                        //popular campos de edição

                        lblTituloCadastro.Text = "Alterar Marca";
                        lblCodigo.Text = dtFabricante.Rows[0]["Código"].ToString();
                        txtDescricao.Text = dtFabricante.Rows[0]["Descrição"].ToString();
                        chkStatus.Checked = Convert.ToBoolean(dtFabricante.Rows[0]["Status"]);
                        pnlFiltro.Visible = false;
                        pnlCadastro.Visible = true;
                    }
                    else if (e.ColumnIndex == 1)//excluir
                    {
                        if (MessageBox.Show("Confirma exclusão da marca?", "Exclusão de marca", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            Fabricante objFabricante = new Fabricante();
                            objFabricante.Codigo = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);
                            objFabricante.Excluir(objFabricante);
                        }
                    }

                    this.PopularListagem();
                }
            }
            catch (Exception ex)
            {
                 //tratar aqui caso o produto esteja relacionado com alguma venda
                if (ex.Message.Contains("FK_tb_fab_fabricante_tb_pro_produto"))
                {
                    MessageBox.Show("A marca não pode ser excluída pois existe(m) produto(s) vinculado(s).");
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                    Utilitarios.SalvarLog(ex.Message, "FABRICANTE - rgvMarca_CellContentClick");
                }
            }

        }
    }
}
