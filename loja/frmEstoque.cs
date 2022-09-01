using Loja;
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
    public partial class frmEstoque : Form
    {
        public frmEstoque()
        {
            InitializeComponent();
            this.CarregarForm();
            this.PopularListagem();
        }

        private int intQtdeTotalEstoque = 0;

        private void CarregarForm()
        {
            try
            {
                txtCodigoFiltro.Focus();

                //carregar text categoria e marca
                AutoCompleteStringCollection strCategoria = new AutoCompleteStringCollection();
                AutoCompleteStringCollection strMarca = new AutoCompleteStringCollection();
                AutoCompleteStringCollection strNome = new AutoCompleteStringCollection();
                AutoCompleteStringCollection strCor = new AutoCompleteStringCollection();

                Fabricante objFabricante = new Fabricante();
                DataTable dtFabricante = new DataTable();
                objFabricante.Status = true;
                dtFabricante = objFabricante.Listar(objFabricante);

                Categoria objCategoria = new Categoria();
                DataTable dtCategoria = new DataTable();
                objCategoria.Status = true;
                dtCategoria = objCategoria.Listar(objCategoria);

                foreach (DataRow dr in dtCategoria.Rows)
                {
                    strCategoria.Add(dr["Descrição"].ToString());
                }

                foreach (DataRow dr in dtFabricante.Rows)
                {
                    strMarca.Add(dr["Descrição"].ToString());
                }

                txtCategoriaFiltro.AutoCompleteCustomSource = strCategoria;
                txtMarcaFiltro.AutoCompleteCustomSource = strMarca;

                Produto objProduto = new Produto();
                DataSet dtsFiltros = new DataSet();
                dtsFiltros = objProduto.ListarFiltros();

                foreach (DataRow dr in dtsFiltros.Tables[0].Rows)
                {
                    strNome.Add(dr["PRO_C_NOME"].ToString());
                }

                foreach (DataRow dr in dtsFiltros.Tables[1].Rows)
                {
                    strCor.Add(dr["PRO_C_COR"].ToString());
                }

                txtNomeFiltro.AutoCompleteCustomSource = strNome;
                txtMarcaFiltro.AutoCompleteCustomSource = strMarca;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "CADASTRO DE ESTOQUE - CarregarForm");
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Estoque objEstoque = new Estoque();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "CADASTRO DE ESTOQUE - txtCodigo_TextChanged");
            }
        }

        private void txtCodigoFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!string.IsNullOrEmpty(txtCodigoFiltro.Text))
                    txtNomeFiltro.Focus();
            }
        }

        private void txtNomeFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
              btnPesquisar.PerformClick();
            
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
                Utilitarios.SalvarLog(ex.Message, "CADASTRO DE ESTOQUE - btnPesquisar_Click");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlMovimento.Visible = false;
            pnlListagem.Visible = true;

            this.PopularListagem();

            lblCodigoProduto.Text = string.Empty;
            lblNome.Text = string.Empty;
            lblDescricao.Text = string.Empty;
            lblTamanho.Text = string.Empty;
            lblCor.Text = string.Empty;
            lblReferencia.Text = string.Empty;
            lblCategoria.Text = string.Empty;
            lblMarca.Text = string.Empty;
            lblTipoMovimento.Text = string.Empty;
            txtQtde.Text = string.Empty;
            txtValorCusto.Text = string.Empty;
            txtValorVenda.Text = string.Empty;
            lblData.Text = DateTime.Now.ToString();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtQtde.Text) && !string.IsNullOrEmpty(txtValorCusto.Text) && !string.IsNullOrEmpty(txtValorVenda.Text))
                {
                    Estoque objEstoque = new Estoque();
                    objEstoque.CodigoBarrasProduto = lblCodigoProduto.Text;
                    objEstoque.CodigoProduto = Convert.ToInt32(lblCodProd.Text);
                    objEstoque.Movimento = lblTipoMovimento.Text;
                    objEstoque.Qtde = Convert.ToInt32(txtQtde.Text);
                    objEstoque.ValorCusto = Convert.ToDecimal(txtValorCusto.Text);
                    objEstoque.ValorVenda = Convert.ToDecimal(txtValorVenda.Text);
                    
                    if(lblTipoMovimento.Text == "SAÍDA" && objEstoque.Qtde  > this.intQtdeTotalEstoque)
                    {
                        MessageBox.Show("A quantidade a ser retirada não pode ser maior do que a quantidade total do estoque! Informe uma qtde menor ou igual a " + this.intQtdeTotalEstoque);
                        txtQtde.Focus();
                        return;
                    }

                    int intRetorno = objEstoque.Inserir(objEstoque);

                    if(lblTipoMovimento.Text == "ENTRADA")
                        MessageBox.Show("Quantidade incluída no estoque com sucesso!");
                    else
                        MessageBox.Show("Quantidade retirada do estoque com sucesso!");

                    lblCodigoProduto.Text = string.Empty;
                    lblNome.Text = string.Empty;
                    lblDescricao.Text = string.Empty;
                    lblTamanho.Text = string.Empty;
                    lblCor.Text = string.Empty;
                    lblReferencia.Text = string.Empty;
                    lblCategoria.Text = string.Empty;
                    lblMarca.Text = string.Empty;
                    lblTipoMovimento.Text = string.Empty;
                    txtQtde.Text = string.Empty;
                    txtValorCusto.Text = string.Empty;
                    txtValorVenda.Text = string.Empty;
                    lblData.Text = DateTime.Now.ToString();

                    pnlMovimento.Visible = false;
                    pnlListagem.Visible = true;
                    this.PopularListagem();
                }
                else
                {
                    MessageBox.Show("Informe a quantidade, o preço de custo e o preço de venda!");
                    txtQtde.Focus();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PopularListagem()
        {
            try
            {
                txtCodigoFiltro.Focus();
                Estoque objEstoque = new Estoque();
                DataTable dtEstoque = new DataTable();

                if (!string.IsNullOrEmpty(txtCodigoFiltro.Text))
                    objEstoque.CodigoBarrasProduto = txtCodigoFiltro.Text;

                if (!string.IsNullOrEmpty(txtNomeFiltro.Text))
                    objEstoque.NomeProduto = txtNomeFiltro.Text;

                if (!string.IsNullOrEmpty(txtReferenciaFiltro.Text))
                    objEstoque.Referencia = txtReferenciaFiltro.Text;

                if (!string.IsNullOrEmpty(txtCategoriaFiltro.Text))
                    objEstoque.Categoria = txtCategoriaFiltro.Text;

                if (!string.IsNullOrEmpty(txtMarcaFiltro.Text))
                    objEstoque.Fabricante = txtMarcaFiltro.Text;

                dtEstoque = objEstoque.ListarResumo(objEstoque);

                rgvEstoque.DataSource = dtEstoque;

                if (dtEstoque.Rows.Count > 0)
                {
                    rgvEstoque.Columns["PRO_N_CODIGO"].Visible = false;
                    rgvEstoque.Columns["Descrição"].Visible = false;
                    rgvEstoque.Columns["Nome"].Width = 300;
                    rgvEstoque.Columns["Tamanho"].Width = 100;
                    rgvEstoque.Columns["Código"].Width = 140;
                    rgvEstoque.Columns["Referência"].Width = 100;
                    rgvEstoque.Columns["Cor"].Width = 100;
                    rgvEstoque.Columns["Categoria"].Width = 150;
                    rgvEstoque.Columns["Marca"].Width = 150;
                    rgvEstoque.Columns["Qtde Total em Estoque"].Width = 200;
                    rgvEstoque.Columns["Preço Venda"].Width = 150;
                    rgvEstoque.Columns["Qtde Total em Estoque"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                    rgvEstoque.Columns["Preço Custo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                    rgvEstoque.Columns["Preço Venda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                    rgvEstoque.Columns["QtdeEstoqueTotal"].Visible = false;
                    rgvEstoque.Columns["ValorCustoEstoqueTotal"].Visible = false;

                    rgvEstoque.Columns["Preço Custo"].DefaultCellStyle.Format = "C2";
                    rgvEstoque.Columns["Preço Venda"].DefaultCellStyle.Format = "C2";

                    lblQtdeTotal.Text = dtEstoque.Rows[0]["QtdeEstoqueTotal"].ToString();
                    lblValorTotalEstoque.Text = Convert.ToDecimal(dtEstoque.Rows[0]["ValorCustoEstoqueTotal"]).ToString("C");
                }
                txtCodigoFiltro.Text = string.Empty;
                txtNomeFiltro.Text = string.Empty;

                //formatar grid
                DataGridViewCellStyle estiloCelulaHeader = new DataGridViewCellStyle();
                estiloCelulaHeader.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                estiloCelulaHeader.ForeColor = Color.DarkBlue;
                this.rgvEstoque.ColumnHeadersDefaultCellStyle = estiloCelulaHeader;
                this.rgvEstoque.DefaultCellStyle = estiloCelulaHeader;

                DataGridViewCellStyle estiloCelula = new DataGridViewCellStyle();
                estiloCelula.Font = new System.Drawing.Font("Arial", 10);
                estiloCelula.ForeColor = Color.Black;
                estiloCelula.BackColor = Color.White;
                this.rgvEstoque.RowsDefaultCellStyle = estiloCelula;

                DataGridViewCellStyle estiloCelulaAlternada = new DataGridViewCellStyle();
                estiloCelulaAlternada.BackColor = Color.Gainsboro;
                this.rgvEstoque.AlternatingRowsDefaultCellStyle = estiloCelulaAlternada;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "CADASTRO DE ESTOQUE - PopularListagem()");
            }
        }

        private void rgvEstoque_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                 var senderGrid = (DataGridView)sender;

                 if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                 {
                     if (e.ColumnIndex == 0)//adicionar entrada de mercadoria
                     {
                        Estoque objEstoque = new Estoque();
                        objEstoque.CodigoProduto = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);
                        DataTable dtEstoque = new DataTable();
                        dtEstoque = objEstoque.ListarResumo(objEstoque);
                        lblCodProd.Text = dtEstoque.Rows[0]["PRO_N_CODIGO"].ToString();
                        lblCodigoProduto.Text = dtEstoque.Rows[0]["Código"].ToString();
                        lblNome.Text = dtEstoque.Rows[0]["Nome"].ToString();
                        lblDescricao.Text = dtEstoque.Rows[0]["Descrição"].ToString();
                        lblTamanho.Text = dtEstoque.Rows[0]["Tamanho"].ToString();
                        lblCor.Text = dtEstoque.Rows[0]["Cor"].ToString();
                        lblReferencia.Text = dtEstoque.Rows[0]["Referência"].ToString();
                        lblCategoria.Text = dtEstoque.Rows[0]["Categoria"].ToString();
                        lblMarca.Text = dtEstoque.Rows[0]["Marca"].ToString();
                        lblTipoMovimento.Text = "ENTRADA";
                        lblData.Text = DateTime.Now.ToString();
                        txtValorCusto.Text = dtEstoque.Rows[0]["Preço Custo"].ToString();
                        txtValorVenda.Text = dtEstoque.Rows[0]["Preço Venda"].ToString();
                        txtQtde.Text = "1";
                        lblQtdeTotalProduto.Text = dtEstoque.Rows[0]["Qtde total em estoque"].ToString();

                        lblTitulo.Text = "Adicionar quantidade em estoque";
                        btnAdicionar.Text = "Adicionar";

                        pnlListagem.Visible = false;
                         pnlMovimento.Visible = true;

                         DataTable dtEstoqueProduto = new DataTable();
                         dtEstoqueProduto = objEstoque.Listar(objEstoque);
                         rgvEstoqueProduto.DataSource = dtEstoqueProduto;
                         rgvEstoqueProduto.Columns["Data Movimento"].Width = 120;
                         rgvEstoqueProduto.Columns["Tipo Movimento"].Width = 120;
                         rgvEstoqueProduto.Columns["Qtde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                         rgvEstoqueProduto.Columns["Preço Custo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                         rgvEstoqueProduto.Columns["Preço Venda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

                        rgvEstoqueProduto.Columns["Preço Custo"].DefaultCellStyle.Format = "C2";
                        rgvEstoqueProduto.Columns["Preço Venda"].DefaultCellStyle.Format = "C2";

                    }
                     else //excluir qtde em estoque
                     {
                         Estoque objEstoque = new Estoque();
                         objEstoque.CodigoProduto = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);
                         DataTable dtEstoque = new DataTable();
                         dtEstoque = objEstoque.ListarResumo(objEstoque);

                         lblTitulo.Text = "Retirar quantidade em estoque";
                         btnAdicionar.Text = "Retirar";
                         lblCodProd.Text = dtEstoque.Rows[0]["PRO_N_CODIGO"].ToString();
                         lblCodigoProduto.Text = dtEstoque.Rows[0]["Código"].ToString();
                         lblNome.Text = dtEstoque.Rows[0]["Nome"].ToString();
                         lblDescricao.Text = dtEstoque.Rows[0]["Descrição"].ToString();
                         lblTamanho.Text = dtEstoque.Rows[0]["Tamanho"].ToString();
                         lblCor.Text = dtEstoque.Rows[0]["Cor"].ToString();
                         lblReferencia.Text = dtEstoque.Rows[0]["Referência"].ToString();
                         lblCategoria.Text = dtEstoque.Rows[0]["Categoria"].ToString();
                         lblMarca.Text = dtEstoque.Rows[0]["Marca"].ToString();
                         lblTipoMovimento.Text = "SAÍDA";
                         lblData.Text = DateTime.Now.ToString();
                         this.intQtdeTotalEstoque = Convert.ToInt32(dtEstoque.Rows[0]["Qtde Total em Estoque"]);
                         txtQtde.Text = "1";
                         txtValorCusto.Text = dtEstoque.Rows[0]["Preço Custo"].ToString();
                         txtValorVenda.Text = dtEstoque.Rows[0]["Preço Venda"].ToString();

                         pnlListagem.Visible = false;
                         pnlMovimento.Visible = true;

                         DataTable dtEstoqueProduto = new DataTable();
                         dtEstoqueProduto = objEstoque.Listar(objEstoque);
                         rgvEstoqueProduto.DataSource = dtEstoqueProduto;

                         rgvEstoqueProduto.Columns["Data Movimento"].Width = 120;
                         rgvEstoqueProduto.Columns["Tipo Movimento"].Width = 120;
                         rgvEstoqueProduto.Columns["Qtde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                         rgvEstoqueProduto.Columns["Preço Custo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                         rgvEstoqueProduto.Columns["Preço Venda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

                        rgvEstoqueProduto.Columns["Preço Custo"].DefaultCellStyle.Format = "C2";
                        rgvEstoqueProduto.Columns["Preço Venda"].DefaultCellStyle.Format = "C2";

                    }
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "CADASTRO DE ESTOQUE - rgvEstoque_CellContentClick");
            }
        }

        private void txtQtde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtValorCusto.Focus();
        }

        private void txtValorCusto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!string.IsNullOrEmpty(txtValorCusto.Text) && string.IsNullOrEmpty(txtValorVenda.Text))
                {
                    txtValorVenda.Text = (Convert.ToDecimal(txtValorCusto.Text) * 2).ToString("N2");//acrescentando 100% sobre o preço de venda
                }
                txtValorVenda.Focus();
            }
        }

        private void txtValorVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnAdicionar.PerformClick();
        }

        private void rgvEstoqueProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //excluir um movimento mediante confirmação
            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 0)//excluir movimento de estoque
                    {
                        if (MessageBox.Show("Confirma exclusão do movimento de estoque?", "Exclusão de movimento", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            Estoque objEstoque = new Estoque();
                            objEstoque.Codigo = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells["Código Mov."].Value);
                            objEstoque.Excluir(objEstoque);
                            MessageBox.Show("Movimento excluído com sucesso! ");

                            lblCodigoProduto.Text = string.Empty;
                            lblNome.Text = string.Empty;
                            lblDescricao.Text = string.Empty;
                            lblTamanho.Text = string.Empty;
                            lblCor.Text = string.Empty;
                            lblReferencia.Text = string.Empty;
                            lblCategoria.Text = string.Empty;
                            lblMarca.Text = string.Empty;
                            lblTipoMovimento.Text = string.Empty;
                            txtQtde.Text = string.Empty;
                            txtValorCusto.Text = string.Empty;
                            txtValorVenda.Text = string.Empty;
                            lblData.Text = DateTime.Now.ToString();

                            pnlMovimento.Visible = false;
                            pnlListagem.Visible = true;
                            this.PopularListagem();

                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "CADASTRO DE ESTOQUE - rgvEstoqueProduto_CellContentClick");
            }
            
        }

        private void btnVerTotais_Click(object sender, EventArgs e)
        {
            pnlSenha.Visible = true;
            btnVerTotais.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtSenha.Text == "ivancamila")
                {
                    pnlSenha.Visible = false;
                    pnlTotal.Visible = true;
                }
                else
                {
                    MessageBox.Show("Senha incorreta!");
                }

                txtSenha.Text = string.Empty;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "CADASTRO DE ESTOQUE - ver Totais");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlTotal.Visible = false;
            btnVerTotais.Visible = true;
        }

        private void txtValorCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 190 || e.KeyChar == 46)
            {
                e.KeyChar = (char)44;
            }
        }

        private void txtValorVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 190 || e.KeyChar == 46)
            {
                e.KeyChar = (char)44;
            }
        }
    }
}
