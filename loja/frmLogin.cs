using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bematech;
using Bematech.Texto;
using System.Configuration;

namespace loja
{
    

    public partial class frmLogin : Form
    {
        public  string strCodigoVendedor = "";
        public bool LoginAdm = false;

        public frmLogin()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
           
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtLogin.Text) && !string.IsNullOrEmpty(txtSenha.Text))
                {
                    Usuario objUsuario = new Usuario();
                    objUsuario.Login = txtLogin.Text;
                    objUsuario.Senha = txtSenha.Text;

                    DataTable dtusuario = new DataTable();
                    dtusuario = objUsuario.ObterLogin(objUsuario);

                    if (dtusuario.Rows.Count > 0)
                    {
                        Utilitarios.intCodigoVendedor = Convert.ToInt32(dtusuario.Rows[0]["usu_n_codigo"]);
                        Utilitarios.strVendedor = dtusuario.Rows[0]["usu_c_nome"].ToString();
                        Utilitarios.strPerfil = dtusuario.Rows[0]["usu_c_perfil"].ToString();

                        if(Utilitarios.strPerfil == "ADMINISTRADOR")
                        {
                            if(!LoginAdm)
                            {
                                DataTable dtLoja = new DataTable();
                                Loja objLoja = new Loja();
                                dtLoja = objLoja.ListarPorEmpresa();

                                if (dtLoja.Rows.Count > 1)
                                {
                                    pnlLogin.Visible = false;
                                    pnlLoja.Visible = true;
                                    ddlLoja.DataSource = dtLoja;
                                    ddlLoja.DisplayMember = "LOJ_C_COMPLEMENTO";
                                    ddlLoja.ValueMember = "LOJ_N_CODIGO";
                                    LoginAdm = true;
                                    return;
                                }
                            }
                            else
                            {
                                Utilitarios.intCodigoLoja = Convert.ToInt32(ddlLoja.SelectedValue);

                                DataTable dtLoja = new DataTable();
                                Loja objLoja = new Loja();
                                dtLoja = objLoja.Listar();

                                if (dtLoja.Rows.Count > 0)
                                {
                                    Utilitarios.ModeloImpressora = Convert.ToInt32(dtLoja.Rows[0]["loj_n_modelo_impressora"]);
                                }
                            }
                            
                        }

                        this.Close();
                        //if (Utilitarios.strPerfil == "VENDEDOR")
                        //{
                            //verifica se o vendedor já abriu o caixa hoje
                            DataTable dtCaixa = new DataTable();
                            Caixa objCaixa = new Caixa();
                            objCaixa.Data = DateTime.Now;
                            //objCaixa.CodigoUsuario = Utilitarios.intCodigoVendedor;
                            objCaixa.CodigoLoja = Convert.ToInt32(ConfigurationManager.AppSettings["CodigoLoja"]);
                            dtCaixa = objCaixa.Listar(objCaixa);

                            bool blnAbriu = false;
                            bool blnFechou = false;

                            foreach(DataRow dr in dtCaixa.Rows)
                            {
                                if (dr["Tipo"].ToString().ToUpper() == "ABERTURA")
                                    blnAbriu = true;

                                if (dr["Tipo"].ToString().ToUpper() == "FECHAMENTO")
                                    blnFechou = true;
                            }

                            if(!blnAbriu && !blnFechou)//nem abriu e nem fechou o caixa
                            {
                                MDIParent1 formteste = new MDIParent1();
                                formteste.Show();
                                Utilitarios.blnAberturaCaixa = false;

                                if (Utilitarios.strPerfil == "VENDEDOR")
                                {
                                    frmFechamentoDia formCaixa = new frmFechamentoDia();
                                    formCaixa.MdiParent = formteste;
                                    formCaixa.Show();
                                }
                               
                            }
                            else if (blnAbriu && blnFechou)//já abriu e já fechou, só pode fazer isso 1 vez ao dia
                            {
                                if (Utilitarios.strPerfil == "VENDEDOR")
                                {
                                    Utilitarios.blnAberturaCaixa = blnAbriu;
                                    MessageBox.Show("Você já abriu e já fechou o caixa hoje, essa operação só pode ser realizada 1 vez ao dia!");
                                    Application.Exit();
                                }
                                else
                                {
                                    Utilitarios.blnAberturaCaixa = blnAbriu;
                                    MDIParent1 formteste = new MDIParent1();
                                    formteste.Show();
                                }
                               //this.Close();
                               // AboutBox1 frm = new AboutBox1();
                              //  frm.Close();
                               
                            }
                            else//ou abriu, ou fechou.
                            {
                                Utilitarios.blnAberturaCaixa = blnAbriu;

                                MDIParent1 formteste = new MDIParent1();
                                formteste.Show();
                            }
                        //}
                        //else
                        //{

                        //    MDIParent1 formteste = new MDIParent1();
                        //    formteste.Show();
                        //}
                        

                       // Form1 frmCategoria = new Form1();
                       // frmCategoria.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuário não encontrado!");
                        txtLogin.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("digite o usuário e a senha!");
                    txtLogin.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                this.Close();
                Utilitarios.SalvarLog(ex.Message + ex.StackTrace, "LOGIN");
            }
        }

        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!string.IsNullOrEmpty(txtLogin.Text))
                    txtSenha.Focus();
                else
                {
                    MessageBox.Show("Digite seu login!");
                    txtLogin.Focus();
                }
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!string.IsNullOrEmpty(txtSenha.Text))
                    btnEntrar.PerformClick();
                else
                {
                    MessageBox.Show("Digite seu login!");
                    txtLogin.Focus();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
