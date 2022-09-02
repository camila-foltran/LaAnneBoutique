using Loja;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bematech;
using Bematech.Texto;
using Bematech.MiniImpressoras;
using System.IO;
using Vip.Printer;
using Vip.Printer.Enums;
using CIDPrinter;

namespace loja
{
    public partial class frmVenda : Form
    {

        StringBuilder strTeste = new StringBuilder();

        #region Variáveis

        public int intCodigoVenda = 0;
        public decimal decTotalPagar = 0;
        public decimal decDesconto = 0;
        public decimal decAcrescimo = 0;
        public string strComprovante = string.Empty;

        #endregion

        public frmVenda()
        {
            InitializeComponent();
            this.CarregarForm();
        }

        public void CarregarForm()
        {
            try
            {
                txtCodigo.Focus();
                //verifica se o vendedor já abriu o caixa hoje
                DataTable dtCaixa = new DataTable();
                Caixa objCaixa = new Caixa();
                objCaixa.Data = DateTime.Now;
                objCaixa.CodigoLoja = Convert.ToInt32(ConfigurationManager.AppSettings["CodigoLoja"]);
                dtCaixa = objCaixa.Listar(objCaixa);

                if (dtCaixa.Rows.Count == 0)
                {
                    MessageBox.Show("O caixa ainda não foi aberto!");
                    this.Close();
                    return;
                }

                this.intCodigoVenda = 0;
                Produto objProduto = new Produto();
                DataTable dtProduto = new DataTable();
                objProduto.Status = true;
                //listar somente produtos que possuem qtde > 0 em estoque
                dtProduto = objProduto.ListarVenda(objProduto);

                AutoCompleteStringCollection strCodigo = new AutoCompleteStringCollection();


                foreach (DataRow dr in dtProduto.Rows)
                {
                    strCodigo.Add(dr["Código"].ToString());
                }

                txtCodigo.AutoCompleteCustomSource = strCodigo;


                DataTable dtVendedores = new DataTable();
                Usuario objUsuario = new Usuario();
                objUsuario.Status = true;
                dtVendedores = objUsuario.Listar(objUsuario);

                AutoCompleteStringCollection strCodigoVendedores = new AutoCompleteStringCollection();

                foreach (DataRow dr in dtVendedores.Rows)
                {
                    strCodigoVendedores.Add(dr["Código"].ToString());
                }

                txtCodigoVendedor.AutoCompleteCustomSource = strCodigoVendedores;

                lblDataVenda.Text = DateTime.Now.ToShortDateString();


                ddlFormaPagto.DataSource = objProduto.ListarFormaPagto(objProduto);
                ddlFormaPagto.DisplayMember = "FPG_C_DESCRICAO";
                ddlFormaPagto.ValueMember = "FPG_N_CODIGO";
                ddlFormaPagto.SelectedValue = Utilitarios.CodigoSelecione;

                //popular combo de produtos, para poder digitar e selecionar o produto sem ter q digitar o código
                objProduto = new Produto();
                DataTable dtProdutos = new DataTable();
                dtProdutos = objProduto.ListarProdutoCombo(objProduto);
                dtProdutos.Rows.Add(0, "0", "Digite ou Selecione...", "descr", "tam", "ref", "cor", 0, "marca", 0, "categoria", 1, "Selecione...", 0, 0);

                DataView dv = dtProdutos.DefaultView;
                dv.Sort = "pro_n_codigo";
                dtProdutos = dv.ToTable();

                ddlProduto.DisplayMember = "Nome";
                ddlProduto.ValueMember = "pro_n_codigo";
                ddlProduto.DataSource = dtProdutos;


                txtValorRecebido.Text = "0";
                txtDesconto.Text = "0";
                txtAcrescimo.Text = "0";
                lblTotalPagar.Text = "0";
                txtSubTotal.Text = "0";
                lblTroco.Text = "0";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "VENDAS - CarregarForm()");
            }
        }

        public void LimparForm()
        {
            txtCodigo.Text = string.Empty;
            ddlProduto.SelectedValue = 0;
            ddlFormaPagto.SelectedValue = Utilitarios.CodigoSelecione;
            txtAcrescimo.Text = string.Empty;
            txtDesconto.Text = string.Empty;
            txtValorRecebido.Text = string.Empty;
            txtSubTotal.Text = string.Empty;
            lblValorUnit.Text = string.Empty;
            lblTotalPagar.Text = "R$ 0,00";
            txtDesconto.Text = "0";
            txtAcrescimo.Text = "0";
            txtValorRecebido.Text = "0";
            txtSubTotal.Text = "0";
            lblTroco.Text = "0";
            lblCodigoVenda.Text = string.Empty;
            txtCodigoVendedor.Text = string.Empty;
            txtValorDinheiro.Text = string.Empty;
            txtCPF.Text = string.Empty;
            this.intCodigoVenda = 0;
            this.decTotalPagar = 0;
            this.decDesconto = 0;
            this.decAcrescimo = 0;
            this.CarregarForm();
        }

        public void AdicionarProduto()
        {
            try
            {
                if (!string.IsNullOrEmpty(ddlProduto.SelectedValue.ToString()))
                {
                    //adicionar a venda caso seja 1º produto e adicionar os itens da venda
                    if (intCodigoVenda == 0)
                    {
                        Venda objVenda = new Venda();
                        objVenda.CodigoUsuario = Utilitarios.intCodigoVendedor;
                        intCodigoVenda = objVenda.Inserir(objVenda);
                        lblCodigoVenda.Text = intCodigoVenda.ToString("000000");
                    }

                    ItemVenda objItemVenda = new ItemVenda();
                    objItemVenda.CodigoVenda = intCodigoVenda;
                    objItemVenda.CodigoProduto = Convert.ToInt32(ddlProduto.SelectedValue);
                    objItemVenda.CodigoProdutoString = txtCodigo.Text;
                    objItemVenda.Qtde = 1;
                    objItemVenda.ValorUnitario = Convert.ToDecimal(lblValorUnit.Text.Replace("R$", "").Replace(".", ""));
                    objItemVenda.ValorTotal = Convert.ToDecimal(objItemVenda.Qtde) * objItemVenda.ValorUnitario;

                    objItemVenda.Inserir(objItemVenda);

                    this.CalculaValores();

                    DataTable dtItensVenda = new DataTable();
                    objItemVenda = new ItemVenda();
                    objItemVenda.CodigoVenda = this.intCodigoVenda;
                    dtItensVenda = objItemVenda.Listar(objItemVenda).Tables[0];
                    rgvProdutos.DataSource = dtItensVenda;

                    rgvProdutos.Columns["itv_n_codigo"].Visible = false;
                    rgvProdutos.Columns["itv_pro_n_codigo"].Visible = false;
                    rgvProdutos.Columns["Valor Total"].Visible = false;
                    rgvProdutos.Columns["Produto"].Width = 190;
                    rgvProdutos.Columns["Marca"].Width = 130;
                    rgvProdutos.Columns["Qtde"].Width = 50;
                    rgvProdutos.Columns["Valor Unit."].Width = 100;
                    rgvProdutos.Columns["Nome"].Visible = false;
                    rgvProdutos.Columns["Cor"].Visible = false;
                    rgvProdutos.Columns["Tamanho"].Visible = false;
                    rgvProdutos.Columns["Valor Unit."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                    rgvProdutos.Columns["Qtde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

                    rgvProdutos.Columns["Valor Unit."].DefaultCellStyle.Format = "C2";

                    //formatar grid
                    DataGridViewCellStyle estiloCelulaHeader = new DataGridViewCellStyle();
                    estiloCelulaHeader.Font = new System.Drawing.Font("Arial", 10);
                    estiloCelulaHeader.ForeColor = Color.DarkBlue;
                    this.rgvProdutos.ColumnHeadersDefaultCellStyle = estiloCelulaHeader;
                    this.rgvProdutos.DefaultCellStyle = estiloCelulaHeader;

                    DataGridViewCellStyle estiloCelula = new DataGridViewCellStyle();
                    estiloCelula.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                    estiloCelula.ForeColor = Color.DarkBlue;
                    estiloCelula.BackColor = Color.White;
                    this.rgvProdutos.RowsDefaultCellStyle = estiloCelula;

                    txtCodigo.Text = string.Empty;
                    ddlProduto.SelectedValue = 0;
                    lblValorUnit.Text = string.Empty;
                    lblValorUnit.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "VENDAS - btnAdicionar_Click");
            }
        }

        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {
            try
            {
                this.intCodigoVenda = 0;

                DataTable dtItensVenda = new DataTable();
                ItemVenda objItemVenda = new ItemVenda();
                objItemVenda.CodigoVenda = this.intCodigoVenda;
                dtItensVenda = objItemVenda.Listar(objItemVenda).Tables[0];
                rgvProdutos.DataSource = dtItensVenda;
                rgvProdutos.Columns[1].Visible = false;
                this.LimparForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "VENDAS - btnCancelarVenda_Click");
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtCodigo.Text))
                    {

                        Produto objProduto = new Produto();
                        DataTable dtProduto = new DataTable();
                        objProduto.CodigoProduto = txtCodigo.Text;
                        dtProduto = objProduto.ListarProdutoCombo(objProduto);
                        dtProduto.Rows.Add(0, "0", "nome", "descr", "tam", "ref", "cor", 0, "marca", 0, "categoria", 1, "Selecione...", 0, 0);

                        DataView dv = dtProduto.DefaultView;
                        dv.Sort = "pro_n_codigo";
                        dtProduto = dv.ToTable();

                        ddlProduto.DisplayMember = "produto";
                        ddlProduto.ValueMember = "pro_n_codigo";

                        if (dtProduto.Rows.Count > 1)
                        {
                            ddlProduto.DataSource = dtProduto;

                            if (dtProduto.Rows.Count == 2)
                                ddlProduto.SelectedValue = dtProduto.Rows[1]["pro_n_codigo"].ToString();
                            else//Se tiver mais de 1 produto, abre combo para seleção
                                ddlProduto.DroppedDown = true;
                        }
                        else
                        {
                            MessageBox.Show("Produto não encontrado!");
                            txtCodigo.Text = string.Empty;
                            txtCodigo.Focus();
                            ddlProduto.SelectedValue = 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                    Utilitarios.SalvarLog(ex.Message, "VENDAS - txtCodigo_KeyDown");
                }
            }
        }

        private void ddlProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(ddlProduto.SelectedValue != null)
                {
                    if(Convert.ToInt32(ddlProduto.SelectedValue) > 0)
                    {
                        Produto objProduto = new Produto();
                        DataTable dtProduto = new DataTable();
                        objProduto.Codigo = Convert.ToInt32(ddlProduto.SelectedValue);
                        dtProduto = objProduto.Listar(objProduto);
                        txtCodigo.Text = txtCodigo.Text = dtProduto.Rows[0]["Código"].ToString();
                        lblValorUnit.Text = Convert.ToDecimal(dtProduto.Rows[0]["Valor Venda"]).ToString("C");

                        this.AdicionarProduto();
                    }
                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "VENDAS - ddlProduto_SelectedIndexChanged");
            }
        }

        private void txtValorRecebido_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 194)//ponto
                {
                    //nao sei ainda
                }
                if (e.KeyValue == 13)
                {
                    if (!string.IsNullOrEmpty(txtValorRecebido.Text))
                    {
                        this.CalculaValores();
                        //pagamento parcial
                        if (Convert.ToDecimal(txtValorRecebido.Text) < this.decTotalPagar)
                        {
                            lblTotalPagar.Text = (this.decTotalPagar - Convert.ToDecimal(txtValorRecebido.Text)).ToString("C");

                        }
                        else
                            lblTroco.Text = (Convert.ToDecimal(txtValorRecebido.Text) - this.decTotalPagar).ToString("C");
                    }
                    txtDesconto.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "VENDAS - txtValorRecebido_KeyDown");
            }
        }

        private void txtDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    if (!string.IsNullOrEmpty(txtDesconto.Text))
                    {
                        if (txtDesconto.Text.Contains("%"))
                        {
                            decimal decDesconto = Math.Round((this.decTotalPagar * Convert.ToDecimal(txtDesconto.Text.Replace("%", "")) / 100), 2);
                            txtDesconto.Text = decDesconto.ToString();
                        }

                        this.decDesconto = Convert.ToDecimal(txtDesconto.Text);
                        this.CalculaValores();
                    }

                    btnCadastrarVenda.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "VENDAS - txtDesconto_KeyDown");
            }

        }

        private void txtAcrescimo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    if (!string.IsNullOrEmpty(txtAcrescimo.Text))
                    {
                        this.decAcrescimo = Convert.ToDecimal(txtAcrescimo.Text);
                        this.CalculaValores();
                    }

                    btnCadastrarVenda.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "VENDAS - txtAcrescimo_KeyDown");
            }
        }

        private void rgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 0)//excluir item da venda
                    {
                        ItemVenda objItemVenda = new ItemVenda();
                        objItemVenda.Codigo = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[1].Value);
                        //obter o valor unitário do produto para subtrair do valor total
                        decimal decValorTotalExcluido = Convert.ToDecimal(senderGrid.Rows[e.RowIndex].Cells["Valor Unit."].Value);

                        if (!string.IsNullOrEmpty(txtValorRecebido.Text))
                        {
                            if (Convert.ToDecimal(txtValorRecebido.Text.Replace(".", "")) < decValorTotalExcluido)
                                txtValorRecebido.Text = "0,00";
                            else
                                txtValorRecebido.Text = (Convert.ToDecimal(txtValorRecebido.Text.Replace(".", "")) - decValorTotalExcluido).ToString();

                        }

                        objItemVenda.Excluir(objItemVenda);

                        DataTable dtItensVenda = new DataTable();
                        objItemVenda = new ItemVenda();
                        objItemVenda.CodigoVenda = this.intCodigoVenda;
                        dtItensVenda = objItemVenda.Listar(objItemVenda).Tables[0];
                        rgvProdutos.DataSource = dtItensVenda;
                        rgvProdutos.Columns[1].Visible = false;

                        this.CalculaValores();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "VENDAS - rgvProdutos_CellContentClick");
            }
        }

        private void btnCadastrarVenda_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(lblTotalPagar.Text) && !string.IsNullOrEmpty(txtCodigoVendedor.Text))
                {
                    if (ddlFormaPagto.Text == "" || ddlFormaPagto.SelectedValue.ToString() == Utilitarios.CodigoSelecione)
                    {
                        MessageBox.Show("Selecione a forma de pagamento!");
                        ddlFormaPagto.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(txtValorRecebido.Text) || txtValorRecebido.Text == "0,00" || txtValorRecebido.Text == "0")
                    {
                        MessageBox.Show("Informe o valor recebido!");
                        return;
                    }

                    if (lblTotalPagar.Text == "R$ 0,00" || lblTotalPagar.Text == "0")
                    {
                        MessageBox.Show("O valor total a pagar não pode ser 0");
                        return;
                    }
                    else
                    {
                        //registra forma de pagamento
                        FormaPagtoVenda objFPV = new FormaPagtoVenda();

                        try
                        {
                            objFPV.CodigoFormaPagto = Convert.ToInt32(ddlFormaPagto.SelectedValue);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Selecione a forma de pagamento!");
                            ddlFormaPagto.Focus();
                            return;
                        }

                        objFPV.CodigoVenda = this.intCodigoVenda;
                        //if(ddlFormaPagto.SelectedValue.ToString() != "21")// ou é dinheiro ou é cartão
                        // {
                        objFPV.Valor = Convert.ToDecimal(txtValorRecebido.Text.Replace(".", "")) - Convert.ToDecimal(lblTroco.Text.Replace("R$", ""));
                        int intRet = objFPV.Inserir(objFPV);

                        //verificar se é um pagamento parcial (em várias formas)
                        if (lblTotalPagar.Text != this.decTotalPagar.ToString("C"))
                        {
                            txtValorRecebido.Text = "0";
                            this.CalculaValores();
                            txtValorRecebido.Text = this.decTotalPagar.ToString();
                            MessageBox.Show("Pagamento registrado, informe o valor restante a receber e a forma de pagamento");
                            ddlFormaPagto.Focus();
                            return;
                        }
                        // }
                        // else // pagamento em dinheiro e em cartão
                        // {
                        #region Codigo Comentado - ainda não implementado
                        /*
                            if (ddlCartao.Text == "" || ddlCartao.SelectedValue.ToString() == "20")
                            {
                                MessageBox.Show("Selecione a forma de pagamento para o valor do pagamento em cartão!");
                                ddlCartao.Focus();
                                return;
                            }

                            if (string.IsNullOrEmpty(txtValorRecebido.Text) || txtValorRecebido.Text == "0,00" || txtValorRecebido.Text == "0")
                            {
                                MessageBox.Show("Informe o valor do pagamento em cartão!");
                                txtValorRecebido.Focus();
                                return;
                            }

                            if (string.IsNullOrEmpty(txtValorDinheiro.Text) || txtValorDinheiro.Text == "0,00" || txtValorDinheiro.Text == "0")
                            {
                                MessageBox.Show("Informe o valor do pagamento em dinheiro!");
                                txtValorDinheiro.Focus();
                                return;
                            }

                            //se chegou até aqui é porque está tudo ok
                            if((Convert.ToDecimal(txtValorDinheiro.Text) + 
                                Convert.ToDecimal(txtValorRecebido.Text) - 
                                Convert.ToDecimal(txtDesconto.Text) + 
                                Convert.ToDecimal(txtAcrescimo.Text)) != this.decTotalPagar)
                            {
                                MessageBox.Show("Os valores em dinheiro e em cartão não correspondem com o total da venda, informe os valores novamente.");
                                
                            }
                            else
                            {
                                objFPV.CodigoFormaPagto = 1;
                                objFPV.Valor = Convert.ToDecimal(txtValorDinheiro.Text);
                                int intFPV = objFPV.Inserir(objFPV);

                                objFPV.CodigoFormaPagto = Convert.ToInt32(ddlCartao.SelectedValue);
                                objFPV.Valor = Convert.ToDecimal(txtValorRecebido.Text) - Convert.ToDecimal(txtDesconto.Text) + Convert.ToDecimal(txtAcrescimo.Text);
                                intFPV = objFPV.Inserir(objFPV);
                            }
                             */
                        #endregion
                        //}


                        Venda objVenda = new Venda();
                        objVenda.Codigo = this.intCodigoVenda;
                        objVenda.CodigoUsuario = Convert.ToInt32(txtCodigoVendedor.Text);
                        objVenda.Status = "A";

                        if (!string.IsNullOrEmpty(txtCPF.Text))
                            objVenda.CNPJCliente = txtCPF.Text;

                        objVenda.ValorTotal = Convert.ToDecimal(txtSubTotal.Text.Replace("R$", "").Replace(".", ""));
                        //objVenda.FormaPagto = ddlFormaPagto.SelectedValue.ToString();

                        if (!string.IsNullOrEmpty(txtDesconto.Text))
                            objVenda.Desconto = Convert.ToDecimal(txtDesconto.Text);

                        if (!string.IsNullOrEmpty(txtAcrescimo.Text))
                            objVenda.Acrescimo = Convert.ToDecimal(txtAcrescimo.Text);

                        //  objVenda.ValorTotal = objVenda.ValorTotal - objVenda.Desconto + objVenda.Acrescimo;
                        //antes de alterar a venda, é preciso fazer uma verificação nas formas de pagto registradas e no valor total da venda, pois está ocorrendo divergencias em alguns casos.
                        DataTable dtVerificaValor = new DataTable();
                        dtVerificaValor = objVenda.VerificaValorVenda(objVenda);

                        if (dtVerificaValor.Rows.Count > 0)
                        {
                            if ((objVenda.ValorTotal - objVenda.Desconto + objVenda.Acrescimo) != Convert.ToDecimal(dtVerificaValor.Rows[0]["TOTAL_REGISTRADO"]))
                            {
                                MessageBox.Show("O valor total da venda é diferente do valor total registrado pelo sistema, a venda será cancelada, registre os produtos novamente.");

                                this.intCodigoVenda = 0;

                                DataTable dtItensVenda = new DataTable();
                                ItemVenda objItemVenda = new ItemVenda();
                                objItemVenda.CodigoVenda = this.intCodigoVenda;
                                dtItensVenda = objItemVenda.Listar(objItemVenda).Tables[0];
                                rgvProdutos.DataSource = dtItensVenda;
                                rgvProdutos.Columns[1].Visible = false;
                                this.LimparForm();

                                return;
                            }
                            else
                                objVenda.Alterar(objVenda); //só vai alterar de fato se os valores forem exatamente iguais
                        }
                        else
                        {
                            MessageBox.Show("O valor total da venda é diferente do valor total registrado pelo sistema, a venda será cancelada, registre os produtos novamente.");

                            this.intCodigoVenda = 0;

                            DataTable dtItensVenda = new DataTable();
                            ItemVenda objItemVenda = new ItemVenda();
                            objItemVenda.CodigoVenda = this.intCodigoVenda;
                            dtItensVenda = objItemVenda.Listar(objItemVenda).Tables[0];
                            rgvProdutos.DataSource = dtItensVenda;
                            rgvProdutos.Columns[1].Visible = false;
                            this.LimparForm();

                            return;
                        }


                        //imprimir comprovante
                        int intRetorno = this.ImprimirCupom(this.intCodigoVenda);

                        //if (!string.IsNullOrEmpty(txtCPF.Text))
                        //this.GeraTXT(this.intCodigoVenda);//gera o arquivo txt para fazer a nfe

                        if (intRetorno == 1)
                        {
                            MessageBox.Show("Venda concluída com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Venda concluída com sucesso - erro ao imprimir comprovante - Clique no botão 'Imprimir comprovante para reimprimir o comprovante. Código da Venda: " + this.intCodigoVenda);
                        }
                        this.intCodigoVenda = 0;

                        DataTable dtItensVenda2 = new DataTable();
                        ItemVenda objItemVenda2 = new ItemVenda();
                        objItemVenda2.CodigoVenda = this.intCodigoVenda;
                        dtItensVenda2 = objItemVenda2.Listar(objItemVenda2).Tables[0];
                        rgvProdutos.DataSource = dtItensVenda2;
                        rgvProdutos.Columns[1].Visible = false;
                        this.LimparForm();
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(lblTotalPagar.Text))
                        MessageBox.Show("O valor total a pagar não pode estar vazio");
                    else
                    {
                        MessageBox.Show("Informe o código do vendedor!");
                        txtCodigoVendedor.Focus();
                    }

                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "VENDAS - btnCadastrarVenda_Click");
            }
        }

        private int ImprimirCupom(int intCodigoVenda)
        {
            try
            {
                //declaração de variaveis para receber os parâmetros da formatação do texto, conforme as seleções no FORM
                int item = 1;
                int linhas = 8;
                int tLetra = 3;
                int italico = 0;
                int sublinhado = 0;
                int expandido = 0;
                int enfatizado = 0;

                StringBuilder stb = new StringBuilder();
                stb = this.MontaCupom(intCodigoVenda);

                stb.Append("\r\n\r\n\r\n");
                //salvar em uma tabela os cupoms para impressão posterior caso seja necessário
                Comprovante objComprovante = new Comprovante();
                objComprovante.CodigoVenda = this.intCodigoVenda;
                objComprovante.TextoComprovante = stb.ToString();
                objComprovante.Status = "IMPRIMIR";
                int intId = objComprovante.Inserir(objComprovante);

                //obter nome da loja pra sair em negrito no cupom
                DataTable dtLoja = new DataTable();
                Loja objLoja = new Loja();
                dtLoja = objLoja.Listar();

                int iRetorno = 0;

                if (Utilitarios.ModeloImpressora == 5)
                {
                    iRetorno = MP2032.ConfiguraModeloImpressora(Utilitarios.ModeloImpressora);

                    try
                    {
                        iRetorno = MP2032.Le_Status();

                        if (iRetorno == 32)//sem papel
                        {
                            MessageBox.Show("A impressora está sem papel, para imprimir o comprovante coloque a bobina de papel na impressora e imprima-o na listagem de vendas. CÓDIGO DA VENDA: " + intCodigoVenda);

                            Utilitarios.SalvarLog("Impressora sem papel: 32 ", "VENDAS - ImprimirCupom(" + intCodigoVenda + ")");

                            return 0;
                        }
                        else if (iRetorno == 68)//Erro de comunicação/"OFFLINE"
                        {
                            MessageBox.Show("Erro de comunicação com a impressora, para reimprimir o comprovante imprima-o na listagem de vendas. CÓDIGO DA VENDA: " + intCodigoVenda);

                            Utilitarios.SalvarLog("Erro de comunicação com a impressora: 68 ", "VENDAS - ImprimirCupom(" + intCodigoVenda + ")");


                            return 0;
                        }
                        else
                        {
                            iRetorno = MP2032.IniciaPorta(Utilitarios.PortaImpressora);//inicia a porta com o valor da combo (exceto ethernet)

                            if (iRetorno <= 0)// erro
                            {
                                MessageBox.Show("Erro ao iniciar a porta da impressora, desligue a impressora, ligue-a novamente, execute o aplicativo 'Instalar impressoras' do menu iniciar e reimprima o comprovante imprima-o na listagem de vendas. CÓDIGO DA VENDA: " + intCodigoVenda);

                                Utilitarios.SalvarLog("Erro ao iniciar porta: " + iRetorno, "VENDAS - ImprimirCupom(" + intCodigoVenda + ")");

                                return 0;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Utilitarios.SalvarLog(ex.Message, "VENDAS - ImprimirCupom(" + intCodigoVenda + ")");
                    }

                    // \n - quebra de linha e \r retorno de impressão (comandos da impressora)
                    iRetorno = MP2032.FormataTX(stb.ToString(), tLetra, italico, sublinhado, expandido, enfatizado);//ao ser clicado, imprime o texto da Text Box

                    iRetorno = MP2032.BematechTX("\r\n\r\n\r\n");

                    if (iRetorno == 0)//não imprimiu
                    {
                        return 0;
                    }

                    iRetorno = MP2032.AcionaGuilhotina(0);
                    iRetorno = MP2032.FechaPorta();
                }
                else if (Utilitarios.ModeloImpressora == 8 || Utilitarios.ModeloImpressora == 7)//MP2064
                {
                    iRetorno = MP2064.ConfiguraModeloImpressora(Utilitarios.ModeloImpressora);

                    try
                    {
                        iRetorno = MP2064.Le_Status();

                        if (iRetorno == 32)//sem papel
                        {
                            MessageBox.Show("A impressora está sem papel, para imprimir o comprovante coloque a bobina de papel na impressora e imprima-o na listagem de vendas. CÓDIGO DA VENDA: " + intCodigoVenda);

                            Utilitarios.SalvarLog("Impressora sem papel: 32 ", "VENDAS - ImprimirCupom(" + intCodigoVenda + ")");

                            return 0;
                        }
                        else if (iRetorno == 68)//Erro de comunicação/"OFFLINE"
                        {
                            MessageBox.Show("Erro de comunicação com a impressora, para reimprimir o comprovante imprima-o na listagem de vendas. CÓDIGO DA VENDA: " + intCodigoVenda);

                            Utilitarios.SalvarLog("Erro de comunicação com a impressora: 68 ", "VENDAS - ImprimirCupom(" + intCodigoVenda + ")");

                            return 0;
                        }
                        else
                        {
                            iRetorno = MP2064.IniciaPorta(Utilitarios.PortaImpressora);//inicia a porta com o valor da combo (exceto ethernet)

                            if (iRetorno <= 0)// erro
                            {
                                MessageBox.Show("Erro ao iniciar a porta da impressora, desligue a impressora, ligue-a novamente, execute o aplicativo 'Instalar impressoras' do menu iniciar e reimprima o comprovante imprima-o na listagem de vendas. CÓDIGO DA VENDA: " + intCodigoVenda);

                                Utilitarios.SalvarLog("Erro ao iniciar porta: " + iRetorno, "VENDAS - ImprimirCupom(" + intCodigoVenda + ")");

                                return 0;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Utilitarios.SalvarLog(ex.Message, "VENDAS - ImprimirCupom(" + intCodigoVenda + ")");
                    }

                    // \n - quebra de linha e \r retorno de impressão (comandos da impressora)
                    iRetorno = MP2064.FormataTX(stb.ToString(), tLetra, italico, sublinhado, expandido, enfatizado);//ao ser clicado, imprime o texto da Text Box

                    iRetorno = MP2064.BematechTX("\r\n\r\n\r\n");

                    if (iRetorno == 0)//não imprimiu
                    {
                        return 0;
                    }

                    iRetorno = MP2064.AcionaGuilhotina(0);
                    iRetorno = MP2064.FechaPorta();
                }
                else if (Utilitarios.ModeloImpressora == 10 || Utilitarios.ModeloImpressora == 11 || Utilitarios.ModeloImpressora == 12)//Elgin i9 ou nova rotina para Bematech
                {
                    var printer = new Printer(Utilitarios.strNomeImpressora, PrinterType.Epson);

                    if (Utilitarios.ModeloImpressora == 11)
                        printer = new Printer(Utilitarios.strNomeImpressora, PrinterType.Bematech);
                    else if(Utilitarios.ModeloImpressora == 12)
                        printer = new Printer(Utilitarios.strNomeImpressora, PrinterType.Daruma);

                    printer.AlignCenter();
                    printer.ExpandedMode(PrinterModeState.On);
                    printer.CondensedMode(PrinterModeState.Off);
                    printer.DoubleWidth2();
                    printer.BoldMode(PrinterModeState.On);
                    printer.WriteLine(dtLoja.Rows[0]["loj_c_nome"].ToString().ToUpper());
                    printer.PrintDocument();
                    printer.Clear();

                    printer.AlignLeft();
                    printer.CondensedMode(PrinterModeState.Off);
                    printer.BoldMode(PrinterModeState.Off);
                    printer.ExpandedMode(PrinterModeState.Off);
                    printer.WriteLine(stb.ToString());
                    printer.FullPaperCut();

                    printer.PrintDocument();
                }
                else if(Utilitarios.ModeloImpressora == 13)
                {
                    ICIDPrint cidPrinter = new CIDPrintiD();
                    cidPrinter.Iniciar();
                    cidPrinter.ImprimirFormatado(dtLoja.Rows[0]["loj_c_nome"].ToString().ToUpper() + "\n", false,false,true, true,false);
                    cidPrinter.ImprimirFormatado(stb.ToString() + "\n", false, false, false, false);
                    cidPrinter.AtivarGuilhotina(TipoCorte.TOTAL);
                }
                else //Elgin wind tp
                {

                    strTeste = stb;

                    using (var printDocument = new System.Drawing.Printing.PrintDocument())
                    {
                        printDocument.PrintPage += printDocument_PrintPage;

                        string strWidth = printDocument.DefaultPageSettings.PrintableArea.Width.ToString();
                        string strHeight = printDocument.DefaultPageSettings.PrintableArea.Height.ToString();

                        printDocument.PrinterSettings.PrinterName = "Elgin";
                        printDocument.Print();
                    }
                }

                return 1;
            }
            catch (Exception ex)
            {
                Utilitarios.SalvarLog(ex.Message, "VENDAS - ImprimirCupom(" + intCodigoVenda + ")");

                StringBuilder stb = this.MontaCupom(intCodigoVenda);
                Comprovante objComprovante = new Comprovante();
                objComprovante.CodigoVenda = this.intCodigoVenda;
                objComprovante.TextoComprovante = stb.ToString();
                objComprovante.Status = "IMPRIMIR";
                int intId = objComprovante.Inserir(objComprovante);

                if (MessageBox.Show("Erro ao imprimir comprovante - verifique se os cabos da impressora estão conectados e tente imprimir novamente.", "Erro ao imprimir comprovante", MessageBoxButtons.RetryCancel) == System.Windows.Forms.DialogResult.Retry)
                {
                    this.ImprimirCupom(intCodigoVenda);
                }

                return 0;
            }
        }

        //evento utilizado para imprimir na impressora Elgin

        void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var printDocument = sender as System.Drawing.Printing.PrintDocument;

            int altura = strTeste.ToString().Split(new char[] { '\n' }).Length ;

            if (printDocument != null)
            {
                using (var font = new Font("Courier New", 14))
                using (var brush = new SolidBrush(Color.Black))
                {
                    e.Graphics.DrawString(
                       strTeste.ToString(),
                        font,
                        brush,
                        new RectangleF(0, 0, printDocument.DefaultPageSettings.PrintableArea.Width, printDocument.DefaultPageSettings.PrintableArea.Height));
                }
            }
        }


        private StringBuilder MontaCupom(int pintCodigoVenda)
        {
            try
            {
                //buscar endereço da loja
                DataTable dtLoja = new DataTable();
                Loja objLoja = new Loja();
                dtLoja = objLoja.Listar();

                //declaração de variaveis para receber os parâmetros da formatação do texto, conforme as seleções no FORM
                int item = 1;
                int linhas = 8;
                int intColunas = 0;

                StringBuilder stb = new StringBuilder();
                //stb.Append("" + dtLoja.Rows[0]["loj_c_nome"].ToString() + "\n");
                stb.Append(" " + dtLoja.Rows[0]["loj_c_endereco"].ToString() + "\n");
                stb.Append(" CNPJ: " + dtLoja.Rows[0]["loj_c_cnpj"].ToString() + "\n");
                stb.Append(" IE: " + dtLoja.Rows[0]["loj_c_ie"].ToString() + "\n");
                stb.Append("------------------------------------------------\n");
                stb.Append(" " + DateTime.Now.ToString() + "                 COD: " + intCodigoVenda.ToString("000000") + "\n");
                stb.Append("      COMPROVANTE - NÃO É DOCUMENTO FISCAL       \n");
                stb.Append(" ITEM CÓDIGO       DESCRIÇÃO       QTD VALOR(R$)\n ");


                DataSet dtItensVenda = new DataSet();
                ItemVenda objItemVenda = new ItemVenda();
                objItemVenda.CodigoVenda = intCodigoVenda;
                dtItensVenda = objItemVenda.Listar(objItemVenda);

                foreach (DataRow dr in dtItensVenda.Tables[0].Rows)
                {
                    string strProduto = dr["Nome"].ToString();

                    if (strProduto.Length > 16)
                        strProduto = strProduto.Substring(0, 16);

                    string strCodigo = dr["Código"].ToString();

                    if (strCodigo.Length > 13)
                        strCodigo = dr["Referência"].ToString();

                    stb.Append(item.ToString("00").PadRight(5) + strCodigo.PadRight(12) + " " + strProduto.PadRight(16) + " " + Convert.ToInt32(dr["Qtde"]).ToString("00").PadLeft(2) + " " + dr["Valor Total"].ToString().PadLeft(9) + "\n ");
                    linhas++;
                    item++;

                }

                // stb.Append("--------------------------------------------------------\r\n");
                stb.Append("TOTAL R$ " + dtItensVenda.Tables[1].Rows[0]["ven_n_total"].ToString().PadLeft(38, ' ') + "\n ");
                linhas++;

                if (Convert.ToDecimal(dtItensVenda.Tables[1].Rows[0]["ven_n_acrescimo"]) > 0)
                {
                    string strAcrescimo = dtItensVenda.Tables[1].Rows[0]["ven_n_acrescimo"].ToString().PadLeft(37, ' ');
                    stb.Append("ACRÉSCIMO " + strAcrescimo + "\n ");
                    linhas++;
                }

                if (Convert.ToDecimal(dtItensVenda.Tables[1].Rows[0]["ven_n_desconto"]) > 0)
                {
                    string strDesconto = "-" + dtItensVenda.Tables[1].Rows[0]["ven_n_desconto"].ToString();
                    stb.Append("DESCONTO " + strDesconto.PadLeft(38) + "\n ");
                    linhas++;
                }

                //PROGRAMAR AQUI A FORMA DE PAGAMENTO
                foreach (DataRow dr in dtItensVenda.Tables[2].Rows)
                {
                    if (dr["FPG_C_DESCRICAO"].ToString().ToUpper() == "DINHEIRO")
                        stb.Append(dr["FPG_C_DESCRICAO"].ToString().PadRight(37) + " " + Convert.ToDecimal(txtValorRecebido.Text).ToString("C").Replace("R$","").PadLeft(9) + "\n ");
                    else
                        stb.Append(dr["FPG_C_DESCRICAO"].ToString().PadRight(37) + " " + dr["FPV_N_VALOR"].ToString().PadLeft(9) + "\n ");
                    linhas++;
                }

                if (lblTroco.Text != "R$ 0,00")
                    stb.Append("TROCO " + lblTroco.Text.Replace("R$", "").PadLeft(41, ' ') + "\n");

                linhas++;
                stb.Append("Vend. " + lblVendedor.Text + "\n");
                linhas++;
                stb.Append("************OBRIGADO E VOLTE SEMPRE!***********\n");

                return stb;
            }
            catch (Exception ex)
            {
                Utilitarios.SalvarLog(ex.Message, "VENDAS - MontaCupom()");
                return new StringBuilder();
            }
        }

        private void CalculaValores()
        {
            try
            {
                this.decTotalPagar = 0;
                DataSet dtsTables = new DataSet();
                DataTable dtItensVenda = new DataTable();
                ItemVenda objItemVenda = new ItemVenda();
                objItemVenda.CodigoVenda = this.intCodigoVenda;
                dtsTables = objItemVenda.Listar(objItemVenda);

                foreach (DataRow dr in dtsTables.Tables[0].Rows)//percorre a tabela de formas de pagamento
                {
                    this.decTotalPagar += Convert.ToDecimal(dr["Valor Total"]);
                }

                txtSubTotal.Text = (this.decTotalPagar).ToString("C");// o sub-total tem que sempre mostrar o valor total dos itens

                this.decTotalPagar = this.decTotalPagar - this.decDesconto + this.decAcrescimo;

                foreach (DataRow dr in dtsTables.Tables[2].Rows)//percorre a tabela de formas de pagamento parciais
                {
                    this.decTotalPagar -= Convert.ToDecimal(dr["FPV_N_VALOR"]);
                }


                lblTotalPagar.Text = this.decTotalPagar.ToString("C");


                //if(ddlFormaPagto.Text != "DINHEIRO")//cartão
                //{
                decimal decValorRecebido = 0;

                if (!string.IsNullOrEmpty(txtValorRecebido.Text))
                    decValorRecebido = Convert.ToDecimal(txtValorRecebido.Text);

                if (decValorRecebido > 0)
                {
                    //  txtValorRecebido.Text = this.decTotalPagar.ToString();

                    if (Convert.ToDecimal(txtValorRecebido.Text) >= this.decTotalPagar)//se o valor a receber for maior do que o total da compra
                    {
                        if (ddlFormaPagto.Text != "DINHEIRO")//cartão não tem troco
                        {
                            txtValorRecebido.Text = this.decTotalPagar.ToString();
                            lblTroco.Text = "R$ 0,00";
                        }
                        else
                            lblTroco.Text = (Convert.ToDecimal(txtValorRecebido.Text) - this.decTotalPagar).ToString("C");
                    }
                    else
                    {
                        lblTotalPagar.Text = (this.decTotalPagar - Convert.ToDecimal(txtValorRecebido.Text)).ToString("C");
                        lblTroco.Text = "R$ 0,00";
                    }
                }
               // else
                   // txtValorRecebido.Text = this.decTotalPagar.ToString();
                //}
                //else//cartão
                //{
                //     if (!string.IsNullOrEmpty(txtValorDinheiro.Text))
                //     {
                //         txtValorRecebido.Text = (this.decTotalPagar - Convert.ToDecimal(txtValorDinheiro.Text)).ToString();
                //         lblTroco.Text = "R$ 0,00";
                //     }
                //}

            }
            catch (Exception ex)
            {
                Utilitarios.SalvarLog(ex.Message, "VENDAS - CalculaValores()");
            }
        }

        protected void GeraTXT(int intCodigoVenda)
        {
            try
            {
                string strCaminho = "D:/teste/loja/Anexos/ArquivoNFGerado";
                string dataEmissao = DateTime.Now.ToShortDateString();
                string serie = "0";
                string frete = string.Empty;
                NFe objNFE = new NFe();
                DataSet dtsDados = new DataSet();

                //Dados da nota fiscal - Grupo A
                objNFE.versao = "3.10"; // versão
                //inclui id dpois de criar td q precisa

                if (intCodigoVenda > 0)
                {
                    Venda objVenda = new Venda();
                    objVenda.Codigo = intCodigoVenda;
                    dtsDados = objVenda.ListarDadosNFE(objVenda);
                }

                DataRow infNFe;
                infNFe = dtsDados.Tables[3].Rows[0];//dados da venda


                double pis = 0, cofins = 0;
                int numNF = 0;

                if (dtsDados.Tables[0].Rows.Count > 0)//dados da empresa
                {
                    DataRow drEmitente;
                    drEmitente = dtsDados.Tables[0].Rows[0];

                    if (drEmitente["emp_c_nf"] != DBNull.Value)
                        numNF = Convert.ToInt32(drEmitente["emp_c_nf"].ToString()) + 1;
                    else
                        numNF = 1; //se for a 1ª vez, esse campo estará vazio.

                    //Identificação da Nota Fiscal eletrônica  - GRUPO B
                    objNFE.infNFE.Ide.cUF = 35;//SP
                    objNFE.infNFE.Ide.cNF = String.Format("{0:00000000}", this.intCodigoVenda);//usando o codigo do contas a receber 
                    objNFE.infNFE.Ide.natOp = "Venda";

                    if (dtsDados.Tables[4].Rows[0]["fpv_fpg_n_codigo"].ToString() != "1" || dtsDados.Tables[4].Rows[0]["fpv_fpg_n_codigo"].ToString() != "5")//pagto em dinheiro ou débito
                        objNFE.infNFE.Ide.indPag = "1";
                    else
                        objNFE.infNFE.Ide.indPag = "0";//modo de pagto confirmar casos parciais (um pouco em dinheiro ou débito e um pouco em cartão de crédito)

                    objNFE.infNFE.Ide.mod = "55";//sempre 55
                    objNFE.infNFE.Ide.serie = serie;
                    objNFE.infNFE.Ide.nNF = numNF.ToString();
                    objNFE.infNFE.Ide.dEmi = Convert.ToDateTime(dataEmissao);
                    objNFE.infNFE.Ide.tpNF = 1;//sempre saída
                    objNFE.infNFE.Ide.cMunFG = Utilitarios.CodigoMunicipio;
                    objNFE.infNFE.Ide.tpImp = 1; //sempre retrato
                    objNFE.infNFE.Ide.tpEmis = "1";//sempre normal
                    objNFE.infNFE.Ide.tpAmb = 2;//mudar para producao depois
                    objNFE.infNFE.Ide.finNFe = "1";//sempre NF-e Normal
                    objNFE.infNFE.Ide.procEmi = "3";//sempre 3-emissão NF-e pelo contribuinte com aplicativo fornecido pelo Fisco
                    objNFE.infNFE.Ide.verProc = "3.10";

                    // Dados do Emitente - Grupo C

                    objNFE.infNFE.Emit.CNPJ = Funcoes.removeFormatacao(drEmitente["emp_c_cnpj"].ToString());
                    objNFE.infNFE.Emit.xNome = drEmitente["emp_c_razao_social"].ToString();

                    if (drEmitente["emp_c_ie"] != DBNull.Value)
                        Funcoes.removeFormatacao(objNFE.infNFE.Emit.IE = Funcoes.removeFormatacao(drEmitente["emp_c_ie"].ToString()));

                    if (drEmitente["EMP_C_REGIME_TRIBUTARIO"] != DBNull.Value)
                    {
                        objNFE.infNFE.Emit.CRT = Convert.ToInt32(drEmitente["EMP_C_REGIME_TRIBUTARIO"].ToString());
                        //se for simples nacional, ICMS é 0. Fazer isso tb na tela frmArquivoNF. Proposta de Remessa e Venda
                    }
                    else
                    {   //o regime tributario não está preenchido... usuário deve preencher
                        //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "alert(\'Por favor preencha o regime tributário da empresa Avanzi de faturamento da proposta. Não foi possível gerar a NF-e! \');", true);
                        //this.ErroGeracaoNFE = true;
                        return;
                    }

                    if (drEmitente["emp_c_nome_fantasia"] != DBNull.Value)
                        objNFE.infNFE.Emit.xFant = drEmitente["emp_c_nome_fantasia"].ToString();//opcional

                    //endereco do emitente
                    objNFE.infNFE.Emit.EnderEmit.xLgr = drEmitente["emp_c_endereco"].ToString();
                    objNFE.infNFE.Emit.EnderEmit.nro = drEmitente["emp_c_numero"].ToString();
                    objNFE.infNFE.Emit.EnderEmit.xBairro = drEmitente["emp_c_bairro"].ToString();
                    objNFE.infNFE.Emit.EnderEmit.xMun = drEmitente["emp_c_cidade"].ToString();
                    objNFE.infNFE.Emit.EnderEmit.UF = drEmitente["EMP_C_ESTADO"].ToString();
                    objNFE.infNFE.Emit.EnderEmit.cMun = Utilitarios.CodigoMunicipio;
                    objNFE.infNFE.Emit.EnderEmit.CEP = Funcoes.removeFormatacao(drEmitente["emp_c_cep"].ToString());
                    objNFE.infNFE.Emit.EnderEmit.cPais = 1058;//opcional
                    objNFE.infNFE.Emit.EnderEmit.xPais = "BRASIL";//opcional
                    //if (drEmitente["emp_c_telefone1"] != DBNull.Value)
                    // objNFE.infNFE.Emit.EnderEmit.fone = Funcoes.removeFormatacao(drEmitente["emp_c_telefone1"].ToString()); //opcional so numeros
                    // if (drEmitente["end_c_complemento"] != DBNull.Value)
                    //objNFE.infNFE.Emit.EnderEmit.xCpl = drEmitente["end_c_complemento"].ToString();  //complemento -> opcional

                    if (drEmitente["emp_n_aliquota_pis"] != DBNull.Value)
                        pis = Convert.ToDouble(drEmitente["emp_n_aliquota_pis"]);
                    else
                        pis = 0;

                    if (drEmitente["emp_n_aliquota_cofins"] != DBNull.Value)
                        cofins = Convert.ToDouble(drEmitente["emp_n_aliquota_cofins"]);
                    else
                        cofins = 0;
                }

                //cria a chave da nf-e
                string _codUF = objNFE.infNFE.Ide.cUF.ToString();
                string _dEmi = objNFE.infNFE.Ide.dEmi.ToString("yyMM");
                string _cnpj = Funcoes.removeFormatacao(objNFE.infNFE.Emit.CNPJ);
                string _mod = objNFE.infNFE.Ide.mod;

                string _serie = string.Format("{0:000}", Int32.Parse(objNFE.infNFE.Ide.serie));
                string _numNF = string.Format("{0:000000000}", Int32.Parse(objNFE.infNFE.Ide.nNF));
                string _tpEmiss = string.Format("{0:0}", Int32.Parse(objNFE.infNFE.Ide.tpEmis));
                string _codigo = string.Format("{0:00000000}", Int32.Parse(objNFE.infNFE.Ide.cNF));

                string chaveNF = _codUF + _dEmi + _cnpj + _mod + _serie + _numNF + _tpEmiss + _codigo;

                int _dv = Funcoes.modulo11(chaveNF);

                objNFE.Id = chaveNF + _dv.ToString();
                objNFE.infNFE.Ide.cDV = _dv.ToString();

                objNFE.infNFE.Dest.idDest = 1;//1-Operação interna 2-Operação interestadual 3-Operação com exterior


                //Dados do Destinatario - Grupo E
                //cnpj ou cpf
                objNFE.infNFE.Dest.CPF = Funcoes.removeFormatacao(infNFe["VEN_CLI_C_CNPJ"].ToString());

                // objNFE.infNFE.Dest.xNome = infNFe["cli_c_nome"].ToString();

                #region Dados Desnecessarios

                //if (destinatario["cli_c_ie"] != DBNull.Value)
                //{
                //    objNFE.infNFE.Dest.indIEDest = 1;
                //    objNFE.infNFE.Dest.IE = Funcoes.removeFormatacao(destinatario["cli_c_ie"].ToString());
                //}
                //else
                //{
                //    objNFE.infNFE.Dest.indIEDest = 2;
                //    objNFE.infNFE.Dest.IE = "ISENTO";
                //}
                //objNFE.infNFE.Dest.fone= //opcional
                //objNFE.infNFE.Dest.email= //opcional

                //endereco do destinatario
                /*
                DataRow[] drLinha = dtsDados.Tables[1].Select("cli_end_c_tipoEndereco = 'Faturamento'");

                if (drLinha.Length > 0)
                {

                    objNFE.infNFE.Dest.EnderDest.xLgr = drLinha[0]["end_c_endereco"].ToString();
                    objNFE.infNFE.Dest.EnderDest.nro = drLinha[0]["end_n_numero"].ToString();
                    objNFE.infNFE.Dest.EnderDest.xBairro = drLinha[0]["end_c_bairro"].ToString();
                    objNFE.infNFE.Dest.EnderDest.UF = drLinha[0]["end_c_uf"].ToString();
                    objNFE.infNFE.Dest.EnderDest.xMun = drLinha[0]["end_c_cidade"].ToString();
                    objNFE.infNFE.Dest.EnderDest.cMun = Funcoes.ListarCodigoMunicipio(drLinha[0]["end_c_uf"].ToString(), drLinha[0]["end_c_cidade"].ToString());
                    objNFE.infNFE.Dest.EnderDest.CEP = Funcoes.removeFormatacao(drLinha[0]["end_c_cep"].ToString());

                    if (drLinha[0]["end_c_complemento"] != DBNull.Value)
                        objNFE.infNFE.Dest.EnderDest.xCpl = drLinha[0]["end_c_complemento"].ToString();//opcional  
                }
                else //se não tem endereço de faturamento, procura o endereço de cobrança. Se não tiver o de cobrança, pega o 1º endereço do select; 
                {
                    drLinha = dtsDados.Tables[1].Select("cli_end_c_tipoEndereco = 'Cobrança'");

                    if (drLinha.Length > 0)
                    {
                        objNFE.infNFE.Dest.EnderDest.xLgr = drLinha[0]["end_c_endereco"].ToString();
                        objNFE.infNFE.Dest.EnderDest.nro = drLinha[0]["end_n_numero"].ToString();
                        objNFE.infNFE.Dest.EnderDest.xBairro = drLinha[0]["end_c_bairro"].ToString();
                        objNFE.infNFE.Dest.EnderDest.UF = drLinha[0]["end_c_uf"].ToString();
                        objNFE.infNFE.Dest.EnderDest.xMun = drLinha[0]["end_c_cidade"].ToString();
                        objNFE.infNFE.Dest.EnderDest.cMun = Funcoes.ListarCodigoMunicipio(drLinha[0]["end_c_uf"].ToString(), drLinha[0]["end_c_cidade"].ToString());
                        objNFE.infNFE.Dest.EnderDest.CEP = Funcoes.removeFormatacao(drLinha[0]["end_c_cep"].ToString());

                        if (drLinha[0]["end_c_complemento"] != DBNull.Value)
                            objNFE.infNFE.Dest.EnderDest.xCpl = drLinha[0]["end_c_complemento"].ToString();//opcional  

                    }
                    else
                    {
                        if (dtsDados.Tables[1].Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(dtsDados.Tables[1].Rows[0]["end_c_endereco"].ToString()))
                            {
                                objNFE.infNFE.Dest.EnderDest.xLgr = dtsDados.Tables[1].Rows[0]["end_c_endereco"].ToString();
                                objNFE.infNFE.Dest.EnderDest.nro = dtsDados.Tables[1].Rows[0]["end_n_numero"].ToString();
                                objNFE.infNFE.Dest.EnderDest.xBairro = dtsDados.Tables[1].Rows[0]["end_c_bairro"].ToString();
                                objNFE.infNFE.Dest.EnderDest.UF = dtsDados.Tables[1].Rows[0]["end_c_uf"].ToString();
                                objNFE.infNFE.Dest.EnderDest.xMun = dtsDados.Tables[1].Rows[0]["end_c_cidade"].ToString();
                                objNFE.infNFE.Dest.EnderDest.cMun = Funcoes.ListarCodigoMunicipio(dtsDados.Tables[1].Rows[0]["end_c_uf"].ToString(), dtsDados.Tables[1].Rows[0]["end_c_cidade"].ToString());
                                objNFE.infNFE.Dest.EnderDest.CEP = Funcoes.removeFormatacao(dtsDados.Tables[1].Rows[0]["end_c_cep"].ToString());

                                if (dtsDados.Tables[1].Rows[0]["end_c_complemento"] != DBNull.Value)
                                    objNFE.infNFE.Dest.EnderDest.xCpl = dtsDados.Tables[1].Rows[0]["end_c_complemento"].ToString();//opcional     
                            }
                        }
                    }
                }
                */
                #endregion

                objNFE.infNFE.Dest.indIEDest = 2;//isento

                objNFE.infNFE.Dest.EnderDest.UF = "SP";
                objNFE.infNFE.Dest.EnderDest.cMun = Utilitarios.CodigoMunicipio;
                objNFE.infNFE.Dest.EnderDest.cPais = 1058;//opcional
                objNFE.infNFE.Dest.EnderDest.xPais = "BRASIL";//opcional

                #region CFOP

                string cfop = "";
                double totalVenda = 0;
                //pega o valor da proposta
                if (infNFe["total_venda"] != DBNull.Value)
                    totalVenda = Convert.ToDouble(infNFe["total_venda"]);

                if (objNFE.infNFE.Dest.EnderDest.UF == "SP")
                {
                    if (!String.IsNullOrEmpty(objNFE.infNFE.Dest.CNPJ))
                        cfop = "5102";// dentro do estado e pessoa juridica
                    else
                        cfop = "5108";// dentro do estado e pessoa fisica
                }
                else
                {
                    if (!String.IsNullOrEmpty(objNFE.infNFE.Dest.CNPJ))
                        cfop = "6102";//fora do estado e pessoa juridica
                    else
                        cfop = "6108";// dentro do estado e pessoa fisica
                }

                #endregion

                double valorProdutos = 0;
                double basePIS = 0, aliquotaPIS = 0, baseCofins = 0, aliquotaCofins = 0, aliquotaIcms = 0, baseIcms = 0;

                // dados dos produtos da venda
                int cont = 1;
                double dValorTotalTrib = 0;

                foreach (DataRow row in dtsDados.Tables[2].Rows)
                {
                    infNFE.det itens = new infNFE.det();

                    itens.nItem = cont;
                    itens.Prod.cProd = row["itv_pro_c_codigo"].ToString();
                    itens.Prod.cEAN = ""; //não informar caso não possua
                    itens.Prod.xProd = row["produto"].ToString();

                    itens.Prod.cEANTrib = "";//não informar caso não possua
                    itens.Prod.NCM = row["pro_c_ncm"].ToString();

                    itens.Prod.CFOP = "5102";
                    itens.Prod.uCom = "UNIT";
                    itens.Prod.qCom = Convert.ToDecimal(row["ITV_N_QTDE"].ToString());
                    itens.Prod.vUnCom = Convert.ToDouble(row["ITV_N_VALOR_UNITARIO"].ToString());
                    itens.Prod.vProd = itens.Prod.vUnCom * Convert.ToDouble(itens.Prod.qCom);
                    itens.Prod.uTrib = itens.Prod.uCom;
                    itens.Prod.qTrib = itens.Prod.qCom;
                    itens.Prod.vUnTrib = itens.Prod.vUnCom;
                    itens.Prod.indTot = 1;//sempre 1 1-inclui valor do total do item no valor final da nf

                    valorProdutos += itens.Prod.vProd;

                    //impostos ver quais serão utilizados

                    if (itens.Prod.CFOP == "5949" || itens.Prod.CFOP == "6949" || itens.Prod.CFOP == "5912" || itens.Prod.CFOP == "6912" ||
                        itens.Prod.CFOP == "5916" || itens.Prod.CFOP == "6916")
                    {
                        //se for locacao, simples remessa, demonstracao ou retorno de mercadoria
                        itens.Imposto.Icms = new infNFE.det.imposto.ICMS();
                        itens.Imposto.Icms.Icms40 = new infNFE.det.imposto.ICMS.ICMS40();
                        itens.Imposto.Icms.Icms40.CST = "41"; //não tributada
                        itens.Imposto.Icms.Icms40.orig = "0"; //origem nacional

                        //CSOSN

                        itens.Imposto.Pis = new infNFE.det.imposto.PIS();
                        itens.Imposto.Pis.PisNT = new infNFE.det.imposto.PIS.PISNT();
                        itens.Imposto.Pis.PisNT.CST = "08"; // ver qual é


                        itens.Imposto.Cofins = new infNFE.det.imposto.COFINS();
                        itens.Imposto.Cofins.CofinsNT = new infNFE.det.imposto.COFINS.COFINSNT();
                        itens.Imposto.Cofins.CofinsNT.CST = "08"; // ver qual é


                        objNFE.infNFE.Total = new infNFE.total();
                    }
                    else if (itens.Prod.CFOP == "5102" || itens.Prod.CFOP == "6102" || itens.Prod.CFOP == "5108" || itens.Prod.CFOP == "6108")
                    {
                        //se for venda
                        itens.Imposto.Icms = new infNFE.det.imposto.ICMS();
                        itens.Imposto.Icms.Icms00 = new infNFE.det.imposto.ICMS.ICMS00();
                        itens.Imposto.Icms.Icms00.CST = "00"; //tributada integralmente
                        itens.Imposto.Icms.Icms00.orig = "0"; //origem nacional
                        itens.Imposto.Icms.Icms00.modBC = "0";
                        itens.Imposto.Icms.Icms00.vBC = 0;
                        itens.Imposto.Icms.Icms00.vICMS = 0;

                        if (itens.Prod.CFOP == "5108" || itens.Prod.CFOP == "6108")
                            itens.Imposto.Icms.Icms00.pICMS = 18; // aliquota de 18% para pessoa fisica
                        else
                        {
                            string uf = objNFE.infNFE.Dest.EnderDest.UF;
                            if (itens.Prod.CFOP == "5102")
                            {
                                itens.Imposto.Icms.Icms00.pICMS = Convert.ToDouble(row["pro_n_icms_sp"].ToString()); // pessoa juridica dentro do estado de sp
                            }
                            else
                            {
                                if (uf == "MG" || uf == "PR" || uf == "RS" || uf == "RJ" || uf == "SC")
                                    itens.Imposto.Icms.Icms00.pICMS = 12; // pessoa juridica fora do estado de sp
                                else
                                {
                                    //estados: ac, al, am, ap, ba, ce, df, es, go, ma, mt, ms, pa, pb, pe, pi, rn, ro, rr, se, to
                                    itens.Imposto.Icms.Icms00.pICMS = 7; // pessoa juridica fora do estado de sp
                                }
                            }
                        }

                        //  baseIcms=itens.Imposto.Icms.Icms00.vBC; //alterado dia 28/05

                        aliquotaIcms = itens.Imposto.Icms.Icms00.pICMS; //alterado dia 28/05
                        baseIcms = totalVenda;
                        //  aliquotaIcms = 

                        // itens.Imposto.Icms.Icms00.vBC = itens.Prod.vProd;
                        // itens.Imposto.Icms.Icms00.vICMS = Convert.ToDouble(Decimal.Round(Convert.ToDecimal(itens.Imposto.Icms.Icms00.vBC * itens.Imposto.Icms.Icms00.pICMS) / 100, 2));

                        itens.Imposto.Pis = new infNFE.det.imposto.PIS();
                        itens.Imposto.Pis.PisAliq = new infNFE.det.imposto.PIS.PISAliq();
                        itens.Imposto.Pis.PisAliq.CST = "01";
                        // itens.Imposto.Pis.PisAliq.vBC=totalProposta; //alterado dia 28/05
                        itens.Imposto.Pis.PisAliq.vBC = itens.Prod.vProd;

                        itens.Imposto.Pis.PisAliq.pPIS = pis;//pis é em percentual

                        itens.Imposto.Pis.PisAliq.vPIS = Convert.ToDouble(Decimal.Round(Convert.ToDecimal(itens.Imposto.Pis.PisAliq.vBC * itens.Imposto.Pis.PisAliq.pPIS) / 100, 2));

                        // basePIS=itens.Imposto.Pis.PisAliq.vBC; //alterado dia 28/05
                        basePIS = totalVenda;
                        //aliquotaPIS= itens.Imposto.Pis.PisAliq.pPIS; //alterado dia 28/05
                        aliquotaPIS = pis;


                        itens.Imposto.Cofins = new infNFE.det.imposto.COFINS();
                        itens.Imposto.Cofins.CofinsAliq = new infNFE.det.imposto.COFINS.COFINSAliq();
                        itens.Imposto.Cofins.CofinsAliq.CST = "01";
                        //  itens.Imposto.Cofins.CofinsAliq.vBC = totalProposta; //alterado dia 28/05
                        itens.Imposto.Cofins.CofinsAliq.vBC = itens.Prod.vProd;

                        itens.Imposto.Cofins.CofinsAliq.pCOFINS = cofins;

                        itens.Imposto.Cofins.CofinsAliq.vCOFINS = Convert.ToDouble(Decimal.Round(Convert.ToDecimal(itens.Imposto.Cofins.CofinsAliq.vBC * itens.Imposto.Cofins.CofinsAliq.pCOFINS) / 100, 2));

                        // baseCofins=itens.Imposto.Cofins.CofinsAliq.vBC; //alterado dia 28/05
                        baseCofins = totalVenda;

                        //   aliquotaCofins= itens.Imposto.Cofins.CofinsAliq.pCOFINS;
                        aliquotaCofins = cofins;

                        //alterado por Camila Foltran dia 11/06/2015 - erro 685.
                        itens.TotalImpostos = itens.Imposto.Icms.Icms00.vICMS + itens.Imposto.Pis.PisAliq.vPIS + itens.Imposto.Cofins.CofinsAliq.vCOFINS;

                        objNFE.infNFE.Total = new infNFE.total();
                    }

                    objNFE.infNFE.Det.Add(itens);
                }


                if (cfop == "5949" || cfop == "6949" || cfop == "5912" || cfop == "6912" || cfop == "5916" || cfop == "6916")
                {
                    //total para locacao, simples remessa, demonstracao ou retorno de mercadoria
                    objNFE.infNFE.Total.IcmsTot = new infNFE.total.ICMSTot();
                    objNFE.infNFE.Total.IcmsTot.vBC = 0;
                    objNFE.infNFE.Total.IcmsTot.vICMS = 0;
                    objNFE.infNFE.Total.IcmsTot.vBCST = 0;
                    objNFE.infNFE.Total.IcmsTot.vST = 0;
                    objNFE.infNFE.Total.IcmsTot.vProd = totalVenda;
                    objNFE.infNFE.Total.IcmsTot.vFrete = 0;
                    objNFE.infNFE.Total.IcmsTot.vSeg = 0;
                    objNFE.infNFE.Total.IcmsTot.vDesc = 0;
                    objNFE.infNFE.Total.IcmsTot.vII = 0;
                    objNFE.infNFE.Total.IcmsTot.vIPI = 0;
                    objNFE.infNFE.Total.IcmsTot.vPIS = 0;
                    objNFE.infNFE.Total.IcmsTot.vCOFINS = 0;
                    objNFE.infNFE.Total.IcmsTot.vOutro = 0;
                    objNFE.infNFE.Total.IcmsTot.vNF = valorProdutos;

                    /*objNFE.infNFE.Total.IcmsTot.vProd - objNFE.infNFE.Total.IcmsTot.vDesc + objNFE.infNFE.Total.IcmsTot.vST
                   + objNFE.infNFE.Total.IcmsTot.vFrete + objNFE.infNFE.Total.IcmsTot.vSeg + objNFE.infNFE.Total.IcmsTot.vII + objNFE.infNFE.Total.IcmsTot.vIPI
                   + objNFE.infNFE.Total.IcmsTot.vOutro + objNFE.infNFE.Total.IcmsTot.vSeg;
                   */
                }
                else if (cfop == "5102" || cfop == "6102" || cfop == "5108" || cfop == "6108")
                {
                    //total para venda
                    objNFE.infNFE.Total.IcmsTot = new infNFE.total.ICMSTot();
                    objNFE.infNFE.Total.IcmsTot.vBC = totalVenda;
                    objNFE.infNFE.Total.IcmsTot.vICMS = (aliquotaIcms / 100) * baseIcms;
                    objNFE.infNFE.Total.IcmsTot.vBCST = 0;
                    objNFE.infNFE.Total.IcmsTot.vST = 0;
                    objNFE.infNFE.Total.IcmsTot.vProd = totalVenda;
                    objNFE.infNFE.Total.IcmsTot.vFrete = 0;
                    objNFE.infNFE.Total.IcmsTot.vSeg = 0;
                    objNFE.infNFE.Total.IcmsTot.vDesc = 0;
                    objNFE.infNFE.Total.IcmsTot.vII = 0;
                    objNFE.infNFE.Total.IcmsTot.vIPI = 0;
                    objNFE.infNFE.Total.IcmsTot.vPIS = Convert.ToDouble(Decimal.Round(Convert.ToDecimal(basePIS * aliquotaPIS) / 100, 2));
                    objNFE.infNFE.Total.IcmsTot.vCOFINS = Convert.ToDouble(Decimal.Round(Convert.ToDecimal(baseCofins * aliquotaCofins) / 100, 2));
                    objNFE.infNFE.Total.IcmsTot.vOutro = 0;
                    objNFE.infNFE.Total.IcmsTot.vNF = valorProdutos;

                    /*objNFE.infNFE.Total.IcmsTot.vProd - objNFE.infNFE.Total.IcmsTot.vDesc + objNFE.infNFE.Total.IcmsTot.vST
                       + objNFE.infNFE.Total.IcmsTot.vFrete + objNFE.infNFE.Total.IcmsTot.vSeg + objNFE.infNFE.Total.IcmsTot.vII + objNFE.infNFE.Total.IcmsTot.vIPI
                       + objNFE.infNFE.Total.IcmsTot.vOutro + objNFE.infNFE.Total.IcmsTot.vSeg;
                     */

                    if (objNFE.infNFE.Emit.CRT == 1) //se for simples nacional, ICMS é 0.
                    {
                        objNFE.infNFE.Total.IcmsTot.vICMS = 0;

                    }
                }
                objNFE.infNFE.Transp = new infNFE.transp();
                objNFE.infNFE.Transp.modFrete = frete;

                objNFE.infNFE.Total.vTotTrib = objNFE.infNFE.Total.IcmsTot.vICMS + objNFE.infNFE.Total.IcmsTot.vII + objNFE.infNFE.Total.IcmsTot.vST +
                                                objNFE.infNFE.Total.IcmsTot.vIPI + objNFE.infNFE.Total.IcmsTot.vPIS + objNFE.infNFE.Total.IcmsTot.vCOFINS + objNFE.infNFE.Total.IcmsTot.vOutro;


                //validação do tamanho dos campos
                objNFE.infNFE.Ide.natOp = VerificaTamanhoCampo(objNFE.infNFE.Ide.natOp, 60);
                objNFE.infNFE.Dest.xNome = VerificaTamanhoCampo(objNFE.infNFE.Dest.xNome, 60);
                objNFE.infNFE.Dest.EnderDest.xCpl = VerificaTamanhoCampo(objNFE.infNFE.Dest.EnderDest.xCpl, 60);
                objNFE.infNFE.Dest.EnderDest.xMun = VerificaTamanhoCampo(objNFE.infNFE.Dest.EnderDest.xMun, 60);
                objNFE.infNFE.Dest.EnderDest.xLgr = VerificaTamanhoCampo(objNFE.infNFE.Dest.EnderDest.xLgr, 60);
                objNFE.infNFE.Dest.EnderDest.nro = VerificaTamanhoCampo(objNFE.infNFE.Dest.EnderDest.nro, 60);
                objNFE.infNFE.Dest.EnderDest.xBairro = VerificaTamanhoCampo(objNFE.infNFE.Dest.EnderDest.xBairro, 60);
                objNFE.infNFE.Dest.EnderDest.fone = VerificaTamanhoCampo(objNFE.infNFE.Dest.EnderDest.fone, 14);

                objNFE.infNFE.Emit.xNome = VerificaTamanhoCampo(objNFE.infNFE.Emit.xNome, 60);
                objNFE.infNFE.Emit.xFant = VerificaTamanhoCampo(objNFE.infNFE.Emit.xFant, 60);
                objNFE.infNFE.Emit.EnderEmit.xLgr = VerificaTamanhoCampo(objNFE.infNFE.Emit.EnderEmit.xLgr, 60);
                objNFE.infNFE.Emit.EnderEmit.nro = VerificaTamanhoCampo(objNFE.infNFE.Emit.EnderEmit.nro, 60);
                objNFE.infNFE.Emit.EnderEmit.xBairro = VerificaTamanhoCampo(objNFE.infNFE.Emit.EnderEmit.xBairro, 60);
                objNFE.infNFE.Emit.EnderEmit.fone = VerificaTamanhoCampo(objNFE.infNFE.Emit.EnderEmit.fone, 14);

                //gera txt
                #region gera TXT
                string strNomeArquivo = string.Empty;

                strNomeArquivo = "Venda_" + this.intCodigoVenda + ".txt";

                StreamWriter strDados = new StreamWriter(strCaminho + "\\" + strNomeArquivo, false, Encoding.UTF8);

                string strInicio = "NOTAFISCAL|1";
                strDados.WriteLine(strInicio);

                string LinhaA = "";
                LinhaA = "A|3.10"; //A|versão do schema|id|
                strDados.WriteLine(LinhaA);

                string strdhEmi = DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00") + "T" + DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00") + "-03:00";

                string LinhaB = "";
                //  layout v3.10 B|cUF|cNF|natOp|indPag|mod|serie|nNF|dhEmi|dhSaiEnt|tpNF|idDest|cMunFG|tpImp|tpEmis|cDV|tp Amb|finNFe|indFinal|indPres|procEmi|verProc|dhCont|xJust|
                LinhaB = "B|"; //B|cUF|cNF|NatOp|intPag|mod|serie|nNF|dEmi|dSaiEnt|dhSaiEnt|tpNF|cMunFG|TpImp|TpEmis|cDV|tpAmb|finNFe|procEmi|VerProc|dhCont|xJust| 
                LinhaB += objNFE.infNFE.Ide.cUF.ToString() + "||" + Funcoes.TirarAcento(objNFE.infNFE.Ide.natOp) + "|" + objNFE.infNFE.Ide.indPag + "|" +
                     objNFE.infNFE.Ide.mod + "|" + objNFE.infNFE.Ide.serie + "|" + objNFE.infNFE.Ide.nNF + "|" + strdhEmi + "||" + objNFE.infNFE.Ide.tpNF.ToString() + "|" +
                  objNFE.infNFE.Dest.idDest + "|" + objNFE.infNFE.Ide.cMunFG + "|" + objNFE.infNFE.Ide.tpImp.ToString() + "|" + objNFE.infNFE.Ide.tpEmis + "||" + objNFE.infNFE.Ide.tpAmb.ToString() + "|" +
                    objNFE.infNFE.Ide.finNFe + "|" + objNFE.infNFE.Dest.indFinal + "|" + objNFE.infNFE.Dest.indPres + "|" + objNFE.infNFE.Ide.procEmi + "||||";
                strDados.WriteLine(LinhaB);


                string LinhaC = "";
                LinhaC = "C|";//C|XNome|XFant|IE|IEST|IM|CNAE|CRT|CNPJ ou CPF|XLgr|Nro|Cpl|Bairro|CMun|XMun|UF|CEP|cPais|xPais|fone|
                LinhaC += Funcoes.TirarAcento(objNFE.infNFE.Emit.xNome) + "|" + Funcoes.TirarAcento(objNFE.infNFE.Emit.xFant) + "|" + objNFE.infNFE.Emit.IE + "||||" + objNFE.infNFE.Emit.CRT + "|";
                strDados.WriteLine(LinhaC);
                LinhaC = "C02|" + objNFE.infNFE.Emit.CNPJ + "|";
                strDados.WriteLine(LinhaC);
                LinhaC = "C05|" + Funcoes.TirarAcento(objNFE.infNFE.Emit.EnderEmit.xLgr) + "|" + objNFE.infNFE.Emit.EnderEmit.nro + "|" + Funcoes.TirarAcento(objNFE.infNFE.Emit.EnderEmit.xCpl) + "|" +
                   Funcoes.TirarAcento(objNFE.infNFE.Emit.EnderEmit.xBairro) + "|" + objNFE.infNFE.Emit.EnderEmit.cMun.ToString() + "|" + Funcoes.TirarAcento(objNFE.infNFE.Emit.EnderEmit.xMun) + "|" + objNFE.infNFE.Emit.EnderEmit.UF + "|" +
                   objNFE.infNFE.Emit.EnderEmit.CEP + "|1058|BRASIL|" + objNFE.infNFE.Emit.EnderEmit.fone + "|";

                strDados.WriteLine(LinhaC);

                string LinhaE = "";
                LinhaE = "E|";//   E|xNome|IE|ISUF|email|CNPJ ou CPF|xLgr|nro|xCpl|xBairro|cMun|xMun|UF|CEP|cPais|xPais|fone|
                //Layout novo v3.1 E|xNome|indIEDest|IE|ISUF|IM|email|
                LinhaE += Funcoes.TirarAcento(objNFE.infNFE.Dest.xNome) + "|" + objNFE.infNFE.Dest.indIEDest + "|" + objNFE.infNFE.Dest.IE + "|||";
                strDados.WriteLine(LinhaE);

                if (String.IsNullOrEmpty(objNFE.infNFE.Dest.CPF))
                {
                    LinhaE = "E02|" + objNFE.infNFE.Dest.CNPJ + "|";
                }
                else
                {
                    LinhaE = "E03|" + objNFE.infNFE.Dest.CPF + "|";
                }
                strDados.WriteLine(LinhaE);

                LinhaE = "E05|" + Funcoes.TirarAcento(objNFE.infNFE.Dest.EnderDest.xLgr) + "|" + objNFE.infNFE.Dest.EnderDest.nro + "|" + Funcoes.TirarAcento(objNFE.infNFE.Dest.EnderDest.xCpl) + "|" +
                   Funcoes.TirarAcento(objNFE.infNFE.Dest.EnderDest.xBairro) + "|" + objNFE.infNFE.Dest.EnderDest.cMun.ToString() + "|" + Funcoes.TirarAcento(objNFE.infNFE.Dest.EnderDest.xMun) + "|" +
                   objNFE.infNFE.Dest.EnderDest.UF + "|" + objNFE.infNFE.Dest.EnderDest.CEP + "|1058|BRASIL|" + objNFE.infNFE.Dest.EnderDest.fone + "|";

                strDados.WriteLine(LinhaE);



                for (int i = 0; i < objNFE.infNFE.Det.Count; i++)
                {

                    string LinhaH = "";

                    LinhaH = "H|";//H|nItem|infAdProd|
                    LinhaH += i + 1 + "||";

                    strDados.WriteLine(LinhaH);

                    string LinhaI = "";

                    LinhaI = "I|";//I|CProd|CEAN|XProd|NCM|EXTIPI|CFOP|UCom|QCom|VUnCom|VProd|CEANTrib|UTrib|QTrib|VUnTrib|VFrete|VSeg|VDesc|vOutro|indTot | xPed | nItemPed | 
                    //layout v 3.1   |cProd|cEAN|xProd|NCM|EXTIPI|CFOP|uCom|qCom|vUnCom|vProd|cEANTrib|uTrib|qTrib|vUnTrib|vFrete|vSeg|vDesc|
                    LinhaI += objNFE.infNFE.Det.ElementAt(i).Prod.cProd + "||" + Funcoes.TirarAcento(objNFE.infNFE.Det.ElementAt(i).Prod.xProd) + "|" + objNFE.infNFE.Det.ElementAt(i).Prod.NCM + "||" +
                       objNFE.infNFE.Det.ElementAt(i).Prod.CFOP + "|" + Funcoes.TirarAcento(objNFE.infNFE.Det.ElementAt(i).Prod.uCom) + "|" + objNFE.infNFE.Det.ElementAt(i).Prod.qCom + "|" +
                       objNFE.infNFE.Det.ElementAt(i).Prod.vUnCom.ToString("0.00").Replace(",", ".") + "|" + objNFE.infNFE.Det.ElementAt(i).Prod.vProd.ToString("0.00").Replace(",", ".") + "||" + objNFE.infNFE.Det.ElementAt(i).Prod.uTrib + "|" + objNFE.infNFE.Det.ElementAt(i).Prod.qTrib + "|" +
                       objNFE.infNFE.Det.ElementAt(i).Prod.vUnTrib.ToString().Replace(",", ".") + "|||||1|";

                    strDados.WriteLine(LinhaI);

                    strDados.WriteLine("M|" + objNFE.infNFE.Det.ElementAt(i).TotalImpostos.ToString("0.00").Replace(",", "."));//linha M

                    string LinhaN = ""; //icms
                    if (objNFE.infNFE.Det.ElementAt(i).Imposto.Icms != null)//n02
                    {
                        LinhaN = "N|";
                        strDados.WriteLine(LinhaN);

                        if (objNFE.infNFE.Det.ElementAt(i).Imposto.Icms.Icms00 != null)
                        {                    //       
                            LinhaN = "N02|"; //N02 | Orig | CST | ModBC | VBC | PICMS | VICMS | 
                            LinhaN += objNFE.infNFE.Det.ElementAt(i).Imposto.Icms.Icms00.orig.ToString() + "|" + objNFE.infNFE.Det.ElementAt(i).Imposto.Icms.Icms00.CST.ToString() + "|" +
                                objNFE.infNFE.Det.ElementAt(i).Imposto.Icms.Icms00.modBC.ToString() + "|" +
                                objNFE.infNFE.Det.ElementAt(i).Imposto.Icms.Icms00.vBC.ToString("0.00").Replace(",", ".") + "|" + objNFE.infNFE.Det.ElementAt(i).Imposto.Icms.Icms00.pICMS.ToString().Replace(",", ".") + "|" + objNFE.infNFE.Det.ElementAt(i).Imposto.Icms.Icms00.vICMS.ToString("0.00").Replace(",", ".") + "|";

                            // dValorTotalTrib += objNFE.infNFE.Det.ElementAt(i).Imposto.Icms.Icms00.vICMS;
                        }
                        else
                        {
                            LinhaN = "N06|"; //N02 | Orig | CST | ModBC | VBC | PICMS | VICMS | 
                            //novo layout v.3.1:      orig|CST|vICMSDeson|motDesICMS|
                            LinhaN += objNFE.infNFE.Det.ElementAt(i).Imposto.Icms.Icms40.orig.ToString() + "|" + objNFE.infNFE.Det.ElementAt(i).Imposto.Icms.Icms40.CST.ToString() + "|";

                        }


                    }
                    strDados.WriteLine(LinhaN);

                    string LinhaQ = "";//pis
                    LinhaQ = "Q|";
                    strDados.WriteLine(LinhaQ);

                    if (objNFE.infNFE.Det.ElementAt(i).Imposto.Pis.PisAliq != null)//Q02|CST|VBC|PPIS|VPIS| 
                    {
                        LinhaQ = "Q02|" + objNFE.infNFE.Det.ElementAt(i).Imposto.Pis.PisAliq.CST.ToString() + "|" + objNFE.infNFE.Det.ElementAt(i).Imposto.Pis.PisAliq.vBC.ToString("0.00").Replace(",", ".") + "|" + objNFE.infNFE.Det.ElementAt(i).Imposto.Pis.PisAliq.pPIS.ToString("0.00").Replace(",", ".") + "|" +
                            objNFE.infNFE.Det.ElementAt(i).Imposto.Pis.PisAliq.vPIS.ToString("0.00").Replace(",", ".") + "|";

                    }
                    else
                    {
                        LinhaQ = "Q04|" + objNFE.infNFE.Det.ElementAt(i).Imposto.Pis.PisNT.CST.ToString() + "|";
                    }


                    if (objNFE.infNFE.Det.ElementAt(i).Imposto.Pis.PisAliq != null)
                        dValorTotalTrib += objNFE.infNFE.Det.ElementAt(i).Imposto.Pis.PisAliq.vPIS;

                    strDados.WriteLine(LinhaQ);

                    string LinhaS = "";//cofins
                    LinhaS = "S|";
                    strDados.WriteLine(LinhaS);

                    if (objNFE.infNFE.Det.ElementAt(i).Imposto.Pis.PisAliq != null)//S02|CST|VBC|PCOFINS|VCOFINS| 
                    {
                        LinhaS = "S02|" + objNFE.infNFE.Det.ElementAt(i).Imposto.Cofins.CofinsAliq.CST.ToString() + "|" +
                            objNFE.infNFE.Det.ElementAt(i).Imposto.Cofins.CofinsAliq.vBC.ToString("0.00").Replace(",", ".") + "|" + objNFE.infNFE.Det.ElementAt(i).Imposto.Cofins.CofinsAliq.pCOFINS.ToString("0.00").Replace(",", ".") + "|" +
                            objNFE.infNFE.Det.ElementAt(i).Imposto.Cofins.CofinsAliq.vCOFINS.ToString("0.00").Replace(",", ".") + "|";

                    }
                    else
                    {
                        LinhaS = "S04|" + objNFE.infNFE.Det.ElementAt(i).Imposto.Cofins.CofinsNT.CST.ToString() + "|";
                    }

                    if (objNFE.infNFE.Det.ElementAt(i).Imposto.Cofins.CofinsAliq != null)
                        dValorTotalTrib += objNFE.infNFE.Det.ElementAt(i).Imposto.Cofins.CofinsAliq.vCOFINS;

                    strDados.WriteLine(LinhaS);

                }


                string LinhaW = "";//totais
                LinhaW = "W|";
                strDados.WriteLine(LinhaW);
                //v.3.1  |vBC|vICMS|vICMSDeson|vBCST|vST|vProd|vFrete|vSeg|vDesc|vII|vIPI|vPIS|vCOFINS|vOutro|vNF|vTotTrib|
                if (objNFE.infNFE.Total.IcmsTot != null)//W02|vBC|vICMS|          |vBCST|vST|vProd|vFrete|vSeg|vDesc|vII|vIPI|vPIS|vCOFINS|vOutro|vNF|
                {
                    LinhaW = "W02|" + objNFE.infNFE.Total.IcmsTot.vBC.ToString("0.00").Replace(",", ".") + "|" + objNFE.infNFE.Total.IcmsTot.vICMS.ToString("0.00").Replace(",", ".") + "|" + "|" + objNFE.infNFE.Total.IcmsTot.vBCST.ToString("0.00").Replace(",", ".") + "|" +
                        objNFE.infNFE.Total.IcmsTot.vST.ToString("0.00").Replace(",", ".") + "|" + objNFE.infNFE.Total.IcmsTot.vProd.ToString("0.00").Replace(",", ".") + "|" + objNFE.infNFE.Total.IcmsTot.vFrete.ToString("0.00").Replace(",", ".") + "|" +
                        objNFE.infNFE.Total.IcmsTot.vSeg.ToString("0.00").Replace(",", ".") + "|" + objNFE.infNFE.Total.IcmsTot.vDesc.ToString("0.00").Replace(",", ".") + "|" + objNFE.infNFE.Total.IcmsTot.vII.ToString().Replace(",", ".") + "|" +
                        objNFE.infNFE.Total.IcmsTot.vIPI.ToString("0.00").Replace(",", ".") + "|" + objNFE.infNFE.Total.IcmsTot.vPIS.ToString("0.00").Replace(",", ".") + "|" + objNFE.infNFE.Total.IcmsTot.vCOFINS.ToString("0.00").Replace(",", ".") + "|" +
                        objNFE.infNFE.Total.IcmsTot.vOutro.ToString("0.00").Replace(",", ".") + "|" + objNFE.infNFE.Total.IcmsTot.vNF.ToString("0.00").Replace(",", ".") + "|" + dValorTotalTrib.ToString("0.00").Replace(",", ".") + "|";

                }
                strDados.WriteLine(LinhaW);


                string LinhaX = "";//frete
                LinhaX = "X|" + objNFE.infNFE.Transp.modFrete + "|";

                strDados.WriteLine(LinhaX);

                LinhaX = "X03||||||";// X03 | XNome | IE | XEnder | UF | XMun |

                strDados.WriteLine(LinhaX);

                LinhaX = "X04||";// X03 | XNome | IE | XEnder | UF | XMun |

                strDados.WriteLine(LinhaX);

                string LinhaY = "";//frete
                LinhaY = "Y|" + objNFE.infNFE.Transp.modFrete + "|";
                strDados.WriteLine(LinhaY);


                //if (infNFe["prs_c_obs"] != DBNull.Value)
                //{
                //    if (!string.IsNullOrEmpty(infNFe["prs_c_obs"].ToString()))
                //    {
                //        string LinhaZ = "";
                //        LinhaZ = "Z||" + Funcoes.TirarAcento(infNFe["prs_c_obs"].ToString());
                //        strDados.WriteLine(LinhaZ);
                //    }
                //}

                strDados.Close();

                #endregion

                DirectoryInfo dir = new DirectoryInfo(strCaminho);

                foreach (FileInfo arquivo in dir.GetFiles())
                {

                    if (arquivo.Name.StartsWith(strNomeArquivo))
                    {
                        //Limpa o conteúdo de saída atual do buffer
                        //Response.Clear();

                        ////Adiciona um cabeçalho que especifica o nome default para a caixa de diálogos Salvar Como...
                        //Response.ContentType = "application/octet-stream";
                        //Response.AddHeader("Content-Disposition", "attachment; filename=" + arquivo.Name + "");

                        ////Adiciona ao cabeçalho o tamanho do arquivo para que o browser possa exibir o progresso do download
                        //Response.AddHeader("Content-Length", arquivo.Length.ToString());
                        //Response.Flush();
                        //Response.WriteFile(arquivo.FullName);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Utilitarios.SalvarLog(ex.Message, "VENDAS - GerarTXT");
            }

        }

        public string VerificaTamanhoCampo(string strCampo, int intTamanho)
        {
            try
            {
                if (strCampo.Length > intTamanho)
                    strCampo = strCampo.Substring(0, intTamanho);

                return strCampo;
            }
            catch (Exception ex)
            {
                return strCampo;
            }
        }

        private void txtValorRecebido_Click(object sender, EventArgs e)
        {
            //  txtValorRecebido.Text = string.Empty;
        }

        private void txtDesconto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDesconto.Text))
            {
                if (txtDesconto.Text.Contains("%"))
                {
                    decimal decDesconto = Math.Round((this.decTotalPagar * Convert.ToDecimal(txtDesconto.Text.Replace("%", "")) / 100), 2);
                    txtDesconto.Text = decDesconto.ToString();
                }

                this.decDesconto = Convert.ToDecimal(txtDesconto.Text);
                this.CalculaValores();
            }
        }

        private void txtValorRecebido_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtValorRecebido.Text))
                {
                    this.CalculaValores();
                    //pagamento parcial
                    if (Convert.ToDecimal(txtValorRecebido.Text) < this.decTotalPagar)
                    {
                        lblTotalPagar.Text = (this.decTotalPagar - Convert.ToDecimal(txtValorRecebido.Text)).ToString("C");

                    }
                    else
                        lblTroco.Text = (Convert.ToDecimal(txtValorRecebido.Text) - this.decTotalPagar).ToString("C");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "VENDAS - txtValorRecebido_Leave");
            }
        }

        private void txtAcrescimo_Leave(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(txtAcrescimo.Text))
                {
                    this.decAcrescimo = Convert.ToDecimal(txtAcrescimo.Text);
                    this.CalculaValores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "VENDAS - txtValorRecebido_Leave");
            }
        }

        private void txtCodigoVendedor_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodigoVendedor.Text))
                {
                    DataTable dtVendedores = new DataTable();
                    Usuario objUsuario = new Usuario();
                    objUsuario.Status = true;
                    objUsuario.Codigo = Convert.ToInt32(txtCodigoVendedor.Text);
                    dtVendedores = objUsuario.Listar(objUsuario);

                    if (dtVendedores.Rows.Count > 0)
                        lblVendedor.Text = dtVendedores.Rows[0]["Nome"].ToString();
                    else
                    {
                        MessageBox.Show("Vendedor não encontrado!");
                        txtCodigoVendedor.Text = string.Empty;
                        txtCodigoVendedor.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "VENDAS - txtCodigoVendedor_Leave");
            }
        }

        private void txtCodigoVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    if (!string.IsNullOrEmpty(txtCodigoVendedor.Text))
                    {
                        DataTable dtVendedores = new DataTable();
                        Usuario objUsuario = new Usuario();
                        objUsuario.Status = true;
                        objUsuario.Codigo = Convert.ToInt32(txtCodigoVendedor.Text);
                        dtVendedores = objUsuario.Listar(objUsuario);

                        if (dtVendedores.Rows.Count > 0)
                            lblVendedor.Text = dtVendedores.Rows[0]["Nome"].ToString();
                        else
                        {
                            MessageBox.Show("Vendedor não encontrado!");
                            txtCodigoVendedor.Text = string.Empty;
                            txtCodigoVendedor.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "VENDAS - txtCodigoVendedor_KeyDown");
            }
        }

        private void ddlFormaPagto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //se a forma de pagamento for diferente de dinheiro, preencher automaticamente o valor recebido
                if (ddlFormaPagto.SelectedValue != null)
                {
                    if (ddlFormaPagto.Text != "DINHEIRO")
                    {
                        decimal decValorRecebido = 0;

                        if (!string.IsNullOrEmpty(txtValorRecebido.Text))
                            decValorRecebido = Convert.ToDecimal(txtValorRecebido.Text);

                        if (decValorRecebido > this.decTotalPagar)
                        {
                            txtValorRecebido.Text = this.decTotalPagar.ToString();
                            this.CalculaValores();
                        }
                        //  txtValorRecebido.Text = lblTotalPagar.Text.Replace("R$", "").Replace(" ", "");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtValorDinheiro_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13 && !string.IsNullOrEmpty(txtValorDinheiro.Text))
                {
                    this.CalculaValores();
                    ddlCartao.Focus();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtValorDinheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 190 || e.KeyChar == 46)
            {
                e.KeyChar = (char)44;
            }
        }

        private void txtValorRecebido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 190 || e.KeyChar == 46)
            {
                e.KeyChar = (char)44;
            }
        }

        private void txtDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 190 || e.KeyChar == 46)
            {
                e.KeyChar = (char)44;
            }
        }

        private void txtAcrescimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 190 || e.KeyChar == 46)
            {
                e.KeyChar = (char)44;
            }
        }
    }
}
