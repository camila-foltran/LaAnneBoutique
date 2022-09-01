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
    public partial class frmProduto : Form
    {
        public frmProduto()
        {
            InitializeComponent();
            //popular combos

            try
            {
                Categoria objCategoria = new Categoria();
                DataTable dtCategoria = new DataTable();
                objCategoria.Status = true;
                dtCategoria = objCategoria.Listar(objCategoria);
                ddlCategoria.Items.Insert(0, "Selecione...");
                ddlCategoria.DataSource = dtCategoria;
                ddlCategoria.DisplayMember = "Descrição";
                ddlCategoria.ValueMember = "Código";

                //procura pela categoria vestuário
                DataRow[] drCat = dtCategoria.Select("Descrição = 'VESTUÁRIO'");
                if (drCat.Length > 0)
                    ddlCategoria.SelectedValue = drCat[0]["Código"].ToString();


                Fabricante objFabricante = new Fabricante();
                DataTable dtFabricante = new DataTable();
                objFabricante.Status = true;
                dtFabricante = objFabricante.Listar(objFabricante);
                ddlMarca.DataSource = dtFabricante;
                ddlMarca.DisplayMember = "Descrição";
                ddlMarca.ValueMember = "Código";

                this.PopularListagem();

                txtCodigoFiltro.Focus();

                //carregar text categoria e marca
                AutoCompleteStringCollection strCategoria = new AutoCompleteStringCollection();
                AutoCompleteStringCollection strMarca = new AutoCompleteStringCollection();
                AutoCompleteStringCollection strNome = new AutoCompleteStringCollection();
                AutoCompleteStringCollection strCor = new AutoCompleteStringCollection();

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
                txtNome.AutoCompleteCustomSource = strNome;
                txtCor.AutoCompleteCustomSource = strCor;
                txtMarcaFiltro.AutoCompleteCustomSource = strMarca;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "CADASTRO DE PRODUTOS - frmProduto()");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnGerouCodigo = false;

                if (!string.IsNullOrEmpty(txtNome.Text))
                {
                    Produto objProduto = new Produto();

                    if(string.IsNullOrEmpty(txtCodigo.Text))
                    {
                        objProduto.CodigoProduto = this.GerarCodigoBarras();
                        if (string.IsNullOrEmpty(objProduto.CodigoProduto))
                        {
                            MessageBox.Show("Ocorreu um erro ao gerar o código do produto!");
                            return;
                        }
                        blnGerouCodigo = true;
                    }
                    else
                        objProduto.CodigoProduto = txtCodigo.Text.ToUpper();

                    objProduto.Nome = txtNome.Text.ToUpper();
                    objProduto.Descricao = txtDescricao.Text.ToUpper();
                    objProduto.Tamanho = txtTamanho.Text.ToUpper();
                    objProduto.Cor = txtCor.Text.ToUpper();
                    objProduto.Referencia = txtReferencia.Text.ToUpper();
                    objProduto.Status = chkStatus.Checked;

                    try
                    {
                        objProduto.CodigoCategoria = Convert.ToInt32(ddlCategoria.SelectedValue);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Selecione a categoria!");
                        ddlCategoria.Focus();
                        return;
                    }

                    try
                    {
                        objProduto.CodigoFabricante = Convert.ToInt32(ddlMarca.SelectedValue);
                   
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("selecione a marca! ");
                        ddlMarca.Focus();
                        return;
                    }

                    if (txtCodigo.Enabled)//inclusao
                    {
                        int intCodigoProduto = objProduto.Inserir(objProduto);

                        Estoque objEstoque = new Estoque();
                        objEstoque.CodigoProduto = intCodigoProduto;
                        objEstoque.CodigoBarrasProduto = objProduto.CodigoProduto;
                        objEstoque.Movimento = "ENTRADA";

                        if (!string.IsNullOrEmpty(txtQtde.Text))
                            objEstoque.Qtde = Convert.ToInt32(txtQtde.Text);
                        else
                            objEstoque.Qtde = 1;

                        if(!string.IsNullOrEmpty(txtValorCusto.Text))
                            objEstoque.ValorCusto = Convert.ToDecimal(txtValorCusto.Text);

                        if(!string.IsNullOrEmpty(txtValorVenda.Text))
                            objEstoque.ValorVenda = Convert.ToDecimal(txtValorVenda.Text);

                        objEstoque.Inserir(objEstoque);

                        if (blnGerouCodigo)
                            MessageBox.Show("Produto incluído com sucesso! CÓDIGO: " + objProduto.CodigoProduto);
                        else
                            MessageBox.Show("Produto incluído com sucesso!");

                    }
                    else//edicao
                    {
                        objProduto.Codigo = Convert.ToInt32(lblCodigo.Text);
                        objProduto.Alterar(objProduto);
                        MessageBox.Show("Alterações salvas com sucesso!");

                        pnlCadastro.Visible = false;
                        pnlListagem.Visible = true;
                    }

                    txtCodigo.Text = string.Empty;
                    txtCodigo.Enabled = true;
                    txtNome.Text = string.Empty;
                    txtDescricao.Text = string.Empty;
                    txtCor.Text = string.Empty;
                    txtTamanho.Text = string.Empty;
                    txtReferencia.Text = string.Empty;
                    txtValorCusto.Text = string.Empty;
                    txtValorVenda.Text = string.Empty;
                    txtCodigo.Focus();

                    this.PopularListagem();
                }
                else
                {
                    MessageBox.Show("Informe o nome e a descrição!");
                    txtCodigo.Focus();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_tb_pro_produto"))
                {
                    //cadastrar entrada em movimento de estoque
                    Estoque objEstoque = new Estoque();
                    DataTable dtProduto = new DataTable();
                    Produto objProd = new Produto();

                    objProd.CodigoProduto = txtCodigo.Text.ToUpper();
                    objProd.Tamanho = txtTamanho.Text.ToUpper();
                    objProd.Cor = txtCor.Text.ToUpper();

                    dtProduto = objProd.Listar(objProd);

                    if(dtProduto.Rows.Count > 0)
                    {
                        objEstoque.CodigoProduto = Convert.ToInt32(dtProduto.Rows[0]["pro_n_codigo"]);
                        objEstoque.CodigoBarrasProduto = dtProduto.Rows[0]["Código"].ToString();
                        objEstoque.Movimento = "ENTRADA";

                        if (!string.IsNullOrEmpty(txtQtde.Text))
                            objEstoque.Qtde = Convert.ToInt32(txtQtde.Text);
                        else
                            objEstoque.Qtde = 1;

                        if (!string.IsNullOrEmpty(txtValorCusto.Text))
                            objEstoque.ValorCusto = Convert.ToDecimal(txtValorCusto.Text);

                        if (!string.IsNullOrEmpty(txtValorVenda.Text))
                            objEstoque.ValorVenda = Convert.ToDecimal(txtValorVenda.Text);

                        objEstoque.Inserir(objEstoque);
                        MessageBox.Show("Produto incluído com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Produto já cadastrado!");
                        txtCodigo.Text = string.Empty;
                        txtCodigo.Enabled = true;
                        txtNome.Text = string.Empty;
                        txtDescricao.Text = string.Empty;
                        txtCor.Text = string.Empty;
                        txtTamanho.Text = string.Empty;
                        txtReferencia.Text = string.Empty;
                        txtCodigo.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                    Utilitarios.SalvarLog(ex.Message, "CADASTRO DE PRODUTOS - btnSalvar_Click");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                pnlCadastro.Visible = false;
                pnlListagem.Visible = true;
                this.PopularListagem();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                pnlCadastro.Visible = true;
                pnlListagem.Visible = false;

                txtCodigo.Text = string.Empty;
                txtCodigo.Enabled = true;
                txtNome.Text = string.Empty;
                txtDescricao.Text = string.Empty;
                txtCor.Text = string.Empty;
                txtTamanho.Text = string.Empty;
                txtReferencia.Text = string.Empty;
                txtQtde.Text = "1";
                txtValorCusto.Text = string.Empty;
                txtValorVenda.Text = string.Empty;
                txtCodigo.Focus();
                pnlEstoque.Visible = true;

            }
            catch (Exception ex)
            {
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
                Utilitarios.SalvarLog(ex.Message, "CADASTRO DE PRODUTOS - btnPesquisar_Click");
            }
        }

        private void rgvProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 0)//editar; popular dados com o código 
                    {
                        Produto objProduto = new Produto();
                        DataTable dtProduto = new DataTable();
                        objProduto.Codigo = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);
                        dtProduto = objProduto.Listar(objProduto);
                        //popular campos de edição

                        lblTitulo.Text = "Alterar produto";
                        lblCodigo.Text = objProduto.Codigo.ToString();
                        txtCodigo.Text = dtProduto.Rows[0]["Código"].ToString();
                        txtCodigo.Enabled = false;
                        txtNome.Text = dtProduto.Rows[0]["Nome"].ToString();
                        txtDescricao.Text = dtProduto.Rows[0]["Descrição"].ToString();
                        txtTamanho.Text = dtProduto.Rows[0]["Tamanho"].ToString();
                        txtCor.Text = dtProduto.Rows[0]["Cor"].ToString();
                        txtReferencia.Text = dtProduto.Rows[0]["Referência"].ToString();
                        chkStatus.Checked = Convert.ToBoolean(dtProduto.Rows[0]["Status"]);
                        ddlCategoria.SelectedValue = dtProduto.Rows[0]["CodigoCategoria"].ToString();
                        ddlMarca.SelectedValue = dtProduto.Rows[0]["CodigoFabricante"].ToString();
                        pnlEstoque.Visible = false;
                        pnlListagem.Visible = false;
                        pnlCadastro.Visible = true;
                    }
                    else if (e.ColumnIndex == 1)//excluir
                    {
                        if (MessageBox.Show("Confirma exclusão do produto e dos movimentos de estoque relacionados a ele?", "Exclusão de produto", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            Produto objProduto = new Produto();
                            objProduto.Codigo = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);

                            //antes de excluir, procura pelo produto na tabela de venda e troca, se achar, não pode excluir
                            DataSet dtsProduto = new DataSet();
                            dtsProduto = objProduto.ListarProdutoVendidoOuTrocado(objProduto);

                            if(dtsProduto.Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show("Esse produto não pode ser excluído pois existe(m) venda(s) vinculada(s). Se você não deseja mais que ele esteja disponível para venda, inative-o.");
                                return;
                            }
                            else if(dtsProduto.Tables[1].Rows.Count > 0)
                            {
                                MessageBox.Show("Esse produto não pode ser excluído pois existe(m) troca(s) vinculada(s). Se você não deseja mais que ele esteja disponível, inative-o.");
                                return;
                            }

                            objProduto.Excluir(objProduto);
                            MessageBox.Show("Produto excluído com sucesso!");
                        }
                    }

                    this.PopularListagem();
                }
            }
            catch (Exception ex)
            {
                //tratar aqui caso o produto esteja relacionado com alguma venda
                if (ex.Message.Contains("FK_tb_est_estoque_tb_pro_produto"))
                {
                    MessageBox.Show("O produto não pode ser excluído pois existem movimentações no estoque.");
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                    Utilitarios.SalvarLog(ex.Message, "CADASTRO DE PRODUTOS - rgvProduto_CellContentClick");
                }
            }
        }

        public void PopularListagem()
        {
            try
            {
                Produto objProduto = new Produto();
                DataTable dtProduto = new DataTable();

                if (!string.IsNullOrEmpty(txtCodigoFiltro.Text))
                    objProduto.CodigoProduto = txtCodigoFiltro.Text.ToUpper();

                if (!string.IsNullOrEmpty(txtNomeFiltro.Text))
                    objProduto.Nome = txtNomeFiltro.Text.ToUpper();

                if (!string.IsNullOrEmpty(txtReferenciaFiltro.Text))
                    objProduto.Referencia = txtReferenciaFiltro.Text;

                if (!string.IsNullOrEmpty(txtCategoriaFiltro.Text))
                    objProduto.Categoria = txtCategoriaFiltro.Text;

                if (!string.IsNullOrEmpty(txtMarcaFiltro.Text))
                    objProduto.Fabricante = txtMarcaFiltro.Text;

                dtProduto = objProduto.Listar(objProduto);

                rgvProduto.DataSource = dtProduto;

                if (dtProduto.Rows.Count > 0)
                {
                    rgvProduto.Columns["PRO_N_CODIGO"].Visible = false;
                    rgvProduto.Columns["Código"].Width = 120;//CÓDIGO
                    rgvProduto.Columns["Nome"].Width = 300;
                    rgvProduto.Columns["Descrição"].Visible = false;
                    rgvProduto.Columns["CodigoFabricante"].Visible = false;
                    rgvProduto.Columns["Marca"].Width = 160;
                    rgvProduto.Columns["CodigoCategoria"].Visible = false;
                    rgvProduto.Columns["Categoria"].Width = 150;
                    rgvProduto.Columns["Status"].Width = 70;
                    rgvProduto.Columns["Tamanho"].Width = 100;
                    //rgvProduto.Columns["Status"].Width = 70;
                    rgvProduto.Columns["Qtde Estoque"].Width = 140;
                    rgvProduto.Columns["Valor Custo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                    rgvProduto.Columns["Valor Venda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                    rgvProduto.Columns["Qtde Estoque"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

                    rgvProduto.Columns["Valor Custo"].DefaultCellStyle.Format = "C2";
                    rgvProduto.Columns["Valor Venda"].DefaultCellStyle.Format = "C2";

                    rgvProduto.Columns["QtdeEstoqueTotal"].Visible = false;
                    rgvProduto.Columns["ValorCustoEstoqueTotal"].Visible = false;

                    //labels de totais:
                    lblQtdeTotal.Text = dtProduto.Rows[0]["QtdeEstoqueTotal"].ToString();
                    lblValorTotalEstoque.Text = Convert.ToDecimal(dtProduto.Rows[0]["ValorCustoEstoqueTotal"]).ToString("C");
                }
                else
                {
                    lblQtdeTotal.Text = "0";
                    lblValorTotalEstoque.Text = "R$ 0,00";
                }
                //formatar grid
                DataGridViewCellStyle estiloCelulaHeader = new DataGridViewCellStyle();
                estiloCelulaHeader.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                estiloCelulaHeader.ForeColor = Color.DarkBlue;
                this.rgvProduto.ColumnHeadersDefaultCellStyle = estiloCelulaHeader;
                this.rgvProduto.DefaultCellStyle = estiloCelulaHeader;

                DataGridViewCellStyle estiloCelula = new DataGridViewCellStyle();
                estiloCelula.Font = new System.Drawing.Font("Arial", 10);
                estiloCelula.ForeColor = Color.Black;
                estiloCelula.BackColor = Color.White;
                this.rgvProduto.RowsDefaultCellStyle = estiloCelula;

                DataGridViewCellStyle estiloCelulaAlternada = new DataGridViewCellStyle();
                estiloCelulaAlternada.BackColor = Color.Gainsboro;
                this.rgvProduto.AlternatingRowsDefaultCellStyle = estiloCelulaAlternada;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gerar um código de barras para o produto caso ele não possua; o código padrão tem 13 caracteres, para diferenciar dos demais, iremos gerar um código com no máximo 6.
        /// </summary>
        /// <returns>Código gerado</returns>
        public string GerarCodigoBarras()
        {
            try
            {
                Random random = new Random();
                int intCodigoProduto = random.Next(999999);

                DataTable dtProduto = new DataTable();
                Produto objProduto = new Produto();
                objProduto.CodigoProduto = intCodigoProduto.ToString();
                dtProduto = objProduto.Listar(objProduto);

                while(dtProduto.Rows.Count > 0)
                {
                    random = new Random();
                    intCodigoProduto = random.Next(999999);
                    dtProduto = new DataTable();
                    objProduto.CodigoProduto = intCodigoProduto.ToString();
                    dtProduto = objProduto.Listar(objProduto);
                }

                return intCodigoProduto.ToString();
            }
            catch(Exception ex)
            {
                Utilitarios.SalvarLog(ex.Message, "CADASTRO DE PRODUTOS - GerarCodigoBarras()");
                return string.Empty;
            }
        }
        
        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            txtNomeFiltro.Focus();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue.Equals(13))
                {
                    if (!string.IsNullOrEmpty(txtCodigo.Text))
                    {
                        //procura pelo produto, caso já exista já mostra msg, assim evita preenchimento de tudo
                        DataTable dtProduto = new DataTable();
                        Produto objProduto = new Produto();
                        objProduto.CodigoProduto = txtCodigo.Text;
                        dtProduto = objProduto.Listar(objProduto);

                        if (dtProduto.Rows.Count > 0)
                        {
                            txtNome.Text = dtProduto.Rows[0]["Nome"].ToString();
                            txtCor.Text = dtProduto.Rows[0]["Cor"].ToString();
                            txtValorCusto.Text = dtProduto.Rows[0]["Valor Custo"].ToString();
                            txtValorVenda.Text = dtProduto.Rows[0]["Valor Venda"].ToString();

                            if(dtProduto.Rows[0]["Referência"] != DBNull.Value)
                                txtReferencia.Text = dtProduto.Rows[0]["Referência"].ToString();

                            ddlCategoria.SelectedValue = dtProduto.Rows[0]["CodigoCategoria"].ToString();
                            ddlMarca.SelectedValue = dtProduto.Rows[0]["CodigoFabricante"].ToString();
                            txtTamanho.Focus();
                        }
                        else
                            txtReferencia.Focus();
                    }

                }
            }
            catch(Exception ex)
            {
                Utilitarios.SalvarLog(ex.Message, "PRODUTO - txtCodigo_KeyDown");
            }
            
        }

        private void txtCodigoFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigoFiltro.Text))
            {
                if (e.KeyValue == 13)
                    txtNomeFiltro.Focus();
            }
        }

        private void txtNomeFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNomeFiltro.Text))
            {
                if (e.KeyValue == 13)
                    btnPesquisar.PerformClick();
            }
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyValue.Equals(13))
                    txtTamanho.Focus();
        }

        private void txtDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {  
                 txtTamanho.Focus();
            }
            
        }

        private void txtTamanho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                txtCor.Focus();
            }
           
        }

        private void txtCor_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCor.Text))
            {
                if (e.KeyValue.Equals(13))
                {
                    if (pnlEstoque.Visible)
                        txtValorCusto.Focus();
                    else
                        btnSalvar.Focus();
                }
                   
            }
        }

        private void txtReferencia_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtReferencia.Text))
                {
                    if (e.KeyValue.Equals(13))
                    {
                        Produto objProduto = new Produto();
                        DataTable dtProduto = new DataTable();
                        objProduto.Referencia = txtReferencia.Text;
                        dtProduto = objProduto.Listar(objProduto);

                        if (dtProduto.Rows.Count > 0)
                        {
                            txtNome.Text = dtProduto.Rows[0]["Nome"].ToString();
                            txtCor.Text = dtProduto.Rows[0]["Cor"].ToString();

                            if (dtProduto.Rows[0]["Referência"] != DBNull.Value)
                                txtReferencia.Text = dtProduto.Rows[0]["Referência"].ToString();

                            txtValorCusto.Text = dtProduto.Rows[0]["Valor Custo"].ToString();
                            txtValorVenda.Text = dtProduto.Rows[0]["Valor Venda"].ToString();
                            ddlCategoria.SelectedValue = dtProduto.Rows[0]["CodigoCategoria"].ToString();
                            ddlMarca.SelectedValue = dtProduto.Rows[0]["CodigoFabricante"].ToString();
                            txtTamanho.Focus();
                        }
                        else
                            txtNome.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "CADASTRO DE PRODUTOS - txtReferencia_KeyDown");
            }
        }

        private void txtReferencia_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtReferencia.Text))
                {

                    Produto objProduto = new Produto();
                    DataTable dtProduto = new DataTable();
                    objProduto.Referencia = txtReferencia.Text;
                    dtProduto = objProduto.Listar(objProduto);

                    if (dtProduto.Rows.Count > 0)
                    {
                        txtNome.Text = dtProduto.Rows[0]["Nome"].ToString();
                        txtCor.Text = dtProduto.Rows[0]["Cor"].ToString();
                        txtValorCusto.Text = dtProduto.Rows[0]["Valor Custo"].ToString();
                        txtValorVenda.Text = dtProduto.Rows[0]["Valor Venda"].ToString();
                        ddlCategoria.SelectedValue = dtProduto.Rows[0]["CodigoCategoria"].ToString();
                        ddlMarca.SelectedValue = dtProduto.Rows[0]["CodigoFabricante"].ToString();
                        txtTamanho.Focus();
                    }
                    else
                        txtNome.Focus();

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "CADASTRO DE PRODUTOS - txtReferencia_KeyDown");
            }
        }

        private void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
           // if (ddlCategoria.SelectedValue != null)
              //  ddlMarca.Focus();
        }

        private void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlMarca.SelectedValue != null)
              //  chkStatus.Focus();
        }

        private void txtValorCusto_KeyDown(object sender, KeyEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "CADASTRO DE PRODUTOS - txtValorCusto_KeyDown");
            }
        }

        private void txtValorCusto_Leave(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(txtValorCusto.Text) && string.IsNullOrEmpty(txtValorVenda.Text))
                {
                    txtValorVenda.Text = (Convert.ToDecimal(txtValorCusto.Text) * 2).ToString("N2");//acrescentando 100% sobre o preço de venda
                }

                txtValorVenda.Focus();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "CADASTRO DE PRODUTOS - txtValorCusto_Leave");
            }
        }

        private void txtValorVenda_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    if (!string.IsNullOrEmpty(txtValorVenda.Text) && string.IsNullOrEmpty(txtValorCusto.Text))
                    {
                        txtValorCusto.Text = (Convert.ToDecimal(txtValorVenda.Text) / 2).ToString("N2");//acrescentando 100% sobre o preço de venda
                    }

                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "CADASTRO DE PRODUTOS - txtValorVenda_KeyDown");
            }
        }

        private void txtValorVenda_Leave(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(txtValorVenda.Text) && string.IsNullOrEmpty(txtValorCusto.Text))
                {
                    txtValorCusto.Text = (Convert.ToDecimal(txtValorVenda.Text) / 2).ToString("N2");//acrescentando 100% sobre o preço de venda
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "CADASTRO DE PRODUTOS - txtValorVenda_Leave");
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void btnVerTotais_Click(object sender, EventArgs e)
        {
            pnlSenha.Visible = true;
            btnVerTotais.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlTotal.Visible = false;
            btnVerTotais.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSenha.Text == "ivancamila")
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
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "CADASTRO DE ESTOQUE - ver Totais");
            }
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
