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
    
    public partial class frmEstatistica : Form
    {
        public int CodigoVendedor = 0;
        public int intAno = 0;

        public frmEstatistica()
        {
            InitializeComponent();

            //se for um vendedor, ele só pode ver as vendas dele
            if (Utilitarios.strPerfil == "VENDEDOR")
            {
                pnlTotais.Visible = false;
                pnlVendedor.Visible = true;
            }
            else
            {
                pnlVendedor.Visible = false;
                // this.CarregarDados();
                this.PopularAnos();
            }
        }

        public void PopularAnos()
        {
            try
            {
                Estoque objEstoque = new Estoque();
                DataTable dtAnos = new DataTable();

                rgvAno.Visible = true;
                dtAnos = objEstoque.ListarTotaisVendaAnosEstoque();

                rgvAno.DataSource = dtAnos;
                rgvAno.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                rgvAno.Columns["TOTAL"].DefaultCellStyle.Format = "C2";
                rgvAno.Columns["TOTAL"].Width = 150;

                //formatar grid
                DataGridViewCellStyle estiloCelulaHeader = new DataGridViewCellStyle();
                estiloCelulaHeader.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                estiloCelulaHeader.ForeColor = Color.DarkBlue;
                this.rgvAno.ColumnHeadersDefaultCellStyle = estiloCelulaHeader;
                this.rgvAno.DefaultCellStyle = estiloCelulaHeader;

                DataGridViewCellStyle estiloCelula = new DataGridViewCellStyle();
                estiloCelula.Font = new System.Drawing.Font("Arial", 10);
                estiloCelula.ForeColor = Color.Black;
                estiloCelula.BackColor = Color.White;
                this.rgvAno.RowsDefaultCellStyle = estiloCelula;

                DataGridViewCellStyle estiloCelulaAlternada = new DataGridViewCellStyle();
                estiloCelulaAlternada.BackColor = Color.Gainsboro;
                this.rgvAno.AlternatingRowsDefaultCellStyle = estiloCelulaAlternada;


                decimal decTotal = 0;
                foreach (DataRow dr in dtAnos.Rows)
                {
                    decTotal += Convert.ToDecimal(dr["TOTAL"]);
                }

                lblTotal.Text = decTotal.ToString("C");
                lblTitulo.Text = "Listagem de vendas";
               
                //FormatarGrid(rgvAno);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "ESTATISTICA - PopularAnos()");
            }
        }

        public void FormatarGrid(DataGridView sender)
        {
            //formatar grid
            DataGridViewCellStyle estiloCelulaHeader = new DataGridViewCellStyle();
            estiloCelulaHeader.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            estiloCelulaHeader.ForeColor = Color.DarkBlue;
            sender.ColumnHeadersDefaultCellStyle = estiloCelulaHeader;
            sender.DefaultCellStyle = estiloCelulaHeader;

            DataGridViewCellStyle estiloCelula = new DataGridViewCellStyle();
            estiloCelula.Font = new System.Drawing.Font("Arial", 10);
            estiloCelula.ForeColor = Color.Black;
            estiloCelula.BackColor = Color.White;
            sender.RowsDefaultCellStyle = estiloCelula;

            DataGridViewCellStyle estiloCelulaAlternada = new DataGridViewCellStyle();
            estiloCelulaAlternada.BackColor = Color.Gainsboro;
            sender.AlternatingRowsDefaultCellStyle = estiloCelulaAlternada;
        }

        public void CarregarDados()
        {
            try
            {
                Venda objVenda = new Venda();

                if (!string.IsNullOrEmpty(txtLogin.Text) && !string.IsNullOrEmpty(txtSenha.Text))
                {
                    Usuario objUsuario = new Usuario();
                    objUsuario.Login = txtLogin.Text;
                    objUsuario.Senha = txtSenha.Text;

                    DataTable dtusuario = new DataTable();
                    dtusuario = objUsuario.ObterLogin(objUsuario);

                    if (dtusuario.Rows.Count > 0)
                    {
                        objVenda.CodigoUsuario = Convert.ToInt32(dtusuario.Rows[0]["usu_n_codigo"]);
                        CodigoVendedor = objVenda.CodigoUsuario;
                        lblVendedor.Text = dtusuario.Rows[0]["usu_c_nome"].ToString();
                        pnlVendedor.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha incorretos!");
                        txtLogin.Text = string.Empty;
                        txtSenha.Text = string.Empty;
                        txtLogin.Focus();
                        return;
                    }
                }
                else
                {
                    lblTituloVendedor.Visible = false;
                    lblVendedor.Visible = false;
                }

                DataTable dtVendasMes = new DataTable();
                objVenda.DataInicio = Convert.ToDateTime("01/01/" + intAno);
                objVenda.DataFim = Convert.ToDateTime("31/12/" + intAno);

                dtVendasMes = objVenda.ListarVendasMes(objVenda);

                decimal decTotal = 0;

                foreach(DataRow dr in dtVendasMes.Rows)
                {
                    decTotal += Convert.ToDecimal(dr["TOTAL"]);
                }

                lblTotal.Text = decTotal.ToString("C");

                lblTitulo.Text += DateTime.Now.Year;

                rgvTotais.DataSource = dtVendasMes;
                rgvTotais.Columns["ANO"].Visible = false;
                rgvTotais.Columns["MES"].Visible = false;
                rgvTotais.Columns["TOTAL_CUSTO"].Visible = false;
                rgvTotais.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                rgvTotais.Columns["COMPRA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                rgvTotais.Columns["DINHEIRO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                rgvTotais.Columns["CARTÃO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

                rgvTotais.Columns["TOTAL"].DefaultCellStyle.Format = "C2";
                rgvTotais.Columns["DINHEIRO"].DefaultCellStyle.Format = "C2";
                rgvTotais.Columns["CARTÃO"].DefaultCellStyle.Format = "C2";
                rgvTotais.Columns["COMPRA"].DefaultCellStyle.Format = "C2";
                rgvTotais.Columns["LUCRO"].DefaultCellStyle.Format = "C2";

                if (!string.IsNullOrEmpty(lblVendedor.Text))
                {
                    rgvTotais.Columns["LUCRO"].Visible = false;
                    rgvTotais.Columns["vendaVendedor"].Visible = false;
                }  
                else
                    rgvTotais.Columns["LUCRO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
               
                //formatar grid
                DataGridViewCellStyle estiloCelulaHeader = new DataGridViewCellStyle();
                estiloCelulaHeader.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                estiloCelulaHeader.ForeColor = Color.DarkBlue;
                this.rgvTotais.ColumnHeadersDefaultCellStyle = estiloCelulaHeader;
                this.rgvTotais.DefaultCellStyle = estiloCelulaHeader;

                DataGridViewCellStyle estiloCelula = new DataGridViewCellStyle();
                estiloCelula.Font = new System.Drawing.Font("Arial", 10);
                estiloCelula.ForeColor = Color.Black;
                estiloCelula.BackColor = Color.White;
                this.rgvTotais.RowsDefaultCellStyle = estiloCelula;

                DataGridViewCellStyle estiloCelulaAlternada = new DataGridViewCellStyle();
                estiloCelulaAlternada.BackColor = Color.Gainsboro;
                this.rgvTotais.AlternatingRowsDefaultCellStyle = estiloCelulaAlternada;

                pnlTotais.Visible = true;
                rgvTotais.Visible = true;
                rgvAno.Visible = false;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "Estatisticas - CarregarDados()");
            }
        }

        private void rgvTotais_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               //ao clicar na lupa mostrar detalhes das vendas do mes (total de vendas diárias)
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 0)//visualizar total vendido em cada dia do mes
                    {
                        DataTable dtVendasMes = new DataTable();
                        Venda objVenda = new Venda();
                        objVenda.DataInicio = Convert.ToDateTime("01/" + Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells["MES"].Value).ToString("00") + "/" +  intAno);
                        objVenda.DataFim = Convert.ToDateTime(DateTime.DaysInMonth(intAno, objVenda.DataInicio.Month) + "/" + objVenda.DataInicio.Month + "/" + objVenda.DataInicio.Year);

                        if (CodigoVendedor > 0)
                            objVenda.CodigoUsuario = CodigoVendedor;

                        dtVendasMes = objVenda.ListarVendasdoMes(objVenda);

                        if (dtVendasMes.Rows.Count > 0)
                            lblTitulo.Text = "Listagem de vendas referente ao ano " + intAno + " - " + dtVendasMes.Rows[0]["MÊS"].ToString();

                        lblTotal.Text = Convert.ToDecimal(dtVendasMes.Rows[dtVendasMes.Rows.Count -1]["TOTAL"]).ToString("C");

                        rgvTotais.Visible = false;
                        rgvTotalMes.Visible = true;
                        rgvVendedor.Visible = false;
                        rgvTotalMes.DataSource = dtVendasMes;

                        rgvTotalMes.Columns["ANO"].Visible = false;
                        rgvTotalMes.Columns["MES"].Visible = false;
                        rgvTotalMes.Columns["MÊS"].Visible = false;
                        rgvTotalMes.Columns["TOTAL_CUSTO"].Visible = false;
                        rgvTotalMes.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                        rgvTotalMes.Columns["LUCRO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                        rgvTotalMes.Columns["COMPRA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                        rgvTotalMes.Columns["DINHEIRO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                        rgvTotalMes.Columns["CARTÃO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

                        rgvTotalMes.Columns["TOTAL"].DefaultCellStyle.Format = "C2";
                        rgvTotalMes.Columns["LUCRO"].DefaultCellStyle.Format = "C2";
                        rgvTotalMes.Columns["COMPRA"].DefaultCellStyle.Format = "C2";
                        rgvTotalMes.Columns["DINHEIRO"].DefaultCellStyle.Format = "C2";
                        rgvTotalMes.Columns["CARTÃO"].DefaultCellStyle.Format = "C2";

                        if (CodigoVendedor > 0)
                            rgvTotalMes.Columns["LUCRO"].Visible = false;

                        //formatar grid
                        DataGridViewCellStyle estiloCelulaHeader = new DataGridViewCellStyle();
                        estiloCelulaHeader.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                        estiloCelulaHeader.ForeColor = Color.DarkBlue;
                        this.rgvTotalMes.ColumnHeadersDefaultCellStyle = estiloCelulaHeader;
                        this.rgvTotalMes.DefaultCellStyle = estiloCelulaHeader;

                        DataGridViewCellStyle estiloCelula = new DataGridViewCellStyle();
                        estiloCelula.Font = new System.Drawing.Font("Arial", 10);
                        estiloCelula.ForeColor = Color.Black;
                        estiloCelula.BackColor = Color.White;
                        this.rgvTotalMes.RowsDefaultCellStyle = estiloCelula;

                        DataGridViewCellStyle estiloCelulaAlternada = new DataGridViewCellStyle();
                        estiloCelulaAlternada.BackColor = Color.Gainsboro;
                        this.rgvTotalMes.AlternatingRowsDefaultCellStyle = estiloCelulaAlternada;

                        btnVoltar.Visible = true;
                    }
                    else if(e.ColumnIndex == 1 && Utilitarios.strPerfil.ToUpper() == "ADMINISTRADOR")//adm quer ver as vendas do mes de cada vendedor 
                    {
                        DataTable dtVendasVendedor = new DataTable();

                        Venda objVenda = new Venda();
                        objVenda.DataInicio = Convert.ToDateTime("01/" + Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells["MES"].Value).ToString("00") + "/" + intAno);
                        objVenda.DataFim = Convert.ToDateTime(DateTime.DaysInMonth(intAno, objVenda.DataInicio.Month) + "/" + objVenda.DataInicio.Month + "/" + objVenda.DataInicio.Year);
                        dtVendasVendedor = objVenda.ListarVendaPorMesVendedor(objVenda);

                        decimal decTotal = 0;
                        foreach(DataRow dr in dtVendasVendedor.Rows)
                        {
                            decTotal += Convert.ToDecimal(dr["TOTAL"]);
                        }

                        //criar grid e popular ele
                        rgvTotais.Visible = false;
                        rgvTotalMes.Visible = false;
                        rgvVendedor.Visible = true;
                        rgvVendedor.DataSource = dtVendasVendedor;
                        btnVoltar.Visible = true;

                        //formatar grid
                        DataGridViewCellStyle estiloCelulaHeader = new DataGridViewCellStyle();
                        estiloCelulaHeader.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                        estiloCelulaHeader.ForeColor = Color.DarkBlue;
                        this.rgvVendedor.ColumnHeadersDefaultCellStyle = estiloCelulaHeader;
                        this.rgvVendedor.DefaultCellStyle = estiloCelulaHeader;

                        DataGridViewCellStyle estiloCelula = new DataGridViewCellStyle();
                        estiloCelula.Font = new System.Drawing.Font("Arial", 10);
                        estiloCelula.ForeColor = Color.Black;
                        estiloCelula.BackColor = Color.White;
                        this.rgvVendedor.RowsDefaultCellStyle = estiloCelula;

                        DataGridViewCellStyle estiloCelulaAlternada = new DataGridViewCellStyle();
                        estiloCelulaAlternada.BackColor = Color.Gainsboro;
                        this.rgvVendedor.AlternatingRowsDefaultCellStyle = estiloCelulaAlternada;

                        rgvVendedor.Columns["VENDEDOR"].Width = 300;
                        rgvVendedor.Columns["ANO"].Visible = false;
                        rgvVendedor.Columns["MES"].Visible = false;
                        rgvVendedor.Columns["MÊS"].Visible = false;
                        rgvVendedor.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                        rgvVendedor.Columns["TOTAL"].DefaultCellStyle.Format = "C2";

                        lblTitulo.Text = "Listagem de vendas referente ao ano " + intAno + " - " + senderGrid.Rows[e.RowIndex].Cells["MÊS"].Value.ToString();
                        lblTotal.Text = decTotal.ToString("C");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "Estatisticas - rgvTotais_CellContentClick");
            }
        }

        private void rgvTotalMes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //ao clicar na lupa mostrar detalhes das vendas do dia
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 0)//visualizar total vendido no dia
                    {
                        Venda objVenda = new Venda();
                        objVenda.DataInicio = Convert.ToDateTime(Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells["DIA"].Value).ToString("00") + "/" + Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells["MES"].Value).ToString("00") + "/" + intAno);
                        objVenda.DataFim = objVenda.DataInicio;

                        if (CodigoVendedor > 0)
                            objVenda.CodigoUsuario = CodigoVendedor;

                        DataSet dtsVendas = new DataSet();
                        dtsVendas = objVenda.ListarVendaDiaria(objVenda);

                        rgvVenda.DataSource = dtsVendas.Tables[2];

                        decimal decTotal = 0;

                        foreach (DataRow dr in dtsVendas.Tables[2].Rows)
                        {
                            decTotal += Convert.ToDecimal(dr["Total Venda"]);
                        }

                        lblTotal.Text = decTotal.ToString("C");

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
                        this.rgvTotalMes.ColumnHeadersDefaultCellStyle = estiloCelulaHeader;
                        this.rgvVenda.DefaultCellStyle = estiloCelulaHeader;

                        DataGridViewCellStyle estiloCelula = new DataGridViewCellStyle();
                        estiloCelula.Font = new System.Drawing.Font("Arial", 10);
                        estiloCelula.ForeColor = Color.Black;
                        estiloCelula.BackColor = Color.White;
                        this.rgvVenda.RowsDefaultCellStyle = estiloCelula;

                        DataGridViewCellStyle estiloCelulaAlternada = new DataGridViewCellStyle();
                        estiloCelulaAlternada.BackColor = Color.Gainsboro;
                        this.rgvVenda.AlternatingRowsDefaultCellStyle = estiloCelulaAlternada;

                        rgvTotais.Visible = false;
                        rgvTotalMes.Visible = false;
                        rgvVenda.Visible = true;
                        rgvVendedor.Visible = false;
                        btnVoltar.Visible = true;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "Estatisticas - rgvTotalMes_CellContentClick");
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Utilitarios.strPerfil == "VENDEDOR" && (string.IsNullOrEmpty(txtLogin.Text) || string.IsNullOrEmpty(txtSenha.Text)))
                {
                    MessageBox.Show("Informe o seu usuário e senha!");
                    txtLogin.Focus();
                }
                else
                    this.CarregarDados();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "Estatisticas - btnEntrar_Click");
            }
        }

        /// <summary>
        /// btnVoltar - retorna à listagem anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if(rgvTotalMes.Visible)
            {
                rgvTotalMes.Visible = false;
                rgvVendedor.Visible = false;
                rgvTotais.Visible = true;
                rgvAno.Visible = false;
            }
            else if(rgvVenda.Visible)
            {
                rgvVenda.Visible = false;
                rgvTotalMes.Visible = true;
                rgvTotais.Visible = false;
                rgvVendedor.Visible = false;
                lblTitulo.Text = "Listagem de vendas referente ao ano " + intAno;
                btnVoltar.Visible = true;
            }
            else if(rgvVendedor.Visible)
            {
                rgvVenda.Visible = false;
                rgvTotalMes.Visible = false;
                rgvTotais.Visible = true;
                rgvVendedor.Visible = false;
                lblTitulo.Text = "Listagem de vendas referente ao ano " + intAno;
                btnVoltar.Visible = true;
            }
            else if(rgvTotais.Visible)
            {
                rgvTotais.Visible = false;
                rgvVenda.Visible = false;
                rgvTotalMes.Visible = false;
                rgvVendedor.Visible = false; 
                rgvAno.Visible = true;
                btnVoltar.Visible = false;
                lblTitulo.Text = "Listagem de vendas ";
            }
        }

        private void pnlTotais_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmEstatistica_Load(object sender, EventArgs e)
        {

        }

        private void rgvAno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //ao clicar na lupa mostrar os meses do ano correspondente
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 0)//visualizar totais por meses
                    {
                        intAno = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells["ANO"].Value);
                        this.CarregarDados();
                        btnVoltar.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "COMPRAS - rgvAno_CellContentClick");
            }
        }

        private void pnlAno_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
