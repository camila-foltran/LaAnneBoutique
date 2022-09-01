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
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
            this.CarregarForm();
        }


        private void CarregarForm()
        {
            try
            {
                Usuario objUsuario = new Usuario();
                DataTable dtVendedor = new DataTable();
                objUsuario.Status = true;
                dtVendedor = objUsuario.Listar(objUsuario);
                rgvVendedor.DataSource = dtVendedor;
                rgvVendedor.Columns[2].Width = 70;
                rgvVendedor.Columns[3].Width = 200;
                rgvVendedor.Columns[4].Width = 100;
                rgvVendedor.Columns[5].Width = 300;
                rgvVendedor.Columns[6].Width = 50;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "VENDEDOR - CarregarForm");
            }
        }

        public void PopularListagem()
        {
            try
            {
                Usuario objUsuario = new Usuario();
                DataTable dtVendedor = new DataTable();
                objUsuario.Nome = txtNomeFiltro.Text.ToUpper();
                dtVendedor = objUsuario.Listar(objUsuario);
                rgvVendedor.DataSource = dtVendedor;
            }
            catch (Exception ex)
            {
                Utilitarios.SalvarLog(ex.Message, "Usuario - PopularListagem()");
            }
        }

        private void chkMostrarCaracteres_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrarCaracteres.Checked)
                txtSenha.UseSystemPasswordChar = false;
            else
                txtSenha.UseSystemPasswordChar = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlListagem.Visible = true;
            pnlCadastro.Visible = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNome.Text))
                {
                    Usuario objUsuario = new Usuario();

                    objUsuario.Nome = txtNome.Text.ToUpper();
                    objUsuario.Email = txtEmail.Text.ToUpper();
                    objUsuario.Status = chkStatus.Checked;
                    objUsuario.Login = txtLogin.Text;
                    objUsuario.Perfil = "VENDEDOR";

                    if (!string.IsNullOrEmpty(lblCodigo.Text))//edição
                    {
                        objUsuario.Codigo = Convert.ToInt32(lblCodigo.Text);
                        objUsuario.Alterar(objUsuario);
                    }
                    else //inclusao
                    {
                        objUsuario.Senha = txtSenha.Text;
                        objUsuario.Inserir(objUsuario);
                    }
                        
                    this.PopularListagem();

                    pnlListagem.Visible = true;
                    pnlCadastro.Visible = false;
                }
                else
                    MessageBox.Show("Informe o nome do vendedor!");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "USUARIO - btnSalvar_Click");
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
                Utilitarios.SalvarLog(ex.Message, "Usarui - btnPesquisar_Click");
            }
        }

        private void rgvVendedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 0)//editar; popular dados com o código 
                    {
                        Usuario objUsuario = new Usuario();
                        DataTable dtUsuario = new DataTable();
                        objUsuario.Codigo = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);
                        dtUsuario = objUsuario.Listar(objUsuario);
                        //popular campos de edição

                        lblTituloCadastro.Text = "Alterar Vendedor";
                        lblCodigo.Text = dtUsuario.Rows[0]["Código"].ToString();
                        txtNome.Text = dtUsuario.Rows[0]["Nome"].ToString();
                        txtLogin.Text = dtUsuario.Rows[0]["Login"].ToString();
                        txtEmail.Text = dtUsuario.Rows[0]["E-mail"].ToString();
                        chkStatus.Checked = Convert.ToBoolean(dtUsuario.Rows[0]["Ativo"]);

                        pnlListagem.Visible = false;
                        pnlCadastro.Visible = true;
                    }
                    else if (e.ColumnIndex == 1)//excluir
                    {
                        Usuario objUsuario = new Usuario();
                        objUsuario.Codigo = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);
                        objUsuario.Excluir(objUsuario);

                    }

                    this.PopularListagem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "FABRICANTE - rgvVendedor_CellContentClick");
            }
        }

        private void txtNomeFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!string.IsNullOrEmpty(txtNomeFiltro.Text))
                    btnPesquisar.PerformClick();

            }
        }
       

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            txtNomeFiltro.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtLogin.Text = string.Empty;
            txtSenha.Text = string.Empty;
            txtEmail.Text = string.Empty;
            chkMostrarCaracteres.Checked = false;
            pnlListagem.Visible = false;
            pnlCadastro.Visible = true;
            lblTituloCadastro.Text = "Adicionar novo vendedor";
            chkStatus.Checked = true;
            txtNome.Focus();
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!string.IsNullOrEmpty(txtNome.Text))
                    txtLogin.Focus();
                else
                    MessageBox.Show("Digite o nome do vendedor!");
            }
        }

        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!string.IsNullOrEmpty(txtNome.Text))
                    txtEmail.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!string.IsNullOrEmpty(txtEmail.Text))
                    txtSenha.Focus();
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnSalvar.PerformClick();
        }
    }
}
