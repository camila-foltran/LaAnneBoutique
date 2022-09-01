using Loja;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace loja
{
    public partial class frmTroca : Form
    {
        public frmTroca()
        {
            InitializeComponent();
            this.CarregarForm();
        }

        #region Variaveis

        public int intCodigoTroca = 0;
        public decimal decTotalDiferenca = 0;
        public decimal decValorTotalVenda = 0;
        public decimal decValorTotalTroca = 0;
        public string CodigoProdutoVendido = "0";

        public DataTable dtTroca = new DataTable();
        public DataTable dtVenda = new DataTable();

        #endregion

        private void CarregarForm()
        {
            try
            {
                dtTroca.Columns.Add("Codigo");
                dtTroca.Columns.Add("CodigoProduto");
                dtTroca.Columns.Add("Código");
                dtTroca.Columns.Add("Nome");
                dtTroca.Columns.Add("Tamanho");
                dtTroca.Columns.Add("Cor");
                dtTroca.Columns.Add("Marca");
                dtTroca.Columns.Add("ValorVenda");

                dtVenda.Columns.Add("Codigo");
                dtVenda.Columns.Add("CodigoProduto");
                dtVenda.Columns.Add("Código");
                dtVenda.Columns.Add("Nome");
                dtVenda.Columns.Add("Tamanho");
                dtVenda.Columns.Add("Cor");
                dtVenda.Columns.Add("Marca");
                dtVenda.Columns.Add("ValorVenda");

                Produto objProduto = new Produto();
                DataTable dtVendedores = new DataTable();
                Usuario objUsuario = new Usuario();
                dtVendedores = objUsuario.Listar(objUsuario);

                AutoCompleteStringCollection strCodigoVendedores = new AutoCompleteStringCollection();

                foreach (DataRow dr in dtVendedores.Rows)
                {
                    strCodigoVendedores.Add(dr["Código"].ToString());
                }

                txtCodigoVendedor.AutoCompleteCustomSource = strCodigoVendedores;

                ddlFormaPagto.DataSource = objProduto.ListarFormaPagto(objProduto);
                ddlFormaPagto.DisplayMember = "FPG_C_DESCRICAO";
                ddlFormaPagto.ValueMember = "FPG_N_CODIGO";
                ddlFormaPagto.SelectedValue = "20";

                txtValorRecebido.Text = "0,00";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "TROCA - CarregarForm()");
            }
        }

        private void LimparForm()
        {
            try
            {
                this.intCodigoTroca = 0;
                this.decTotalDiferenca = 0;
                this.CodigoProdutoVendido = "0";
                this.decValorTotalVenda = 0;

                txtCodigoTroca.Text = string.Empty;
                txtCodigoVenda.Text = string.Empty;
                txtValorRecebido.Text = string.Empty;
                txtValorRecebido.Text = string.Empty;
                ddlFormaPagto.SelectedValue = "20";

                txtCodigoVendedor.Text = string.Empty;
                txtCodigoVenda.Enabled = true;
                txtDesconto.Text = string.Empty;
                txtValorRecebido.Text = string.Empty;

                //popular grid de itens

                rgvProdutosTroca.DataSource = this.dtTroca;
                rgvProdutosTroca.Columns[1].Visible = false;
                rgvProdutosTroca.Columns[2].Visible = false;

            }
            catch (Exception ex)
            {
                Utilitarios.SalvarLog(ex.Message, "TROCA - LimparForm()");
            }
        }

        private void btnCancelarTroca_Click(object sender, EventArgs e)
        {
            this.LimparForm();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

        }

        private void btnTrocar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodigoVendedor.Text))
                {
                    if (txtValorRecebido.Text != "0,00" && txtValorRecebido.Text != "" && this.decTotalDiferenca > 0)
                    {
                        if (ddlFormaPagto.Text == "" || ddlFormaPagto.Text == "SELECIONE...")
                        {
                            MessageBox.Show("Selecione a forma de pagamento!");
                            ddlFormaPagto.Focus();
                            return;
                        }

                        if (Convert.ToDecimal(txtValorRecebido.Text) == 0 && this.decTotalDiferenca > 0)
                        {
                            MessageBox.Show("Informe o valor recebido!");
                            txtValorRecebido.Focus();
                            return;
                        }
                    }


                    bool blnTemPagto = false;
                    //registra forma de pagamento
                    if (Convert.ToDecimal(txtValorRecebido.Text) > 0)
                    {
                        blnTemPagto = true;
                        FormaPagtoTroca objFPT = new FormaPagtoTroca();
                        objFPT.CodigoFormaPagto = Convert.ToInt32(ddlFormaPagto.SelectedValue);
                        objFPT.CodigoTroca = this.intCodigoTroca;
                        objFPT.Valor = Convert.ToDecimal(txtValorRecebido.Text);
                        int intRet = objFPT.Inserir(objFPT);

                        decimal decDesconto = 0;

                        if (!string.IsNullOrEmpty(txtDesconto.Text))
                            decDesconto = Convert.ToDecimal(txtDesconto.Text);

                        //verificar se é um pagamento parcial (em várias formas)
                        if (((objFPT.Valor + decDesconto) - this.decTotalDiferenca) != 0 && objFPT.Valor > 0)
                        {
                            txtValorRecebido.Text = (this.decTotalDiferenca - objFPT.Valor).ToString();

                            MessageBox.Show("Pagamento registrado, informe o valor restante a receber e a forma de pagamento");
                            ddlFormaPagto.SelectedValue = "20";
                            ddlFormaPagto.Focus();
                            return;
                        }
                    }

                    Troca objTroca = new Troca();
                    objTroca.Codigo = this.intCodigoTroca;
                    objTroca.CodigoUsuario = Convert.ToInt32(txtCodigoVendedor.Text);
                    objTroca.CodigoVenda = Convert.ToInt32(txtCodigoVenda.Text);
                    objTroca.ValorVenda = 0;//Convert.ToDecimal(lblValorDiferenca.Text.Replace("R$", ""));
                    objTroca.ValorTroca = this.decTotalDiferenca;

                    if (!string.IsNullOrEmpty(txtDesconto.Text))
                        objTroca.Desconto = Convert.ToDecimal(txtDesconto.Text);

                    objTroca.Alterar(objTroca);

                    if (blnTemPagto)
                    {
                        this.ImprimirCupom(this.intCodigoTroca);
                    }

                    MessageBox.Show("Troca realizada com sucesso!");
                    this.LimparForm();
                }
                else
                {
                    MessageBox.Show("Informe o código do vendedor!");
                    txtCodigoVendedor.Focus();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "TROCA - btnTrocar_Click");
            }
        }

        /// <summary>
        /// Esse cupom  deve ser diferente pois é troca não é necessário ser impresso todos os itens
        /// </summary>
        /// <param name="intCodigoTroca"></param>
        /// <returns></returns>
        private int ImprimirCupom(int intCodigoTroca)
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
                int iRetorno = 0;

                StringBuilder stb = this.MontaCupom2(intCodigoTroca);

                if (Utilitarios.ModeloImpressora == 5)
                    iRetorno = MP2032.ConfiguraModeloImpressora(Utilitarios.ModeloImpressora);
                else
                    iRetorno = MP2064.ConfiguraModeloImpressora(Utilitarios.ModeloImpressora);

                try
                {
                    if (Utilitarios.ModeloImpressora == 5)
                        iRetorno = MP2032.Le_Status();
                    else
                        iRetorno = MP2064.Le_Status();

                    if (iRetorno == 32)//sem papel
                    {
                        MessageBox.Show("A impressora está sem papel, para imprimir o comprovante coloque a bobina de papel na impressora e imprima-o na listagem de vendas. CÓDIGO DA VENDA: " + intCodigoTroca);

                        Utilitarios.SalvarLog("Impressora sem papel: 32 ", "VENDAS - ImprimirCupom(" + intCodigoTroca + ")");

                        stb.Append("\r\n\r\n\r\n");
                        //salvar em uma tabela os cupoms que não foram impressos
                        Comprovante objComprovante = new Comprovante();
                        objComprovante.CodigoVenda = this.intCodigoTroca;
                        objComprovante.TextoComprovante = stb.ToString();
                        objComprovante.Status = "IMPRIMIR";
                        int intId = objComprovante.Inserir(objComprovante);
                        return 0;
                    }
                    else if (iRetorno == 68)//Erro de comunicação/"OFFLINE"
                    {
                        MessageBox.Show("Erro de comunicação com a impressora, para reimprimir o comprovante imprima-o na listagem de vendas. CÓDIGO DA VENDA: " + intCodigoTroca);

                        Utilitarios.SalvarLog("Erro de comunicação com a impressora: 68 ", "VENDAS - ImprimirCupom(" + intCodigoTroca + ")");

                        stb.Append("\r\n\r\n\r\n");
                        //salvar em uma tabela os cupoms que não foram impressos
                        Comprovante objComprovante = new Comprovante();
                        objComprovante.CodigoVenda = this.intCodigoTroca;
                        objComprovante.TextoComprovante = stb.ToString();
                        objComprovante.Status = "IMPRIMIR";
                        int intId = objComprovante.Inserir(objComprovante);
                        return 0;
                    }
                    else
                    {
                        if (Utilitarios.ModeloImpressora == 5)
                            iRetorno = MP2032.IniciaPorta(Utilitarios.PortaImpressora);//inicia a porta com o valor da combo (exceto ethernet)
                        else
                            iRetorno = MP2064.IniciaPorta(Utilitarios.PortaImpressora);//inicia a porta com o valor da combo (exceto ethernet)

                        if (iRetorno <= 0)// erro
                        {
                            MessageBox.Show("Erro ao iniciar a porta da impressora, desligue a impressora, ligue-a novamente, execute o aplicativo 'Instalar impressoras' do menu iniciar e reimprima o comprovante imprima-o na listagem de vendas. CÓDIGO DA TROCA: " + intCodigoTroca);

                            Utilitarios.SalvarLog("Erro ao iniciar porta: " + iRetorno, "VENDAS - ImprimirCupom(" + intCodigoTroca + ")");

                            stb.Append("\r\n\r\n\r\n");
                            //salvar em uma tabela os cupoms que não foram impressos
                            Comprovante objComprovante = new Comprovante();
                            objComprovante.CodigoVenda = this.intCodigoTroca;
                            objComprovante.TextoComprovante = stb.ToString();
                            objComprovante.Status = "IMPRIMIR";
                            int intId = objComprovante.Inserir(objComprovante);
                            return 0;
                        }
                    }

                }
                catch (Exception ex)
                {
                    Utilitarios.SalvarLog(ex.Message, "VENDAS - ImprimirCupom(" + intCodigoTroca + ")");
                }

                // \n - quebra de linha e \r retorno de impressão (comandos da impressora)
                if (Utilitarios.ModeloImpressora == 5)
                {
                    iRetorno = MP2032.FormataTX(stb.ToString(), tLetra, italico, sublinhado, expandido, enfatizado);//ao ser clicado, imprime o texto da Text Box
                    iRetorno = MP2032.BematechTX("\r\n\r\n\r\n");
                }
                else
                {
                    iRetorno = MP2064.FormataTX(stb.ToString(), tLetra, italico, sublinhado, expandido, enfatizado);//ao ser clicado, imprime o texto da Text Box
                    iRetorno = MP2064.BematechTX("\r\n\r\n\r\n");
                }

                if (iRetorno == 0)//não imprimiu
                {
                    stb.Append("\r\n\r\n\r\n");
                    //salvar em uma tabela os cupoms que não foram impressos
                    Comprovante objComprovante = new Comprovante();
                    objComprovante.CodigoVenda = this.intCodigoTroca;
                    objComprovante.TextoComprovante = stb.ToString();
                    objComprovante.Status = "IMPRIMIR";
                    int intId = objComprovante.Inserir(objComprovante);
                    return 0;
                }

                if (Utilitarios.ModeloImpressora == 5)
                {
                    iRetorno = MP2032.AcionaGuilhotina(0);
                    iRetorno = MP2032.FechaPorta();
                }
                else
                {
                    iRetorno = MP2064.AcionaGuilhotina(0);
                    iRetorno = MP2064.FechaPorta();
                }

                return 1;
            }
            catch (Exception ex)
            {
                Utilitarios.SalvarLog(ex.Message, "TROCA - ImprimirCupom(" + intCodigoTroca + ")");
                return 0;
            }
        }

        private StringBuilder MontaCupom2(int intCodigoTroca)
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

                DataSet dtItensVenda = new DataSet();
                ItemVenda objItemVenda = new ItemVenda();

                DataTable dtTroca = new DataTable();
                Troca objTroca = new Troca();
                objTroca.Codigo = this.intCodigoTroca;
                dtTroca = objTroca.Listar(objTroca);

                objItemVenda.CodigoVenda = Convert.ToInt32(dtTroca.Rows[0]["tro_n_codigo_venda"]);
                dtItensVenda = objItemVenda.Listar(objItemVenda);

                StringBuilder stb = new StringBuilder();
                stb.Append("\x1B\x61\x1" + dtLoja.Rows[0]["loj_c_nome"].ToString() + "\r\n");
                stb.Append("\x1B\x61\x1" + dtLoja.Rows[0]["loj_c_endereco"].ToString() + "\r\n");
                stb.Append("CNPJ: " + dtLoja.Rows[0]["loj_c_cnpj"].ToString() + "\r\n");
                stb.Append("IE: " + dtLoja.Rows[0]["loj_c_ie"].ToString() + "\r\n");
                stb.Append("--------------------------------------------------\r\n");
                stb.Append(DateTime.Now.ToString() + "                    COD: " + objItemVenda.CodigoVenda.ToString("000000") + "\r\n");
                stb.Append("      COMPROVANTE - NÃO É DOCUMENTO FISCAL       \r\n");
                stb.Append("ITEM CÓDIGO        DESCRIÇÃO         QTD VALOR(R$)\r\n ");

                foreach (DataRow dr in dtItensVenda.Tables[0].Rows)
                {
                    string strProduto = dr["Nome"].ToString();

                    if (strProduto.Length > 18)
                        strProduto = strProduto.Substring(0, 18);

                    string strCodigo = dr["Código"].ToString();

                    if (strCodigo.Length > 13)
                        strCodigo = dr["Referência"].ToString();

                    stb.Append(item.ToString("00").PadRight(4) + strCodigo.PadRight(13) + " " + strProduto.PadRight(18) + " " + Convert.ToInt32(dr["Qtde"]).ToString("00").PadLeft(2) + " " + dr["Valor Total"].ToString().PadLeft(9) + "\r\n ");
                    linhas++;
                    item++;

                }

                // stb.Append("--------------------------------------------------------\r\n");
                stb.Append("TOTAL R$ " + dtItensVenda.Tables[1].Rows[0]["ven_n_total"].ToString().PadLeft(40, ' ') + "\r\n ");
                linhas++;

                if (dtItensVenda.Tables[1].Rows[0]["ven_n_acrescimo"] != DBNull.Value)
                {
                    if (Convert.ToDecimal(dtItensVenda.Tables[1].Rows[0]["ven_n_acrescimo"]) > 0)
                    {
                        string strAcrescimo = dtItensVenda.Tables[1].Rows[0]["ven_n_acrescimo"].ToString().PadLeft(39, ' ');
                        stb.Append("ACRÉSCIMO " + strAcrescimo + "\r\n ");
                        linhas++;
                    }
                }

                if (dtItensVenda.Tables[1].Rows[0]["ven_n_desconto"] != DBNull.Value)
                {
                    if (Convert.ToDecimal(dtItensVenda.Tables[1].Rows[0]["ven_n_desconto"]) > 0)
                    {
                        string strDesconto = "-" + dtItensVenda.Tables[1].Rows[0]["ven_n_desconto"].ToString();
                        stb.Append("DESCONTO " + strDesconto.PadLeft(40) + "\r\n ");
                        linhas++;
                    }
                }

                //PROGRAMAR AQUI A FORMA DE PAGAMENTO
                foreach (DataRow dr in dtItensVenda.Tables[2].Rows)
                {
                    // if (dr["FPG_C_DESCRICAO"].ToString().ToUpper() == "DINHEIRO")
                    // stb.Append(dr["FPG_C_DESCRICAO"].ToString().PadRight(39) + " " + txtValorRecebido.Text.ToString().PadLeft(9) + "\r\n ");
                    //else
                    stb.Append(dr["FPG_C_DESCRICAO"].ToString().PadRight(39) + " " + dr["FPV_N_VALOR"].ToString().PadLeft(9) + "\r\n ");
                    linhas++;
                }

                //  if (lblTroco.Text != "R$ 0,00")
                //  stb.Append("TROCO " + lblTroco.Text.Replace("R$", "").PadLeft(43, ' ') + "\r\n");

                linhas++;
                stb.Append("Vend. " + lblVendedor.Text + "\r\n");
                linhas++;
                stb.Append("************OBRIGADO E VOLTE SEMPRE!***********\r\n\r\n");

                return stb;
            }
            catch (Exception ex)
            {
                Utilitarios.SalvarLog(ex.Message, "VENDAS - MontaCupom()");
                return new StringBuilder();
            }
        }


        private void txtCodigoVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13 && !string.IsNullOrEmpty(txtCodigoVendedor.Text))
                {
                    DataTable dtVendedores = new DataTable();
                    Usuario objUsuario = new Usuario();
                    objUsuario.Status = true;
                    objUsuario.Codigo = Convert.ToInt32(txtCodigoVendedor.Text);
                    dtVendedores = objUsuario.Listar(objUsuario);

                    if (dtVendedores.Rows.Count > 0)
                    {
                        lblVendedor.Text = dtVendedores.Rows[0]["Nome"].ToString();
                        ddlFormaPagto.Focus();
                    }
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
                Utilitarios.SalvarLog(ex.Message, "TROCA - txtCodigoVendedor_KeyDown");
            }
        }

        private void ddlFormaPagto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlFormaPagto.SelectedValue != null)
                {
                    if (ddlFormaPagto.SelectedValue != "1")//dinheiro
                    {
                        // txtValorRecebido.Text = lblValorDiferenca.Text.Replace("R$", "").Replace("-","");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "TROCA - ddlFormaPagto_SelectedIndexChanged");
            }
        }

        private void txtCodigoTroca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtCodigoTroca.Text))
                    {

                        Produto objProduto = new Produto();
                        DataTable dtProduto = new DataTable();
                        objProduto.CodigoProduto = txtCodigoTroca.Text;
                        dtProduto = objProduto.ListarProdutoTrocaCombo(objProduto);
                        dtProduto.Rows.Add(0, "0", "nome", "descr", "tam", "ref", "cor", 0, "marca", 0, "categoria", 1, "Selecione...", 0, 0);

                        DataView dv = dtProduto.DefaultView;
                        dv.Sort = "pro_n_codigo";
                        dtProduto = dv.ToTable();

                        ddlProdutoTroca.DisplayMember = "produto";
                        ddlProdutoTroca.ValueMember = "pro_n_codigo";

                        if (dtProduto.Rows.Count > 1)
                        {
                            ddlProdutoTroca.DataSource = dtProduto;

                            if (dtProduto.Rows.Count == 2)
                                ddlProdutoTroca.SelectedValue = dtProduto.Rows[1]["pro_n_codigo"].ToString();
                            else//Se tiver mais de 1 produto, abre combo para seleção
                                ddlProdutoTroca.DroppedDown = true;
                        }
                        else
                        {
                            MessageBox.Show("Produto não encontrado!");
                            txtCodigoTroca.Text = string.Empty;
                            txtCodigoTroca.Focus();
                            ddlProdutoTroca.SelectedValue = 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                    Utilitarios.SalvarLog(ex.Message, "TROCA - txtCodigoTroca_KeyDown");
                }
            }
        }

        private void ddlProdutoTroca_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlProdutoTroca.SelectedValue != null)
                {
                    if (Convert.ToInt32(ddlProdutoTroca.SelectedValue) > 0)
                    {
                        Produto objProduto = new Produto();
                        DataTable dtProduto = new DataTable();
                        objProduto.Codigo = Convert.ToInt32(ddlProdutoTroca.SelectedValue);
                        dtProduto = objProduto.Listar(objProduto);

                        dtTroca.Rows.Add(dtTroca.Rows.Count + 1,
                                         dtProduto.Rows[0]["PRO_N_CODIGO"].ToString(),
                                         dtProduto.Rows[0]["Código"].ToString(),
                                         dtProduto.Rows[0]["Nome"].ToString(),
                                         dtProduto.Rows[0]["Tamanho"].ToString(),
                                         dtProduto.Rows[0]["Cor"].ToString(),
                                         dtProduto.Rows[0]["Marca"].ToString(),
                                         Convert.ToDecimal(dtProduto.Rows[0]["Valor Venda"])
                                         );

                        rgvProdutosTroca.DataSource = dtTroca;

                        rgvProdutosTroca.Columns["ValorVenda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                        rgvProdutosTroca.Columns["ValorVenda"].DefaultCellStyle.Format = "C2";

                        rgvProdutosTroca.Columns["CodigoProduto"].Visible = false;
                        rgvProdutosTroca.Columns["Codigo"].Visible = false;

                        //formatar grid
                        DataGridViewCellStyle estiloCelulaHeader = new DataGridViewCellStyle();
                        estiloCelulaHeader.Font = new System.Drawing.Font("Arial", 10);
                        estiloCelulaHeader.ForeColor = Color.DarkBlue;
                        this.rgvProdutosTroca.ColumnHeadersDefaultCellStyle = estiloCelulaHeader;
                        this.rgvProdutosTroca.DefaultCellStyle = estiloCelulaHeader;

                        DataGridViewCellStyle estiloCelula = new DataGridViewCellStyle();
                        estiloCelula.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                        estiloCelula.ForeColor = Color.DarkBlue;
                        estiloCelula.BackColor = Color.White;
                        this.rgvProdutosTroca.RowsDefaultCellStyle = estiloCelula;

                        foreach (DataRow dr in dtTroca.Rows)
                        {
                            decValorTotalTroca += Convert.ToDecimal(dr["ValorVenda"]);
                        }

                        lblTotalTroca.Text = decValorTotalTroca.ToString("C");
                        txtCodigoTroca.Text = string.Empty;
                        
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "TROCA - ddlProdutoTroca_SelectedIndexChanged");
            }
        }

        private void rgvProdutosTroca_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 0)//excluir item da troca
                    {
                        DataRow[] dr = dtTroca.Select("Codigo = " + senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString());

                        if (dr.Length > 0)
                        {
                            decValorTotalTroca -= Convert.ToDecimal(dr[0]["ValorVenda"]);
                            dtTroca.Rows.Remove(dr[0]);
                        }
                           
                        lblTotalTroca.Text = decValorTotalTroca.ToString("C");
                        rgvProdutosTroca.DataSource = dtTroca;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "TROCA - rgvProdutosTroca_CellContentClick");
            }
        }

        private void txtCodigoVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtCodigoVenda.Text))
                    {

                        Produto objProduto = new Produto();
                        DataTable dtProduto = new DataTable();
                        objProduto.CodigoProduto = txtCodigoTroca.Text;
                        dtProduto = objProduto.ListarProdutoCombo(objProduto);
                        dtProduto.Rows.Add(0, "0", "nome", "descr", "tam", "ref", "cor", 0, "marca", 0, "categoria", 1, "Selecione...", 0, 0);

                        DataView dv = dtProduto.DefaultView;
                        dv.Sort = "pro_n_codigo";
                        dtProduto = dv.ToTable();

                        ddlProdutoTroca.DisplayMember = "produto";
                        ddlProdutoTroca.ValueMember = "pro_n_codigo";

                        if (dtProduto.Rows.Count > 1)
                        {
                            ddlProdutoVenda.DataSource = dtProduto;

                            if (dtProduto.Rows.Count == 2)
                                ddlProdutoVenda.SelectedValue = dtProduto.Rows[1]["pro_n_codigo"].ToString();
                            else//Se tiver mais de 1 produto, abre combo para seleção
                                ddlProdutoVenda.DroppedDown = true;
                        }
                        else
                        {
                            MessageBox.Show("Produto não encontrado!");
                            txtCodigoVenda.Text = string.Empty;
                            txtCodigoVenda.Focus();
                            ddlProdutoVenda.SelectedValue = 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                    Utilitarios.SalvarLog(ex.Message, "TROCA - txtCodigoVenda_KeyDown");
                }
            }
        }

        private void ddlProdutoVenda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlProdutoVenda.SelectedValue != null)
                {
                    if (Convert.ToInt32(ddlProdutoVenda.SelectedValue) > 0)
                    {
                        Produto objProduto = new Produto();
                        DataTable dtProduto = new DataTable();
                        objProduto.Codigo = Convert.ToInt32(ddlProdutoVenda.SelectedValue);
                        dtProduto = objProduto.Listar(objProduto);

                        dtVenda.Rows.Add(dtTroca.Rows.Count + 1,
                                         dtProduto.Rows[0]["PRO_N_CODIGO"].ToString(),
                                         dtProduto.Rows[0]["Código"].ToString(),
                                         dtProduto.Rows[0]["Nome"].ToString(),
                                         dtProduto.Rows[0]["Tamanho"].ToString(),
                                         dtProduto.Rows[0]["Cor"].ToString(),
                                         dtProduto.Rows[0]["Marca"].ToString(),
                                         Convert.ToDecimal(dtProduto.Rows[0]["Valor Venda"])
                                         );

                        rgvProdutosNovaVenda.DataSource = dtTroca;

                        rgvProdutosNovaVenda.Columns["ValorVenda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                        rgvProdutosNovaVenda.Columns["ValorVenda"].DefaultCellStyle.Format = "C2";

                        rgvProdutosNovaVenda.Columns["CodigoProduto"].Visible = false;
                        rgvProdutosNovaVenda.Columns["Codigo"].Visible = false;

                        //formatar grid
                        DataGridViewCellStyle estiloCelulaHeader = new DataGridViewCellStyle();
                        estiloCelulaHeader.Font = new System.Drawing.Font("Arial", 10);
                        estiloCelulaHeader.ForeColor = Color.DarkBlue;
                        this.rgvProdutosNovaVenda.ColumnHeadersDefaultCellStyle = estiloCelulaHeader;
                        this.rgvProdutosNovaVenda.DefaultCellStyle = estiloCelulaHeader;

                        DataGridViewCellStyle estiloCelula = new DataGridViewCellStyle();
                        estiloCelula.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                        estiloCelula.ForeColor = Color.DarkBlue;
                        estiloCelula.BackColor = Color.White;
                        this.rgvProdutosNovaVenda.RowsDefaultCellStyle = estiloCelula;

                        foreach (DataRow dr in dtVenda.Rows)
                        {
                            decValorTotalVenda += Convert.ToDecimal(dr["ValorVenda"]);
                        }

                        lblTotalVenda.Text = decValorTotalVenda.ToString("C");
                        txtCodigoVenda.Text = string.Empty;

                        decTotalDiferenca = decValorTotalTroca - decValorTotalVenda;

                        if (decTotalDiferenca < 0)
                            lblTotalPagar.Text = (decTotalDiferenca * (-1)).ToString("C");
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "TROCA - ddlProdutoVenda_SelectedIndexChanged");
            }
        }
    }
}
