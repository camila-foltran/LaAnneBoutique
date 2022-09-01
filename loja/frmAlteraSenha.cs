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
    public partial class frmAlteraSenha : Form
    {
        public frmAlteraSenha()
        {
            InitializeComponent();
        }

        private void btnAlterarSenha_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtNovaSenha.Text == txtConfirmaSenha.Text && !string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtSenhaAtual.Text))
                {
                    Usuario objUsuario = new Usuario();
                    DataTable dtUsuario = new DataTable();
                    objUsuario.Login = txtUsuario.Text;
                    objUsuario.Senha = txtSenhaAtual.Text;

                    dtUsuario = objUsuario.ObterLogin(objUsuario);

                    if(dtUsuario.Rows.Count > 0)
                    {
                        objUsuario.Codigo = Convert.ToInt32(dtUsuario.Rows[0]["usu_n_codigo"]);
                        objUsuario.Senha = txtNovaSenha.Text;
                        objUsuario.AlterarSenha(objUsuario);

                        MessageBox.Show("Senha alterada com sucesso!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha incorretos!");
                        txtUsuario.Text = string.Empty;
                        txtSenhaAtual.Text = string.Empty;
                        txtNovaSenha.Text = string.Empty;
                        txtConfirmaSenha.Text = string.Empty;
                        txtUsuario.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("As senhas não conferem!");
                    txtNovaSenha.Text = string.Empty;
                    txtConfirmaSenha.Text = string.Empty;
                    txtNovaSenha.Focus();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
                
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = string.Empty;
            txtSenhaAtual.Text = string.Empty;
            txtNovaSenha.Text = string.Empty;
            txtConfirmaSenha.Text = string.Empty;
            this.Close();
        }
    }
}
