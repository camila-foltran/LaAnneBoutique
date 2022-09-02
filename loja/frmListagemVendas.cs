using CIDPrinter;
using Loja;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vip.Printer;
using Vip.Printer.Enums;

namespace loja
{
    public partial class frmListagemVendas : Form
    {
        public frmListagemVendas()
        {
            InitializeComponent();

            if (Utilitarios.strPerfil == "ADMINISTRADOR")
                pnlFiltro.Visible = true;

            txtDataFim.Text = DateTime.Now.ToShortDateString();
            txtDataFimImpressao.Text = DateTime.Now.ToShortDateString();

            this.CarregarForm();
        }

        public void CarregarForm()
        {
            try
            {
                txtDataInicioImpressao.Text = DateTime.Now.Day.ToString("00") + "/" + DateTime.Now.Month.ToString("00") + "/" + DateTime.Now.Year.ToString();

                Venda objVenda = new Venda();
                if (pnlFiltro.Visible)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(txtDataInicio.Text))
                            objVenda.DataInicio = Convert.ToDateTime(txtDataInicio.Text);

                        if (!string.IsNullOrEmpty(txtDataFim.Text))
                            objVenda.DataFim = Convert.ToDateTime(txtDataFim.Text);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Erro ao processar a data de início e fim. Verifique se as datas estão no formado dd/mm/yyyy (Ex: 02/05/2016) e tente novamente.");
                        return;
                    }
                }
                else
                {
                    objVenda.DataInicio = DateTime.Now;
                    objVenda.DataFim = DateTime.Now;
                }

                lblData.Text = DateTime.Now.ToShortDateString();
                DataSet dtsVendas = new DataSet();
                dtsVendas = objVenda.ListarVendaDiaria(objVenda);

                rgvVenda.DataSource = dtsVendas.Tables[2];

                rgvVenda.Columns["itv_n_codigo"].Visible = false;
                rgvVenda.Columns["Qtde Total"].Visible = false;
                rgvVenda.Columns["TOTAL"].Visible = false;
                rgvVenda.Columns["Código Produto"].Width = 140;
                rgvVenda.Columns["Código Venda"].Width = 120;
                rgvVenda.Columns["Produto"].Width = 300;
                rgvVenda.Columns["Marca"].Width = 150;
                rgvVenda.Columns["Qtde"].Width = 50;
                rgvVenda.Columns["Valor Unit."].Width = 150;
                rgvVenda.Columns["Valor Unit."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                rgvVenda.Columns["Qtde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                rgvVenda.Columns["Desconto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                rgvVenda.Columns["Acrescimo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                rgvVenda.Columns["Total Venda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

                rgvVenda.Columns["Valor Unit."].DefaultCellStyle.Format = "C2";
                rgvVenda.Columns["Desconto"].DefaultCellStyle.Format = "C2";
                rgvVenda.Columns["Acrescimo"].DefaultCellStyle.Format = "C2";
                rgvVenda.Columns["Total Venda"].DefaultCellStyle.Format = "C2";

                //formatar grid
                DataGridViewCellStyle estiloCelulaHeader = new DataGridViewCellStyle();
                estiloCelulaHeader.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                estiloCelulaHeader.ForeColor = Color.DarkBlue;
                this.rgvVenda.ColumnHeadersDefaultCellStyle = estiloCelulaHeader;
                this.rgvVenda.DefaultCellStyle = estiloCelulaHeader;

                DataGridViewCellStyle estiloCelula = new DataGridViewCellStyle();
                estiloCelula.Font = new System.Drawing.Font("Arial", 10);
                estiloCelula.ForeColor = Color.Black;
                estiloCelula.BackColor = Color.White;
                this.rgvVenda.RowsDefaultCellStyle = estiloCelula;

                DataGridViewCellStyle estiloCelulaAlternada = new DataGridViewCellStyle();
                estiloCelulaAlternada.BackColor = Color.Gainsboro;
                this.rgvVenda.AlternatingRowsDefaultCellStyle = estiloCelulaAlternada;

                DataRow[] drQtdeTotal = dtsVendas.Tables[0].Select("MARCA = 'TOTAL'");
                int intQtdeTotal = 0;
                foreach(DataRow dr in drQtdeTotal)
                {
                    intQtdeTotal += Convert.ToInt32(dr[5]);
                }
                lblQtdeTotal.Text = intQtdeTotal.ToString("000");


                decimal decTotalDinheiro = 0;
                decimal decTotalCartao = 0;
                decimal decTotalCarne = 0;
                decimal decTotalDesconto = 0;

                Produto objProduto = new Produto();
                DataTable dtFormaPagto = new DataTable();
                dtFormaPagto = objProduto.ListarFormaPagto(objProduto);

                DataRow[] drPagto = dtFormaPagto.Select("FPG_C_DESCRICAO = 'DINHEIRO'");
                string strCodigoDinheiro = "1";
                if (drPagto.Length > 0)
                    strCodigoDinheiro = drPagto[0]["FPG_N_CODIGO"].ToString();

                string strCodigoCarne = string.Empty;
                drPagto = dtFormaPagto.Select("FPG_C_DESCRICAO = 'CARNÊ'");
                if (drPagto.Length > 0)
                    strCodigoCarne = drPagto[0]["FPG_N_CODIGO"].ToString();

                foreach (DataRow dr in dtsVendas.Tables[1].Rows)
                {
                    if (dr["fpv_fpg_n_codigo"].ToString() == strCodigoDinheiro)//pagto em dinheiro
                        decTotalDinheiro += (Convert.ToDecimal(dr["fpv_n_valor"]));
                    else if(dr["fpv_fpg_n_codigo"].ToString() == strCodigoCarne)//pagto carnê
                        decTotalCarne += (Convert.ToDecimal(dr["fpv_n_valor"]));
                    else
                        decTotalCartao += (Convert.ToDecimal(dr["fpv_n_valor"]));
                }

                foreach (DataRow dr in dtsVendas.Tables[2].Rows)
                {
                    if (dr["Desconto"] != DBNull.Value)
                        decTotalDesconto += Convert.ToDecimal(dr["Desconto"]);
                }

                for(int i=0; i< dtsVendas.Tables[2].Rows.Count; i++)
                {
                    DataRow[] dr = dtsVendas.Tables[2].Select("[Código Venda] = " + dtsVendas.Tables[2].Rows[i]["Código Venda"].ToString());

                    if(dr.Length > 0)
                    {
                        //deixar em destaque somente a linha do total
                        for(int j=i; j< i+(dr.Length); j++)
                        {
                            if(rgvVenda.Rows[j].Cells["Marca"].Value.ToString() == "TOTAL")
                            {
                                DataGridViewCellStyle estiloCelulaTotal = new DataGridViewCellStyle();
                                //estiloCelulaHeader.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                                estiloCelulaTotal.BackColor = Color.Yellow;
                                this.rgvVenda.Rows[j].DefaultCellStyle = estiloCelulaTotal;
                                i = j;
                                break;
                            }
                        }
                    }
                    
                }

                lblTotalDinheiro.Text = decTotalDinheiro.ToString("C");
                lblTotalCartao.Text = decTotalCartao.ToString("C");
                lblTotalCarne.Text = decTotalCarne.ToString("C");
                lblTotalDesconto.Text = decTotalDesconto.ToString("C");
                lblTotal.Text = (decTotalCartao + decTotalDinheiro + decTotalCarne).ToString("C");

            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "LISTAGEM DE VENDAS - CarregarForm");
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CarregarForm();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        StringBuilder stb = new StringBuilder();

        /// <summary>
        /// A impressão do total vendido pode ser de um dia, de um mes ou de um período informado.
        /// Vendedores só podem imprimir o total vendido no dia.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnImprimirVenda_Click(object sender, EventArgs e)
        {
            try
            {
                decimal decTotalVendidoDia = 0;
                Venda objVenda = new Venda();
                if (pnlFiltro.Visible)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(txtDataInicioImpressao.Text))
                            objVenda.DataInicio = Convert.ToDateTime(txtDataInicioImpressao.Text);
                        else
                            objVenda.DataInicio = DateTime.Now;

                        if (!string.IsNullOrEmpty(txtDataFimImpressao.Text))
                            objVenda.DataFim = Convert.ToDateTime(txtDataFimImpressao.Text);
                        else
                            objVenda.DataFim = DateTime.Now;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Erro ao processar a data de início e fim. Verifique se as datas estão no formado dd/mm/yyyy (Ex: 02/05/2016) e tente novamente.");
                        return;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtDataInicioImpressao.Text) && !string.IsNullOrEmpty(txtDataFimImpressao.Text))
                    {
                        try
                        {
                            objVenda.DataInicio = Convert.ToDateTime(txtDataInicioImpressao.Text);
                            objVenda.DataFim = Convert.ToDateTime(txtDataFimImpressao.Text);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Erro ao processar a data de início e fim. Verifique se as datas estão no formado dd/mm/yyyy (Ex: 02/05/2016) e tente novamente.");
                            return;
                        }
                       
                    }
                     else
                    {
                        objVenda.DataInicio = DateTime.Now;
                        objVenda.DataFim = DateTime.Now;
                    }
                }

                DataSet dtVendas = new DataSet();
                dtVendas = objVenda.ListarPeriodo(objVenda);

                //buscar endereço da loja
                DataTable dtLoja = new DataTable();
                Loja objLoja = new Loja();
                dtLoja = objLoja.Listar();

                //declaração de variaveis para receber os parâmetros da formatação do texto, conforme as seleções no FORM
                int item = 1;
                int linhas = 8;
                int tLetra = 2;
                int italico = 0;
                int sublinhado = 0;
                int expandido = 0;
                int enfatizado = 0;

                int iRetorno = 0;

                //stb.Append(dtLoja.Rows[0]["loj_c_nome"].ToString() + "\r\n");
                stb.Append("   " + dtLoja.Rows[0]["loj_c_endereco"].ToString() + "\r\n");
                stb.Append("   CNPJ: " + dtLoja.Rows[0]["loj_c_cnpj"].ToString() + "\r\n");
                stb.Append("   IE: " + dtLoja.Rows[0]["loj_c_ie"].ToString() + "\r\n");
                stb.Append("-----------------------------------------------\r\n");

                if (Utilitarios.ModeloImpressora == 5)
                    iRetorno = MP2032.ComandoTX("\x1B\x61\x0", 3);
                else if(Utilitarios.ModeloImpressora == 8 || Utilitarios.ModeloImpressora == 7)
                    iRetorno = MP2064.ComandoTX("\x1B\x61\x0", 3);

                stb.Append("   Total de vendas realizadas\r\n");
                stb.Append("   De: " + objVenda.DataInicio.ToShortDateString() + " a " + objVenda.DataFim.ToShortDateString() + "\r\n");

                foreach(DataRow dr in dtVendas.Tables[0].Rows)
                {
                    decTotalVendidoDia += Convert.ToDecimal(dr["TOTAL_VENDA"]);
                    stb.Append("   " + Convert.ToInt32(dr["DIA"]).ToString("00") + "/" + Convert.ToInt32(dr["MES"]).ToString("00") + "/" + Convert.ToInt32(dr["ANO"]).ToString("0000") + " - " + Convert.ToDecimal(dr["TOTAL_VENDA"]).ToString("C").PadLeft(11,' ') + "\r\n");
                }

                //separar vendas em dinheiro das vendas no cartão
                decimal decTotalDinheiro = 0;
                decimal decTotalCartao = 0;
                decimal decTotalCarne = 0;

                Produto objProduto = new Produto();
                DataTable dtFormaPagto = new DataTable();
                dtFormaPagto = objProduto.ListarFormaPagto(objProduto);

                DataRow[] drPagto = dtFormaPagto.Select("FPG_C_DESCRICAO = 'DINHEIRO'");
                string strCodigoDinheiro = "1";

                if (drPagto.Length > 0)
                    strCodigoDinheiro = drPagto[0]["FPG_N_CODIGO"].ToString();

                string strCodigoCarne = string.Empty;
                drPagto = dtFormaPagto.Select("FPG_C_DESCRICAO = 'CARNÊ'");
                if (drPagto.Length > 0)
                    strCodigoCarne = drPagto[0]["FPG_N_CODIGO"].ToString();

                foreach (DataRow dr in dtVendas.Tables[2].Rows)
                {
                    if (dr["fpv_fpg_n_codigo"].ToString() == strCodigoDinheiro)//pagto em dinheiro
                        decTotalDinheiro += (Convert.ToDecimal(dr["fpv_n_valor"]));
                    else if(dr["fpv_fpg_n_codigo"].ToString() == strCodigoCarne)//pagto em carne
                        decTotalCarne += (Convert.ToDecimal(dr["fpv_n_valor"]));
                    else
                        decTotalCartao += (Convert.ToDecimal(dr["fpv_n_valor"]));
                }

                stb.Append("   TOTAL DINHEIRO: " + decTotalDinheiro.ToString("C").PadLeft(8, ' ') + "\r\n");
                stb.Append("   TOTAL CARTÃO: " + decTotalCartao.ToString("C").PadLeft(10, ' ') + "\r\n");
                stb.Append("   TOTAL CARNÊ: " + decTotalCarne.ToString("C").PadLeft(11, ' ') + "\r\n");
                stb.Append("   TOTAL: " + decTotalVendidoDia.ToString("C").PadLeft(17, ' ') + "\r\n");

                stb.Append("   Data de impressão: " + DateTime.Now + "\r\n");
                stb.Append("   ASSINATURA DO VENDEDOR(A):\r\n\r\n________________________________________ \r\n\r\n\r\n\r\n\r\n\r\n");

               
                //salvar em uma tabela os cupoms de vendas entregue ao shopping
                Comprovante objComprovante = new Comprovante();
                objComprovante.TextoComprovante = stb.ToString();
                objComprovante.Status = "IMPRIMIR SEMANAL";
                int intId = objComprovante.Inserir(objComprovante);

                if (Utilitarios.ModeloImpressora == 5)
                {
                    iRetorno = MP2032.ConfiguraModeloImpressora(Utilitarios.ModeloImpressora);
                    iRetorno = MP2032.IniciaPorta(Utilitarios.PortaImpressora);//inicia a porta com o valor da combo (exceto ethernet)
                    iRetorno = MP2032.FormataTX(stb.ToString(), tLetra, italico, sublinhado, expandido, enfatizado);//ao ser clicado, imprime o texto da Text Box
                    iRetorno = MP2032.AcionaGuilhotina(0);
                    iRetorno = MP2032.FechaPorta();
                }
                else if (Utilitarios.ModeloImpressora == 8 || Utilitarios.ModeloImpressora == 7)
                {
                    iRetorno = MP2064.ConfiguraModeloImpressora(Utilitarios.ModeloImpressora);
                    iRetorno = MP2064.IniciaPorta(Utilitarios.PortaImpressora);//inicia a porta com o valor da combo (exceto ethernet)
                    iRetorno = MP2064.FormataTX(stb.ToString(), tLetra, italico, sublinhado, expandido, enfatizado);//ao ser clicado, imprime o texto da Text Box
                    iRetorno = MP2064.AcionaGuilhotina(0);
                    iRetorno = MP2064.FechaPorta();
                }
                else if (Utilitarios.ModeloImpressora == 10 || Utilitarios.ModeloImpressora == 11)//Elgin i9 ou nova rotina para Bematech
                {
                    var printer = new Printer(Utilitarios.strNomeImpressora, PrinterType.Epson);

                    if (Utilitarios.ModeloImpressora == 11)
                        printer = new Printer(Utilitarios.strNomeImpressora, PrinterType.Bematech);

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
                    cidPrinter.ImprimirFormatado("    " + dtLoja.Rows[0]["loj_c_nome"].ToString().ToUpper() + "\n", false, false, true, true, false);
                    cidPrinter.ImprimirFormatado(stb.ToString() + "\n", false, false, false, false);
                    cidPrinter.AtivarGuilhotina(TipoCorte.TOTAL);
                }
                else
                {
                    using (var printDocument = new System.Drawing.Printing.PrintDocument())
                    {
                        printDocument.PrintPage += printDocument_PrintPage;

                        string strWidth = printDocument.DefaultPageSettings.PrintableArea.Width.ToString();
                        string strHeight = printDocument.DefaultPageSettings.PrintableArea.Height.ToString();

                        printDocument.PrinterSettings.PrinterName = "Elgin";
                        printDocument.Print();
                    }
                }

                MessageBox.Show("Comprovante impresso com sucesso!");

                txtDataInicioImpressao.Text = string.Empty;
                txtDataFimImpressao.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao imprimir comprovante.");
                Utilitarios.SalvarLog(ex.Message, "Listagem Vendas - btnImprimirVenda_Click");
            }
        }

        void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var printDocument = sender as System.Drawing.Printing.PrintDocument;

            if (printDocument != null)
            {
                using (var font = new Font("Courier New", 14))
                using (var brush = new SolidBrush(Color.Black))
                {
                    e.Graphics.DrawString(
                       stb.ToString(),
                        font,
                        brush,
                        new RectangleF(0, 0, printDocument.DefaultPageSettings.PrintableArea.Width, printDocument.DefaultPageSettings.PrintableArea.Height));
                }
            }
        }

        private void rgvVenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (e.RowIndex >= 0)
                {
                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&  e.ColumnIndex == 0 )//imprimir comprovante
                    {
                        this.ImprimirCupom(Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells["Código Venda"].Value));
                    }
                }
            }
            catch(Exception ex)
            {
                Utilitarios.SalvarLog(ex.Message, "Listagem Vendas - rgvVenda_CellContentClick");
            }
        }
       
        private void ImprimirCupom(int pintCodigoVenda)
        {
            try
            {
                Comprovante objCupom = new Comprovante();
                DataTable dtCupom = new DataTable();
                objCupom.CodigoVenda = pintCodigoVenda;
                dtCupom = objCupom.Listar(objCupom);

                if (dtCupom.Rows.Count > 0)
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

                    if(Utilitarios.ModeloImpressora == 5)
                    {
                        iRetorno = MP2032.ConfiguraModeloImpressora(Utilitarios.ModeloImpressora);
                        iRetorno = MP2032.Le_Status();
                    }
                    else if(Utilitarios.ModeloImpressora == 8 || Utilitarios.ModeloImpressora == 7)
                    {
                        iRetorno = MP2064.ConfiguraModeloImpressora(Utilitarios.ModeloImpressora);
                        iRetorno = MP2064.Le_Status();
                    }

                    if (iRetorno == 32)//sem papel
                    {
                        MessageBox.Show("A impressora está sem papel, para imprimir o comprovante coloque a bobina de papel na impressora e imprima-o na listagem de vendas. CÓDIGO DA VENDA: " + pintCodigoVenda);
                        Utilitarios.SalvarLog("Impressora sem papel: 32 ", "LISTAGEM VENDAS - ImprimirCupom(" + pintCodigoVenda + ")");
                    }
                    else if (iRetorno == 68)//Erro de comunicação/"OFFLINE"
                    {
                        MessageBox.Show("Erro de comunicação com a impressora, desligue a impressora, ligue-a novamente, execute o aplicativo 'Instalar impressoras' do menu iniciar e tente novamente. CÓDIGO DA VENDA: " + pintCodigoVenda);
                        Utilitarios.SalvarLog("Erro de comunicação com a impressora: 68 ", "LISTAGEM VENDAS - ImprimirCupom(" + pintCodigoVenda + ")");
                    }
                    else
                    {
                        if (Utilitarios.ModeloImpressora == 5)
                            iRetorno = MP2032.IniciaPorta(Utilitarios.PortaImpressora);//inicia a porta com o valor da combo (exceto ethernet)
                        else if (Utilitarios.ModeloImpressora == 8 || Utilitarios.ModeloImpressora == 7)
                            iRetorno = MP2064.IniciaPorta(Utilitarios.PortaImpressora);//inicia a porta com o valor da combo (exceto ethernet)
                        else
                            iRetorno = 1;

                        if (iRetorno <= 0)// erro
                        {
                            MessageBox.Show("Erro ao iniciar a porta da impressora, desligue a impressora, ligue-a novamente, execute o aplicativo 'Instalar impressoras' do menu iniciar e reimprima o comprovante imprima-o na listagem de vendas. CÓDIGO DA VENDA: " + pintCodigoVenda);
                            Utilitarios.SalvarLog("Erro ao iniciar porta: " + iRetorno, " LISTAGEM VENDAS - ImprimirCupom(" + pintCodigoVenda + ")");
                        }
                        else
                        {
                            if (Utilitarios.ModeloImpressora == 5)
                            {
                                iRetorno = MP2032.FormataTX(dtCupom.Rows[0]["COM_C_DESCRICAO"].ToString(), tLetra, italico, sublinhado, expandido, enfatizado);//ao ser clicado, imprime o texto da Text Box
                                iRetorno = MP2032.BematechTX("\r\n\r\n\r\n");
                                iRetorno = MP2032.AcionaGuilhotina(0);
                                iRetorno = MP2032.FechaPorta();
                            }
                            else if (Utilitarios.ModeloImpressora == 8 || Utilitarios.ModeloImpressora == 7)
                            {
                                iRetorno = MP2064.FormataTX(dtCupom.Rows[0]["COM_C_DESCRICAO"].ToString(), tLetra, italico, sublinhado, expandido, enfatizado);//ao ser clicado, imprime o texto da Text Box
                                iRetorno = MP2064.BematechTX("\r\n\r\n\r\n");
                                iRetorno = MP2064.AcionaGuilhotina(0);
                                iRetorno = MP2064.FechaPorta();
                            }
                            else if (Utilitarios.ModeloImpressora == 10 || Utilitarios.ModeloImpressora == 11)//Elgin i9 ou nova rotina para Bematech
                            {
                                //obter o nome da loja pra colocar em negrito no cupom
                                DataTable dtLoja = new DataTable();
                                Loja objLoja = new Loja();
                                dtLoja = objLoja.Listar();

                                var printer = new Printer(Utilitarios.strNomeImpressora, PrinterType.Epson);

                                if (Utilitarios.ModeloImpressora == 11)
                                    printer = new Printer(Utilitarios.strNomeImpressora, PrinterType.Bematech);

                                printer.AlignCenter();
                                printer.ExpandedMode(PrinterModeState.On);
                                printer.CondensedMode(PrinterModeState.Off);
                                printer.DoubleWidth2();
                                printer.BoldMode(PrinterModeState.On);
                                printer.WriteLine("   " + dtLoja.Rows[0]["loj_c_nome"].ToString().ToUpper());
                                printer.PrintDocument();
                                printer.Clear();

                                printer.AlignLeft();
                                printer.CondensedMode(PrinterModeState.Off);
                                printer.BoldMode(PrinterModeState.Off);
                                printer.ExpandedMode(PrinterModeState.Off);
                                printer.WriteLine(dtCupom.Rows[0]["COM_C_DESCRICAO"].ToString());
                                printer.FullPaperCut();

                                printer.PrintDocument();
                            }
                            else if (Utilitarios.ModeloImpressora == 13)
                            {
                                //obter o nome da loja pra colocar em negrito no cupom
                                DataTable dtLoja = new DataTable();
                                Loja objLoja = new Loja();
                                dtLoja = objLoja.Listar();

                                ICIDPrint cidPrinter = new CIDPrintiD();
                                cidPrinter.Iniciar();
                                cidPrinter.ImprimirFormatado("     " + dtLoja.Rows[0]["loj_c_nome"].ToString().ToUpper() + "\n", false, false, true, true, false);
                                cidPrinter.ImprimirFormatado(dtCupom.Rows[0]["COM_C_DESCRICAO"].ToString() + "\n", false, false, false, false);
                                cidPrinter.AtivarGuilhotina(TipoCorte.TOTAL);
                            }
                            else
                            {
                                stb.Append(dtCupom.Rows[0]["COM_C_DESCRICAO"].ToString());

                                using (var printDocument = new System.Drawing.Printing.PrintDocument())
                                {
                                    printDocument.PrintPage += printDocument_PrintPage;

                                    string strWidth = printDocument.DefaultPageSettings.PrintableArea.Width.ToString();
                                    string strHeight = printDocument.DefaultPageSettings.PrintableArea.Height.ToString();

                                    printDocument.PrinterSettings.PrinterName = "Elgin";
                                    printDocument.Print();
                                }
                            }

                            MessageBox.Show("Comprovante impresso com sucesso!");
                        }
                    }
                }
                else
                    MessageBox.Show("Comprovante não encontrado!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao imprimir comprovante, desligue a impressora e ligue-a novamente, execute o aplicativo 'Instalar impressoras' do menu iniciar e reimprima o comprovante imprima-o na listagem de vendas. CÓDIGO DA VENDA: " + pintCodigoVenda);
                Utilitarios.SalvarLog("Erro generico ao imprimir comprovante: " + ex.Message, "LISTAGEM VENDAS - ImprimirCupom(" + pintCodigoVenda + ")");
            }

        }

        private void rgvVenda_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            try
            {
                var senderGrid = (DataGridView)sender;
                if (senderGrid.Rows[e.RowIndex].Cells["Marca"].Value == "TOTAL")
                {
                   // senderGrid.Rows[e.RowIndex].Cells["imprimir"].Value = Image.FromFile("D:\\teste\\loja\\img\\Icone\\impressao16.png");
                }
                else
                {
                   // senderGrid.Rows[e.RowIndex].Cells["imprimir"].Value = null;
                    //senderGrid.Columns["imprimir"].Visible = false;
                }
            }
            catch(Exception ex)
            {

            }
            
        }

        private void btnImprimirVendaSemanal_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {
                Utilitarios.SalvarLog(ex.Message, "Listagem Vendas - btnImprimirVendaSemanal_Click");
            }
        }

        private void frmListagemVendas_Load(object sender, EventArgs e)
        {

        }
    }
}
