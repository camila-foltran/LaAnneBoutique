using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loja
{
    public partial class frmFechamentoDia : Form
    {
        public frmFechamentoDia()
        {
            InitializeComponent();
            this.VerificaForm();
            
        }

        private void VerificaForm()
        {
            try
            {
                lblData.Text = DateTime.Now.ToString();
                lblDataAbertura.Text = DateTime.Now.ToString();

                if (!Utilitarios.blnAberturaCaixa)
                {

                    pnlAbertura.Visible = true;
                    pnlFechamento.Visible = false;
                    txtCodigoVendedorAbertura.Focus();
                }
                else
                {
                    DataTable dtFechamento = new DataTable();

                    DataTable dtCaixa = new DataTable();
                    Caixa objCaixa = new Caixa();
                    objCaixa.Data = DateTime.Now;
                    objCaixa.CodigoLoja = Convert.ToInt32(ConfigurationManager.AppSettings["CodigoLoja"]);
                    dtCaixa = objCaixa.ListarFechamento(objCaixa);

                    if(dtCaixa.Rows.Count > 0)
                    {
                        lblValorAbertura.Text = Convert.ToDecimal(dtCaixa.Rows[0]["cai_n_troco"]).ToString("C");
                        lblValorDinheiro.Text = Convert.ToDecimal(dtCaixa.Rows[0]["total_dinheiro"]).ToString("C");
                    }

                    pnlAbertura.Visible = false;
                    pnlFechamento.Visible = true;
                    txtCodigoVendedorFechamento.Focus();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

        private void frmFechamentoDia_Load(object sender, EventArgs e)
        {

        }

        private void btnAbrirCaixa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtTroco.Text) && !string.IsNullOrEmpty(txtCodigoVendedorAbertura.Text))
                {
                    //verifica se o caixa já foi aberto, independente do vendedor
                    DataTable dtCaixa = new DataTable();
                    Caixa objCaixa = new Caixa();
                    objCaixa.Data = DateTime.Now;
                   // objCaixa.CodigoUsuario = Convert.ToInt32(txtCodigoVendedorAbertura.Text);
                    objCaixa.CodigoLoja = Convert.ToInt32(ConfigurationManager.AppSettings["CodigoLoja"]);
                    dtCaixa = objCaixa.Listar(objCaixa);

                    bool blnAbriu = false;
                    bool blnFechou = false;

                    foreach (DataRow dr in dtCaixa.Rows)
                    {
                        if (dr["cai_c_tipo"].ToString().ToUpper() == "ABERTURA")
                            blnAbriu = true;

                        if (dr["cai_c_tipo"].ToString().ToUpper() == "FECHAMENTO")
                            blnFechou = true;
                    }

                    if (!blnAbriu && !blnFechou)
                    {
                        objCaixa = new Caixa();
                        objCaixa.CodigoUsuario = Convert.ToInt32(txtCodigoVendedorAbertura.Text);
                        objCaixa.Tipo = "ABERTURA";
                        objCaixa.CodigoLoja = Convert.ToInt32(ConfigurationManager.AppSettings["CodigoLoja"]);
                        objCaixa.Troco = Convert.ToDecimal(txtTroco.Text);

                        if (!string.IsNullOrEmpty(txtObs.Text))
                            objCaixa.Obs = txtObs.Text;

                        //antes de abrir o caixa, verificar se o código do vendedor é válido
                        DataTable dtUsuario = new DataTable();
                        Usuario objUsuario = new Usuario();
                        objUsuario.Codigo = objCaixa.CodigoUsuario;
                        dtUsuario = objUsuario.Listar(objUsuario);

                        if (dtUsuario.Rows.Count > 0)
                        {

                            int intRetorno = objCaixa.Inserir(objCaixa);
                            Utilitarios.blnAberturaCaixa = true;
                            MessageBox.Show("Caixa aberto com sucesso!");

                            this.Close();

                            frmVenda formVenda = new frmVenda();
                            MDIParent1 teste = new MDIParent1();
                            formVenda.MdiParent = teste;
                            formVenda.Show();
                        }
                        else
                        {
                            MessageBox.Show("Usuário não encontrado!");
                            txtCodigoVendedorAbertura.Focus();
                        }
                    }
                    else if (blnAbriu)
                    {
                        MessageBox.Show("O caixa já foi aberto hoje!");
                        this.Close();
                    }
                }
                else
                {
                    if(string.IsNullOrEmpty(txtTroco.Text))
                        MessageBox.Show("Informe o valor do troco!");
                    else
                        MessageBox.Show("Informe o código do vendedor!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "ABERTURA DE CAIXA - VENDEDOR " + Utilitarios.intCodigoVendedor);
            }
        }

        private void btnFecharCaixa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtValorCaixa.Text) && !string.IsNullOrEmpty(txtCodigoVendedorFechamento.Text))
                {
                    //verifica se o vendedor já abriu o caixa hoje
                    DataTable dtCaixa = new DataTable();
                    Caixa objCaixa = new Caixa();
                    objCaixa.Data = DateTime.Now;
                    //objCaixa.CodigoUsuario = Convert.ToInt32(txtCodigoVendedorFechamento.Text);
                    objCaixa.CodigoLoja = Convert.ToInt32(ConfigurationManager.AppSettings["CodigoLoja"]);
                    dtCaixa = objCaixa.Listar(objCaixa);

                    bool blnAbriu = false;
                    bool blnFechou = false;

                    foreach (DataRow dr in dtCaixa.Rows)
                    {
                        if (dr["Tipo"].ToString().ToUpper() == "ABERTURA")
                            blnAbriu = true;

                        if (dr["Tipo"].ToString().ToUpper() == "FECHAMENTO")
                            blnFechou = true;
                    }

                    if (!blnFechou)//esse é o correto
                    {
                        objCaixa = new Caixa();
                        objCaixa.Data = DateTime.Now;
                       
                        objCaixa.ValorFinal = Convert.ToDecimal(txtValorCaixa.Text);
                        objCaixa.CodigoLoja = Convert.ToInt32(ConfigurationManager.AppSettings["CodigoLoja"]);

                        if (!string.IsNullOrEmpty(txtObs.Text))
                            objCaixa.Obs = txtObs.Text;

                        //verifica se o valor informado bate com o valor das vendas em dinheiro
                        dtCaixa = new DataTable();
                        dtCaixa = objCaixa.ListarFechamento(objCaixa);

                        decimal decTotalDinheiro = Convert.ToDecimal(dtCaixa.Rows[0]["cai_n_troco"]) + Convert.ToDecimal(dtCaixa.Rows[0]["total_dinheiro"]);

                        if (decTotalDinheiro > objCaixa.ValorFinal)//está sobrando dinheiro em caixa
                            objCaixa.Diferenca = objCaixa.ValorFinal - decTotalDinheiro;
                        else//está faltando
                            objCaixa.Diferenca = decTotalDinheiro - objCaixa.ValorFinal;

                        objCaixa.Tipo = "FECHAMENTO";
                        objCaixa.CodigoUsuario = Convert.ToInt32(txtCodigoVendedorFechamento.Text);

                         //antes de abrir o caixa, verificar se o código do vendedor é válido
                        DataTable dtUsuario = new DataTable();
                        Usuario objUsuario = new Usuario();
                        objUsuario.Codigo = objCaixa.CodigoUsuario;
                        dtUsuario = objUsuario.Listar(objUsuario);

                        if (dtUsuario.Rows.Count > 0)
                        {

                            int intRetorno = objCaixa.Inserir(objCaixa);

                            if (objCaixa.Diferenca != 0)
                                MessageBox.Show("Caixa fechado com diferença de " + (decTotalDinheiro - objCaixa.ValorFinal).ToString("C"));
                            else
                                MessageBox.Show("Caixa fechado com sucesso!");

                            this.Close();
                            //Application.Exit();
                        }
                        else
                        {
                            MessageBox.Show("Usuário não encontrado!");
                            txtCodigoVendedorFechamento.Focus();
                        }
                    }
                    else //o caixa já está fechado
                    {
                        MessageBox.Show("O caixa já está fechado!");
                        this.Close();
                    }
                }
                else
                {
                    if(string.IsNullOrEmpty(txtValorCaixa.Text))
                        MessageBox.Show("Informe o valor registrado no caixa!");
                    else
                        MessageBox.Show("Informe o código do vendedor!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "FECHAMENTO DE CAIXA - VENDEDOR " + Utilitarios.intCodigoVendedor);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
